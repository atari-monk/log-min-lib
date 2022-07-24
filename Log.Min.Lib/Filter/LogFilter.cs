using System.Linq.Expressions;
using Log.Min.Data;

namespace Log.Min.Lib;

public class LogFilter 
    : IFilterFactory<LogModel, LogFilterArgs>
{
    private LogFilterArgs? filterArgs;
    private DateTime dateFilter;

    private LogFilterArgs FilterArgs
    {
        get
        {
            ArgumentNullException.ThrowIfNull(filterArgs);
            return filterArgs;
        }
    }

    public Expression<Func<LogModel, bool>>? GetFilter(
        LogFilterArgs filterArgs)
    {
        SetFilter(filterArgs);
        if(IsToDoFilterOn())
            return GetToDoFilter();
        SetStartFilterValue();
        return GetFilterByStart();
    }

    private void SetFilter(LogFilterArgs filterArgs)
    {
        this.filterArgs = filterArgs;
    }

    private bool IsToDoFilterOn()
    {
        return FilterArgs.ToDoLogs;
    }

    private Expression<Func<LogModel, bool>>? GetToDoFilter()
    {
        return l => l.Start.HasValue == false && l.End.HasValue == false;
    }

    private void SetStartFilterValue()
    {
        dateFilter = FilterArgs.Start.HasValue ?
            FilterArgs.Start.Value.Date 
            : DateTime.Now.Date;
    }

    private Expression<Func<LogModel, bool>> GetFilterByStartAndCategory()
    {
        return l => l.Start.HasValue
            && l.Start.Value.Date.Equals(dateFilter);
    }

    private Expression<Func<LogModel, bool>> GetFilterByStart()
    {
        return l => l.Start.HasValue
            && l.Start.Value.Date.Equals(dateFilter);
    }    
}