using CommandDotNet;
using ModelHelper;

namespace Log.Min.Lib;

public class LogFilterArgs
    : Model
    , IArgumentModel
{
    [Option(
        shortName: 's'
        , longName: "start")]
    public DateTime? Start { get; set; }

    [Option(longName: "todo")]
    public bool ToDoLogs { get; set; }
}