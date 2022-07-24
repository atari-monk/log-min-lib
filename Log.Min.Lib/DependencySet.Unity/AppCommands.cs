using CRUDCommandHelper;
using DIHelper.Unity;
using Unity;

namespace Log.Min.Lib;

public class AppCommands 
    : UnityDependencySet
{
    public AppCommands(
        IUnityContainer container) 
        : base(container)
    {
    }

    public override void Register()
    {
        Container
            .RegisterSingleton<IReadCommand<LogFilterArgs>, LogReadCommand>()
            .RegisterSingleton<IInsertCommand<Lib.LogInsertArgs>, LogInsertCommand>()
            .RegisterSingleton<IUpdateCommand<LogUpdateResetArgs>, LogUpdateCommand>()
            .RegisterSingleton<IDeleteCommand<DeleteArgs>, LogDeleteCommand>();
    }
}