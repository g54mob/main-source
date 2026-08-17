using System;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using I2.Loc;
using UnityEngine;
using VampireSurvivors.App.Data.Adventures;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Data.Items;
using VampireSurvivors.Data.PowerUp;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.DLC;
using VampireSurvivors.Framework.Loading;
using VampireSurvivors.Framework.Platforms;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using Zenject;

namespace VampireSurvivors.Achievements;

public class AchievementManager : IInitializable, IDisposable
{
	[Serializable]
	public enum AchievementUnlockType
	{
		KillXNumberOfEnemies = 1,
		KillXNumberOfEnemiesOfTypes,
		KillXNumberOfEnemiesInRun,
		KillBossTypesInRun,
		PlayInStage,
		SurviveXSeconds,
		FindItems,
		FindXNumberOfItems,
		FindXNumberOfAnyItems,
		HaveOpenedCoffinForXCharacter,
		FindWeapons,
		CollectedWeapons,
		HaveLeveledWeaponToSpecificLevel,
		HaveLeveledWeaponToSpecificLevelOrEvolved,
		ReachedXLevel,
		ReachedXLevelAsCharacter,
		PlayXCharacter,
		HaveModifiers
	}

	[Serializable]
	public enum ModifierType
	{
		Hyper = 1,
		Hurry,
		LimitBreak,
		Inverse,
		Endless
	}

	public List<AchievementType> AchievementsUnlockedOnPlatform;

	private DataManager _dataManager;

	private AdventureProgressManager _adventureProgressManager;

	private AdventureManager _adventureManager;

	private Dictionary<AchievementType, AchievementData> _Achievements;

	private List<AchievementType> _UnAchievedAchievements;

	private List<AchievementData> _recentlyUnlocked;

	private List<AchievementData> _recentlyUnlockedAdventureProgress;

	private List<SecretType> _newSecrets;

	private List<VampireSurvivors.Objects.Characters.CharacterController> _Characters;

	private List<AchievementType> _AchivementsToUnlock;

	private List<ICustomAchievements> _CustomAchievementHandellers;

	private PlayerOptions _playerOptions;

	private GameSessionData _sessionData;

	private MultiplayerManager _multiplayer;

	public bool allowUnlocking;

	private int _CollectionCount;

	public List<SecretType> NewSecrets => _newSecrets;

	public List<VampireSurvivors.Objects.Characters.CharacterController> Characters => _Characters;

	private void Construct(PlayerOptions playerOptions, GameSessionData session, MultiplayerManager multi)
	{
		_playerOptions = playerOptions;
		_sessionData = session;
		_multiplayer = multi;
	}

	public void Initialize()
	{
	}

	public void Dispose()
	{
	}

	public void Setup()
	{
		//IL_00b0: Expected I4, but got O
		//IL_0118: Expected I4, but got O
		//IL_0180: Expected I4, but got O
		//IL_01e8: Expected I4, but got O
		//IL_0250: Expected I4, but got O
		DataManager dataManager = _dataManager;
		_Achievements = dataManager._003CAllAchievements_003Ek__BackingField;
		BaseGame_CustomAchivementHandleing baseGame_CustomAchivementHandleing = new BaseGame_CustomAchivementHandleing();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AFF0");
		Dictionary<DlcType, BundleManifestData> loadedDlc = DlcSystem.LoadedDlc;
		int num = ((Dictionary<System.Int32Enum, object>)(object)loadedDlc).FindEntry((System.Int32Enum)0);
		Dictionary<DlcType, BundleManifestData> loadedDlc2 = DlcSystem.LoadedDlc;
		int num2 = ((Dictionary<System.Int32Enum, object>)(object)loadedDlc2).FindEntry((System.Int32Enum)1);
		if (num2 >= 0)
		{
			Foscari_CustomAchivementHandleing foscari_CustomAchivementHandleing = new Foscari_CustomAchivementHandleing();
			int num3 = ((Dictionary<DlcType, BundleManifestData>)(object)_CustomAchievementHandellers).FindEntry((DlcType)foscari_CustomAchivementHandleing);
		}
		Dictionary<DlcType, BundleManifestData> loadedDlc3 = DlcSystem.LoadedDlc;
		int num4 = ((Dictionary<System.Int32Enum, object>)(object)loadedDlc3).FindEntry((System.Int32Enum)2);
		if (num4 >= 0)
		{
			Chalcedony_CustomAchivementHandleing chalcedony_CustomAchivementHandleing = new Chalcedony_CustomAchivementHandleing();
			int num5 = ((Dictionary<DlcType, BundleManifestData>)(object)_CustomAchievementHandellers).FindEntry((DlcType)chalcedony_CustomAchivementHandleing);
		}
		Dictionary<DlcType, BundleManifestData> loadedDlc4 = DlcSystem.LoadedDlc;
		int num6 = ((Dictionary<System.Int32Enum, object>)(object)loadedDlc4).FindEntry((System.Int32Enum)3);
		if (num6 >= 0)
		{
			FirstBlood_CustomAchivementHandleing firstBlood_CustomAchivementHandleing = new FirstBlood_CustomAchivementHandleing();
			int num7 = ((Dictionary<DlcType, BundleManifestData>)(object)_CustomAchievementHandellers).FindEntry((DlcType)firstBlood_CustomAchivementHandleing);
		}
		Dictionary<DlcType, BundleManifestData> loadedDlc5 = DlcSystem.LoadedDlc;
		int num8 = ((Dictionary<System.Int32Enum, object>)(object)loadedDlc5).FindEntry((System.Int32Enum)5);
		if (num8 >= 0)
		{
			ThosePeople_CustomAchivementHandleing thosePeople_CustomAchivementHandleing = new ThosePeople_CustomAchivementHandleing();
			int num9 = ((Dictionary<DlcType, BundleManifestData>)(object)_CustomAchievementHandellers).FindEntry((DlcType)thosePeople_CustomAchivementHandleing);
		}
		Dictionary<DlcType, BundleManifestData> loadedDlc6 = DlcSystem.LoadedDlc;
		int num10 = ((Dictionary<System.Int32Enum, object>)(object)loadedDlc6).FindEntry((System.Int32Enum)4);
		if (num10 >= 0)
		{
			Emeralds_CustomAchivementHandleing emeralds_CustomAchivementHandleing = new Emeralds_CustomAchivementHandleing();
			int num11 = ((Dictionary<DlcType, BundleManifestData>)(object)_CustomAchievementHandellers).FindEntry((DlcType)emeralds_CustomAchivementHandleing);
		}
	}

	public void UnlockAchievement(AchievementType achievement)
	{
		//IL_0028: Expected O, but got I
		//IL_007d: Expected O, but got I
		List<System.Int32Enum> achivementsToUnlock = (List<System.Int32Enum>)(object)_AchivementsToUnlock;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rcx_v2 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rcx_v2 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rcx_v2 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r8_v3+18]");
		if (num >= 0)
		{
			achivementsToUnlock.AddWithResize((System.Int32Enum)achievement);
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rcx_v2 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		object obj2 = (nint)0 + (nint)1;
	}

	public void UnlockAchievementDirectly(AchievementType t)
	{
		DataManager dataManager = _dataManager;
		_Achievements = dataManager._003CAllAchievements_003Ek__BackingField;
		bool flag = Unlock(t);
	}

