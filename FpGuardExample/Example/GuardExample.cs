namespace FpGuardExample.Example;
using LanguageExt;
using LanguageExt.Common;
using static LanguageExt.Prelude;

public record ApplyForm(string PlateType, string PlateNo);
public class FpGuardExample
{
    public static Either<Error, List<ApplyForm>> SubmitForm(List<ApplyForm> form) =>
    guard(form.GroupBy(f => f.PlateType).All(g => g.Count() <= 1), Error.New("同一車種不可重複申請"))
    .ToEither()
    .Map(constant<List<ApplyForm>, Unit>(form));
}