using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Platforms;
using VampireSurvivors.Framework.Platforms.Saves;
using VampireSurvivors.Objects;

namespace VampireSurvivors.Framework.Saves;

public static class SaveSystem
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static StorageOperationComplete _003C_003E9__3_0;

		public static Func<SaveSummary, DateTime> _003C_003E9__9_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal unsafe void _003CSave_003Eb__3_0(StorageResult r)
		{
			//IL_0018: Expected O, but got Ref
			object obj = default(object);
			string text = ((Enum)(&obj)).ToString();
			string message = "Save complete, " + text;
			Debug.Log(message);
		}

		internal DateTime _003CHandleConflictResolution_003Eb__9_0(SaveSummary summary)
		{
			return (DateTime)(((object?)summary?._003CRawDateTime_003Ek__BackingField) ?? ((object)new NullReferenceException()));
		}
	}

	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public PlayerOptions playerOptions;

		public Action<StorageResult> onComplete;

		public Action<StorageResult, PlayerOptionsData> _003C_003E9__1;

		internal unsafe void _003CLoadAsync_003Eb__0(StorageResult r, byte[] data)
		{
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_005d: Expected O, but got Unknown
			//IL_0074: Unknown result type (might be due to invalid IL or missing references)
			//IL_0079: Expected O, but got Unknown
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Expected O, but got Unknown
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a7: Expected O, but got Unknown
			//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b5: Expected O, but got Unknown
			//IL_03f7: Expected O, but got I4
			//IL_0407: Unknown result type (might be due to invalid IL or missing references)
			//IL_040c: Expected O, but got Unknown
			_003C_003Ec__DisplayClass4_1 CS_0024_003C_003E8__locals12 = new _003C_003Ec__DisplayClass4_1();
			Action<StorageResult, PlayerOptionsData> onLoadComplete = _003C_003E9__1;
			if (_003C_003E9__1 == null)
			{
				Action<StorageResult, PlayerOptionsData> action = (_003C_003E9__1 = delegate(StorageResult storageResult, PlayerOptionsData conf)
				{
					bool onlineClientWithRunData = default(bool);
					playerOptions.ApplyConfig(conf, adventureMode: false, hostConfig: false, onlineClientWithRunData);
					Debug.Log("apply config done!");
					Action<StorageResult> action2 = onComplete;
					if (onComplete != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v114 @ rax_v6 (System.Action`1<VampireSurvivors.Framework.Platforms.Saves.StorageResult>)+18] (should have been resolved before IL gen)");
					}
				});
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				bool flag = (nint)0 == 0;
				onLoadComplete = action;
				if (!flag)
				{
					object obj = this + 32;
					object obj2 = obj >> 12;
					object obj3 = obj2 & 0x1FFFFF;
					object obj4 = obj3 >> 6;
					object obj5 = obj4 * 8;
					object obj6 = 6603577472L + obj5;
					object obj7 = obj3 & 0x3F;
					nint num2;
					do
					{
						object obj8 = 1 << (int)obj7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rdx_v22+462E0]");
						object obj9 = 0 | obj8;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rdx_v22+462E0]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rdx_v22+462E0]");
						if (num == 0)
						{
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rdx_v22+462E0]");
						num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rdx_v22+462E0]");
					}
					while (num2 != 0);
					onLoadComplete = action;
				}
			}
			CS_0024_003C_003E8__locals12.onLoadComplete = onLoadComplete;
			switch (r)
			{
			default:
			{
				Action<StorageResult, PlayerOptionsData> onLoadComplete3 = CS_0024_003C_003E8__locals12.onLoadComplete;
				if (CS_0024_003C_003E8__locals12.onLoadComplete != null)
				{
					PlayerOptionsData playerOptionsData2 = new PlayerOptionsData();
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v450 @ rdi_v4 (System.Action`2<VampireSurvivors.Framework.Platforms.Saves.StorageResult, VampireSurvivors.Data.PlayerOptionsData>)+18] (should have been resolved before IL gen)");
				}
				break;
			}
			case StorageResult.NotFound:
			{
				Debug.Log("No save file found. Creating new default save.");
				PlayerOptionsData newPlayerOptionsData = new PlayerOptionsData();
				CS_0024_003C_003E8__locals12.newPlayerOptionsData = newPlayerOptionsData;
				byte[] serializedPlayerData = SaveUtils.GetSerializedPlayerData(CS_0024_003C_003E8__locals12.newPlayerOptionsData);
				IPlatformSaveUtils saveUtil = SaveUtil;
				if (saveUtil != null)
				{
					string saveFileName = SaveUtils.GetSaveFileName();
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99950");
				}
				IPlatformSaveUtils saveUtil2 = SaveUtil;
				if (saveUtil2 == null)
				{
					break;
				}
				StorageOperationComplete storageOperationComplete = delegate(StorageResult saveResult)
				{
					//IL_002b: Expected I4, but got O
					//IL_0050: Expected O, but got Ref
					//IL_0105: Expected O, but got I
					//IL_0115: Expected O, but got I
					//IL_0125: Expected O, but got I
					object obj13 = default(object);
					object obj14 = default(object);
					while (true)
					{
						if (saveResult != StorageResult.Successful)
						{
							if (saveResult == StorageResult.NoFreeSpace)
							{
								Debug.LogWarning("No free space available, we need to handle this via an in-game dialog to let users try again or continue without saving");
								Action<StorageResult, PlayerOptionsData> onLoadComplete4 = CS_0024_003C_003E8__locals12.onLoadComplete;
								if (CS_0024_003C_003E8__locals12.onLoadComplete == null)
								{
									break;
								}
								PlayerOptionsData playerOptionsData3 = new PlayerOptionsData();
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rdi_v4 (System.Action`2<VampireSurvivors.Framework.Platforms.Saves.StorageResult, VampireSurvivors.Data.PlayerOptionsData>)+28]");
								object obj10 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rdi_v4 (System.Action`2<VampireSurvivors.Framework.Platforms.Saves.StorageResult, VampireSurvivors.Data.PlayerOptionsData>)+40]");
								object obj11 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rdi_v4 (System.Action`2<VampireSurvivors.Framework.Platforms.Saves.StorageResult, VampireSurvivors.Data.PlayerOptionsData>)+18]");
								object obj12 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v210 @ rax_v10 (should have been resolved before IL gen)");
								continue;
							}
							object arg = (StorageResult)obj13;
							System.ParamsArray paramsArray = new System.ParamsArray(arg);
							string message = string.FormatHelper((IFormatProvider)null, "[SaveSystem] New save data persist result: {0}", (System.ParamsArray)(&obj14));
							Debug.LogWarning(message);
							Debug.LogWarning("[SaveSystem] Returning StorageResult.Successful to continue with game loading and prevent game hanging");
						}
						Action<StorageResult, PlayerOptionsData> onLoadComplete5 = CS_0024_003C_003E8__locals12.onLoadComplete;
						if (CS_0024_003C_003E8__locals12.onLoadComplete != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v111 @ rax_v4 (System.Action`2<VampireSurvivors.Framework.Platforms.Saves.StorageResult, VampireSurvivors.Data.PlayerOptionsData>)+18] (should have been resolved before IL gen)");
						}
						break;
					}
				};
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A998B0");
				break;
			}
			case StorageResult.Successful:
			{
				Encoding uTF = Encoding.UTF8;
				string text = uTF.GetString(data);
				SaveParser saveParser = new SaveParser();
				PlayerOptionsData playerOptionsData = saveParser.ParsePod(text);
				if (text != null && playerOptionsData != null && SaveUtils.ChecksumIsValid(text, playerOptionsData._003Cchecksum_003Ek__BackingField))
				{
					Action<StorageResult, PlayerOptionsData> onLoadComplete2 = CS_0024_003C_003E8__locals12.onLoadComplete;
					if (CS_0024_003C_003E8__locals12.onLoadComplete != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v565 @ rax_v24 (System.Action`2<VampireSurvivors.Framework.Platforms.Saves.StorageResult, VampireSurvivors.Data.PlayerOptionsData>)+18] (should have been resolved before IL gen)");
					}
					break;
				}
				goto case StorageResult.DataCorrupted;
			}
			case StorageResult.DataCorrupted:
				TryRestoreDataAsync(CS_0024_003C_003E8__locals12.onLoadComplete);
				break;
			}
		}

		internal void _003CLoadAsync_003Eb__1(StorageResult r, PlayerOptionsData conf)
		{
			bool onlineClientWithRunData = default(bool);
			playerOptions.ApplyConfig(conf, adventureMode: false, hostConfig: false, onlineClientWithRunData);
			Debug.Log("apply config done!");
			Action<StorageResult> action = onComplete;
			if (onComplete != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v114 @ rax_v6 (System.Action`1<VampireSurvivors.Framework.Platforms.Saves.StorageResult>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass4_1
	{
		public Action<StorageResult, PlayerOptionsData> onLoadComplete;

		public PlayerOptionsData newPlayerOptionsData;

		internal unsafe void _003CLoadAsync_003Eb__2(StorageResult saveResult)
		{
			//IL_002b: Expected I4, but got O
			//IL_0050: Expected O, but got Ref
			//IL_0105: Expected O, but got I
			//IL_0115: Expected O, but got I
			//IL_0125: Expected O, but got I
			object obj4 = default(object);
			object obj5 = default(object);
			while (true)
			{
				if (saveResult != StorageResult.Successful)
				{
					if (saveResult == StorageResult.NoFreeSpace)
					{
						Debug.LogWarning("No free space available, we need to handle this via an in-game dialog to let users try again or continue without saving");
						Action<StorageResult, PlayerOptionsData> action = onLoadComplete;
						if (onLoadComplete != null)
						{
							PlayerOptionsData playerOptionsData = new PlayerOptionsData();
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rdi_v4 (System.Action`2<VampireSurvivors.Framework.Platforms.Saves.StorageResult, VampireSurvivors.Data.PlayerOptionsData>)+28]");
							object obj = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rdi_v4 (System.Action`2<VampireSurvivors.Framework.Platforms.Saves.StorageResult, VampireSurvivors.Data.PlayerOptionsData>)+40]");
							object obj2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rdi_v4 (System.Action`2<VampireSurvivors.Framework.Platforms.Saves.StorageResult, VampireSurvivors.Data.PlayerOptionsData>)+18]");
							object obj3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v210 @ rax_v10 (should have been resolved before IL gen)");
							continue;
						}
						break;
					}
					object arg = (StorageResult)obj4;
					System.ParamsArray paramsArray = new System.ParamsArray(arg);
					string message = string.FormatHelper((IFormatProvider)null, "[SaveSystem] New save data persist result: {0}", (System.ParamsArray)(&obj5));
					Debug.LogWarning(message);
					Debug.LogWarning("[SaveSystem] Returning StorageResult.Successful to continue with game loading and prevent game hanging");
				}
				Action<StorageResult, PlayerOptionsData> action2 = onLoadComplete;
				if (onLoadComplete != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v111 @ rax_v4 (System.Action`2<VampireSurvivors.Framework.Platforms.Saves.StorageResult, VampireSurvivors.Data.PlayerOptionsData>)+18] (should have been resolved before IL gen)");
				}
				break;
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public Action<StorageResult, PlayerOptionsData> onComplete;

		internal void _003CTryRestoreDataAsync_003Eb__0(StorageResult br, byte[] bdata)
		{
			if (br == StorageResult.Successful)
			{
				Encoding uTF = Encoding.UTF8;
				string text = uTF.GetString(bdata);
				SaveParser saveParser = new SaveParser();
				PlayerOptionsData playerOptionsData = saveParser.ParsePod(text);
				if (text != null && playerOptionsData != null && SaveUtils.ChecksumIsValid(text, playerOptionsData._003Cchecksum_003Ek__BackingField))
				{
					Debug.LogWarning("Save Data was successfully restored from backup!");
					IPlatformSaveUtils saveUtil = SaveUtil;
					string saveFileName = SaveUtils.GetSaveFileName();
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99950");
					Action<StorageResult, PlayerOptionsData> action = onComplete;
					if (onComplete != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v269 @ rax_v31 (System.Action`2<VampireSurvivors.Framework.Platforms.Saves.StorageResult, VampireSurvivors.Data.PlayerOptionsData>)+18] (should have been resolved before IL gen)");
					}
					return;
				}
			}
			Debug.LogError("SaveData is corrupt");
			Action<StorageResult, PlayerOptionsData> action2 = onComplete;
			if (onComplete != null)
			{
				PlayerOptionsData playerOptionsData2 = new PlayerOptionsData();
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v182 @ rdi_v4 (System.Action`2<VampireSurvivors.Framework.Platforms.Saves.StorageResult, VampireSurvivors.Data.PlayerOptionsData>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public PlayerOptions playerOptions;

		public Action<bool> onComplete;

		internal void _003CTryRestoreBackup_003Eb__0(StorageResult br, byte[] bdata)
		{
			//IL_015a: Expected O, but got I4
			//IL_0123: Expected O, but got I4
			Action<bool> action;
			if (br == StorageResult.Successful)
			{
				Encoding uTF = Encoding.UTF8;
				string text = uTF.GetString(bdata);
				SaveParser saveParser = new SaveParser();
				PlayerOptionsData playerOptionsData = saveParser.ParsePod(text);
				if (text != null && playerOptionsData != null && SaveUtils.ChecksumIsValid(text, playerOptionsData._003Cchecksum_003Ek__BackingField))
				{
					Debug.LogWarning("Save Data was successfully restored from backup!");
					IPlatformSaveUtils saveUtil = SaveUtil;
					string saveFileName = SaveUtils.GetSaveFileName();
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99950");
					bool onlineClientWithRunData = default(bool);
					playerOptions.ApplyConfig(playerOptionsData, adventureMode: false, hostConfig: false, onlineClientWithRunData);
					action = onComplete;
					if (onComplete != null)
					{
						object obj = 1;
						goto IL_01ab;
					}
					return;
				}
			}
			action = onComplete;
			if (onComplete != null)
			{
				object obj = 0;
				goto IL_01ab;
			}
			return;
			IL_01ab:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v254 @ rax_v2 (System.Action`1<System.Boolean>)+18] (should have been resolved before IL gen)");
		}
	}

	private sealed class _003C_003Ec__DisplayClass9_0
	{
		public Action<byte[]> onComplete;

		public List<SaveSummary> summaries;

		internal void _003CHandleConflictResolution_003Eb__1(int i)
		{
			Action<byte[]> action = onComplete;
			if (onComplete != null)
			{
				List<SaveSummary> list = summaries;
				if (i < list._size)
				{
					SaveSummary[] items = list._items;
					SaveSummary saveSummary = items[i];
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v33 @ r9_v1 (System.Action`1<System.Byte[]>)+18] (should have been resolved before IL gen)");
				}
				else
				{
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				}
			}
		}
	}

	private static IPlatformSaveUtils SaveUtil
	{
		get
		{
			//IL_003c: Expected I, but got O
			SystemPlatform sInstance = SystemPlatform.sInstance;
			if (SystemPlatform.sInstance != null)
			{
				IBaseAccount currentSystem = sInstance.m_CurrentSystem;
				if (sInstance.m_CurrentSystem != null)
				{
					nint num = (nint)currentSystem;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: [v63 @ rdx_v1 (Il2CppClass<VampireSurvivors.Framework.Platforms.IBaseAccount>)+1B8] (should have been resolved before IL gen)");
				}
			}
			return (IPlatformSaveUtils)new NullReferenceException();
		}
	}

	static SaveSystem()
	{
		//IL_0013: Expected O, but got I4
		//IL_001c: Expected O, but got I4
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		string[] properties = DefaultSaveData.properties;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj2 < properties.Length)
		{
			MethodInfo parser = SaveUtils.GetParser(properties[obj]);
			obj++;
			obj2 = obj;
		}
	}

	public unsafe static void Save(PlayerOptionsData data, bool commitImmediately = true, bool createBackup = false, CommitOptions options = CommitOptions.Default)
	{
		//IL_0074: Expected I, but got O
		//IL_00d1: Expected I, but got O
		//IL_00e1: Expected O, but got I
		//IL_00fc: Expected I, but got O
		//IL_01b1: Expected I, but got O
		SystemPlatform sInstance = SystemPlatform.sInstance;
		IPlatformSaveUtils storage = sInstance.m_CurrentSystem.Storage;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj != null)
		{
			byte[] serializedPlayerData = SaveUtils.GetSerializedPlayerData(data);
			SystemPlatform sInstance2 = SystemPlatform.sInstance;
			IBaseAccount currentSystem = sInstance2.m_CurrentSystem;
			nint num = (nint)currentSystem;
			IPlatformSaveUtils storage2 = currentSystem.Storage;
			string saveFileName = SaveUtils.GetSaveFileName();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99950");
			if (!commitImmediately)
			{
				return;
			}
			SystemPlatform sInstance3 = SystemPlatform.sInstance;
			IBaseAccount currentSystem2 = sInstance3.m_CurrentSystem;
			nint num2 = (nint)currentSystem2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v375 @ rdx_v11 (Il2CppClass<VampireSurvivors.Framework.Platforms.IBaseAccount>)+1C0]");
			object obj2 = 0;
			IPlatformSaveUtils storage3 = currentSystem2.Storage;
			nint num3 = (nint)typeof(_003C_003Ec);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v392 @ rax_v25 (Il2CppClass<VampireSurvivors.Framework.Saves.SaveSystem+<>c>)+B8]");
			nint num4 = 0;
			StorageOperationComplete storageOperationComplete = _003C_003Ec._003C_003E9__3_0;
			if (_003C_003Ec._003C_003E9__3_0 == null)
			{
				StorageOperationComplete storageOperationComplete2 = (_003C_003Ec._003C_003E9__3_0 = delegate
				{
					//IL_0018: Expected O, but got Ref
					object obj3 = default(object);
					string text = ((Enum)(&obj3)).ToString();
					string message = "Save complete, " + text;
					Debug.Log(message);
				});
				nint num5 = (nint)typeof(_003C_003Ec);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v446 @ rax_v33 (Il2CppClass<VampireSurvivors.Framework.Saves.SaveSystem+<>c>)+B8]");
				num4 = (nint)0 + (nint)8;
				storageOperationComplete = storageOperationComplete2;
				obj2 = _003C_003Ec._003C_003E9;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A998B0");
		}
		else
		{
			Debug.LogError("System storage is not ready to use, progress will not be saved!");
		}
	}

	public unsafe static void LoadAsync(PlayerOptions playerOptions, Action<StorageResult> onComplete)
	{
		_003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals20 = new _003C_003Ec__DisplayClass4_0();
		CS_0024_003C_003E8__locals20.playerOptions = playerOptions;
		CS_0024_003C_003E8__locals20.onComplete = onComplete;
		IPlatformSaveUtils saveUtil = SaveUtil;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null)
		{
			Debug.LogError("System storage is not ready to use!");
			Action<StorageResult> onComplete2 = CS_0024_003C_003E8__locals20.onComplete;
			if (CS_0024_003C_003E8__locals20.onComplete != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v331 @ rax_v24 (System.Action`1<VampireSurvivors.Framework.Platforms.Saves.StorageResult>)+18] (should have been resolved before IL gen)");
			}
		}
		IPlatformSaveUtils saveUtil2 = SaveUtil;
		if (saveUtil2 == null)
		{
			return;
		}
		string saveFileName = SaveUtils.GetSaveFileName();
		StorageOperationCompleteWithData storageOperationCompleteWithData = delegate(StorageResult r, byte[] data)
		{
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_005d: Expected O, but got Unknown
			//IL_0074: Unknown result type (might be due to invalid IL or missing references)
			//IL_0079: Expected O, but got Unknown
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Expected O, but got Unknown
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a7: Expected O, but got Unknown
			//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b5: Expected O, but got Unknown
			//IL_03f7: Expected O, but got I4
			//IL_0407: Unknown result type (might be due to invalid IL or missing references)
			//IL_040c: Expected O, but got Unknown
			_003C_003Ec__DisplayClass4_1 CS_0024_003C_003E8__locals24 = new _003C_003Ec__DisplayClass4_1();
			Action<StorageResult, PlayerOptionsData> onLoadComplete = CS_0024_003C_003E8__locals20._003C_003E9__1;
			if (CS_0024_003C_003E8__locals20._003C_003E9__1 == null)
			{
				Action<StorageResult, PlayerOptionsData> action = (CS_0024_003C_003E8__locals20._003C_003E9__1 = delegate(StorageResult storageResult, PlayerOptionsData conf)
				{
					bool onlineClientWithRunData = default(bool);
					CS_0024_003C_003E8__locals20.playerOptions.ApplyConfig(conf, adventureMode: false, hostConfig: false, onlineClientWithRunData);
					Debug.Log("apply config done!");
					Action<StorageResult> onComplete3 = CS_0024_003C_003E8__locals20.onComplete;
					if (CS_0024_003C_003E8__locals20.onComplete != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v114 @ rax_v6 (System.Action`1<VampireSurvivors.Framework.Platforms.Saves.StorageResult>)+18] (should have been resolved before IL gen)");
					}
				});
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				bool flag = (nint)0 == 0;
				onLoadComplete = action;
				if (!flag)
				{
					object obj2 = CS_0024_003C_003E8__locals20 + 32;
					object obj3 = obj2 >> 12;
					object obj4 = obj3 & 0x1FFFFF;
					object obj5 = obj4 >> 6;
					object obj6 = obj5 * 8;
					object obj7 = 6603577472L + obj6;
					object obj8 = obj4 & 0x3F;
					nint num2;
					do
					{
						object obj9 = 1 << (int)obj8;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rdx_v22+462E0]");
						object obj10 = 0 | obj9;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rdx_v22+462E0]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rdx_v22+462E0]");
						if (num == 0)
						{
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rdx_v22+462E0]");
						num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rdx_v22+462E0]");
					}
					while (num2 != 0);
					onLoadComplete = action;
				}
			}
			CS_0024_003C_003E8__locals24.onLoadComplete = onLoadComplete;
			switch (r)
			{
			default:
			{
				Action<StorageResult, PlayerOptionsData> onLoadComplete3 = CS_0024_003C_003E8__locals24.onLoadComplete;
				if (CS_0024_003C_003E8__locals24.onLoadComplete != null)
				{
					PlayerOptionsData playerOptionsData2 = new PlayerOptionsData();
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v450 @ rdi_v4 (System.Action`2<VampireSurvivors.Framework.Platforms.Saves.StorageResult, VampireSurvivors.Data.PlayerOptionsData>)+18] (should have been resolved before IL gen)");
				}
				break;
			}
			case StorageResult.NotFound:
			{
				Debug.Log("No save file found. Creating new default save.");
				PlayerOptionsData newPlayerOptionsData = new PlayerOptionsData();
				CS_0024_003C_003E8__locals24.newPlayerOptionsData = newPlayerOptionsData;
				byte[] serializedPlayerData = SaveUtils.GetSerializedPlayerData(CS_0024_003C_003E8__locals24.newPlayerOptionsData);
				IPlatformSaveUtils saveUtil3 = SaveUtil;
				if (saveUtil3 != null)
				{
					string saveFileName2 = SaveUtils.GetSaveFileName();
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99950");
				}
				IPlatformSaveUtils saveUtil4 = SaveUtil;
				if (saveUtil4 != null)
				{
					StorageOperationComplete storageOperationComplete = delegate(StorageResult saveResult)
					{
						//IL_002b: Expected I4, but got O
						//IL_0050: Expected O, but got Ref
						//IL_0105: Expected O, but got I
						//IL_0115: Expected O, but got I
						//IL_0125: Expected O, but got I
						object obj14 = default(object);
						object obj15 = default(object);
						while (true)
						{
							if (saveResult != StorageResult.Successful)
							{
								if (saveResult == StorageResult.NoFreeSpace)
								{
									Debug.LogWarning("No free space available, we need to handle this via an in-game dialog to let users try again or continue without saving");
									Action<StorageResult, PlayerOptionsData> onLoadComplete4 = CS_0024_003C_003E8__locals24.onLoadComplete;
									if (CS_0024_003C_003E8__locals24.onLoadComplete == null)
									{
										break;
									}
									PlayerOptionsData playerOptionsData3 = new PlayerOptionsData();
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rdi_v4 (System.Action`2<VampireSurvivors.Framework.Platforms.Saves.StorageResult, VampireSurvivors.Data.PlayerOptionsData>)+28]");
									object obj11 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rdi_v4 (System.Action`2<VampireSurvivors.Framework.Platforms.Saves.StorageResult, VampireSurvivors.Data.PlayerOptionsData>)+40]");
									object obj12 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rdi_v4 (System.Action`2<VampireSurvivors.Framework.Platforms.Saves.StorageResult, VampireSurvivors.Data.PlayerOptionsData>)+18]");
									object obj13 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v210 @ rax_v10 (should have been resolved before IL gen)");
									continue;
								}
								object arg = (StorageResult)obj14;
								System.ParamsArray paramsArray = new System.ParamsArray(arg);
								string message = string.FormatHelper((IFormatProvider)null, "[SaveSystem] New save data persist result: {0}", (System.ParamsArray)(&obj15));
								Debug.LogWarning(message);
								Debug.LogWarning("[SaveSystem] Returning StorageResult.Successful to continue with game loading and prevent game hanging");
							}
							Action<StorageResult, PlayerOptionsData> onLoadComplete5 = CS_0024_003C_003E8__locals24.onLoadComplete;
							if (CS_0024_003C_003E8__locals24.onLoadComplete != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v111 @ rax_v4 (System.Action`2<VampireSurvivors.Framework.Platforms.Saves.StorageResult, VampireSurvivors.Data.PlayerOptionsData>)+18] (should have been resolved before IL gen)");
							}
							break;
						}
					};
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A998B0");
				}
				break;
			}
			case StorageResult.Successful:
			{
				Encoding uTF = Encoding.UTF8;
				string text = uTF.GetString(data);
				SaveParser saveParser = new SaveParser();
				PlayerOptionsData playerOptionsData = saveParser.ParsePod(text);
				if (text != null && playerOptionsData != null && SaveUtils.ChecksumIsValid(text, playerOptionsData._003Cchecksum_003Ek__BackingField))
				{
					Action<StorageResult, PlayerOptionsData> onLoadComplete2 = CS_0024_003C_003E8__locals24.onLoadComplete;
					if (CS_0024_003C_003E8__locals24.onLoadComplete != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v565 @ rax_v24 (System.Action`2<VampireSurvivors.Framework.Platforms.Saves.StorageResult, VampireSurvivors.Data.PlayerOptionsData>)+18] (should have been resolved before IL gen)");
					}
					break;
				}
				goto case StorageResult.DataCorrupted;
			}
			case StorageResult.DataCorrupted:
				TryRestoreDataAsync(CS_0024_003C_003E8__locals24.onLoadComplete);
				break;
			}
		};
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99810");
	}

	private static void TryRestoreDataAsync(Action<StorageResult, PlayerOptionsData> onComplete)
	{
		//IL_00b6: Expected O, but got I
		//IL_00c6: Expected O, but got I
		//IL_00d6: Expected O, but got I
		_003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals7 = new _003C_003Ec__DisplayClass5_0();
		CS_0024_003C_003E8__locals7.onComplete = onComplete;
		IPlatformSaveUtils saveUtil = SaveUtil;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj == null)
		{
			Debug.LogError("SaveData is corrupt");
			Action<StorageResult, PlayerOptionsData> onComplete2 = CS_0024_003C_003E8__locals7.onComplete;
			if (CS_0024_003C_003E8__locals7.onComplete == null)
			{
				return;
			}
			PlayerOptionsData playerOptionsData = new PlayerOptionsData();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v272 @ rdi_v5 (System.Action`2<VampireSurvivors.Framework.Platforms.Saves.StorageResult, VampireSurvivors.Data.PlayerOptionsData>)+28]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v272 @ rdi_v5 (System.Action`2<VampireSurvivors.Framework.Platforms.Saves.StorageResult, VampireSurvivors.Data.PlayerOptionsData>)+40]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v272 @ rdi_v5 (System.Action`2<VampireSurvivors.Framework.Platforms.Saves.StorageResult, VampireSurvivors.Data.PlayerOptionsData>)+18]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v174 @ rax_v24 (should have been resolved before IL gen)");
		}
		IPlatformSaveUtils saveUtil2 = SaveUtil;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj5 = default(object);
		if (obj5 == null)
		{
			return;
		}
		string saveFileName = SaveUtils.GetSaveFileName();
		StorageOperationCompleteWithData storageOperationCompleteWithData = delegate(StorageResult br, byte[] bdata)
		{
			if (br == StorageResult.Successful)
			{
				Encoding uTF = Encoding.UTF8;
				string text = uTF.GetString(bdata);
				SaveParser saveParser = new SaveParser();
				PlayerOptionsData playerOptionsData2 = saveParser.ParsePod(text);
				if (text != null && playerOptionsData2 != null && SaveUtils.ChecksumIsValid(text, playerOptionsData2._003Cchecksum_003Ek__BackingField))
				{
					Debug.LogWarning("Save Data was successfully restored from backup!");
					IPlatformSaveUtils saveUtil3 = SaveUtil;
					string saveFileName2 = SaveUtils.GetSaveFileName();
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99950");
					Action<StorageResult, PlayerOptionsData> onComplete3 = CS_0024_003C_003E8__locals7.onComplete;
					if (CS_0024_003C_003E8__locals7.onComplete != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v269 @ rax_v31 (System.Action`2<VampireSurvivors.Framework.Platforms.Saves.StorageResult, VampireSurvivors.Data.PlayerOptionsData>)+18] (should have been resolved before IL gen)");
					}
					return;
				}
			}
			Debug.LogError("SaveData is corrupt");
			Action<StorageResult, PlayerOptionsData> onComplete4 = CS_0024_003C_003E8__locals7.onComplete;
			if (CS_0024_003C_003E8__locals7.onComplete != null)
			{
				PlayerOptionsData playerOptionsData3 = new PlayerOptionsData();
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v182 @ rdi_v4 (System.Action`2<VampireSurvivors.Framework.Platforms.Saves.StorageResult, VampireSurvivors.Data.PlayerOptionsData>)+18] (should have been resolved before IL gen)");
			}
		};
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99810");
	}

	public static void DeleteSave()
	{
		PlayerOptionsData data = new PlayerOptionsData();
		Save(data);
	}

	public static bool BackupExists()
	{
		//IL_00a4: Expected I4, but got O
		IPlatformSaveUtils saveUtil = SaveUtil;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		bool flag = default(bool);
		if (!flag)
		{
			return flag;
		}
		IPlatformSaveUtils saveUtil2 = SaveUtil;
		string saveFileName = SaveUtils.GetSaveFileName();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18000BDF0");
			bool result = default(bool);
			return result;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public static void TryRestoreBackup(PlayerOptions playerOptions, Action<bool> onComplete)
	{
		_003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals9 = new _003C_003Ec__DisplayClass8_0();
		CS_0024_003C_003E8__locals9.playerOptions = playerOptions;
		CS_0024_003C_003E8__locals9.onComplete = onComplete;
		IPlatformSaveUtils saveUtil = SaveUtil;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj == null)
		{
			Action<bool> onComplete2 = CS_0024_003C_003E8__locals9.onComplete;
			if (CS_0024_003C_003E8__locals9.onComplete != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v315 @ rax_v23 (System.Action`1<System.Boolean>)+18] (should have been resolved before IL gen)");
			}
			return;
		}
		IPlatformSaveUtils saveUtil2 = SaveUtil;
		string saveFileName = SaveUtils.GetSaveFileName();
		StorageOperationCompleteWithData storageOperationCompleteWithData = delegate(StorageResult br, byte[] bdata)
		{
			//IL_015a: Expected O, but got I4
			//IL_0123: Expected O, but got I4
			Action<bool> onComplete3;
			object obj2;
			if (br == StorageResult.Successful)
			{
				Encoding uTF = Encoding.UTF8;
				string text = uTF.GetString(bdata);
				SaveParser saveParser = new SaveParser();
				PlayerOptionsData playerOptionsData = saveParser.ParsePod(text);
				if (text != null && playerOptionsData != null && SaveUtils.ChecksumIsValid(text, playerOptionsData._003Cchecksum_003Ek__BackingField))
				{
					Debug.LogWarning("Save Data was successfully restored from backup!");
					IPlatformSaveUtils saveUtil3 = SaveUtil;
					string saveFileName2 = SaveUtils.GetSaveFileName();
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99950");
					bool onlineClientWithRunData = default(bool);
					CS_0024_003C_003E8__locals9.playerOptions.ApplyConfig(playerOptionsData, adventureMode: false, hostConfig: false, onlineClientWithRunData);
					onComplete3 = CS_0024_003C_003E8__locals9.onComplete;
					if (CS_0024_003C_003E8__locals9.onComplete == null)
					{
						return;
					}
					obj2 = 1;
					goto IL_01ab;
				}
			}
			onComplete3 = CS_0024_003C_003E8__locals9.onComplete;
			if (CS_0024_003C_003E8__locals9.onComplete == null)
			{
				return;
			}
			obj2 = 0;
			goto IL_01ab;
			IL_01ab:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v254 @ rax_v2 (System.Action`1<System.Boolean>)+18] (should have been resolved before IL gen)");
		};
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99810");
	}

	public unsafe static void HandleConflictResolution(byte[] dataA, byte[] dataB, Action<byte[]> onComplete)
	{
		//IL_0325: Expected O, but got I
		//IL_02f6: Expected O, but got I
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Expected Ref, but got Unknown
		//IL_0169: Expected I8, but got I4
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Expected Ref, but got Unknown
		//IL_0196: Expected I, but got O
		//IL_029d: Expected I4, but got O
		//IL_02ca: Expected O, but got I4
		_003C_003Ec__DisplayClass9_0 obj = new _003C_003Ec__DisplayClass9_0();
		obj.onComplete = onComplete;
		PlayerOptionsData playerOptionsData = SaveUtils.TryParseData(dataA);
		PlayerOptionsData playerOptionsData2 = SaveUtils.TryParseData(dataB);
		if (playerOptionsData != null)
		{
			if (playerOptionsData2 != null)
			{
				string text = playerOptionsData._003Cchecksum_003Ek__BackingField;
				string text2 = playerOptionsData2._003Cchecksum_003Ek__BackingField;
				if ((object)playerOptionsData._003Cchecksum_003Ek__BackingField != playerOptionsData2._003Cchecksum_003Ek__BackingField)
				{
					bool flag = playerOptionsData._003Cchecksum_003Ek__BackingField == null;
					IntPtr intPtr = default(IntPtr);
					nint num = intPtr;
					if (!flag)
					{
						bool flag2 = playerOptionsData2._003Cchecksum_003Ek__BackingField == null;
						num = intPtr;
						if (!flag2)
						{
							bool flag3 = text._stringLength != text2._stringLength;
							num = intPtr;
							if (!flag3)
							{
								ref byte second = ref *(byte*)(playerOptionsData2._003Cchecksum_003Ek__BackingField + 20);
								ulong length = (ulong)(text._stringLength + text._stringLength);
								bool flag4 = System.SpanHelpers.SequenceEqual(ref *(byte*)(playerOptionsData._003Cchecksum_003Ek__BackingField + 20), ref second, length);
								num = unchecked((nint)null);
								if (flag4)
								{
									goto IL_02d4;
								}
							}
						}
					}
					List<SaveSummary> summaries = new List<SaveSummary>();
					SaveSummary saveSummary = SaveUtils.GetSaveSummary(playerOptionsData, dataA);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A992A0");
					SaveSummary saveSummary2 = SaveUtils.GetSaveSummary(playerOptionsData2, dataB);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A992A0");
					obj.summaries = summaries;
					Func<object, DateTime> keySelector = (Func<object, DateTime>)_003C_003Ec._003C_003E9__9_0;
					if (_003C_003Ec._003C_003E9__9_0 == null)
					{
						keySelector = (Func<object, DateTime>)(_003C_003Ec._003C_003E9__9_0 = (SaveSummary summary) => (DateTime)(((object?)summary?._003CRawDateTime_003Ek__BackingField) ?? ((object)new NullReferenceException())));
					}
					bool flag5 = default(bool);
					System.Linq.OrderedEnumerable<object, DateTime> orderedEnumerable = new System.Linq.OrderedEnumerable<object, DateTime>((IEnumerable<object>)obj.summaries, keySelector, (IComparer<DateTime>)null, flag5);
					if (orderedEnumerable != null)
					{
						List<object> summaries2 = new List<object>(orderedEnumerable);
						obj.summaries = (List<SaveSummary>)(object)summaries2;
						Action<int> action = null;
						((_003C_003Ec__DisplayClass9_0)(object)action)._003CHandleConflictResolution_003Eb__1((int)obj);
						bool textIsLocalizationTerm = default(bool);
						bool hasCancelButton = default(bool);
						Action onCancel = default(Action);
						PopupManager.CreateSaveFileComparison("Save-Conflict", "lang/save_conflict_title", "lang/save_conflict_description", obj.summaries, (Action<int>)flag5, textIsLocalizationTerm, hasCancelButton, onCancel);
						return;
					}
					Exception ex = System.Linq.Error.ArgumentNull("source");
					throw ex;
				}
			}
			goto IL_02d4;
		}
		Action<byte[]> onComplete2 = obj.onComplete;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v428 @ rax_v13 (System.Action`1<System.Byte[]>)+28]");
		object obj2 = 0;
		byte[] array = dataB;
		goto IL_03af;
		IL_03af:
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v428 @ rax_v13 (System.Action`1<System.Byte[]>)+18] (should have been resolved before IL gen)");
		return;
		IL_02d4:
		onComplete2 = obj.onComplete;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v428 @ rax_v13 (System.Action`1<System.Byte[]>)+28]");
		obj2 = 0;
		array = dataA;
		goto IL_03af;
	}
}