	public unsafe void CheckForStartupAchievements()
	{
		//IL_0044: Expected O, but got I4
		//IL_004c: Expected O, but got Ref
		//IL_030a: Expected O, but got I
		//IL_031a: Expected O, but got I
		//IL_0374: Expected O, but got I
		//IL_0526: Expected O, but got I
		//IL_0536: Expected O, but got I
		//IL_0590: Expected O, but got I
		//IL_0742: Expected O, but got I
		//IL_0752: Expected O, but got I
		//IL_07ac: Expected O, but got I
		//IL_095e: Expected O, but got I
		//IL_096e: Expected O, but got I
		//IL_09c8: Expected O, but got I
		//IL_0b7a: Expected O, but got I
		//IL_0b8a: Expected O, but got I
		//IL_0beb: Expected O, but got I
		if (AdventureManager._003CIsInAdventureMode_003Ek__BackingField)
		{
			return;
		}
		FixUnlocks();
		List<ICustomAchievements>.Enumerator enumerator = default(List<ICustomAchievements>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			List<ICustomAchievements>.Enumerator enumerator2 = (List<ICustomAchievements>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		Dictionary<DlcType, BundleManifestData> loadedDlc = DlcSystem.LoadedDlc;
		int num = ((Dictionary<System.Int32Enum, object>)(object)loadedDlc).FindEntry((System.Int32Enum)0);
		PlayerOptionsData playerOptionsData;
		if (num >= 0)
		{
			PlayerOptions playerOptions = _playerOptions;
			if (playerOptions._onlineClientWithRunDataConfig == null)
			{
				if (playerOptions._hostGameConfig == null)
				{
					if (playerOptions._currentAdventureSaveData != null)
					{
						playerOptionsData = playerOptions._currentAdventureSaveData;
						if ((object)playerOptionsData._003CSelectedAdventureType_003Ek__BackingField != null)
						{
							goto IL_0ce0;
						}
					}
					playerOptionsData = playerOptions._mainGameConfig;
				}
				else
				{
					playerOptionsData = playerOptions._hostGameConfig;
				}
			}
			else
			{
				playerOptionsData = playerOptions._onlineClientWithRunDataConfig;
			}
			goto IL_0ce0;
		}
		goto IL_0389;
		IL_0d9b:
		PlayerOptionsData playerOptionsData2;
		List<StageType> list = playerOptionsData2._003CUnlockedStages_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v467 @ rcx_v53 (System.Collections.Generic.List`1<VampireSurvivors.Data.StageType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj2 = default(object);
			if ((nint)obj2 != -1)
			{
				goto IL_09dd;
			}
		}
		PlayerOptionsData config = _playerOptions.Config;
		List<System.Int32Enum> list2 = (List<System.Int32Enum>)(object)config._003CUnlockedStages_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v458 @ rcx_v56 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v458 @ rcx_v56 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v458 @ rcx_v56 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v458 @ rcx_v56 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v365 @ r9_v15+18]");
		if (num2 >= 0)
		{
			list2.AddWithResize((System.Int32Enum)28);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v458 @ rcx_v56 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj5 = (nint)0 + (nint)1;
			_ = 28;
		}
		goto IL_09dd;
		IL_0ddd:
		PlayerOptionsData playerOptionsData3;
		List<StageType> list3 = playerOptionsData3._003CUnlockedStages_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v468 @ rcx_v45 (System.Collections.Generic.List`1<VampireSurvivors.Data.StageType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj6 = default(object);
			if ((nint)obj6 != -1)
			{
				goto IL_0dad;
			}
		}
		PlayerOptionsData config2 = _playerOptions.Config;
		List<System.Int32Enum> list4 = (List<System.Int32Enum>)(object)config2._003CUnlockedStages_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v463 @ rcx_v48 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v463 @ rcx_v48 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v463 @ rcx_v48 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		object obj8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v463 @ rcx_v48 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ r9_v12+18]");
		if (num3 >= 0)
		{
			list4.AddWithResize((System.Int32Enum)1048);
			UnlockAchievementsAndGiveRewards();
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v463 @ rcx_v48 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		object obj9 = (nint)0 + (nint)1;
		_ = 1048;
		goto IL_0dad;
		IL_0d23:
		PlayerOptionsData playerOptionsData4;
		List<StageType> list5 = playerOptionsData4._003CUnlockedStages_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v465 @ rcx_v67 (System.Collections.Generic.List`1<VampireSurvivors.Data.StageType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj10 = default(object);
			if ((nint)obj10 != -1)
			{
				goto IL_05a5;
			}
		}
		PlayerOptionsData config3 = _playerOptions.Config;
		List<System.Int32Enum> list6 = (List<System.Int32Enum>)(object)config3._003CUnlockedStages_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v448 @ rcx_v70 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v448 @ rcx_v70 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v448 @ rcx_v70 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		object obj12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v448 @ rcx_v70 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v359 @ r9_v21+18]");
		if (num4 >= 0)
		{
			list6.AddWithResize((System.Int32Enum)23);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v448 @ rcx_v70 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj13 = (nint)0 + (nint)1;
			_ = 23;
		}
		goto IL_05a5;
		IL_09dd:
		Dictionary<DlcType, BundleManifestData> loadedDlc2 = DlcSystem.LoadedDlc;
		int num5 = ((Dictionary<System.Int32Enum, object>)(object)loadedDlc2).FindEntry((System.Int32Enum)5);
		if (num5 < 0)
		{
			goto IL_0dad;
		}
		PlayerOptions playerOptions2 = _playerOptions;
		if (playerOptions2._onlineClientWithRunDataConfig == null)
		{
			if (playerOptions2._hostGameConfig == null)
			{
				if (playerOptions2._currentAdventureSaveData != null)
				{
					playerOptionsData3 = playerOptions2._currentAdventureSaveData;
					if ((object)playerOptionsData3._003CSelectedAdventureType_003Ek__BackingField != null)
					{
						goto IL_0ddd;
					}
				}
				playerOptionsData3 = playerOptions2._mainGameConfig;
			}
			else
			{
				playerOptionsData3 = playerOptions2._hostGameConfig;
			}
		}
		else
		{
			playerOptionsData3 = playerOptions2._onlineClientWithRunDataConfig;
		}
		goto IL_0ddd;
		IL_0389:
		Dictionary<DlcType, BundleManifestData> loadedDlc3 = DlcSystem.LoadedDlc;
		int num6 = ((Dictionary<System.Int32Enum, object>)(object)loadedDlc3).FindEntry((System.Int32Enum)1);
		if (num6 >= 0)
		{
			PlayerOptions playerOptions3 = _playerOptions;
			if (playerOptions3._onlineClientWithRunDataConfig == null)
			{
				if (playerOptions3._hostGameConfig == null)
				{
					if (playerOptions3._currentAdventureSaveData != null)
					{
						playerOptionsData4 = playerOptions3._currentAdventureSaveData;
						if ((object)playerOptionsData4._003CSelectedAdventureType_003Ek__BackingField != null)
						{
							goto IL_0d23;
						}
					}
					playerOptionsData4 = playerOptions3._mainGameConfig;
				}
				else
				{
					playerOptionsData4 = playerOptions3._hostGameConfig;
				}
			}
			else
			{
				playerOptionsData4 = playerOptions3._onlineClientWithRunDataConfig;
			}
			goto IL_0d23;
		}
		goto IL_05a5;
		IL_07c1:
		Dictionary<DlcType, BundleManifestData> loadedDlc4 = DlcSystem.LoadedDlc;
		int num7 = ((Dictionary<System.Int32Enum, object>)(object)loadedDlc4).FindEntry((System.Int32Enum)3);
		if (num7 >= 0)
		{
			PlayerOptions playerOptions4 = _playerOptions;
			if (playerOptions4._onlineClientWithRunDataConfig == null)
			{
				if (playerOptions4._hostGameConfig == null)
				{
					if (playerOptions4._currentAdventureSaveData != null)
					{
						playerOptionsData2 = playerOptions4._currentAdventureSaveData;
						if ((object)playerOptionsData2._003CSelectedAdventureType_003Ek__BackingField != null)
						{
							goto IL_0d9b;
						}
					}
					playerOptionsData2 = playerOptions4._mainGameConfig;
				}
				else
				{
					playerOptionsData2 = playerOptions4._hostGameConfig;
				}
			}
			else
			{
				playerOptionsData2 = playerOptions4._onlineClientWithRunDataConfig;
			}
			goto IL_0d9b;
		}
		goto IL_09dd;
		IL_0dad:
		UnlockAchievementsAndGiveRewards();
		return;
		IL_05a5:
		Dictionary<DlcType, BundleManifestData> loadedDlc5 = DlcSystem.LoadedDlc;
		int num8 = ((Dictionary<System.Int32Enum, object>)(object)loadedDlc5).FindEntry((System.Int32Enum)2);
		PlayerOptionsData playerOptionsData5;
		if (num8 >= 0)
		{
			PlayerOptions playerOptions5 = _playerOptions;
			if (playerOptions5._onlineClientWithRunDataConfig == null)
			{
				if (playerOptions5._hostGameConfig == null)
				{
					if (playerOptions5._currentAdventureSaveData != null)
					{
						playerOptionsData5 = playerOptions5._currentAdventureSaveData;
						if ((object)playerOptionsData5._003CSelectedAdventureType_003Ek__BackingField != null)
						{
							goto IL_0d5f;
						}
					}
					playerOptionsData5 = playerOptions5._mainGameConfig;
				}
				else
				{
					playerOptionsData5 = playerOptions5._hostGameConfig;
				}
			}
			else
			{
				playerOptionsData5 = playerOptions5._onlineClientWithRunDataConfig;
			}
			goto IL_0d5f;
		}
		goto IL_07c1;
		IL_0d5f:
		List<StageType> list7 = playerOptionsData5._003CUnlockedStages_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v466 @ rcx_v60 (System.Collections.Generic.List`1<VampireSurvivors.Data.StageType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj14 = default(object);
			if ((nint)obj14 != -1)
			{
				goto IL_07c1;
			}
		}
		PlayerOptionsData config4 = _playerOptions.Config;
		List<System.Int32Enum> list8 = (List<System.Int32Enum>)(object)config4._003CUnlockedStages_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v453 @ rcx_v63 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v453 @ rcx_v63 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v453 @ rcx_v63 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		object obj16 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v453 @ rcx_v63 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v362 @ r9_v18+18]");
		if (num9 >= 0)
		{
			list8.AddWithResize((System.Int32Enum)26);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v453 @ rcx_v63 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj17 = (nint)0 + (nint)1;
			_ = 26;
		}
		goto IL_07c1;
		IL_0ce0:
		List<StageType> list9 = playerOptionsData._003CUnlockedStages_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rcx_v74 (System.Collections.Generic.List`1<VampireSurvivors.Data.StageType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj18 = default(object);
			if ((nint)obj18 != -1)
			{
				goto IL_0389;
			}
		}
		PlayerOptionsData config5 = _playerOptions.Config;
		List<System.Int32Enum> list10 = (List<System.Int32Enum>)(object)config5._003CUnlockedStages_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v443 @ rcx_v77 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v443 @ rcx_v77 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
		object obj19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v443 @ rcx_v77 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		object obj20 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v443 @ rcx_v77 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
		nint num10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v356 @ r9_v24+18]");
		if (num10 >= 0)
		{
			list10.AddWithResize((System.Int32Enum)20);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v443 @ rcx_v77 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
			object obj21 = (nint)0 + (nint)1;
			_ = 20;
		}
		goto IL_0389;
	}

	public unsafe void FixUnlocks()
	{
		//IL_0013: Expected O, but got I4
		//IL_001b: Expected O, but got Ref
		//IL_018f: Expected O, but got I
		//IL_071a: Expected I, but got O
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Expected O, but got Unknown
		//IL_01ff: Expected O, but got I
		//IL_02fc: Expected O, but got I
		//IL_0791: Expected I, but got O
		//IL_030a: Unknown result type (might be due to invalid IL or missing references)
		//IL_030f: Expected O, but got Unknown
		//IL_0510: Expected O, but got I
		//IL_0386: Expected O, but got I
		//IL_0419: Expected O, but got I
		//IL_044d: Expected O, but got I4
		//IL_063a: Expected O, but got I
		//IL_07e7: Expected I, but got O
		//IL_0648: Unknown result type (might be due to invalid IL or missing references)
		//IL_064d: Expected O, but got Unknown
		//IL_06bc: Expected I, but got O
		List<AchievementType> list = new List<AchievementType>();
		List<ICustomAchievements>.Enumerator enumerator = default(List<ICustomAchievements>.Enumerator);
		if (enumerator.MoveNext())
		{
			List<ICustomAchievements>.Enumerator enumerator2 = (List<ICustomAchievements>.Enumerator)0;
			List<ICustomAchievements>.Enumerator enumerator3 = (List<ICustomAchievements>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		object obj = default(object);
		object obj2 = default(object);
		object obj4 = default(object);
		object obj6 = default(object);
		while (true)
		{
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ stack_-80_v28+1C]");
				if (obj2 == null)
				{
					object obj3 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ stack_-80_v28+18]");
					if ((nint)obj3 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ stack_-80_v28+10]");
						object obj5 = 0;
						obj4 = obj6 + 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v643 @ rdx_v62+20+v627 @ stack_-78_v26*4]");
						bool flag = Unlock(AchievementType.ReachLV5);
						continue;
					}
					break;
				}
				break;
			}
			throw new NullReferenceException();
		}
		bool flag2 = obj == null;
		nint num = 0;
		object obj17;
		if (!flag2)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ stack_-80_v28+1C]");
			if (obj2 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ stack_-80_v28+18]");
				object obj7 = (nint)0 + (nint)1;
				Dictionary<PowerUpType, int> dictionary = new Dictionary<PowerUpType, int>();
				PlayerOptions playerOptions = _playerOptions;
				if (playerOptions._onlineClientWithRunDataConfig == null && playerOptions._hostGameConfig == null && playerOptions._currentAdventureSaveData != null)
				{
					PlayerOptionsData currentAdventureSaveData = playerOptions._currentAdventureSaveData;
					if ((object)currentAdventureSaveData._003CSelectedAdventureType_003Ek__BackingField != null)
					{
					}
				}
				object obj8 = obj7;
				object obj9 = default(object);
				while (true)
				{
					if (obj9 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ stack_-80_v30+1C]");
						if (obj2 != null)
						{
							break;
						}
						object obj10 = obj8;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ stack_-80_v30+18]");
						if ((nint)obj10 >= 0)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ stack_-80_v30+10]");
						object obj11 = 0;
						object obj12 = obj8 + 1;
						bool flag3 = _Achievements == null;
						Dictionary<AchievementType, AchievementData> achievements = _Achievements;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1025 @ rdx_v51+20+v1008 @ stack_-78_v28*4]");
						int num2 = ((Dictionary<System.Int32Enum, object>)(object)achievements).FindEntry((System.Int32Enum)0);
						obj8 = obj12;
						if (flag3)
						{
							continue;
						}
						Dictionary<AchievementType, AchievementData> achievements2 = _Achievements;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1025 @ rdx_v51+20+v2063 @ rcx_v61*4]");
						object obj13 = ((Dictionary<System.Int32Enum, object>)(object)achievements2).get_Item((System.Int32Enum)0);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1238 @ rax_v128 (System.Object)+88]");
						object obj14 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1238 @ rax_v128 (System.Object)+88]");
						bool flag4 = (nint)0 == 0;
						obj8 = obj12;
						if (flag4)
						{
							continue;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1191 @ rax_v129+10]");
						bool flag5 = (nint)0 <= (nint)0;
						obj8 = obj12;
						if (!flag5)
						{
							Dictionary<AchievementType, AchievementData> achievements3 = _Achievements;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1025 @ rdx_v51+20+v2063 @ rcx_v61*4]");
							object obj15 = ((Dictionary<System.Int32Enum, object>)(object)achievements3).get_Item((System.Int32Enum)0);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1138 @ rax_v130 (System.Object)+88]");
							PowerUpType key = Enum.Parse<PowerUpType>((string)0);
							bool flag6 = dictionary == null;
							int num3 = dictionary.FindEntry(key);
							object obj16 = !flag6;
							if (obj16 == null)
							{
								bool flag7 = ((Dictionary<System.Int32Enum, int>)(object)dictionary).TryInsert((System.Int32Enum)key, 1, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
								obj8 = obj12;
								continue;
							}
							int num4 = dictionary.get_Item(key);
							int value = num4 + 1;
							bool flag8 = ((Dictionary<System.Int32Enum, int>)(object)dictionary).TryInsert((System.Int32Enum)key, value, System.Collections.Generic.InsertionBehavior.OverwriteExisting);
							obj8 = obj12;
						}
						continue;
					}
					throw new NullReferenceException();
				}
				bool flag9 = obj9 == null;
				nint num5 = 0;
				if (!flag9)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ stack_-80_v30+1C]");
					if (obj2 == null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ stack_-80_v30+18]");
						obj17 = (nint)0 + (nint)1;
						PlayerOptions playerOptions2 = _playerOptions;
						if (playerOptions2._onlineClientWithRunDataConfig == null)
						{
							if (playerOptions2._hostGameConfig == null)
							{
								PlayerOptionsData currentAdventureSaveData2;
								if (playerOptions2._currentAdventureSaveData != null)
								{
									currentAdventureSaveData2 = playerOptions2._currentAdventureSaveData;
									if ((object)currentAdventureSaveData2._003CSelectedAdventureType_003Ek__BackingField != null)
									{
										goto IL_05cf;
									}
								}
								currentAdventureSaveData2 = playerOptions2._mainGameConfig;
							}
							else
							{
								PlayerOptionsData currentAdventureSaveData2 = playerOptions2._hostGameConfig;
							}
						}
						else
						{
							PlayerOptionsData currentAdventureSaveData2 = playerOptions2._onlineClientWithRunDataConfig;
						}
						goto IL_05cf;
					}
					System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
					num5 = unchecked((nint)null);
				}
				throw new NullReferenceException();
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			num = unchecked((nint)null);
		}
		throw new NullReferenceException();
		IL_05cf:
		object obj18 = obj17;
		object obj19 = default(object);
		while (true)
		{
			if (obj19 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v425 @ stack_-80_v32+1C]");
				if (obj2 == null)
				{
					object obj20 = obj18;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v425 @ stack_-80_v32+18]");
					if ((nint)obj20 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v425 @ stack_-80_v32+10]");
						object obj21 = 0;
						object obj22 = obj18 + 1;
						bool flag10 = _Achievements == null;
						Dictionary<AchievementType, AchievementData> achievements4 = _Achievements;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1699 @ rdx_v44+20+v1682 @ stack_-78_v30*4]");
						int num6 = ((Dictionary<System.Int32Enum, object>)(object)achievements4).FindEntry((System.Int32Enum)0);
						obj18 = obj22;
						if (!flag10)
						{
							Dictionary<AchievementType, AchievementData> achievements5 = _Achievements;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1699 @ rdx_v44+20+v2380 @ rcx_v52*4]");
							object obj23 = ((Dictionary<System.Int32Enum, object>)(object)achievements5).get_Item((System.Int32Enum)0);
							nint num7 = (nint)obj23;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2401 @ rax_v107 (Il2CppClass<System.Object>)+1D8] (should have been resolved before IL gen)");
							obj18 = obj22;
						}
						continue;
					}
					break;
				}
				break;
			}
			throw new NullReferenceException();
		}
		bool flag11 = obj19 == null;
		nint num8 = 0;
		if (!flag11)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v425 @ stack_-80_v32+1C]");
			if (obj2 == null)
			{
				return;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			num8 = unchecked((nint)null);
		}
		throw new NullReferenceException();
	}

	public unsafe List<SecretType> CheckAllSecrets()
	{
		//IL_0020: Expected native int or pointer, but got O
		//IL_002e: Expected native int or pointer, but got O
		//IL_0046: Expected O, but got Ref
		List<ICustomAchievements>.Enumerator newSecrets = (List<ICustomAchievements>.Enumerator)_newSecrets;
		int version = newSecrets._version + 1;
		((List<ICustomAchievements>.Enumerator*)(nint)newSecrets)->_version = version;
		((List<ICustomAchievements>.Enumerator*)(nint)newSecrets)->_index = 0;
		List<ICustomAchievements>.Enumerator enumerator = default(List<ICustomAchievements>.Enumerator);
		if (enumerator.MoveNext())
		{
			List<ICustomAchievements>.Enumerator enumerator2 = (List<ICustomAchievements>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		return _newSecrets;
	}

	public unsafe List<AchievementData> CheckAllAchievements()
	{
		//IL_0019: Expected I, but got O
		//IL_00b3: Expected I, but got O
		//IL_009b: Expected O, but got I
		//IL_00f9: Expected I, but got O
		//IL_01bf: Expected I, but got O
		//IL_016d: Expected I, but got O
		//IL_0276: Expected I, but got O
		//IL_0241: Expected O, but got I
		//IL_02b3: Expected I, but got O
		//IL_02d4: Expected I, but got O
		//IL_0306: Expected O, but got I
		//IL_03b6: Expected O, but got I
		//IL_03ed: Expected I, but got O
		//IL_0687: Expected I, but got O
		//IL_0716: Expected I, but got O
		//IL_0477: Expected O, but got I
		//IL_04bd: Expected O, but got Ref
		//IL_0528: Expected O, but got Ref
		//IL_064a: Expected O, but got I
		//IL_05fc: Expected I, but got O
		Debug.Log("[AchievementManager] CheckAllAchievements start");
		nint num = (nint)_recentlyUnlocked;
		bool flag3 = default(bool);
		if (_recentlyUnlocked != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ rcx_v9 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+1C]");
			_ = (nint)0 + (nint)1;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ rcx_v9 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+18]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ rcx_v9 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+10]");
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ rcx_v9 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+18]");
				Array.Clear((Array)num2, 0, 0);
				bool flag = false;
			}
			num = (nint)_AchivementsToUnlock;
			if (_AchivementsToUnlock != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ rcx_v9 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+1C]");
				_ = (nint)0 + (nint)1;
				_ = 0;
				nint num3 = (nint)typeof(GM);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v507 @ rax_v19 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
				num = 0;
				GameManager core = GM.Core;
				if ((object)GM.Core != null)
				{
					if (core._003CStartedAsOnlineMultiplayerRun_003Ek__BackingField)
					{
						bool flag2 = _playerOptions == null;
						num = (nint)_playerOptions;
						if (flag2)
						{
							goto IL_0658;
						}
						PlayerOptionsData clientPlayerOptionsWithRunDataApplied = _playerOptions.GetClientPlayerOptionsWithRunDataApplied();
						_playerOptions.ApplyConfig(clientPlayerOptionsWithRunDataApplied, adventureMode: false, hostConfig: false, flag3);
						bool flag = false;
					}
					num = (nint)_Characters;
					if (_Characters != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ rcx_v9 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+1C]");
						_ = (nint)0 + (nint)1;
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ rcx_v9 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+18]");
						if ((nint)0 > (nint)0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ rcx_v9 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+10]");
							nint num4 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ rcx_v9 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+18]");
							Array.Clear((Array)num4, 0, 0);
							bool flag = false;
						}
						GameManager core2 = GM.Core;
						bool flag4 = (object)GM.Core == null;
						num = (nint)typeof(GM);
						if (!flag4)
						{
							List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters = core2._mainCharacters;
							bool flag5 = core2._mainCharacters == null;
							num = (nint)typeof(GM);
							if (!flag5)
							{
								List<object> characters = (List<object>)(object)_Characters;
								num = (nint)GM.Core;
								if (mainCharacters._size <= 1)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ rcx_v9 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+E0]");
									object obj = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ rcx_v9 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+E0]");
									if ((nint)0 != 0 && _Characters != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B050");
										goto IL_03bb;
									}
								}
								else if ((object)GM.Core != null && _Characters != null)
								{
									List<VampireSurvivors.Objects.Characters.CharacterController> characters2 = _Characters;
									int size = characters._size;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ rcx_v9 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+2A0]");
									((List<object>)(object)characters2).InsertRange(size, (IEnumerable<object>)0);
									goto IL_03bb;
								}
							}
						}
					}
				}
			}
		}
		goto IL_0658;
		IL_0658:
		throw new NullReferenceException();
		IL_03bb:
		AdventureProgressManager adventureProgressManager = _adventureProgressManager;
		Dictionary<AdventureAchievementType, AchievementData> dictionary = new Dictionary<AdventureAchievementType, AchievementData>();
		bool flag6 = _adventureProgressManager == null;
		num = (nint)dictionary;
		if (!flag6)
		{
			adventureProgressManager._003CAchieved_003Ek__BackingField = dictionary;
			num = (nint)_adventureProgressManager;
			if (_adventureProgressManager != null && _Characters != null)
			{
				List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
				while (enumerator.MoveNext())
				{
					AdventureProgressManager adventureProgressManager2 = _adventureProgressManager;
					if (_adventureProgressManager != null)
					{
						AdventureProgressManager adventureProgressManager3 = _adventureProgressManager;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ rcx_v9 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+30]");
						adventureProgressManager3.RunChecks(null, this, (Dictionary<AdventureAchievementType, AchievementData>)0, flag3);
						continue;
					}
					throw new NullReferenceException();
				}
				int collectionCount = AchivementManagerSupport.CalcualteNewCollectionCount(_dataManager, _playerOptions);
				_CollectionCount = collectionCount;
				bool flag7 = _Achievements == null;
				num = (nint)_dataManager;
				if (!flag7)
				{
					Dictionary<AchievementType, AchievementData>.Enumerator enumerator2 = default(Dictionary<AchievementType, AchievementData>.Enumerator);
					IntPtr intPtr = default(IntPtr);
					while (enumerator2.MoveNext())
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
						if (CheckAchievement(null))
						{
							string text = ((Enum)(&intPtr)).ToString();
							string text2 = null;
							string message = "Unlock achivement: " + text + " : " + text2;
							Debug.Log(message);
							if (_AchivementsToUnlock == null)
							{
								throw new NullReferenceException();
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A994F0");
						}
					}
					bool flag8 = _CustomAchievementHandellers == null;
					num = (nint)(&enumerator2);
					if (!flag8)
					{
						List<ICustomAchievements>.Enumerator enumerator3 = default(List<ICustomAchievements>.Enumerator);
						if (enumerator3.MoveNext())
						{
							List<System.Int32Enum> list = (List<System.Int32Enum>)(&enumerator3);
							throw new NullReferenceException();
						}
						if (AdventureManager._003CIsInAdventureMode_003Ek__BackingField)
						{
							List<object> recentlyUnlocked = (List<object>)(object)_recentlyUnlocked;
							bool flag9 = _recentlyUnlocked == null;
							num = (nint)_recentlyUnlocked;
							if (flag9)
							{
								goto IL_0658;
							}
							((List<object>)(object)_recentlyUnlocked).InsertRange(recentlyUnlocked._size, (IEnumerable<object>)_recentlyUnlockedAdventureProgress);
						}
						Debug.Log("[AchievementManager] CheckAllAchievements end");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ rcx_v9 (Il2CppStaticFields<VampireSurvivors.Framework.GM>)+30]");
						return BuildAchievedList((Dictionary<AdventureAchievementType, AchievementData>)0);
					}
				}
			}
		}
		goto IL_0658;
	}

	private unsafe List<AchievementData> BuildAchievedList(Dictionary<AdventureAchievementType, AchievementData> achieved)
	{
		//IL_0072: Expected O, but got I
		//IL_01c6: Expected O, but got Ref
		List<AchievementData> list = new List<AchievementData>();
		bool flag = _Achievements == null;
		List<AchievementData> list2 = list;
		if (!flag)
		{
			Dictionary<AchievementType, AchievementData>.Enumerator enumerator = default(Dictionary<AchievementType, AchievementData>.Enumerator);
			object obj = default(object);
			object obj2 = default(object);
			while (enumerator.MoveNext())
			{
				List<AchievementType> achivementsToUnlock = _AchivementsToUnlock;
				bool flag2 = _AchivementsToUnlock == null;
				list2 = (List<AchievementData>)(object)_AchivementsToUnlock;
				if (!flag2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v302 @ rcx_v29 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+18]");
					if ((nint)0 == 0)
					{
						continue;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v302 @ rcx_v29 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+10]");
					list2 = (List<AchievementData>)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
					if ((nint)obj == -1)
					{
						continue;
					}
					PlayerOptions playerOptions = _playerOptions;
					if (_playerOptions != null)
					{
						PlayerOptionsData mainGameConfig = playerOptions._mainGameConfig;
						if (playerOptions._mainGameConfig != null)
						{
							list2 = (List<AchievementData>)(object)mainGameConfig._003CAchievements_003Ek__BackingField;
							if (mainGameConfig._003CAchievements_003Ek__BackingField != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B0B0");
								if (obj2 == null)
								{
									if (list == null)
									{
										throw new NullReferenceException();
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,8\"");
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B120");
								}
								continue;
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			if (AdventureManager._003CIsInAdventureMode_003Ek__BackingField)
			{
				if (achieved == null)
				{
					goto IL_0292;
				}
				Dictionary<AdventureAchievementType, AchievementData>.Enumerator enumerator2 = default(Dictionary<AdventureAchievementType, AchievementData>.Enumerator);
				object item = default(object);
				while (enumerator2.MoveNext())
				{
					bool flag3 = list == null;
					Dictionary<AdventureAchievementType, AchievementData>.Enumerator enumerator3 = (Dictionary<AdventureAchievementType, AchievementData>.Enumerator)(&enumerator2);
					if (!flag3)
					{
						int version = list._version + 1;
						list._version = version;
						enumerator3 = (Dictionary<AdventureAchievementType, AchievementData>.Enumerator)list._items;
						if (list._items != null)
						{
							int size = list._size;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v702 @ rcx_v7 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.AdventureAchievementType, VampireSurvivors.Achievements.AchievementData>+Enumerator<VampireSurvivors.Data.AdventureAchievementType, VampireSurvivors.…");
							if ((nint)size >= (nint)0)
							{
								((List<object>)(object)list).AddWithResize(item);
								continue;
							}
							int size2 = list._size + 1;
							list._size = size2;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							continue;
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
			}
			return list;
		}
		goto IL_0292;
		IL_0292:
		throw new NullReferenceException();
	}

	public void UnlockAchievementsAndGiveRewards()
	{
		//IL_01ad: Expected O, but got I
		//IL_0068: Expected O, but got I
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		if (!allowUnlocking)
		{
			return;
		}
		object obj = default(object);
		object obj2 = default(object);
		object obj4 = default(object);
		object obj6 = default(object);
		while (true)
		{
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ stack_-28_v9+1C]");
				if (obj2 == null)
				{
					object obj3 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ stack_-28_v9+18]");
					if ((nint)obj3 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ stack_-28_v9+10]");
						object obj5 = 0;
						obj4 = obj6 + 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ rdx_v16+20+v287 @ stack_-20_v8*4]");
						bool flag = Unlock(AchievementType.ReachLV5);
						continue;
					}
					break;
				}
				break;
			}
			throw new NullReferenceException();
		}
		bool flag2 = obj == null;
		AchievementManager achievementManager = (AchievementManager)0;
		if (!flag2)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ stack_-28_v9+1C]");
			if (obj2 == null)
			{
				List<AchievementType> achivementsToUnlock = _AchivementsToUnlock;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rdx_v12 (System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>)+1C]");
				_ = (nint)0 + (nint)1;
				_ = 0;
				if (AdventureManager._003CIsInAdventureMode_003Ek__BackingField)
				{
					AdventureProgressManager adventureProgressManager = _adventureProgressManager;
					_adventureProgressManager.UnlockAll(adventureProgressManager._003CAchieved_003Ek__BackingField);
				}
				return;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			achievementManager = null;
		}
		throw new NullReferenceException();
	}

	public bool Unlock(AchievementType t)
	{
		//IL_0455: Expected I4, but got O
		//IL_017e: Expected I, but got O
		//IL_026c: Expected I4, but got O
		//IL_02ff: Expected I, but got O
		if (_Achievements != null)
		{
			Dictionary<AchievementType, AchievementData> achievements = _Achievements;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v4 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.AchievementType, VampireSurvivors.Achievements.AchievementData>)+20]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v4 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.AchievementType, VampireSurvivors.Achievements.AchievementData>)+28]");
			if (num >= 0)
			{
				int num2 = ((Dictionary<System.Int32Enum, object>)(object)_Achievements).FindEntry((System.Int32Enum)t);
				if (num2 >= 0)
				{
					PlayerOptions playerOptions = _playerOptions;
					if (_playerOptions != null)
					{
						PlayerOptionsData mainGameConfig = playerOptions._mainGameConfig;
						if (playerOptions._mainGameConfig != null && mainGameConfig._003CAchievements_003Ek__BackingField != null)
						{
							if (((Dictionary<AchievementType, AchievementData>)(object)mainGameConfig._003CAchievements_003Ek__BackingField).FindEntry(t) != 0)
							{
								goto IL_03af;
							}
							if (_Achievements != null)
							{
								object obj = ((Dictionary<System.Int32Enum, object>)(object)_Achievements).get_Item((System.Int32Enum)t);
								PlayerOptions playerOptions2 = _playerOptions;
								if (_playerOptions != null && obj != null)
								{
									nint num3 = (nint)obj;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v202 @ r10_v3 (Il2CppClass<System.Object>)+1C8] (should have been resolved before IL gen)");
									PlayerOptions playerOptions3 = _playerOptions;
									if (_playerOptions != null)
									{
										PlayerOptionsData mainGameConfig2 = playerOptions3._mainGameConfig;
										if (playerOptions3._mainGameConfig != null && mainGameConfig2._003CAchievements_003Ek__BackingField != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A994F0");
											if (_Achievements != null)
											{
												object obj2 = ((Dictionary<System.Int32Enum, object>)(object)_Achievements).get_Item((System.Int32Enum)t);
												if (_recentlyUnlocked != null)
												{
													AchievementData achievementData = ((Dictionary<AchievementType, AchievementData>)(object)_recentlyUnlocked).get_Item((AchievementType)obj2);
													if (_playerOptions != null)
													{
														PlayerOptionsData config = _playerOptions.Config;
														if (config != null)
														{
															if (!config._003CSaveSyncPlatformAchievements_003Ek__BackingField)
															{
																goto IL_03af;
															}
															SystemPlatform sInstance = SystemPlatform.sInstance;
															if (SystemPlatform.sInstance != null)
															{
																IBaseAccount currentSystem = sInstance.m_CurrentSystem;
																if (sInstance.m_CurrentSystem != null)
																{
																	nint num4 = (nint)currentSystem;
																	IPlatformAchievementsManager achievementsManager = sInstance.m_CurrentSystem.AchievementsManager;
																	if (achievementsManager != null)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B400");
																		if (AchievementsUnlockedOnPlatform != null)
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B0B0");
																			object obj3 = default(object);
																			if (obj3 == null)
																			{
																				if (AchievementsUnlockedOnPlatform == null)
																				{
																					goto IL_0447;
																				}
																				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A994F0");
																			}
																			goto IL_03af;
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
							}
						}
					}
					goto IL_0447;
				}
			}
		}
		return false;
		IL_03af:
		PlayerOptions playerOptions4 = _playerOptions;
		if (_playerOptions != null)
		{
			if (playerOptions4._currentAdventureSaveData != null)
			{
				if (_adventureManager == null)
				{
					goto IL_0447;
				}
				_adventureManager.CopyDataFromBaseGame(playerOptions4._mainGameConfig, playerOptions4._currentAdventureSaveData);
			}
			return true;
		}
		goto IL_0447;
		IL_0447:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private void PopPlatformAchievement(AchievementType t)
	{
		//IL_005a: Expected I, but got O
		PlayerOptionsData config = _playerOptions.Config;
		if (config._003CSaveSyncPlatformAchievements_003Ek__BackingField)
		{
			SystemPlatform sInstance = SystemPlatform.sInstance;
			IBaseAccount currentSystem = sInstance.m_CurrentSystem;
			nint num = (nint)currentSystem;
			IPlatformAchievementsManager achievementsManager = currentSystem.AchievementsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B400");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B0B0");
			object obj = default(object);
			if (obj == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A994F0");
			}
		}
	}

	private bool CheckAchievement(AchievementData achievementData)
	{
		if (achievementData._003CUnlockConditions_003Ek__BackingField != null)
		{
			List<AchievementUnlockConditionData> list = achievementData._003CUnlockConditions_003Ek__BackingField;
			if (list._size != 0)
			{
				List<AchievementUnlockConditionData>.Enumerator enumerator = default(List<AchievementUnlockConditionData>.Enumerator);
				do
				{
					if (!enumerator.MoveNext())
					{
						string message = "<AchievementManager.CheckAchievement> " + achievementData._003Cdescription_003Ek__BackingField + " has been Achieved";
						Debug.Log(message);
						return true;
					}
				}
				while (CheckUnlockCondition(null));
			}
		}
		return false;
	}

	private bool CheckUnlockCondition(AchievementUnlockConditionData unlockConditionData)
	{
		//IL_007a: Expected I4, but got O
		//IL_0018: Expected O, but got I4
		//IL_0042: Expected O, but got I8
		//IL_005c: Expected O, but got I8
		if (unlockConditionData != null)
		{
			object obj = unlockConditionData.AchievementUnlockType - 1;
			if ((nint)obj <= 17)
			{
				object obj2 = 6442450944L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rdx_v1+6BD74F8+v50 @ rax_v4*4]");
				object obj3 = 0 + 6442450944L;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v68 @ rcx_v3 (should have been resolved before IL gen)");
			}
			return false;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private bool CheckKillXNumberOfEnemies(int requiredNumberOfKills)
	{
		//IL_0062: Expected O, but got I4
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected I4, but got Unknown
		PlayerOptionsData config = _playerOptions.Config;
		Dictionary<EnemyType, int>.Enumerator enumerator = default(Dictionary<EnemyType, int>.Enumerator);
		while (enumerator.MoveNext())
		{
		}
		object obj = -requiredNumberOfKills;
		int num = 0 ^ requiredNumberOfKills;
		object obj2 = 0 ^ obj;
		int num2 = num & obj2;
		bool flag = num2 < 0;
		bool flag2 = (nint)obj < 0;
		return flag2 == flag;
	}

	private bool CheckKillXNumberOfEnemiesOfTypes(List<EnemyType> enemyTypes, int requiredNumberOfKills)
	{
		//IL_0018: Expected O, but got I4
		//IL_02b3: Expected O, but got I
		//IL_007b: Expected O, but got I
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Expected O, but got Unknown
		//IL_02c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ce: Expected O, but got Unknown
		//IL_02d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02db: Expected I4, but got Unknown
		//IL_02f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f5: Expected I4, but got Unknown
		//IL_01da: Expected O, but got I4
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected O, but got Unknown
		AchievementManager achievementManager = this;
		object obj = 0;
		object obj2 = default(object);
		object obj3 = default(object);
		object obj5 = default(object);
		while (true)
		{
			object obj7;
			PlayerOptionsData playerOptionsData;
			if (obj2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ stack_-30_v12+1C]");
				if (obj3 != null)
				{
					break;
				}
				object obj4 = obj5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ stack_-30_v12+18]");
				if ((nint)obj4 >= 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ stack_-30_v12+10]");
				object obj6 = 0;
				obj7 = obj5 + 1;
				PlayerOptions playerOptions = _playerOptions;
				if (playerOptions._onlineClientWithRunDataConfig == null)
				{
					if (playerOptions._hostGameConfig == null)
					{
						if (playerOptions._currentAdventureSaveData != null)
						{
							playerOptionsData = playerOptions._currentAdventureSaveData;
							if ((object)playerOptionsData._003CSelectedAdventureType_003Ek__BackingField != null)
							{
								goto IL_0151;
							}
						}
						playerOptionsData = playerOptions._mainGameConfig;
					}
					else
					{
						playerOptionsData = playerOptions._hostGameConfig;
					}
				}
				else
				{
					playerOptionsData = playerOptions._onlineClientWithRunDataConfig;
				}
				goto IL_0151;
			}
			throw new NullReferenceException();
			IL_0151:
			AchievementManager achievementManager2 = (AchievementManager)(object)playerOptionsData._003CKillCount_003Ek__BackingField;
			Dictionary<EnemyType, int> dictionary = playerOptionsData._003CKillCount_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rdx_v16+20+v132 @ stack_-28_v11*4]");
			int num = dictionary.FindEntry(EnemyType.BAT1);
			if (num < 0)
			{
				obj5 = obj7;
				achievementManager = (AchievementManager)(object)playerOptionsData._003CKillCount_003Ek__BackingField;
				continue;
			}
			DataManager dataManager = achievementManager2._dataManager;
			achievementManager = (AchievementManager)(num + num);
			object obj8 = obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v285 @ rax_v41 (VampireSurvivors.Data.DataManager)+2C+v348 @ rcx_v4 (VampireSurvivors.Achievements.AchievementManager)*8]");
			obj = obj8 + 0;
			obj5 = obj7;
		}
		bool flag = obj2 == null;
		achievementManager = (AchievementManager)0;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ stack_-30_v12+1C]");
			if (obj3 == null)
			{
				object obj9 = obj - requiredNumberOfKills;
				int num2 = obj ^ requiredNumberOfKills;
				object obj10 = obj ^ obj9;
				int num3 = num2 & obj10;
				bool flag2 = num3 < 0;
				bool flag3 = (nint)obj9 < 0;
				return flag3 == flag2;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			achievementManager = null;
		}
		throw new NullReferenceException();
	}

	private bool CheckKillXNumberOfEnemiesInRun(int requiredNumberOfKills)
	{
		//IL_00cd: Expected I4, but got O
		//IL_005d: Expected O, but got I4
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected I4, but got Unknown
		if (_playerOptions != null)
		{
			PlayerOptionsData config = _playerOptions.Config;
			if (config != null)
			{
				object obj = config._003CRunEnemies_003Ek__BackingField - requiredNumberOfKills;
				int num = config._003CRunEnemies_003Ek__BackingField ^ requiredNumberOfKills;
				int num2 = config._003CRunEnemies_003Ek__BackingField ^ obj;
				int num3 = num & num2;
				bool flag = num3 < 0;
				bool flag2 = (nint)obj < 0;
				return flag2 == flag;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private bool CheckKillBossTypesInRun(List<EnemyType> enemyTypes)
	{
		//IL_006e: Expected O, but got I
		//IL_010b: Expected I, but got O
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected O, but got Unknown
		object obj = default(object);
		object obj2 = default(object);
		object obj4 = default(object);
		object obj6 = default(object);
		while (true)
		{
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ stack_-28_v10+1C]");
				if (obj2 == null)
				{
					object obj3 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ stack_-28_v10+18]");
					if ((nint)obj3 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ stack_-28_v10+10]");
						object obj5 = 0;
						obj4++;
						PlayerOptionsData config = _playerOptions.Config;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AF20");
						if (obj6 == null)
						{
							return false;
						}
						continue;
					}
					break;
				}
				break;
			}
			throw new NullReferenceException();
		}
		bool flag = obj == null;
		nint num = 0;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ stack_-28_v10+1C]");
			if (obj2 == null)
			{
				return true;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			num = unchecked((nint)null);
		}
		throw new NullReferenceException();
	}

	private bool CheckPlayInStage(StageType requiredStage)
	{
		//IL_00d6: Expected I4, but got O
		//IL_010d: Expected O, but got I4
		PlayerOptions playerOptions = _playerOptions;
		if (_playerOptions == null)
		{
			goto IL_00c8;
		}
		PlayerOptionsData playerOptionsData;
		if (playerOptions._hostGameConfig == null)
		{
			if (playerOptions._currentAdventureSaveData != null)
			{
				playerOptionsData = playerOptions._currentAdventureSaveData;
				if ((object)playerOptionsData._003CSelectedAdventureType_003Ek__BackingField != null)
				{
					goto IL_00fb;
				}
			}
			playerOptionsData = playerOptions._mainGameConfig;
			if (playerOptions._mainGameConfig == null)
			{
				goto IL_00c8;
			}
		}
		else
		{
			playerOptionsData = playerOptions._hostGameConfig;
		}
		goto IL_00fb;
		IL_00fb:
		object obj = playerOptionsData._003CSelectedStage_003Ek__BackingField - requiredStage;
		return obj == null;
		IL_00c8:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private bool CheckSurviveXSeconds(float requiredSurvivedSeconds)
	{
		//IL_0036: Expected I4, but got O
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			bool flag = core._003CSurvivedSeconds_003Ek__BackingField < requiredSurvivedSeconds;
			return !flag;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private bool CheckFindItems(List<ItemType> requiredItemTypes)
	{
		//IL_006e: Expected O, but got I
		//IL_010b: Expected I, but got O
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected O, but got Unknown
		object obj = default(object);
		object obj2 = default(object);
		object obj4 = default(object);
		object obj6 = default(object);
		while (true)
		{
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ stack_-28_v10+1C]");
				if (obj2 == null)
				{
					object obj3 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ stack_-28_v10+18]");
					if ((nint)obj3 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ stack_-28_v10+10]");
						object obj5 = 0;
						obj4++;
						PlayerOptionsData config = _playerOptions.Config;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A965C0");
						if (obj6 == null)
						{
							return false;
						}
						continue;
					}
					break;
				}
				break;
			}
			throw new NullReferenceException();
		}
		bool flag = obj == null;
		nint num = 0;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ stack_-28_v10+1C]");
			if (obj2 == null)
			{
				return true;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			num = unchecked((nint)null);
		}
		throw new NullReferenceException();
	}

	private bool CheckFindXNumberOfItems(List<ItemType> requiredItemTypes, int requiredNumberOfItems)
	{
		//IL_02a9: Expected O, but got I
		//IL_007b: Expected O, but got I
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Expected O, but got Unknown
		//IL_02c4: Expected O, but got I4
		//IL_02d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02de: Expected I4, but got Unknown
		AchievementManager achievementManager = this;
		int num = 0;
		object obj = default(object);
		object obj2 = default(object);
		object obj4 = default(object);
		while (true)
		{
			object obj6;
			PlayerOptionsData playerOptionsData;
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ stack_-30_v13+1C]");
				if (obj2 != null)
				{
					break;
				}
				object obj3 = obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ stack_-30_v13+18]");
				if ((nint)obj3 >= 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ stack_-30_v13+10]");
				object obj5 = 0;
				obj6 = obj4 + 1;
				PlayerOptions playerOptions = _playerOptions;
				if (playerOptions._onlineClientWithRunDataConfig == null)
				{
					if (playerOptions._hostGameConfig == null)
					{
						if (playerOptions._currentAdventureSaveData != null)
						{
							playerOptionsData = playerOptions._currentAdventureSaveData;
							if ((object)playerOptionsData._003CSelectedAdventureType_003Ek__BackingField != null)
							{
								goto IL_0151;
							}
						}
						playerOptionsData = playerOptions._mainGameConfig;
					}
					else
					{
						playerOptionsData = playerOptions._hostGameConfig;
					}
				}
				else
				{
					playerOptionsData = playerOptions._onlineClientWithRunDataConfig;
				}
				goto IL_0151;
			}
			throw new NullReferenceException();
			IL_0151:
			bool flag = playerOptionsData._003CPickupCount_003Ek__BackingField == null;
			Dictionary<ItemType, int> dictionary = playerOptionsData._003CPickupCount_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rdx_v17+20+v132 @ stack_-28_v12*4]");
			int num2 = dictionary.FindEntry(ItemType.VOID);
			obj4 = obj6;
			if (!flag)
			{
				PlayerOptionsData config = _playerOptions.Config;
				Dictionary<ItemType, int> dictionary2 = config._003CPickupCount_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rdx_v17+20+v745 @ rcx_v19*4]");
				int num3 = dictionary2.get_Item(ItemType.VOID);
				num = num3;
				obj4 = obj6;
				achievementManager = (AchievementManager)(object)config._003CPickupCount_003Ek__BackingField;
			}
		}
		bool flag2 = obj == null;
		achievementManager = (AchievementManager)0;
		if (!flag2)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ stack_-30_v13+1C]");
			if (obj2 == null)
			{
				object obj7 = num - requiredNumberOfItems;
				int num4 = num ^ requiredNumberOfItems;
				int num5 = num ^ obj7;
				int num6 = num4 & num5;
				bool flag3 = num6 < 0;
				bool flag4 = (nint)obj7 < 0;
				return flag4 == flag3;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			achievementManager = null;
		}
		throw new NullReferenceException();
	}

	private bool CheckFindXNumberOfAnyItems(int requiredNumberOfItems)
	{
		//IL_000f: Expected O, but got I4
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected I4, but got Unknown
		object obj = _CollectionCount - requiredNumberOfItems;
		int num = _CollectionCount ^ requiredNumberOfItems;
		int num2 = _CollectionCount ^ obj;
		int num3 = num & num2;
		bool flag = num3 < 0;
		bool flag2 = (nint)obj < 0;
		return flag2 == flag;
	}

	public bool CheckHaveOpenedCoffinForXCharacter(CharacterType requiredCharacterType)
	{
		//IL_0115: Expected I4, but got O
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Expected I4, but got Unknown
		if (_playerOptions != null)
		{
			PlayerOptionsData config = _playerOptions.Config;
			if (config != null && config._003CUnlockedCharacters_003Ek__BackingField != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
				if (_playerOptions != null)
				{
					PlayerOptionsData config2 = _playerOptions.Config;
					if (config2 != null && config2._003COpenedCoffins_003Ek__BackingField != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
						object obj = default(object);
						bool flag = default(bool);
						bool result = (byte)((obj | flag) ? 1 : 0) != 0;
						if (!AdventureManager._003CIsInAdventureMode_003Ek__BackingField)
						{
							return result;
						}
						return flag;
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private unsafe bool CheckFindWeapons(List<WeaponType> requiredWeapons)
	{
		//IL_0202: Expected O, but got I
		//IL_0068: Expected O, but got I
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Expected O, but got Unknown
		//IL_00b6: Expected O, but got I4
		//IL_01df: Expected O, but got Ref
		//IL_0103: Expected O, but got I4
		object obj = default(object);
		object obj2 = default(object);
		AchievementManager achievementManager2 = default(AchievementManager);
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		AchievementManager achievementManager4;
		while (true)
		{
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ stack_-90_v8+1C]");
				if (obj2 != null)
				{
					break;
				}
				AchievementManager achievementManager = achievementManager2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ stack_-90_v8+18]");
				if ((nint)achievementManager >= 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ stack_-90_v8+10]");
				object obj3 = 0;
				AchievementManager achievementManager3 = achievementManager2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rdx_v12+18]");
				if ((nint)achievementManager3 < 0)
				{
					achievementManager2 = (AchievementManager)(achievementManager2 + 1);
					object obj4 = 0;
					while (enumerator.MoveNext())
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rdx_v12+20+v420 @ rcx_v14 (VampireSurvivors.Achievements.AchievementManager)*4]");
						int playerWeaponLevel = AchivementManagerSupport.GetPlayerWeaponLevel(null, WeaponType.VOID);
						if (playerWeaponLevel >= 0)
						{
							obj4 = 1;
						}
					}
					bool flag = obj4 != null;
					achievementManager4 = (AchievementManager)(&enumerator);
					if (!flag)
					{
						return false;
					}
					continue;
				}
				throw new IndexOutOfRangeException();
			}
			throw new NullReferenceException();
		}
		bool flag2 = obj == null;
		achievementManager4 = (AchievementManager)0;
		if (!flag2)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ stack_-90_v8+1C]");
			if (obj2 == null)
			{
				return true;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			achievementManager4 = null;
		}
		throw new NullReferenceException();
	}

	private bool CheckCollectedWeapons(List<WeaponType> requiredWeapons)
	{
		//IL_006e: Expected O, but got I
		//IL_010b: Expected I, but got O
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected O, but got Unknown
		object obj = default(object);
		object obj2 = default(object);
		object obj4 = default(object);
		object obj6 = default(object);
		while (true)
		{
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ stack_-28_v10+1C]");
				if (obj2 == null)
				{
					object obj3 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ stack_-28_v10+18]");
					if ((nint)obj3 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ stack_-28_v10+10]");
						object obj5 = 0;
						obj4++;
						PlayerOptionsData config = _playerOptions.Config;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
						if (obj6 == null)
						{
							return false;
						}
						continue;
					}
					break;
				}
				break;
			}
			throw new NullReferenceException();
		}
		bool flag = obj == null;
		nint num = 0;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ stack_-28_v10+1C]");
			if (obj2 == null)
			{
				return true;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			num = unchecked((nint)null);
		}
		throw new NullReferenceException();
	}

	private bool CheckHaveLeveledWeaponToSpecificLevel(WeaponType weaponType, int level)
	{
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		while (enumerator.MoveNext())
		{
			int playerWeaponLevel = AchivementManagerSupport.GetPlayerWeaponLevel(null, weaponType);
			if (playerWeaponLevel >= level)
			{
				return true;
			}
		}
		return false;
	}

	private bool CheckHaveLeveledWeaponToSpecificLevelOrEvolved(WeaponType weaponType, int level, WeaponType evolvedWeaponType)
	{
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		while (enumerator.MoveNext())
		{
			int playerWeaponLevel = AchivementManagerSupport.GetPlayerWeaponLevel(null, weaponType);
			if (playerWeaponLevel < level)
			{
				int playerWeaponLevel2 = AchivementManagerSupport.GetPlayerWeaponLevel(null, evolvedWeaponType);
				if (playerWeaponLevel2 < 0)
				{
					continue;
				}
			}
			return true;
		}
		return false;
	}

	private unsafe bool CheckReachedXLevel(int requiredLevel)
	{
		//IL_0013: Expected O, but got I4
		//IL_001b: Expected O, but got Ref
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		return false;
	}

	private unsafe bool ReachedXLevelAsCharacter(CharacterType characterType, int requiredLevel)
	{
		//IL_0013: Expected O, but got I4
		//IL_001b: Expected O, but got Ref
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		return false;
	}

	private unsafe bool CheckPlayXCharacter(CharacterType requiredCharacterType)
	{
		//IL_0013: Expected O, but got I4
		//IL_001b: Expected O, but got Ref
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		return false;
	}

	private bool CheckHaveModifiers(List<ModifierType> requiredModifierTypes)
	{
		//IL_0068: Expected O, but got I
		//IL_02ca: Expected I, but got O
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		//IL_0091: Expected O, but got I
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Expected O, but got Unknown
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Expected O, but got Unknown
		object obj2 = default(object);
		object obj3 = default(object);
		object obj4 = default(object);
		while (true)
		{
			object obj = obj2;
			while (true)
			{
				bool flag = obj3 == null;
				nint num = 0;
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ stack_-28_v17+1C]");
					if (obj4 == null)
					{
						object obj5 = obj;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ stack_-28_v17+18]");
						if ((nint)obj5 < 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ stack_-28_v17+10]");
							object obj6 = 0;
							obj++;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rax_v48+20+v134 @ r8_v19*4]");
							object obj7 = -1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rax_v48+20+v134 @ r8_v19*4]");
							bool flag2 = (nint)0 == 1;
							if (!flag2)
							{
								object obj8 = obj7 - 1;
								if (!flag2)
								{
									object obj9 = obj8 - 1;
									if (!flag2)
									{
										object obj10 = obj9 - 1;
										if (!flag2)
										{
											if ((nint)obj10 != 1)
											{
												continue;
											}
											PlayerOptionsData configDuringRun = _playerOptions.ConfigDuringRun;
											bool flag3 = configDuringRun._003CSelectedReapers_003Ek__BackingField;
											obj2 = obj;
											if (flag3)
											{
												break;
											}
										}
										else
										{
											PlayerOptionsData configDuringRun2 = _playerOptions.ConfigDuringRun;
											bool flag4 = configDuringRun2._003CSelectedInverse_003Ek__BackingField;
											obj2 = obj;
											if (flag4)
											{
												break;
											}
										}
									}
									else
									{
										PlayerOptionsData configDuringRun3 = _playerOptions.ConfigDuringRun;
										bool flag5 = configDuringRun3._003CSelectedLimitBreak_003Ek__BackingField;
										obj2 = obj;
										if (flag5)
										{
											break;
										}
									}
								}
								else
								{
									PlayerOptionsData configDuringRun4 = _playerOptions.ConfigDuringRun;
									bool flag6 = configDuringRun4._003CSelectedHurry_003Ek__BackingField;
									obj2 = obj;
									if (flag6)
									{
										break;
									}
								}
							}
							else
							{
								PlayerOptionsData configDuringRun5 = _playerOptions.ConfigDuringRun;
								bool flag7 = configDuringRun5._003CSelectedHyper_003Ek__BackingField;
								obj2 = obj;
								if (flag7)
								{
									break;
								}
							}
							return false;
						}
					}
					bool flag8 = obj3 == null;
					num = 0;
					if (!flag8)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ stack_-28_v17+1C]");
						if (obj4 == null)
						{
							return true;
						}
						System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
						num = unchecked((nint)null);
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
		}
	}

	public void AddRecentlyUnlockedAdventureProgress(AchievementData achievementData)
	{
		if (_recentlyUnlockedAdventureProgress != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B120");
		}
	}

	public Sprite GetSpriteForAchievement(AchievementData bad)
	{
		//IL_03ee: Expected O, but got I
		//IL_01ec: Expected O, but got I
		//IL_0403: Expected O, but got I
		//IL_0201: Expected O, but got I
		//IL_0770: Expected O, but got I
		//IL_0606: Expected O, but got I
		//IL_0418: Expected O, but got I
		//IL_0216: Expected O, but got I
		//IL_08b2: Expected O, but got I
		//IL_0785: Expected O, but got I
		//IL_061b: Expected O, but got I
		//IL_0b3f: Expected O, but got I
		//IL_09f2: Expected O, but got I
		//IL_08c7: Expected O, but got I
		//IL_079a: Expected O, but got I
		//IL_0630: Expected O, but got I
		//IL_0dad: Expected I4, but got O
		//IL_0c93: Expected O, but got I
		//IL_0a07: Expected O, but got I
		//IL_08dc: Expected O, but got I
		//IL_0a1c: Expected O, but got I
		//IL_0477: Expected O, but got I
		//IL_0275: Expected O, but got I
		//IL_0de0: Expected I4, but got O
		//IL_0b99: Expected I, but got O
		//IL_0bc3: Expected O, but got I
		//IL_0e13: Expected I4, but got O
		//IL_0cef: Expected O, but got I
		//IL_0cff: Expected O, but got I
		//IL_0e2e: Expected I4, but got O
		//IL_04d3: Expected O, but got I
		//IL_04e3: Expected O, but got I
		//IL_02dd: Expected O, but got I
		//IL_02ed: Expected O, but got I
		//IL_02fd: Expected O, but got I
		//IL_0f33: Expected I4, but got O
		string text3;
		string text4;
		if (bad._003CadventureUnlockData_003Ek__BackingField != null)
		{
			AdventureProgressData adventureProgressData = bad._003CadventureUnlockData_003Ek__BackingField;
			string text = adventureProgressData._003CIconSpriteName_003Ek__BackingField;
			if (adventureProgressData._003CIconSpriteName_003Ek__BackingField != null && text._stringLength > 0)
			{
				string text2 = adventureProgressData._003CIconTextureName_003Ek__BackingField;
				if (adventureProgressData._003CIconTextureName_003Ek__BackingField != null && text2._stringLength > 0)
				{
					text3 = adventureProgressData._003CIconSpriteName_003Ek__BackingField;
					text4 = adventureProgressData._003CIconTextureName_003Ek__BackingField;
					goto IL_00fb;
				}
			}
		}
		string text5 = bad._003CcharacterToUnlock_003Ek__BackingField;
		string text7;
		string text8;
		if (bad._003CcharacterToUnlock_003Ek__BackingField != null && text5._stringLength > 0)
		{
			CharacterType characterType = Enum.Parse<CharacterType>(bad._003CcharacterToUnlock_003Ek__BackingField);
			Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = _dataManager.GetConvertedCharacterData();
			object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)characterType);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rax_v103 (System.Object)+18]");
			if ((nint)0 <= (nint)0)
			{
				goto IL_0f78;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rax_v103 (System.Object)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rsi_v29+20]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rsi_v30+48]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rsi_v30+48]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v753 @ rax_v104+10]");
				if ((nint)0 > (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rsi_v30+40]");
					string text6 = (string)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rsi_v30+40]");
					if ((nint)0 != 0 && text6._stringLength > 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rsi_v30+40]");
						CharacterLoader.LoadCharacterTexture((string)0, characterType, _dataManager);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rsi_v30+48]");
						text7 = (string)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rsi_v30+40]");
						text8 = (string)0;
						goto IL_0302;
					}
				}
			}
		}
		string text9 = bad._003CweaponToUnlock_003Ek__BackingField;
		if (bad._003CweaponToUnlock_003Ek__BackingField != null && text9._stringLength > 0)
		{
			Dictionary<WeaponType, List<WeaponData>> convertedWeapons = _dataManager.GetConvertedWeapons();
			WeaponType key = Enum.Parse<WeaponType>(bad._003CweaponToUnlock_003Ek__BackingField);
			object obj5 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item((System.Int32Enum)key);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rax_v96 (System.Object)+18]");
			if ((nint)0 <= (nint)0)
			{
				goto IL_0f78;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rax_v96 (System.Object)+10]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rax_v97+20]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rax_v98+40]");
			object obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rax_v98+40]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v926 @ rcx_v74+10]");
				if ((nint)0 > (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rax_v98+38]");
					string text10 = (string)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rax_v98+38]");
					if ((nint)0 != 0 && text10._stringLength > 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rax_v98+40]");
						text7 = (string)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rax_v98+38]");
						text8 = (string)0;
						goto IL_0302;
					}
				}
			}
		}
		string text11 = bad._003CstageToUnlock_003Ek__BackingField;
		string text13;
		if (bad._003CstageToUnlock_003Ek__BackingField != null && text11._stringLength > 0)
		{
			string text12 = bad._003ChyperToUnlock_003Ek__BackingField;
			if (bad._003ChyperToUnlock_003Ek__BackingField == null || text12._stringLength <= 0)
			{
				Dictionary<StageType, List<StageData>> convertedStages = _dataManager.GetConvertedStages();
				StageType key2 = Enum.Parse<StageType>(bad._003CstageToUnlock_003Ek__BackingField);
				object obj9 = ((Dictionary<System.Int32Enum, object>)(object)convertedStages).get_Item((System.Int32Enum)key2);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rax_v89 (System.Object)+18]");
				if ((nint)0 <= (nint)0)
				{
					goto IL_0f78;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rax_v89 (System.Object)+10]");
				object obj10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rax_v90+20]");
				object obj11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ rcx_v69+60]");
				text13 = (string)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ rcx_v69+60]");
				if ((nint)0 != 0 && text13._stringLength > 0)
				{
					goto IL_0681;
				}
			}
		}
		string text14 = bad._003ChyperToUnlock_003Ek__BackingField;
		if (bad._003ChyperToUnlock_003Ek__BackingField != null && text14._stringLength > 0)
		{
			Dictionary<StageType, List<StageData>> convertedStages2 = _dataManager.GetConvertedStages();
			StageType key3 = Enum.Parse<StageType>(bad._003ChyperToUnlock_003Ek__BackingField);
			object obj12 = ((Dictionary<System.Int32Enum, object>)(object)convertedStages2).get_Item((System.Int32Enum)key3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rax_v78 (System.Object)+18]");
			if ((nint)0 <= (nint)0)
			{
				goto IL_0f78;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rax_v78 (System.Object)+10]");
			object obj13 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rax_v79+20]");
			object obj14 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rcx_v61+58]");
			text13 = (string)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rcx_v61+58]");
			if ((nint)0 != 0 && text13._stringLength > 0)
			{
				goto IL_0681;
			}
		}
		string text15 = bad._003CpowerUpToUnlock_003Ek__BackingField;
		string text16;
		if (bad._003CpowerUpToUnlock_003Ek__BackingField != null && text15._stringLength > 0)
		{
			Dictionary<PowerUpType, List<PowerUpData>> convertedPowerUpData = _dataManager.GetConvertedPowerUpData();
			PowerUpType key4 = Enum.Parse<PowerUpType>(bad._003CpowerUpToUnlock_003Ek__BackingField);
			object obj15 = ((Dictionary<System.Int32Enum, object>)(object)convertedPowerUpData).get_Item((System.Int32Enum)key4);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rax_v71 (System.Object)+18]");
			if ((nint)0 <= (nint)0)
			{
				goto IL_0f78;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rax_v71 (System.Object)+10]");
			object obj16 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ rax_v72+20]");
			object obj17 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rcx_v56+38]");
			text16 = (string)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rcx_v56+38]");
			if ((nint)0 != 0 && text16._stringLength > 0)
			{
				goto IL_0a68;
			}
		}
		string text17 = bad._003CweaponIcon_003Ek__BackingField;
		if (bad._003CweaponIcon_003Ek__BackingField != null && text17._stringLength > 0)
		{
			Dictionary<WeaponType, List<WeaponData>> convertedWeapons2 = _dataManager.GetConvertedWeapons();
			WeaponType key5 = Enum.Parse<WeaponType>(bad._003CweaponIcon_003Ek__BackingField);
			object obj18 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons2).get_Item((System.Int32Enum)key5);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rax_v64 (System.Object)+18]");
			if ((nint)0 <= (nint)0)
			{
				goto IL_0f78;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rax_v64 (System.Object)+10]");
			object obj19 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rax_v65+20]");
			object obj20 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rcx_v51+40]");
			text16 = (string)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rcx_v51+40]");
			if ((nint)0 != 0 && text16._stringLength > 0)
			{
				goto IL_0a68;
			}
		}
		string text18 = bad._003CarcanaToUnlock_003Ek__BackingField;
		string text19;
		string text20;
		string textureName;
		bool ignoreExtension;
		if (bad._003CarcanaToUnlock_003Ek__BackingField != null && text18._stringLength > 0)
		{
			DataManager dataManager = _dataManager;
			ArcanaType key6 = Enum.Parse<ArcanaType>(bad._003CarcanaToUnlock_003Ek__BackingField);
			object obj21 = ((Dictionary<System.Int32Enum, object>)(object)dataManager._003CAllArcanas_003Ek__BackingField).get_Item((System.Int32Enum)key6);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rax_v58 (System.Object)+40]");
			text19 = (string)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rax_v58 (System.Object)+40]");
			if ((nint)0 != 0 && text19._stringLength > 0)
			{
				nint num = (nint)typeof(SpriteManager);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1947 @ rcx_v45 (Il2CppClass<VampireSurvivors.Graphics.SpriteManager>)+E4]");
				bool flag = (nint)0 != 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rax_v58 (System.Object)+40]");
				text20 = (string)0;
				if (flag)
				{
					goto IL_0a75;
				}
				textureName = "items";
				ignoreExtension = true;
				goto IL_0f82;
			}
		}
		string text21 = bad._003CrelicToUnlock_003Ek__BackingField;
		if (bad._003CrelicToUnlock_003Ek__BackingField != null && text21._stringLength > 0)
		{
			DataManager dataManager2 = _dataManager;
			ItemType key7 = Enum.Parse<ItemType>(bad._003CrelicToUnlock_003Ek__BackingField);
			object obj22 = ((Dictionary<System.Int32Enum, object>)(object)dataManager2._003CAllItems_003Ek__BackingField).get_Item((System.Int32Enum)key7);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rax_v53 (System.Object)+38]");
			string text22 = (string)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rax_v53 (System.Object)+38]");
			if ((nint)0 != 0 && text22._stringLength > 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rax_v53 (System.Object)+30]");
				text8 = (string)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rax_v53 (System.Object)+38]");
				text7 = (string)0;
				goto IL_0302;
			}
		}
		if (bad._003CskinsToUnlock_003Ek__BackingField != null)
		{
			List<SkinToUnlock> list = bad._003CskinsToUnlock_003Ek__BackingField;
			if (list._size > 0)
			{
				List<PowerUpData> list2 = ((Dictionary<PowerUpType, List<PowerUpData>>)(object)list).get_Item(PowerUpType.POWER);
				Dictionary<CharacterType, List<CharacterData>> convertedCharacterData2 = _dataManager.GetConvertedCharacterData();
				if (convertedCharacterData2 != null)
				{
					object obj23 = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData2).get_Item((System.Int32Enum)list2._items);
					if (obj23 != null)
					{
						List<CharacterData> list3 = ((Dictionary<CharacterType, List<CharacterData>>)obj23).get_Item((CharacterType)list2._items);
						if (list3 != null)
						{
							object obj24 = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData2).get_Item((System.Int32Enum)list2._items);
							List<CharacterData> list4 = ((Dictionary<CharacterType, List<CharacterData>>)obj24).get_Item((CharacterType)list2._items);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ rax_v40 (System.Collections.Generic.List`1<VampireSurvivors.Data.PowerUp.PowerUpData>)+14]");
							Skin skinData = ((CharacterData)(object)list4).GetSkinData(SkinType.DEFAULT);
							if (skinData != null)
							{
								string text23 = skinData._003CspriteName_003Ek__BackingField;
								if (skinData._003CspriteName_003Ek__BackingField != null && text23._stringLength > 0)
								{
									string text24 = skinData._003CtextureName_003Ek__BackingField;
									if (skinData._003CtextureName_003Ek__BackingField != null && text24._stringLength > 0)
									{
										CharacterLoader.LoadCharacterTexture(skinData._003CtextureName_003Ek__BackingField, (CharacterType)list2._items, _dataManager);
										text3 = skinData._003CspriteName_003Ek__BackingField;
										text4 = skinData._003CtextureName_003Ek__BackingField;
										goto IL_00fb;
									}
								}
							}
						}
					}
				}
			}
		}
		textureName = "UI";
		ignoreExtension = true;
		text19 = "QuestionMark";
		goto IL_0f82;
		IL_0f78:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		Sprite result = default(Sprite);
		return result;
		IL_0681:
		textureName = "UI";
		ignoreExtension = true;
		text19 = text13;
		goto IL_0f82;
		IL_0a75:
		textureName = "items";
		ignoreExtension = true;
		text19 = text20;
		goto IL_0f82;
		IL_0a68:
		text20 = text16;
		goto IL_0a75;
		IL_0f82:
		return SpriteManager.GetSprite(text19, textureName, ignoreExtension);
		IL_00fb:
		textureName = text4;
		ignoreExtension = true;
		text19 = text3;
		goto IL_0f82;
		IL_0302:
		textureName = text8;
		ignoreExtension = true;
		text19 = text7;
		goto IL_0f82;
	}

	public Sprite GetFrameForSprite(AchievementData bad)
	{
		//IL_00c9: Expected O, but got I4
		//IL_0117: Expected O, but got I4
		//IL_00bb: Expected O, but got I4
		//IL_0165: Expected O, but got I4
		//IL_0109: Expected O, but got I4
		//IL_0157: Expected O, but got I4
		//IL_02e4: Expected O, but got I
		//IL_02f9: Expected O, but got I
		string text = bad._003CweaponToUnlock_003Ek__BackingField;
		bool flag = bad._003CweaponToUnlock_003Ek__BackingField == null;
		Sprite sprite = null;
		if (!flag)
		{
			bool flag2 = text._stringLength <= 0;
			sprite = null;
			if (!flag2)
			{
				Sprite sprite2 = SpriteManager.GetSprite("frameB", "UI");
				sprite = sprite2;
			}
		}
		string text2 = bad._003CcharacterToUnlock_003Ek__BackingField;
		object obj = ((bad._003CcharacterToUnlock_003Ek__BackingField == null || text2._stringLength <= 0) ? ((object)1) : ((object)0));
		string text3 = bad._003CstageToUnlock_003Ek__BackingField;
		bool flag3 = obj == null;
		Sprite sprite3 = null;
		if (!flag3)
		{
			sprite3 = sprite;
		}
		object obj2 = ((bad._003CstageToUnlock_003Ek__BackingField == null || text3._stringLength <= 0) ? ((object)1) : ((object)0));
		bool flag4 = obj2 == null;
		string text4 = bad._003ChyperToUnlock_003Ek__BackingField;
		Sprite sprite4 = null;
		if (!flag4)
		{
			sprite4 = sprite3;
		}
		object obj3 = ((bad._003ChyperToUnlock_003Ek__BackingField == null || text4._stringLength <= 0) ? ((object)1) : ((object)0));
		bool flag5 = obj3 == null;
		string text5 = bad._003CrelicToUnlock_003Ek__BackingField;
		Sprite sprite5 = null;
		if (!flag5)
		{
			sprite5 = sprite4;
		}
		if (bad._003CrelicToUnlock_003Ek__BackingField != null && text5._stringLength > 0)
		{
			sprite5 = SpriteManager.GetSprite("frameF", "UI");
		}
		if (bad._003CgoldPrize_003Ek__BackingField > 0)
		{
			string text6 = bad._003CweaponIcon_003Ek__BackingField;
			if (bad._003CweaponIcon_003Ek__BackingField != null && text6._stringLength > 0)
			{
				sprite5 = null;
			}
		}
		string text7 = bad._003CpowerUpToUnlock_003Ek__BackingField;
		if (bad._003CpowerUpToUnlock_003Ek__BackingField != null && text7._stringLength > 0)
		{
			PowerUpType key = Enum.Parse<PowerUpType>(bad._003CpowerUpToUnlock_003Ek__BackingField);
			Dictionary<PowerUpType, List<PowerUpData>> convertedPowerUpData = _dataManager.GetConvertedPowerUpData();
			object obj4 = ((Dictionary<System.Int32Enum, object>)(object)convertedPowerUpData).get_Item((System.Int32Enum)key);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rax_v32 (System.Object)+18]");
			if ((nint)0 <= (nint)0)
			{
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				Sprite result = default(Sprite);
				return result;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rax_v32 (System.Object)+10]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rax_v33+20]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rcx_v27+4D]");
			sprite5 = (((nint)0 == 0) ? SpriteManager.GetSprite("frameD", "UI") : SpriteManager.GetSprite("frameE", "UI"));
		}
		string text8 = bad._003CarcanaToUnlock_003Ek__BackingField;
		if (bad._003CarcanaToUnlock_003Ek__BackingField != null && text8._stringLength > 0)
		{
			ArcanaType arcanaType = Enum.Parse<ArcanaType>(bad._003CarcanaToUnlock_003Ek__BackingField);
			string spriteName = ((arcanaType <= ArcanaType.T21_BLOODY) ? "frameG" : "frameH");
			sprite5 = SpriteManager.GetSprite(spriteName, "UI");
		}
		bool flag6 = bad._003CskinsToUnlock_003Ek__BackingField != null;
		Sprite result2 = null;
		if (!flag6)
		{
			result2 = sprite5;
		}
		return result2;
	}

	public unsafe string GetUnlockText(AchievementData bad)
	{
		//IL_00c7: Expected O, but got Ref
		//IL_025c: Expected O, but got I
		//IL_0276: Expected O, but got I
		//IL_0e84: Expected O, but got I4
		//IL_09fd: Expected O, but got I
		//IL_0e92: Expected O, but got I4
		//IL_099a: Expected I8, but got I4
		//IL_09a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_09a9: Expected Ref, but got Unknown
		//IL_09b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b7: Expected Ref, but got Unknown
		string text = bad._003CforcedUnlockTips_003Ek__BackingField;
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		string text3;
		string text4;
		string translation7;
		string text11;
		if (bad._003CforcedUnlockTips_003Ek__BackingField != null && text._stringLength > 0)
		{
			bool flag = !bad._003Cachieved_003Ek__BackingField;
			string term = "lang/genericPopup_unlocks";
			if (!flag)
			{
				term = "lang/genericPopup_unlocked";
			}
			string translation = LocalizationManager.GetTranslation(term, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			IntPtr intPtr = default(IntPtr);
			string text2 = ((Enum)(&intPtr)).ToString();
			string term2 = "achievementLang/{" + text2 + "}forcedUnlockTips";
			text3 = LocalizationManager.GetTranslation(term2, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			text4 = translation;
		}
		else
		{
			string text5 = bad._003ChyperToUnlock_003Ek__BackingField;
			if (bad._003ChyperToUnlock_003Ek__BackingField != null && text5._stringLength > 0)
			{
				bool flag2 = !bad._003Cachieved_003Ek__BackingField;
				string term3 = "lang/genericPopup_unlocksHyper";
				if (!flag2)
				{
					term3 = "lang/genericPopup_unlockedHyper";
				}
				string translation2 = LocalizationManager.GetTranslation(term3, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
				StageType stageType = Enum.Parse<StageType>(bad._003ChyperToUnlock_003Ek__BackingField);
				Dictionary<StageType, List<StageData>> convertedStages = _dataManager.GetConvertedStages();
				object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedStages).get_Item((System.Int32Enum)stageType);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v275 @ rax_v167 (System.Object)+18]");
				if ((nint)0 > (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v275 @ rax_v167 (System.Object)+10]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ rax_v168+20]");
					string localizedName = ((StageData)0).GetLocalizedName(stageType);
					string translation3 = LocalizationManager.GetTranslation(localizedName, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
					return translation2.Replace("%0", translation3);
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				CharacterData characterData = null;
				throw new NullReferenceException();
			}
			string text6 = bad._003CstageToUnlock_003Ek__BackingField;
			if (bad._003CstageToUnlock_003Ek__BackingField != null && text6._stringLength > 0)
			{
				bool flag3 = !bad._003Cachieved_003Ek__BackingField;
				string term4 = "lang/genericPopup_unlocks";
				if (!flag3)
				{
					term4 = "lang/genericPopup_unlocked";
				}
				string translation4 = LocalizationManager.GetTranslation(term4, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
				StageType stageType2 = Enum.Parse<StageType>(bad._003CstageToUnlock_003Ek__BackingField);
				StageType stageType3 = Enum.Parse<StageType>((string)(object)typeof(AdventureManager));
				DataManager dataManager = _dataManager;
				Dictionary<System.Int32Enum, object> dictionary;
				if (stageType3 == StageType.FOREST)
				{
					Dictionary<StageType, List<StageData>> convertedStages2 = dataManager.GetConvertedStages();
					dictionary = (Dictionary<System.Int32Enum, object>)(object)convertedStages2;
				}
				else
				{
					if (dataManager._adventureStageData == null)
					{
						Dictionary<StageType, List<StageData>> adventureStageData = DataManager.ConvertStageDataJsonToObjects(dataManager._003CAllStages_003Ek__BackingField);
						dataManager._adventureStageData = adventureStageData;
					}
					dictionary = (Dictionary<System.Int32Enum, object>)(object)dataManager._adventureStageData;
				}
				object obj3 = dictionary.get_Item((System.Int32Enum)stageType2);
				List<StageData> list = ((Dictionary<StageType, List<StageData>>)obj3).get_Item(stageType2);
				string localizedName2 = ((StageData)(object)list).GetLocalizedName(stageType2);
				text3 = LocalizationManager.GetTranslation(localizedName2, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
				text4 = translation4;
			}
			else
			{
				string text7 = bad._003CcharacterToUnlock_003Ek__BackingField;
				if (bad._003CcharacterToUnlock_003Ek__BackingField != null && text7._stringLength > 0)
				{
					bool flag4 = !bad._003Cachieved_003Ek__BackingField;
					string term5 = "lang/genericPopup_unlocks";
					if (!flag4)
					{
						term5 = "lang/genericPopup_unlocked";
					}
					string translation5 = LocalizationManager.GetTranslation(term5, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
					CharacterType characterType = Enum.Parse<CharacterType>(bad._003CcharacterToUnlock_003Ek__BackingField);
					Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = _dataManager.GetConvertedCharacterData();
					object obj4 = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)characterType);
					List<CharacterData> list2 = ((Dictionary<CharacterType, List<CharacterData>>)obj4).get_Item(characterType);
					text3 = ((CharacterData)(object)list2).GetCharFirstName(characterType);
					if (!bad._003Cachieved_003Ek__BackingField && bad._003Cmistery_003Ek__BackingField)
					{
						text3 = " ???";
					}
					text4 = translation5;
				}
				else
				{
					string text8 = bad._003CweaponToUnlock_003Ek__BackingField;
					if (bad._003CweaponToUnlock_003Ek__BackingField != null && text8._stringLength > 0)
					{
						bool flag5 = !bad._003Cachieved_003Ek__BackingField;
						string term6 = "lang/genericPopup_unlocks";
						if (!flag5)
						{
							term6 = "lang/genericPopup_unlocked";
						}
						string translation6 = LocalizationManager.GetTranslation(term6, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
						WeaponType weaponType = Enum.Parse<WeaponType>(bad._003CweaponToUnlock_003Ek__BackingField);
						Dictionary<WeaponType, List<WeaponData>> convertedWeapons = _dataManager.GetConvertedWeapons();
						object obj5 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item((System.Int32Enum)weaponType);
						List<WeaponData> list3 = ((Dictionary<WeaponType, List<WeaponData>>)obj5).get_Item(WeaponType.VOID);
						string localizedNameTerm = ((WeaponData)(object)list3).GetLocalizedNameTerm(weaponType);
						text3 = LocalizationManager.GetTranslation(localizedNameTerm, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
						text4 = translation6;
					}
					else
					{
						string text9 = bad._003CrelicToUnlock_003Ek__BackingField;
						if (bad._003CrelicToUnlock_003Ek__BackingField != null && text9._stringLength > 0)
						{
							bool flag6 = !bad._003Cachieved_003Ek__BackingField;
							string term7 = "lang/genericPopup_unlocks";
							if (!flag6)
							{
								term7 = "lang/genericPopup_unlocked";
							}
							translation7 = LocalizationManager.GetTranslation(term7, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
							ItemType itemType = Enum.Parse<ItemType>(bad._003CrelicToUnlock_003Ek__BackingField);
							DataManager dataManager2 = _dataManager;
							object obj6 = ((Dictionary<System.Int32Enum, object>)(object)dataManager2._003CAllItems_003Ek__BackingField).get_Item((System.Int32Enum)itemType);
							string localPrefix = ((ItemData)obj6).GetLocalPrefix(itemType);
							string term8 = localPrefix + "achievementTips";
							string translation8 = LocalizationManager.GetTranslation(term8, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
							string text10 = translation8.Replace("\\n", "<br>");
							object obj7 = "";
							if ((object)text10 == "")
							{
								goto IL_09ed;
							}
							bool flag7 = text10 == null;
							text11 = text10;
							if (!flag7)
							{
								bool flag8 = "" == null;
								text11 = text10;
								if (!flag8)
								{
									int stringLength = text10._stringLength;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2651 @ rdx_v48+10]");
									bool flag9 = (nint)stringLength != 0;
									text11 = text10;
									if (!flag9)
									{
										ulong length = (ulong)(text10._stringLength + text10._stringLength);
										bool flag10 = System.SpanHelpers.SequenceEqual(ref *(byte*)(text10 + 20), ref *(byte*)("" + 20), length);
										bool flag11 = !flag10;
										text11 = text10;
										if (!flag11)
										{
											goto IL_09ed;
										}
									}
								}
							}
							goto IL_11d3;
						}
						string text12 = bad._003CarcanaToUnlock_003Ek__BackingField;
						if (bad._003CarcanaToUnlock_003Ek__BackingField != null && text12._stringLength > 0)
						{
							bool flag12 = !bad._003Cachieved_003Ek__BackingField;
							string term9 = "lang/genericPopup_unlocks";
							if (!flag12)
							{
								term9 = "lang/genericPopup_unlocked";
							}
							string translation9 = LocalizationManager.GetTranslation(term9, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
							ArcanaType arcanaType = Enum.Parse<ArcanaType>(bad._003CarcanaToUnlock_003Ek__BackingField);
							DataManager dataManager3 = _dataManager;
							object obj8 = ((Dictionary<System.Int32Enum, object>)(object)dataManager3._003CAllArcanas_003Ek__BackingField).get_Item((System.Int32Enum)arcanaType);
							string localizedNameTerm2 = ((ArcanaData)obj8).GetLocalizedNameTerm(arcanaType);
							text3 = LocalizationManager.GetTranslation(localizedNameTerm2, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
							text4 = translation9;
						}
						else
						{
							string text13 = bad._003CpowerUpToUnlock_003Ek__BackingField;
							if (bad._003CpowerUpToUnlock_003Ek__BackingField == null || text13._stringLength <= 0)
							{
								if (bad._003CgoldPrize_003Ek__BackingField > 0)
								{
									string text14 = bad._003CweaponIcon_003Ek__BackingField;
									if ((bad._003CweaponIcon_003Ek__BackingField != null && text14._stringLength > 0) || bad._003CgoldPrize_003Ek__BackingField > 0)
									{
										bool flag13 = !bad._003Cachieved_003Ek__BackingField;
										string term10 = "lang/genericPopup_obtainsCoin";
										if (!flag13)
										{
											term10 = "lang/genericPopup_obtainedCoin";
										}
										string translation10 = LocalizationManager.GetTranslation(term10, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
										int num = default(int);
										string newValue = num.ToString();
										return translation10.Replace("%0", newValue);
									}
								}
								if (bad._003CskinsToUnlock_003Ek__BackingField != null)
								{
									List<SkinToUnlock> list4 = bad._003CskinsToUnlock_003Ek__BackingField;
									if (list4._size > 0)
									{
										List<string> list5 = new List<string>();
										object obj9 = 0;
										List<SkinToUnlock>.Enumerator enumerator = default(List<SkinToUnlock>.Enumerator);
										if (enumerator.MoveNext())
										{
											object obj10 = 0;
											if (_dataManager != null)
											{
												Dictionary<CharacterType, List<CharacterData>> convertedCharacterData2 = _dataManager.GetConvertedCharacterData();
												if (convertedCharacterData2 != null)
												{
													throw new NullReferenceException();
												}
												throw new NullReferenceException();
											}
											throw new NullReferenceException();
										}
										if (list5._size > 0)
										{
											bool flag14 = !bad._003Cachieved_003Ek__BackingField;
											string term11 = "lang/genericPopup_unlocks";
											if (!flag14)
											{
												term11 = "lang/genericPopup_unlocked";
											}
											string translation11 = LocalizationManager.GetTranslation(term11, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
											bool flag15 = obj9 == null;
											string term12 = "lang/new_skins_for";
											if (!flag15)
											{
												term12 = "lang/new_starting_weapon_for";
											}
											string translation12 = LocalizationManager.GetTranslation(term12, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
											string newValue2 = string.Join(", ", list5);
											text3 = translation12.Replace("%0", newValue2);
											text4 = translation11;
											goto IL_1144;
										}
									}
								}
								return "";
							}
							bool flag16 = !bad._003Cachieved_003Ek__BackingField;
							string term13 = "lang/genericPopup_unlocks";
							if (!flag16)
							{
								term13 = "lang/genericPopup_unlocked";
							}
							string translation13 = LocalizationManager.GetTranslation(term13, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
							PowerUpType powerUpType = Enum.Parse<PowerUpType>(bad._003CpowerUpToUnlock_003Ek__BackingField);
							Dictionary<PowerUpType, List<PowerUpData>> convertedPowerUpData = _dataManager.GetConvertedPowerUpData();
							object obj11 = ((Dictionary<System.Int32Enum, object>)(object)convertedPowerUpData).get_Item((System.Int32Enum)powerUpType);
							List<PowerUpData> list6 = ((Dictionary<PowerUpType, List<PowerUpData>>)obj11).get_Item(powerUpType);
							string localizedName3 = ((PowerUpData)(object)list6).GetLocalizedName(powerUpType);
							text3 = LocalizationManager.GetTranslation(localizedName3, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
							text4 = translation13;
						}
					}
				}
			}
		}
		goto IL_1144;
		IL_1144:
		string text15 = text3;
		goto IL_1257;
		IL_1257:
		return text4 + " " + text15;
		IL_09ed:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v292 @ rax_v91 (System.Object)+20]");
		text11 = (string)0;
		goto IL_11d3;
		IL_11d3:
		if (!bad._003Cachieved_003Ek__BackingField && bad._003Cmistery_003Ek__BackingField)
		{
			text11 = " ???";
		}
		text15 = text11;
		text4 = translation7;
		goto IL_1257;
	}

	public bool CheckForCoffinOpen(CharacterType characterType)
	{
		//IL_0115: Expected I4, but got O
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Expected I4, but got Unknown
		if (_playerOptions != null)
		{
			PlayerOptionsData config = _playerOptions.Config;
			if (config != null && config._003CUnlockedCharacters_003Ek__BackingField != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
				if (_playerOptions != null)
				{
					PlayerOptionsData config2 = _playerOptions.Config;
					if (config2 != null && config2._003COpenedCoffins_003Ek__BackingField != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
						object obj = default(object);
						bool flag = default(bool);
						bool result = (byte)((obj | flag) ? 1 : 0) != 0;
						if (!AdventureManager._003CIsInAdventureMode_003Ek__BackingField)
						{
							return result;
						}
						return flag;
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public int GetPickUpCount(ItemType t)
	{
		//IL_0125: Expected I4, but got O
		if (_playerOptions != null)
		{
			PlayerOptionsData config = _playerOptions.Config;
			if (config != null && config._003CPickupCount_003Ek__BackingField != null)
			{
				int num = config._003CPickupCount_003Ek__BackingField.FindEntry(t);
				if (num < 0)
				{
					return 0;
				}
				if (_playerOptions != null)
				{
					PlayerOptionsData config2 = _playerOptions.Config;
					if (config2 != null && config2._003CPickupCount_003Ek__BackingField != null)
					{
						return config2._003CPickupCount_003Ek__BackingField.get_Item(t);
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	public unsafe int GetPlayerWeaponLevel(VampireSurvivors.Objects.Characters.CharacterController character, WeaponType t, bool checkRemovedEquipment = true, bool checkHiddenEquipment = false)
	{
		//IL_0466: Expected O, but got Ref
		//IL_0064: Expected O, but got I4
		//IL_006c: Expected O, but got Ref
		//IL_00ce: Expected O, but got Ref
		//IL_04c5: Expected O, but got Ref
		//IL_00ea: Expected O, but got I4
		//IL_00f2: Expected O, but got Ref
		//IL_03c3: Expected I4, but got I8
		//IL_0161: Expected O, but got Ref
		//IL_018b: Expected O, but got Ref
		//IL_053a: Expected O, but got Ref
		//IL_01a7: Expected O, but got I4
		//IL_01af: Expected O, but got Ref
		//IL_05fa: Expected O, but got Ref
		//IL_02e2: Expected O, but got I4
		//IL_02ea: Expected O, but got Ref
		//IL_0211: Expected O, but got Ref
		//IL_034c: Expected O, but got Ref
		//IL_027e: Expected O, but got Ref
		//IL_022d: Expected O, but got I4
		//IL_0235: Expected O, but got Ref
		//IL_0368: Expected O, but got I4
		//IL_0370: Expected O, but got Ref
		List<Equipment>.Enumerator enumerator2;
		if ((object)character != null)
		{
			CharacterWeaponsManager weaponsManager = character._weaponsManager;
			if ((object)character._weaponsManager != null && ((EquipmentManager)weaponsManager)._003CActiveEquipment_003Ek__BackingField != null)
			{
				List<Equipment>.Enumerator enumerator = default(List<Equipment>.Enumerator);
				if (enumerator.MoveNext())
				{
					object obj = 0;
					enumerator2 = (List<Equipment>.Enumerator)(&enumerator);
					throw new NullReferenceException();
				}
				CharacterAccessoriesManager accessoriesManager = character._accessoriesManager;
				bool flag = (object)character._accessoriesManager == null;
				AchievementManager achievementManager = (AchievementManager)(&enumerator);
				if (!flag)
				{
					bool flag2 = ((EquipmentManager)accessoriesManager)._003CActiveEquipment_003Ek__BackingField == null;
					achievementManager = (AchievementManager)(&enumerator);
					if (!flag2)
					{
						List<Equipment>.Enumerator enumerator3 = default(List<Equipment>.Enumerator);
						if (enumerator3.MoveNext())
						{
							object obj2 = 0;
							List<Equipment>.Enumerator enumerator4 = (List<Equipment>.Enumerator)(&enumerator3);
							throw new NullReferenceException();
						}
						bool flag3 = !checkRemovedEquipment;
						achievementManager = (AchievementManager)(&enumerator3);
						if (flag3)
						{
							goto IL_057e;
						}
						CharacterWeaponsManager weaponsManager2 = character._weaponsManager;
						bool flag4 = (object)character._weaponsManager == null;
						achievementManager = (AchievementManager)(&enumerator3);
						if (!flag4)
						{
							bool flag5 = ((EquipmentManager)weaponsManager2)._003CRemovedEquipment_003Ek__BackingField == null;
							achievementManager = (AchievementManager)(&enumerator3);
							if (!flag5)
							{
								List<Equipment>.Enumerator enumerator5 = default(List<Equipment>.Enumerator);
								if (enumerator5.MoveNext())
								{
									object obj3 = 0;
									List<Equipment>.Enumerator enumerator6 = (List<Equipment>.Enumerator)(&enumerator5);
									throw new NullReferenceException();
								}
								CharacterAccessoriesManager accessoriesManager2 = character._accessoriesManager;
								bool flag6 = (object)character._accessoriesManager == null;
								achievementManager = (AchievementManager)(&enumerator5);
								if (!flag6)
								{
									bool flag7 = ((EquipmentManager)accessoriesManager2)._003CRemovedEquipment_003Ek__BackingField == null;
									achievementManager = (AchievementManager)(&enumerator5);
									if (!flag7)
									{
										List<Equipment>.Enumerator enumerator7 = default(List<Equipment>.Enumerator);
										if (enumerator7.MoveNext())
										{
											object obj4 = 0;
											List<Equipment>.Enumerator enumerator8 = (List<Equipment>.Enumerator)(&enumerator7);
											throw new NullReferenceException();
										}
										achievementManager = (AchievementManager)(&enumerator7);
										goto IL_057e;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_03c8;
		IL_03b6:
		return -1;
		IL_03c8:
		enumerator2 = (List<Equipment>.Enumerator)this;
		throw new NullReferenceException();
		IL_057e:
		object obj5 = default(object);
		if (obj5 == null)
		{
			goto IL_03b6;
		}
		CharacterWeaponsManager weaponsManager3 = character._weaponsManager;
		if ((object)character._weaponsManager != null && ((EquipmentManager)weaponsManager3)._003CHiddenEquipment_003Ek__BackingField != null)
		{
			List<Equipment>.Enumerator enumerator9 = default(List<Equipment>.Enumerator);
			if (enumerator9.MoveNext())
			{
				object obj6 = 0;
				List<Equipment>.Enumerator enumerator10 = (List<Equipment>.Enumerator)(&enumerator9);
				throw new NullReferenceException();
			}
			CharacterAccessoriesManager accessoriesManager3 = character._accessoriesManager;
			bool flag8 = (object)character._accessoriesManager == null;
			AchievementManager achievementManager = (AchievementManager)(&enumerator9);
			if (!flag8)
			{
				bool flag9 = ((EquipmentManager)accessoriesManager3)._003CHiddenEquipment_003Ek__BackingField == null;
				achievementManager = (AchievementManager)(&enumerator9);
				if (!flag9)
				{
					List<Equipment>.Enumerator enumerator11 = default(List<Equipment>.Enumerator);
					if (enumerator11.MoveNext())
					{
						object obj7 = 0;
						List<Equipment>.Enumerator enumerator12 = (List<Equipment>.Enumerator)(&enumerator11);
						throw new NullReferenceException();
					}
					goto IL_03b6;
				}
			}
		}
		goto IL_03c8;
	}

	public unsafe void ApplyPlatformAchievementsRetroactively()
	{
		//IL_007e: Expected O, but got Ref
		//IL_0164: Expected O, but got I4
		//IL_0111: Expected O, but got I
		//IL_011a: Expected O, but got I4
		//IL_01dd: Expected O, but got I
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01eb: Expected O, but got Unknown
		//IL_0181: Expected O, but got I
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Expected O, but got Unknown
		//IL_018e: Expected I, but got O
		PlayerOptionsData config = _playerOptions.Config;
		if (!config._003CSaveSyncPlatformAchievements_003Ek__BackingField)
		{
			return;
		}
		PlayerOptionsData config2 = _playerOptions.Config;
		IEnumerable<AchievementType> enumerable = Enumerable.Except(config2._003CAchievements_003Ek__BackingField, AchievementsUnlockedOnPlatform);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj2 = default(object);
		object obj = (object)(&obj2);
		IPlatformAchievementsManager platformAchievementsManager = null;
		object obj3 = default(object);
		object obj13 = default(object);
		IPlatformAchievementsManager platformAchievementsManager3 = default(IPlatformAchievementsManager);
		AchievementType id = default(AchievementType);
		while (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			object obj5;
			object obj12;
			if (obj3 != null)
			{
				bool flag = obj2 == null;
				platformAchievementsManager = null;
				if (!flag)
				{
					object obj4 = obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v371 @ r10_v6+12E]");
					if ((nint)0 >= (nint)0)
					{
						goto IL_0151;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v371 @ r10_v6+B0]");
					obj5 = 0;
					object obj6 = 0;
					while (true)
					{
						object obj7 = obj6 + obj6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v386 @ r8_v11+v409 @ rax_v49*8]");
						if (0 == (nint)typeof(IEnumerator<AchievementType>))
						{
							break;
						}
						obj6++;
						object obj8 = obj6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v371 @ r10_v6+12E]");
						if ((nint)obj8 < 0)
						{
							continue;
						}
						goto IL_0151;
					}
					object obj9 = obj6 + obj6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v386 @ r8_v11+8+v465 @ rcx_v36*8]");
					object obj10 = (nint)0 << 4;
					object obj11 = obj10 + 312;
					obj12 = obj11 + obj4;
					goto IL_02dd;
				}
				throw new NullReferenceException();
			}
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
			}
			return;
			IL_0151:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
			obj5 = 0;
			obj12 = obj13;
			goto IL_02dd;
			IL_02dd:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v470 @ rdx_v14] (should have been resolved before IL gen)");
			IPlatformAchievementsManager sInstance = (IPlatformAchievementsManager)SystemPlatform.sInstance;
			if (SystemPlatform.sInstance != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v505 @ rcx_v19 (VampireSurvivors.IPlatformAchievementsManager)+10]");
				IPlatformAchievementsManager platformAchievementsManager2 = (IPlatformAchievementsManager)0;
				nint num = (nint)platformAchievementsManager2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v541 @ rdx_v18 (Il2CppClass<VampireSurvivors.IPlatformAchievementsManager>)+1C8] (should have been resolved before IL gen)");
				platformAchievementsManager3.ReportProgressAsync(id);
				continue;
			}
			throw new NullReferenceException();
		}
		throw new NullReferenceException();
	}

	public int CountKilledEnemiesAndVariants(EnemyType enemyType)
	{
		//IL_0028: Expected O, but got I
		//IL_0081: Expected O, but got I
		//IL_064e: Expected I4, but got O
		//IL_0187: Expected O, but got I
		//IL_01c4: Expected O, but got I
		//IL_03c0: Expected O, but got I
		//IL_060b: Expected O, but got I4
		//IL_03ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d3: Expected O, but got Unknown
		//IL_021e: Expected O, but got I
		//IL_0529: Expected O, but got I
		//IL_053b: Expected O, but got I4
		//IL_02a9: Expected O, but got I
		//IL_0590: Expected I, but got O
		//IL_02b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bc: Expected O, but got Unknown
		//IL_0347: Expected O, but got I
		List<EnemyType> list = new List<EnemyType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rax_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rax_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rax_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rcx_v27+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)enemyType);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rax_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rax_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rcx_v27+18]");
			if (num2 >= 0)
			{
				goto IL_0640;
			}
		}
		Dictionary<EnemyType, List<EnemyData>> convertedEnemyData = _dataManager.GetConvertedEnemyData();
		bool flag = ((Dictionary<System.Int32Enum, object>)(object)convertedEnemyData).TryGetValue((System.Int32Enum)enemyType, out object value);
		bool flag2 = !flag;
		int num3 = 0;
		object obj6 = default(object);
		object obj8 = default(object);
		if (!flag2)
		{
			if (value != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ stack_20_v22 (System.Object)+18]");
				if ((nint)0 > (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ stack_20_v22 (System.Object)+18]");
					if ((nint)0 <= (nint)0)
					{
						System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
						throw new IndexOutOfRangeException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ stack_20_v22 (System.Object)+10]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rcx_v52+18]");
					if ((nint)0 <= (nint)0)
					{
						goto IL_0640;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rcx_v52+20]");
					List<EnemyType> list2 = (List<EnemyType>)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rcx_v52+20]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v586 @ rcx_v55 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+150]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v586 @ rcx_v55 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+150]");
							object obj4 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v841 @ rax_v88+18]");
							if ((nint)0 > (nint)0)
							{
								object obj5 = default(object);
								object obj11 = default(object);
								while (true)
								{
									if (obj5 != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ stack_-88_v26+1C]");
										if (obj6 == null)
										{
											object obj7 = obj8;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ stack_-88_v26+18]");
											if ((nint)obj7 < 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ stack_-88_v26+10]");
												object obj9 = 0;
												object obj10 = obj8 + 1;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AF20");
												bool flag3 = obj11 != null;
												obj8 = obj10;
												if (!flag3)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AF90");
													obj8 = obj10;
												}
												continue;
											}
											break;
										}
										break;
									}
									throw new NullReferenceException();
								}
								bool flag4 = obj5 == null;
								nint num4 = 0;
								if (!flag4)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ stack_-88_v26+1C]");
									if (obj6 == null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ stack_-88_v26+18]");
										object obj12 = (nint)0 + (nint)1;
										obj8 = obj12;
										goto IL_0354;
									}
									System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
									num4 = unchecked((nint)null);
								}
								throw new NullReferenceException();
							}
						}
					}
				}
			}
			goto IL_0354;
		}
		goto IL_064e;
		IL_0640:
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		return (int)ex;
		IL_0354:
		num3 = 0;
		object obj14 = default(object);
		object obj13;
		while (true)
		{
			obj13 = obj14;
			while (true)
			{
				PlayerOptionsData playerOptionsData;
				if (obj13 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1225 @ rcx_v40+1C]");
					if (obj6 != null)
					{
						break;
					}
					object obj15 = obj8;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1225 @ rcx_v40+18]");
					if ((nint)obj15 >= 0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1225 @ rcx_v40+10]");
					object obj16 = 0;
					obj8++;
					PlayerOptions playerOptions = _playerOptions;
					if (playerOptions._onlineClientWithRunDataConfig == null)
					{
						if (playerOptions._hostGameConfig == null)
						{
							if (playerOptions._currentAdventureSaveData != null)
							{
								playerOptionsData = playerOptions._currentAdventureSaveData;
								if ((object)playerOptionsData._003CSelectedAdventureType_003Ek__BackingField != null)
								{
									goto IL_0496;
								}
							}
							playerOptionsData = playerOptions._mainGameConfig;
						}
						else
						{
							playerOptionsData = playerOptions._hostGameConfig;
						}
					}
					else
					{
						playerOptionsData = playerOptions._onlineClientWithRunDataConfig;
					}
					goto IL_0496;
				}
				throw new NullReferenceException();
				IL_0496:
				if (playerOptionsData._003CKillCount_003Ek__BackingField == null)
				{
					continue;
				}
				goto IL_04b8;
			}
			break;
			IL_04b8:
			PlayerOptionsData config = _playerOptions.Config;
			Dictionary<EnemyType, int> dictionary = config._003CKillCount_003Ek__BackingField;
			Dictionary<EnemyType, int> dictionary2 = config._003CKillCount_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v661 @ rax_v68+20+v172 @ stack_-80_v26*4]");
			int num5 = dictionary2.FindEntry(EnemyType.BAT1);
			if (num5 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v804 @ rbx_v21 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.EnemyType, System.Int32>)+18]");
				object obj17 = 0;
				object obj18 = num5 + num5;
				int num6 = num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v808 @ rax_v74+2C+v1150 @ rcx_v45*8]");
				num3 = (int)((nint)num6 + (nint)0);
			}
		}
		if (obj13 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1225 @ rcx_v40+1C]");
			if (obj6 == null)
			{
				goto IL_064e;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			obj13 = 0;
		}
		throw new NullReferenceException();
		IL_064e:
		return num3;
	}

	public bool CheckRequiredCharacterUnlocked(AchievementType achievementType)
	{
		//IL_00f7: Expected I4, but got O
		if (_Achievements != null)
		{
			object obj = ((Dictionary<System.Int32Enum, object>)(object)_Achievements).get_Item((System.Int32Enum)achievementType);
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v4 (System.Object)+94]");
				if ((nint)0 == 0)
				{
					return true;
				}
				PlayerOptions playerOptions = _playerOptions;
				if (_playerOptions != null)
				{
					PlayerOptionsData mainGameConfig = playerOptions._mainGameConfig;
					if (playerOptions._mainGameConfig != null && mainGameConfig._003CUnlockedCharacters_003Ek__BackingField != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
						bool result = default(bool);
						return result;
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public AchievementManager()
	{
		List<AchievementType> achievementsUnlockedOnPlatform = new List<AchievementType>();
		AchievementsUnlockedOnPlatform = achievementsUnlockedOnPlatform;
		List<AchievementData> recentlyUnlocked = new List<AchievementData>();
		_recentlyUnlocked = recentlyUnlocked;
		List<AchievementData> recentlyUnlockedAdventureProgress = new List<AchievementData>();
		_recentlyUnlockedAdventureProgress = recentlyUnlockedAdventureProgress;
		List<SecretType> newSecrets = new List<SecretType>();
		_newSecrets = newSecrets;
		List<VampireSurvivors.Objects.Characters.CharacterController> characters = new List<VampireSurvivors.Objects.Characters.CharacterController>();
		_Characters = characters;
		List<AchievementType> achivementsToUnlock = new List<AchievementType>();
		_AchivementsToUnlock = achivementsToUnlock;
		List<ICustomAchievements> customAchievementHandellers = new List<ICustomAchievements>();
		_CustomAchievementHandellers = customAchievementHandellers;
		allowUnlocking = true;
	}
}
