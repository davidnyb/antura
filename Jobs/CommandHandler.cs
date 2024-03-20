
    //------ Example

    [HttpPost]
    public JsonResult Delete(int id)
    {
        var item = StockItem.Find(id);
        var user = HyrmaUser.GetLoggedInUser().Authorize(item).Authorize(FeatureType.DeleteStockItem);

        _commandInvoker.Execute(new DeleteStockItemCommand(item));

        return Json(new JsonResponse());
    }

    //------ Example



    public class DeleteStockItemCommand : Command
    {
        public StockItem                       StockItem { get; }
        public HyrmaConnect_IntegrationClient? Client    { get; set; }

        public DeleteStockItemCommand(StockItem stockItem, HyrmaConnect_IntegrationClient? client)
        {
            StockItem = stockItem;
            Client    = client;
        }

        public DeleteStockItemCommand(StockItem stockItem)
        {
            StockItem = stockItem;
        }
    }

    public class DeleteStockItemHandler : ICommandHandler<DeleteStockItemCommand>
    {
        public void Handle(DeleteStockItemCommand command)
        {
            var item = command.StockItem;
            item.Status = StockItemStatus.Deleted;
            item.IncludedIn.Clear();
        }
    }

    public class DeleteStockItemEventLogHandler : IEventLogHandler<DeleteStockItemCommand>
    {
        public void Handle(DeleteStockItemCommand command)
        {
            HyrmaDB.Session.Save(new LogEvent {
                EventType   = LogEventType.StockItemDeleted,
                Company     = command.Company,
                User        = command.User,
                StockItem   = command.StockItem,
                IntArgument = (long?) command.Client
            });
        }
    }
