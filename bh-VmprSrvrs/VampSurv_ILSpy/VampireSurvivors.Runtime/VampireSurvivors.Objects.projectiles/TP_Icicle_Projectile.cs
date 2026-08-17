using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using QFSW.MOP2;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Icicle_Projectile : Projectile
{
	private Timer _hitboxTimer;

	private Timer _expireTimer;

	private Timer _expireTimer2;

	private MultiTargetTween _scaleTween;

	private MultiTargetTween _alphaTween;

	private float _deltaTime;

	private float2 posOffset;

	private PhaserSprite _crystalSprite;

	private PhaserSprite _icicleSprite;

	private PhaserSprite _animatedSprite;

	private const float Percentage = 0.0625f;

	private const float Radius = 0.5f;

	private const float SpeedModifier = 35f;

	private List<string> _frameNames;

	private float _angle1;

	private float _angle2;

	private float _angle3;

	private bool isAiming;

	private bool isExploding;

	private TP_Icicle_Weapon trueWeapon;

	private float2 targetPosition;

	protected override void Awake()
	{
		//IL_01a7: Expected O, but got I4
		//IL_01a7: Expected I4, but got O
		//IL_01b2: Expected O, but got I4
		base.Awake();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		_renderer.sprite = sprite;
		_renderer.enabled = false;
		GameObject gameObject = base.gameObject;
		Vector2 vector = default(Vector2);
		PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, vector, "ThosePeople", "TP_VFX_Icicle01");
		PhaserSprite phaserSprite2 = phaserSprite.setAlpha(0.65f);
		PhaserSprite crystalSprite = phaserSprite2.setBlendMode(BlendMode.Add);
		_crystalSprite = crystalSprite;
		string spriteName = Extensions.PickRnd(_frameNames);
		GameObject gameObject2 = base.gameObject;
		PhaserSprite phaserSprite3 = RenderingExtensions.AddPhaserSprite(gameObject2, vector, "ThosePeople", spriteName);
		PhaserSprite icicleSprite = phaserSprite3.setAlpha(0.65f);
		_icicleSprite = icicleSprite;
		string spriteName2 = Extensions.PickRnd(_frameNames);
		GameObject gameObject3 = base.gameObject;
		PhaserSprite phaserSprite4 = RenderingExtensions.AddPhaserSprite(gameObject3, vector, "ThosePeople", spriteName2);
		PhaserSprite phaserSprite5 = phaserSprite4.setAlpha(0.65f);
		PhaserSprite animatedSprite = phaserSprite5.setVisible(visible: false);
		_animatedSprite = animatedSprite;
		string text = default(string);
		int num = default(int);
		bool flag = default(bool);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_VFX_IcicleD", 1, 10, vector, text, num, flag);
		PhaserSprite animatedSprite2 = _animatedSprite;
		bool autoSetAnimation = default(bool);
		animatedSprite2._spriteAnimation.AddAnimation("explode", animationFrames, 32, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
		targetPosition = (float2)1065353216;
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0021: Expected I, but got O
		//IL_0029: Expected I, but got O
		//IL_0039: Expected O, but got I
		//IL_00b9: Expected O, but got I4
		//IL_000e: Expected O, but got I4
		//IL_0714: Expected O, but got I4
		//IL_0075: Expected O, but got I
		//IL_00ab: Expected O, but got I4
		//IL_072b: Expected O, but got F4
		//IL_0854: Expected O, but got F4
		//IL_0760: Expected O, but got F4
		//IL_07a4: Expected O, but got I4
		//IL_0175: Expected O, but got I
		//IL_018c: Invalid comparison between O and F4
		//IL_020f: Expected O, but got I4
		//IL_020f: Expected O, but got I4
		//IL_0223: Expected O, but got I4
		//IL_01cd: Expected O, but got I4
		//IL_02b8: Expected I, but got O
		//IL_0326: Expected O, but got I4
		//IL_03af: Expected I, but got O
		//IL_040f: Expected O, but got I4
		//IL_0545: Expected I, but got O
		//IL_0809: Unknown result type (might be due to invalid IL or missing references)
		//IL_080e: Expected O, but got Unknown
		//IL_0831: Expected O, but got F4
		//IL_0650: Expected O, but got F4
		//IL_0671: Expected O, but got I4
		//IL_06a0: Expected F4, but got I4
		//IL_02db->IL02db: Incompatible stack heights: 1 vs 0
		base.InitProjectile(pool, weapon, index);
		_isCullable = false;
		isExploding = false;
		float? num;
		if ((object)weapon == null)
		{
			num = (float?)(object)0;
			goto IL_06ed;
		}
		nint num2 = (nint)typeof(TP_Icicle_Weapon);
		nint num3 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdx_v71 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Icicle_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r8_v60 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdx_v71 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_Icicle_Weapon>)+130]");
		object obj3;
		if (num4 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ r8_v60 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rax_v136+FFFFFFF8+v71 @ rax_v131*8]");
			if (0 == (nint)typeof(TP_Icicle_Weapon))
			{
				obj3 = 1;
				goto IL_06fc;
			}
		}
		obj3 = 0;
		goto IL_06fc;
		IL_06fc:
		bool flag = obj3 == null;
		num = (float?)(object)0;
		if (!flag)
		{
			num = (float?)weapon;
		}
		goto IL_06ed;
		IL_06ed:
		trueWeapon = (TP_Icicle_Weapon)num;
		PhaserSprite phaserSprite = _animatedSprite.setVisible(visible: false);
		PhaserSprite phaserSprite2 = _icicleSprite.setVisible(visible: true);
		object obj4 = UnityEngine.Random.value;
		object obj6 = default(object);
		object obj5 = obj6 + obj6;
		float num5 = (_angle1 = (float)obj5 * (float)Math.PI);
		object obj7 = UnityEngine.Random.value;
		float num6 = num5 + num5;
		float num7 = (_angle2 = num6 * (float)Math.PI);
		object obj8 = UnityEngine.Random.value;
		float num8 = num7 + num7;
		_speed = 2f;
		float num9 = (_angle3 = num8 * (float)Math.PI);
		setVelocity(0f, (float?)(object)1);
		isAiming = true;
		PhaserSprite phaserSprite3 = _icicleSprite.setBlendMode(BlendMode.Normal);
		TP_Icicle_Weapon tP_Icicle_Weapon = trueWeapon;
		BulletPool projectilePool = ((Weapon)tP_Icicle_Weapon)._projectilePool;
		ObjectPool pool2 = projectilePool._pool;
		Dictionary<int, GameObject> aliveObjects = pool2._aliveObjects;
		float num10 = trueWeapon.PAmount();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v415 @ rsi_v9 (System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.GameObject>)+20]");
		nint num11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v415 @ rsi_v9 (System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.GameObject>)+28]");
		object obj9 = num11 - 0;
		float num12 = num9 + num9;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj9) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num12))
		{
			int num13 = _indexInWeapon & 1;
			bool flag2 = num13 == 0;
			object obj10 = !flag2;
			if (obj10 == null)
			{
				PhaserSprite phaserSprite4 = _icicleSprite.setBlendMode(BlendMode.Add);
			}
		}
		BaseBody baseBody = body.setCircle(16f, (float?)(object)1, (float?)(object)1);
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
		PhaserSprite phaserSprite5 = _crystalSprite.setAlpha(0.65f);
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		if ((object)_crystalSprite != null)
		{
			nint num14 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj11 = default(object);
			bool flag3 = obj11 == null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 500f;
		tweenConfig.delay = 500f;
		tweenConfig.alpha = (float?)(object)1;
		MultiTargetTween alphaTween = Tweens.Add(tweenConfig);
		_alphaTween = alphaTween;
		float num15 = _weapon.PArea();
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig2 = new TweenConfig();
		object[] array2 = new object[1];
		nint num16 = (nint)array2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj12 = default(object);
		bool flag4 = obj12 == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig2.targets = array2;
		tweenConfig2.duration = 500f;
		tweenConfig2.scale = (float?)(object)1;
		MultiTargetTween scaleTween = Tweens.Add(tweenConfig2);
		_scaleTween = scaleTween;
		float hitBoxDelay = _weapon.HitBoxDelay;
		Action onComplete = delegate
		{
			if (_objectsHit != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
			}
		};
		float num17 = hitBoxDelay * 0.001f;
		bool flag5 = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer hitboxTimer = Timers.Register(num17, onComplete, null, isLooped: true, flag5, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_hitboxTimer = hitboxTimer;
		float num18 = _weapon.PDuration();
		Action onComplete2 = Shoot;
		float num19 = num17 * 0.001f;
		Timer expireTimer = Timers.Register(num19, onComplete2, null, isLooped: false, flag5, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_expireTimer = expireTimer;
		TP_Icicle_Weapon tP_Icicle_Weapon2 = trueWeapon;
		Weapon weapon2 = _weapon;
		nint num20 = (nint)weapon2;
		float num21 = weapon2.PAmount();
		float num22 = (float)Math.PI * 2f / num19;
		float num23 = num22 * (float)_indexInWeapon;
		float num24 = (_deltaTime = num23 + tP_Icicle_Weapon2.angleTime);
		bool flag6 = num12 > 4.5f;
		float num25 = 4.5f;
		if (!flag6)
		{
			num25 = num12;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		float num26 = num24 * num25;
		float num27 = num26 * 0.5f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		object obj13 = num24 ^ 0;
		TP_Icicle_Weapon tP_Icicle_Weapon3 = trueWeapon;
		float num28 = (float)obj13 * num25;
		posOffset = (float2)num27;
		float num29 = num28 * 0.5f;
		Weapon weapon3 = _weapon;
		float2 float5 = ((Equipment)weapon3)._003COwner_003Ek__BackingField.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		float num30 = tP_Icicle_Weapon3.AimTime * 5f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		float num31 = tP_Icicle_Weapon3.AimTime * 5f;
		float num32 = (float)float5 + num30;
		float num33 = num12 + num31;
		targetPosition = (float2)num32;
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.sfx_javelin2, new SoundManager.SoundConfig
		{
			Volume = (float?)(object)1,
			Rate = 1f
		}, 200f, 1, flag5 ? 1 : 0);
	}

	private void AimAtTarget()
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		float2 float5 = base.position;
		object obj = targetPosition - float5;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TP_Icicle_Projectile)+144]");
		object obj3 = default(object);
		object obj2 = 0 - obj3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
		float num = (float)obj2 * 57.29578f;
		_icicleSprite.angle = num;
	}

	public unsafe override void InternalUpdate()
	{
		//IL_00ba: Expected O, but got Ref
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Expected O, but got Unknown
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * 1000f;
		float num2 = num * 2.1618f;
		float num3 = num * 1.6181f;
		float angle = num2 + _angle2;
		float angle2 = num + _angle1;
		float angle3 = num3 + _angle3;
		_angle2 = angle;
		_angle1 = angle2;
		_angle3 = angle3;
		Transform transform = _crystalSprite.transform;
		object obj = default(object);
		transform.Rotate((Vector3)(&obj), 2f, Space.Self);
		if (isAiming)
		{
			Weapon weapon = _weapon;
			float2 float5 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
			float2 float6 = default(float2);
			base.position = float6;
			float2 float7 = base.position;
			object obj2 = targetPosition - float7;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.TP_Icicle_Projectile)+144]");
			object obj4 = default(object);
			object obj3 = 0 - obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
			float num4 = (float)obj3 * 57.29578f;
			_icicleSprite.angle = num4;
		}
	}

	public override void Despawn()
	{
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		if (_expireTimer2 != null)
		{
			_expireTimer2.Cancel();
		}
		base.Despawn();
	}

	public void Shoot()
	{
		//IL_00b3: Expected I, but got O
		//IL_0137: Expected O, but got F4
		//IL_01ac: Expected O, but got F4
		//IL_01d7: Expected O, but got I4
		_isCullable = true;
		if (_alphaTween != null)
		{
			_alphaTween.Kill();
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		if (_hitboxTimer != null)
		{
			_hitboxTimer.Cancel();
		}
		isAiming = false;
		Transform transform = _icicleSprite.transform;
		Vector3 localEulerAngles = transform.localEulerAngles;
		nint num = (nint)this;
		float projectileSpeed = base.ProjectileSpeed;
		float num2 = localEulerAngles.z * ((float)Math.PI / 180f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
		object obj = default(object);
		float num3 = num2 * (float)obj;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
		ArcadeSprite sprite = _sprite;
		float num4 = num2 * (float)obj;
		BaseBody baseBody = sprite.body;
		baseBody._velocity = (float2)num3;
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		object obj2 = UnityEngine.Random.value;
		float detune = num4 * 200f;
		soundConfig.Detune = detune;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_ShieldDark1, soundConfig, 200f, 1, time);
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		//IL_00d3: Expected O, but got I4
		//IL_0171: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj != null)
		{
			return;
		}
		bool flag = TryFreeze(other);
		if (!isAiming && --_penetrating <= 0 && !isExploding)
		{
			isExploding = true;
			setVelocity(0f, (float?)(object)1);
			PhaserSprite phaserSprite = _animatedSprite.setVisible(visible: true);
			PhaserSprite phaserSprite2 = _icicleSprite.setVisible(visible: false);
			PhaserSprite animatedSprite = _animatedSprite;
			animatedSprite._spriteAnimation.SetAnimation("explode");
			if (_expireTimer2 != null)
			{
				_expireTimer2.Cancel();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Icicle_Projectile>)+370]");
			Action onComplete = new Action(this, (IntPtr)0);
			nint num = (nint)this;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer expireTimer = Timers.Register(0.3f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_expireTimer2 = expireTimer;
		}
	}

	public TP_Icicle_Projectile()
	{
		List<string> list = new List<string>();
		list._version++;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Icicle02");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Icicle03");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		list._version++;
		string[] items3 = list._items;
		if (list._size >= items3.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Icicle04");
		}
		else
		{
			list._size++;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		_frameNames = list;
		base._002Ector();
	}

	private void _003CInitProjectile_003Eb__22_0()
	{
		if (_objectsHit != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		}
	}
}
