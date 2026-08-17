using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Profiling;
using Unity.Profiling.LowLevel;
using Unity.Profiling.LowLevel.Unsafe;
using UnityEngine;
using VampireSurvivors.App.Data.Adventures;
using VampireSurvivors.App.Scripts.Data;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Items;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework.DLC;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.App.Scripts.Framework.Adventures;

public class AdventureManager : IInitializable, IDisposable
{
	private sealed class _003C_003Ec__DisplayClass42_0
	{
		public AdventureManager _003C_003E4__this;

		public AdventureType adventureType;

		public PlayerOptionsData adventurePod;

		internal void _003CAscendAdventure_003Eb__0(bool b)
		{
			AdventureManager adventureManager = _003C_003E4__this;
			if (!b)
			{
				Action<bool> action = adventureManager._003COnAdventureAscended_003Ek__BackingField;
				if (adventureManager._003COnAdventureAscended_003Ek__BackingField != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v65 @ r9_v4 (System.Action`1<System.Boolean>)+18] (should have been resolved before IL gen)");
				}
			}
			else
			{
				PlayerOptions playerOptions = adventureManager._playerOptions;
				PlayerOptionsData mainGameConfig = playerOptions._mainGameConfig;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9D2B0");
				AdventureManager adventureManager2 = _003C_003E4__this;
				adventureManager2._playerOptions.Save();
				_003C_003E4__this.ApplyAscension(adventurePod, adventureType);
			}
		}
	}

	public static int MAX_ASCENSION_POINTS;

	private PlayerOptions _playerOptions;

	private DataManager _dataManager;

	private static AdventureManager _adventureManagerInstance;

	private static readonly ProfilerMarker MarkerInitAdventure;

	private static readonly ProfilerMarker MarkerInitDataManager;

	private static bool _003CIsInAdventureMode_003Ek__BackingField;

	private static DlcType? _003CCurrentAdventureDlcType_003Ek__BackingField;

	private static bool _003CShouldExitAdventureModeOnDisconnect_003Ek__BackingField;

	private AdventureData _003CAdventureData_003Ek__BackingField;

	public AdventureType CurrentAdventure;

	private Action<AdventureType> _003COnAdventureStartedEvent_003Ek__BackingField;

	private Action _003COnAdventureExitEvent_003Ek__BackingField;

	private Action<bool> _003COnAdventureAscended_003Ek__BackingField;

	public static bool IsInAdventureMode
	{
		get
		{
			return _003CIsInAdventureMode_003Ek__BackingField;
		}
		set
		{
			_003CIsInAdventureMode_003Ek__BackingField = value;
		}
	}

	public static DlcType? CurrentAdventureDlcType
	{
		get
		{
			return _003CCurrentAdventureDlcType_003Ek__BackingField;
		}
		private set
		{
			_003CCurrentAdventureDlcType_003Ek__BackingField = value;
		}
	}

	public static bool ShouldExitAdventureModeOnDisconnect
	{
		get
		{
			return _003CShouldExitAdventureModeOnDisconnect_003Ek__BackingField;
		}
		set
		{
			_003CShouldExitAdventureModeOnDisconnect_003Ek__BackingField = value;
		}
	}

	public PlayerOptionsData CurrentAdventureSaveData
	{
		get
		{
			//IL_0033: Expected O, but got I4
			PlayerOptionsData playerOptions = (PlayerOptionsData)(object)_playerOptions;
			if (_playerOptions != null)
			{
				return (PlayerOptionsData)playerOptions._003CSelectedMaxWeapons_003Ek__BackingField;
			}
			return (PlayerOptionsData)(object)_playerOptions;
		}
	}

	public AdventureData AdventureData
	{
		get
		{
			return _003CAdventureData_003Ek__BackingField;
		}
		private set
		{
			_003CAdventureData_003Ek__BackingField = value;
		}
	}

	public Action<AdventureType> OnAdventureStartedEvent
	{
		get
		{
			return _003COnAdventureStartedEvent_003Ek__BackingField;
		}
		set
		{
			_003COnAdventureStartedEvent_003Ek__BackingField = value;
		}
	}

	public Action OnAdventureExitEvent
	{
		get
		{
			return _003COnAdventureExitEvent_003Ek__BackingField;
		}
		set
		{
			_003COnAdventureExitEvent_003Ek__BackingField = value;
		}
	}

	public Action<bool> OnAdventureAscended
	{
		get
		{
			return _003COnAdventureAscended_003Ek__BackingField;
		}
		set
		{
			_003COnAdventureAscended_003Ek__BackingField = value;
		}
	}

	public void Initialize()
	{
		_adventureManagerInstance = this;
	}

	public void Dispose()
	{
	}

	public unsafe void InitAdventure(AdventureType adventureType)
	{
		//IL_055c: Expected I, but got O
		//IL_00db: Expected O, but got I
		//IL_01b3: Expected O, but got Ref
		//IL_04d8->IL04d8: Incompatible stack heights: 19 vs 16
		if ((object)MarkerInitAdventure != null)
		{
			ProfilerUnsafeUtility.BeginSample((IntPtr)MarkerInitAdventure);
		}
		PlayerOptions playerOptions = _playerOptions;
		bool flag = _playerOptions == null;
		if (playerOptions._currentAdventureSaveData != null)
		{
			Debug.Log("We are already in an Adventure, exiting this Adventure before initializing a new one...");
			ExitAdventureMode(fireExitEvent: false, resetDataManager: false);
		}
		PlayerOptions playerOptions2 = _playerOptions;
		bool flag2 = _playerOptions == null;
		AdventureManager mainGameConfig = (AdventureManager)(object)playerOptions2._mainGameConfig;
		bool flag3 = playerOptions2._mainGameConfig == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v279 @ rcx_v7 (VampireSurvivors.App.Scripts.Framework.Adventures.AdventureManager)+2E0]");
		bool flag4 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v279 @ rcx_v7 (VampireSurvivors.App.Scripts.Framework.Adventures.AdventureManager)+2E0]");
		int num = ((Dictionary<System.Int32Enum, object>)0).FindEntry((System.Int32Enum)adventureType);
		PlayerOptionsData playerOptionsData2;
		if (flag4)
		{
			PlayerOptionsData playerOptionsData = StartNewAdventure(adventureType);
			playerOptionsData2 = playerOptionsData;
		}
		else
		{
			PlayerOptions playerOptions3 = _playerOptions;
			PlayerOptionsData mainGameConfig2 = playerOptions3._mainGameConfig;
			bool flag5 = mainGameConfig2._003CAdventuresSaveData_003Ek__BackingField == null;
			int num2 = ((Dictionary<System.Int32Enum, object>)(object)mainGameConfig2._003CAdventuresSaveData_003Ek__BackingField).FindEntry((System.Int32Enum)adventureType);
			if (!flag5)
			{
				PlayerOptions playerOptions4 = _playerOptions;
				PlayerOptionsData mainGameConfig3 = playerOptions4._mainGameConfig;
				object obj = ((Dictionary<System.Int32Enum, object>)(object)mainGameConfig3._003CAdventuresSaveData_003Ek__BackingField).get_Item((System.Int32Enum)adventureType);
				playerOptionsData2 = (PlayerOptionsData)obj;
			}
			else
			{
				AdventureType adventureType2 = default(AdventureType);
				object arg = adventureType2;
				System.ParamsArray paramsArray = new System.ParamsArray(arg);
				System.ParamsArray paramsArray2 = default(System.ParamsArray);
				string message = string.FormatHelper((IFormatProvider)null, "Trying to load Adventure of type {0}, but the save data does not contain any data for this...", (System.ParamsArray)(&paramsArray2));
				Debug.LogError(message);
				playerOptionsData2 = null;
			}
			PlayerOptions playerOptions5 = _playerOptions;
			CopyRelicsFromBaseGame(playerOptions5._mainGameConfig, playerOptionsData2);
			PlayerOptions playerOptions6 = _playerOptions;
			CopyArcanasFromBaseGame(playerOptions6._mainGameConfig, playerOptionsData2);
		}
		PlayerOptions playerOptions7 = _playerOptions;
		bool flag6 = _playerOptions == null;
		CopyCoreSettingsFromBaseGame(playerOptions7._mainGameConfig, playerOptionsData2);
		bool flag7 = _playerOptions == null;
		_playerOptions.CurrentAdventureSaveData = playerOptionsData2;
		bool flag8 = _playerOptions == null;
		PlayerOptionsData config = _playerOptions.Config;
		bool flag9 = config == null;
		config._003CSelectedGoldenEggs_003Ek__BackingField = false;
		InitDataManagerForAdventure(adventureType);
		bool flag10 = _playerOptions == null;
		_playerOptions.Save();
		bool flag11 = _playerOptions == null;
		_playerOptions.ApplyLoadedOptions();
		bool flag12 = _playerOptions == null;
		_playerOptions.FixPlayerOptionsData();
		bool flag13 = _playerOptions == null;
		_playerOptions.ApplyUnlocksToData();
		PlayerOptions playerOptions8 = _playerOptions;
		bool flag14 = _playerOptions == null;
		bool flag15 = playerOptions8._playerStats == null;
		playerOptions8._playerStats.InitStats();
		CurrentAdventure = adventureType;
		_003CIsInAdventureMode_003Ek__BackingField = true;
		AdventureData adventureData = _003CAdventureData_003Ek__BackingField;
		bool flag16 = _003CAdventureData_003Ek__BackingField == null;
		CoreAdventureData coreAdventureData = adventureData._003CCoreAdventureData_003Ek__BackingField;
		bool flag17 = adventureData._003CCoreAdventureData_003Ek__BackingField == null;
		if ((object)coreAdventureData._003CRequiresDLC_003Ek__BackingField == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186C84580");
		}
		else
		{
			AdventureData adventureData2 = _003CAdventureData_003Ek__BackingField;
			bool flag18 = _003CAdventureData_003Ek__BackingField == null;
			CoreAdventureData coreAdventureData2 = adventureData2._003CCoreAdventureData_003Ek__BackingField;
			bool flag19 = adventureData2._003CCoreAdventureData_003Ek__BackingField == null;
			bool flag20 = (object)coreAdventureData2._003CRequiresDLC_003Ek__BackingField == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186C84580");
		}
		Action<AdventureType> action = _003COnAdventureStartedEvent_003Ek__BackingField;
		ProfilerMarker.AutoScope autoScope = default(ProfilerMarker.AutoScope);
		if (_003COnAdventureStartedEvent_003Ek__BackingField != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1653 @ rcx_v24 (System.Action`1<VampireSurvivors.Data.AdventureType>)+18] (should have been resolved before IL gen)");
			autoScope.Dispose();
		}
		else
		{
			autoScope.Dispose();
		}
	}

