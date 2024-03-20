    public class CommandInvoker : ICommandInvoker
    {
        public static TCommand Invoke<TCommand>(TCommand command) where TCommand : Command
        {
            var dependencyResolver = DependencyResolver.Current;
            var commandInvoker     = dependencyResolver.GetService<ICommandInvoker>();
            commandInvoker.Execute(command);
            return command;
        }

        public void Execute<TCommand>(TCommand command) where TCommand : Command
        {
            // do not override command with user and company already set
            command.User    = command.User    ?? HyrmaUser.GetLoggedInUser();
            command.Company = command.Company ?? command.User?.Company;

            var dependencyResolver = DependencyResolver.Current;

            var commandHandler = dependencyResolver.GetService<ICommandHandler<TCommand>>();
            commandHandler.Handle(command);

            var eventLogHandler = dependencyResolver.GetService<IEventLogHandler<TCommand>>();
            eventLogHandler?.Handle(command);
        }
    }

