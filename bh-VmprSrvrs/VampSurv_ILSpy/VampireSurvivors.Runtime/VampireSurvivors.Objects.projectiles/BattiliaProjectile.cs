using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class BattiliaProjectile : Projectile
{
	protected float fixedDuration = 3000f;

	protected uint shadowTint = 16711680u;

	private float _currentDirectionX;

	private float _currentDirectionY;

	private Timer _expireTimer;

	protected PhaserSprite _batSprite;

	protected PhaserSprite _shadowSprite;

	private float2 previousPosition;

	private BattiliaWeapon trueWeapon;

	private bool isInitialised;

	private bool isFirstUpdate = true;

	public float TrueSpeed
	{
		get
		{
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Expected O, but got Unknown
			float num;
			if (!(GameManager.ProjectileSpeed > 2.4750001f))
			{
				object obj = GameManager.ProjectileSpeed & -2147483649L;
				bool flag = (nint)obj <= 2139095040;
				num = 2.4750001f;
				if (flag)
				{
					goto IL_006d;
				}
			}
			num = GameManager.ProjectileSpeed;
			goto IL_006d;
			IL_006d:
			float num2 = _weapon.PSpeed();
			Weapon weapon = _weapon;
			float num3 = ((Equipment)weapon)._003COwner_003Ek__BackingField.PMoveSpeed();
			float num4 = default(float);
			bool flag2 = !(num4 > 1f);
			float num5 = 1f;
			if (!flag2)
			{
				Weapon weapon2 = _weapon;
				float num6 = ((Equipment)weapon2)._003COwner_003Ek__BackingField.PMoveSpeed();
				num5 = num4;
			}
			float num7 = num * num4;
			float num8 = num7 * _speed;
			return num8 * num5;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		ArcadeSprite arcadeSprite = setVisible(visible: false);
		int num = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("Bat1_i0", 1, 4, "enemies", num);
		List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames("Bat2_i0", 1, 4, "enemies", num);
		List<Sprite> animationFrames3 = SpriteManager.GetAnimationFrames("Bat3_i0", 1, 4, "enemies", num);
		List<Sprite> animationFrames4 = SpriteManager.GetAnimationFrames("XLBat_i0", 1, 4, "enemies", num);
		PhaserWorld instance = PhaserWorld.Instance;
		float2 float5 = base.position;
		Vector2 pos = default(Vector2);
		PhaserSprite batSprite = instance.AddPhaserSprite(pos, "enemies", "Bat1_i01");
		_batSprite = batSprite;
		PhaserWorld instance2 = PhaserWorld.Instance;
		float2 float6 = base.position;
		PhaserSprite shadowSprite = instance2.AddPhaserSprite(pos, "enemies", "Bat1_i01");
		_shadowSprite = shadowSprite;
		PhaserSprite batSprite2 = _batSprite;
		bool startRandomFrame = default(bool);
		Action onComplete = default(Action);
		bool autoSetAnimation = default(bool);
		batSprite2._spriteAnimation.AddAnimation("idle1", animationFrames, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		PhaserSprite batSprite3 = _batSprite;
		batSprite3._spriteAnimation.AddAnimation("idle2", animationFrames2, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		PhaserSprite batSprite4 = _batSprite;
		batSprite4._spriteAnimation.AddAnimation("idle3", animationFrames3, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		PhaserSprite batSprite5 = _batSprite;
		batSprite5._spriteAnimation.AddAnimation("idle4", animationFrames4, 8, (byte)num != 0, startRandomFrame, onComplete, autoSetAnimation);
		PhaserSprite batSprite6 = _batSprite;
		batSprite6._spriteAnimation.SetAnimation("idle1");
		PhaserSprite phaserSprite = _batSprite.setVisible(visible: false);
		PhaserSprite phaserSprite2 = _shadowSprite.setVisible(visible: false);
		SetColors();
	}

	public unsafe override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_0058: Expected I, but got O
		//IL_0060: Expected I, but got O
		//IL_0070: Expected O, but got I
		//IL_00f0: Expected O, but got I4
		//IL_0045: Expected O, but got I4
		//IL_054e: Expected O, but got I4
		//IL_00ac: Expected O, but got I
		//IL_011f: Expected O, but got I4
		//IL_00e2: Expected O, but got I4
		//IL_0143: Expected O, but got I4
		//IL_0143: Expected O, but got I4
		//IL_017c: Expected O, but got I4
		//IL_056c: Expected O, but got F4
		//IL_05fd: Expected O, but got F4
		//IL_0582: Expected O, but got I4
		//IL_02f4: Expected F4, but got O
		//IL_0315: Expected F4, but got I
		//IL_0325: Invalid comparison between F4 and I4
		//IL_0336: Invalid comparison between F4 and I4
		//IL_0382: Invalid comparison between F4 and I4
		//IL_0393: Invalid comparison between F4 and I4
		//IL_0289: Expected O, but got Ref
		base.InitProjectile(pool, weapon, index);
		if (isInitialised)
		{
			return;
		}
		Weapon weapon2 = _weapon;
		isInitialised = true;
		float? num;
		if ((object)_weapon == null)
		{
			num = (float?)(object)0;
			goto IL_0527;
		}
		nint num2 = (nint)typeof(BattiliaWeapon);
		nint num3 = (nint)weapon2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ r8_v34 (Il2CppClass<VampireSurvivors.Objects.Weapons.BattiliaWeapon>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ r9_v14 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ r8_v34 (Il2CppClass<VampireSurvivors.Objects.Weapons.BattiliaWeapon>)+130]");
		object obj3;
		if (num4 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v212 @ r9_v14 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v364 @ rax_v102+FFFFFFF8+v213 @ rax_v97*8]");
			if (0 == (nint)typeof(BattiliaWeapon))
			{
				obj3 = 1;
				goto IL_0536;
			}
		}
		obj3 = 0;
		goto IL_0536;
		IL_0527:
		trueWeapon = (BattiliaWeapon)num;
		_isCullable = false;
		ArcadeSprite arcadeSprite = setScale(1f, (float?)(object)0);
		BaseBody baseBody = body.setCircle(8f, (float?)(object)1, (float?)(object)1);
		float num5 = weapon.PArea();
		BattiliaWeapon battiliaWeapon = trueWeapon;
		ArcadeSprite arcadeSprite2 = setScale(battiliaWeapon.physScale, (float?)(object)0);
		float num6 = default(float);
		PhaserSprite phaserSprite = RenderingExtensions.SetScale(_batSprite, num6);
		PhaserSprite phaserSprite2 = RenderingExtensions.SetScale(_shadowSprite, num6);
		BattiliaWeapon battiliaWeapon2 = trueWeapon;
		PhaserSprite phaserSprite3 = _batSprite.setAlpha(battiliaWeapon2.batAlpha);
		BattiliaWeapon battiliaWeapon3 = trueWeapon;
		PhaserSprite phaserSprite4 = _shadowSprite.setAlpha(battiliaWeapon3.shadowAlpha);
		SetAnims();
		object obj4 = UnityEngine.Random.value;
		object obj5 = UnityEngine.Random.value;
		float2 float5 = base.position;
		float2 float6 = base.position;
		float2 float7 = default(float2);
		base.position = float7;
		Transform transform = ((Equipment)weapon)._003COwner_003Ek__BackingField.transform;
		Weapon weapon3 = _weapon;
		bool flag = !weapon3.IsHoming;
		Transform target = transform;
		if (!flag)
		{
			GameManager core = GM.Core;
			if (((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0)
			{
				UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(transform);
				throw new NullReferenceException();
			}
			Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
			object obj6 = default(object);
			EnemyController enemyController = core._stage.FindClosestEnemy((Vector3)(&obj6), excludeDead: true);
			bool flag2 = (object)enemyController == null;
			target = transform;
			if (!flag2)
			{
				bool flag3 = ((UnityEngine.Object)enemyController).m_CachedPtr == (IntPtr)0;
				target = transform;
				if (!flag3)
				{
					Transform transform2 = enemyController.transform;
					target = transform2;
				}
			}
		}
		ApplyInitialVelocity(target, null, rotate: false, (Vector3?)(object)0);
		BaseBody baseBody2 = body;
		_currentDirectionX = (float)baseBody2._velocity;
		BaseBody baseBody3 = body;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v572 @ rax_v50 (BaseBody)+74]");
		_currentDirectionY = 0f;
		bool flag4 = _currentDirectionX < 0f;
		bool flag5 = _currentDirectionX == 0f;
		bool flag6 = !flag4;
		bool flag7 = !flag5;
		bool flag8 = flag7 & flag6;
		PhaserSprite phaserSprite5 = _batSprite.setFlipX(flag8);
		bool flag9 = _currentDirectionX < 0f;
		bool flag10 = _currentDirectionX == 0f;
		bool flag11 = !flag9;
		bool flag12 = !flag10;
		bool flag13 = flag12 & flag11;
		PhaserSprite phaserSprite6 = _shadowSprite.setFlipX(flag13);
		if (_expireTimer != null)
		{
			_expireTimer.Cancel();
		}
		Action onComplete = delegate
		{
			_isCullable = true;
		};
		float duration = fixedDuration * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer expireTimer = Timers.Register(duration, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_expireTimer = expireTimer;
		float2 float8 = base.position;
		previousPosition = float8;
		_ = 3229614080L;
		isFirstUpdate = true;
		PhaserSprite phaserSprite7 = _batSprite.setVisible(visible: false);
		PhaserSprite phaserSprite8 = _shadowSprite.setVisible(visible: false);
		BaseBody baseBody4 = body;
		baseBody4._enable = false;
		return;
		IL_0536:
		bool flag14 = obj3 == null;
		num = (float?)(object)0;
		if (!flag14)
		{
			num = (float?)_weapon;
		}
		goto IL_0527;
	}

	protected virtual void SetAnims()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3F84]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		PhaserSprite batSprite = _batSprite;
		if (_indexInWeapon >= 10)
		{
			if (_indexInWeapon >= 20)
			{
				batSprite._spriteAnimation.SetAnimation("idle3");
			}
			else
			{
				batSprite._spriteAnimation.SetAnimation("idle2");
			}
		}
		else
		{
			batSprite._spriteAnimation.SetAnimation("idle1");
		}
	}

	protected virtual void SetColors()
	{
		PhaserSprite phaserSprite = _shadowSprite.setTintFill(isEnabled: true, shadowTint);
	}

	public override void ApplyInitialVelocity(Transform target, Transform playerTransform, bool rotate = true, Vector3? customFromPosition = null)
	{
		//IL_017b: Expected I, but got O
		//IL_0019: Invalid comparison between O and F4
		//IL_020b: Expected I, but got O
		//IL_022b: Expected F4, but got I
		//IL_0234: Expected F4, but got O
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00f9: Invalid comparison between O and F4
		//IL_0167: Expected O, but got F4
		//IL_0143: Expected F4, but got O
		nint num = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rax_v2 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num2 = 0;
		bool flag = ((UnityEngine.Object)target).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)target).m_CachedPtr, out Vector3 ret);
		float2 float5 = base.position;
		object obj = (object)ret - (object)float5;
		float2 float6 = base.position;
		object obj3 = default(object);
		object obj4 = default(object);
		object obj2 = obj3 - obj4;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1829A85B0");
		float num3;
		float num4;
		if (System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref Vector2.zeroVector) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1E-05f))
		{
			num3 = (float)obj / (float)Vector2.zeroVector;
			num4 = (float)obj2 / (float)Vector2.zeroVector;
		}
		else
		{
			nint num5 = (nint)typeof(Vector2);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v407 @ rax_v44 (Il2CppClass<UnityEngine.Vector2>)+B8]");
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v408 @ rcx_v27 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
			num4 = 0f;
			num3 = (float)Vector2.zeroVector;
		}
		float num7;
		if (!(GameManager.ProjectileSpeed > 2.4750001f))
		{
			object obj5 = GameManager.ProjectileSpeed & -2147483649L;
			bool flag2 = (nint)obj5 <= 2139095040;
			num7 = 2.4750001f;
			if (flag2)
			{
				goto IL_00bf;
			}
		}
		num7 = GameManager.ProjectileSpeed;
		goto IL_00bf;
		IL_00bf:
		float num8 = _weapon.PSpeed();
		Weapon weapon = _weapon;
		float num9 = ((Equipment)weapon)._003COwner_003Ek__BackingField.PMoveSpeed();
		bool flag3 = System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref Vector2.zeroVector) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f);
		float num10 = 1f;
		if (!flag3)
		{
			Weapon weapon2 = _weapon;
			float num11 = ((Equipment)weapon2)._003COwner_003Ek__BackingField.PMoveSpeed();
			num10 = (float)Vector2.zeroVector;
		}
		float num12 = num7 * (float)Vector2.zeroVector;
		ArcadeSprite sprite = _sprite;
		float num13 = num12 * _speed;
		float num14 = num13 * num10;
		float num15 = num3 * num14;
		float num16 = num4 * num14;
		BaseBody baseBody = sprite.body;
		baseBody._velocity = (float2)num15;
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null && --_penetrating <= 0)
		{
			Despawn();
		}
	}

	public void RestoreVelocity()
	{
		//IL_0030: Expected O, but got F4
		ArcadeSprite sprite = _sprite;
		BaseBody baseBody = sprite.body;
		baseBody._velocity = (float2)_currentDirectionX;
		_ = _currentDirectionY;
	}

	public override void InternalUpdate()
	{
		float2 float5 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		float2 float6 = base.position;
		float deltaTime = PauseSystem.DeltaTime;
		float2 float7 = base.position;
		float deltaTime2 = PauseSystem.DeltaTime;
		float num = deltaTime2 * _currentDirectionY;
		float num2 = num + num;
		object obj = default(object);
		float num3 = (float)obj - num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
		PhaserSprite batSprite = _batSprite;
		Sprite sprite = batSprite._spriteRenderer.sprite;
		PhaserSprite phaserSprite = _shadowSprite.setFrame(sprite);
		int num4 = base.depth;
		PhaserSprite phaserSprite2 = _batSprite.setDepth(num4);
		int num5 = base.depth;
		int num6 = num5 - 1;
		PhaserSprite phaserSprite3 = _shadowSprite.setDepth(num6);
		if (!isFirstUpdate)
		{
			PhaserSprite phaserSprite4 = _batSprite.setVisible(visible: true);
			PhaserSprite phaserSprite5 = _shadowSprite.setVisible(visible: true);
			BaseBody baseBody = body;
			baseBody._enable = true;
		}
		isFirstUpdate = false;
	}

	public override void Despawn()
	{
		base.Despawn();
		PhaserSprite phaserSprite = _batSprite.setVisible(visible: false);
		PhaserSprite phaserSprite2 = _shadowSprite.setVisible(visible: false);
		isInitialised = false;
	}

	private void _003CInitProjectile_003Eb__14_0()
	{
		_isCullable = true;
	}
}
