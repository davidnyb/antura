
    public enum JobType
    {
        LeaseBilling   = 1,
        InvoiceMerging = 2,
        InvoiceClosing = 3,
    }

    public abstract class Job
    {
        public abstract JobType Type { get; }

        public virtual int       Id         { get; set; }
        public virtual JobStatus Status     { get; set; }
        public virtual DateTime? StartedAt  { get; set; }
        public virtual DateTime? FinishedAt { get; set; }

        public virtual Company   Company { get; set; }
        public virtual HyrmaUser User    { get; set; }

        public virtual IList<JobTask> Tasks { get; set; }

        public virtual InvoiceClosing InvoiceClosing => new InvoiceClosing(this);
        public virtual LeaseBilling   LeaseBilling   => new LeaseBilling(this);

        public virtual bool?     BoolArg  { get; set; }
        public virtual int?      IntArg   { get; set; }
        public virtual DateTime? DateArg  { get; set; }
        public virtual DateTime? DateArg2 { get; set; }

        //...
    }
