using CLIHelper;
using CRUDCommandHelper;
using DataToTable;
using Log.Min.Data;
using Serilog;

namespace Log.Min.Lib;

public class LogReadCommand
    : ReadCommand<ILogUnitOfWork, LogModel, LogFilterArgs>
{
    private readonly IFilterFactory<LogModel, LogFilterArgs> filterFactory;

    public LogReadCommand(
        ILogUnitOfWork unitOfWork
        , IOutput output
        , ILogger log
        , IDataToText<LogModel> textProvider
        , IFilterFactory<LogModel, LogFilterArgs> filterFactory)
            : base(unitOfWork, output, log, textProvider)
    {
        this.filterFactory = filterFactory;
    }

    protected override List<LogModel> Get(LogFilterArgs model)
    {
        var list = UnitOfWork.Log.GetLog(
            filterFactory.GetFilter(model)).ToList();
        foreach (var item in list)
        {
            Output.WriteLine(GetMsg(item));
        }
        return list;
    }

    private string GetMsg(LogModel item)
    {
        return $"log ins x \"{item.Description}\" 1 \"{item.Start?.ToString(LogFilterArgs.DateTimeFormat)}\" \"{item.End?.ToString(LogFilterArgs.DateTimeFormat)}\"";
    }
}