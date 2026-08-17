using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Cpp2ILInjected;
using Cysharp.Threading.Tasks;
using Steamworks;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Platforms;
using VampireSurvivors.Framework.Platforms.Saves;
using VampireSurvivors.Framework.Platforms.SteamworksIntegration;
using VampireSurvivors.Objects;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Framework.Saves;

public static class Migrator
{
	private class MigratorLoadingState
	{
		public bool loadedOldSave;

		public bool showedDialog;
	}

	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action _003C_003E9__1_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CAttemptMigration_003Eb__1_0()
		{
		}
	}

	private sealed class _003C_003Ec__DisplayClass2_0
	{
		public MigratorLoadingState state;

		public Action<StorageResult> _003C_003E9__0;

		internal void _003CTryLoadingFromLocations_003Eb__0(StorageResult result)
		{
			switch (result)
			{
			case StorageResult.NothingToCommit:
			{
				MigratorLoadingState migratorLoadingState2 = state;
				migratorLoadingState2.showedDialog = true;
				break;
			}
			case StorageResult.Successful:
			{
				MigratorLoadingState migratorLoadingState = state;
				migratorLoadingState.loadedOldSave = true;
				break;
			}
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public byte[] data;

		public PlayerOptions playerOptions;

		public Action<StorageResult> onComplete;

		public bool done;

		internal void _003CTryLoadFromBytes_003Eb__0(byte[] resolvedData)
		{
			//IL_0036: Expected O, but got I4
			//IL_00cd: Expected O, but got I4
			//IL_00b0: Expected O, but got I4
			if (resolvedData != data)
			{
				Action<StorageResult> action = onComplete;
				object obj = 8;
			}
			else
			{
				PlayerOptionsData playerOptionsData = SaveUtils.TryParseData(data);
				if (playerOptionsData != null)
				{
					bool onlineClientWithRunData = default(bool);
					playerOptions.ApplyConfig(playerOptionsData, adventureMode: false, hostConfig: false, onlineClientWithRunData);
					Debug.Log("apply config done!");
					Action<StorageResult> action = onComplete;
					object obj = 0;
				}
				else
				{
					Action<StorageResult> action = onComplete;
					object obj = 9;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v155 @ rax_v1 (System.Action`1<VampireSurvivors.Framework.Platforms.Saves.StorageResult>)+18] (should have been resolved before IL gen)");
			done = true;
		}
	}

	private sealed class _003CAttemptMigration_003Ed__1(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public PlayerOptions playerOptions;

		private byte[] _003CcurrentData_003E5__2;

		private List<string> _003CdirectoriesToTry_003E5__3;

		private MigratorLoadingState _003Cstate_003E5__4;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_0008: Expected O, but got Ref
			//IL_047f: Expected I4, but got I8
			//IL_0b12: Expected I4, but got O
			//IL_001d: Expected O, but got I4
			//IL_0078: Expected I4, but got I8
			//IL_005a: Expected I4, but got I8
			//IL_02aa: Expected O, but got I4
			//IL_0272: Unknown result type (might be due to invalid IL or missing references)
			//IL_0277: Expected O, but got Unknown
			//IL_029c: Expected O, but got I
			//IL_02f4: Expected O, but got I4
			//IL_0573: Expected I, but got O
			//IL_057b: Expected I, but got O
			//IL_058b: Expected O, but got I
			//IL_02b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_02be: Expected O, but got Unknown
			//IL_02e6: Expected O, but got I
			//IL_08b7: Expected O, but got I4
			//IL_060b: Expected O, but got I4
			//IL_087f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0884: Expected O, but got Unknown
			//IL_08a9: Expected O, but got I
			//IL_05c7: Expected O, but got I
			//IL_033e: Expected O, but got I4
			//IL_0bd7: Expected O, but got Ref
			//IL_0bea: Expected O, but got Ref
			//IL_0bfd: Expected O, but got Ref
			//IL_0303: Unknown result type (might be due to invalid IL or missing references)
			//IL_0308: Expected O, but got Unknown
			//IL_0330: Expected O, but got I
			//IL_0901: Expected O, but got I4
			//IL_05fd: Expected O, but got I4
			//IL_08c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_08cb: Expected O, but got Unknown
			//IL_08f3: Expected O, but got I
			//IL_0384: Expected O, but got I4
			//IL_034c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0351: Expected O, but got Unknown
			//IL_0376: Expected O, but got I
			//IL_03ce: Expected O, but got I4
			//IL_0e70: Expected O, but got Ref
			//IL_0393: Unknown result type (might be due to invalid IL or missing references)
			//IL_0398: Expected O, but got Unknown
			//IL_03c0: Expected O, but got I
			//IL_0418: Expected O, but got I4
			//IL_094a: Expected O, but got Ref
			//IL_095d: Expected O, but got Ref
			//IL_06d2: Expected O, but got I4
			//IL_0c63: Expected O, but got Ref
			//IL_0c76: Expected O, but got Ref
			//IL_0c89: Expected O, but got Ref
			//IL_03dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_03e2: Expected O, but got Unknown
			//IL_040a: Expected O, but got I
			//IL_069a: Unknown result type (might be due to invalid IL or missing references)
			//IL_069f: Expected O, but got Unknown
			//IL_06c4: Expected O, but got I
			//IL_09fb: Expected O, but got I4
			//IL_044d: Expected O, but got I4
			//IL_09c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_09c8: Expected O, but got Unknown
			//IL_09ed: Expected O, but got I
			//IL_0718: Expected O, but got I4
			//IL_06e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_06e5: Expected O, but got Unknown
			//IL_070a: Expected O, but got I
			//IL_0a45: Expected O, but got I4
			//IL_0730: Expected O, but got Ref
			//IL_0743: Expected O, but got Ref
			//IL_0a0a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a0f: Expected O, but got Unknown
			//IL_0a37: Expected O, but got I
			//IL_0a8f: Expected O, but got I4
			//IL_0ecf: Expected O, but got Ref
			//IL_0ee2: Expected O, but got Ref
			//IL_0ef5: Expected O, but got Ref
			//IL_0a54: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a59: Expected O, but got Unknown
			//IL_0a81: Expected O, but got I
			//IL_07c8: Expected O, but got I4
			//IL_0790: Unknown result type (might be due to invalid IL or missing references)
			//IL_0795: Expected O, but got Unknown
			//IL_07ba: Expected O, but got I
			//IL_0812: Expected O, but got I4
			//IL_0ae1: Expected O, but got I4
			//IL_07d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_07dc: Expected O, but got Unknown
			//IL_0804: Expected O, but got I
			//IL_0858: Expected O, but got I4
			//IL_0db1: Expected O, but got Ref
			//IL_0dc4: Expected O, but got Ref
			//IL_0dd7: Expected O, but got Ref
			//IL_0820: Unknown result type (might be due to invalid IL or missing references)
			//IL_0825: Expected O, but got Unknown
			//IL_084a: Expected O, but got I
			object obj2 = default(object);
			object obj = (object)(&obj2);
			bool flag = _003C_003E1__state == 0;
			bool flag2 = default(bool);
			string platformSpecificParentPath;
			SystemPlatform sInstance;
			object obj22;
			if (!flag)
			{
				object obj3 = _003C_003E1__state - 1;
				if (!flag)
				{
					if ((nint)obj3 == 1)
					{
						_003C_003E1__state = -1;
						goto IL_00b9;
					}
					goto IL_01a6;
				}
				MigratorLoadingState migratorLoadingState = _003Cstate_003E5__4;
				_003C_003E1__state = -1;
				if (_003Cstate_003E5__4 != null)
				{
					if (migratorLoadingState.loadedOldSave)
					{
						goto IL_00b9;
					}
					List<string> list = _003CdirectoriesToTry_003E5__3;
					if (_003CdirectoriesToTry_003E5__3 != null)
					{
						int version = list._version + 1;
						list._version = version;
						list._size = 0;
						if (list._size > 0)
						{
							Array.Clear(list._items, 0, list._size);
						}
						string fullPath = Path.GetFullPath(".");
						if (fullPath != null)
						{
							object obj4 = fullPath + 20;
							_ = 0;
							_ = fullPath._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-19]");
							object obj5 = 0;
						}
						else
						{
							object obj5 = 0;
						}
						object obj6 = "resources";
						if ("resources" != null)
						{
							object obj7 = "resources" + 20;
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v760 @ rsi_v10+10]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-19]");
							object obj8 = 0;
						}
						else
						{
							object obj8 = 0;
						}
						object obj9 = "app";
						if ("app" != null)
						{
							object obj10 = "app" + 20;
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v842 @ rsi_v11+10]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-19]");
							object obj11 = 0;
						}
						else
						{
							object obj11 = 0;
						}
						ReadOnlySpan<char> path = (ReadOnlySpan<char>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
						ReadOnlySpan<char> path2 = (ReadOnlySpan<char>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
						ReadOnlySpan<char> path3 = (ReadOnlySpan<char>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
						string text = Path.Join(path3, path2, path);
						if (text != null)
						{
							object obj12 = text + 20;
							_ = 0;
							_ = text._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-19]");
							object obj13 = 0;
						}
						else
						{
							object obj13 = 0;
						}
						object obj14 = ".webpack";
						if (".webpack" != null)
						{
							object obj15 = ".webpack" + 20;
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1177 @ rsi_v13+10]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-19]");
							object obj16 = 0;
						}
						else
						{
							object obj16 = 0;
						}
						object obj17 = "renderer";
						if ("renderer" != null)
						{
							object obj18 = "renderer" + 20;
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rsi_v14+10]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-19]");
							object obj19 = 0;
						}
						else
						{
							object obj19 = 0;
						}
						ReadOnlySpan<char> path4 = (ReadOnlySpan<char>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
						ReadOnlySpan<char> path5 = (ReadOnlySpan<char>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
						ReadOnlySpan<char> path6 = (ReadOnlySpan<char>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
						string item = Path.Join(path6, path5, path4);
						if (_003CdirectoriesToTry_003E5__3 != null)
						{
							_003CdirectoriesToTry_003E5__3.Add(item);
							IEnumerator enumerator = TryLoadingFromLocations(_003CdirectoriesToTry_003E5__3, _003CcurrentData_003E5__2, playerOptions, _003Cstate_003E5__4, (string)flag2);
							_003C_003E2__current = enumerator;
							_003C_003E1__state = 2;
							goto IL_0f29;
						}
					}
				}
			}
			else
			{
				_003C_003E1__state = -1;
				if (playerOptions != null)
				{
					PlayerOptionsData config = playerOptions.Config;
					string rawData = SaveSerializer.Serialize(config);
					string s = SaveUtils.UpdateChecksum(rawData);
					Encoding uTF = Encoding.UTF8;
					if (uTF != null)
					{
						byte[] bytes = uTF.GetBytes(s);
						_003CcurrentData_003E5__2 = bytes;
						platformSpecificParentPath = GetPlatformSpecificParentPath();
						List<string> list2 = new List<string>();
						_003CdirectoriesToTry_003E5__3 = list2;
						sInstance = SystemPlatform.sInstance;
						if (SystemPlatform.sInstance != null)
						{
							IBaseAccount currentSystem = sInstance.m_CurrentSystem;
							if (sInstance.m_CurrentSystem != null)
							{
								nint num = (nint)typeof(SteamworksAccount);
								nint num2 = (nint)currentSystem;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v972 @ r8_v26 (Il2CppClass<VampireSurvivors.Framework.Platforms.SteamworksIntegration.SteamworksAccount>)+130]");
								object obj20 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ r9_v8 (Il2CppClass<VampireSurvivors.Framework.Platforms.IBaseAccount>)+130]");
								nint num3 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v972 @ r8_v26 (Il2CppClass<VampireSurvivors.Framework.Platforms.SteamworksIntegration.SteamworksAccount>)+130]");
								if (num3 >= 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ r9_v8 (Il2CppClass<VampireSurvivors.Framework.Platforms.IBaseAccount>)+C8]");
									object obj21 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1063 @ rax_v125+FFFFFFF8+v973 @ rax_v80*8]");
									if (0 == (nint)typeof(SteamworksAccount))
									{
										obj22 = 1;
										goto IL_0cf6;
									}
								}
								obj22 = 0;
								goto IL_0cf6;
							}
							goto IL_0e0b;
						}
					}
				}
			}
			goto IL_0b04;
			IL_0cf6:
			bool flag3 = obj22 == null;
			IBaseAccount baseAccount = null;
			if (!flag3)
			{
				baseAccount = sInstance.m_CurrentSystem;
			}
			if (baseAccount != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v998 @ rax_v83 (VampireSurvivors.Framework.Platforms.IBaseAccount)+78]");
				if ((nint)0 != 0)
				{
					SteamId steamId = SteamClient.SteamId;
					CultureInfo invariantCulture = CultureInfo.InvariantCulture;
					uint num4 = (uint)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
					string text2 = ((uint*)num4)->ToString(invariantCulture);
					if (platformSpecificParentPath != null)
					{
						object obj23 = platformSpecificParentPath + 20;
						_ = 0;
						_ = platformSpecificParentPath._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-19]");
						object obj24 = 0;
					}
					else
					{
						object obj24 = 0;
					}
					string text3 = "Vampire_Survivors_" + text2;
					if (text3 != null)
					{
						object obj25 = text3 + 20;
						_ = 0;
						_ = text3._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-19]");
						object obj26 = 0;
					}
					else
					{
						object obj26 = 0;
					}
					ReadOnlySpan<char> path7 = (ReadOnlySpan<char>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
					ReadOnlySpan<char> path8 = (ReadOnlySpan<char>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
					string item2 = Path.Join(path8, path7);
					if (_003CdirectoriesToTry_003E5__3 != null)
					{
						_003CdirectoriesToTry_003E5__3.Add(item2);
						if (platformSpecificParentPath != null)
						{
							object obj27 = platformSpecificParentPath + 20;
							_ = 0;
							_ = platformSpecificParentPath._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-19]");
							object obj28 = 0;
						}
						else
						{
							object obj28 = 0;
						}
						object obj29 = "Vampire_Survivors_Data";
						if ("Vampire_Survivors_Data" != null)
						{
							object obj30 = "Vampire_Survivors_Data" + 20;
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ r14_v9+10]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-19]");
							object obj31 = 0;
						}
						else
						{
							object obj31 = 0;
						}
						if (text2 != null)
						{
							object obj32 = text2 + 20;
							_ = 0;
							_ = text2._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-19]");
							object obj33 = 0;
						}
						else
						{
							object obj33 = 0;
						}
						ReadOnlySpan<char> path9 = (ReadOnlySpan<char>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
						ReadOnlySpan<char> path10 = (ReadOnlySpan<char>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
						ReadOnlySpan<char> path11 = (ReadOnlySpan<char>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
						string item3 = Path.Join(path11, path10, path9);
						if (_003CdirectoriesToTry_003E5__3 != null)
						{
							_003CdirectoriesToTry_003E5__3.Add(item3);
							goto IL_0e0b;
						}
					}
					goto IL_0b04;
				}
			}
			goto IL_0e0b;
			IL_0e0b:
			object obj35;
			if (platformSpecificParentPath != null)
			{
				object obj34 = platformSpecificParentPath + 20;
				_ = 0;
				_ = platformSpecificParentPath._stringLength;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-19]");
				obj35 = 0;
			}
			else
			{
				obj35 = 0;
			}
			object obj36 = "Vampire_Survivors_Data";
			object obj38;
			if ("Vampire_Survivors_Data" != null)
			{
				object obj37 = "Vampire_Survivors_Data" + 20;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ r14_v6+10]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-19]");
				obj38 = 0;
			}
			else
			{
				obj38 = 0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
			string item4;
			if (obj35 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
				if (obj38 != null)
				{
					ReadOnlySpan<char> second = (ReadOnlySpan<char>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
					ReadOnlySpan<char> first = (ReadOnlySpan<char>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
					item4 = Path.JoinInternal(first, second);
					goto IL_0987;
				}
			}
			ReadOnlySpan<char> value = (ReadOnlySpan<char>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
			item4 = ((string)null).CreateString(value);
			goto IL_0987;
			IL_00b9:
			MigratorLoadingState migratorLoadingState2 = _003Cstate_003E5__4;
			if (_003Cstate_003E5__4 != null)
			{
				if (!migratorLoadingState2.loadedOldSave)
				{
					if (!migratorLoadingState2.showedDialog)
					{
						Action callback = _003C_003Ec._003C_003E9__1_0;
						if (_003C_003Ec._003C_003E9__1_0 == null)
						{
							callback = (_003C_003Ec._003C_003E9__1_0 = delegate
							{
							});
						}
						bool descriptionIsLocalizationTerm = default(bool);
						PopupManager.CreateWarningPopup("Recover-Old-Data-Failed", "lang/failed_load_save_data", "No backup data was found!", callback, flag2, descriptionIsLocalizationTerm);
						return false;
					}
				}
				else
				{
					if (playerOptions == null)
					{
						goto IL_0b04;
					}
					playerOptions.Save();
					UniTaskVoid uniTaskVoid = VSUtils.RestartAppWithFrameDelay();
				}
				goto IL_01a6;
			}
			goto IL_0b04;
			IL_0f29:
			return true;
			IL_01a6:
			return false;
			IL_0987:
			if (_003CdirectoriesToTry_003E5__3 != null)
			{
				_003CdirectoriesToTry_003E5__3.Add(item4);
				if (platformSpecificParentPath != null)
				{
					object obj39 = platformSpecificParentPath + 20;
					_ = 0;
					_ = platformSpecificParentPath._stringLength;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-19]");
					object obj40 = 0;
				}
				else
				{
					object obj40 = 0;
				}
				object obj41 = "Vampire_Survivors";
				if ("Vampire_Survivors" != null)
				{
					object obj42 = "Vampire_Survivors" + 20;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1546 @ rsi_v6+10]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-19]");
					object obj43 = 0;
				}
				else
				{
					object obj43 = 0;
				}
				object obj44 = "saves";
				if ("saves" != null)
				{
					object obj45 = "saves" + 20;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rsi_v7+10]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-19]");
					object obj46 = 0;
				}
				else
				{
					object obj46 = 0;
				}
				ReadOnlySpan<char> path12 = (ReadOnlySpan<char>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
				ReadOnlySpan<char> path13 = (ReadOnlySpan<char>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
				ReadOnlySpan<char> path14 = (ReadOnlySpan<char>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
				string item5 = Path.Join(path14, path13, path12);
				if (_003CdirectoriesToTry_003E5__3 != null)
				{
					_003CdirectoriesToTry_003E5__3.Add(item5);
					MigratorLoadingState migratorLoadingState3 = new MigratorLoadingState();
					_003Cstate_003E5__4 = migratorLoadingState3;
					IEnumerator enumerator2 = TryLoadingFromLocations(_003CdirectoriesToTry_003E5__3, _003CcurrentData_003E5__2, playerOptions, _003Cstate_003E5__4, (string)flag2);
					_003C_003E2__current = enumerator2;
					_003C_003E1__state = 1;
					goto IL_0f29;
				}
			}
			goto IL_0b04;
			IL_0b04:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private sealed class _003CTryLoadFromBytes_003Ed__5(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public byte[] data;

		public PlayerOptions playerOptions;

		public Action<StorageResult> onComplete;

		public byte[] currentData;

		private _003C_003Ec__DisplayClass5_0 _003C_003E8__1;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0136: Expected I4, but got I8
			//IL_0191: Expected I4, but got O
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				_003C_003Ec__DisplayClass5_0 obj = new _003C_003Ec__DisplayClass5_0();
				_003C_003E8__1 = obj;
				_003C_003Ec__DisplayClass5_0 obj2 = _003C_003E8__1;
				if (_003C_003E8__1 != null)
				{
					obj2.data = data;
					_003C_003Ec__DisplayClass5_0 obj3 = _003C_003E8__1;
					if (_003C_003E8__1 != null)
					{
						obj3.playerOptions = playerOptions;
						_003C_003Ec__DisplayClass5_0 obj4 = _003C_003E8__1;
						if (_003C_003E8__1 != null)
						{
							obj4.onComplete = onComplete;
							_003C_003Ec__DisplayClass5_0 obj5 = _003C_003E8__1;
							if (_003C_003E8__1 != null)
							{
								obj5.done = false;
								_003C_003Ec__DisplayClass5_0 obj6 = _003C_003E8__1;
								if (_003C_003E8__1 != null)
								{
									Action<byte[]> action = delegate(byte[] resolvedData)
									{
										//IL_0036: Expected O, but got I4
										//IL_00cd: Expected O, but got I4
										//IL_00b0: Expected O, but got I4
										if (resolvedData != _003C_003E8__1.data)
										{
											Action<StorageResult> action2 = _003C_003E8__1.onComplete;
											object obj8 = 8;
										}
										else
										{
											PlayerOptionsData playerOptionsData = SaveUtils.TryParseData(_003C_003E8__1.data);
											if (playerOptionsData != null)
											{
												bool onlineClientWithRunData = default(bool);
												_003C_003E8__1.playerOptions.ApplyConfig(playerOptionsData, adventureMode: false, hostConfig: false, onlineClientWithRunData);
												Debug.Log("apply config done!");
												Action<StorageResult> action2 = _003C_003E8__1.onComplete;
												object obj8 = 0;
											}
											else
											{
												Action<StorageResult> action2 = _003C_003E8__1.onComplete;
												object obj8 = 9;
											}
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v155 @ rax_v1 (System.Action`1<VampireSurvivors.Framework.Platforms.Saves.StorageResult>)+18] (should have been resolved before IL gen)");
										_003C_003E8__1.done = true;
									};
									SaveSystem.HandleConflictResolution(currentData, obj6.data, action);
									goto IL_022e;
								}
							}
						}
					}
				}
				goto IL_0183;
			}
			if (_003C_003E1__state != 1)
			{
				goto IL_017d;
			}
			_003C_003E1__state = -1;
			goto IL_022e;
			IL_022e:
			_003C_003Ec__DisplayClass5_0 obj7 = _003C_003E8__1;
			if (_003C_003E8__1 != null)
			{
				if (!obj7.done)
				{
					_003C_003E2__current = null;
					_003C_003E1__state = 1;
					return true;
				}
				goto IL_017d;
			}
			goto IL_0183;
			IL_017d:
			return false;
			IL_0183:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private sealed class _003CTryLoadFromPath_003Ed__4(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public string filePath;

		public Action<StorageResult> onComplete;

		public byte[] currentData;

		public PlayerOptions playerOptions;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0031: Expected I4, but got I8
			//IL_0116: Expected I4, but got I8
			//IL_0129: Expected I4, but got O
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				if (!File.Exists(filePath))
				{
					Action<StorageResult> action = onComplete;
					if (onComplete != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v75 @ rax_v5 (System.Action`1<VampireSurvivors.Framework.Platforms.Saves.StorageResult>)+18] (should have been resolved before IL gen)");
						return false;
					}
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				byte[] array = File.ReadAllBytes(filePath);
				if (array != null)
				{
					IEnumerator enumerator = TryLoadFromBytes(array, currentData, playerOptions, onComplete);
					_003C_003E2__current = enumerator;
					_003C_003E1__state = 1;
					return true;
				}
			}
			else if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private sealed class _003CTryLoadingFromLocations_003Ed__2(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public MigratorLoadingState state;

		public List<string> directoriesToTry;

		public string filename;

		public byte[] currentData;

		public PlayerOptions playerOptions;

		private _003C_003Ec__DisplayClass2_0 _003C_003E8__1;

		private int _003Ci_003E5__2;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_008b: Expected I4, but got I8
			//IL_03a0: Expected I4, but got O
			//IL_01de: Expected O, but got I4
			//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c8: Expected O, but got Unknown
			//IL_0209: Expected O, but got I4
			//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f3: Expected O, but got Unknown
			//IL_040c: Expected O, but got Ref
			//IL_024c: Expected O, but got Ref
			//IL_024c: Expected O, but got Ref
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				_003C_003Ec__DisplayClass2_0 obj = new _003C_003Ec__DisplayClass2_0();
				_003C_003E8__1 = obj;
				_003C_003Ec__DisplayClass2_0 obj2 = _003C_003E8__1;
				if (_003C_003E8__1 != null)
				{
					obj2.state = state;
					_003Ci_003E5__2 = 0;
					goto IL_0369;
				}
			}
			else
			{
				if (_003C_003E1__state != 1)
				{
					goto IL_0310;
				}
				_003C_003Ec__DisplayClass2_0 obj3 = _003C_003E8__1;
				_003C_003E1__state = -1;
				if (_003C_003E8__1 != null)
				{
					MigratorLoadingState migratorLoadingState = obj3.state;
					if (obj3.state != null)
					{
						if (migratorLoadingState.loadedOldSave)
						{
							goto IL_0310;
						}
						int num = _003Ci_003E5__2 + 1;
						_003Ci_003E5__2 = num;
						goto IL_0369;
					}
				}
			}
			goto IL_0392;
			IL_0392:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_0369:
			List<string> list = directoriesToTry;
			string filePath;
			if (directoriesToTry != null)
			{
				if (_003Ci_003E5__2 >= list._size)
				{
					goto IL_0310;
				}
				List<string> list2 = directoriesToTry;
				int num2 = _003Ci_003E5__2;
				if (_003Ci_003E5__2 < list2._size)
				{
					string[] items = list2._items;
					if (list2._items != null)
					{
						object obj5;
						if (items[num2] != null)
						{
							object obj4 = items[num2] + 20;
							obj5 = obj4;
						}
						else
						{
							obj5 = 0;
						}
						object obj7;
						if (filename != null)
						{
							object obj6 = filename + 20;
							obj7 = obj6;
						}
						else
						{
							obj7 = 0;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
						object obj8 = default(object);
						if (obj5 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
							if (obj7 != null)
							{
								object obj9 = default(object);
								filePath = Path.JoinInternal((ReadOnlySpan<char>)(&obj8), (ReadOnlySpan<char>)(&obj9));
								goto IL_026f;
							}
							obj8 = obj5;
						}
						else
						{
							obj8 = obj7;
						}
						filePath = ((string)null).CreateString((ReadOnlySpan<char>)(&obj8));
						goto IL_026f;
					}
				}
				else
				{
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				}
			}
			goto IL_0392;
			IL_026f:
			_003C_003Ec__DisplayClass2_0 obj10 = _003C_003E8__1;
			if (_003C_003E8__1 != null)
			{
				Action<StorageResult> onComplete = obj10._003C_003E9__0;
				if (obj10._003C_003E9__0 == null)
				{
					Action<StorageResult> action = delegate(StorageResult result)
					{
						switch (result)
						{
						case StorageResult.NothingToCommit:
						{
							MigratorLoadingState migratorLoadingState3 = _003C_003E8__1.state;
							migratorLoadingState3.showedDialog = true;
							break;
						}
						case StorageResult.Successful:
						{
							MigratorLoadingState migratorLoadingState2 = _003C_003E8__1.state;
							migratorLoadingState2.loadedOldSave = true;
							break;
						}
						}
					};
					onComplete = action;
				}
				IEnumerator enumerator = TryLoadFromPath(filePath, currentData, playerOptions, onComplete);
				_003C_003E2__current = enumerator;
				_003C_003E1__state = 1;
				return true;
			}
			goto IL_0392;
			IL_0310:
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	public static IEnumerator AttemptMigration(PlayerOptions playerOptions)
	{
		_003CAttemptMigration_003Ed__1 obj = null;
		obj._003C_003E1__state = 0;
		obj.playerOptions = playerOptions;
		return obj;
	}

	private static IEnumerator TryLoadingFromLocations(List<string> directoriesToTry, byte[] currentData, PlayerOptions playerOptions, MigratorLoadingState state, string filename = "SaveData.sav")
	{
		_003CTryLoadingFromLocations_003Ed__2 obj = null;
		obj._003C_003E1__state = 0;
		obj.directoriesToTry = directoriesToTry;
		obj.currentData = currentData;
		obj.playerOptions = playerOptions;
		obj.state = state;
		string filename2 = default(string);
		obj.filename = filename2;
		return obj;
	}

	private static byte[] SerializeCurrentData(PlayerOptionsData currentData)
	{
		//IL_0045: Expected I, but got O
		//IL_0055: Expected O, but got I
		//IL_0065: Expected O, but got I
		string rawData = SaveSerializer.Serialize(currentData);
		string text = SaveUtils.UpdateChecksum(rawData);
		Encoding uTF = Encoding.UTF8;
		if (uTF != null)
		{
			nint num = (nint)uTF;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ r8_v1 (Il2CppClass<System.Text.Encoding>)+268]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ r8_v1 (Il2CppClass<System.Text.Encoding>)+270]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v67 @ r9_v1 (should have been resolved before IL gen)");
		}
		return (byte[])(object)new NullReferenceException();
	}

	private static IEnumerator TryLoadFromPath(string filePath, byte[] currentData, PlayerOptions playerOptions, Action<StorageResult> onComplete)
	{
		_003CTryLoadFromPath_003Ed__4 obj = null;
		obj._003C_003E1__state = 0;
		obj.filePath = filePath;
		obj.currentData = currentData;
		obj.playerOptions = playerOptions;
		obj.onComplete = onComplete;
		return obj;
	}

	private static IEnumerator TryLoadFromBytes(byte[] data, byte[] currentData, PlayerOptions playerOptions, Action<StorageResult> onComplete)
	{
		_003CTryLoadFromBytes_003Ed__5 obj = null;
		obj._003C_003E1__state = 0;
		obj.data = data;
		obj.currentData = currentData;
		obj.playerOptions = playerOptions;
		obj.onComplete = onComplete;
		return obj;
	}

	private static bool DoDirectLoad(byte[] data, PlayerOptions playerOptions)
	{
		//IL_0012: Expected I4, but got O
		//IL_008b: Expected I4, but got O
		//IL_0063: Expected O, but got I4
		bool flag = (byte)(int)SaveUtils.TryParseData(data) != 0;
		if (flag)
		{
			if (playerOptions != null)
			{
				bool onlineClientWithRunData = default(bool);
				playerOptions.ApplyConfig((PlayerOptionsData)flag, adventureMode: false, hostConfig: false, onlineClientWithRunData);
				Debug.Log("apply config done!");
				return true;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		return flag;
	}

	private static string GetPlatformSpecificParentPath()
	{
		//IL_00ef: Expected O, but got I4
		//IL_0115: Expected O, but got I4
		//IL_013b: Expected O, but got I4
		object obj = Application.platform;
		string result;
		if ((nint)obj != 2)
		{
			object obj2 = Application.platform;
			if ((nint)obj2 != 7)
			{
				object obj3 = Application.platform;
				if ((nint)obj3 != 1 && Application.platform != RuntimePlatform.OSXEditor)
				{
					RuntimePlatform platform = Application.platform;
					if (platform != RuntimePlatform.LinuxPlayer)
					{
						RuntimePlatform platform2 = Application.platform;
						bool flag = platform2 != RuntimePlatform.LinuxEditor;
						result = null;
						if (flag)
						{
							goto IL_0158;
						}
					}
					return "~/.config/";
				}
				return "~/Library/Application Support/";
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184E7E2C0");
		string text2 = default(string);
		string text = text2 + "\\";
		result = text;
		goto IL_0158;
		IL_0158:
		return result;
	}
}
