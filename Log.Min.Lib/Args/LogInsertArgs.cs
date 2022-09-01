using System.ComponentModel.DataAnnotations;
using CommandDotNet;
using ModelHelper;

namespace Log.Min.Lib;

public class  LogInsertArgs 
    : Model
    , IArgumentModel
{
    [Operand(nameof(Description))
        , MaxLength(DescriptionMax)]
    public string? Description { get; set; }

    [Operand(nameof(Start)
        , Description = DateTimeFormat)]
    public DateTime? Start { get; set; } = DateTime.Now;

    [Operand(nameof(End)
        , Description = DateTimeFormat)]
    public DateTime? End { get; set; }
}