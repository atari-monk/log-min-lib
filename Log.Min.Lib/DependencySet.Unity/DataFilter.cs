using DIHelper.Unity;
using Log.Min.Data;
using Unity;

namespace Log.Min.Lib;

public class DataFilter 
    : UnityDependencySet
{
    public DataFilter(
        IUnityContainer container) 
            : base(container)
    {
    }

    public override void Register()
    {
        Container
            .RegisterSingleton<
                IFilterFactory<LogModel, LogFilterArgs>
                , LogFilter>();
    }
}