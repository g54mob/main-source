using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using Events;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_Energy1_Projectile : Projectile
{
	private Timer _expireTimer;

	private float _saveVelX;

	private float _saveVelY;

	private float _spriteSize;

	private float _bodyRadius;

	protected float[] _firingAngles;

	private MultiTargetTween _scaleTween;

	protected override void Awake()
	{
		base.Awake();
		WORLD_BOUNDS_EVENT wORLD_BOUNDS_EVENT = Bounce;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA6950");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186BA8770");
		Sprite sprite = default(Sprite);
		ArcadeSprite arcadeSprite = setFrame(sprite);
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0024: Expected O, but got I4
		//IL_005b: Expected O, but got I4
		//IL_005b: Expected O, but got I4
		//IL_006f: Expected O, but got I4
		//IL_017e: Expected O, but got I4
		//IL_01b4: Expected O, but got I4
		//IL_01b4: Expected O, but got I4
		//IL_01e2: Expected I, but got O
		//IL_0229: Expected I4, but got I8
		//IL_02a4: Expected O, but got I4
		//IL_0257: Expected O, but got I4
		//IL_0260: Unknown result type (might be due to invalid IL or missing references)
		//IL_0265: Expected O, but got Unknown
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Expected I4, but got Unknown
		//IL_02bb: Expected O, but got I4
		//IL_02d4: Expected I, but got O
		//IL_0359: Expected O, but got F4
		base.InitProjectile(pool, weapon, index);
		_isCullable = false;
		float num = _weapon.PArea();
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		float num2 = _bodyRadius * 3f;
		BaseBody baseBody = base.body.setCircle(_bodyRadius, (float?)(object)1, (float?)(object)1);
		ArcadeSprite arcadeSprite2 = setScale(0.1f, (float?)(object)0);
		CheckRenderer();
		float num3 = _bodyRadius + _bodyRadius;
		float num4 = num3 / _spriteSize;
		SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(((ArcadeSprite)this)._spriteRenderer, num4);
		_speed = 1f;
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] targets = new object[1];
		SpriteRenderer spriteRenderer2 = RenderingExtensions.SetScale((SpriteRenderer)(object)this, num4);
		if ((object)spriteRenderer2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = targets;
			tweenConfig.duration = 200f;
			tweenConfig.scale = (float?)(object)1;
			MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
			_scaleTween = scaleTween;
			setCollideWorldBounds(value: true, (float?)(object)1, (float?)(object)1);
			VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)weapon)._003COwner_003Ek__BackingField;
			BaseBody baseBody2 = base.body;
			nint num5 = (nint)baseBody2;
			Body body = baseBody2.setBoundsRectangle(characterController._worldBoxCollider);
			BaseBody baseBody3 = base.body;
			baseBody3._onWorldBounds = true;
			int num6 = (int)(_indexInWeapon & 0x80000001L);
			if ((nint)baseBody3 < 0)
			{
				object obj = num6 - 1;
				object obj2 = obj | -2;
				num6 = obj2 + 1;
			}
			float2 float5 = base.position;
			Weapon weapon2 = _weapon;
			float2 float6 = ((Equipment)weapon2)._003COwner_003Ek__BackingField.position;
			bool flag = (byte)(float5 <= float6) != 0;
			float? num7 = (float?)(object)180;
			if (!flag)
			{
				num7 = (float?)(object)0;
			}
			float[] firingAngles = _firingAngles;
			nint num8 = (nint)this;
			float projectileSpeed = base.ProjectileSpeed;
			BaseBody baseBody4 = base.body;
			float num9 = (float)num7 + firingAngles[num6];
			float num10 = num9 * ((float)Math.PI / 180f);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F00");
			float num11 = num10 * (float)float5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003F60");
			float num12 = num10 * (float)float5;
			baseBody4._velocity = (float2)num11;
			if (_expireTimer != null)
			{
				_expireTimer.Cancel();
			}
			float num13 = _weapon.PDuration();
			float num14 = _weapon.PAmount();
			Action onComplete = FadeOutAndDispose;
			float num15 = num12 * num12;
			float duration = num15 * 0.001f;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			Timer expireTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
			_expireTimer = expireTimer;
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	public override void InternalUpdate()
	{
		//IL_001c: Expected F4, but got O
		//IL_006a: Expected F4, but got I
		object renderer = _renderer;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rdi_v1 (System.Object)+10]");
		bool flag = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rdi_v1 (System.Object)+10]");
		Renderer.set_sortingOrder_Injected((IntPtr)0, 2);
		BaseBody baseBody = body;
		float saveVelX = (float)baseBody._velocity;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001870E9C44h\"");
		if ((object)baseBody._velocity == null)
		{
			saveVelX = _saveVelX;
		}
		_saveVelX = saveVelX;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rax_v14 (BaseBody)+74]");
		float saveVelY = 0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001870E9C65h\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rax_v14 (BaseBody)+74]");
		if ((nint)0 == 0)
		{
			saveVelY = _saveVelY;
		}
		_saveVelY = saveVelY;
	}

	private void Bounce(Body b, bool up, bool down, bool left, bool right)
	{
		if (b == body)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
			PlayBounceSFX();
		}
	}

	private void PlayBounceSFX()
	{
		//IL_004b: Expected O, but got F4
		//IL_0079: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		object obj = UnityEngine.Random.value;
		object obj2 = default(object);
		float num = (float)obj2 - 0.5f;
		float detune = num * 200f;
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_GlobusBounce, soundConfig, 200f, 10, time);
	}

	private void FadeOutAndDispose()
	{
		//IL_003f: Expected I, but got O
		//IL_00a3: Expected O, but got I4
		//IL_00be: Expected I, but got O
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		nint num = (nint)array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj = default(object);
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			tweenConfig.targets = array;
			tweenConfig.duration = 200f;
			tweenConfig.scale = (float?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v302 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_Energy1_Projectile>)+370]");
			TweenCallback onComplete = new TweenCallback(this, (IntPtr)0);
			nint num2 = (nint)this;
			tweenConfig.onComplete = onComplete;
			MultiTargetTween scaleTween = Tweens.Add(tweenConfig);
			_scaleTween = scaleTween;
			Weapon weapon = _weapon;
			if (weapon._explodeOnExpire)
			{
				float2 pos = base.position;
				Projectile projectile = weapon.SpawnExplosionAt(pos, 0, 1, 0f);
			}
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	public override void OnHasHitWallPhaser(PhaserTile tile)
	{
		//IL_0050: Expected O, but got I4
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		//IL_00e7: Expected O, but got I8
		//IL_0214: Expected O, but got I4
		//IL_021c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0221: Expected O, but got Unknown
		//IL_00b6: Expected O, but got I4
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Expected O, but got Unknown
		//IL_00cc: Expected O, but got I4
		//IL_0168: Expected O, but got I8
		//IL_0137: Expected O, but got I4
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_014d: Expected O, but got I4
		//IL_018e: Expected O, but got F4
		int num = tile._data & 8;
		bool flag = num == 0;
		bool flag2 = num < 0;
		bool flag3 = !flag2;
		object obj = !flag;
		object obj2 = flag3 & obj;
		object obj5;
		if (obj2 == null)
		{
			int num2 = tile._data & 4;
			bool flag4 = num2 == 0;
			bool flag5 = num2 < 0;
			bool flag6 = !flag5;
			object obj3 = !flag6;
			object obj4 = obj3 | flag4;
			obj5 = 1;
			if (obj4 != null)
			{
				goto IL_01ae;
			}
		}
		obj5 = 4294967295L;
		goto IL_01ae;
		IL_022f:
		object obj6;
		float saveVelY = (float)obj6 * _saveVelY;
		_saveVelY = saveVelY;
		ArcadeSprite sprite = _sprite;
		BaseBody baseBody = sprite.body;
		baseBody._velocity = (float2)_saveVelX;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		PlayBounceSFX();
		return;
		IL_01ae:
		float saveVelX = (float)obj5 * _saveVelX;
		_saveVelX = saveVelX;
		int num3 = tile._data & 1;
		bool flag7 = num3 == 0;
		bool flag8 = num3 < 0;
		bool flag9 = !flag8;
		object obj7 = !flag7;
		object obj8 = flag9 & obj7;
		if (obj8 == null)
		{
			int num4 = tile._data & 2;
			bool flag10 = num4 == 0;
			bool flag11 = num4 < 0;
			bool flag12 = !flag11;
			object obj9 = !flag12;
			object obj10 = obj9 | flag10;
			obj6 = 1;
			if (obj10 != null)
			{
				goto IL_022f;
			}
		}
		obj6 = 4294967295L;
		goto IL_022f;
	}

	public override void Despawn()
	{
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		if (_scaleTween != null)
		{
			_scaleTween.Kill();
		}
		base.Despawn();
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
	}

	public TP_Energy1_Projectile()
	{
		//IL_0026: Expected F4, but got I4
		//IL_003d: Expected F4, but got I8
		_spriteSize = 64f;
		_bodyRadius = 8f;
		_firingAngles = new float[2] { 1.1107041E+09f, 3.2581878E+09f };
		base._002Ector();
	}
}
