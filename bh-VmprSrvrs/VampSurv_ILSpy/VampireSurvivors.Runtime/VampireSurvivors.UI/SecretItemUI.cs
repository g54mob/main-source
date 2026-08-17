using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Achievements;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Data.PowerUp;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.UI;

public class SecretItemUI : SelectableUI
{
	private Image _Tick;

	private TextMeshProUGUI _Description;

	private Image _Reward;

	private SecretData _data;

	private SecretType _type;

	private DataManager _dataManager;

	private SecretsPage _page;

	private bool _hasAchieved;

	public void SetData(DataManager dataManager, SecretsPage page, SecretData data, SecretType type, bool hasAchieved)
	{
		_data = data;
		SecretType secretType = default(SecretType);
		_type = secretType;
		_dataManager = dataManager;
		_page = page;
		bool flag = default(bool);
		_hasAchieved = flag;
		_Tick.enabled = flag;
		string localizedDescriptionTerm = data.GetLocalizedDescriptionTerm(secretType);
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		string translation = LocalizationManager.GetTranslation(localizedDescriptionTerm, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		_Description.text = translation;
		Sprite sprite2;
		Image reward;
		if (!flag)
		{
			Sprite sprite = SpriteManager.GetSprite("QuestionMark", "UI");
			sprite2 = sprite;
			reward = _Reward;
		}
		else
		{
			Sprite rewardSprite = GetRewardSprite(_data);
			_Reward.sprite = rewardSprite;
			Image reward2 = _Reward;
			Sprite sprite3 = reward2.m_Sprite;
			if ((object)reward2.m_Sprite != null && ((UnityEngine.Object)sprite3).m_CachedPtr != (IntPtr)0)
			{
				return;
			}
			Sprite sprite4 = SpriteManager.GetSprite("QuestionMark", "UI");
			sprite2 = sprite4;
			reward = _Reward;
		}
		reward.sprite = sprite2;
	}

	public SecretType GetSecretType()
	{
		return _type;
	}

	public bool CheckAchieved()
	{
		return _hasAchieved;
	}

	public Sprite GetSecondReward(SecretData bad)
	{
		//IL_045e: Expected I4, but got O
		//IL_038d: Expected I4, but got O
		//IL_04ac: Expected O, but got I
		//IL_04c1: Expected O, but got I
		//IL_02f8: Expected I4, but got O
		//IL_04d6: Expected O, but got I
		//IL_04e6: Expected O, but got I
		//IL_03db: Expected O, but got I
		//IL_03f0: Expected O, but got I
		//IL_0334: Expected O, but got I
		//IL_0344: Expected O, but got I
		//IL_0405: Expected O, but got I
		//IL_0415: Expected O, but got I
		//IL_0291: Expected I4, but got O
		//IL_0238: Expected O, but got I
		//IL_0248: Expected O, but got I
		//IL_01fc: Expected I4, but got O
		//IL_0178: Expected I4, but got O
		//IL_01a3: Expected O, but got I
		//IL_01b3: Expected O, but got I
		string spriteName;
		string textureName;
		if ((object)bad._003CweaponToUnlock_003Ek__BackingField == null)
		{
			if ((object)bad._003CstageToUnlock_003Ek__BackingField == null)
			{
				if ((object)bad._003ChyperToUnlock_003Ek__BackingField == null)
				{
					if ((object)bad._003CrelicToUnlock_003Ek__BackingField == null)
					{
						if ((object)bad._003CpowerUpToUnlock_003Ek__BackingField == null)
						{
							if ((object)bad._003CarcanaToUnlock_003Ek__BackingField == null)
							{
								if (bad._003CweaponListToUnlock_003Ek__BackingField == null)
								{
									return null;
								}
								return SpriteManager.GetSprite(bad._003CcustomSmallFrame_003Ek__BackingField, bad._003CcustomSmallTexture_003Ek__BackingField);
							}
							DataManager dataManager = _dataManager;
							if ((object)bad._003CarcanaToUnlock_003Ek__BackingField != null)
							{
								System.Int32Enum key = (System.Int32Enum)((object?)bad._003CarcanaToUnlock_003Ek__BackingField >> 32);
								object obj = ((Dictionary<System.Int32Enum, object>)(object)dataManager._003CAllArcanas_003Ek__BackingField).get_Item(key);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rax_v30 (System.Object)+40]");
								spriteName = (string)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rax_v30 (System.Object)+38]");
								textureName = (string)0;
								goto IL_04eb;
							}
						}
						else
						{
							Dictionary<PowerUpType, List<PowerUpData>> convertedPowerUpData = _dataManager.GetConvertedPowerUpData();
							if ((object)bad._003CpowerUpToUnlock_003Ek__BackingField != null)
							{
								System.Int32Enum key2 = (System.Int32Enum)((object?)bad._003CpowerUpToUnlock_003Ek__BackingField >> 32);
								object obj2 = ((Dictionary<System.Int32Enum, object>)(object)convertedPowerUpData).get_Item(key2);
								List<PowerUpData> list = ((Dictionary<PowerUpType, List<PowerUpData>>)obj2).get_Item((PowerUpType)key2);
								goto IL_0228;
							}
						}
					}
					else
					{
						DataManager dataManager2 = _dataManager;
						if ((object)bad._003CrelicToUnlock_003Ek__BackingField != null)
						{
							System.Int32Enum key3 = (System.Int32Enum)((object?)bad._003CrelicToUnlock_003Ek__BackingField >> 32);
							object obj3 = ((Dictionary<System.Int32Enum, object>)(object)dataManager2._003CAllItems_003Ek__BackingField).get_Item(key3);
							List<PowerUpData> list = (List<PowerUpData>)obj3;
							goto IL_0228;
						}
					}
				}
				else
				{
					Dictionary<StageType, List<StageData>> convertedStages = _dataManager.GetConvertedStages();
					if ((object)bad._003ChyperToUnlock_003Ek__BackingField != null)
					{
						System.Int32Enum key4 = (System.Int32Enum)((object?)bad._003ChyperToUnlock_003Ek__BackingField >> 32);
						object obj4 = ((Dictionary<System.Int32Enum, object>)(object)convertedStages).get_Item(key4);
						List<StageData> list2 = ((Dictionary<StageType, List<StageData>>)obj4).get_Item((StageType)key4);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rax_v22 (System.Collections.Generic.List`1<VampireSurvivors.Data.Stage.StageData>)+58]");
						spriteName = (string)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rax_v22 (System.Collections.Generic.List`1<VampireSurvivors.Data.Stage.StageData>)+40]");
						textureName = (string)0;
						goto IL_04eb;
					}
				}
			}
			else
			{
				Dictionary<StageType, List<StageData>> convertedStages2 = _dataManager.GetConvertedStages();
				if ((object)bad._003CstageToUnlock_003Ek__BackingField != null)
				{
					System.Int32Enum key5 = (System.Int32Enum)((object?)bad._003CstageToUnlock_003Ek__BackingField >> 32);
					object obj5 = ((Dictionary<System.Int32Enum, object>)(object)convertedStages2).get_Item(key5);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rax_v18 (System.Object)+18]");
					if ((nint)0 > (nint)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rax_v18 (System.Object)+10]");
						object obj6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rax_v19+20]");
						object obj7 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rdx_v14+58]");
						spriteName = (string)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rdx_v14+40]");
						textureName = (string)0;
						goto IL_04eb;
					}
					goto IL_0515;
				}
			}
		}
		else
		{
			Dictionary<WeaponType, List<WeaponData>> convertedWeapons = _dataManager.GetConvertedWeapons();
			if ((object)bad._003CweaponToUnlock_003Ek__BackingField != null)
			{
				System.Int32Enum key6 = (System.Int32Enum)((object?)bad._003CweaponToUnlock_003Ek__BackingField >> 32);
				object obj8 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item(key6);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rax_v15 (System.Object)+18]");
				if ((nint)0 > (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rax_v15 (System.Object)+10]");
					object obj9 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ rax_v16+20]");
					object obj10 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rdx_v10+40]");
					spriteName = (string)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rdx_v10+38]");
					textureName = (string)0;
					goto IL_04eb;
				}
				goto IL_0515;
			}
		}
		goto IL_0506;
		IL_04eb:
		return SpriteManager.GetSprite(spriteName, textureName);
		IL_0228:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rax_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.PowerUp.PowerUpData>)+38]");
		spriteName = (string)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rax_v25 (System.Collections.Generic.List`1<VampireSurvivors.Data.PowerUp.PowerUpData>)+30]");
		textureName = (string)0;
		goto IL_04eb;
		IL_0506:
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		Sprite result = default(Sprite);
		return result;
		IL_0515:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		goto IL_0506;
	}

	public Sprite GetCharacterReward(SecretData bad)
	{
		//IL_029e: Expected I4, but got O
		//IL_02ec: Expected O, but got I
		//IL_0301: Expected O, but got I
		//IL_0316: Expected O, but got I
		//IL_0326: Expected O, but got I
		string spriteName;
		string textureName;
		if ((object)bad._003CcharacterToUnlock_003Ek__BackingField == null)
		{
			if (bad._003CskinsToUnlock_003Ek__BackingField != null)
			{
				List<SkinToUnlock> list = bad._003CskinsToUnlock_003Ek__BackingField;
				if (list._size > 0)
				{
					if (list._size <= 0)
					{
						goto IL_0346;
					}
					SkinToUnlock[] items = list._items;
					SkinToUnlock skinToUnlock = items[0];
					Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = _dataManager.GetConvertedCharacterData();
					if (convertedCharacterData != null)
					{
						object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)skinToUnlock.character);
						if (obj != null)
						{
							List<CharacterData> list2 = ((Dictionary<CharacterType, List<CharacterData>>)obj).get_Item(skinToUnlock.character);
							if (list2 != null)
							{
								Skin skinData = ((CharacterData)(object)list2).GetSkinData(skinToUnlock.skin);
								if (skinData != null)
								{
									string text = skinData._003CspriteName_003Ek__BackingField;
									if (skinData._003CspriteName_003Ek__BackingField != null && text._stringLength > 0)
									{
										string text2 = skinData._003CtextureName_003Ek__BackingField;
										if (skinData._003CtextureName_003Ek__BackingField != null && text2._stringLength > 0)
										{
											spriteName = skinData._003CspriteName_003Ek__BackingField;
											textureName = skinData._003CtextureName_003Ek__BackingField;
											goto IL_032b;
										}
									}
								}
							}
						}
					}
				}
			}
			return null;
		}
		Dictionary<CharacterType, List<CharacterData>> convertedCharacterData2 = _dataManager.GetConvertedCharacterData();
		if ((object)bad._003CcharacterToUnlock_003Ek__BackingField != null)
		{
			System.Int32Enum key = (System.Int32Enum)((object?)bad._003CcharacterToUnlock_003Ek__BackingField >> 32);
			object obj2 = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData2).get_Item(key);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rax_v15 (System.Object)+18]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rax_v15 (System.Object)+10]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rax_v16+20]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rdx_v10+48]");
				spriteName = (string)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ rdx_v10+40]");
				textureName = (string)0;
				goto IL_032b;
			}
			goto IL_0346;
		}
		goto IL_0356;
		IL_0346:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		goto IL_0356;
		IL_0356:
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		Sprite result = default(Sprite);
		return result;
		IL_032b:
		return SpriteManager.GetSprite(spriteName, textureName);
	}

	public Sprite GetOtherReward(SecretData bad)
	{
		//IL_0070: Expected I4, but got O
		//IL_00be: Expected O, but got I
		//IL_00d3: Expected O, but got I
		//IL_00ff: Expected O, but got I
		//IL_00ff: Expected O, but got I
		if ((object)bad._003CweaponToUnlock_003Ek__BackingField == null)
		{
			return null;
		}
		Dictionary<WeaponType, List<WeaponData>> convertedWeapons = _dataManager.GetConvertedWeapons();
		if ((object)bad._003CweaponToUnlock_003Ek__BackingField != null)
		{
			System.Int32Enum key = (System.Int32Enum)((object?)bad._003CweaponToUnlock_003Ek__BackingField >> 32);
			object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item(key);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v11 (System.Object)+18]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v11 (System.Object)+10]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rax_v12+20]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rdx_v8+40]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rdx_v8+38]");
				return SpriteManager.GetSprite((string)num, (string)0);
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		Sprite result = default(Sprite);
		return result;
	}

	private Sprite GetRewardSprite(SecretData bad)
	{
		//IL_006b: Expected I4, but got O
		//IL_00b9: Expected O, but got I
		//IL_00ce: Expected O, but got I
		//IL_0118: Expected O, but got I
		Sprite characterReward = GetCharacterReward(bad);
		Sprite sprite2;
		if ((object)bad._003CcharacterToUnlock_003Ek__BackingField != null)
		{
			Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = _dataManager.GetConvertedCharacterData();
			if ((object)bad._003CcharacterToUnlock_003Ek__BackingField != null)
			{
				System.Int32Enum key = (System.Int32Enum)((object?)bad._003CcharacterToUnlock_003Ek__BackingField >> 32);
				object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item(key);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rax_v28 (System.Object)+18]");
				if ((nint)0 > (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rax_v28 (System.Object)+10]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rax_v29+20]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rcx_v23+60]");
					if ((nint)0 == 0)
					{
						goto IL_0129;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rcx_v23+60]");
					Sprite sprite = SpriteManager.GetSprite((string)0, "UI");
					sprite2 = sprite;
					goto IL_01b4;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
			Sprite result = default(Sprite);
			return result;
		}
		goto IL_0129;
		IL_01b4:
		if ((object)sprite2 == null || ((UnityEngine.Object)sprite2).m_CachedPtr == (IntPtr)0)
		{
			Sprite secondReward = GetSecondReward(bad);
			sprite2 = secondReward;
		}
		return sprite2;
		IL_0129:
		sprite2 = null;
		goto IL_01b4;
	}

	protected override void OnSelected()
	{
		_page.SetInfoPanel(_data, _type, this);
	}

	public void SetInfoPanel()
	{
		_page.SetInfoPanel(_data, _type, this);
	}

	public SecretItemUI()
	{
		//IL_0036: Expected I, but got O
		base._ShowSelector = true;
		base._ShouldUpdatePositionWhenForcingDumbFix = true;
		ReselectIfDefaultSelectedOnPage = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
