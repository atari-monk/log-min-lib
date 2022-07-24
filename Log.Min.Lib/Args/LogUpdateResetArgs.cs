using CommandDotNet;

namespace Log.Min.Lib;

public class LogUpdateResetArgs
    : LogUpdateToNowArgs
{
    [Option(
        "rstart")]
    public bool? ResetStart { get; set; }

    [Option(
        "rend")]
    public bool? ResetEnd { get; set; }
}
