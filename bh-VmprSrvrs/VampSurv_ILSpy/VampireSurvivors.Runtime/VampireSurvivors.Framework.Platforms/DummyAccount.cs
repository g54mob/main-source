using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Platforms.Saves;

namespace VampireSurvivors.Framework.Platforms;

public class DummyAccount : IBaseAccount
{
	private DummyStorage _storage;

	private DummyAchievementsManager _dummyAchievementsManager;

	public override string LocalID => m_Name;

	public override string OnlineID => m_Name;

	public override string UniqueAccountID
	{
		get
		{
			//IL_0005: Expected I, but got O
			//IL_0015: Expected O, but got I
			//IL_0025: Expected O, but got I
			nint num = (nint)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ rdx_v1 (Il2CppClass<VampireSurvivors.Framework.Platforms.DummyAccount>)+1A8]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ rdx_v1 (Il2CppClass<VampireSurvivors.Framework.Platforms.DummyAccount>)+1B0]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v2 @ rax_v1 (should have been resolved before IL gen)");
			/*Error: End of method reached without returning.*/;
		}
	}

	public override IPlatformSaveUtils Storage => _storage;

	public override IPlatformAchievementsManager AchievementsManager => _dummyAchievementsManager;

	public DummyAccount(int rewiredPlayerId = 0)
		: base(rewiredPlayerId)
	{
		_storage = new DummyStorage
		{
			_003CContinuePlayingWithoutSaving_003Ek__BackingField = true
		};
		_dummyAchievementsManager = new DummyAchievementsManager();
	}

	public override void LoginAsync(LoginOptions options, Action<LoginResult> onComplete)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A297D]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		m_Name = "Mr Dummy User";
		if (m_LoginState != LoginState.OnlineLoggingIn)
		{
			m_LoginState = LoginState.OnlineLoggingIn;
		}
		if (onComplete != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [onComplete @ r8 (System.Action`1<VampireSurvivors.Framework.Platforms.LoginResult>)+18] (should have been resolved before IL gen)");
		}
	}

	public override void GetAvailableDlc(Action<List<DlcType>> onComplete)
	{
		//IL_0018: Expected I, but got O
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_0080: Expected O, but got I
		if (onComplete != null)
		{
			nint num = (nint)typeof(DlcType);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			IntPtr intPtr = default(IntPtr);
			num = intPtr;
			if (num == 0)
			{
				ArgumentNullException ex = new ArgumentNullException("enumType");
				throw ex;
			}
			object obj3 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v235 @ rdx_v8+8F8] (should have been resolved before IL gen)");
			IEnumerable source = default(IEnumerable);
			IEnumerable<DlcType> enumerable = Enumerable.Cast<DlcType>(source);
			if (enumerable == null)
			{
				Exception ex2 = System.Linq.Error.ArgumentNull("source");
				throw ex2;
			}
			List<System.Int32Enum> list = new List<System.Int32Enum>((IEnumerable<System.Int32Enum>)enumerable);
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [onComplete @ rdx (System.Action`1<System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>>)+18] (should have been resolved before IL gen)");
		}
	}

	public override void GetLicensedDlc(Action<List<DlcType>> onComplete)
	{
		if (onComplete != null)
		{
			List<DlcType> list = new List<DlcType>();
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [onComplete @ rdx (System.Action`1<System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>>)+18] (should have been resolved before IL gen)");
		}
	}

	public override void UpdateInstalledDlc(Action onComplete)
	{
		if (onComplete != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: onComplete.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	public override void MountDlc(DlcType dlcType, Action<string> onComplete)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [onComplete @ r8 (System.Action`1<System.String>)+18] (should have been resolved before IL gen)");
	}

	public override void UnmountDlc(DlcType dlcType, Action onComplete)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: onComplete.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
	}
}
