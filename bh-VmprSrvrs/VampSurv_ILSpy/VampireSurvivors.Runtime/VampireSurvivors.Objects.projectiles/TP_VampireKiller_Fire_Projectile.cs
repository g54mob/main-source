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
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class TP_VampireKiller_Fire_Projectile : Projectile
{
	private ParticleSystem _pfxEmitter;

	private Tween _scaleTween;

	private PhaserSprite _animatedSprite;

	private uint[] _tints = new uint[3] { 16711680u, 16776960u, 255u };

	private bool _isDespawning;

	protected override void Awake()
	{
		//IL_00d8: Expected O, but got I4
		//IL_00d8: Expected I4, but got O
		base.Awake();
		GenerateParticleSystem();
		Sprite sprite = SpriteManager.GetSprite("WhiteDot", "vfx");
		_renderer.sprite = sprite;
		_renderer.enabled = false;
		GameObject gameObject = base.gameObject;
		Vector2 vector = default(Vector2);
		PhaserSprite animatedSprite = RenderingExtensions.AddPhaserSprite(gameObject, vector, "ThosePeople", "TP_VFX_Fireball01");
		_animatedSprite = animatedSprite;
		string text = default(string);
		int num = default(int);
		bool flag = default(bool);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("TP_VFX_Fireball", 1, 8, vector, text, num, flag);
		PhaserSprite animatedSprite2 = _animatedSprite;
		bool autoSetAnimation = default(bool);
		animatedSprite2._spriteAnimation.AddAnimation("loop", animationFrames, 32, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
		PhaserSprite animatedSprite3 = _animatedSprite;
		animatedSprite3._spriteAnimation.SetAnimation("loop");
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_002a: Expected O, but got I4
		//IL_002a: Expected O, but got I4
		//IL_00b9: Expected F4, but got O
		//IL_0160: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		Transform cachedTransform = _cachedTransform;
		_speed = 1.65f;
		_isDespawning = false;
		bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref value);
		BaseBody baseBody = body.setCircle(12f, (float?)(object)1, (float?)(object)1);
		float2 float5 = base.position;
		float2 float6 = default(float2);
		base.position = float6;
		if (_scaleTween != null)
		{
			TweenExtensions.Kill(_scaleTween);
		}
		bool flag2 = (object)_weapon == null;
		float num = _weapon.PArea();
		TweenerCore<Vector3, Vector3, VectorOptions> scaleTween = ShortcutExtensions.DOScale(_cachedTransform, (float)float6, 0.2f);
		_scaleTween = scaleTween;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool flag3 = _scaleTween == null;
		int num2 = base.depth;
		int num3 = num2 - 1;
		RenderingExtensions.SetDepth(_pfxEmitter, num3);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig
		{
			Rate = 1.5f,
			Volume = (float?)(object)1
		};
		float detune = (float)_indexInWeapon * 100f;
		soundConfig.Detune = detune;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.TP_sfx_Fireball, soundConfig, 200f, 10, time);
	}

	public unsafe void SetAngleVelocity_Deg(float angleDeg)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Expected O, but got Unknown
		//IL_00f9: Expected I, but got O
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Expected O, but got Unknown
		//IL_0213: Unknown result type (might be due to invalid IL or missing references)
		//IL_0218: Expected O, but got Unknown
		//IL_0226: Expected F4, but got O
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Expected O, but got Unknown
		//IL_0061: Expected O, but got F4
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Expected O, but got Unknown
		//IL_01b3: Expected native int or pointer, but got O
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c6: Expected O, but got Unknown
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Expected O, but got Unknown
		object obj2 = default(object);
		object obj = obj2 - 95;
		float num = angleDeg * ((float)Math.PI / 180f);
		float projectileSpeed = base.ProjectileSpeed;
		float speed = default(float);
		Vector2 vector = SetVelocityFromRotation(num, speed);
		BaseBody baseBody = body;
		Transform transform = base.transform;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
		nint num2 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ rax_v21 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rax_v22 (Il2CppStaticFields<UnityEngine.Vector3>)+50]");
		_ = 0;
		_ = Vector3.forwardVector;
		_ = 0;
		object obj3 = obj - 73;
		object obj4 = obj - 89;
		Quaternion.AngleAxis_Injected((float)this, ref *(Vector3*)obj4, out *(Quaternion*)obj3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-49]");
		_ = 0;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		object obj5 = obj - 57;
		Transform.set_rotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Quaternion*)obj5);
		object obj6 = angleDeg ^ -0f;
		Transform transform2 = _pfxEmitter.transform;
		Vector3 localEulerAngles = (Vector3)(obj - 89);
		transform2.localEulerAngles = localEulerAngles;
		_ = _pfxEmitter;
		_ = _pfxEmitter;
		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)(obj - 25);
		float min = num ^ -0f;
		float max = num ^ -0f;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(min, max));
		ParticleSystem.MinMaxCurve startRotation = (ParticleSystem.MinMaxCurve)(obj - 57);
		ParticleSystem.MainModule mainModule = (ParticleSystem.MainModule)(obj + 127);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-19]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-9]");
		_ = 0;
		((ParticleSystem.MainModule*)mainModule)->startRotation = startRotation;
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		//IL_003d: Expected I, but got O
		//IL_0045: Expected I, but got O
		//IL_0055: Expected O, but got I
		//IL_00d5: Expected O, but got I4
		//IL_0091: Expected O, but got I
		//IL_00c7: Expected O, but got I4
		//IL_0501: Expected I, but got O
		//IL_011b: Expected I, but got O
		//IL_014e: Expected I, but got O
		//IL_0166: Expected I, but got O
		//IL_01a0: Expected I, but got O
		//IL_01a8: Expected O, but got I
		//IL_01b8: Expected O, but got I
		//IL_0238: Expected O, but got I4
		//IL_01f4: Expected O, but got I
		//IL_0245: Expected O, but got I
		//IL_022a: Expected O, but got I4
		//IL_02a8: Expected O, but got I
		//IL_02de: Expected I, but got O
		//IL_02ec: Expected I, but got O
		//IL_02fc: Expected O, but got I
		//IL_037c: Expected O, but got I4
		//IL_0338: Expected O, but got I
		//IL_05b8: Expected I, but got O
		//IL_036e: Expected O, but got I4
		//IL_03ca: Expected I, but got O
		//IL_0450: Expected I, but got O
		//IL_03e5: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj != null)
		{
			return;
		}
		nint num = (nint)typeof(EnemyController);
		nint num2 = (nint)other;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rdx_v4 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ r8_v4 (Il2CppClass<VampireSurvivors.Interfaces.IDamageable>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rdx_v4 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
		object obj4;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ r8_v4 (Il2CppClass<VampireSurvivors.Interfaces.IDamageable>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rax_v73+FFFFFFF8+v156 @ rax_v6*8]");
			if (0 == (nint)typeof(EnemyController))
			{
				obj4 = 1;
				goto IL_04bd;
			}
		}
		obj4 = 0;
		goto IL_04bd;
		IL_05a1:
		IDamageable damageable;
		bool flag = damageable == null;
		float2 float5;
		nint num4 = (nint)float5;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v394 @ rbx_v7 (VampireSurvivors.Interfaces.IDamageable)+10]");
			bool flag2 = (nint)0 == 0;
			num4 = (nint)float5;
			if (!flag2)
			{
				num4 = (nint)float5;
			}
		}
		if (!_isDespawning)
		{
			_isDespawning = true;
			if (_scaleTween != null)
			{
				TweenExtensions.Kill(_scaleTween);
			}
			nint num5 = (nint)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v919 @ rax_v34 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_VampireKiller_Fire_Projectile>)+370]");
			num4 = 0;
			Despawn();
		}
		goto IL_050f;
		IL_056c:
		object obj5;
		bool flag3 = obj5 == null;
		damageable = null;
		float5 = (float2)typeof(TP_VampireKiller_Explosion_Projectile);
		Projectile projectile;
		if (!flag3)
		{
			damageable = projectile;
			float5 = (float2)typeof(TP_VampireKiller_Explosion_Projectile);
		}
		goto IL_05a1;
		IL_054a:
		Weapon weapon;
		if ((object)weapon == null || ((UnityEngine.Object)weapon).m_CachedPtr == (IntPtr)0)
		{
			goto IL_050f;
		}
		float2 float6 = base.position;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rsi_v6 (VampireSurvivors.Objects.Weapons.Weapon)+170]");
		float2 float7 = default(float2);
		projectile = ((BulletPool)0).SpawnAt(float7, weapon);
		bool flag4 = (object)projectile == null;
		damageable = null;
		float5 = float7;
		if (!flag4)
		{
			nint num6 = (nint)projectile;
			nint num7 = (nint)typeof(TP_VampireKiller_Explosion_Projectile);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v700 @ rdx_v16 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_VampireKiller_Explosion_Projectile>)+130]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v699 @ r8_v17 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
			nint num8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v700 @ rdx_v16 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_VampireKiller_Explosion_Projectile>)+130]");
			if (num8 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v699 @ r8_v17 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
				object obj7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v756 @ rax_v51+FFFFFFF8+v701 @ rax_v47*8]");
				if (0 == (nint)typeof(TP_VampireKiller_Explosion_Projectile))
				{
					obj5 = 1;
					goto IL_056c;
				}
			}
			obj5 = 0;
			goto IL_056c;
		}
		goto IL_05a1;
		IL_0523:
		object obj8;
		bool flag5 = obj8 == null;
		weapon = null;
		if (!flag5)
		{
			weapon = (Weapon)num4;
		}
		goto IL_054a;
		IL_04bd:
		bool flag6 = obj4 == null;
		IDamageable damageable2 = null;
		if (!flag6)
		{
			damageable2 = other;
		}
		bool flag7 = damageable2 == null;
		num4 = (nint)typeof(EnemyController);
		if (!flag7)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rbp_v5 (VampireSurvivors.Interfaces.IDamageable)+10]");
			bool flag8 = (nint)0 == 0;
			num4 = (nint)typeof(EnemyController);
			if (!flag8)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rbp_v5 (VampireSurvivors.Interfaces.IDamageable)+1F9]");
				bool flag9 = (nint)0 == 0;
				num4 = (nint)typeof(EnemyController);
				if (!flag9)
				{
					num4 = (nint)_weapon;
					if ((object)_weapon == null)
					{
						weapon = null;
						goto IL_054a;
					}
					nint num9 = (nint)typeof(TP_SpriteWhip_Weapon);
					object obj9 = num4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v508 @ r8_v18 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_SpriteWhip_Weapon>)+130]");
					object obj10 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v509 @ r9_v10+130]");
					nint num10 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v508 @ r8_v18 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_SpriteWhip_Weapon>)+130]");
					if (num10 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v509 @ r9_v10+C8]");
						object obj11 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v564 @ rax_v64+FFFFFFF8+v510 @ rax_v60*8]");
						if (0 == (nint)typeof(TP_SpriteWhip_Weapon))
						{
							obj8 = 1;
							goto IL_0523;
						}
					}
					obj8 = 0;
					goto IL_0523;
				}
			}
		}
		goto IL_050f;
		IL_050f:
		Weapon weapon2 = _weapon;
		if (weapon2._explodeOnExpire)
		{
			float2 pos = base.position;
			Projectile projectile2 = weapon2.SpawnExplosionAt(pos, 1, 0, 0f);
		}
	}

	public void StartDespawn()
	{
		if (!_isDespawning)
		{
			_isDespawning = true;
			if (_scaleTween != null)
			{
				TweenExtensions.Kill(_scaleTween);
			}
			Despawn();
		}
	}

	private unsafe void GenerateParticleSystem()
	{
		//IL_0008: Expected O, but got Ref
		//IL_04f3: Expected O, but got Ref
		//IL_051a: Expected O, but got I
		//IL_052f: Expected native int or pointer, but got O
		//IL_0549: Expected O, but got I
		//IL_0569: Expected O, but got Ref
		//IL_0583: Expected native int or pointer, but got O
		//IL_0687: Expected O, but got I
		//IL_05bb: Expected O, but got Ref
		//IL_05d5: Expected native int or pointer, but got O
		//IL_06c1: Expected O, but got I
		//IL_0626: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("ThosePeople");
		List<string> list = new List<string>();
		list._002Ector();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fireball01");
		}
		else
		{
			int num = list._size + 1;
			list._size = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version2 = list._version + 1;
		list._version = version2;
		string[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fireball02");
		}
		else
		{
			int num2 = list._size + 1;
			list._size = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version3 = list._version + 1;
		list._version = version3;
		string[] items3 = list._items;
		if (list._size >= items3.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fireball03");
		}
		else
		{
			int num3 = list._size + 1;
			list._size = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version4 = list._version + 1;
		list._version = version4;
		string[] items4 = list._items;
		if (list._size >= items4.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fireball04");
		}
		else
		{
			int num4 = list._size + 1;
			list._size = num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version5 = list._version + 1;
		list._version = version5;
		string[] items5 = list._items;
		if (list._size >= items5.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fireball05");
		}
		else
		{
			int num5 = list._size + 1;
			list._size = num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version6 = list._version + 1;
		list._version = version6;
		string[] items6 = list._items;
		if (list._size >= items6.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fireball06");
		}
		else
		{
			int num6 = list._size + 1;
			list._size = num6;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version7 = list._version + 1;
		list._version = version7;
		string[] items7 = list._items;
		if (list._size >= items7.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fireball07");
		}
		else
		{
			int num7 = list._size + 1;
			list._size = num7;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version8 = list._version + 1;
		list._version = version8;
		string[] items8 = list._items;
		if (list._size >= items8.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"TP_VFX_Fireball08");
		}
		else
		{
			int num8 = list._size + 1;
			list._size = num8;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+77]");
		particleSystemConfig._quantity = (int?)(object)0;
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(100f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-19]");
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-9]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0.65f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+7]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+17]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-69]");
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-59]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-49]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 39));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(1f, 1f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+27]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+37]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-41]");
		particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-31]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-21]");
		_ = 0;
		particleSystemConfig._on = true;
		particleSystemConfig._tintRandom = _tints;
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+77]");
		particleSystemConfig._blendMode = (BlendMode?)(object)0;
		ParticleSystem pfxEmitter = ParticleSystemGenerator.GenerateParticleSystem(particleSystemConfig, _cachedTransform);
		_pfxEmitter = pfxEmitter;
	}

	public override void Despawn()
	{
		if (_scaleTween != null)
		{
			TweenExtensions.Kill(_scaleTween);
		}
		base.Despawn();
	}
}
