using System.ComponentModel.DataAnnotations;
using CommandDotNet;
using DotNetExtension;
using Log.Min.Data;
using ModelHelper;

namespace Log.Min.Lib;

[AtLeastOneProperty(
    nameof(LogModel.Description)
    , nameof(LogModel.Start)
    , nameof(LogModel.End)
    , nameof(LogModel.TimeTicks)
    , "EndNow"
    , "StartNow"
    , "ResetStart"
    , "ResetEnd"
    , ErrorMessage = UpdateError)]
public class LogUpdateArgs 
    : Model
    , IArgumentModel
    , IId
{
    private const string UpdateError = 
        "You must supply Description or Start or End or TimeTicks"
        + "or EndNow or StartNow or ResetStart or ResetEnd";

    [Operand(
        "id")
        , Required
        , Range(IdMin, IdMax, ErrorMessage = IdError)]
    public int Id { get; set; }

    [Option(
        'd'
        , "description")
        , MaxLength(DescriptionMax)]
    public string? Description { get; set; }

    [Option(
        's'
        , "start")]
    public DateTime? Start { get; set; }

    [Option(
        'e'
        , "end")]
    public DateTime? End { get; set; }

    [Option(
        'i'
        , "ticks")]
    public int? TimeTicks { get; set; }
}