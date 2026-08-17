using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Stages;

namespace VampireSurvivors.Achievements;

public class Emeralds_CustomAchivementHandleing : ICustomAchievements
{
	[StructLayout((LayoutKind)3)]
	private struct _003C_003Ec__DisplayClass3_0
	{
		public AchievementManager achievementManager;
	}

	private sealed class _003C_003Ec__DisplayClass3_1
	{
		public CharacterType characterType;

		internal bool _003CRunSecretsCheck_003Eb__1(VampireSurvivors.Objects.Characters.CharacterController character)
		{
			//IL_0053: Expected I4, but got O
			//IL_0031: Expected O, but got I4
			if ((object)character != null)
			{
				object obj = character._characterType - characterType;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public List<AchievementType> CheckAchievements(PlayerOptions playerOptions, AchievementManager achievementManager, DataManager dataManager)
	{
		List<AchievementType> list = new List<AchievementType>();
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			GameSessionData gameSessionData = core._gameSessionData;
			if (core._gameSessionData != null)
			{
				VampireSurvivors.Objects.Characters.CharacterController activeCharacter = gameSessionData._activeCharacter;
				if ((object)gameSessionData._activeCharacter != null)
				{
					if (activeCharacter._characterType != CharacterType.EME_MECHKATANA)
					{
						goto IL_0230;
					}
					List<WeaponType> glimmeredTechniques = activeCharacter.GlimmeredTechniques;
					if (activeCharacter.GlimmeredTechniques != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rax_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
						if ((nint)0 >= (nint)7)
						{
							CharacterData currentCharacterData = activeCharacter._currentCharacterData;
							if (activeCharacter._currentCharacterData == null)
							{
								goto IL_0235;
							}
							if (currentCharacterData._003CcurrentSkin_003Ek__BackingField == SkinType.SKIN_EME_D_RETRO)
							{
								if (list == null)
								{
									goto IL_0235;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A994F0");
							}
						}
						List<WeaponType> glimmeredTechniques2 = activeCharacter.GlimmeredTechniques;
						if (activeCharacter.GlimmeredTechniques != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rax_v10 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
							if ((nint)0 >= (nint)11)
							{
								CharacterData currentCharacterData2 = activeCharacter._currentCharacterData;
								if (activeCharacter._currentCharacterData == null)
								{
									goto IL_0235;
								}
								if (currentCharacterData2._003CcurrentSkin_003Ek__BackingField == SkinType.SKIN_EME_D_KATANA)
								{
									if (list == null)
									{
										goto IL_0235;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A994F0");
								}
							}
							goto IL_0230;
						}
					}
				}
			}
		}
		goto IL_0235;
		IL_0235:
		return (List<AchievementType>)(object)new NullReferenceException();
		IL_0230:
		return list;
	}

	public List<AchievementType> GetUnlocksThatNeedFixing(PlayerOptions playerOptions)
	{
		return null;
	}

	public List<AchievementType> CheckForStartupAchievements(PlayerOptions playerOptions)
	{
		return null;
	}

	public unsafe void RunSecretsCheck(AchievementManager achievementManager, PlayerOptions playerOptions, DataManager dataManager)
	{
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected Ref, but got Unknown
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected Ref, but got Unknown
		//IL_029a: Unknown result type (might be due to invalid IL or missing references)
		//IL_029f: Expected Ref, but got Unknown
		//IL_02a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ad: Expected Ref, but got Unknown
		//IL_03a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03aa: Expected Ref, but got Unknown
		//IL_03b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b8: Expected Ref, but got Unknown
		//IL_00c9: Expected O, but got I
		//IL_00e8: Expected O, but got I
		//IL_03f7: Expected O, but got I
		//IL_0107: Expected O, but got I
		//IL_040c: Expected O, but got I
		//IL_0126: Expected O, but got I
		//IL_0145: Expected O, but got I
		//IL_0164: Expected O, but got I
		//IL_0175: Expected O, but got I4
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Expected O, but got Unknown
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Expected O, but got Unknown
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Expected O, but got Unknown
		//IL_01f1: Expected O, but got I
		//IL_01f1: Expected O, but got I
		//IL_05d1: Expected I, but got O
		//IL_05d9: Expected I, but got O
		//IL_05e9: Expected O, but got I
		//IL_0225: Expected O, but got I
		//IL_0225: Expected O, but got I
		//IL_0669: Expected O, but got I4
		//IL_049d: Expected O, but got I
		//IL_049d: Expected O, but got I
		//IL_0625: Expected O, but got I
		//IL_04d1: Expected O, but got I
		//IL_04d1: Expected O, but got I
		//IL_065b: Expected O, but got I4
		_ = 0;
		_ = 0;
		_ = 0;
		PlayerOptionsData config = playerOptions.Config;
		List<ItemType> list = config._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v266 @ rcx_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		if ((nint)0 == 0)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj = default(object);
		if ((nint)obj == -1)
		{
			return;
		}
		object obj2 = default(object);
		bool checkHiddenEquipment = default(bool);
		if (_003CRunSecretsCheck_003Eg__TryGetCharacterFromCurrentCharacters_007C3_0(CharacterType.EME_MAGICALL, out *(VampireSurvivors.Objects.Characters.CharacterController*)(obj2 - 56), ref *(_003C_003Ec__DisplayClass3_0*)(obj2 + 48)))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+30]");
			int pickUpCount = ((AchievementManager)0).GetPickUpCount(ItemType.EME_CATB);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+30]");
			int pickUpCount2 = ((AchievementManager)0).GetPickUpCount(ItemType.EME_CATR);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+30]");
			int pickUpCount3 = ((AchievementManager)0).GetPickUpCount(ItemType.EME_CATW);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+30]");
			int pickUpCount4 = ((AchievementManager)0).GetPickUpCount(ItemType.EME_CATU);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+30]");
			int pickUpCount5 = ((AchievementManager)0).GetPickUpCount(ItemType.EME_CATY);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+30]");
			int pickUpCount6 = ((AchievementManager)0).GetPickUpCount(ItemType.EME_CAT_RAINBOW);
			object obj3 = pickUpCount6 + pickUpCount5;
			object obj4 = obj3 + pickUpCount4;
			object obj5 = obj4 + pickUpCount3;
			object obj6 = obj5 + pickUpCount2;
			object obj7 = obj6 + pickUpCount;
			if ((nint)obj7 >= 30)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+30]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-38]");
				int playerWeaponLevel = ((AchievementManager)num).GetPlayerWeaponLevel((VampireSurvivors.Objects.Characters.CharacterController)0, WeaponType.GATTI, checkRemovedEquipment: true, checkHiddenEquipment);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+30]");
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-38]");
				int playerWeaponLevel2 = ((AchievementManager)num2).GetPlayerWeaponLevel((VampireSurvivors.Objects.Characters.CharacterController)0, WeaponType.STIGRANGATTI, checkRemovedEquipment: true, checkHiddenEquipment);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+30]");
				if ((nint)0 < (nint)0)
				{
					GameManager core = GM.Core;
					PlayerOptionsData config2 = core._playerOptions.Config;
					bool flag = core._playerOptions.UnlockSecret(SecretType.EME_CATS, config2);
				}
			}
		}
		if (_003CRunSecretsCheck_003Eg__TryGetCharacterFromCurrentCharacters_007C3_0(CharacterType.EME_EXGREATSWORD, out *(VampireSurvivors.Objects.Characters.CharacterController*)(obj2 - 48), ref *(_003C_003Ec__DisplayClass3_0*)(obj2 + 48)))
		{
			PlayerOptionsData config3 = playerOptions.Config;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AF20");
			object obj8 = default(object);
			if (obj8 != null)
			{
				GameManager core2 = GM.Core;
				ArcanaManager arcanaManager = core2._arcanaManager;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A968E0");
				object obj9 = default(object);
				if (obj9 != null)
				{
					GameManager core3 = GM.Core;
					PlayerOptionsData config4 = core3._playerOptions.Config;
					bool flag2 = core3._playerOptions.UnlockSecret(SecretType.EME_DEMON, config4);
				}
			}
		}
		if (_003CRunSecretsCheck_003Eg__TryGetCharacterFromCurrentCharacters_007C3_0(CharacterType.EME_MECHKATANA, out *(VampireSurvivors.Objects.Characters.CharacterController*)(obj2 + 56), ref *(_003C_003Ec__DisplayClass3_0*)(obj2 + 48)))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+38]");
			object obj10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rax_v30+110]");
			object obj11 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v257 @ rcx_v23+184]");
			if ((nint)0 == 26)
			{
				PlayerOptionsData config5 = playerOptions.Config;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9AF20");
				object obj12 = default(object);
				if (obj12 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+30]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+38]");
					int playerWeaponLevel3 = ((AchievementManager)num3).GetPlayerWeaponLevel((VampireSurvivors.Objects.Characters.CharacterController)0, WeaponType.SONG, checkRemovedEquipment: true, checkHiddenEquipment);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+30]");
					nint num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+38]");
					int playerWeaponLevel4 = ((AchievementManager)num4).GetPlayerWeaponLevel((VampireSurvivors.Objects.Characters.CharacterController)0, WeaponType.MANNAGGIA, checkRemovedEquipment: true, checkHiddenEquipment);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+30]");
					if ((nint)0 < (nint)0)
					{
						GameManager core4 = GM.Core;
						PlayerOptionsData config6 = core4._playerOptions.Config;
						bool flag3 = core4._playerOptions.UnlockSecret(SecretType.EME_IMAKOO, config6);
					}
				}
			}
		}
		PlayerOptionsData config7 = playerOptions.Config;
		if (config7._003CSelectedStage_003Ek__BackingField != StageType.EMERALD)
		{
			return;
		}
		GameManager core5 = GM.Core;
		Stage stage = core5._stage;
		BackgroundManager fancyBg = stage._fancyBg;
		if ((object)stage._fancyBg == null)
		{
			return;
		}
		nint num5 = (nint)typeof(BackgroundEmerald);
		nint num6 = (nint)fancyBg;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v215 @ r8_v11 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundEmerald>)+130]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ r10_v3 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundManager>)+130]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v215 @ r8_v11 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundEmerald>)+130]");
		object obj15;
		if (num7 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ r10_v3 (Il2CppClass<VampireSurvivors.Objects.Stages.BackgroundManager>)+C8]");
			object obj14 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v935 @ rax_v28+FFFFFFF8+v920 @ rax_v21*8]");
			if (0 == (nint)typeof(BackgroundEmerald))
			{
				obj15 = 1;
				goto IL_0717;
			}
		}
		obj15 = 0;
		goto IL_0717;
		IL_0717:
		bool flag4 = obj15 == null;
		BackgroundManager backgroundManager = null;
		if (!flag4)
		{
			backgroundManager = stage._fancyBg;
		}
		if ((object)backgroundManager != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v706 @ rbx_v5 (VampireSurvivors.Objects.Stages.BackgroundManager)+D4]");
			if ((nint)0 == 0)
			{
				GameManager core6 = GM.Core;
				PlayerOptionsData config8 = core6._playerOptions.Config;
				bool flag5 = core6._playerOptions.UnlockSecret(SecretType.EME_KINA, config8);
			}
		}
	}

	internal unsafe static bool _003CRunSecretsCheck_003Eg__TryGetCharacterFromCurrentCharacters_007C3_0(CharacterType characterType, out VampireSurvivors.Objects.Characters.CharacterController characterController, ref _003C_003Ec__DisplayClass3_0 P_2)
	{
		//IL_00dd: Expected I4, but got O
		//IL_006f: Expected O, but got I
		_003C_003Ec__DisplayClass3_1 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass3_1();
		if (CS_0024_003C_003E8__locals3 != null)
		{
			CS_0024_003C_003E8__locals3.characterType = characterType;
			object obj = P_2;
			if ((object)P_2 != null)
			{
				Func<VampireSurvivors.Objects.Characters.CharacterController, bool> predicate = delegate(VampireSurvivors.Objects.Characters.CharacterController character)
				{
					//IL_0053: Expected I4, but got O
					//IL_0031: Expected O, but got I4
					if ((object)character == null)
					{
						NullReferenceException ex2 = new NullReferenceException();
						return (byte)(int)ex2 != 0;
					}
					object obj3 = character._characterType - CS_0024_003C_003E8__locals3.characterType;
					return obj3 == null;
				};
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rdi_v3+58]");
				object obj2 = Enumerable.FirstOrDefault((IEnumerable<object>)0, (Func<object, bool>)predicate);
				ref VampireSurvivors.Objects.Characters.CharacterController reference = ref *(VampireSurvivors.Objects.Characters.CharacterController*)obj2;
				VampireSurvivors.Objects.Characters.CharacterController characterController2 = characterController;
				if ((object)characterController != null)
				{
					bool flag = ((UnityEngine.Object)characterController2).m_CachedPtr == (IntPtr)0;
					return !flag;
				}
				return false;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}
}
