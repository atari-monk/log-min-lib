using AutoMapper;
using CRUDCommandHelper;
using Log.Min.Data;
using Serilog;

namespace Log.Min.Lib;

public class LogInsertCommand
    : InsertCommand<ILogUnitOfWork, LogModel, LogInsertArgs>
{
    public LogInsertCommand(
        ILogUnitOfWork unitOfWork
        , ILogger log
        , IMapper mapper)
            : base(unitOfWork, log, mapper)
    {
    }

    protected override void InsertEntity(LogModel entity) =>
        UnitOfWork.Log.Insert(entity);
}