using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Achievements;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Data.PowerUp;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Data;

public class SecretData
{
	private string _003Cdescription_003Ek__BackingField;

	private CharacterType? _003CcharacterToUnlock_003Ek__BackingField;

	private WeaponType? _003CweaponToUnlock_003Ek__BackingField;

	private StageType? _003CstageToUnlock_003Ek__BackingField;

	private StageType? _003ChyperToUnlock_003Ek__BackingField;

	private ItemType? _003CrelicToUnlock_003Ek__BackingField;

	private ArcanaType? _003CarcanaToUnlock_003Ek__BackingField;

	private PowerUpType? _003CpowerUpToUnlock_003Ek__BackingField;

	private bool _003Cmistery_003Ek__BackingField;

	private bool _003Cachieved_003Ek__BackingField;

	private bool _003CisSpell_003Ek__BackingField;

	private string _003Cspell_003Ek__BackingField;

	private string _003Cspecial_003Ek__BackingField;

	private bool _003Chidden_003Ek__BackingField;

	private int? _003CgoldPrize_003Ek__BackingField;

	private bool _003CisModifier_003Ek__BackingField;

	private List<SkinToUnlock> _003CskinsToUnlock_003Ek__BackingField;

	private List<WeaponType> _003CweaponListToUnlock_003Ek__BackingField;

	private ItemType? _003CrequiresRelic_003Ek__BackingField;

	private string _003CcustomTexture_003Ek__BackingField;

	private string _003CcustomFrame_003Ek__BackingField;

	private string _003CcustomSmallTexture_003Ek__BackingField;

	private string _003CcustomSmallFrame_003Ek__BackingField;

	private const string _prefix = "secretLang/";

	public string description
	{
		get
		{
			return _003Cdescription_003Ek__BackingField;
		}
		set
		{
			_003Cdescription_003Ek__BackingField = value;
		}
	}

	public CharacterType? characterToUnlock
	{
		get
		{
			return _003CcharacterToUnlock_003Ek__BackingField;
		}
		set
		{
			_003CcharacterToUnlock_003Ek__BackingField = value;
		}
	}

	public WeaponType? weaponToUnlock
	{
		get
		{
			return _003CweaponToUnlock_003Ek__BackingField;
		}
		set
		{
			_003CweaponToUnlock_003Ek__BackingField = value;
		}
	}

	public StageType? stageToUnlock
	{
		get
		{
			return _003CstageToUnlock_003Ek__BackingField;
		}
		set
		{
			_003CstageToUnlock_003Ek__BackingField = value;
		}
	}

	public StageType? hyperToUnlock
	{
		get
		{
			return _003ChyperToUnlock_003Ek__BackingField;
		}
		set
		{
			_003ChyperToUnlock_003Ek__BackingField = value;
		}
	}

	public ItemType? relicToUnlock
	{
		get
		{
			return _003CrelicToUnlock_003Ek__BackingField;
		}
		set
		{
			_003CrelicToUnlock_003Ek__BackingField = value;
		}
	}

	public ArcanaType? arcanaToUnlock
	{
		get
		{
			return _003CarcanaToUnlock_003Ek__BackingField;
		}
		set
		{
			_003CarcanaToUnlock_003Ek__BackingField = value;
		}
	}

	public PowerUpType? powerUpToUnlock
	{
		get
		{
			return _003CpowerUpToUnlock_003Ek__BackingField;
		}
		set
		{
			_003CpowerUpToUnlock_003Ek__BackingField = value;
		}
	}

	public bool mistery
	{
		get
		{
			return _003Cmistery_003Ek__BackingField;
		}
		set
		{
			_003Cmistery_003Ek__BackingField = value;
		}
	}

	public bool achieved
	{
		get
		{
			return _003Cachieved_003Ek__BackingField;
		}
		set
		{
			_003Cachieved_003Ek__BackingField = value;
		}
	}

	public bool isSpell
	{
		get
		{
			return _003CisSpell_003Ek__BackingField;
		}
		set
		{
			_003CisSpell_003Ek__BackingField = value;
		}
	}

	public string spell
	{
		get
		{
			return _003Cspell_003Ek__BackingField;
		}
		set
		{
			_003Cspell_003Ek__BackingField = value;
		}
	}

	public string special
	{
		get
		{
			return _003Cspecial_003Ek__BackingField;
		}
		set
		{
			_003Cspecial_003Ek__BackingField = value;
		}
	}

	public bool hidden
	{
		get
		{
			return _003Chidden_003Ek__BackingField;
		}
		set
		{
			_003Chidden_003Ek__BackingField = value;
		}
	}

	public int? goldPrize
	{
		get
		{
			return _003CgoldPrize_003Ek__BackingField;
		}
		set
		{
			_003CgoldPrize_003Ek__BackingField = value;
		}
	}

	public bool isModifier
	{
		get
		{
			return _003CisModifier_003Ek__BackingField;
		}
		set
		{
			_003CisModifier_003Ek__BackingField = value;
		}
	}

