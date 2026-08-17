using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Slash1Projectile : Projectile
{
	private SpriteTrail _Trail;

	private Tween _angleTween;

	private Tween _accelTween;

	private Tween _backwardsTween;

	private Timer _cullingTimer;

	private const float AccelForward = 2f;

	private const float AccelBack = -4f;

	private float _acceleration;

	private Vector2 _velocity;

	private Timer _despawnTimer;

	private bool _isGoingBack;

	private float _accumulatedTime;

	private MultiTargetTween _despawnTween;

	private bool _isDespawning;

	private float2 offset;

	protected override void Awake()
	{
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("TP_VFX_Sword01", "ThosePeople");
		ArcadeSprite arcadeSprite = setFrame(sprite);
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0020: Expected O, but got I4
		//IL_0020: Expected O, but got I4
		//IL_00f3: Expected O, but got I8
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Expected O, but got Unknown
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Expected O, but got Unknown
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ac: Expected O, but got Unknown
		//IL_04ab: Expected O, but got I4
		//IL_04bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c0: Expected O, but got Unknown
		//IL_0312: Expected O, but got I4
		//IL_0344: Expected O, but got Ref
		//IL_0394: Expected O, but got I4
		//IL_0406: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		_speed = 1.5f;
		BaseBody baseBody = body.setCircle(16f, (float?)(object)1, (float?)(object)1);
		SetScaleToArea();
		_acceleration = 2f;
		_isCullable = false;
		_isGoingBack = false;
		_isDespawning = false;
		_accumulatedTime = 0f;
		if (_accelTween != null)
		{
			TweenExtensions.Kill(_accelTween);
		}
		DOGetter<float> getter = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter = null;
		((TP_Slash1Projectile)(object)dOSetter)._003CInitProjectile_003Eb__16_1(1f);
		TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, dOSetter, 0f, 0.5f);
		object obj = 6603577472L;
		TweenCallback tweenCallback2;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v433 @ rax_v14 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				bool flag = (nint)0 == 0;
				_ = 0;
				if (!flag)
				{
					object obj2 = tweenerCore + 184;
					object obj3 = obj2 >> 12;
					object obj4 = obj3 & 0x1FFFFF;
					object obj5 = obj4 >> 6;
					object obj6 = obj4 & 0x3F;
					nint num2;
					do
					{
						object obj7 = 1 << (int)obj6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rbp_v3+462E0+v493 @ rdx_v30*8]");
						object obj8 = 0 | obj7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rbp_v3+462E0+v493 @ rdx_v30*8]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rbp_v3+462E0+v493 @ rdx_v30*8]");
						if (num == 0)
						{
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rbp_v3+462E0+v493 @ rdx_v30*8]");
						num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rbp_v3+462E0+v493 @ rdx_v30*8]");
					}
					while (num2 != 0);
					TweenCallback tweenCallback = GoBackwards;
					tweenCallback2 = tweenCallback;
					goto IL_021c;
				}
			}
		}
		TweenCallback tweenCallback3 = GoBackwards;
		bool flag2 = tweenerCore == null;
		tweenCallback2 = tweenCallback3;
		if (!flag2)
		{
			goto IL_021c;
		}
		goto IL_024d;
		IL_021c:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v433 @ rax_v14 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
		if ((nint)0 == 0)
		{
		}
		goto IL_024d;
		IL_024d:
		_accelTween = tweenerCore;
		Tween accelTween = _accelTween;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		accelTween.stringId = "DefaultGameTweenId";
		Weapon weapon2 = _weapon;
		ArcadeSprite arcadeSprite = ((Equipment)weapon2)._003COwner_003Ek__BackingField;
		((ArcadeSprite)((Equipment)weapon2)._003COwner_003Ek__BackingField).CheckRenderer();
		Vector2 vector = arcadeSprite._spriteRenderer.size;
		float num3 = 3.2463913E+09f * 0.65f;
		offset = (float2)0;
		float2 float5 = base.position;
		float2 float6 = default(float2);
		base.position = float6;
		object obj9 = default(object);
		ApplyPlayerFacingVelocity((Vector3)(&obj9));
		BaseBody baseBody2 = body;
		_velocity = baseBody2._velocity;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rax_v27 (BaseBody)+74]");
		_ = 0;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float detune = (float)_indexInWeapon * -100f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_SwordThrow, soundConfig, 200f, 10, time);
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		object obj10 = renderer.pixelHeight + renderer.pixelHeight;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
		int sortingOrder = default(int);
		_renderer.sortingOrder = sortingOrder;
		SpriteTrail spriteTrail = _Trail.setVisible(b: true);
	}

	public override void InternalUpdate()
	{
		//IL_0160: Expected O, but got F4
		//IL_0287: Invalid comparison between O and F4
		//IL_023f->IL01e4: Incompatible stack heights: 1 vs 0
		//IL_009b->IL01e4: Incompatible stack heights: 1 vs 0
		//IL_00ca->IL01e4: Incompatible stack heights: 1 vs 0
		//IL_02f9->IL02a9: Incompatible stack heights: 2 vs 0
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TP_Slash1Projectile)+100]");
		float num = 0f * _acceleration;
		float num2 = (float)_velocity * _acceleration;
		if (_isGoingBack)
		{
			Transform cachedTransform = _cachedTransform;
			if ((object)_cachedTransform != null)
			{
				bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
				Weapon weapon = _weapon;
				if ((object)_weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
				{
					Transform transform = ((Equipment)weapon)._003COwner_003Ek__BackingField.transform;
					if ((object)transform != null)
					{
						bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret2);
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C6C6E0");
						Vector3 vector = default(Vector3);
						ret2 = ((System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref vector) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1E-05f)) ? Vector3.zeroVector : vector);
						num2 = (float)ret2 * _acceleration;
						object obj = default(object);
						num = (float)obj * _acceleration;
						goto IL_02a9;
					}
				}
			}
			goto IL_01e4;
		}
		float deltaTime = PauseSystem.DeltaTime;
		float num3 = deltaTime * 1000f;
		float accumulatedTime = num3 + _accumulatedTime;
		_accumulatedTime = accumulatedTime;
		goto IL_02a9;
		IL_02a9:
		ArcadeSprite sprite = _sprite;
		if ((object)_sprite != null)
		{
			BaseBody baseBody = sprite.body;
			if (sprite.body != null)
			{
				baseBody._velocity = (float2)num2;
				Weapon weapon2 = _weapon;
				if ((object)_weapon != null && (object)((Equipment)weapon2)._003COwner_003Ek__BackingField != null)
				{
					int num4 = ((Equipment)weapon2)._003COwner_003Ek__BackingField.depth;
					int num5 = num4 - 1;
					ArcadeSprite arcadeSprite = setDepth(num5);
					return;
				}
			}
		}
		goto IL_01e4;
		IL_01e4:
		throw new NullReferenceException();
	}

	private void GoBackwards()
	{
		_isGoingBack = true;
		float num = _weapon.PDuration();
		object obj = default(object);
		float num2 = (float)obj / 1000f;
		Action onComplete = StartDespawn;
		float num3 = num2 * _accumulatedTime;
		float duration = num3 * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer despawnTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_despawnTimer = despawnTimer;
		if (_backwardsTween != null)
		{
			TweenExtensions.Kill(_backwardsTween);
		}
		DOGetter<float> getter = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter = null;
		float val = default(float);
		((TP_Slash1Projectile)(object)dOSetter)._003CGoBackwards_003Eb__18_1(val);
		TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, dOSetter, -4f, 0.5f);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v347 @ rax_v16 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 1;
				_ = 0;
			}
		}
		_backwardsTween = tweenerCore;
		Tween backwardsTween = _backwardsTween;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		backwardsTween.stringId = "DefaultGameTweenId";
		if (_objectsHit != null)
		{
			((TP_Slash1Projectile)(object)_objectsHit)._003CGoBackwards_003Eb__18_1(val);
		}
	}

	public void StartDespawn()
	{
		//IL_009d: Expected I, but got O
		//IL_0101: Expected O, but got I4
		//IL_011c: Expected I, but got O
		if (!_isDespawning)
		{
			_isDespawning = true;
			if (_backwardsTween != null)
			{
				TweenExtensions.Kill(_backwardsTween);
			}
			if (_despawnTween != null)
			{
				_despawnTween.Kill();
			}
			TweenConfig tweenConfig = new TweenConfig();
			object[] array = new object[1];
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 200f;
			tweenConfig.scale = (float?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Slash1Projectile>)+370]");
			TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			tweenConfig.onComplete = onComplete;
			MultiTargetTween despawnTween = Tweens.Add(tweenConfig);
			_despawnTween = despawnTween;
		}
	}

	public void OwnerHit()
	{
		if (_isGoingBack)
		{
			StartDespawn();
		}
	}

	public override void Despawn()
	{
		base.Despawn();
		if (_despawnTween != null)
		{
			_despawnTween.Kill();
		}
		if (_despawnTimer != null)
		{
			_despawnTimer.Cancel();
		}
		if (_cullingTimer != null)
		{
			_cullingTimer.Cancel();
		}
		Tween accelTween = _accelTween;
		if (_accelTween != null && accelTween._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(_accelTween);
		}
		Tween angleTween = _angleTween;
		if (_angleTween != null && angleTween._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(_angleTween);
		}
		Tween backwardsTween = _backwardsTween;
		if (_backwardsTween != null && backwardsTween._003Cactive_003Ek__BackingField)
		{
			TweenExtensions.Kill(_backwardsTween);
		}
		SpriteTrail spriteTrail = _Trail.setVisible(b: false);
	}

	public TP_Slash1Projectile()
	{
		//IL_002a: Expected I, but got O
		_acceleration = 1f;
		nint num = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v3 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num2 = 0;
		_velocity = Vector2.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rcx_v3 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
		_ = 0;
		base._002Ector();
	}

	private float _003CInitProjectile_003Eb__16_0()
	{
		return _acceleration;
	}

	private void _003CInitProjectile_003Eb__16_1(float x)
	{
		_acceleration = x;
	}

	private float _003CGoBackwards_003Eb__18_0()
	{
		return _acceleration;
	}

	private void _003CGoBackwards_003Eb__18_1(float val)
	{
		_acceleration = val;
	}
}
