using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_AuraBlast2_HellfireProjectile : Projectile
{
	private SpriteTrail _Trail;

	private const float Radius = 16f;

	private const float Gravity = 6.25f;

	private Vector2 _velocity;

	private PhaserSprite _hellfireSprite;

	private MultiTargetTween _scaleTween;

	private Timer _leftBounceTimer;

	private Timer _rightBounceTimer;

	private Timer _bottomBounceTimer;

	protected override void Awake()
	{
		base.Awake();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999FBD5]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		_renderer.sprite = sprite;
		_renderer.enabled = false;
		SpriteTextures.SpriteTexturesBase spriteTexturesBase = SpriteTextures.Base;
		if (spriteTexturesBase.Vfx != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999FA61]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			GameObject gameObject = base.gameObject;
			Vector2 pos = default(Vector2);
			PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, "vfx", "ProjectileHellfireLarge");
			GameObject gameObject2 = phaserSprite.gameObject;
			((UnityEngine.Object)gameObject2).SetName("_fireballSprite");
			_hellfireSprite = phaserSprite;
			return;
		}
		throw new NullReferenceException();
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0034: Expected I4, but got O
		//IL_02d3: Expected O, but got I4
		//IL_02dc: Expected O, but got I4
		//IL_006f: Expected O, but got I4
		//IL_0078: Expected O, but got I4
		//IL_0242: Expected F4, but got O
		//IL_0252: Expected F4, but got I
		//IL_0139: Expected I4, but got I8
		//IL_03c2: Expected O, but got I4
		//IL_03cb: Expected O, but got I4
		//IL_0309: Expected O, but got I
		//IL_0316: Expected O, but got I8
		//IL_0466: Expected O, but got I4
		//IL_016c: Expected O, but got I4
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Expected O, but got Unknown
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Expected I4, but got Unknown
		//IL_00c5: Expected O, but got I4
		//IL_040b: Expected O, but got F4
		//IL_0439: Expected O, but got I4
		//IL_033e: Expected O, but got I
		//IL_0196: Expected O, but got I4
		//IL_00e3: Expected O, but got I4
		//IL_01d4: Expected O, but got I8
		//IL_0212: Expected O, but got I8
		base.InitProjectile(pool, weapon, index);
		BaseBody baseBody = body;
		_isCullable = false;
		baseBody._enable = true;
		BaseBody baseBody2 = body;
		bool flag = (byte)(int)baseBody2 != 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v103 @ rdx_v10 (System.Boolean)+218] (should have been resolved before IL gen)");
		SpriteTrail trail = _Trail;
		bool flag2 = (object)_Trail == null;
		object obj = 1;
		object obj2 = 1;
		if (!flag2)
		{
			bool flag3 = ((UnityEngine.Object)trail).m_CachedPtr == (IntPtr)0;
			obj = 1;
			obj2 = 1;
			if (!flag3)
			{
				_Trail.Reset();
				PhaserSprite hellfireSprite = _hellfireSprite;
				SpriteTrail trail2 = _Trail;
				trail2._MainSprite = hellfireSprite._spriteRenderer;
				obj2 = 1;
				_Trail.enabled = true;
				obj = 0;
				flag = true;
			}
		}
		Weapon weapon2 = _weapon;
		float num6;
		if (!weapon2.IsHoming)
		{
			int num = (int)(_indexInWeapon & 0x80000001L);
			if ((weapon2.IsHoming ? 1 : 0) < (false ? 1 : 0))
			{
				object obj3 = num - 1;
				object obj4 = obj3 | -2;
				num = obj4 + 1;
			}
			bool flag4 = num == 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			object obj5 = 0;
			object obj6 = 4294967295L;
			if (!flag4)
			{
				obj6 = 1;
			}
			bool flag5 = obj5 != null;
			object obj7 = 1;
			if (!flag5)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj5 == null)
				{
					MissingMethodException ex = new MissingMethodException();
					throw ex;
				}
				obj7 = 6573110936L;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v636 @ rax_v49 (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			object obj8 = 0;
			float num2 = 10f * (float)obj6;
			float num3 = 90f - num2;
			float num4 = num3 * ((float)Math.PI / 180f);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj8 == null)
				{
					MissingMethodException ex2 = new MissingMethodException();
					throw ex2;
				}
				obj7 = 6573110936L;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v666 @ rax_v52 (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
			float num5 = num4 * 4f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			num6 = num4 * 4f;
		}
		else
		{
			Transform transform = base.AimForNearestEnemy();
			BaseBody baseBody3 = body;
			float num5 = (float)baseBody3._velocity;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rax_v44 (BaseBody)+74]");
			num6 = 0f;
		}
		object obj9 = 216;
		object obj10 = 220;
		InitTimers();
		ScaleIn();
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1.5f;
		object obj11 = UnityEngine.Random.value;
		float num7 = num6 - 0.5f;
		float detune = num7 * 400f;
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Aurablast, soundConfig, 200f, 10, time);
	}

	private void InitTrail()
	{
		SpriteTrail trail = _Trail;
		if ((object)_Trail != null && ((UnityEngine.Object)trail).m_CachedPtr != (IntPtr)0)
		{
			_Trail.Reset();
			PhaserSprite hellfireSprite = _hellfireSprite;
			SpriteTrail trail2 = _Trail;
			trail2._MainSprite = hellfireSprite._spriteRenderer;
			_Trail.enabled = true;
		}
	}

	private void InitVelocity()
	{
		//IL_0048: Expected I4, but got I8
		//IL_0180: Expected O, but got I
		//IL_018d: Expected O, but got I8
		//IL_024b: Expected O, but got I4
		//IL_007b: Expected O, but got I4
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Expected O, but got Unknown
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected I4, but got Unknown
		//IL_01b5: Expected O, but got I
		//IL_00a5: Expected O, but got I4
		//IL_02a1: Expected O, but got F4
		//IL_00e3: Expected O, but got I8
		//IL_0121: Expected O, but got I8
		Weapon weapon = _weapon;
		if (!weapon.IsHoming)
		{
			int num = (int)(_indexInWeapon & 0x80000001L);
			if ((weapon.IsHoming ? 1 : 0) < (false ? 1 : 0))
			{
				object obj = num - 1;
				object obj2 = obj | -2;
				num = obj2 + 1;
			}
			bool flag = num == 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			object obj3 = 0;
			object obj4 = 4294967295L;
			if (!flag)
			{
				obj4 = 1;
			}
			bool flag2 = obj3 != null;
			object obj5 = 1;
			if (!flag2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj3 == null)
				{
					MissingMethodException ex = new MissingMethodException();
					throw ex;
				}
				obj5 = 6573110936L;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v224 @ rax_v17 (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			object obj6 = 0;
			float num2 = 10f * (float)obj4;
			float num3 = 90f - num2;
			float num4 = num3 * ((float)Math.PI / 180f);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj6 == null)
				{
					MissingMethodException ex2 = new MissingMethodException();
					throw ex2;
				}
				obj5 = 6573110936L;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v257 @ rax_v20 (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
			float num5 = num4 * 4f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			float num6 = num4 * 4f;
			_velocity = (Vector2)num5;
		}
		else
		{
			Transform transform = base.AimForNearestEnemy();
			BaseBody baseBody = body;
			_velocity = baseBody._velocity;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rax_v12 (BaseBody)+74]");
			_ = 0;
		}
	}

	private void InitTimers()
	{
		_ = 0;
		_ = 1;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		bool isOnlineTimer = default(bool);
		bool canPause = default(bool);
		Timer leftBounceTimer = Timers.Register(0.001f, null, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer, canPause);
		_leftBounceTimer = leftBounceTimer;
		Timer rightBounceTimer = Timers.Register(0.001f, null, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_rightBounceTimer = rightBounceTimer;
		Timer bottomBounceTimer = Timers.Register(0.001f, null, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_bottomBounceTimer = bottomBounceTimer;
	}

	private void ScaleIn()
	{
		//IL_017f: Expected O, but got I4
		//IL_000d: Expected I, but got O
		//IL_002a: Expected O, but got I
		//IL_008b: Expected O, but got I8
		//IL_00e9: Expected I, but got O
		//IL_014d: Expected O, but got I4
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
		Weapon weapon = _weapon;
		nint num = (nint)weapon;
		float num2 = weapon.PArea();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
			weapon = (Weapon)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v140 @ rax_v14 (should have been resolved before IL gen)");
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_cachedTransform != null)
		{
			nint num3 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 250f;
		tweenConfig.scale = (float?)(object)1;
		MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
		_scaleTween = scaleTween;
	}

	private void PlaySfx()
	{
		//IL_004b: Expected O, but got F4
		//IL_0079: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1.5f;
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		float num = (float)obj2 - 0.5f;
		float detune = num * 400f;
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Aurablast, soundConfig, 200f, 10, time);
	}

	public override void InternalUpdate()
	{
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Expected O, but got Unknown
		//IL_0199->IL013e: Incompatible stack heights: 1 vs 0
		//IL_00c3->IL013e: Incompatible stack heights: 1 vs 0
		//IL_00f2->IL013e: Incompatible stack heights: 1 vs 0
		UpdateVelocity();
		float2 float5 = base.position;
		Weapon weapon = _weapon;
		if ((object)_weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
		{
			Transform transform = ((Equipment)weapon)._003COwner_003Ek__BackingField.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				Weapon weapon2 = _weapon;
				if ((object)_weapon != null)
				{
					VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
					if ((object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
					{
						ArcadeBodyBounds worldBoxCollider = characterController._worldBoxCollider;
						if (characterController._worldBoxCollider != null)
						{
							object obj2 = default(object);
							object obj = obj2 - worldBoxCollider.height;
							object obj3 = default(object);
							if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
							{
								_isCullable = true;
								Despawn();
							}
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void UpdateVelocity()
	{
		//IL_00f5: Expected F4, but got O
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * 6.25f;
		float num2 = num * -1f;
		float num3 = num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rcx_v13 (VampireSurvivors.Objects.Projectiles.TP_AuraBlast2_HellfireProjectile)+DC]");
		float num4 = num3 + 0f;
		CheckForBounce();
		ArcadeSprite sprite = _sprite;
		BaseBody baseBody = sprite.body;
		baseBody._velocity = _velocity;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rcx_v13 (VampireSurvivors.Objects.Projectiles.TP_AuraBlast2_HellfireProjectile)+DC]");
		_ = 0;
		Transform cachedTransform = _cachedTransform;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
		Vector3 axis = default(Vector3);
		Quaternion.AngleAxis_Injected((float)this, ref axis, out Quaternion _);
		bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
		Quaternion value = default(Quaternion);
		Transform.set_rotation_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref value);
	}

	private void CheckForBounce()
	{
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_00dd: Expected O, but got F4
		//IL_01b6: Expected O, but got F4
		if (_bounces > 0)
		{
			Bounds bounds = CameraExtensions.OrthographicBounds(_mainCamera);
			object obj2 = default(object);
			object obj = (object)bounds.m_Center - obj2;
			object obj3 = obj2 + (object)bounds.m_Center;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rax_v4 (UnityEngine.Bounds)+10]");
			object obj4 = obj2 - 0;
			float2 float5 = base.position;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) >= System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float5) && _leftBounceTimer.IsDone)
			{
				int bounces = _bounces - 1;
				_bounces = bounces;
				float num = (float)_velocity * -1.1f;
				_velocity = (Vector2)num;
				_leftBounceTimer.Cancel();
				Timer leftBounceTimer = Timers.Register(0.5f, null, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				_leftBounceTimer = leftBounceTimer;
			}
			float2 float6 = base.position;
			if (System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float6) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) && _rightBounceTimer.IsDone)
			{
				int bounces2 = _bounces - 1;
				_bounces = bounces2;
				float num2 = (float)_velocity * -1.1f;
				_velocity = (Vector2)num2;
				_rightBounceTimer.Cancel();
				Timer rightBounceTimer = Timers.Register(0.5f, null, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				_rightBounceTimer = rightBounceTimer;
			}
			float2 float7 = base.position;
			object obj5 = default(object);
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5) && _bottomBounceTimer.IsDone)
			{
				int bounces3 = _bounces - 1;
				_bounces = bounces3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TP_AuraBlast2_HellfireProjectile)+DC]");
				float num3 = 0f * -0.9f;
				_bottomBounceTimer.Cancel();
				Timer bottomBounceTimer = Timers.Register(0.5f, null, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
				_bottomBounceTimer = bottomBounceTimer;
			}
		}
	}

	private void Bounce(bool invertX, bool invertY)
	{
		//IL_004f: Expected O, but got F4
		int bounces = _bounces - 1;
		_bounces = bounces;
		if (invertX)
		{
			float num = (float)_velocity * -1.1f;
			_velocity = (Vector2)num;
		}
		if (invertY)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TP_AuraBlast2_HellfireProjectile)+DC]");
			float num2 = 0f * -0.9f;
		}
	}

	private void CheckForDespawn()
	{
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Expected O, but got Unknown
		//IL_018e->IL0133: Incompatible stack heights: 1 vs 0
		//IL_00b8->IL0133: Incompatible stack heights: 1 vs 0
		//IL_00e7->IL0133: Incompatible stack heights: 1 vs 0
		float2 float5 = base.position;
		Weapon weapon = _weapon;
		if ((object)_weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
		{
			Transform transform = ((Equipment)weapon)._003COwner_003Ek__BackingField.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				Weapon weapon2 = _weapon;
				if ((object)_weapon != null)
				{
					VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
					if ((object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
					{
						ArcadeBodyBounds worldBoxCollider = characterController._worldBoxCollider;
						if (characterController._worldBoxCollider != null)
						{
							object obj2 = default(object);
							object obj = obj2 - worldBoxCollider.height;
							object obj3 = default(object);
							if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
							{
								_isCullable = true;
								Despawn();
							}
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void Despawn()
	{
		SpriteTrail trail = _Trail;
		if ((object)_Trail != null && ((UnityEngine.Object)trail).m_CachedPtr != (IntPtr)0)
		{
			_Trail.Reset();
			_Trail.enabled = false;
		}
		if (_leftBounceTimer != null)
		{
			_leftBounceTimer.Cancel();
		}
		if (_rightBounceTimer != null)
		{
			_rightBounceTimer.Cancel();
		}
		if (_bottomBounceTimer != null)
		{
			_bottomBounceTimer.Cancel();
		}
		base.Despawn();
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null && _weapon.HasActiveArcanaOfType(ArcanaType.T19_FIRE))
		{
			Weapon weapon = _weapon;
			GameManager gameMan = weapon._gameMan;
			float2 float5 = base.position;
			Vector2 pos = default(Vector2);
			gameMan._arcanaManager.TriggerFireExplosion(pos);
		}
	}
}
