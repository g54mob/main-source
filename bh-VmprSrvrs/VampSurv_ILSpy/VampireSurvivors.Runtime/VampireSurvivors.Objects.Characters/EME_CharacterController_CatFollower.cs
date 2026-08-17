using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.UI.Player;

namespace VampireSurvivors.Objects.Characters;

public class EME_CharacterController_CatFollower : CharacterController
{
	private List<WeaponType> hiddenWeaponTypes;

	private WeaponType _chosenWeapon;

	protected const string EmeraldsTextureName = "character_eme_witch";

	private bool _randomiseColour;

	private float RingLevelUpEveyXLevels;

	private List<Sprite> idleAnim;

	public override void AfterFullInitialization()
	{
		base.AfterFullInitialization();
		HealthBar healthBar = RenderingExtensions.SetScale(base._healthBar, 0.00125f);
		base._spriteTrail.Reset();
		SpriteTrail spriteTrail = base._spriteTrail;
		spriteTrail._MaxHistory = 0;
		spriteTrail.InitialiseGhosts(expandExisting: true);
		SpriteOutlinerControl multiplayerOutliner = base._multiplayerOutliner;
		multiplayerOutliner._outlineOffsetNegative = true;
	}

	public override void LevelUp()
	{
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Expected I4, but got Unknown
		//IL_00b4: Expected I, but got O
		//IL_00bd: Expected O, but got I4
		//IL_00c6: Expected O, but got I4
		//IL_0153: Expected I, but got O
		//IL_015b: Expected I, but got O
		//IL_016b: Expected O, but got I
		//IL_01eb: Expected O, but got I4
		//IL_01a7: Expected O, but got I
		//IL_01dd: Expected O, but got I4
		//IL_0322: Unknown result type (might be due to invalid IL or missing references)
		//IL_0327: Expected O, but got Unknown
		//IL_0251: Invalid comparison between F4 and I
		//IL_0298: Expected I, but got O
		base.LevelUp();
		CharacterWeaponsManager weaponsManager = base._weaponsManager;
		Predicate<Equipment> match = delegate(Equipment x)
		{
			//IL_0053: Expected I4, but got O
			//IL_0031: Expected O, but got I4
			if ((object)x == null)
			{
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			object obj8 = x._equipmentType - _chosenWeapon;
			return obj8 == null;
		};
		List<object> list = ((List<object>)(object)((EquipmentManager)weaponsManager)._003CHiddenEquipment_003Ek__BackingField).FindAll((Predicate<object>)match);
		List<Equipment> list2 = ((EquipmentManager)weaponsManager)._003CHiddenEquipment_003Ek__BackingField.FindAll(match);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 0000000187656895h\"");
		if (base._level != 0)
		{
			return;
		}
		int num = (int)(base._level / RingLevelUpEveyXLevels);
		List<Equipment> list3 = ((EquipmentManager)weaponsManager)._003CHiddenEquipment_003Ek__BackingField.FindAll(match);
		float num2 = (float)num + 1f;
		nint num3 = unchecked((nint)null);
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			if ((nint)obj2 >= list._size)
			{
				return;
			}
			if ((nint)obj >= list._size)
			{
				break;
			}
			object[] items = list._items;
			object obj3 = items[obj];
			object obj4;
			if (items[obj] == null)
			{
				obj4 = null;
				goto IL_02fc;
			}
			nint num4 = (nint)typeof(Weapon);
			num3 = (nint)obj3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v310 @ rdx_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ r9_v5 (Il2CppClass<System.Object>)+130]");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v310 @ rdx_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
			object obj7;
			if (num5 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ r9_v5 (Il2CppClass<System.Object>)+C8]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v367 @ rax_v37+FFFFFFF8+v312 @ rax_v33*8]");
				if (0 == (nint)typeof(Weapon))
				{
					obj7 = 1;
					goto IL_02d4;
				}
			}
			obj7 = 0;
			goto IL_02d4;
			IL_02d4:
			bool flag = obj7 == null;
			obj4 = null;
			if (!flag)
			{
				obj4 = items[obj];
			}
			goto IL_02fc;
			IL_02fc:
			if (obj4 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ rbx_v6 (System.Object)+10]");
				if ((nint)0 != 0)
				{
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ rbx_v6 (System.Object)+4C]");
					if (num2 > 0f)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ rbx_v6 (System.Object)+4C]");
						if ((nint)0 < (nint)8)
						{
							nint num6 = (nint)obj4;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v517 @ rax_v26 (Il2CppClass<System.Object>)+3C8] (should have been resolved before IL gen)");
						}
					}
				}
			}
			obj++;
			obj2 = obj;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw new NullReferenceException();
	}

	protected unsafe override void SetCharacterSprite()
	{
		List<Sprite> catIdleAnimation = GetCatIdleAnimation();
		idleAnim = catIdleAnimation;
		if (idleAnim != null)
		{
			List<Sprite> list = idleAnim;
			bool flag = list._size <= 0;
			Sprite[] items = list._items;
			_CharacterRenderer.sprite = items[0];
			Sprite sprite = _CharacterRenderer.sprite;
			bool flag2 = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
			Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out Rect ret);
			Transform transform = base._healthBar.transform;
			bool flag3 = (object)transform == null;
			bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Transform.set_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&ret));
		}
		else
		{
			Debug.Log("No idle animation");
		}
	}

	protected override void SetupAnimation()
	{
		if (idleAnim != null)
		{
			List<Sprite> list = idleAnim;
			if (list._size > 0)
			{
				bool shouldLoop = default(bool);
				bool startRandomFrame = default(bool);
				Action onComplete = default(Action);
				bool autoSetAnimation = default(bool);
				_spriteAnimation.AddAnimation("walk", idleAnim, 8, shouldLoop, startRandomFrame, onComplete, autoSetAnimation);
				_spriteAnimation.SetAnimation("walk");
				_currentAnimation = CharAnimationType.walk;
				base.CurrentWalkAnimName = "walk";
				base.OnStop();
			}
		}
	}

	protected override void AddAttackAnimations()
	{
		if (idleAnim != null)
		{
			SpriteAnimation spriteAnimation = _spriteAnimation;
			if ((object)_spriteAnimation != null && ((UnityEngine.Object)spriteAnimation).m_CachedPtr != (IntPtr)0)
			{
				bool shouldLoop = default(bool);
				bool startRandomFrame = default(bool);
				Action onComplete = default(Action);
				bool autoSetAnimation = default(bool);
				_spriteAnimation.AddAnimation("idle", idleAnim, 4, shouldLoop, startRandomFrame, onComplete, autoSetAnimation);
				_hasIdleAnimation = true;
			}
		}
	}

	private List<Sprite> GetCatIdleAnimation()
	{
		//IL_01cc: Expected O, but got I
		//IL_01dc: Expected O, but got I
		//IL_01fc: Expected O, but got I4
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5F00]");
		bool flag = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rax_v2+B8]");
		object obj2 = 0;
		string animName = (string)obj2;
		ItemType catType = GetCatType();
		object obj3 = catType - 101;
		if (!flag)
		{
			object obj4 = obj3 - 1;
			if (!flag)
			{
				object obj5 = obj4 - 1;
				if (!flag)
				{
					object obj6 = obj5 - 1;
					if (!flag)
					{
						if ((nint)obj6 != 1)
						{
							Debug.LogError("Item type isn't a cat!");
						}
						else
						{
							_chosenWeapon = WeaponType.EME_RING_FIRE;
							animName = "eme_cat_red_i0";
						}
					}
					else
					{
						_chosenWeapon = WeaponType.EME_RING_METAL;
						animName = "eme_cat_white_i0";
					}
				}
				else
				{
					_chosenWeapon = WeaponType.EME_RING_WATER;
					animName = "eme_cat_black_i0";
				}
			}
			else
			{
				_chosenWeapon = WeaponType.EME_RING_WOOD;
				animName = "eme_cat_blue_i0";
			}
		}
		else
		{
			_chosenWeapon = WeaponType.EME_RING_EARTH;
			animName = "eme_cat_yellow_i0";
		}
		int num = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames(animName, 1, 4, "character_eme_witch", num);
		GameManager core = GM.Core;
		if ((object)GM.Core != null && core._weaponsFacade != null)
		{
			Weapon weapon = core._weaponsFacade.AddHiddenWeapon(_chosenWeapon, this, removeFromStore: true, (byte)num != 0);
			return animationFrames;
		}
		return (List<Sprite>)(object)new NullReferenceException();
	}

	protected virtual ItemType GetCatType()
	{
		//IL_00c9: Expected O, but got I4
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected O, but got Unknown
		if (_randomiseColour)
		{
			object obj = UnityEngine.Random.RandomRangeInt(0, 5);
			bool flag = obj == null;
			if (!flag)
			{
				object obj2 = obj - 1;
				if (flag)
				{
					return ItemType.EME_CATB;
				}
				object obj3 = obj2 - 1;
				if (flag)
				{
					return ItemType.EME_CATR;
				}
				object obj4 = obj3 - 1;
				if (flag)
				{
					return ItemType.EME_CATW;
				}
				if ((nint)obj4 == 1)
				{
					goto IL_0098;
				}
			}
			return ItemType.EME_CATU;
		}
		goto IL_0098;
		IL_0098:
		return ItemType.EME_CATY;
	}

	public EME_CharacterController_CatFollower()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_02b7: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_02df: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_0307: Expected O, but got I
		//IL_01c0: Expected O, but got I
		//IL_032f: Expected O, but got I
		//IL_022a: Expected O, but got I
		List<WeaponType> list = new List<WeaponType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rdx_v4+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)409);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 409;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rdx_v6+18]");
		if (num2 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)407);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 407;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rdx_v8+18]");
		if (num3 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)411);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 411;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rdx_v10+18]");
		if (num4 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)408);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 408;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rdx_v12+18]");
		if (num5 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)410);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 410;
		}
		hiddenWeaponTypes = list;
		_chosenWeapon = WeaponType.EME_RING_FIRE;
		_randomiseColour = true;
		RingLevelUpEveyXLevels = 7f;
		idleAnim = new List<Sprite>();
		base._002Ector();
	}

	private bool _003CLevelUp_003Eb__7_0(Equipment x)
	{
		//IL_0053: Expected I4, but got O
		//IL_0031: Expected O, but got I4
		if ((object)x != null)
		{
			object obj = x._equipmentType - _chosenWeapon;
			return obj == null;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	internal static ItemType _003CGetCatType_003Eg__RandomCatType_007C12_0()
	{
		//IL_00aa: Expected O, but got I4
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		object obj = UnityEngine.Random.RandomRangeInt(0, 5);
		bool flag = obj == null;
		if (!flag)
		{
			object obj2 = obj - 1;
			if (flag)
			{
				return ItemType.EME_CATB;
			}
			object obj3 = obj2 - 1;
			if (flag)
			{
				return ItemType.EME_CATR;
			}
			object obj4 = obj3 - 1;
			if (flag)
			{
				return ItemType.EME_CATW;
			}
			if ((nint)obj4 == 1)
			{
				return ItemType.EME_CATY;
			}
		}
		return ItemType.EME_CATU;
	}
}
