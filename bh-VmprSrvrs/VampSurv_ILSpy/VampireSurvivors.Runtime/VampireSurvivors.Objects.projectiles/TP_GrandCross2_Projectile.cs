using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Events;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_GrandCross2_Projectile : Projectile
{
	private MeshRenderer _CrossMesh;

	private SpriteRenderer _TrailSprite;

	private SpriteTrail _Trail;

	private SpriteTrail _GoldenTrail;

	private const float Radius = 24f;

	private const float MaxAcceleration = 2f;

	private TP_GrandCross2_Weapon _trueWeapon;

	private Vector2 _velocity;

	private float _acceleration;

	private bool _isGoingBackwards;

	private bool _hasOverlappedBeam;

	private bool _canDespawn;

	private bool _isDespawning;

	private Tween _angleTween;

	private Tween _accelTween;

	private Tween _backwardsTween;

	private Timer _cullingTimer;

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
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_001d: Expected I, but got O
		//IL_0025: Expected I, but got O
		//IL_0035: Expected O, but got I
		//IL_00b5: Expected O, but got I4
		//IL_0071: Expected O, but got I
		//IL_00a7: Expected O, but got I4
		//IL_00ff: Expected O, but got I4
		//IL_00ff: Expected O, but got I4
		//IL_0120: Expected O, but got I4
		//IL_013b: Expected I, but got O
		//IL_01a3: Expected O, but got I4
		//IL_029c: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		Weapon weapon2 = _weapon;
		TP_GrandCross2_Weapon trueWeapon;
		if ((object)_weapon == null)
		{
			trueWeapon = null;
			goto IL_0241;
		}
		nint num = (nint)typeof(TP_GrandCross2_Weapon);
		nint num2 = (nint)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rdx_v19 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_GrandCross2_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ r9_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rdx_v19 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_GrandCross2_Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ r9_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rax_v46+FFFFFFF8+v65 @ rax_v41*8]");
			if (0 == (nint)typeof(TP_GrandCross2_Weapon))
			{
				obj3 = 1;
				goto IL_0250;
			}
		}
		obj3 = 0;
		goto IL_0250;
		IL_0250:
		bool flag = obj3 == null;
		trueWeapon = null;
		if (!flag)
		{
			trueWeapon = (TP_GrandCross2_Weapon)_weapon;
		}
		goto IL_0241;
		IL_0241:
		_trueWeapon = trueWeapon;
		_isCullable = false;
		_acceleration = 2f;
		BaseBody baseBody = body.setCircle(24f, (float?)(object)1, (float?)(object)1);
		BaseBody baseBody2 = body;
		baseBody2._checkCollision = (ArcadeBodyCollision)15;
		SetScaleToArea();
		InitPosition();
		nint num4 = (nint)this;
		Transform transform = base.AimForNearestEnemy();
		BaseBody baseBody3 = body;
		_velocity = baseBody3._velocity;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ rax_v14 (BaseBody)+74]");
		_ = 0;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		object obj4 = renderer.pixelHeight + renderer.pixelHeight;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
		int sortingOrder = default(int);
		_renderer.sortingOrder = sortingOrder;
		InitTrails();
		InitBouncing();
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float detune = (float)_indexInWeapon * -100f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Shot, soundConfig, 200f, 10, time);
		DoTweens();
	}

	private void InitPosition()
	{
		//IL_0104: Expected O, but got F4
		//IL_00af: Expected O, but got F4
		Transform cachedTransform = _cachedTransform;
		bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
		object obj = UnityEngine.Random.value;
		bool flag2 = (object)_weapon == null;
		float num = _weapon.PArea();
		object obj2 = UnityEngine.Random.value;
		bool flag3 = (object)_weapon == null;
		float num2 = _weapon.PArea();
		Transform cachedTransform2 = _cachedTransform;
		bool flag4 = (object)_cachedTransform == null;
		bool flag5 = ((UnityEngine.Object)cachedTransform2).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_position_Injected(((UnityEngine.Object)cachedTransform2).m_CachedPtr, ref value);
	}

	private void InitVelocity()
	{
		Transform transform = base.AimForNearestEnemy();
		BaseBody baseBody = body;
		_velocity = baseBody._velocity;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ rax_v3 (BaseBody)+74]");
		_ = 0;
	}

	private void InitDepth()
	{
		//IL_002e: Expected O, but got I4
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.Renderer renderer = s_scene._renderer;
		object obj = renderer.pixelHeight + renderer.pixelHeight;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BDD0");
		int sortingOrder = default(int);
		_renderer.sortingOrder = sortingOrder;
	}

	private void InitTrails()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A1389]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Sprite sprite = SpriteManager.GetSprite("TP_GrandCrossTrail", "ThosePeople");
		_TrailSprite.sprite = sprite;
		_TrailSprite.enabled = false;
		SpriteTrail trail = _Trail;
		trail._MainSprite = _TrailSprite;
		SpriteTrail spriteTrail = _Trail.setVisible(b: true);
		SpriteTrail goldenTrail = _GoldenTrail;
		goldenTrail._MainSprite = _TrailSprite;
		SpriteTrail spriteTrail2 = _GoldenTrail.setVisible(b: true);
	}

	private void InitBouncing()
	{
		//IL_0121: Expected O, but got I4
		//IL_0121: Expected O, but got I4
		//IL_00ac: Expected O, but got I4
		//IL_00ac: Expected O, but got I4
		int num = _weapon.PBounces();
		if (num > 0)
		{
			if (_bounceActivated)
			{
				goto IL_010c;
			}
			_bounceActivated = true;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if ((object)s_scene.physics == null)
			{
				throw new NullReferenceException();
			}
			WORLD_BOUNDS_EVENT wORLD_BOUNDS_EVENT = Bounce;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA6950");
			setCollideWorldBounds(value: true, (float?)(object)1, (float?)(object)1);
			Weapon weapon = _weapon;
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
			Body body = base.body.setBoundsRectangle(characterController._worldBoxCollider);
			BaseBody baseBody = base.body;
			baseBody._onWorldBounds = true;
		}
		if (!_bounceActivated)
		{
			return;
		}
		goto IL_010c;
		IL_010c:
		setCollideWorldBounds(value: true, (float?)(object)1, (float?)(object)1);
	}

	private unsafe void DoTweens()
	{
		//IL_0072: Expected O, but got I8
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected O, but got Unknown
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Expected O, but got Unknown
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Expected O, but got Unknown
		//IL_0261: Expected O, but got Ref
		//IL_049a: Expected O, but got I4
		//IL_04aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_04af: Expected O, but got Unknown
		if (_accelTween != null)
		{
			DG.Tweening.TweenExtensions.Kill(_accelTween);
		}
		DOGetter<float> getter = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter = null;
		float x = default(float);
		((TP_GrandCross2_Projectile)(object)dOSetter)._003CDoTweens_003Eb__24_1(x);
		TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, dOSetter, 0f, 0.5f);
		object obj = 6603577472L;
		TweenCallback tweenCallback2;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rax_v8 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
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
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rbp_v1+462E0+v178 @ rdx_v32*8]");
						object obj8 = 0 | obj7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rbp_v1+462E0+v178 @ rdx_v32*8]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rbp_v1+462E0+v178 @ rdx_v32*8]");
						if (num == 0)
						{
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rbp_v1+462E0+v178 @ rdx_v32*8]");
						num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rbp_v1+462E0+v178 @ rdx_v32*8]");
					}
					while (num2 != 0);
					TweenCallback tweenCallback = GoBackwards;
					tweenCallback2 = tweenCallback;
					goto IL_0198;
				}
			}
		}
		TweenCallback tweenCallback3 = GoBackwards;
		bool flag2 = tweenerCore == null;
		tweenCallback2 = tweenCallback3;
		if (!flag2)
		{
			goto IL_0198;
		}
		goto IL_01c7;
		IL_0198:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rax_v8 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
		if ((nint)0 == 0)
		{
		}
		goto IL_01c7;
		IL_01c7:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_accelTween = tweenerCore;
		if (_angleTween != null)
		{
			DG.Tweening.TweenExtensions.Kill(_angleTween);
		}
		object obj9 = default(object);
		TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore2 = ShortcutExtensions.DOLocalRotate(_cachedTransform, (Vector3)(&obj9), 1f, RotateMode.FastBeyond360);
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v623 @ rax_v17 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v623 @ rax_v17 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v623 @ rax_v17 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+98]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v623 @ rax_v17 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+99]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v623 @ rax_v17 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
				if ((nint)0 != 0)
				{
					_ = 1;
					_ = 0;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v623 @ rax_v17 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v623 @ rax_v17 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 4294967295L;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v623 @ rax_v17 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
					if ((nint)0 == 0)
					{
						_ = 2139095040;
					}
				}
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_angleTween = tweenerCore2;
	}

	private unsafe void GoBackwards()
	{
		//IL_0033: Expected O, but got Ref
		_isGoingBackwards = true;
		if (_angleTween != null)
		{
			DG.Tweening.TweenExtensions.Kill(_angleTween);
		}
		object obj = default(object);
		TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DOLocalRotate(_cachedTransform, (Vector3)(&obj), 1f, RotateMode.FastBeyond360);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+98]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+99]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
				if ((nint)0 != 0)
				{
					_ = 1;
					_ = 0;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 4294967295L;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rax_v3 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
					if ((nint)0 == 0)
					{
						_ = 2139095040;
					}
				}
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_angleTween = tweenerCore;
		if (_backwardsTween != null)
		{
			DG.Tweening.TweenExtensions.Kill(_backwardsTween);
		}
		DOGetter<float> getter = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter = null;
		((TP_GrandCross2_Projectile)(object)dOSetter)._003CGoBackwards_003Eb__25_1(0f);
		TweenerCore<float, float, FloatOptions> tweenerCore2 = DOTween.To(getter, dOSetter, -2f, 0.5f);
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v615 @ rax_v17 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 1;
				_ = 0;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_backwardsTween = tweenerCore2;
		if (_cullingTimer != null)
		{
			_cullingTimer.Cancel();
		}
		Action onComplete = delegate
		{
			_canDespawn = true;
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer cullingTimer = Timers.Register(0.75000006f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_cullingTimer = cullingTimer;
		if (_objectsHit != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		}
	}

	public override void InternalUpdate()
	{
		//IL_005a: Expected O, but got F4
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Expected O, but got Unknown
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Expected O, but got Unknown
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Expected O, but got Unknown
		//IL_022c: Expected O, but got I4
		//IL_0276: Expected I, but got O
		float num = (float)_velocity * _acceleration;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TP_GrandCross2_Projectile)+FC]");
		float num2 = 0f * _acceleration;
		ArcadeSprite sprite = _sprite;
		BaseBody baseBody = sprite.body;
		baseBody._velocity = (float2)num;
		if (_isGoingBackwards && !_hasOverlappedBeam)
		{
			TP_GrandCross2_Weapon trueWeapon = _trueWeapon;
			float2 float5 = ((Equipment)trueWeapon)._003COwner_003Ek__BackingField.position;
			Rectangle pfxRect = trueWeapon._pfxRect;
			object obj = float5 + pfxRect._x;
			float2 float6 = ((Equipment)trueWeapon)._003COwner_003Ek__BackingField.position;
			Rectangle pfxRect2 = trueWeapon._pfxRect;
			object obj2 = float6 + pfxRect2._x;
			object obj3 = obj2 + pfxRect2._width;
			float2 float7 = base.position;
			if (System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float7) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
			{
				float2 float8 = base.position;
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) > System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float8))
				{
					_hasOverlappedBeam = true;
					_trueWeapon.TriggerBeam();
					SetTrailAlpha(_GoldenTrail, 0.5f);
				}
			}
		}
		if (_canDespawn && !_isDespawning && !CameraExtensions.IsObjectVisible(_mainCamera, _CrossMesh))
		{
			BaseBody baseBody2 = body;
			_isDespawning = true;
			baseBody2._checkCollision = (ArcadeBodyCollision)0;
			if (_cullingTimer != null)
			{
				_cullingTimer.Cancel();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v415 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_GrandCross2_Projectile>)+370]");
			Action onComplete = new Action(this, (IntPtr)0);
			nint num3 = (nint)this;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer cullingTimer = Timers.Register(0.2f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_cullingTimer = cullingTimer;
		}
	}

	private void UpdateVelocity()
	{
		//IL_005a: Expected O, but got F4
		float num = (float)_velocity * _acceleration;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TP_GrandCross2_Projectile)+FC]");
		float num2 = 0f * _acceleration;
		ArcadeSprite sprite = _sprite;
		BaseBody baseBody = sprite.body;
		baseBody._velocity = (float2)num;
	}

	private void CheckForBeamOverlap()
	{
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected O, but got Unknown
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Expected O, but got Unknown
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Expected O, but got Unknown
		if (!_isGoingBackwards || _hasOverlappedBeam)
		{
			return;
		}
		TP_GrandCross2_Weapon trueWeapon = _trueWeapon;
		float2 float5 = ((Equipment)trueWeapon)._003COwner_003Ek__BackingField.position;
		Rectangle pfxRect = trueWeapon._pfxRect;
		object obj = float5 + pfxRect._x;
		float2 float6 = ((Equipment)trueWeapon)._003COwner_003Ek__BackingField.position;
		Rectangle pfxRect2 = trueWeapon._pfxRect;
		object obj2 = float6 + pfxRect2._x;
		object obj3 = obj2 + pfxRect2._width;
		float2 float7 = base.position;
		if (System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float7) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
		{
			float2 float8 = base.position;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) > System.Runtime.CompilerServices.Unsafe.As<float2, UIntPtr>(ref float8))
			{
				_hasOverlappedBeam = true;
				_trueWeapon.TriggerBeam();
				SetTrailAlpha(_GoldenTrail, 0.5f);
			}
		}
	}

	private void SetTrailAlpha(SpriteTrail trail, float alpha)
	{
		//IL_0024: Expected O, but got I4
		//IL_002d: Expected O, but got I4
		//IL_00bc: Expected O, but got I
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01da: Expected O, but got Unknown
		//IL_00a7->IL0108: Incompatible stack heights: 1 vs 0
		//IL_00dc->IL0108: Incompatible stack heights: 1 vs 0
		//IL_01f4->IL0108: Incompatible stack heights: 5 vs 0
		//IL_0107->IL01f9: Incompatible stack heights: 5 vs 0
		SpriteTrail goldenTrail = _GoldenTrail;
		bool flag = (object)_GoldenTrail == null;
		object obj = 0;
		object obj2 = 0;
		if (!flag)
		{
			Color value = default(Color);
			while (true)
			{
				if ((nint)obj < goldenTrail._MaxHistory)
				{
					if ((object)trail == null)
					{
						break;
					}
					List<SpriteRenderer> ghosts = trail._ghosts;
					if (trail._ghosts == null)
					{
						break;
					}
					bool flag2 = (nint)obj2 >= ghosts._size;
					object items = ghosts._items;
					if (ghosts._items == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rbx_v4 (System.Object)+20+v157 @ rsi_v3*8]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rbx_v4 (System.Object)+20+v157 @ rsi_v3*8]");
					if ((nint)0 == 0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rbx_v5 (System.Object)+10]");
					bool flag3 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rbx_v5 (System.Object)+10]");
					SpriteRenderer.get_color_Injected((IntPtr)0, out Color _);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rbx_v5 (System.Object)+10]");
					bool flag4 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rbx_v5 (System.Object)+10]");
					SpriteRenderer.get_color_Injected((IntPtr)0, out Color _);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rbx_v5 (System.Object)+10]");
					bool flag5 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rbx_v5 (System.Object)+10]");
					SpriteRenderer.get_color_Injected((IntPtr)0, out Color _);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rbx_v5 (System.Object)+10]");
					bool flag6 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rbx_v5 (System.Object)+10]");
					SpriteRenderer.set_color_Injected((IntPtr)0, ref value);
					goldenTrail = _GoldenTrail;
					obj2++;
					if ((object)_GoldenTrail == null)
					{
						break;
					}
					obj = obj2;
					continue;
				}
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void PlaySfx()
	{
		//IL_004b: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float detune = (float)_indexInWeapon * -100f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Shot, soundConfig, 200f, 10, time);
	}

	private void Bounce(Body b, bool up, bool down, bool left, bool right)
	{
		//IL_0039: Expected O, but got I4
		//IL_0039: Expected O, but got I4
		//IL_0145: Expected O, but got F4
		if (body != b)
		{
			return;
		}
		if (_bounces <= 0)
		{
			setCollideWorldBounds(value: false, (float?)(object)1, (float?)(object)1);
			return;
		}
		int bounces = _bounces - 1;
		_bounces = bounces;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		bool flag = _accelTween == null;
		_hasOverlappedBeam = false;
		if (!flag && DG.Tweening.TweenExtensions.IsPlaying(_accelTween))
		{
			if (_accelTween != null)
			{
				DG.Tweening.TweenExtensions.Kill(_accelTween);
			}
			float acceleration = _acceleration * -1f;
			_acceleration = acceleration;
			GoBackwards();
		}
		else
		{
			float num = (float)_velocity * -1f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TP_GrandCross2_Projectile)+FC]");
			float num2 = 0f * -1f;
			_velocity = (Vector2)num;
		}
	}

	protected override void OnHasHitAnotherPlayerObject(IDamageable other)
	{
		//IL_001d: Expected I, but got O
		//IL_0025: Expected I, but got O
		//IL_0035: Expected O, but got I
		//IL_00b5: Expected O, but got I4
		//IL_026b: Expected I, but got O
		//IL_0071: Expected O, but got I
		//IL_00c8: Expected I, but got O
		//IL_00a7: Expected O, but got I4
		//IL_010b: Expected O, but got I4
		//IL_010b: Expected O, but got I4
		//IL_0217: Expected O, but got F4
		BaseBody baseBody = body;
		BaseBody baseBody2;
		if (body == null)
		{
			baseBody2 = null;
			goto IL_027e;
		}
		nint num = (nint)typeof(Body);
		nint num2 = (nint)baseBody;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r8_v7 (Il2CppClass<Body>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ r9_v1 (Il2CppClass<BaseBody>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ r8_v7 (Il2CppClass<Body>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ r9_v1 (Il2CppClass<BaseBody>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rax_v20+FFFFFFF8+v47 @ rax_v16*8]");
			if (0 == (nint)typeof(Body))
			{
				obj3 = 1;
				goto IL_024e;
			}
		}
		obj3 = 0;
		goto IL_024e;
		IL_024e:
		bool flag = obj3 == null;
		nint num4 = (nint)typeof(Body);
		baseBody2 = null;
		if (!flag)
		{
			num4 = (nint)typeof(Body);
			baseBody2 = body;
		}
		goto IL_027e;
		IL_027e:
		if (body != baseBody2)
		{
			return;
		}
		if (_bounces <= 0)
		{
			setCollideWorldBounds(value: false, (float?)(object)1, (float?)(object)1);
			return;
		}
		int bounces = _bounces - 1;
		_bounces = bounces;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		bool flag2 = _accelTween == null;
		_hasOverlappedBeam = false;
		if (!flag2 && DG.Tweening.TweenExtensions.IsPlaying(_accelTween))
		{
			if (_accelTween != null)
			{
				DG.Tweening.TweenExtensions.Kill(_accelTween);
			}
			float acceleration = _acceleration * -1f;
			_acceleration = acceleration;
			GoBackwards();
		}
		else
		{
			float num5 = (float)_velocity * -1f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TP_GrandCross2_Projectile)+FC]");
			float num6 = 0f * -1f;
			_velocity = (Vector2)num5;
		}
	}

	private void CheckForDespawn()
	{
		//IL_0077: Expected O, but got I4
		//IL_00c1: Expected I, but got O
		if (_canDespawn && !_isDespawning && !CameraExtensions.IsObjectVisible(_mainCamera, _CrossMesh))
		{
			BaseBody baseBody = body;
			_isDespawning = true;
			baseBody._checkCollision = (ArcadeBodyCollision)0;
			if (_cullingTimer != null)
			{
				_cullingTimer.Cancel();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_GrandCross2_Projectile>)+370]");
			Action onComplete = new Action(this, (IntPtr)0);
			nint num = (nint)this;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer cullingTimer = Timers.Register(0.2f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_cullingTimer = cullingTimer;
		}
	}

	public override void Despawn()
	{
		if (_cullingTimer != null)
		{
			_cullingTimer.Cancel();
		}
		Tween accelTween = _accelTween;
		if (_accelTween != null && accelTween._003Cactive_003Ek__BackingField)
		{
			DG.Tweening.TweenExtensions.Kill(_accelTween);
		}
		Tween angleTween = _angleTween;
		if (_angleTween != null && angleTween._003Cactive_003Ek__BackingField)
		{
			DG.Tweening.TweenExtensions.Kill(_angleTween);
		}
		Tween backwardsTween = _backwardsTween;
		if (_backwardsTween != null && backwardsTween._003Cactive_003Ek__BackingField)
		{
			DG.Tweening.TweenExtensions.Kill(_backwardsTween);
		}
		SetTrailAlpha(_GoldenTrail, 0f);
		base.Despawn();
	}

	public TP_GrandCross2_Projectile()
	{
		//IL_001f: Expected I, but got O
		nint num = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v3 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num2 = 0;
		_velocity = Vector2.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rcx_v3 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
		_ = 0;
		base._002Ector();
	}

	private float _003CDoTweens_003Eb__24_0()
	{
		return _acceleration;
	}

	private void _003CDoTweens_003Eb__24_1(float x)
	{
		_acceleration = x;
	}

	private float _003CGoBackwards_003Eb__25_0()
	{
		return _acceleration;
	}

	private void _003CGoBackwards_003Eb__25_1(float val)
	{
		_acceleration = val;
	}

	private void _003CGoBackwards_003Eb__25_2()
	{
		_canDespawn = true;
	}
}
