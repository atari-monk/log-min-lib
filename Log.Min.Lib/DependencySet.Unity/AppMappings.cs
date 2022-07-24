using AutoMapper;
using Log.Min.Data;
using Unity;

namespace Log.Min.Lib;

public class AppMappings 
    : ModelHelper.AppMappings
{
    public AppMappings(
        IUnityContainer container)
        : base(container)
    {
    }

    protected override MapperConfiguration CreateMap() => 
        new (
        c =>
        {
            c.CreateMap<LogInsertArgs, LogModel>();
            c.CreateMap<LogUpdateResetArgs, LogUpdate>();
        });
}