	public unsafe bool HasLoadedAtLeastOneDlcWithAdventures()
	{
		//IL_0030: Expected O, but got I
		//IL_008e: Expected O, but got I
		//IL_00ad: Expected O, but got Ref
		//IL_00fe: Expected O, but got I
		//IL_01fb: Expected O, but got I4
		Dictionary<DlcType, BundleManifestData> loadedDlc = DlcSystem.LoadedDlc;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rax_v3 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.DlcType, VampireSurvivors.Framework.DLC.BundleManifestData>)+20]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ rax_v3 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.DlcType, VampireSurvivors.Framework.DLC.BundleManifestData>)+28]");
		object obj = num - 0;
		if ((nint)obj > 0)
		{
			Dictionary<AdventureType, AdventureData>.Enumerator enumerator = default(Dictionary<AdventureType, AdventureData>.Enumerator);
			object obj2 = default(object);
			while (enumerator.MoveNext())
			{
				if (obj2 == null)
				{
					continue;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v516 @ stack_-20+20]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v516 @ stack_-20+20]");
				bool flag = (nint)0 == 0;
				Dictionary<AdventureType, AdventureData>.Enumerator enumerator2 = (Dictionary<AdventureType, AdventureData>.Enumerator)(&enumerator);
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v446 @ rax_v24+40]");
					if ((nint)0 == 0)
					{
						continue;
					}
					Dictionary<DlcType, BundleManifestData> loadedDlc2 = DlcSystem.LoadedDlc;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v516 @ stack_-20+20]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v516 @ stack_-20+20]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v366 @ rdx_v9+40]");
						if ((nint)0 != 0)
						{
							bool flag2 = loadedDlc2 == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v366 @ rdx_v9+40]");
							System.Int32Enum key = (System.Int32Enum)((nint)0 >> 32);
							int num2 = ((Dictionary<System.Int32Enum, object>)(object)loadedDlc2).FindEntry(key);
							if (!flag2)
							{
								return true;
							}
							continue;
						}
						System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
						enumerator2 = (Dictionary<AdventureType, AdventureData>.Enumerator)0;
					}
				}
				throw new NullReferenceException();
			}
		}
		return false;
	}

	public bool IsOwned(AdventureType type)
	{
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected O, but got Unknown
		//IL_00c6: Expected O, but got I
		//IL_011b: Expected O, but got I
		PlayerOptions playerOptions = _playerOptions;
		PlayerOptionsData mainGameConfig = playerOptions._mainGameConfig;
		List<ItemType> list = mainGameConfig._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rcx_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		bool result;
		if ((nint)0 == 0)
		{
			result = false;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj2 = default(object);
			object obj = obj2 - -1;
			bool flag = obj == null;
			result = !flag;
		}
		DataManager dataManager = _dataManager;
		bool flag2 = ((Dictionary<System.Int32Enum, object>)(object)dataManager._003CAllAdventures_003Ek__BackingField).TryGetValue((System.Int32Enum)type, out object _);
		if (!flag2)
		{
			return flag2;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ stack_8_v4 (System.Object)+20]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rdx_v5+40]");
		if ((nint)0 == 0)
		{
			return result;
		}
		Dictionary<DlcType, BundleManifestData> loadedDlc = DlcSystem.LoadedDlc;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ stack_8_v4 (System.Object)+20]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rdx_v7+40]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rdx_v7+40]");
			System.Int32Enum key = (System.Int32Enum)((nint)0 >> 32);
			int num = ((Dictionary<System.Int32Enum, object>)(object)loadedDlc).FindEntry(key);
			int num2 = num >> 31;
			return (byte)(num2 ^ 1) != 0;
		}
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		bool result2 = default(bool);
		return result2;
	}

	public unsafe bool AscendAdventure(AdventureType adventureType, bool forceShowAscensionConfirmation = false)
	{
		//IL_031f: Expected I4, but got O
		//IL_0365: Expected O, but got Ref
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Expected Ref, but got Unknown
		//IL_022c: Expected O, but got I4
		//IL_0274: Expected I4, but got O
		_003C_003Ec__DisplayClass42_0 obj = new _003C_003Ec__DisplayClass42_0();
		object arg;
		string format;
		if (obj != null)
		{
			obj._003C_003E4__this = this;
			obj.adventureType = adventureType;
			DataManager dataManager = _dataManager;
			if (_dataManager != null && dataManager._003CAllAdventures_003Ek__BackingField != null)
			{
				AdventureType adventureType2 = default(AdventureType);
				if (!((Dictionary<System.Int32Enum, object>)(object)dataManager._003CAllAdventures_003Ek__BackingField).TryGetValue((System.Int32Enum)adventureType, out object _))
				{
					arg = adventureType2;
					format = "Data for {0} could not be found in the DataManager";
					goto IL_034a;
				}
				PlayerOptions playerOptions = _playerOptions;
				if (_playerOptions != null)
				{
					PlayerOptionsData mainGameConfig = playerOptions._mainGameConfig;
					if (playerOptions._mainGameConfig != null && mainGameConfig._003CAdventuresSaveData_003Ek__BackingField != null)
					{
						if (!((Dictionary<System.Int32Enum, object>)(object)mainGameConfig._003CAdventuresSaveData_003Ek__BackingField).TryGetValue((System.Int32Enum)obj.adventureType, out *(object*)(obj + 32)))
						{
							arg = adventureType2;
							format = "Progress data for {0} could not be found in the main game config";
							goto IL_034a;
						}
						if (!CanAscend(obj.adventureType))
						{
							Debug.LogWarning("Cannot ascend an Adventure as it has not been completed");
							return false;
						}
						PlayerOptions playerOptions2 = _playerOptions;
						if (_playerOptions != null)
						{
							PlayerOptionsData mainGameConfig2 = playerOptions2._mainGameConfig;
							if (playerOptions2._mainGameConfig != null)
							{
								bool flag = mainGameConfig2._003CSeenAscensionPopups_003Ek__BackingField == null;
								if (!flag)
								{
									bool flag2 = ((Dictionary<AdventureType, PlayerOptionsData>)(object)mainGameConfig2._003CSeenAscensionPopups_003Ek__BackingField).TryGetValue(obj.adventureType, out *(PlayerOptionsData*)null);
									object obj2 = !flag;
									if (obj2 == null)
									{
										ApplyAscension(obj.adventurePod, obj.adventureType);
										return true;
									}
									Action<bool> action = null;
									bool flag3 = ((Dictionary<AdventureType, PlayerOptionsData>)(object)action).TryGetValue((AdventureType)obj, out *(PlayerOptionsData*)null);
									bool textIsLocalizationTerm = default(bool);
									PopupManager.CreateOKCancelPopup("Ascension-Tutorial-Popup", "adventureLang/adv_adventureSelect_ascendAdventure", "adventureLang/adv_adventureSelect_ascendAdventurePopup", action, textIsLocalizationTerm);
									return false;
								}
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_034a:
		System.ParamsArray paramsArray = new System.ParamsArray(arg);
		object obj3 = default(object);
		string message = string.FormatHelper((IFormatProvider)null, format, (System.ParamsArray)(&obj3));
		Debug.LogWarning(message);
		return false;
	}

	public unsafe void ResetAdventureProgress(AdventureType adventureType)
	{
		//IL_012e: Expected I4, but got O
		//IL_0153: Expected O, but got Ref
		//IL_00cc: Expected I4, but got O
		//IL_0102: Expected O, but got I
		PlayerOptions playerOptions = _playerOptions;
		PlayerOptionsData mainGameConfig = playerOptions._mainGameConfig;
		int num = ((Dictionary<System.Int32Enum, object>)(object)mainGameConfig._003CAdventuresSaveData_003Ek__BackingField).FindEntry((System.Int32Enum)adventureType);
		object obj2 = default(object);
		if (num >= 0)
		{
			PlayerOptions playerOptions2 = _playerOptions;
			PlayerOptionsData mainGameConfig2 = playerOptions2._mainGameConfig;
			if (((Dictionary<System.Int32Enum, object>)(object)mainGameConfig2._003CAdventuresSaveData_003Ek__BackingField).TryGetValue((System.Int32Enum)adventureType, out object _))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ stack_20_v3 (System.Object)+2D8]");
				if ((nint)0 != 0)
				{
					object obj = (AdventureType)obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182AD6810");
					object message = default(object);
					Debug.Log(message);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ stack_20_v3 (System.Object)+2D8]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rcx_v18+1C]");
					_ = (nint)0 + (nint)1;
					_ = 0;
				}
			}
		}
		else
		{
			object arg = (AdventureType)obj2;
			System.ParamsArray paramsArray = new System.ParamsArray(arg);
			object obj4 = default(object);
			string message2 = string.FormatHelper((IFormatProvider)null, "Trying to reset Adventure progress for {0}, but no save data exists for it", (System.ParamsArray)(&obj4));
			Debug.LogWarning(message2);
		}
	}

	public static void ForceExitAdventure()
	{
		_adventureManagerInstance.ExitAdventureMode(fireExitEvent: false, resetDataManager: true, force: true);
	}

	public void ExitAdventureMode(bool fireExitEvent = true, bool resetDataManager = true, bool force = false)
	{
		//IL_030e: Expected O, but got I4
		//IL_0317: Expected O, but got I4
		//IL_0347: Expected O, but got I4
		//IL_03fe: Expected O, but got I4
		if (!_003CIsInAdventureMode_003Ek__BackingField && !force)
		{
			return;
		}
		PlayerOptions playerOptions = _playerOptions;
		PlayerOptionsData currentAdventureSaveData = playerOptions._currentAdventureSaveData;
		PlayerOptions playerOptions2 = _playerOptions;
		PlayerOptionsData mainGameConfig = playerOptions2._mainGameConfig;
		mainGameConfig._003CSoundsVolume_003Ek__BackingField = currentAdventureSaveData._003CSoundsVolume_003Ek__BackingField;
		mainGameConfig._003CMusicVolume_003Ek__BackingField = currentAdventureSaveData._003CMusicVolume_003Ek__BackingField;
		mainGameConfig._003CLanguage_003Ek__BackingField = currentAdventureSaveData._003CLanguage_003Ek__BackingField;
		mainGameConfig._003CClassicMusic_003Ek__BackingField = currentAdventureSaveData._003CClassicMusic_003Ek__BackingField;
		mainGameConfig._003CVisuallyInvertStages_003Ek__BackingField = currentAdventureSaveData._003CVisuallyInvertStages_003Ek__BackingField;
		mainGameConfig._003CHideProgress_003Ek__BackingField = currentAdventureSaveData._003CHideProgress_003Ek__BackingField;
		mainGameConfig._003CFlashingVFXEnabled_003Ek__BackingField = currentAdventureSaveData._003CFlashingVFXEnabled_003Ek__BackingField;
		mainGameConfig._003CJoystickVisible_003Ek__BackingField = currentAdventureSaveData._003CJoystickVisible_003Ek__BackingField;
		mainGameConfig._003CSelectedJoystickType_003Ek__BackingField = currentAdventureSaveData._003CSelectedJoystickType_003Ek__BackingField;
		mainGameConfig._003CDamageNumbersEnabled_003Ek__BackingField = currentAdventureSaveData._003CDamageNumbersEnabled_003Ek__BackingField;
		mainGameConfig._003CGlimmerCarouselEnabled_003Ek__BackingField = currentAdventureSaveData._003CGlimmerCarouselEnabled_003Ek__BackingField;
		mainGameConfig._003CStreamSafeEnabled_003Ek__BackingField = currentAdventureSaveData._003CStreamSafeEnabled_003Ek__BackingField;
		mainGameConfig._003CFullscreen_003Ek__BackingField = currentAdventureSaveData._003CFullscreen_003Ek__BackingField;
		mainGameConfig._003CHideAdsButtons_003Ek__BackingField = currentAdventureSaveData._003CHideAdsButtons_003Ek__BackingField;
		mainGameConfig._003CShowPickups_003Ek__BackingField = currentAdventureSaveData._003CShowPickups_003Ek__BackingField;
		mainGameConfig._003CShowSmallMapIcons_003Ek__BackingField = currentAdventureSaveData._003CShowSmallMapIcons_003Ek__BackingField;
		mainGameConfig._003CEnableBonusAdsMechanics_003Ek__BackingField = currentAdventureSaveData._003CEnableBonusAdsMechanics_003Ek__BackingField;
		mainGameConfig._003CScreenShakeEnabled_003Ek__BackingField = currentAdventureSaveData._003CScreenShakeEnabled_003Ek__BackingField;
		mainGameConfig._003CControllerVibrationEnabled_003Ek__BackingField = currentAdventureSaveData._003CControllerVibrationEnabled_003Ek__BackingField;
		mainGameConfig._003CAssignControllerToPlayer1_003Ek__BackingField = currentAdventureSaveData._003CAssignControllerToPlayer1_003Ek__BackingField;
		mainGameConfig._003CShowPlayerIndicators_003Ek__BackingField = currentAdventureSaveData._003CShowPlayerIndicators_003Ek__BackingField;
		mainGameConfig._003CPermanentCoopOutlines_003Ek__BackingField = currentAdventureSaveData._003CPermanentCoopOutlines_003Ek__BackingField;
		mainGameConfig._003CTintUISelection_003Ek__BackingField = currentAdventureSaveData._003CTintUISelection_003Ek__BackingField;
		mainGameConfig._003CSequentialChestMode_003Ek__BackingField = currentAdventureSaveData._003CSequentialChestMode_003Ek__BackingField;
		mainGameConfig._003CDisableMovingBackground_003Ek__BackingField = currentAdventureSaveData._003CDisableMovingBackground_003Ek__BackingField;
		mainGameConfig._003CDisableBlood_003Ek__BackingField = currentAdventureSaveData._003CDisableBlood_003Ek__BackingField;
		mainGameConfig._003CBorderType_003Ek__BackingField = currentAdventureSaveData._003CBorderType_003Ek__BackingField;
		mainGameConfig._003CPixelFont_003Ek__BackingField = currentAdventureSaveData._003CPixelFont_003Ek__BackingField;
		mainGameConfig._003CDisplayDefangedEnemies_003Ek__BackingField = currentAdventureSaveData._003CDisplayDefangedEnemies_003Ek__BackingField;
		mainGameConfig._003CHasPlayedStage3_003Ek__BackingField = currentAdventureSaveData._003CHasPlayedStage3_003Ek__BackingField;
		_playerOptions.Save();
		_playerOptions.CurrentAdventureSaveData = null;
		_playerOptions.ApplyLoadedOptions();
		PlayerOptions playerOptions3 = _playerOptions;
		playerOptions3._playerStats.InitStats();
		bool flag = !resetDataManager;
		object obj = 0;
		object obj2 = 0;
		if (!flag)
		{
			DataManager dataManager = _dataManager;
			dataManager._adventureStageData = null;
			obj2 = 0;
			dataManager._adventureCharacterData = null;
			obj = 0;
			dataManager.ReloadAllData();
		}
		_playerOptions.ApplyUnlocksToData();
		_003CAdventureData_003Ek__BackingField = null;
		_003CIsInAdventureMode_003Ek__BackingField = false;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186C84580");
		if (fireExitEvent)
		{
			Action action = _003COnAdventureExitEvent_003Ek__BackingField;
			if (_003COnAdventureExitEvent_003Ek__BackingField != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v707.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
	}

	public bool IsAdventureCharacter(CharacterType characterType)
	{
		//IL_0096: Expected I4, but got O
		if (_003CIsInAdventureMode_003Ek__BackingField)
		{
			AdventureData adventureData = _003CAdventureData_003Ek__BackingField;
			if (_003CAdventureData_003Ek__BackingField == null)
			{
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			if (adventureData._003CCharacterTypes_003Ek__BackingField != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
				bool result = default(bool);
				return result;
			}
		}
		return false;
	}

	public bool IsAdventureCompleted(AdventureType adventureType)
	{
		//IL_0304: Expected I4, but got O
		//IL_01e9: Expected O, but got I
		//IL_023e: Expected O, but got I
		//IL_0280: Expected O, but got I
		//IL_029d: Expected O, but got I
		//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b2: Expected O, but got Unknown
		DataManager dataManager = _dataManager;
		if (_dataManager != null && dataManager._003CAllAdventures_003Ek__BackingField != null)
		{
			if (!((Dictionary<System.Int32Enum, object>)(object)dataManager._003CAllAdventures_003Ek__BackingField).TryGetValue((System.Int32Enum)adventureType, out object value))
			{
				goto IL_02f0;
			}
			PlayerOptions playerOptions = _playerOptions;
			if (_playerOptions != null)
			{
				PlayerOptionsData mainGameConfig = playerOptions._mainGameConfig;
				if (playerOptions._mainGameConfig != null && mainGameConfig._003CAdventuresSaveData_003Ek__BackingField != null)
				{
					int num = ((Dictionary<System.Int32Enum, object>)(object)mainGameConfig._003CAdventuresSaveData_003Ek__BackingField).FindEntry((System.Int32Enum)adventureType);
					if (num < 0)
					{
						goto IL_02f0;
					}
					PlayerOptions playerOptions2 = _playerOptions;
					if (_playerOptions != null)
					{
						PlayerOptionsData mainGameConfig2 = playerOptions2._mainGameConfig;
						if (playerOptions2._mainGameConfig != null && mainGameConfig2._003CAdventuresSaveData_003Ek__BackingField != null)
						{
							object obj = ((Dictionary<System.Int32Enum, object>)(object)mainGameConfig2._003CAdventuresSaveData_003Ek__BackingField).get_Item((System.Int32Enum)adventureType);
							if (obj != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ rax_v13 (System.Object)+2D8]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ rax_v13 (System.Object)+2D8]");
									object obj2 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rcx_v9+18]");
									if ((nint)0 > (nint)0)
									{
										if (value != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ stack_8_v3 (System.Object)+40]");
											object obj3 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ stack_8_v3 (System.Object)+40]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rcx_v9+18]");
												nint num2 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rax_v15+18]");
												object obj4 = num2 - 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rcx_v9+18]");
												nint num3 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rax_v15+18]");
												object obj5 = num3 ^ 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rcx_v9+18]");
												object obj6 = 0 ^ obj4;
												object obj7 = obj5 & obj6;
												bool flag = (nint)obj7 < 0;
												bool flag2 = (nint)obj4 < 0;
												return flag2 == flag;
											}
										}
										goto IL_02f6;
									}
								}
							}
							goto IL_02f0;
						}
					}
				}
			}
		}
		goto IL_02f6;
		IL_02f0:
		return false;
		IL_02f6:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public bool WasAdventureAlreadyCompleted(AdventureType adventureType)
	{
		//IL_0247: Expected I4, but got O
		//IL_01ca: Expected O, but got I
		//IL_01e0: Expected O, but got I
		//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f5: Expected O, but got Unknown
		DataManager dataManager = _dataManager;
		if (_dataManager != null && dataManager._003CAllAdventures_003Ek__BackingField != null)
		{
			if (!((Dictionary<System.Int32Enum, object>)(object)dataManager._003CAllAdventures_003Ek__BackingField).TryGetValue((System.Int32Enum)adventureType, out object _))
			{
				goto IL_0233;
			}
			PlayerOptions playerOptions = _playerOptions;
			if (_playerOptions != null)
			{
				PlayerOptionsData mainGameConfig = playerOptions._mainGameConfig;
				if (playerOptions._mainGameConfig != null && mainGameConfig._003CAdventuresSaveData_003Ek__BackingField != null)
				{
					int num = ((Dictionary<System.Int32Enum, object>)(object)mainGameConfig._003CAdventuresSaveData_003Ek__BackingField).FindEntry((System.Int32Enum)adventureType);
					if (num < 0)
					{
						goto IL_0233;
					}
					PlayerOptions playerOptions2 = _playerOptions;
					if (_playerOptions != null)
					{
						PlayerOptionsData mainGameConfig2 = playerOptions2._mainGameConfig;
						if (playerOptions2._mainGameConfig != null && mainGameConfig2._003CAdventuresSaveData_003Ek__BackingField != null)
						{
							object obj = ((Dictionary<System.Int32Enum, object>)(object)mainGameConfig2._003CAdventuresSaveData_003Ek__BackingField).get_Item((System.Int32Enum)adventureType);
							if (obj != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rax_v13 (System.Object)+2D4]");
								object obj2 = -1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rax_v13 (System.Object)+2D4]");
								object obj3 = (nint)0 ^ (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rax_v13 (System.Object)+2D4]");
								object obj4 = 0 ^ obj2;
								object obj5 = obj3 & obj4;
								bool flag = (nint)obj5 < 0;
								bool flag2 = (nint)obj2 < 0;
								return flag2 == flag;
							}
							goto IL_0233;
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0233:
		return false;
	}

	public bool CanAscend(AdventureType adventureType)
	{
		//IL_0128: Expected I4, but got O
		//IL_00e7: Expected O, but got I
		//IL_0165: Expected O, but got I
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Expected O, but got Unknown
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Expected I4, but got Unknown
		if (IsAdventureCompleted(adventureType))
		{
			PlayerOptions playerOptions = _playerOptions;
			if (_playerOptions != null)
			{
				PlayerOptionsData mainGameConfig = playerOptions._mainGameConfig;
				if (playerOptions._mainGameConfig != null && mainGameConfig._003CAdventuresSaveData_003Ek__BackingField != null)
				{
					object obj = ((Dictionary<System.Int32Enum, object>)(object)mainGameConfig._003CAdventuresSaveData_003Ek__BackingField).get_Item((System.Int32Enum)adventureType);
					if (obj != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rax_v7 (System.Object)+2D8]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rax_v7 (System.Object)+2D8]");
							object obj2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rcx_v7+18]");
							if ((nint)0 > (nint)0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rax_v7 (System.Object)+2D4]");
								object obj3 = -MAX_ASCENSION_POINTS;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rax_v7 (System.Object)+2D4]");
								int num = (int)((nint)0 ^ (nint)MAX_ASCENSION_POINTS);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rax_v7 (System.Object)+2D4]");
								object obj4 = 0 ^ obj3;
								int num2 = num & obj4;
								bool flag = num2 < 0;
								bool flag2 = (nint)obj3 < 0;
								return flag2 != flag;
							}
						}
					}
					goto IL_0114;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		goto IL_0114;
		IL_0114:
		return false;
	}

	public unsafe void InitDataManagerForAdventure(AdventureType adventureType)
	{
		//IL_02c3: Expected I, but got O
		//IL_00df: Expected O, but got I4
		//IL_0114: Expected O, but got I
		//IL_0129: Expected O, but got I
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Expected O, but got Unknown
		//IL_023d->IL02ee: Incompatible stack heights: 2 vs 0
		//IL_01c3->IL02c8: Incompatible stack heights: 1 vs 0
		//IL_0288->IL02ee: Incompatible stack heights: 4 vs 0
		if ((object)MarkerInitDataManager != null)
		{
			ProfilerUnsafeUtility.BeginSample((IntPtr)MarkerInitDataManager);
		}
		DataManager dataManager = _dataManager;
		bool flag = dataManager._003CAllAdventures_003Ek__BackingField == null;
		int num = ((Dictionary<System.Int32Enum, object>)(object)dataManager._003CAllAdventures_003Ek__BackingField).FindEntry((System.Int32Enum)adventureType);
		ProfilerMarker.AutoScope autoScope = default(ProfilerMarker.AutoScope);
		if (!flag)
		{
			_dataManager.ReloadAllData();
			DataManager dataManager2 = _dataManager;
			object obj = ((Dictionary<System.Int32Enum, object>)(object)dataManager2._003CAllAdventures_003Ek__BackingField).get_Item((System.Int32Enum)adventureType);
			_003CAdventureData_003Ek__BackingField = (AdventureData)obj;
			_dataManager.UpdateAllCharacterHiddenPropertiesForAdventures(_003CAdventureData_003Ek__BackingField);
			_dataManager.GenerateAdventureSpecificData(_003CAdventureData_003Ek__BackingField);
			Dictionary<WeaponType, List<WeaponData>> convertedWeapons = _dataManager.GetConvertedWeapons();
			Dictionary<WeaponType, List<WeaponData>>.Enumerator enumerator = default(Dictionary<WeaponType, List<WeaponData>>.Enumerator);
			object obj6 = default(object);
			while (enumerator.MoveNext())
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v926 @ rax_v50+18]");
				bool flag2 = (nint)0 <= (nint)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v926 @ rax_v50+10]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rax_v51+20]");
				object obj4 = 0;
				AdventureData adventureData = _003CAdventureData_003Ek__BackingField;
				List<WeaponType> list = adventureData._003CWeaponTypes_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v665 @ rcx_v29 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
				bool flag3;
				if ((nint)0 == 0)
				{
					flag3 = false;
					continue;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
				object obj5 = obj6 - -1;
				bool flag4 = obj5 == null;
				flag3 = !flag4;
			}
			Dictionary<StageType, List<VampireSurvivors.Data.Stage.StageData>>.Enumerator enumerator2 = default(Dictionary<StageType, List<VampireSurvivors.Data.Stage.StageData>>.Enumerator);
			Dictionary<StageType, List<VampireSurvivors.Data.Stage.StageData>>.Enumerator enumerator3 = default(Dictionary<StageType, List<VampireSurvivors.Data.Stage.StageData>>.Enumerator);
			while (enumerator2.MoveNext())
			{
				AdventureData adventureData2 = _003CAdventureData_003Ek__BackingField;
				bool flag5 = _003CAdventureData_003Ek__BackingField == null;
				CoreAdventureData coreAdventureData = adventureData2._003CCoreAdventureData_003Ek__BackingField;
				bool flag6 = adventureData2._003CCoreAdventureData_003Ek__BackingField == null;
				if (StageType.FOREST == coreAdventureData._003CStartingStage_003Ek__BackingField)
				{
					bool flag7 = (object)enumerator3 == null;
					bool flag8 = ((Dictionary<StageType, List<VampireSurvivors.Data.Stage.StageData>>.Enumerator*)enumerator3)->MoveNext();
					bool flag9 = !flag8;
					_ = 1;
				}
			}
			autoScope.Dispose();
		}
		else
		{
			autoScope.Dispose();
		}
	}

	private void ApplyAscension(PlayerOptionsData adventurePod, AdventureType adventureType)
	{
		PlayerOptionsData playerOptionsData = StartNewAdventure(adventureType);
		int num = adventurePod._003CAdventureCompletionCount_003Ek__BackingField + 1;
		playerOptionsData._003CAdventureCompletionCount_003Ek__BackingField = num;
		playerOptionsData._003CAscensionPointsAllocation_003Ek__BackingField = adventurePod._003CAscensionPointsAllocation_003Ek__BackingField;
		playerOptionsData._003CAllTimeAdventurePlaytime_003Ek__BackingField = adventurePod._003CAllTimeAdventurePlaytime_003Ek__BackingField;
		_playerOptions.CurrentAdventureSaveData = playerOptionsData;
		PlayerOptionsData config = _playerOptions.Config;
		config._003CSelectedGoldenEggs_003Ek__BackingField = false;
		PlayerOptionsData config2 = _playerOptions.Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9D240");
		object obj = default(object);
		if (obj != null)
		{
			PlayerOptionsData config3 = _playerOptions.Config;
			bool flag = ((List<System.Int32Enum>)(object)config3._003CCompletedAdventures_003Ek__BackingField).Remove((System.Int32Enum)adventureType);
		}
		_playerOptions.Save();
		ResetAdventureProgress(adventureType);
		bool flag2 = _003CIsInAdventureMode_003Ek__BackingField;
		bool flag3 = false;
		if (!flag2)
		{
			ExitAdventureMode(fireExitEvent: false, resetDataManager: true, force: true);
			flag3 = true;
		}
		Action<bool> action = _003COnAdventureAscended_003Ek__BackingField;
		if (_003COnAdventureAscended_003Ek__BackingField != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v433 @ rax_v18 (System.Action`1<System.Boolean>)+18] (should have been resolved before IL gen)");
		}
	}

	private void CopyCoreSettingsFromAdventureToBaseGame(PlayerOptionsData AdventureGameSaveData)
	{
		PlayerOptions playerOptions = _playerOptions;
		PlayerOptionsData mainGameConfig = playerOptions._mainGameConfig;
		mainGameConfig._003CSoundsVolume_003Ek__BackingField = AdventureGameSaveData._003CSoundsVolume_003Ek__BackingField;
		mainGameConfig._003CMusicVolume_003Ek__BackingField = AdventureGameSaveData._003CMusicVolume_003Ek__BackingField;
		mainGameConfig._003CLanguage_003Ek__BackingField = AdventureGameSaveData._003CLanguage_003Ek__BackingField;
		mainGameConfig._003CClassicMusic_003Ek__BackingField = AdventureGameSaveData._003CClassicMusic_003Ek__BackingField;
		mainGameConfig._003CVisuallyInvertStages_003Ek__BackingField = AdventureGameSaveData._003CVisuallyInvertStages_003Ek__BackingField;
		mainGameConfig._003CHideProgress_003Ek__BackingField = AdventureGameSaveData._003CHideProgress_003Ek__BackingField;
		mainGameConfig._003CFlashingVFXEnabled_003Ek__BackingField = AdventureGameSaveData._003CFlashingVFXEnabled_003Ek__BackingField;
		mainGameConfig._003CJoystickVisible_003Ek__BackingField = AdventureGameSaveData._003CJoystickVisible_003Ek__BackingField;
		mainGameConfig._003CSelectedJoystickType_003Ek__BackingField = AdventureGameSaveData._003CSelectedJoystickType_003Ek__BackingField;
		mainGameConfig._003CDamageNumbersEnabled_003Ek__BackingField = AdventureGameSaveData._003CDamageNumbersEnabled_003Ek__BackingField;
		mainGameConfig._003CGlimmerCarouselEnabled_003Ek__BackingField = AdventureGameSaveData._003CGlimmerCarouselEnabled_003Ek__BackingField;
		mainGameConfig._003CStreamSafeEnabled_003Ek__BackingField = AdventureGameSaveData._003CStreamSafeEnabled_003Ek__BackingField;
		mainGameConfig._003CFullscreen_003Ek__BackingField = AdventureGameSaveData._003CFullscreen_003Ek__BackingField;
		mainGameConfig._003CHideAdsButtons_003Ek__BackingField = AdventureGameSaveData._003CHideAdsButtons_003Ek__BackingField;
		mainGameConfig._003CShowPickups_003Ek__BackingField = AdventureGameSaveData._003CShowPickups_003Ek__BackingField;
		mainGameConfig._003CShowSmallMapIcons_003Ek__BackingField = AdventureGameSaveData._003CShowSmallMapIcons_003Ek__BackingField;
		mainGameConfig._003CEnableBonusAdsMechanics_003Ek__BackingField = AdventureGameSaveData._003CEnableBonusAdsMechanics_003Ek__BackingField;
		mainGameConfig._003CScreenShakeEnabled_003Ek__BackingField = AdventureGameSaveData._003CScreenShakeEnabled_003Ek__BackingField;
		mainGameConfig._003CControllerVibrationEnabled_003Ek__BackingField = AdventureGameSaveData._003CControllerVibrationEnabled_003Ek__BackingField;
		mainGameConfig._003CAssignControllerToPlayer1_003Ek__BackingField = AdventureGameSaveData._003CAssignControllerToPlayer1_003Ek__BackingField;
		mainGameConfig._003CShowPlayerIndicators_003Ek__BackingField = AdventureGameSaveData._003CShowPlayerIndicators_003Ek__BackingField;
		mainGameConfig._003CPermanentCoopOutlines_003Ek__BackingField = AdventureGameSaveData._003CPermanentCoopOutlines_003Ek__BackingField;
		mainGameConfig._003CTintUISelection_003Ek__BackingField = AdventureGameSaveData._003CTintUISelection_003Ek__BackingField;
		mainGameConfig._003CSequentialChestMode_003Ek__BackingField = AdventureGameSaveData._003CSequentialChestMode_003Ek__BackingField;
		mainGameConfig._003CDisableMovingBackground_003Ek__BackingField = AdventureGameSaveData._003CDisableMovingBackground_003Ek__BackingField;
		mainGameConfig._003CDisableBlood_003Ek__BackingField = AdventureGameSaveData._003CDisableBlood_003Ek__BackingField;
		mainGameConfig._003CBorderType_003Ek__BackingField = AdventureGameSaveData._003CBorderType_003Ek__BackingField;
		mainGameConfig._003CPixelFont_003Ek__BackingField = AdventureGameSaveData._003CPixelFont_003Ek__BackingField;
		mainGameConfig._003CDisplayDefangedEnemies_003Ek__BackingField = AdventureGameSaveData._003CDisplayDefangedEnemies_003Ek__BackingField;
		mainGameConfig._003CHasPlayedStage3_003Ek__BackingField = AdventureGameSaveData._003CHasPlayedStage3_003Ek__BackingField;
	}

	private PlayerOptionsData StartNewAdventure(AdventureType adventureType)
	{
		//IL_0059: Expected O, but got I4
		PlayerOptions playerOptions = _playerOptions;
		if (_playerOptions != null)
		{
			PlayerOptionsData playerOptionsData = new PlayerOptionsData(addDefaults: false);
			CopyDataFromBaseGame(playerOptions._mainGameConfig, playerOptionsData);
			if (playerOptionsData != null)
			{
				playerOptionsData._003CSelectedAdventureType_003Ek__BackingField = (AdventureType?)(object)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 78 Invalid \"Jump target not found in method: 0x186C813E0\"");
			}
		}
		return (PlayerOptionsData)(object)new NullReferenceException();
	}

	private PlayerOptionsData GenerateNewAdventureData(PlayerOptionsData currentSaveData, AdventureType adventureType)
	{
		//IL_0030: Expected O, but got I4
		PlayerOptionsData playerOptionsData = new PlayerOptionsData(addDefaults: false);
		CopyDataFromBaseGame(currentSaveData, playerOptionsData);
		if (playerOptionsData != null)
		{
			playerOptionsData._003CSelectedAdventureType_003Ek__BackingField = (AdventureType?)(object)1;
			return playerOptionsData;
		}
		return (PlayerOptionsData)(object)new NullReferenceException();
	}

	private PlayerOptionsData PopulateSaveDataWithAdventureData(PlayerOptionsData adventureSaveData, AdventureType adventureType)
	{
		//IL_00e8: Expected O, but got I
		//IL_013f: Expected F4, but got I
		//IL_014f: Expected O, but got I
		//IL_0189: Expected F4, but got I
		//IL_0199: Expected O, but got I
		//IL_01fa: Expected O, but got I
		//IL_025b: Expected O, but got I
		//IL_02a5: Expected O, but got I
		//IL_0306: Expected O, but got I
		//IL_0395: Expected O, but got I
		DataManager dataManager = _dataManager;
		if (_dataManager != null && dataManager._003CAllAdventures_003Ek__BackingField != null)
		{
			int num = ((Dictionary<System.Int32Enum, object>)(object)dataManager._003CAllAdventures_003Ek__BackingField).FindEntry((System.Int32Enum)adventureType);
			if (num < 0)
			{
				Debug.LogError("Trying to load JSON data for an Adventure which does not exist");
				return adventureSaveData;
			}
			DataManager dataManager2 = _dataManager;
			if (_dataManager != null && dataManager2._003CAllAdventures_003Ek__BackingField != null)
			{
				object obj = ((Dictionary<System.Int32Enum, object>)(object)dataManager2._003CAllAdventures_003Ek__BackingField).get_Item((System.Int32Enum)adventureType);
				if (obj != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rax_v13 (System.Object)+20]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rax_v13 (System.Object)+20]");
					if ((nint)0 != 0 && adventureSaveData != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rax_v14+20]");
						adventureSaveData._003CCoins_003Ek__BackingField = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rax_v13 (System.Object)+20]");
						object obj3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rax_v13 (System.Object)+20]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rax_v15+20]");
							adventureSaveData._003CLifetimeCoins_003Ek__BackingField = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rax_v13 (System.Object)+20]");
							object obj4 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rax_v13 (System.Object)+20]");
							if ((nint)0 != 0 && adventureSaveData._003CUnlockedCharacters_003Ek__BackingField != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99240");
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rax_v13 (System.Object)+20]");
								object obj5 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rax_v13 (System.Object)+20]");
								if ((nint)0 != 0 && adventureSaveData._003CBoughtCharacters_003Ek__BackingField != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99240");
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rax_v13 (System.Object)+20]");
									object obj6 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rax_v13 (System.Object)+20]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rdx_v10+24]");
										adventureSaveData.SelectedCharacter = CharacterType.VOID;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rax_v13 (System.Object)+20]");
										object obj7 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rax_v13 (System.Object)+20]");
										if ((nint)0 != 0 && adventureSaveData._003CUnlockedStages_003Ek__BackingField != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97AB0");
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rax_v13 (System.Object)+20]");
											object obj8 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rax_v13 (System.Object)+20]");
											if ((nint)0 != 0)
											{
												List<System.Int32Enum> list = (List<System.Int32Enum>)(object)adventureSaveData._003CUnlockedWeapons_003Ek__BackingField;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rax_v20+28]");
												adventureSaveData._003CSelectedStage_003Ek__BackingField = StageType.FOREST;
												if (adventureSaveData._003CUnlockedWeapons_003Ek__BackingField != null)
												{
													List<WeaponType> list2 = adventureSaveData._003CUnlockedWeapons_003Ek__BackingField;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rcx_v11 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
													nint num2 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rax_v13 (System.Object)+38]");
													((List<System.Int32Enum>)(object)list2).InsertRange((int)num2, (IEnumerable<System.Int32Enum>)0);
													return adventureSaveData;
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		return (PlayerOptionsData)(object)new NullReferenceException();
	}

	public void CopyDataFromBaseGame(PlayerOptionsData baseGameSaveData, PlayerOptionsData adventureSaveData)
	{
		CopyRelicsFromBaseGame(baseGameSaveData, adventureSaveData);
		adventureSaveData._003CUnlockedSkinsV2_003Ek__BackingField = baseGameSaveData._003CUnlockedSkinsV2_003Ek__BackingField;
		adventureSaveData._003CBoughtSkins_003Ek__BackingField = baseGameSaveData._003CBoughtSkins_003Ek__BackingField;
		CopyArcanasFromBaseGame(baseGameSaveData, adventureSaveData);
		CopyCoreSettingsFromBaseGame(baseGameSaveData, adventureSaveData);
	}

	private void CopyArcanasFromBaseGame(PlayerOptionsData baseGameSaveData, PlayerOptionsData adventureSaveData)
	{
		//IL_0021: Expected I, but got O
		//IL_0084: Expected O, but got I
		//IL_01bc: Expected I, but got O
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected O, but got Unknown
		//IL_017b: Expected I, but got O
		//IL_00f9: Expected O, but got I
		//IL_0120: Expected I, but got O
		//IL_013e: Expected O, but got I
		List<ArcanaType> list = baseGameSaveData._003CUnlockedArcanas_003Ek__BackingField;
		nint num = unchecked((nint)null);
		object obj = default(object);
		object obj2 = default(object);
		object obj4 = default(object);
		nint num3 = default(nint);
		object obj7 = default(object);
		while (true)
		{
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ stack_-28_v3+1C]");
				if (obj2 != null)
				{
					break;
				}
				object obj3 = obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ stack_-28_v3+18]");
				if ((nint)obj3 >= 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ stack_-28_v3+10]");
				object obj5 = 0;
				object obj6 = obj4 + 1;
				List<ArcanaType> list2 = adventureSaveData._003CUnlockedArcanas_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v508 @ rcx_v18 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
				bool flag = (nint)0 == 0;
				nint num2 = num3;
				nint num4 = 0;
				List<ArcanaType> list3 = list;
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v508 @ rcx_v18 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
					list3 = (List<ArcanaType>)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
					bool flag2 = (nint)obj7 != -1;
					num2 = 0;
					num4 = unchecked((nint)null);
					num3 = 0;
					obj4 = obj6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v508 @ rcx_v18 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
					list = (List<ArcanaType>)0;
					if (flag2)
					{
						continue;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97710");
				num3 = num2;
				obj4 = obj6;
				list = list3;
				num = (nint)adventureSaveData._003CUnlockedArcanas_003Ek__BackingField;
				continue;
			}
			throw new NullReferenceException();
		}
		bool flag3 = obj == null;
		num = 0;
		if (!flag3)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ stack_-28_v3+1C]");
			if (obj2 == null)
			{
				return;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			num = unchecked((nint)null);
		}
		throw new NullReferenceException();
	}

	private void CopyCoreSettingsFromBaseGame(PlayerOptionsData baseGameSaveData, PlayerOptionsData adventureSaveData)
	{
		adventureSaveData._003CSoundsVolume_003Ek__BackingField = baseGameSaveData._003CSoundsVolume_003Ek__BackingField;
		adventureSaveData._003CMusicVolume_003Ek__BackingField = baseGameSaveData._003CMusicVolume_003Ek__BackingField;
		adventureSaveData._003CLanguage_003Ek__BackingField = baseGameSaveData._003CLanguage_003Ek__BackingField;
		adventureSaveData._003CClassicMusic_003Ek__BackingField = baseGameSaveData._003CClassicMusic_003Ek__BackingField;
		adventureSaveData._003CVisuallyInvertStages_003Ek__BackingField = baseGameSaveData._003CVisuallyInvertStages_003Ek__BackingField;
		adventureSaveData._003CHideProgress_003Ek__BackingField = baseGameSaveData._003CHideProgress_003Ek__BackingField;
		adventureSaveData._003CFlashingVFXEnabled_003Ek__BackingField = baseGameSaveData._003CFlashingVFXEnabled_003Ek__BackingField;
		adventureSaveData._003CJoystickVisible_003Ek__BackingField = baseGameSaveData._003CJoystickVisible_003Ek__BackingField;
		adventureSaveData._003CSelectedJoystickType_003Ek__BackingField = baseGameSaveData._003CSelectedJoystickType_003Ek__BackingField;
		adventureSaveData._003CDamageNumbersEnabled_003Ek__BackingField = baseGameSaveData._003CDamageNumbersEnabled_003Ek__BackingField;
		adventureSaveData._003CGlimmerCarouselEnabled_003Ek__BackingField = baseGameSaveData._003CGlimmerCarouselEnabled_003Ek__BackingField;
		adventureSaveData._003CStreamSafeEnabled_003Ek__BackingField = baseGameSaveData._003CStreamSafeEnabled_003Ek__BackingField;
		adventureSaveData._003CFullscreen_003Ek__BackingField = baseGameSaveData._003CFullscreen_003Ek__BackingField;
		adventureSaveData._003CHideAdsButtons_003Ek__BackingField = baseGameSaveData._003CHideAdsButtons_003Ek__BackingField;
		adventureSaveData._003CShowPickups_003Ek__BackingField = baseGameSaveData._003CShowPickups_003Ek__BackingField;
		adventureSaveData._003CShowSmallMapIcons_003Ek__BackingField = baseGameSaveData._003CShowSmallMapIcons_003Ek__BackingField;
		adventureSaveData._003CEnableBonusAdsMechanics_003Ek__BackingField = baseGameSaveData._003CEnableBonusAdsMechanics_003Ek__BackingField;
		adventureSaveData._003CScreenShakeEnabled_003Ek__BackingField = baseGameSaveData._003CScreenShakeEnabled_003Ek__BackingField;
		adventureSaveData._003CControllerVibrationEnabled_003Ek__BackingField = baseGameSaveData._003CControllerVibrationEnabled_003Ek__BackingField;
		adventureSaveData._003CAssignControllerToPlayer1_003Ek__BackingField = baseGameSaveData._003CAssignControllerToPlayer1_003Ek__BackingField;
		adventureSaveData._003CShowPlayerIndicators_003Ek__BackingField = baseGameSaveData._003CShowPlayerIndicators_003Ek__BackingField;
		adventureSaveData._003CPermanentCoopOutlines_003Ek__BackingField = baseGameSaveData._003CPermanentCoopOutlines_003Ek__BackingField;
		adventureSaveData._003CTintUISelection_003Ek__BackingField = baseGameSaveData._003CTintUISelection_003Ek__BackingField;
		adventureSaveData._003CSequentialChestMode_003Ek__BackingField = baseGameSaveData._003CSequentialChestMode_003Ek__BackingField;
		adventureSaveData._003CDisableMovingBackground_003Ek__BackingField = baseGameSaveData._003CDisableMovingBackground_003Ek__BackingField;
		adventureSaveData._003CDisableBlood_003Ek__BackingField = baseGameSaveData._003CDisableBlood_003Ek__BackingField;
		adventureSaveData._003CBorderType_003Ek__BackingField = baseGameSaveData._003CBorderType_003Ek__BackingField;
		adventureSaveData._003CPixelFont_003Ek__BackingField = baseGameSaveData._003CPixelFont_003Ek__BackingField;
		adventureSaveData._003CDisplayDefangedEnemies_003Ek__BackingField = baseGameSaveData._003CDisplayDefangedEnemies_003Ek__BackingField;
		adventureSaveData._003CHasPlayedStage3_003Ek__BackingField = baseGameSaveData._003CHasPlayedStage3_003Ek__BackingField;
	}

	private void CopySkinsFromBaseGame(PlayerOptionsData baseGameSaveData, PlayerOptionsData adventureSaveData)
	{
		adventureSaveData._003CUnlockedSkinsV2_003Ek__BackingField = baseGameSaveData._003CUnlockedSkinsV2_003Ek__BackingField;
		adventureSaveData._003CBoughtSkins_003Ek__BackingField = baseGameSaveData._003CBoughtSkins_003Ek__BackingField;
	}

	private unsafe void CopyRelicsFromBaseGame(PlayerOptionsData baseGameSaveData, PlayerOptionsData adventureSaveData)
	{
		//IL_0239: Expected O, but got I
		//IL_0078: Expected O, but got I
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected O, but got Unknown
		object value = null;
		object obj = default(object);
		object obj2 = default(object);
		AdventureManager adventureManager2 = default(AdventureManager);
		while (true)
		{
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ stack_-50_v3+1C]");
				if (obj2 != null)
				{
					break;
				}
				AdventureManager adventureManager = adventureManager2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ stack_-50_v3+18]");
				if ((nint)adventureManager >= 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ stack_-50_v3+10]");
				object obj3 = 0;
				adventureManager2 = (AdventureManager)(adventureManager2 + 1);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ rbx_v8+20+v496 @ rcx_v18 (VampireSurvivors.App.Scripts.Framework.Adventures.AdventureManager)*4]");
				if ((nint)0 == 0)
				{
					continue;
				}
				DataManager dataManager = _dataManager;
				Dictionary<ItemType, ItemData> dictionary = dataManager._003CAllItems_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ rbx_v8+20+v496 @ rcx_v18 (VampireSurvivors.App.Scripts.Framework.Adventures.AdventureManager)*4]");
				if (!((Dictionary<System.Int32Enum, object>)(object)dictionary).TryGetValue((System.Int32Enum)0, out value) || value == null)
				{
					continue;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ stack_-38_v3 (System.Object)+53]");
				if ((nint)0 != 0)
				{
					List<ItemType> list = adventureSaveData._003CCollectedItems_003Ek__BackingField;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ rbx_v8+20+v496 @ rcx_v18 (VampireSurvivors.App.Scripts.Framework.Adventures.AdventureManager)*4]");
					if (!((Dictionary<ItemType, ItemData>)(object)list).TryGetValue(ItemType.VOID, out *(ItemData*)(&value)))
					{
						List<ItemType> list2 = adventureSaveData._003CCollectedItems_003Ek__BackingField;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ rbx_v8+20+v496 @ rcx_v18 (VampireSurvivors.App.Scripts.Framework.Adventures.AdventureManager)*4]");
						bool flag = ((Dictionary<ItemType, ItemData>)(object)list2).TryGetValue(ItemType.VOID, out *(ItemData*)(&value));
					}
				}
				continue;
			}
			throw new NullReferenceException();
		}
		bool flag2 = obj == null;
		AdventureManager adventureManager3 = (AdventureManager)0;
		if (!flag2)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ stack_-50_v3+1C]");
			if (obj2 == null)
			{
				return;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			adventureManager3 = null;
		}
		throw new NullReferenceException();
	}

	private unsafe PlayerOptionsData LoadAdventureData(AdventureType adventureType)
	{
		//IL_0127: Expected I4, but got O
		//IL_014c: Expected O, but got Ref
		PlayerOptions playerOptions = _playerOptions;
		if (_playerOptions != null)
		{
			PlayerOptionsData mainGameConfig = playerOptions._mainGameConfig;
			if (playerOptions._mainGameConfig != null && mainGameConfig._003CAdventuresSaveData_003Ek__BackingField != null)
			{
				int num = ((Dictionary<System.Int32Enum, object>)(object)mainGameConfig._003CAdventuresSaveData_003Ek__BackingField).FindEntry((System.Int32Enum)adventureType);
				if (num < 0)
				{
					object obj = default(object);
					object arg = (AdventureType)obj;
					System.ParamsArray paramsArray = new System.ParamsArray(arg);
					object obj2 = default(object);
					string message = string.FormatHelper((IFormatProvider)null, "Trying to load Adventure of type {0}, but the save data does not contain any data for this...", (System.ParamsArray)(&obj2));
					Debug.LogError(message);
					return null;
				}
				PlayerOptions playerOptions2 = _playerOptions;
				if (_playerOptions != null)
				{
					PlayerOptionsData mainGameConfig2 = playerOptions2._mainGameConfig;
					if (playerOptions2._mainGameConfig != null && mainGameConfig2._003CAdventuresSaveData_003Ek__BackingField != null)
					{
						return (PlayerOptionsData)((Dictionary<System.Int32Enum, object>)(object)mainGameConfig2._003CAdventuresSaveData_003Ek__BackingField).get_Item((System.Int32Enum)adventureType);
					}
				}
			}
		}
		return (PlayerOptionsData)(object)new NullReferenceException();
	}

	static AdventureManager()
	{
		//IL_0035: Expected O, but got I
		//IL_005b: Expected O, but got I
		//IL_0065: Expected O, but got I4
		MAX_ASCENSION_POINTS = 60;
		IntPtr intPtr = ProfilerUnsafeUtility.CreateMarker("AdventureManager.InitAdventure", 1, MarkerFlags.Default, 0);
		MarkerInitAdventure = (ProfilerMarker)(nint)intPtr;
		IntPtr intPtr2 = ProfilerUnsafeUtility.CreateMarker("AdventureManager.InitDataManager", 1, MarkerFlags.Default, 0);
		MarkerInitDataManager = (ProfilerMarker)(nint)intPtr2;
		_003CCurrentAdventureDlcType_003Ek__BackingField = (DlcType?)(object)0;
	}
}
