using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class LEM_Banana1_Projectile : Projectile
{
	private SpriteTrail _SpriteTrail;

	private SpriteRenderer _SpriteTrailSprite;

	protected readonly float2 RotationDegRange;

	protected LEM_Banana1_Weapon _trueWeapon;

	protected PhaserSprite _bananaSprite;

	protected float _rotationDeg;

	protected int _flipSign;

	protected Timer _expireTimer;

	private bool _003CIsCrit_003Ek__BackingField;

	private bool _003CHasExploded_003Ek__BackingField;

	protected virtual float Radius => 8f;

	protected unsafe virtual SpriteTextureData BananaSprite
	{
		get
		{
			//IL_0063: Expected native int or pointer, but got O
			SpriteTextures.SpriteTexturesLemon lemon = SpriteTextures.Lemon;
			if (SpriteTextures.Lemon != null && lemon.LEM_Vfx != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A0E54]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				SpriteTextureData spriteTextureData = default(SpriteTextureData);
				System.Runtime.CompilerServices.Unsafe.Write(&((SpriteTextureData*)(nint)spriteTextureData)->Sprite, "LEM_VFX_GrosMichel");
				return spriteTextureData;
			}
			return (SpriteTextureData)new NullReferenceException();
		}
	}

	protected unsafe virtual SpriteTextureData TrailSprite
	{
		get
		{
			//IL_0063: Expected native int or pointer, but got O
			SpriteTextures.SpriteTexturesLemon lemon = SpriteTextures.Lemon;
			if (SpriteTextures.Lemon != null && lemon.LEM_Vfx != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A0E55]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				SpriteTextureData spriteTextureData = default(SpriteTextureData);
				System.Runtime.CompilerServices.Unsafe.Write(&((SpriteTextureData*)(nint)spriteTextureData)->Sprite, "LEM_VFX_GrosMichel_Trail");
				return spriteTextureData;
			}
			return (SpriteTextureData)new NullReferenceException();
		}
	}

	protected virtual float BananaSpriteScale => 0.25f;

	protected virtual float LaunchAngleOffset => (float)_indexInWeapon * 15f;

	protected float CurveAnglePerSec
	{
		get
		{
			float deltaTime = PauseSystem.DeltaTime;
			return deltaTime * 5f;
		}
	}

	protected float RotationDegPerSec
	{
		get
		{
			float deltaTime = PauseSystem.DeltaTime;
			return deltaTime * _rotationDeg;
		}
	}

	public bool IsCrit
	{
		get
		{
			return _003CIsCrit_003Ek__BackingField;
		}
		private set
		{
			_003CIsCrit_003Ek__BackingField = value;
		}
	}

	public bool HasExploded
	{
		get
		{
			return _003CHasExploded_003Ek__BackingField;
		}
		set
		{
			_003CHasExploded_003Ek__BackingField = value;
		}
	}

	protected override void Awake()
	{
		//IL_00d6: Expected O, but got I4
		//IL_018e: Expected F4, but got O
		base.Awake();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999FBD5]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		_renderer.sprite = sprite;
		_renderer.enabled = false;
		SpriteTextureData bananaSprite = BananaSprite;
		GameObject gameObject = base.gameObject;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,8\"");
		Vector2 pos = default(Vector2);
		PhaserSprite phaserSprite = RenderingExtensions.AddPhaserSprite(gameObject, pos, bananaSprite.Sprite, bananaSprite.Sprite);
		float bananaSpriteScale = BananaSpriteScale;
		float xScale = default(float);
		PhaserSprite phaserSprite2 = phaserSprite.setScale(xScale, (float?)(object)0);
		GameObject gameObject2 = phaserSprite2.gameObject;
		((UnityEngine.Object)gameObject2).SetName("BananaSprite");
		_bananaSprite = phaserSprite2;
		SpriteTextureData trailSprite = TrailSprite;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
		Sprite sprite2 = SpriteManager.GetSprite(trailSprite.Sprite, trailSprite.Sprite);
		_SpriteTrailSprite.sprite = sprite2;
		_SpriteTrailSprite.enabled = false;
		float bananaSpriteScale2 = BananaSpriteScale;
		SpriteTrail spriteTrail = RenderingExtensions.SetScale(_SpriteTrail, (float)trailSprite.Sprite);
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_001d: Expected I, but got O
		//IL_0025: Expected I4, but got O
		//IL_0035: Expected O, but got I
		//IL_00b5: Expected O, but got I4
		//IL_0071: Expected O, but got I
		//IL_0113: Expected O, but got F4
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Expected O, but got Unknown
		//IL_00a7: Expected O, but got I4
		//IL_014a: Expected O, but got I4
		//IL_014a: Expected O, but got I4
		//IL_0176: Expected O, but got I4
		//IL_01af: Expected O, but got I
		//IL_0229: Expected O, but got Ref
		//IL_0240: Expected F4, but got I
		//IL_0240: Expected F4, but got O
		//IL_0215: Expected O, but got I8
		base.InitProjectile(pool, weapon, index);
		Weapon weapon2 = _weapon;
		LEM_Banana1_Weapon trueWeapon;
		if ((object)_weapon == null)
		{
			trueWeapon = null;
			goto IL_029e;
		}
		nint num = (nint)typeof(LEM_Banana1_Weapon);
		int num2 = (int)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rdx_v22 (Il2CppClass<VampireSurvivors.Objects.Weapons.LEM_Banana1_Weapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r9_v9 (System.Int32)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rdx_v22 (Il2CppClass<VampireSurvivors.Objects.Weapons.LEM_Banana1_Weapon>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r9_v9 (System.Int32)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rax_v41+FFFFFFF8+v66 @ rax_v36*8]");
			if (0 == (nint)typeof(LEM_Banana1_Weapon))
			{
				obj3 = 1;
				goto IL_02ad;
			}
		}
		obj3 = 0;
		goto IL_02ad;
		IL_02ad:
		bool flag = obj3 == null;
		trueWeapon = null;
		if (!flag)
		{
			trueWeapon = (LEM_Banana1_Weapon)_weapon;
		}
		goto IL_029e;
		IL_029e:
		_trueWeapon = trueWeapon;
		CheckForCrit();
		_003CHasExploded_003Ek__BackingField = false;
		_speed = 2f;
		_bounces = 1;
		float radius = Radius;
		float radius2 = Radius;
		float num4 = default(float);
		object obj4 = num4 ^ -0f;
		float radius3 = Radius;
		object obj5 = obj4 ^ -0f;
		BaseBody baseBody = body.setCircle(num4, (float?)(object)1, (float?)(object)1);
		SetScaleToArea();
		BaseBody baseBody2 = body;
		baseBody2._checkCollision = (ArcadeBodyCollision)15;
		float2 float5 = base.position;
		float num5 = (float)obj5 + 0.16f;
		float2 float6 = default(float2);
		base.position = float6;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		bool flag2 = (nint)0 != 0;
		ArcadeSprite arcadeSprite = this;
		if (!flag2)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj6 == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
			arcadeSprite = (ArcadeSprite)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v394 @ rax_v24 (should have been resolved before IL gen)");
		object obj7 = default(object);
		_cachedTransform.localEulerAngles = (Vector3)(&obj7);
		float2 rotationDegRange = RotationDegRange;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.LEM_Banana1_Projectile)+E4]");
		float rotationDeg = UnityEngine.Random.Range((float)rotationDegRange, 0f);
		_rotationDeg = rotationDeg;
		ResetExpireTimer();
		PlayThrowSfx();
	}

	private void CheckForCrit()
	{
		//IL_0065: Expected O, but got I
		//IL_00d2: Invalid comparison between F4 and I
		//IL_00f8: Invalid comparison between F4 and I4
		LEM_Banana1_Weapon trueWeapon = _trueWeapon;
		List<float> critChancesArray = ((Weapon)trueWeapon)._critChancesArray;
		int critIndex = ((Weapon)trueWeapon)._critIndex;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rcx_v6 (System.Collections.Generic.List`1<System.Single>)+18]");
		int num = (int)((nint)critIndex % (nint)0);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rcx_v6 (System.Collections.Generic.List`1<System.Single>)+18]");
		if ((nint)num < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rcx_v6 (System.Collections.Generic.List`1<System.Single>)+10]");
			object obj = 0;
			int critIndex2 = ((Weapon)trueWeapon)._critIndex + 1;
			((Weapon)trueWeapon)._critIndex = critIndex2;
			WeaponData currentWeaponData = ((Weapon)trueWeapon)._currentWeaponData;
			float num2 = ((Equipment)trueWeapon)._003COwner_003Ek__BackingField.PLuck();
			object obj2 = default(object);
			float num3 = (float)obj2 * currentWeaponData._003CcritChance_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rcx_v7+20+v44 @ rdx_v5 (System.Int32)*4]");
			bool flag = num3 < 0f;
			float num4 = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ rcx_v7+20+v44 @ rdx_v5 (System.Int32)*4]");
			float num5 = num4 - 0f;
			bool flag2 = num5 == 0f;
			bool flag3 = !flag;
			bool flag4 = !flag2;
			bool flag5 = flag4 & flag3;
			_003CIsCrit_003Ek__BackingField = flag5;
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	private unsafe void InitPositionAndRotation()
	{
		//IL_0039: Expected O, but got I
		//IL_00b3: Expected O, but got Ref
		//IL_00ca: Expected F4, but got I
		//IL_00ca: Expected F4, but got O
		//IL_009f: Expected O, but got I8
		float2 float5 = base.position;
		object obj = default(object);
		float num = (float)obj + 0.16f;
		float2 float6 = default(float2);
		base.position = float6;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		bool flag = (nint)0 != 0;
		ArcadeSprite arcadeSprite = this;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj2 == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
			arcadeSprite = (ArcadeSprite)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v62 @ rax_v7 (should have been resolved before IL gen)");
		object obj3 = default(object);
		_cachedTransform.localEulerAngles = (Vector3)(&obj3);
		float2 rotationDegRange = RotationDegRange;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.LEM_Banana1_Projectile)+E4]");
		float rotationDeg = UnityEngine.Random.Range((float)rotationDegRange, 0f);
		_rotationDeg = rotationDeg;
	}

	private void ResetExpireTimer()
	{
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		float num = _weapon.PDuration();
		Action onComplete = StartDespawn;
		object obj = default(object);
		float duration = (float)obj * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer expireTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_expireTimer = expireTimer;
	}

	public void SetBehaviour(Vector2 playerDir)
	{
		SetFlipFromPlayerDirection(playerDir);
		Weapon weapon = _weapon;
		if (!weapon.IsHoming)
		{
			AimInDirection(playerDir);
		}
		else
		{
			Transform transform = base.AimForNearestEnemy(rotate: false);
		}
	}

	protected void SetFlipFromPlayerDirection(Vector2 playerDir)
	{
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_0013: Expected O, but got I4
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected I4, but got Unknown
		bool flag = 0 < (nint)playerDir;
		object obj = 0 - playerDir;
		bool flag2 = obj == null;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		bool flag5 = flag4 & flag3;
		object obj2 = (flag5 ? 1 : 0) ^ 1;
		object obj3 = obj2 * 2;
		int flipSign = obj3 - 1;
		_flipSign = flipSign;
		PhaserSprite phaserSprite = _bananaSprite.setFlipX(flag5);
		_SpriteTrailSprite.flipX = flag5;
	}

	protected virtual void AimInDirection(Vector2 playerDir)
	{
		//IL_0005: Expected I, but got O
		//IL_0014: Expected I, but got O
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		nint num = (nint)this;
		float launchAngleOffset = LaunchAngleOffset;
		nint num2 = (nint)this;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
		object obj = default(object);
		float num3 = (float)obj * 57.29578f;
		object obj3 = default(object);
		object obj2 = _flipSign * obj3;
		float num4 = num3 + (float)obj2;
		float num5 = num4 * ((float)Math.PI / 180f);
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: [v24 @ rbx_v1 (Il2CppClass<VampireSurvivors.Objects.Projectiles.LEM_Banana1_Projectile>)+418] (should have been resolved before IL gen)");
		/*Error: End of method reached without returning.*/;
	}

	public unsafe override void InternalUpdate()
	{
		//IL_0134: Expected O, but got Ref
		//IL_0116: Expected O, but got F4
		Weapon weapon = _weapon;
		if (!weapon.IsHoming)
		{
			BaseBody baseBody = body;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C244F0");
			float deltaTime = PauseSystem.DeltaTime;
			float num = deltaTime * 5f;
			float num2 = _weapon.PSpeed();
			float num3 = num * deltaTime;
			float num4 = num3 * (float)_flipSign;
			object obj = default(object);
			float num5 = (float)obj * num4;
			object obj2 = default(object);
			float num6 = (float)obj2 * num4;
			float num7 = (float)baseBody._velocity - num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rax_v6 (BaseBody)+74]");
			float num8 = 0f - num6;
			ArcadeSprite sprite = _sprite;
			BaseBody baseBody2 = sprite.body;
			baseBody2._velocity = (float2)num7;
		}
		float deltaTime2 = PauseSystem.DeltaTime;
		object obj3 = default(object);
		_cachedTransform.Rotate((Vector3)(&obj3), Space.Self);
	}

	private void UpdateVelocity()
	{
		//IL_0116: Expected O, but got F4
		Weapon weapon = _weapon;
		if (!weapon.IsHoming)
		{
			BaseBody baseBody = body;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C244F0");
			float deltaTime = PauseSystem.DeltaTime;
			float num = deltaTime * 5f;
			float num2 = _weapon.PSpeed();
			float num3 = num * deltaTime;
			float num4 = num3 * (float)_flipSign;
			object obj = default(object);
			float num5 = (float)obj * num4;
			object obj2 = default(object);
			float num6 = (float)obj2 * num4;
			float num7 = (float)baseBody._velocity - num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rax_v5 (BaseBody)+74]");
			float num8 = 0f - num6;
			ArcadeSprite sprite = _sprite;
			BaseBody baseBody2 = sprite.body;
			baseBody2._velocity = (float2)num7;
		}
	}

	private unsafe void UpdateRotation()
	{
		//IL_0022: Expected O, but got Ref
		float deltaTime = PauseSystem.DeltaTime;
		object obj = default(object);
		_cachedTransform.Rotate((Vector3)(&obj), Space.Self);
	}

	protected virtual void PlayThrowSfx()
	{
		//IL_004b: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		float detune = (float)_indexInWeapon * -150f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.LEM_sfx_banana_throw1, soundConfig, 200f, 10, time);
	}

	private void PlayBounceSfx()
	{
		//IL_009a: Expected O, but got F4
		//IL_00c8: Expected O, but got I4
		if (!_trueWeapon.DespawnOnExplode || !_003CHasExploded_003Ek__BackingField)
		{
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			object obj = UnityEngine.Random.value;
			object obj2 = default(object);
			float num = (float)obj2 - 0.5f;
			float detune = num * 200f;
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Detune = detune;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.LEM_sfx_banana_bounce, soundConfig, 200f, 10, time);
		}
	}

	private void StartDespawn()
	{
		//IL_0013: Expected O, but got I4
		//IL_004c: Expected I, but got O
		BaseBody baseBody = body;
		baseBody._checkCollision = (ArcadeBodyCollision)0;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(_cachedTransform, 0f, 0.25f);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Projectiles.LEM_Banana1_Projectile>)+370]");
		TweenCallback tweenCallback = new TweenCallback(this, (IntPtr)0);
		nint num = (nint)this;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rax_v5 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
	}

	public override void Despawn()
	{
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		base.Despawn();
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		OnHasHitAnObjectLogic(other, triggerHit: true);
	}

	protected override void OnHasHitAnotherPlayerObject(IDamageable other)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 2 Invalid \"Jump target not found in method: 0x18724ED40\"");
	}

	protected void OnHasHitAnObjectLogic(IDamageable other, bool triggerHit)
	{
		//IL_01e1: Expected O, but got F4
		//IL_020f: Expected O, but got I4
		//IL_0183: Expected F4, but got I4
		//IL_0193: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj != null)
		{
			return;
		}
		if (_bounces <= 0)
		{
			if (triggerHit && --_penetrating <= 0)
			{
				Despawn();
			}
			return;
		}
		float num = _speed + 0.5f;
		int bounces = _bounces - 1;
		_bounces = bounces;
		_speed = num;
		LEM_Banana1_Weapon trueWeapon = _trueWeapon;
		int num2;
		if (trueWeapon.DespawnOnExplode)
		{
			bool flag = _003CHasExploded_003Ek__BackingField;
			IntPtr intPtr = default(IntPtr);
			num2 = (int)(nint)intPtr;
			if (flag)
			{
				goto IL_0188;
			}
		}
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		object obj2 = UnityEngine.Random.value;
		float num3 = num - 0.5f;
		float detune = num3 * 200f;
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.LEM_sfx_banana_bounce, soundConfig, 200f, 10, time);
		num2 = 10;
		num = 0f;
		goto IL_0188;
		IL_0188:
		ResetExpireTimer();
		nint num4 = (nint)this;
		Transform transform = base.AimForRandomEnemy();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004C40");
		_003CHasExploded_003Ek__BackingField = false;
		CheckForCrit();
	}

	public LEM_Banana1_Projectile()
	{
		//IL_0017: Expected O, but got I4
		RotationDegRange = (float2)1135869952;
		_ = 1144258560;
		base._002Ector();
	}
}
