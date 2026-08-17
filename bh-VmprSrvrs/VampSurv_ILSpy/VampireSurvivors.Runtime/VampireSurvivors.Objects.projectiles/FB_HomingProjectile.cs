using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class FB_HomingProjectile : Projectile
{
	private SpriteAnimation _anim;

	public float2 _targetPosition;

	public float _timeSinceChangedTarget;

	public float _facingAngle;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("Multistage Missile-Horizontal-F1", "FirstBlood");
		ArcadeSprite arcadeSprite = setFrame(sprite);
		SpriteAnimation anim = _anim;
		if ((object)_anim == null || ((UnityEngine.Object)anim).m_CachedPtr == (IntPtr)0)
		{
			SpriteAnimation component = _renderer.GetComponent<SpriteAnimation>();
			_anim = component;
			List<Sprite> frames = new List<Sprite>();
			Sprite sprite2 = SpriteManager.GetSprite("Multistage Missile-Horizontal-F1", "FirstBlood");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
			Sprite sprite3 = SpriteManager.GetSprite("Multistage Missile-Horizontal-F2", "FirstBlood");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
			Sprite sprite4 = SpriteManager.GetSprite("Multistage Missile-Horizontal-F3", "FirstBlood");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
			Sprite sprite5 = SpriteManager.GetSprite("Multistage Missile-Horizontal-F4", "FirstBlood");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97420");
			bool shouldLoop = default(bool);
			bool startRandomFrame = default(bool);
			Action onComplete = default(Action);
			bool autoSetAnimation = default(bool);
			_anim.AddAnimation("idle", frames, 8, shouldLoop, startRandomFrame, onComplete, autoSetAnimation);
		}
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_006e: Expected O, but got I4
		//IL_006e: Expected O, but got I4
		//IL_0089: Expected I, but got O
		//IL_009f: Invalid comparison between I4 and F4
		//IL_00e0: Expected O, but got I4
		//IL_0117: Expected F4, but got I4
		base.InitProjectile(pool, weapon, index);
		SpriteAnimation anim = _anim;
		_isCullable = false;
		((BaseSpriteAnimation)anim)._currentAnimation = null;
		Sprite sprite = SpriteManager.GetSprite("Multistage Missile-Horizontal-F1", "FirstBlood");
		ArcadeSprite arcadeSprite = setFrame(sprite);
		BaseBody baseBody = body.setCircle(8f, (float?)(object)1, (float?)(object)1);
		Weapon weapon2 = _weapon;
		nint num = (nint)weapon2;
		float num2 = weapon2.PArea();
		float num3 = default(float);
		if (!(0f > num3))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtss xmm0,xmm0\"");
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73D18");
		}
		ArcadeSprite arcadeSprite2 = setScale(num3, (float?)(object)0);
		float? volume = default(float?);
		float rate = default(float);
		float detune = default(float);
		bool loop = default(bool);
		PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC4_HomingShot, 100f, 12, 0f, volume, rate, detune, loop, 1f);
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		//IL_036b: Invalid comparison between I4 and F4
		//IL_00cb: Expected I, but got O
		//IL_00d3: Expected I, but got O
		//IL_00e3: Expected O, but got I
		//IL_0163: Expected O, but got I4
		//IL_011f: Expected O, but got I
		//IL_0155: Expected O, but got I4
		//IL_02c2: Expected O, but got I4
		//IL_02c2: Expected O, but got I4
		//IL_02df: Expected I, but got O
		//IL_0357: Expected F4, but got I4
		//IL_0357: Expected F4, but got O
		//IL_0357: Expected F4, but got I4
		//IL_0357: Expected O, but got I4
		//IL_025e: Expected I, but got O
		if (0f > _timeSinceChangedTarget)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj != null)
		{
			return;
		}
		if (_weapon.HasActiveArcanaOfType(ArcanaType.T19_FIRE))
		{
			Weapon weapon = _weapon;
			GameManager gameMan = weapon._gameMan;
			float2 float5 = base.position;
			Vector2 pos = default(Vector2);
			gameMan._arcanaManager.TriggerFireExplosion(pos);
		}
		int penetrating = _penetrating - 1;
		_penetrating = penetrating;
		nint num = (nint)typeof(EnemyController);
		nint num2 = (nint)other;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ rdx_v7 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v456 @ r8_v7 (Il2CppClass<VampireSurvivors.Interfaces.IDamageable>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ rdx_v7 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
		object obj4;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v456 @ r8_v7 (Il2CppClass<VampireSurvivors.Interfaces.IDamageable>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v543 @ rax_v43+FFFFFFF8+v526 @ rax_v9*8]");
			if (0 == (nint)typeof(EnemyController))
			{
				obj4 = 1;
				goto IL_037f;
			}
		}
		obj4 = 0;
		goto IL_037f;
		IL_037f:
		bool flag = obj4 == null;
		IDamageable damageable = null;
		if (!flag)
		{
			damageable = other;
		}
		if (damageable != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ rdi_v7 (VampireSurvivors.Interfaces.IDamageable)+10]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ rdi_v7 (VampireSurvivors.Interfaces.IDamageable)+1F9]");
				if ((nint)0 != 0)
				{
					_penetrating = 0;
				}
			}
		}
		if (_penetrating <= 0)
		{
			SetScaleToArea();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @187074010");
			object obj5 = default(object);
			int num4 = default(int);
			bool flag2 = default(bool);
			Action action2 = default(Action);
			bool flag3 = default(bool);
			if (obj5 == null)
			{
				List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("Crush Bomb-Explosion-F", 1, 7, "firstBlood", num4);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v781 @ r8_v15 (Il2CppClass<VampireSurvivors.Objects.Projectiles.FB_HomingProjectile>)+370]");
				Action action = new Action(this, (IntPtr)0);
				nint num5 = (nint)this;
				_anim.AddAnimation("bang", animationFrames, 16, (byte)num4 != 0, flag2, action2, flag3);
			}
			_anim.SetAnimation("bang");
			BaseBody baseBody = body.setCircle(16f, (float?)(object)1, (float?)(object)1);
			base.angle = 0f;
			nint num6 = (nint)typeof(float2);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v788 @ rax_v23 (Il2CppClass<Unity.Mathematics.float2>)+B8]");
			nint num7 = 0;
			BaseBody baseBody2 = body;
			baseBody2._velocity = float2.zero;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v269 @ rcx_v20 (Il2CppStaticFields<Unity.Mathematics.float2>)+4]");
			_ = 0;
			_timeSinceChangedTarget = -1000f;
			PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC4_Explosion1, 500f, 10, 0f, (float?)(object)num4, flag2 ? 1 : 0, (float)action2, flag3, 1f);
		}
	}
}
