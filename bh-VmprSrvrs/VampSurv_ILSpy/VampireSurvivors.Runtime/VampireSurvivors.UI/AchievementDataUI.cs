using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Achievements;
using VampireSurvivors.App.Data.Adventures;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Data.PowerUp;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.UI;

public class AchievementDataUI : SelectableUI
{
	private Image Icon;

	private Image Tick;

	private TextMeshProUGUI Label;

	private GameObject Moneybag;

	private GameObject _Frame;

	private Localize localizer;

	private AchievementsPage _page;

	private AchievementData _data;

	private DataManager _dataManager;

	private bool _isAdventureAchievement;

	private AchievementType _type;

	private AdventureAchievementType _adventureType;

	private bool _hasAchieved;

	public void SetData(AdventureAchievementType type, AchievementData bad, AchievementsPage page, DataManager dataManager, bool hasCompleted)
	{
		//IL_002b: Expected I4, but got O
		_adventureType = type;
		_isAdventureAchievement = true;
		DataManager dataManager2 = default(DataManager);
		Init(bad, page, dataManager2, (byte)(int)dataManager != 0);
	}

	public void SetData(AchievementType type, AchievementData bad, AchievementsPage page, DataManager dataManager, bool hasCompleted)
	{
		_type = type;
		_isAdventureAchievement = false;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 10 Invalid \"Jump target not found in method: 0x187757260\"");
	}

	private void Init(AchievementData achievementData, AchievementsPage page, DataManager dataManager, bool hasCompleted)
	{
		//IL_007e: Expected I, but got O
		//IL_0098: Expected O, but got I
		//IL_00a8: Expected O, but got I
		//IL_002a: Expected I, but got O
		//IL_003a: Expected O, but got I
		//IL_004a: Expected O, but got I
		//IL_065c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0661: Expected O, but got Unknown
		//IL_07ab->IL053e: Incompatible stack heights: 1 vs 0
		//IL_0744->IL053e: Incompatible stack heights: 2 vs 0
		//IL_077c->IL053e: Incompatible stack heights: 1 vs 0
		//IL_04a1->IL053e: Incompatible stack heights: 1 vs 0
		//IL_0686->IL053e: Incompatible stack heights: 2 vs 0
		//IL_04c3->IL04c3: Incompatible stack heights: 2 vs 0
		if (_isAdventureAchievement)
		{
			if (achievementData == null)
			{
				goto IL_053e;
			}
			nint num = (nint)achievementData;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ r8_v42 (Il2CppClass<VampireSurvivors.Achievements.AchievementData>)+188]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ r8_v42 (Il2CppClass<VampireSurvivors.Achievements.AchievementData>)+190]");
			object obj2 = 0;
			AchievementType adventureType = (AchievementType)_adventureType;
		}
		else
		{
			if (achievementData == null)
			{
				goto IL_053e;
			}
			nint num2 = (nint)achievementData;
			AchievementType adventureType = _type;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ r8_v40 (Il2CppClass<VampireSurvivors.Achievements.AchievementData>)+178]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ r8_v40 (Il2CppClass<VampireSurvivors.Achievements.AchievementData>)+180]");
			object obj2 = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v421 @ rax_v22 (should have been resolved before IL gen)");
		Image component;
		if ((object)localizer != null)
		{
			string term = default(string);
			localizer.Term = term;
			if ((object)Tick != null)
			{
				bool flag = default(bool);
				Tick.enabled = flag;
				achievementData._003Cachieved_003Ek__BackingField = flag;
				SetName(achievementData._003Cdescription_003Ek__BackingField);
				_hasAchieved = flag;
				_page = page;
				_data = achievementData;
				_dataManager = dataManager;
				if ((object)_Frame != null)
				{
					component = _Frame.GetComponent<Image>();
					string text = achievementData._003CarcanaToUnlock_003Ek__BackingField;
					if (achievementData._003CarcanaToUnlock_003Ek__BackingField != null && text._stringLength > 0)
					{
						if ((object)component != null)
						{
							component.enabled = true;
							int num3 = int.Parse(achievementData._003CarcanaToUnlock_003Ek__BackingField);
							string spriteName = ((num3 <= 21) ? "frameG" : "frameH");
							Sprite sprite = SpriteManager.GetSprite(spriteName, "UI");
							component.sprite = sprite;
							goto IL_025f;
						}
					}
					else if ((object)component != null)
					{
						component.enabled = false;
						goto IL_025f;
					}
				}
			}
		}
		goto IL_053e;
		IL_025f:
		Sprite spriteForAchievement = GetSpriteForAchievement(_data);
		Rect ret;
		Rect ret2;
		Vector2 sizeDelta = default(Vector2);
		if ((object)Icon != null)
		{
			Icon.sprite = spriteForAchievement;
			AchievementData data = _data;
			if (_data != null && (object)Moneybag != null)
			{
				int num4 = data._003CgoldPrize_003Ek__BackingField ^ data._003CgoldPrize_003Ek__BackingField;
				int num5 = data._003CgoldPrize_003Ek__BackingField & num4;
				bool flag2 = num5 < 0;
				bool flag3 = data._003CgoldPrize_003Ek__BackingField < 0;
				bool flag4 = data._003CgoldPrize_003Ek__BackingField == 0;
				bool flag5 = flag3 == flag2;
				bool flag6 = !flag4;
				bool active = flag6 & flag5;
				Moneybag.SetActive(active);
				Image icon = Icon;
				if ((object)Icon != null)
				{
					AchievementsPage sprite2 = (AchievementsPage)(object)icon.m_Sprite;
					if ((object)icon.m_Sprite == null || ((UnityEngine.Object)sprite2).m_CachedPtr == (IntPtr)0)
					{
						goto IL_04c3;
					}
					if ((object)Icon != null)
					{
						RectTransform rectTransform = Icon.rectTransform;
						AchievementsPage icon2 = (AchievementsPage)(object)Icon;
						if ((object)Icon != null)
						{
							AchievementsPage achievementPrefab = (AchievementsPage)(object)icon2._AchievementPrefab;
							if ((object)icon2._AchievementPrefab != null)
							{
								bool flag7 = ((UnityEngine.Object)achievementPrefab).m_CachedPtr == (IntPtr)0;
								Sprite.get_rect_Injected(((UnityEngine.Object)achievementPrefab).m_CachedPtr, out ret);
								AchievementDataUI icon3 = (AchievementDataUI)(object)Icon;
								if ((object)Icon != null)
								{
									AchievementDataUI dataManager2 = (AchievementDataUI)(object)icon3._dataManager;
									if (icon3._dataManager != null)
									{
										bool flag8 = ((UnityEngine.Object)dataManager2).m_CachedPtr == (IntPtr)0;
										Sprite.get_rect_Injected(((UnityEngine.Object)dataManager2).m_CachedPtr, out ret2);
										object obj4 = default(object);
										object obj3 = obj4 * UIHelper.JS_MAGIC_SCALE_NUMBER;
										object obj5 = obj3 + obj3;
										if ((object)rectTransform != null)
										{
											rectTransform.sizeDelta = sizeDelta;
											goto IL_04c3;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_053e;
		IL_053e:
		throw new NullReferenceException();
		IL_04c3:
		string text2 = achievementData._003CarcanaToUnlock_003Ek__BackingField;
		if (achievementData._003CarcanaToUnlock_003Ek__BackingField == null || text2._stringLength > 0)
		{
		}
		RectTransform rectTransform2 = component.rectTransform;
		AchievementDataUI sprite3 = (AchievementDataUI)(object)component.m_Sprite;
		if ((object)component.m_Sprite != null)
		{
			bool flag9 = ((UnityEngine.Object)sprite3).m_CachedPtr == (IntPtr)0;
			Sprite.get_rect_Injected(((UnityEngine.Object)sprite3).m_CachedPtr, out ret2);
			Localize sprite4 = (Localize)(object)component.m_Sprite;
			if ((object)component.m_Sprite != null)
			{
				bool flag10 = ((UnityEngine.Object)sprite4).m_CachedPtr == (IntPtr)0;
				Sprite.get_rect_Injected(((UnityEngine.Object)sprite4).m_CachedPtr, out ret);
				if ((object)rectTransform2 != null)
				{
					rectTransform2.sizeDelta = sizeDelta;
					return;
				}
			}
		}
		goto IL_053e;
	}

	protected override void OnSelected()
	{
		//IL_00c3: Expected I, but got O
		//IL_00d3: Expected O, but got I
		//IL_00e3: Expected O, but got I
		//IL_0050: Expected I, but got O
		//IL_006a: Expected O, but got I
		//IL_007a: Expected O, but got I
		AchievementsPage page = _page;
		AchievementData data;
		Localize descriptionText;
		if (!_isAdventureAchievement)
		{
			data = _data;
			descriptionText = page._DescriptionText;
			nint num = (nint)data;
			AchievementType type = _type;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ r8_v7 (Il2CppClass<VampireSurvivors.Achievements.AchievementData>)+178]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ r8_v7 (Il2CppClass<VampireSurvivors.Achievements.AchievementData>)+180]");
			object obj2 = 0;
		}
		else
		{
			data = _data;
			descriptionText = page._DescriptionText;
			nint num2 = (nint)data;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ r8_v5 (Il2CppClass<VampireSurvivors.Achievements.AchievementData>)+188]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ r8_v5 (Il2CppClass<VampireSurvivors.Achievements.AchievementData>)+190]");
			object obj2 = 0;
			AchievementType type = (AchievementType)_adventureType;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v112 @ rax_v1 (should have been resolved before IL gen)");
		string term = default(string);
		descriptionText.Term = term;
		page.UpdateInfoDisplay(data);
	}

	private void SetSprite()
	{
		Sprite spriteForAchievement = GetSpriteForAchievement(_data);
		Icon.sprite = spriteForAchievement;
		AchievementData data = _data;
		int num = data._003CgoldPrize_003Ek__BackingField ^ data._003CgoldPrize_003Ek__BackingField;
		int num2 = data._003CgoldPrize_003Ek__BackingField & num;
		bool flag = num2 < 0;
		bool flag2 = data._003CgoldPrize_003Ek__BackingField < 0;
		bool flag3 = data._003CgoldPrize_003Ek__BackingField == 0;
		bool flag4 = flag2 == flag;
		bool flag5 = !flag3;
		bool active = flag5 & flag4;
		Moneybag.SetActive(active);
	}

	public bool IsCompleted()
	{
		//IL_0041: Expected I4, but got O
		AchievementData data = _data;
		if (_data != null)
		{
			return data._003Cachieved_003Ek__BackingField;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private unsafe Sprite GetSpriteForAchievement(AchievementData bad)
	{
		//IL_01fd: Expected O, but got I
		//IL_02da: Expected O, but got I
		//IL_0212: Expected O, but got I
		//IL_02ef: Expected O, but got I
		//IL_0227: Expected O, but got I
		//IL_0237: Expected O, but got I
		//IL_07f6: Expected O, but got I
		//IL_0806: Expected O, but got I
		//IL_0585: Expected O, but got I
		//IL_0458: Expected O, but got I
		//IL_0304: Expected O, but got I
		//IL_059a: Expected O, but got I
		//IL_046d: Expected O, but got I
		//IL_095c: Expected O, but got I
		//IL_08a9: Expected O, but got I
		//IL_05af: Expected O, but got I
		//IL_0482: Expected O, but got I
		//IL_034d: Expected O, but got I
		//IL_08be: Expected O, but got I
		//IL_0a08: Expected O, but got I
		//IL_08d3: Expected O, but got I
		//IL_04cb: Expected O, but got I
		//IL_0a1d: Expected O, but got I
		//IL_0748: Expected I, but got O
		//IL_0a32: Expected O, but got I
		//IL_0735: Expected I, but got O
		//IL_062f: Expected O, but got I
		//IL_070e: Expected O, but got I
		//IL_06b4: Expected I8, but got I4
		//IL_06be: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c3: Expected Ref, but got Unknown
		//IL_06e0: Expected I, but got I8
		//IL_06f0: Expected O, but got I
		string text3;
		string textureName;
		bool ignoreExtension;
		if (_isAdventureAchievement)
		{
			AdventureProgressData adventureProgressData = bad._003CadventureUnlockData_003Ek__BackingField;
			string text = adventureProgressData._003CIconSpriteName_003Ek__BackingField;
			if (adventureProgressData._003CIconSpriteName_003Ek__BackingField != null && text._stringLength > 0)
			{
				string text2 = adventureProgressData._003CIconTextureName_003Ek__BackingField;
				if (adventureProgressData._003CIconTextureName_003Ek__BackingField != null && text2._stringLength > 0)
				{
					text3 = adventureProgressData._003CIconSpriteName_003Ek__BackingField;
					textureName = adventureProgressData._003CIconTextureName_003Ek__BackingField;
					ignoreExtension = true;
					goto IL_0cf1;
				}
			}
		}
		string text4 = bad._003CweaponToUnlock_003Ek__BackingField;
		bool flag = bad._003CweaponToUnlock_003Ek__BackingField == null;
		string text5 = "";
		text3 = "";
		if (!flag)
		{
			bool flag2 = text4._stringLength <= 0;
			text5 = "";
			text3 = "";
			if (!flag2)
			{
				Dictionary<WeaponType, List<WeaponData>> convertedWeapons = _dataManager.GetConvertedWeapons();
				WeaponType key = Enum.Parse<WeaponType>(bad._003CweaponToUnlock_003Ek__BackingField);
				object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item((System.Int32Enum)key);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rax_v93 (System.Object)+18]");
				if ((nint)0 <= (nint)0)
				{
					goto IL_0b03;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rax_v93 (System.Object)+10]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rax_v94+20]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rsi_v40+40]");
				text3 = (string)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rsi_v40+38]");
				text5 = (string)0;
			}
		}
		string text6 = bad._003CcharacterToUnlock_003Ek__BackingField;
		if (bad._003CcharacterToUnlock_003Ek__BackingField == null || text6._stringLength <= 0)
		{
			goto IL_0b0d;
		}
		Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = _dataManager.GetConvertedCharacterData();
		CharacterType key2 = Enum.Parse<CharacterType>(bad._003CcharacterToUnlock_003Ek__BackingField);
		object obj4 = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)key2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rax_v86 (System.Object)+18]");
		if ((nint)0 <= (nint)0)
		{
			goto IL_0b03;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rax_v86 (System.Object)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rax_v87+20]");
		object obj6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rdi_v42+60]");
		string text7 = (string)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rdi_v42+60]");
		if ((nint)0 != 0)
		{
			bool flag3 = text7._stringLength > 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rdi_v42+60]");
			text3 = (string)0;
			if (flag3)
			{
				goto IL_0b3c;
			}
		}
		text3 = "QuestionMark.png";
		goto IL_0b3c;
		IL_0b03:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		Sprite result = default(Sprite);
		return result;
		IL_0b87:
		string text8 = bad._003CrelicToUnlock_003Ek__BackingField;
		if (bad._003CrelicToUnlock_003Ek__BackingField != null && text8._stringLength > 0)
		{
			DataManager dataManager = _dataManager;
			ItemType key3 = Enum.Parse<ItemType>(bad._003CrelicToUnlock_003Ek__BackingField);
			object obj7 = ((Dictionary<System.Int32Enum, object>)(object)dataManager._003CAllItems_003Ek__BackingField).get_Item((System.Int32Enum)key3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rax_v50 (System.Object)+38]");
			text3 = (string)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rax_v50 (System.Object)+30]");
			text5 = (string)0;
		}
		string text9 = bad._003CpowerUpToUnlock_003Ek__BackingField;
		if (bad._003CpowerUpToUnlock_003Ek__BackingField != null && text9._stringLength > 0)
		{
			Dictionary<PowerUpType, List<PowerUpData>> convertedPowerUpData = _dataManager.GetConvertedPowerUpData();
			PowerUpType key4 = Enum.Parse<PowerUpType>(bad._003CpowerUpToUnlock_003Ek__BackingField);
			object obj8 = ((Dictionary<System.Int32Enum, object>)(object)convertedPowerUpData).get_Item((System.Int32Enum)key4);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ rax_v44 (System.Object)+18]");
			if ((nint)0 <= (nint)0)
			{
				goto IL_0b03;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ rax_v44 (System.Object)+10]");
			object obj9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ rax_v45+20]");
			object obj10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rdi_v25+38]");
			text3 = (string)0;
			text5 = "items";
		}
		string text10 = bad._003CarcanaToUnlock_003Ek__BackingField;
		if (bad._003CarcanaToUnlock_003Ek__BackingField != null && text10._stringLength > 0)
		{
			DataManager dataManager2 = _dataManager;
			ArcanaType key5 = Enum.Parse<ArcanaType>(bad._003CarcanaToUnlock_003Ek__BackingField);
			object obj11 = ((Dictionary<System.Int32Enum, object>)(object)dataManager2._003CAllArcanas_003Ek__BackingField).get_Item((System.Int32Enum)key5);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rax_v39 (System.Object)+40]");
			text3 = (string)0;
			text5 = "items";
		}
		string text11 = bad._003CweaponIcon_003Ek__BackingField;
		if (bad._003CweaponIcon_003Ek__BackingField != null && text11._stringLength > 0)
		{
			Dictionary<WeaponType, List<WeaponData>> convertedWeapons2 = _dataManager.GetConvertedWeapons();
			WeaponType key6 = Enum.Parse<WeaponType>(bad._003CweaponIcon_003Ek__BackingField);
			object obj12 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons2).get_Item((System.Int32Enum)key6);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rax_v33 (System.Object)+18]");
			if ((nint)0 <= (nint)0)
			{
				goto IL_0b03;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rax_v33 (System.Object)+10]");
			object obj13 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rax_v34+20]");
			object obj14 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rdi_v20+40]");
			text3 = (string)0;
			text5 = "items";
		}
		if (text3 == null || text3._stringLength <= 0)
		{
			text5 = "UI";
			text3 = "QuestionMark.png";
		}
		string text12 = bad._003CforcedTexture_003Ek__BackingField;
		if (bad._003CforcedTexture_003Ek__BackingField != null && text12._stringLength > 0)
		{
			text3 = bad._003CforcedFrameName_003Ek__BackingField;
			text5 = bad._003CforcedTexture_003Ek__BackingField;
		}
		textureName = text5;
		ignoreExtension = true;
		goto IL_0cf1;
		IL_0b79:
		text5 = "UI";
		goto IL_0b4a;
		IL_0bb6:
		if (_isAdventureAchievement)
		{
			nint num = (nint)typeof(AdventureAchievementType);
		}
		else
		{
			nint num = (nint)typeof(AchievementType);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		string text13 = default(string);
		if (text13 != null)
		{
			text13 = text13.ToString();
		}
		string message = "Type : " + text13;
		Debug.Log(message);
		goto IL_076d;
		IL_0b3c:
		text5 = "UI";
		goto IL_0b0d;
		IL_0b4a:
		string text14 = bad._003ChyperToUnlock_003Ek__BackingField;
		if (bad._003ChyperToUnlock_003Ek__BackingField == null || text14._stringLength <= 0)
		{
			goto IL_0b87;
		}
		Dictionary<StageType, List<StageData>> convertedStages = _dataManager.GetConvertedStages();
		StageType key7 = Enum.Parse<StageType>(bad._003ChyperToUnlock_003Ek__BackingField);
		object obj15 = ((Dictionary<System.Int32Enum, object>)(object)convertedStages).get_Item((System.Int32Enum)key7);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rax_v55 (System.Object)+18]");
		if ((nint)0 <= (nint)0)
		{
			goto IL_0b03;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rax_v55 (System.Object)+10]");
		object obj16 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rax_v56+20]");
		object obj17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rsi_v28+58]");
		string text15 = (string)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rsi_v28+58]");
		if ((nint)0 != 0 && text15._stringLength > 0)
		{
			object obj18 = "QuestionMark.png";
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rsi_v28+58]");
			bool flag4 = 0 == unchecked((nint)"QuestionMark.png");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rsi_v28+58]");
			text3 = (string)0;
			if (!flag4)
			{
				if ("QuestionMark.png" != null)
				{
					int stringLength = text15._stringLength;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1699 @ rdx_v35+10]");
					if ((nint)stringLength == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rsi_v28+58]");
						ref byte first = ref *(byte*)((nint)0 + (nint)20);
						ulong num3 = (ulong)(text15._stringLength + text15._stringLength);
						bool flag5 = System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("QuestionMark.png" + 20), num3);
						num2 = (nint)num3;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rsi_v28+58]");
						text3 = (string)0;
						if (flag5)
						{
							goto IL_0bb6;
						}
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rsi_v28+58]");
				text3 = (string)0;
				goto IL_076d;
			}
		}
		else
		{
			nint num2 = 0;
			text3 = "QuestionMark.png";
		}
		goto IL_0bb6;
		IL_076d:
		text5 = "UI";
		goto IL_0b87;
		IL_0cf1:
		return SpriteManager.GetSprite(text3, textureName, ignoreExtension);
		IL_0b0d:
		string text16 = bad._003CstageToUnlock_003Ek__BackingField;
		if (bad._003CstageToUnlock_003Ek__BackingField != null && text16._stringLength > 0)
		{
			string text17 = bad._003ChyperToUnlock_003Ek__BackingField;
			if (bad._003ChyperToUnlock_003Ek__BackingField == null || text17._stringLength <= 0)
			{
				Dictionary<StageType, List<StageData>> convertedStages2 = _dataManager.GetConvertedStages();
				StageType key8 = Enum.Parse<StageType>(bad._003CstageToUnlock_003Ek__BackingField);
				object obj19 = ((Dictionary<System.Int32Enum, object>)(object)convertedStages2).get_Item((System.Int32Enum)key8);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rax_v79 (System.Object)+18]");
				if ((nint)0 <= (nint)0)
				{
					goto IL_0b03;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rax_v79 (System.Object)+10]");
				object obj20 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rax_v80+20]");
				object obj21 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rdi_v36+60]");
				string text18 = (string)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rdi_v36+60]");
				if ((nint)0 != 0)
				{
					bool flag6 = text18._stringLength > 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rdi_v36+60]");
					text3 = (string)0;
					if (flag6)
					{
						goto IL_0b79;
					}
				}
				text3 = "QuestionMark.png";
				goto IL_0b79;
			}
		}
		goto IL_0b4a;
	}

	public AchievementDataUI()
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