	public List<SkinToUnlock> skinsToUnlock
	{
		get
		{
			return _003CskinsToUnlock_003Ek__BackingField;
		}
		set
		{
			_003CskinsToUnlock_003Ek__BackingField = value;
		}
	}

	public List<WeaponType> weaponListToUnlock
	{
		get
		{
			return _003CweaponListToUnlock_003Ek__BackingField;
		}
		set
		{
			_003CweaponListToUnlock_003Ek__BackingField = value;
		}
	}

	public ItemType? requiresRelic
	{
		get
		{
			return _003CrequiresRelic_003Ek__BackingField;
		}
		set
		{
			_003CrequiresRelic_003Ek__BackingField = value;
		}
	}

	public string customTexture
	{
		get
		{
			return _003CcustomTexture_003Ek__BackingField;
		}
		set
		{
			_003CcustomTexture_003Ek__BackingField = value;
		}
	}

	public string customFrame
	{
		get
		{
			return _003CcustomFrame_003Ek__BackingField;
		}
		set
		{
			_003CcustomFrame_003Ek__BackingField = value;
		}
	}

	public string customSmallTexture
	{
		get
		{
			return _003CcustomSmallTexture_003Ek__BackingField;
		}
		set
		{
			_003CcustomSmallTexture_003Ek__BackingField = value;
		}
	}

	public string customSmallFrame
	{
		get
		{
			return _003CcustomSmallFrame_003Ek__BackingField;
		}
		set
		{
			_003CcustomSmallFrame_003Ek__BackingField = value;
		}
	}

