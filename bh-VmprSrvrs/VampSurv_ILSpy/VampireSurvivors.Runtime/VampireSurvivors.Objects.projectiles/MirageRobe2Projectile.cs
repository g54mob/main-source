using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class MirageRobe2Projectile : MirageRobeProjectile
{
	private SpriteAnimation _spriteAnimation;

	private Color[][] _tints;

	public override float ProjectileSpeed
	{
		get
		{
			float num = _weapon.PSpeed();
			Weapon weapon = _weapon;
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
			CharacterData currentCharacterData = characterController._currentCharacterData;
			float num2 = GameManager.PlayerPxSpeed * currentCharacterData._003CmoveSpeed_003Ek__BackingField;
			object obj = default(object);
			float num3 = num2 * (float)obj;
			return num3 * _speed;
		}
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_00f3: Expected O, but got I
		//IL_0108: Expected O, but got I
		//IL_01b0: Expected I4, but got O
		//IL_033a: Unknown result type (might be due to invalid IL or missing references)
		//IL_033f: Expected O, but got Unknown
		//IL_0356: Unknown result type (might be due to invalid IL or missing references)
		//IL_035b: Expected O, but got Unknown
		//IL_0376: Expected O, but got I8
		//IL_037f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0384: Expected O, but got Unknown
		//IL_0815: Expected O, but got I4
		//IL_0825: Unknown result type (might be due to invalid IL or missing references)
		//IL_082a: Expected O, but got Unknown
		//IL_0433: Expected O, but got I4
		//IL_0433: Expected O, but got Ref
		//IL_0433: Expected O, but got Ref
		//IL_0433: Expected O, but got Ref
		//IL_04a7: Expected O, but got I4
		//IL_04af: Expected O, but got Ref
		//IL_0653: Expected O, but got Ref
		base.InitProjectile(pool, weapon, index);
		_speed = 0.3f;
		GameManager core = GM.Core;
		Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = core._dataManager.GetConvertedCharacterData();
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
		object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)characterController._characterType);
		if (obj == null)
		{
			GameManager core2 = GM.Core;
			Dictionary<CharacterType, List<CharacterData>> convertedCharacterData2 = core2._dataManager.GetConvertedCharacterData();
			obj = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData2).get_Item((System.Int32Enum)1);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v492 @ rax_v26 (System.Object)+18]");
		string textureName;
		string text;
		int end;
		int fps;
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v492 @ rax_v26 (System.Object)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ rcx_v20+20]");
			CharacterData characterData = (CharacterData)0;
			if (characterData._003Cskins_003Ek__BackingField == null)
			{
				textureName = characterData._003CtextureName_003Ek__BackingField;
				text = characterData._003CspriteName_003Ek__BackingField;
				end = characterData._003CwalkingFrames_003Ek__BackingField;
				if ((object)characterData._003CwalkFrameRate_003Ek__BackingField != null)
				{
					if ((object)characterData._003CwalkFrameRate_003Ek__BackingField != null)
					{
						fps = (object?)characterData._003CwalkFrameRate_003Ek__BackingField >> 32;
						goto IL_01f3;
					}
					System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
					throw new NullReferenceException();
				}
			}
			else
			{
				Skin currentSkinData = characterData.GetCurrentSkinData();
				textureName = currentSkinData._003CtextureName_003Ek__BackingField;
				text = currentSkinData._003CspriteName_003Ek__BackingField;
				end = currentSkinData._003CwalkingFrames_003Ek__BackingField;
			}
			fps = 8;
			goto IL_01f3;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		return;
		IL_01f3:
		string animName = text.Replace("01.png", "");
		int num = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames(animName, 1, end, textureName, num);
		SpriteAnimation spriteAnimation = _spriteAnimation;
		if ((object)_spriteAnimation == null || ((UnityEngine.Object)spriteAnimation).m_CachedPtr == (IntPtr)0)
		{
			GameObject gameObject = _renderer.gameObject;
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1038 @ rdi_v19 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
			SpriteAnimation spriteAnimation2 = ((!gameObject.TryGetComponent<SpriteAnimation>(out var component)) ? gameObject.AddComponent<SpriteAnimation>() : component);
			_spriteAnimation = spriteAnimation2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
			if ((nint)0 != 0)
			{
				object obj3 = this + 248;
				object obj4 = obj3 >> 12;
				object obj5 = obj4 & 0x1FFFFF;
				object obj6 = obj5 >> 6;
				object obj7 = 6603577472L;
				object obj8 = obj5 & 0x3F;
				nint num4;
				do
				{
					object obj9 = 1 << (int)obj8;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1459 @ rdi_v20+462E0+v1435 @ rdx_v44*8]");
					object obj10 = 0 | obj9;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1459 @ rdi_v20+462E0+v1435 @ rdx_v44*8]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1459 @ rdi_v20+462E0+v1435 @ rdx_v44*8]");
					if (num3 == 0)
					{
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1459 @ rdi_v20+462E0+v1435 @ rdx_v44*8]");
					num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1459 @ rdi_v20+462E0+v1435 @ rdx_v44*8]");
				}
				while (num4 != 0);
			}
		}
		_spriteAnimation.CleanAnimations();
		bool flag = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		_spriteAnimation.AddAnimation("walk", animationFrames, fps, (byte)num != 0, flag, onComplete, autoSetAnimation);
		_spriteAnimation.SetAnimation("walk");
		CheckRenderer();
		Color color = default(Color);
		Color color2 = default(Color);
		Color color3 = default(Color);
		SpriteRenderer spriteRenderer = RenderingExtensions.SetTint(((ArcadeSprite)this)._spriteRenderer, (Color)(&color), (Color)(&color2), (Color)(&color3), (Color)num, flag ? BlendMode.Add : BlendMode.Normal);
		ArcadeSprite arcadeSprite = setAlpha(0.65f);
		Color[][] tints = _tints;
		int num5 = _indexInWeapon % tints.Length;
		int num6 = num5 - 4;
		ArcadeSprite arcadeSprite2 = setDepth(num6);
		List<EnemyController>.Enumerator enumerator = default(List<EnemyController>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj11 = 0;
			Component component2 = (Component)(&enumerator);
			throw new NullReferenceException();
		}
		Weapon weapon2 = _weapon;
		if (!weapon2.IsHoming)
		{
			object obj12 = default(object);
			ApplyPlayerFacingVelocity((Vector3)(&obj12), rotate: false);
		}
		else
		{
			Transform transform = base.AimForNearestEnemy(rotate: false);
		}
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj != null)
		{
			return;
		}
		if (--_penetrating <= 0)
		{
			base.Despawn();
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		GameObject gameObject = default(GameObject);
		EnemyController component = gameObject.GetComponent<EnemyController>();
		if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
		{
			float num = _weapon.PDuration();
			float duration = default(float);
			bool flag = component.Freeze(duration);
			GameManager core = GM.Core;
			ArcanaManager arcanaManager = core._arcanaManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A968E0");
			object obj2 = default(object);
			if (obj2 != null)
			{
				GameManager core2 = GM.Core;
				float2 float5 = component.position;
				Vector2 pos = default(Vector2);
				core2._arcanaManager.TriggerColdExplosion(pos);
			}
		}
	}

	public MirageRobe2Projectile()
	{
		Color[][] tints = new Color[4][];
		Color[] array = new Color[4];
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A121A0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12440]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A121A0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12440]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Color[] array2 = new Color[4];
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A124C0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12400]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A124C0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12400]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Color[] array3 = new Color[4];
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A124C0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12420]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A124C0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12420]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Color[] array4 = new Color[4];
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A124C0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12410]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A124C0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12410]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		_tints = tints;
		((Projectile)this)._002Ector();
	}
}
