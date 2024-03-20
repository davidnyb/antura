    public abstract class Command
    {
        public Company   Company { get; set; }
        public HyrmaUser User    { get; set; }
    }

    public abstract class ResultCommand<TResult> : Command
    {
        public TResult Result { get; set; }
    }

    public interface ICommandInvoker
    {
        void Execute<TCommand>(TCommand command) where TCommand : Command;
    }

    public interface ICommandHandler<in TCommand>
    {
        void Handle(TCommand command);
    }

    public interface IEventLogHandler<in TCommand>
    {
        void Handle(TCommand command);
    }

