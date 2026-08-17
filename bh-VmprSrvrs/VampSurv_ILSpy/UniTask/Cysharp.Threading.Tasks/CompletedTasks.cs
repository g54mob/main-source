using Cpp2ILInjected;

namespace Cysharp.Threading.Tasks;

internal static class CompletedTasks
{
	public static readonly UniTask<AsyncUnit> AsyncUnit;

	public static readonly UniTask<bool> True;

	public static readonly UniTask<bool> False;

	public static readonly UniTask<int> Zero;

	public static readonly UniTask<int> MinusOne;

	public static readonly UniTask<int> One;

	static CompletedTasks()
	{
		//IL_0038: Expected O, but got I
		//IL_00a8: Expected O, but got I
		//IL_0118: Expected O, but got I
		//IL_0188: Expected O, but got I
		//IL_01fc: Expected O, but got I
		//IL_026c: Expected O, but got I
		_ = 0;
		_ = 0;
		_ = 0;
		_ = Cysharp.Threading.Tasks.AsyncUnit.Default;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-10]");
		AsyncUnit = (UniTask<AsyncUnit>)0;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ rcx_v8 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-10]");
		True = (UniTask<bool>)0;
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v368 @ rcx_v12 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-10]");
		False = (UniTask<bool>)0;
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v519 @ rcx_v16 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-10]");
		Zero = (UniTask<int>)0;
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v670 @ rcx_v20 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 4294967295L;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-10]");
		MinusOne = (UniTask<int>)0;
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v821 @ rcx_v24 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-10]");
		One = (UniTask<int>)0;
	}
}
