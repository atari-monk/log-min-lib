using AutoMapper;
using CRUDCommandHelper;
using Log.Min.Data;
using Serilog;

namespace Log.Min.Lib;

public class LogUpdateCommand
    : UpdateCommand<ILogUnitOfWork, LogModel, LogUpdateResetArgs, LogUpdate>
{
    public LogUpdateCommand(
        ILogUnitOfWork unitOfWork
        , ILogger log
        , IMapper mapper)
            : base(unitOfWork, log, mapper)
    {
    }

    protected override LogModel GetById(int id) =>
        UnitOfWork.Log.GetById(id) ?? new LogModel();
}