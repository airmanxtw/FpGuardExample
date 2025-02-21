namespace TestFpGuardExample;
using FpGuardExample.Example;
using LanguageExt.UnitTesting;

[TestClass]
public class UnitTest1
{

    [TestMethod]
    public void TestMethod0()
    {
        List<ApplyForm> form =
        [
            new ApplyForm("機車", "123"),
        ];

        FpGuardExample.SubmitForm(form)
        .ShouldBeRight(r => Assert.AreEqual(form, r));
    }

    [TestMethod]
    public void TestMethod1()
    {
        List<ApplyForm> form =
        [
            new ApplyForm("機車", "123"),
            new ApplyForm("汽車", "456"),
        ];
        FpGuardExample.SubmitForm(form)
        .ShouldBeRight(r => Assert.AreEqual(form, r));

    }

    [TestMethod]
    public void TestMethod2()
    {
        List<ApplyForm> form =
        [
            new ApplyForm("機車", "123"),
            new ApplyForm("機車", "456"),
            new ApplyForm("汽車", "789"),
        ];
        FpGuardExample.SubmitForm(form)
        .ShouldBeLeft(e => Assert.AreEqual("同一車種不可重複申請", e.Message));
    }
}