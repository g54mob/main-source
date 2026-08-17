using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Cpp2ILInjected;
using UnityEngine.AddressableAssets;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Platforms.Saves;

namespace VampireSurvivors.Framework.Platforms.Standalone;

public class StandaloneAccount : IBaseAccount
{
	private StandaloneStorage m_Storage;

	private DummyAchievementsManager m_DummyAchievementsManager;

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
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ rdx_v1 (Il2CppClass<VampireSurvivors.Framework.Platforms.Standalone.StandaloneAccount>)+1A8]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ rdx_v1 (Il2CppClass<VampireSurvivors.Framework.Platforms.Standalone.StandaloneAccount>)+1B0]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v2 @ rax_v1 (should have been resolved before IL gen)");
			/*Error: End of method reached without returning.*/;
		}
	}

	public override IPlatformSaveUtils Storage => m_Storage;

	public override IPlatformAchievementsManager AchievementsManager => m_DummyAchievementsManager;

	public StandaloneAccount(int rewiredPlayerId = 0)
		: base(rewiredPlayerId)
	{
		StandaloneStorage standaloneStorage = new StandaloneStorage();
		Dictionary<string, StandaloneStorage.Blob> mData = new Dictionary<string, StandaloneStorage.Blob>();
		standaloneStorage._mData = mData;
		m_Storage = standaloneStorage;
		m_DummyAchievementsManager = new DummyAchievementsManager();
		SystemPlatform.OnUpdate += OnUpdate;
		SystemPlatform.OnQuit += OnDestroy;
	}

	public override void LoginAsync(LoginOptions options, Action<LoginResult> onComplete)
	{
		string userName = Environment.UserName;
		m_Name = userName;
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
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_00a7: Expected I4, but got O
		//IL_00bf: Expected O, but got I4
		//IL_0117: Expected O, but got I
		//IL_0127: Expected O, but got I
		//IL_019c: Expected O, but got I
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Expected O, but got Unknown
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Expected O, but got Unknown
		List<DlcType> list = new List<DlcType>();
		((List<DlcType>)(object)typeof(DlcType)).Add(DlcType.Foscari);
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		object obj4 = default(object);
		object obj3 = obj4;
		if (obj3 != null)
		{
			object obj5 = obj3;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v158 @ rdx_v9+8F8] (should have been resolved before IL gen)");
			List<DlcType> list2 = default(List<DlcType>);
			list2.Add((DlcType)typeof(DlcType[]));
			object obj6 = default(object);
			bool flag = obj6 == null;
			object obj7 = 0;
			if (!flag)
			{
				while (true)
				{
					object obj8 = obj7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rax_v22+18]");
					if ((nint)obj8 >= 0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+1C]");
					_ = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+10]");
					object obj9 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
					object obj10 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ r8_v8+18]");
					if (num >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rax_v22+20+v198 @ rdi_v5*4]");
						((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)0);
						obj7++;
						nint num2 = 0;
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
						object obj11 = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rax_v22+20+v198 @ rdi_v5*4]");
						_ = 0;
						obj7++;
						nint num2 = 0;
					}
				}
				if (onComplete != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [onComplete @ rdx (System.Action`1<System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>>)+18] (should have been resolved before IL gen)");
				}
				return;
			}
			throw new InvalidCastException();
		}
		ArgumentNullException ex = new ArgumentNullException("enumType");
		throw ex;
	}

	public override void UpdateInstalledDlc(Action onComplete)
	{
		if (onComplete != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: onComplete.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	public unsafe override void MountDlc(DlcType dlcType, Action<string> onComplete)
	{
		//IL_0094: Expected O, but got Ref
		//IL_009d: Expected O, but got I4
		//IL_0183: Expected O, but got I4
		//IL_03d2: Expected O, but got Ref
		//IL_03ed: Expected O, but got Ref
		//IL_0130: Expected O, but got I
		//IL_0139: Expected O, but got I4
		//IL_02b6: Expected O, but got I
		//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c4: Expected O, but got Unknown
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Expected O, but got Unknown
		//IL_028e: Expected I, but got O
		//IL_01f9: Expected O, but got Ref
		//IL_0269: Expected I, but got O
		if (Addressables.m_AddressablesInstance != null)
		{
			string playerBuildDataPath = Addressables.m_AddressablesInstance.PlayerBuildDataPath;
			string path = Path.Combine(playerBuildDataPath, "StandaloneWindows64");
			IEnumerable<string> enumerable = Directory.EnumerateFiles(path);
			if (enumerable != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				object obj2 = default(object);
				object obj = (object)(&obj2);
				object obj3 = 0;
				string text = null;
				object obj4 = default(object);
				IntPtr intPtr = default(IntPtr);
				string text4 = default(string);
				IntPtr intPtr2 = default(IntPtr);
				object obj14 = default(object);
				while (true)
				{
					object obj6;
					object obj13;
					if (obj2 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						if (obj4 == null)
						{
							break;
						}
						bool flag = obj2 == null;
						text = null;
						if (!flag)
						{
							object obj5 = obj2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ r10_v8+12E]");
							if ((nint)0 >= (nint)0)
							{
								goto IL_0170;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ r10_v8+B0]");
							obj6 = 0;
							object obj7 = 0;
							while (true)
							{
								object obj8 = obj7 + obj7;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v367 @ r8_v14+v618 @ rax_v49*8]");
								if (0 == (nint)typeof(IEnumerator<string>))
								{
									break;
								}
								obj7++;
								object obj9 = obj7;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ r10_v8+12E]");
								if ((nint)obj9 < 0)
								{
									continue;
								}
								goto IL_0170;
							}
							object obj10 = obj7 + obj7;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v367 @ r8_v14+8+v676 @ rcx_v40*8]");
							object obj11 = (nint)0 << 4;
							object obj12 = obj11 + 312;
							obj13 = obj12 + obj5;
							goto IL_03bf;
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
					IL_03bf:
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v681 @ rdx_v17] (should have been resolved before IL gen)");
					string text2 = ((Enum)(&intPtr)).ToString();
					bool flag2 = text2 == null;
					text = (string)(&intPtr);
					if (!flag2)
					{
						string text3 = text2.ToLowerInvariant();
						string value = text3 + "_persistent";
						if (text4 != null)
						{
							nint num;
							if (!text4.Contains(value))
							{
								string text5 = ((Enum)(&intPtr2)).ToString();
								if (text5 == null)
								{
									throw new NullReferenceException();
								}
								string text6 = text5.ToLowerInvariant();
								string value2 = text6 + "_dynamic";
								bool flag3 = text4.Contains(value2);
								bool flag4 = !flag3;
								num = (nint)typeof(IEnumerator<string>);
								if (flag4)
								{
									continue;
								}
							}
							obj3 = "";
							num = (nint)typeof(IEnumerator<string>);
							continue;
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
					IL_0170:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
					obj6 = 0;
					obj13 = obj14;
					goto IL_03bf;
				}
				if (obj != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
				}
				if (onComplete != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [onComplete @ r8 (System.Action`1<System.String>)+18] (should have been resolved before IL gen)");
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void UnmountDlc(DlcType dlcType, Action onComplete)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: onComplete.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
	}

	public override bool DoesSupportWindowModes()
	{
		return true;
	}

	public override bool DoesSupportVSync()
	{
		return true;
	}

	public override bool DoesPlayer1NeedController()
	{
		return false;
	}

	private void OnUpdate()
	{
	}

	private void OnDestroy()
	{
		Action value = OnUpdate;
		SystemPlatform.OnUpdate -= value;
		Action value2 = OnDestroy;
		SystemPlatform.OnQuit -= value2;
	}
}
