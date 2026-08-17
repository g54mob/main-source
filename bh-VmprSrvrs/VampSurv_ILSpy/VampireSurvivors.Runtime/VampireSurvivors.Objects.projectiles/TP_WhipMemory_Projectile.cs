using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_WhipMemory_Projectile : Projectile
{
	private float _radius;

	private PhaserSprite _animatedSprite;

	private Tween _radiusTween;

	private bool trailInit;

	private List<SfxType> sfx;

	protected override void Awake()
	{
		//IL_00d8: Expected O, but got I4
		//IL_00d8: Expected I4, but got O
		//IL_0140: Expected O, but got I4
		//IL_0140: Expected I4, but got O
		//IL_01a8: Expected O, but got I4
		//IL_01a8: Expected I4, but got O
		//IL_0210: Expected O, but got I4
		//IL_0210: Expected I4, but got O
		//IL_0250: Expected I4, but got O
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		_renderer.sprite = sprite;
		_renderer.enabled = false;
		GameObject gameObject = base.gameObject;
		Vector2 vector = default(Vector2);
		PhaserSprite animatedSprite = RenderingExtensions.AddPhaserSprite(gameObject, vector, "ThosePeople", "TP_VFX_WhipMemory01");
		_animatedSprite = animatedSprite;
		string text = default(string);
		int num = default(int);
		bool flag = default(bool);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_VFX_WhipMemory", 1, 4, vector, text, num, flag);
		PhaserSprite animatedSprite2 = _animatedSprite;
		bool autoSetAnimation = default(bool);
		animatedSprite2._spriteAnimation.AddAnimation("dash", animationFrames, 32, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
		List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames("TP_VFX_WhipMemory", 6, 7, vector, text, num, flag);
		PhaserSprite animatedSprite3 = _animatedSprite;
		animatedSprite3._spriteAnimation.AddAnimation("slide", animationFrames2, 2, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
		List<Sprite> animationFrames3 = SpriteManager.GetAnimationFrames("TP_VFX_WhipMemory", 8, 9, vector, text, num, flag);
		PhaserSprite animatedSprite4 = _animatedSprite;
		animatedSprite4._spriteAnimation.AddAnimation("uppercut", animationFrames3, 2, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
		List<Sprite> animationFrames4 = SpriteManager.GetAnimationFrames("TP_VFX_WhipMemory", 10, 11, vector, text, num, flag);
		PhaserSprite animatedSprite5 = _animatedSprite;
		animatedSprite5._spriteAnimation.AddAnimation("fall", animationFrames4, 2, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
		PhaserSprite phaserSprite = _animatedSprite.setAlpha(0.85f);
		PhaserSprite phaserSprite2 = _animatedSprite.setTint(15658751u, 13421823u, 15658751u, (uint)(int)text, (BlendMode)num);
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_01ac: Expected O, but got I4
		//IL_01f4: Expected O, but got I4
		//IL_01f4: Expected O, but got I4
		//IL_020c: Expected I4, but got I8
		//IL_023c: Expected O, but got I4
		//IL_0245: Unknown result type (might be due to invalid IL or missing references)
		//IL_024a: Expected O, but got Unknown
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Expected I4, but got Unknown
		//IL_026b: Expected O, but got I4
		//IL_0444: Expected O, but got I4
		//IL_044d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0452: Expected O, but got Unknown
		//IL_045b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0460: Expected O, but got Unknown
		//IL_0480: Expected F4, but got I4
		//IL_0282: Unknown result type (might be due to invalid IL or missing references)
		//IL_0287: Expected O, but got Unknown
		//IL_0391: Expected O, but got I4
		//IL_039a: Unknown result type (might be due to invalid IL or missing references)
		//IL_039f: Expected O, but got Unknown
		//IL_04fe: Expected O, but got F4
		//IL_03d2: Expected F4, but got I4
		//IL_00fa: Expected O, but got I4
		//IL_02ee: Expected O, but got I4
		//IL_0560: Expected O, but got I4
		//IL_05a1: Expected O, but got I4
		//IL_0165: Expected O, but got F4
		//IL_0165: Expected O, but got Ref
		//IL_0165: Expected O, but got Ref
		//IL_0165: Expected O, but got Ref
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Expected O, but got Unknown
		base.InitProjectile(pool, weapon, index);
		_speed = 1.65f;
		float num = default(float);
		if (!trailInit)
		{
			PhaserSprite animatedSprite = _animatedSprite;
			trailInit = true;
			GameObject gameObject = animatedSprite._spriteRenderer.gameObject;
			SpriteTrail spriteTrail = gameObject.AddComponent<SpriteTrail>();
			_spriteTrail = spriteTrail;
			PhaserSprite animatedSprite2 = _animatedSprite;
			SpriteTrail spriteTrail2 = _spriteTrail;
			spriteTrail2._MainSprite = animatedSprite2._spriteRenderer;
			SpriteTrail spriteTrail3 = _spriteTrail;
			spriteTrail3._DefaultGhostAlpha = 0.65f;
			SpriteTrail spriteTrail4 = _spriteTrail;
			spriteTrail4._AlphaDecayPerGhost = 0.1f;
			SpriteTrail spriteTrail5 = _spriteTrail;
			spriteTrail5._MaxHistory = 4;
			spriteTrail5.InitialiseGhosts(expandExisting: true);
			SpriteTrail spriteTrail6 = _spriteTrail.setVisible(b: false);
			float num2 = default(float);
			num = num2;
			float? num3 = (float?)(object)0;
			object obj = default(object);
			object obj2 = default(object);
			object obj3 = default(object);
			BlendMode blendMode = default(BlendMode);
			bool flag;
			do
			{
				SpriteTrail spriteTrail7 = _spriteTrail;
				List<SpriteRenderer> ghosts = spriteTrail7._ghosts;
				if ((nint)num3 < ghosts._size)
				{
					SpriteRenderer[] items = ghosts._items;
					SpriteRenderer spriteRenderer = RenderingExtensions.SetTint(items[(object)num3], (Color)(&obj), (Color)(&obj2), (Color)(&obj3), (Color)num, blendMode);
					num3 = (float?)(object)((_003F?)num3 + 1);
					flag = (nint)num3 < 4;
					num = num;
					continue;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return;
			}
			while (flag);
		}
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		float num4 = _weapon.PArea();
		float num5 = default(float);
		float radius = num5 * _radius;
		BaseBody baseBody = body.setCircle(radius, (float?)(object)1, (float?)(object)1);
		int num6 = (int)(_indexInWeapon & 0x80000003L);
		if ((nint)body < 0)
		{
			object obj4 = num6 - 1;
			object obj5 = obj4 | -4;
			num6 = obj5 + 1;
		}
		bool flag2 = num6 == 0;
		if (flag2)
		{
			goto IL_03df;
		}
		object obj6 = num6 - 1;
		float num7;
		PhaserSprite animatedSprite5;
		object obj8;
		bool flag3;
		if (!flag2)
		{
			object obj7 = obj6 - 1;
			if (!flag2)
			{
				if ((nint)obj7 != 1)
				{
					goto IL_03df;
				}
				PhaserSprite animatedSprite3 = _animatedSprite;
				animatedSprite3._spriteAnimation.SetAnimation("fall");
				num7 = -1f;
			}
			else
			{
				PhaserSprite animatedSprite4 = _animatedSprite;
				animatedSprite4._spriteAnimation.SetAnimation("uppercut");
				num7 = 1f;
			}
			animatedSprite5 = _animatedSprite;
			obj8 = 0;
			flag3 = false;
		}
		else
		{
			PhaserSprite animatedSprite6 = _animatedSprite;
			animatedSprite6._spriteAnimation.SetAnimation("slide");
			Weapon weapon2 = _weapon;
			bool flag4 = ((Equipment)weapon2)._003COwner_003Ek__BackingField.flipX;
			Weapon weapon3 = _weapon;
			animatedSprite5 = _animatedSprite;
			object obj9 = (flag4 ? 1 : 0) * 2;
			object obj10 = obj9 - 1;
			bool flag5 = ((Equipment)weapon3)._003COwner_003Ek__BackingField.flipX;
			flag3 = (byte)((flag5 ? 1u : 0u) ^ 1u) != 0;
			num7 = 0f;
			obj8 = obj10;
		}
		goto IL_048d;
		IL_048d:
		PhaserSprite phaserSprite = animatedSprite5.setFlipX(flag3);
		float projectileSpeed = base.ProjectileSpeed;
		float num8 = (float)obj8 * num5;
		float projectileSpeed2 = base.ProjectileSpeed;
		ArcadeSprite sprite = _sprite;
		float num9 = num5 * num7;
		BaseBody baseBody2 = sprite.body;
		baseBody2._velocity = (float2)num8;
		PhaserSprite phaserSprite2 = _animatedSprite.setAlpha(0.65f);
		PhaserSprite phaserSprite3 = _animatedSprite.setVisible(visible: true);
		SfxType sfxType = Extensions.PickRnd(sfx);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		PlaySoundResult playSoundResult = SoundManager.PlaySound(sfxType, soundConfig, 150f, 1, num);
		ArcadeSprite arcadeSprite2 = setScale(num5, (float?)(object)0);
		return;
		IL_03df:
		PhaserSprite animatedSprite7 = _animatedSprite;
		animatedSprite7._spriteAnimation.SetAnimation("dash");
		Weapon weapon4 = _weapon;
		bool flag6 = ((Equipment)weapon4)._003COwner_003Ek__BackingField.flipX;
		Weapon weapon5 = _weapon;
		animatedSprite5 = _animatedSprite;
		object obj11 = (flag6 ? 1 : 0) ^ 1;
		object obj12 = obj11 * 2;
		object obj13 = obj12 - 1;
		flag3 = ((Equipment)weapon5)._003COwner_003Ek__BackingField.flipX;
		num7 = 0f;
		obj8 = obj13;
		goto IL_048d;
	}

	private void StartDespawn()
	{
		PhaserSprite phaserSprite = _animatedSprite.setVisible(visible: false);
		Despawn();
	}

	public override void Despawn()
	{
		if (_radiusTween != null)
		{
			TweenExtensions.Kill(_radiusTween);
		}
		base.Despawn();
	}

	public TP_WhipMemory_Projectile()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_01b4: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_01dc: Expected O, but got I
		//IL_0156: Expected O, but got I
		_radius = 16f;
		List<SfxType> list = new List<SfxType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rdx_v4+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)422);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 422;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rdx_v6+18]");
		if (num2 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)423);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 423;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rdx_v8+18]");
		if (num3 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)424);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.SfxType>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 424;
		}
		sfx = list;
		base._002Ector();
	}
}