	public Sprite GetSecondReward(DataManager dataManager)
	{
		//IL_0671: Expected I4, but got O
		//IL_05a8: Expected I4, but got O
		//IL_06bf: Expected O, but got I
		//IL_06d4: Expected O, but got I
		//IL_04da: Expected I4, but got O
		//IL_06e9: Expected O, but got I
		//IL_06f9: Expected O, but got I
		//IL_05f6: Expected O, but got I
		//IL_060b: Expected O, but got I
		//IL_044d: Expected I4, but got O
		//IL_0620: Expected O, but got I
		//IL_0630: Expected O, but got I
		//IL_0563: Expected O, but got I
		//IL_0544: Expected O, but got I
		//IL_0489: Expected O, but got I
		//IL_0499: Expected O, but got I
		//IL_03ee: Expected I4, but got O
		//IL_03aa: Expected O, but got I
		//IL_03ba: Expected O, but got I
		//IL_036e: Expected I4, but got O
		//IL_02f2: Expected I4, but got O
		//IL_031d: Expected O, but got I
		//IL_032d: Expected O, but got I
		string spriteName;
		string textureName;
		if ((object)_003CcharacterToUnlock_003Ek__BackingField == null)
		{
			if ((object)_003CweaponToUnlock_003Ek__BackingField == null)
			{
				if ((object)_003CstageToUnlock_003Ek__BackingField == null)
				{
					if ((object)_003ChyperToUnlock_003Ek__BackingField == null)
					{
						if ((object)_003CrelicToUnlock_003Ek__BackingField == null)
						{
							if ((object)_003CpowerUpToUnlock_003Ek__BackingField == null)
							{
								if ((object)_003CarcanaToUnlock_003Ek__BackingField == null)
								{
									if (_003CskinsToUnlock_003Ek__BackingField != null)
									{
										List<SkinToUnlock> list = _003CskinsToUnlock_003Ek__BackingField;
										if (list._size > 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
											Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = dataManager.GetConvertedCharacterData();
											if (convertedCharacterData != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rax_v39+10]");
												object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)0);
												if (obj != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rax_v39+10]");
													List<CharacterData> list2 = ((Dictionary<CharacterType, List<CharacterData>>)obj).get_Item(CharacterType.VOID);
													if (list2 != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rax_v39+14]");
														Skin skinData = ((CharacterData)(object)list2).GetSkinData(SkinType.DEFAULT);
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
																	goto IL_06fe;
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
								if ((object)_003CarcanaToUnlock_003Ek__BackingField != null)
								{
									System.Int32Enum key = (System.Int32Enum)((object?)_003CarcanaToUnlock_003Ek__BackingField >> 32);
									object obj2 = ((Dictionary<System.Int32Enum, object>)(object)dataManager._003CAllArcanas_003Ek__BackingField).get_Item(key);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rax_v35 (System.Object)+40]");
									spriteName = (string)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ rax_v35 (System.Object)+38]");
									textureName = (string)0;
									goto IL_06fe;
								}
							}
							else
							{
								Dictionary<PowerUpType, List<PowerUpData>> convertedPowerUpData = dataManager.GetConvertedPowerUpData();
								if ((object)_003CpowerUpToUnlock_003Ek__BackingField != null)
								{
									System.Int32Enum key2 = (System.Int32Enum)((object?)_003CpowerUpToUnlock_003Ek__BackingField >> 32);
									object obj3 = ((Dictionary<System.Int32Enum, object>)(object)convertedPowerUpData).get_Item(key2);
									List<PowerUpData> list3 = ((Dictionary<PowerUpType, List<PowerUpData>>)obj3).get_Item((PowerUpType)key2);
									goto IL_039a;
								}
							}
						}
						else if ((object)_003CrelicToUnlock_003Ek__BackingField != null)
						{
							System.Int32Enum key3 = (System.Int32Enum)((object?)_003CrelicToUnlock_003Ek__BackingField >> 32);
							object obj4 = ((Dictionary<System.Int32Enum, object>)(object)dataManager._003CAllItems_003Ek__BackingField).get_Item(key3);
							List<PowerUpData> list3 = (List<PowerUpData>)obj4;
							goto IL_039a;
						}
					}
					else
					{
						Dictionary<StageType, List<StageData>> convertedStages = dataManager.GetConvertedStages();
						if ((object)_003ChyperToUnlock_003Ek__BackingField != null)
						{
							System.Int32Enum key4 = (System.Int32Enum)((object?)_003ChyperToUnlock_003Ek__BackingField >> 32);
							object obj5 = ((Dictionary<System.Int32Enum, object>)(object)convertedStages).get_Item(key4);
							List<StageData> list4 = ((Dictionary<StageType, List<StageData>>)obj5).get_Item((StageType)key4);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rax_v29 (System.Collections.Generic.List`1<VampireSurvivors.Data.Stage.StageData>)+58]");
							spriteName = (string)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rax_v29 (System.Collections.Generic.List`1<VampireSurvivors.Data.Stage.StageData>)+40]");
							textureName = (string)0;
							goto IL_06fe;
						}
					}
				}
				else
				{
					Dictionary<StageType, List<StageData>> convertedStages2 = dataManager.GetConvertedStages();
					if ((object)_003CstageToUnlock_003Ek__BackingField != null)
					{
						System.Int32Enum key5 = (System.Int32Enum)((object?)_003CstageToUnlock_003Ek__BackingField >> 32);
						object obj6 = ((Dictionary<System.Int32Enum, object>)(object)convertedStages2).get_Item(key5);
						List<StageData> list5 = ((Dictionary<StageType, List<StageData>>)obj6).get_Item((StageType)key5);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rax_v22 (System.Collections.Generic.List`1<VampireSurvivors.Data.Stage.StageData>)+40]");
						bool flag = (nint)0 == 0;
						string textureName2 = "UI";
						if (!flag)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rax_v22 (System.Collections.Generic.List`1<VampireSurvivors.Data.Stage.StageData>)+40]");
							textureName2 = (string)0;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rax_v22 (System.Collections.Generic.List`1<VampireSurvivors.Data.Stage.StageData>)+58]");
						return SpriteManager.GetSprite((string)0, textureName2);
					}
				}
			}
			else
			{
				Dictionary<WeaponType, List<WeaponData>> convertedWeapons = dataManager.GetConvertedWeapons();
				if ((object)_003CweaponToUnlock_003Ek__BackingField != null)
				{
					System.Int32Enum key6 = (System.Int32Enum)((object?)_003CweaponToUnlock_003Ek__BackingField >> 32);
					object obj7 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons).get_Item(key6);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rax_v18 (System.Object)+18]");
					if ((nint)0 > (nint)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rax_v18 (System.Object)+10]");
						object obj8 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rax_v19+20]");
						object obj9 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rdx_v14+40]");
						spriteName = (string)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rdx_v14+38]");
						textureName = (string)0;
						goto IL_06fe;
					}
					goto IL_074f;
				}
			}
		}
		else
		{
			Dictionary<CharacterType, List<CharacterData>> convertedCharacterData2 = dataManager.GetConvertedCharacterData();
			if ((object)_003CcharacterToUnlock_003Ek__BackingField != null)
			{
				System.Int32Enum key7 = (System.Int32Enum)((object?)_003CcharacterToUnlock_003Ek__BackingField >> 32);
				object obj10 = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData2).get_Item(key7);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rax_v15 (System.Object)+18]");
				if ((nint)0 > (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rax_v15 (System.Object)+10]");
					object obj11 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rax_v16+20]");
					object obj12 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rdx_v10+48]");
					spriteName = (string)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rdx_v10+40]");
					textureName = (string)0;
					goto IL_06fe;
				}
				goto IL_074f;
			}
		}
		goto IL_0740;
		IL_074f:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		goto IL_0740;
		IL_0740:
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		Sprite result = default(Sprite);
		return result;
		IL_06fe:
		return SpriteManager.GetSprite(spriteName, textureName);
		IL_039a:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rax_v31 (System.Collections.Generic.List`1<VampireSurvivors.Data.PowerUp.PowerUpData>)+38]");
		spriteName = (string)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rax_v31 (System.Collections.Generic.List`1<VampireSurvivors.Data.PowerUp.PowerUpData>)+30]");
		textureName = (string)0;
		goto IL_06fe;
	}

	public unsafe string GetLocalizedDescriptionTerm(SecretType t)
	{
		//IL_000e: Expected O, but got Ref
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		return "secretLang/{" + text + "}description";
	}
}
