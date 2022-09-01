using CLIHelper;
using CRUDCommandHelper;
using Log.Min.Data;
using Serilog;

namespace Log.Min.Lib;

public class LogDeleteCommand
    : DeleteCommand<ILogUnitOfWork, LogModel, DeleteArgs>
{
    public LogDeleteCommand(
        ILogUnitOfWork unitOfWork
        , ILogger log
        , IInput input) 
            : base(unitOfWork, log, input)
    {
    }

    protected override void DeleteEntity(LogModel entity) => 
        UnitOfWork.Log.Delete(entity);

    protected override LogModel GetById(int id) =>
        UnitOfWork.Log.GetById(id) ?? new LogModel();
}