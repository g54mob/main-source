using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Achievements;
using VampireSurvivors.App.Data.Adventures;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using Zenject;

namespace VampireSurvivors.App.Scripts.Framework.Adventures;

public class AdventureProgressManager : IInitializable, IDisposable
{
	private DataManager _dataManager;

	private AdventureManager _adventureManager;

	private PlayerOptions _playerOptions;

	private AchievementManager _achievementManager;

	private Dictionary<AdventureAchievementType, AchievementData> _003CAchieved_003Ek__BackingField;

	public Dictionary<AdventureAchievementType, AchievementData> Achieved
	{
		get
		{
			return _003CAchieved_003Ek__BackingField;
		}
		set
		{
			_003CAchieved_003Ek__BackingField = value;
		}
	}

	public void Initialize()
	{
	}

	public void Dispose()
	{
	}

	public void RunChecks(VampireSurvivors.Objects.Characters.CharacterController currentCharacter, AchievementManager achievementManager, Dictionary<AdventureAchievementType, AchievementData> achieved, bool forceUnlockAll = false)
	{
		//IL_00cc: Expected I4, but got O
		_achievementManager = achievementManager;
		object obj = default(object);
		if (!AdventureManager._003CIsInAdventureMode_003Ek__BackingField && obj == null)
		{
			return;
		}
		PlayerOptionsData config = _playerOptions.Config;
		if ((object)config._003CSelectedAdventureType_003Ek__BackingField != null)
		{
			PlayerOptionsData config2 = _playerOptions.Config;
			if ((object)config2._003CSelectedAdventureType_003Ek__BackingField != null)
			{
				AdventureType adventureType = (AdventureType)((object?)config2._003CSelectedAdventureType_003Ek__BackingField >> 32);
				bool forceUnlockAll2 = default(bool);
				RunProgressDataChecks(currentCharacter, adventureType, achieved, forceUnlockAll2);
			}
			else
			{
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
			}
		}
		else
		{
			Debug.LogError("Cannot process progress data checks as Config.SelectedAdventureType is NULL");
		}
	}

	public unsafe void RunProgressDataChecks(VampireSurvivors.Objects.Characters.CharacterController currentCharacter, AdventureType adventureType, Dictionary<AdventureAchievementType, AchievementData> achieved, bool forceUnlockAll = false)
	{
		//IL_004d: Expected O, but got I
		//IL_008b: Expected O, but got I
		//IL_0206: Expected O, but got Ref
		//IL_03ea: Expected O, but got Ref
		bool flag = _playerOptions == null;
		Dictionary<System.Int32Enum, object> playerOptions = (Dictionary<System.Int32Enum, object>)(object)_playerOptions;
		PlayerOptionsData config;
		object value;
		if (!flag)
		{
			config = _playerOptions.Config;
			playerOptions = (Dictionary<System.Int32Enum, object>)(object)_dataManager;
			if (_dataManager != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v650 @ rcx_v4 (System.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>)+1B8]");
				playerOptions = (Dictionary<System.Int32Enum, object>)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v650 @ rcx_v4 (System.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>)+1B8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v650 @ rcx_v4 (System.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>)+1B8]");
					if (!((Dictionary<System.Int32Enum, object>)0).TryGetValue((System.Int32Enum)adventureType, out value))
					{
						return;
					}
					object obj = default(object);
					if (obj == null)
					{
						if ((object)currentCharacter != null)
						{
							bool flag2 = ((UnityEngine.Object)currentCharacter).m_CachedPtr != (IntPtr)0;
							playerOptions = (Dictionary<System.Int32Enum, object>)(object)typeof(UnityEngine.Object);
							if (flag2)
							{
								goto IL_0124;
							}
						}
						Debug.LogError("CurrentCharacter cannot be null when performing progress data checks");
						return;
					}
					goto IL_0124;
				}
			}
		}
		goto IL_0460;
		IL_0124:
		AdventureManager adventureManager = _adventureManager;
		if (_adventureManager != null)
		{
			bool flag3 = _adventureManager.IsAdventureCompleted(adventureManager.CurrentAdventure);
			if (config != null)
			{
				bool flag4 = config._003CAdventureCompletionCount_003Ek__BackingField < 1;
				bool flag5 = flag3;
				if (!flag4)
				{
					flag5 = true;
				}
				if (value != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ stack_-80_v8 (System.Object)+40]");
					System.Collections.Generic.InsertionBehavior insertionBehavior = System.Collections.Generic.InsertionBehavior.None;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ stack_-80_v8 (System.Object)+40]");
					if ((nint)0 != 0)
					{
						VampireSurvivors.Objects.Characters.CharacterController characterController = null;
						List<AchievementData>.Enumerator enumerator = default(List<AchievementData>.Enumerator);
						if (enumerator.MoveNext())
						{
							AchievementData achievementData = null;
							playerOptions = (Dictionary<System.Int32Enum, object>)(&enumerator);
							throw new NullReferenceException();
						}
						if (flag5)
						{
							return;
						}
						if (_adventureManager != null)
						{
							if (!_adventureManager.IsAdventureCompleted(adventureType))
							{
								return;
							}
							if (_adventureManager != null)
							{
								AdventureType adventureType2 = default(AdventureType);
								object arg = adventureType2;
								System.ParamsArray paramsArray = new System.ParamsArray(arg);
								System.ParamsArray paramsArray2 = default(System.ParamsArray);
								string message = string.FormatHelper((IFormatProvider)null, "Awarding AdventureStar for completing the {0} Adventure!", (System.ParamsArray)(&paramsArray2));
								Debug.Log(message);
								PlayerOptions playerOptions2 = _playerOptions;
								if (_playerOptions != null)
								{
									PlayerOptionsData mainGameConfig = playerOptions2._mainGameConfig;
									if (playerOptions2._mainGameConfig != null)
									{
										float num = mainGameConfig._003CAdventureStars_003Ek__BackingField + 1f;
										mainGameConfig._003CAdventureStars_003Ek__BackingField = num;
										PlayerOptions.OnValueChanged adventureStarsUpdated = PlayerOptions.AdventureStarsUpdated;
										if (PlayerOptions.AdventureStarsUpdated != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1114.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
										}
										_playerOptions.Save();
										return;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0460;
		IL_0460:
		throw new NullReferenceException();
	}

	public void UnlockAll(Dictionary<AdventureAchievementType, AchievementData> achieved)
	{
		PlayerOptionsData config = _playerOptions.Config;
		if ((object)config._003CSelectedAdventureType_003Ek__BackingField != null)
		{
			PlayerOptionsData config2 = _playerOptions.Config;
			DataManager dataManager = _dataManager;
			System.Int32Enum key = default(System.Int32Enum);
			if (((Dictionary<System.Int32Enum, object>)(object)dataManager._003CAllAdventures_003Ek__BackingField).TryGetValue(key, out object value))
			{
				Dictionary<AdventureAchievementType, AchievementData>.Enumerator enumerator = default(Dictionary<AdventureAchievementType, AchievementData>.Enumerator);
				AchievementData achievementData = default(AchievementData);
				PlayerOptionsData config3 = default(PlayerOptionsData);
				while (enumerator.MoveNext())
				{
					Unlock(AdventureAchievementType.MS001_ACH001, achievementData, (AdventureData)value, config3);
				}
			}
			return;
		}
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		throw new NullReferenceException();
	}

	private bool UnlockRequirementsMet(AchievementData achievementData, VampireSurvivors.Objects.Characters.CharacterController currentCharacter)
	{
		//IL_00f1: Expected I4, but got O
		//IL_0112: Expected O, but got I4
		//IL_0ac5: Expected I4, but got O
		//IL_09de: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e3: Expected O, but got Unknown
		//IL_09f0: Invalid comparison between F4 and O
		//IL_04b9: Expected I4, but got O
		//IL_0baa: Expected I4, but got O
		//IL_0614: Expected I4, but got O
		//IL_04de: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e3: Expected O, but got Unknown
		//IL_04f0: Invalid comparison between F4 and O
		//IL_0cb4: Expected I4, but got O
		//IL_0bcf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bd4: Expected O, but got Unknown
		//IL_0be1: Invalid comparison between F4 and O
		//IL_0a17: Expected I4, but got O
		//IL_079d: Expected I4, but got O
		//IL_0f36: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f3b: Expected O, but got Unknown
		//IL_0f48: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f4d: Expected I4, but got Unknown
		//IL_0f5a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f5f: Expected I4, but got Unknown
		//IL_0919: Expected I4, but got O
		//IL_0cd5: Expected O, but got I4
		//IL_123f: Expected O, but got I
		//IL_017a: Expected O, but got I
		//IL_082a: Expected I4, but got O
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Expected O, but got Unknown
		//IL_12c3: Expected O, but got I
		//IL_0d3d: Expected O, but got I
		//IL_0d4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d50: Expected O, but got Unknown
		//IL_02fa: Expected I4, but got O
		//IL_033d: Expected I4, but got O
		//IL_0358: Expected O, but got I4
		//IL_0260: Expected O, but got I
		//IL_0272: Expected O, but got I4
		//IL_0282: Unknown result type (might be due to invalid IL or missing references)
		//IL_0287: Expected O, but got Unknown
		//IL_0e23: Expected O, but got I
		//IL_0e35: Expected O, but got I4
		//IL_0e45: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e4a: Expected O, but got Unknown
		AdventureProgressData adventureProgressData;
		object obj3 = default(object);
		object obj5 = default(object);
		object obj12 = default(object);
		bool result = default(bool);
		StageType? stageType;
		bool flag12;
		object message;
		if (achievementData != null)
		{
			adventureProgressData = achievementData._003CadventureUnlockData_003Ek__BackingField;
			if (achievementData._003CadventureUnlockData_003Ek__BackingField != null)
			{
				if ((object)adventureProgressData._003CRequiredStage_003Ek__BackingField != null && (object)adventureProgressData._003CRequiredCharacter_003Ek__BackingField != null && (object)adventureProgressData._003CRequiredEnemyKillType_003Ek__BackingField != null && (object)adventureProgressData._003CRequiredEnemyKillCount_003Ek__BackingField != null)
				{
					if ((object)adventureProgressData._003CRequiredEnemyKillType_003Ek__BackingField != null)
					{
						EnemyType baseRequiredEnemyType = (EnemyType)((object?)adventureProgressData._003CRequiredEnemyKillType_003Ek__BackingField >> 32);
						List<EnemyType> enemyTypesIncludingVariants = GetEnemyTypesIncludingVariants(baseRequiredEnemyType);
						object obj = 0;
						AdventureProgressManager adventureProgressManager = this;
						object obj2 = default(object);
						while (true)
						{
							if (obj2 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ stack_-78_v20+1C]");
								if (obj3 != null)
								{
									break;
								}
								object obj4 = obj5;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ stack_-78_v20+18]");
								if ((nint)obj4 >= 0)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ stack_-78_v20+10]");
								object obj6 = 0;
								object obj7 = obj5 + 1;
								PlayerOptionsData config = _playerOptions.Config;
								bool flag = config._003CKillCount_003Ek__BackingField == null;
								obj5 = obj7;
								adventureProgressManager = (AdventureProgressManager)(object)_playerOptions;
								if (!flag)
								{
									PlayerOptionsData config2 = _playerOptions.Config;
									Dictionary<EnemyType, int> dictionary = config2._003CKillCount_003Ek__BackingField;
									Dictionary<EnemyType, int> dictionary2 = config2._003CKillCount_003Ek__BackingField;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1882 @ rdx_v80+20+v2162 @ rcx_v92*4]");
									int num = dictionary2.FindEntry(EnemyType.BAT1);
									bool flag2 = num < 0;
									obj5 = obj7;
									adventureProgressManager = (AdventureProgressManager)(object)config2._003CKillCount_003Ek__BackingField;
									if (!flag2)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1686 @ rbx_v41 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.EnemyType, System.Int32>)+18]");
										adventureProgressManager = (AdventureProgressManager)0;
										object obj8 = num + num;
										object obj9 = obj;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1806 @ rcx_v75 (VampireSurvivors.App.Scripts.Framework.Adventures.AdventureProgressManager)+2C+v1699 @ rdx_v93*8]");
										obj = obj9 + 0;
										obj5 = obj7;
									}
								}
								continue;
							}
							throw new NullReferenceException();
						}
						bool flag3 = obj2 == null;
						adventureProgressManager = (AdventureProgressManager)0;
						if (!flag3)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ stack_-78_v20+1C]");
							if (obj3 == null)
							{
								if ((object)adventureProgressData._003CRequiredEnemyKillCount_003Ek__BackingField != null && (object)adventureProgressData._003CRequiredCharacter_003Ek__BackingField != null)
								{
									CharacterType requiredCharacterType = (CharacterType)((object?)adventureProgressData._003CRequiredCharacter_003Ek__BackingField >> 32);
									bool flag4 = checkIfCharacterInPlay(requiredCharacterType);
									if ((object)adventureProgressData._003CRequiredStage_003Ek__BackingField != null)
									{
										StageType requiredStage = (StageType)((object?)adventureProgressData._003CRequiredStage_003Ek__BackingField >> 32);
										bool flag5 = CheckPlayInStage(requiredStage);
										object obj10 = flag4 & flag5;
										if (obj10 == null)
										{
											goto IL_111a;
										}
										object obj11 = obj - obj12;
										object obj13 = obj ^ obj12;
										object obj14 = obj ^ obj11;
										object obj15 = obj13 & obj14;
										bool flag6 = (nint)obj15 < 0;
										bool flag7 = (nint)obj11 < 0;
										result = flag7 == flag6;
										goto IL_126f;
									}
								}
								goto IL_11f7;
							}
							System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
							adventureProgressManager = null;
						}
						throw new NullReferenceException();
					}
				}
				else if ((object)adventureProgressData._003CRequiredMinute_003Ek__BackingField != null && (object)adventureProgressData._003CRequiredStage_003Ek__BackingField != null && (object)adventureProgressData._003CRequiredCharacter_003Ek__BackingField != null)
				{
					if ((object)adventureProgressData._003CRequiredMinute_003Ek__BackingField != null && (object)adventureProgressData._003CRequiredStage_003Ek__BackingField != null && (object)adventureProgressData._003CRequiredCharacter_003Ek__BackingField != null)
					{
						CharacterType requiredCharacterType2 = (CharacterType)((object?)adventureProgressData._003CRequiredCharacter_003Ek__BackingField >> 32);
						bool flag8 = checkIfCharacterInPlay(requiredCharacterType2);
						GameManager core = GM.Core;
						object obj16 = obj12 * 60;
						float num2 = core._003CSurvivedSeconds_003Ek__BackingField;
						if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj16))
						{
							result = false;
						}
						else
						{
							StageType requiredStage2 = default(StageType);
							bool flag9 = CheckPlayInStage(requiredStage2);
							result = flag9 & flag8;
						}
						goto IL_126f;
					}
				}
				else if ((object)adventureProgressData._003CRequiredFoundWeaponType_003Ek__BackingField != null && (object)adventureProgressData._003CRequiredStage_003Ek__BackingField != null && (object)adventureProgressData._003CRequiredCharacter_003Ek__BackingField != null)
				{
					if ((object)adventureProgressData._003CRequiredFoundWeaponType_003Ek__BackingField != null && (object)adventureProgressData._003CRequiredStage_003Ek__BackingField != null && (object)adventureProgressData._003CRequiredCharacter_003Ek__BackingField != null)
					{
						CharacterType requiredCharacterType3 = (CharacterType)((object?)adventureProgressData._003CRequiredCharacter_003Ek__BackingField >> 32);
						bool flag10 = checkIfCharacterInPlay(requiredCharacterType3);
						PlayerOptionsData config3 = _playerOptions.Config;
						if (config3._003CCollectedWeapons_003Ek__BackingField != null)
						{
							PlayerOptionsData config4 = _playerOptions.Config;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
							object obj17 = default(object);
							bool flag11 = obj17 != null;
							stageType = adventureProgressData._003CRequiredStage_003Ek__BackingField;
							flag12 = flag10;
							if (flag11)
							{
								goto IL_081c;
							}
						}
						goto IL_06b0;
					}
				}
				else
				{
					if ((object)adventureProgressData._003CRequiredLevel_003Ek__BackingField == null)
					{
						goto IL_092c;
					}
					if ((object)adventureProgressData._003CRequiredStage_003Ek__BackingField != null && (object)adventureProgressData._003CRequiredCharacter_003Ek__BackingField != null)
					{
						if ((object)adventureProgressData._003CRequiredLevel_003Ek__BackingField != null && (object)adventureProgressData._003CRequiredStage_003Ek__BackingField != null && (object)adventureProgressData._003CRequiredCharacter_003Ek__BackingField != null)
						{
							CharacterType requiredCharacterType4 = (CharacterType)((object?)adventureProgressData._003CRequiredCharacter_003Ek__BackingField >> 32);
							bool flag13 = checkIfCharacterInPlay(requiredCharacterType4);
							PlayerOptionsData config5 = _playerOptions.Config;
							if (config5._003CCollectedWeapons_003Ek__BackingField != null)
							{
								bool flag14 = currentCharacter._level < (nint)obj12;
								stageType = adventureProgressData._003CRequiredStage_003Ek__BackingField;
								flag12 = flag13;
								if (!flag14)
								{
									goto IL_081c;
								}
							}
							goto IL_06b0;
						}
					}
					else
					{
						if ((object)adventureProgressData._003CRequiredLevel_003Ek__BackingField == null || (object)adventureProgressData._003CRequiredStage_003Ek__BackingField == null)
						{
							goto IL_092c;
						}
						if ((object)adventureProgressData._003CRequiredLevel_003Ek__BackingField != null && (object)adventureProgressData._003CRequiredStage_003Ek__BackingField != null)
						{
							object obj18 = (object?)adventureProgressData._003CRequiredLevel_003Ek__BackingField >> 32;
							if (currentCharacter._level < (nint)obj18)
							{
								goto IL_111a;
							}
							StageType requiredStage3 = (StageType)((object?)adventureProgressData._003CRequiredStage_003Ek__BackingField >> 32);
							result = CheckPlayInStage(requiredStage3);
							goto IL_126f;
						}
					}
				}
				goto IL_11f7;
			}
			message = "[AdventureProgressManager] AdventureUnlockData is NULL, cannot process unlock requirement checks.";
		}
		else
		{
			message = "[AdventureProgressManager] AchievementData NULL, cannot process unlock requirement checks.";
		}
		Debug.LogError(message);
		goto IL_111a;
		IL_092c:
		if ((object)adventureProgressData._003CRequiredMinute_003Ek__BackingField != null && (object)adventureProgressData._003CRequiredStage_003Ek__BackingField != null)
		{
			if ((object)adventureProgressData._003CRequiredMinute_003Ek__BackingField == null || (object)adventureProgressData._003CRequiredStage_003Ek__BackingField == null)
			{
				goto IL_11f7;
			}
			GameManager core2 = GM.Core;
			object obj19 = (object?)adventureProgressData._003CRequiredMinute_003Ek__BackingField >> 32;
			object obj20 = obj19 * 60;
			float num3 = core2._003CSurvivedSeconds_003Ek__BackingField;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num3) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj20))
			{
				goto IL_111a;
			}
			StageType requiredStage4 = (StageType)((object?)adventureProgressData._003CRequiredStage_003Ek__BackingField >> 32);
			result = CheckPlayInStage(requiredStage4);
		}
		else if ((object)adventureProgressData._003CRequiredLevel_003Ek__BackingField != null && (object)adventureProgressData._003CRequiredCharacter_003Ek__BackingField != null)
		{
			if ((object)adventureProgressData._003CRequiredLevel_003Ek__BackingField == null || (object)adventureProgressData._003CRequiredCharacter_003Ek__BackingField == null)
			{
				goto IL_11f7;
			}
			CharacterType requiredCharacterType5 = (CharacterType)((object?)adventureProgressData._003CRequiredCharacter_003Ek__BackingField >> 32);
			bool flag15 = checkIfCharacterInPlay(requiredCharacterType5);
			bool flag16 = currentCharacter._level < (nint)obj12;
			bool flag17 = false;
			if (!flag16)
			{
				flag17 = flag15;
			}
			result = flag17;
		}
		else if ((object)adventureProgressData._003CRequiredMinute_003Ek__BackingField != null && (object)adventureProgressData._003CRequiredCharacter_003Ek__BackingField != null)
		{
			if ((object)adventureProgressData._003CRequiredMinute_003Ek__BackingField == null || (object)adventureProgressData._003CRequiredCharacter_003Ek__BackingField == null)
			{
				goto IL_11f7;
			}
			CharacterType requiredCharacterType6 = (CharacterType)((object?)adventureProgressData._003CRequiredCharacter_003Ek__BackingField >> 32);
			result = checkIfCharacterInPlay(requiredCharacterType6);
			GameManager core3 = GM.Core;
			object obj21 = obj12 * 60;
			float num4 = core3._003CSurvivedSeconds_003Ek__BackingField;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num4) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj21))
			{
				result = false;
			}
		}
		else
		{
			if ((object)adventureProgressData._003CRequiredEnemyKillType_003Ek__BackingField != null && (object)adventureProgressData._003CRequiredEnemyKillCount_003Ek__BackingField != null)
			{
				if ((object)adventureProgressData._003CRequiredEnemyKillCount_003Ek__BackingField != null)
				{
					object obj22 = (object?)adventureProgressData._003CRequiredEnemyKillCount_003Ek__BackingField >> 32;
					if ((object)adventureProgressData._003CRequiredEnemyKillType_003Ek__BackingField != null)
					{
						EnemyType baseRequiredEnemyType2 = (EnemyType)((object?)adventureProgressData._003CRequiredEnemyKillType_003Ek__BackingField >> 32);
						List<EnemyType> enemyTypesIncludingVariants2 = GetEnemyTypesIncludingVariants(baseRequiredEnemyType2);
						object obj23 = 0;
						AdventureProgressManager adventureProgressManager2 = this;
						object obj24 = default(object);
						while (true)
						{
							if (obj24 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ stack_-78_v18+1C]");
								if (obj3 != null)
								{
									break;
								}
								object obj25 = obj5;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ stack_-78_v18+18]");
								if ((nint)obj25 >= 0)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ stack_-78_v18+10]");
								object obj26 = 0;
								object obj27 = obj5 + 1;
								PlayerOptionsData config6 = _playerOptions.Config;
								bool flag18 = config6._003CKillCount_003Ek__BackingField == null;
								obj5 = obj27;
								adventureProgressManager2 = (AdventureProgressManager)(object)_playerOptions;
								if (!flag18)
								{
									PlayerOptionsData config7 = _playerOptions.Config;
									Dictionary<EnemyType, int> dictionary3 = config7._003CKillCount_003Ek__BackingField;
									Dictionary<EnemyType, int> dictionary4 = config7._003CKillCount_003Ek__BackingField;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1926 @ rdx_v36+20+v2965 @ rcx_v43*4]");
									int num5 = dictionary4.FindEntry(EnemyType.BAT1);
									bool flag19 = num5 < 0;
									obj5 = obj27;
									adventureProgressManager2 = (AdventureProgressManager)(object)config7._003CKillCount_003Ek__BackingField;
									if (!flag19)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2103 @ rdi_v23 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.EnemyType, System.Int32>)+18]");
										adventureProgressManager2 = (AdventureProgressManager)0;
										object obj28 = num5 + num5;
										object obj29 = obj23;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1267 @ rcx_v14 (VampireSurvivors.App.Scripts.Framework.Adventures.AdventureProgressManager)+2C+v2393 @ rdx_v41*8]");
										obj23 = obj29 + 0;
										obj5 = obj27;
									}
								}
								continue;
							}
							throw new NullReferenceException();
						}
						bool flag20 = obj24 == null;
						adventureProgressManager2 = (AdventureProgressManager)0;
						if (!flag20)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v423 @ stack_-78_v18+1C]");
							if (obj3 == null)
							{
								object obj30 = obj23 - obj22;
								object obj31 = obj23 ^ obj22;
								object obj32 = obj23 ^ obj30;
								object obj33 = obj31 & obj32;
								bool flag21 = (nint)obj33 < 0;
								bool flag22 = (nint)obj30 < 0;
								result = flag22 == flag21;
								goto IL_126f;
							}
							System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
							adventureProgressManager2 = null;
						}
						throw new NullReferenceException();
					}
				}
				goto IL_11f7;
			}
			if ((object)adventureProgressData._003CRequiredFoundWeaponType_003Ek__BackingField == null)
			{
				if ((object)adventureProgressData._003CRequiredFoundCoffinType_003Ek__BackingField == null)
				{
					if ((object)adventureProgressData._003CRequiredLevel_003Ek__BackingField == null)
					{
						goto IL_111a;
					}
					if ((object)adventureProgressData._003CRequiredLevel_003Ek__BackingField == null)
					{
						goto IL_11f7;
					}
					object obj34 = (object?)adventureProgressData._003CRequiredLevel_003Ek__BackingField >> 32;
					object obj35 = currentCharacter._level - obj34;
					int num6 = currentCharacter._level ^ obj34;
					int num7 = currentCharacter._level ^ obj35;
					int num8 = num6 & num7;
					bool flag23 = num8 < 0;
					bool flag24 = (nint)obj35 < 0;
					result = flag24 == flag23;
				}
				else
				{
					if ((object)adventureProgressData._003CRequiredFoundCoffinType_003Ek__BackingField == null)
					{
						goto IL_11f7;
					}
					object obj36 = (object?)adventureProgressData._003CRequiredFoundCoffinType_003Ek__BackingField >> 32;
					PlayerOptionsData config8 = _playerOptions.Config;
					if (config8._003COpenedCoffins_003Ek__BackingField != null)
					{
						PlayerOptionsData config9 = _playerOptions.Config;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
						object obj37 = default(object);
						if (obj37 != null)
						{
							result = true;
							goto IL_126f;
						}
					}
					PlayerOptionsData config10 = _playerOptions.Config;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9ACE0");
				}
			}
			else
			{
				if ((object)adventureProgressData._003CRequiredFoundWeaponType_003Ek__BackingField == null)
				{
					goto IL_11f7;
				}
				PlayerOptionsData config11 = _playerOptions.Config;
				if (config11._003CCollectedWeapons_003Ek__BackingField == null)
				{
					goto IL_111a;
				}
				PlayerOptionsData config12 = _playerOptions.Config;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
			}
		}
		goto IL_126f;
		IL_111a:
		result = false;
		goto IL_126f;
		IL_06b0:
		result = false;
		goto IL_126f;
		IL_126f:
		return result;
		IL_081c:
		StageType requiredStage5 = (StageType)((object?)stageType >> 32);
		bool flag25 = CheckPlayInStage(requiredStage5);
		result = flag25 & flag12;
		goto IL_126f;
		IL_11f7:
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		bool result2 = default(bool);
		return result2;
	}

	private unsafe bool checkIfCharacterInPlay(CharacterType requiredCharacterType)
	{
		//IL_0019: Expected O, but got I4
		//IL_0021: Expected O, but got Ref
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = (List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		return false;
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

	private List<EnemyType> GetEnemyTypesIncludingVariants(EnemyType baseRequiredEnemyType)
	{
		//IL_0028: Expected O, but got I
		//IL_0081: Expected O, but got I
		//IL_017e: Expected O, but got I
		//IL_01bb: Expected O, but got I
		//IL_0215: Expected O, but got I
		//IL_02a0: Expected O, but got I
		//IL_0337: Expected I, but got O
		//IL_02ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b3: Expected O, but got Unknown
		List<EnemyType> list = new List<EnemyType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rcx_v14+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)baseRequiredEnemyType);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rcx_v14+18]");
			if (num2 >= 0)
			{
				goto IL_036c;
			}
		}
		Dictionary<EnemyType, List<EnemyData>> convertedEnemyData = _dataManager.GetConvertedEnemyData();
		if (((Dictionary<System.Int32Enum, object>)(object)convertedEnemyData).TryGetValue((System.Int32Enum)baseRequiredEnemyType, out object value) && value != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ stack_20_v10 (System.Object)+18]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ stack_20_v10 (System.Object)+18]");
				if ((nint)0 > (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ stack_20_v10 (System.Object)+10]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rcx_v19+18]");
					if ((nint)0 > (nint)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rcx_v19+20]");
						List<EnemyType> list2 = (List<EnemyType>)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rcx_v19+20]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v554 @ rcx_v22 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+150]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v554 @ rcx_v22 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+150]");
								object obj4 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v624 @ rax_v27+18]");
								if ((nint)0 > (nint)0)
								{
									object obj5 = default(object);
									object obj6 = default(object);
									object obj8 = default(object);
									object obj11 = default(object);
									while (true)
									{
										if (obj5 != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ stack_-38_v10+1C]");
											if (obj6 == null)
											{
												object obj7 = obj8;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ stack_-38_v10+18]");
												if ((nint)obj7 < 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ stack_-38_v10+10]");
													object obj9 = 0;
													object obj10 = obj8 + 1;
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AF20");
													bool flag = obj11 != null;
													obj8 = obj10;
													if (!flag)
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
									bool flag2 = obj5 == null;
									nint num3 = 0;
									if (!flag2)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ stack_-38_v10+1C]");
										if (obj6 == null)
										{
											goto IL_037a;
										}
										System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
										num3 = unchecked((nint)null);
									}
									throw new NullReferenceException();
								}
							}
						}
						goto IL_037a;
					}
				}
				else
				{
					System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				}
				goto IL_036c;
			}
		}
		goto IL_037a;
		IL_037a:
		return list;
		IL_036c:
		return (List<EnemyType>)(object)new IndexOutOfRangeException();
	}

	private unsafe void Unlock(AdventureAchievementType adventureAchievementType, AchievementData achievementData, AdventureData adventureData, PlayerOptionsData config)
	{
		//IL_00fa: Expected O, but got I4
		//IL_0108: Expected O, but got I4
		//IL_0110: Expected O, but got Ref
		//IL_01d3: Expected O, but got I
		//IL_01e3: Expected O, but got I
		//IL_0261: Expected O, but got I
		//IL_0315: Expected I, but got O
		AdventureProgressManager adventureProgressManager = this;
		PlayerOptionsData playerOptionsData = default(PlayerOptionsData);
		if (playerOptionsData != null)
		{
			if (playerOptionsData._003CAdventureProgress_003Ek__BackingField != null)
			{
				adventureProgressManager = (AdventureProgressManager)(object)playerOptionsData._003CAdventureProgress_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9D310");
				object obj = default(object);
				if (obj != null)
				{
					return;
				}
			}
			if (adventureData != null)
			{
				if (adventureData._003CProgressData_003Ek__BackingField == null)
				{
					return;
				}
				List<AchievementData> list = adventureData._003CProgressData_003Ek__BackingField;
				if (list._size <= 0 || achievementData == null)
				{
					return;
				}
				object obj2 = 0;
				List<AchievementData>.Enumerator enumerator = default(List<AchievementData>.Enumerator);
				if (enumerator.MoveNext())
				{
					object obj3 = 0;
					List<AchievementData>.Enumerator enumerator2 = (List<AchievementData>.Enumerator)(&enumerator);
					throw new NullReferenceException();
				}
				if (obj2 == null)
				{
					return;
				}
				List<System.Int32Enum> list2 = (List<System.Int32Enum>)(object)playerOptionsData._003CAdventureProgress_003Ek__BackingField;
				if (playerOptionsData._003CAdventureProgress_003Ek__BackingField != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rcx_v13 (System.Collections.Generic.List`1<System.Int32Enum>)+1C]");
					_ = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rcx_v13 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rcx_v13 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rcx_v13 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rcx_v13 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ r8_v7+18]");
						if (num >= 0)
						{
							((List<System.Int32Enum>)(object)playerOptionsData._003CAdventureProgress_003Ek__BackingField).AddWithResize((System.Int32Enum)adventureAchievementType);
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rcx_v13 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
							object obj6 = (nint)0 + (nint)1;
						}
						nint num2 = (nint)achievementData;
						achievementData.Unlock(playerOptionsData, _playerOptions);
						if (_achievementManager != null)
						{
							AchievementManager achievementManager = _achievementManager;
							if (achievementManager._recentlyUnlockedAdventureProgress != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B120");
							}
						}
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private bool HasAlreadyUnlocked(AdventureAchievementType adventureAchievementType, PlayerOptionsData config)
	{
		//IL_004d: Expected I4, but got O
		if (config != null)
		{
			if (config._003CAdventureProgress_003Ek__BackingField == null)
			{
				return false;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9D310");
			bool result = default(bool);
			return result;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}
}
