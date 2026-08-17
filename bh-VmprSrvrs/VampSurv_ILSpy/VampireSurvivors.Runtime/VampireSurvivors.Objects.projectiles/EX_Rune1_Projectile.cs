using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles;

public class EX_Rune1_Projectile : Projectile
{
	private float _IndexOffsetScaleFactor = 0.1f;

	private ParticleEmitterManager _pfxManager;

	private ParticleSystem _pfx;

	private EX_Rune1_Weapon trueWeapon;

	private EnemyController targetEnemy;

	protected Vector3 start;

	protected Vector3 end;

	protected float midYOffset = 0.64f;

	protected float t;

	protected float speed = 3f;

	protected SpriteAnimation _spriteAnimation;

	public virtual List<string> ParticleFrames
	{
		get
		{
			List<string> list = new List<string>();
			if (list != null)
			{
				int version = list._version + 1;
				list._version = version;
				string[] items = list._items;
				if (list._items != null)
				{
					if (list._size >= items.Length)
					{
						((List<object>)(object)list).AddWithResize((object)"PfxRed.png");
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
					if (list._items != null)
					{
						if (list._size >= items2.Length)
						{
							((List<object>)(object)list).AddWithResize((object)"PfxGray.png");
							return list;
						}
						int num2 = list._size + 1;
						list._size = num2;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						return list;
					}
				}
			}
			return (List<string>)(object)new NullReferenceException();
		}
	}

	public virtual void MakeSpriteAnimation()
	{
		//IL_010f: Expected O, but got I4
		//IL_010f: Expected I4, but got O
		Vector2 pivot = default(Vector2);
		string text = default(string);
		int num = default(int);
		bool flag = default(bool);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("_runes_0", 2, 6, pivot, text, num, flag);
		GameObject gameObject = _renderer.gameObject;
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rdi_v3 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
		}
		SpriteAnimation spriteAnimation = ((!gameObject.TryGetComponent<SpriteAnimation>(out var component)) ? gameObject.AddComponent<SpriteAnimation>() : component);
		_spriteAnimation = spriteAnimation;
		_spriteAnimation.CleanAnimations();
		bool autoSetAnimation = default(bool);
		_spriteAnimation.AddAnimation("Idle", animationFrames, 8, (byte)(int)text != 0, (byte)num != 0, (Action)flag, autoSetAnimation);
	}

	public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
	{
		//IL_004e: Expected O, but got I4
		//IL_004e: Expected O, but got I4
		//IL_0062: Expected O, but got I4
		//IL_0091: Expected I, but got O
		//IL_0099: Expected I, but got O
		//IL_00a9: Expected O, but got I
		//IL_0129: Expected O, but got I4
		//IL_00e5: Expected O, but got I
		//IL_011b: Expected O, but got I4
		base.InitProjectile(pool, weapon, index);
		float num = weapon.PArea();
		ArcadeSprite sprite = _sprite;
		object obj = default(object);
		float radius = (float)obj * 8f;
		BaseBody baseBody = sprite.body.setCircle(radius, (float?)(object)1, (float?)(object)1);
		ArcadeSprite arcadeSprite = setScale(0f, (float?)(object)0);
		BaseBody baseBody2 = body;
		baseBody2._enable = false;
		nint num2 = (nint)typeof(EX_Rune1_Weapon);
		nint num3 = (nint)weapon;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rdx_v6 (Il2CppClass<VampireSurvivors.Objects.Weapons.EX_Rune1_Weapon>)+130]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rdx_v6 (Il2CppClass<VampireSurvivors.Objects.Weapons.EX_Rune1_Weapon>)+130]");
		object obj4;
		if (num4 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ rax_v20+FFFFFFF8+v204 @ rax_v11*8]");
			if (0 == (nint)typeof(EX_Rune1_Weapon))
			{
				obj4 = 1;
				goto IL_015e;
			}
		}
		obj4 = 0;
		goto IL_015e;
		IL_015e:
		bool flag = obj4 == null;
		Weapon weapon2 = null;
		if (!flag)
		{
			weapon2 = weapon;
		}
		trueWeapon = (EX_Rune1_Weapon)weapon2;
		_isCullable = false;
	}

	public void SetEnemyTarget(EnemyController enemy, bool flipMyY = false)
	{
		//IL_0256: Expected O, but got F4
		//IL_01be: Expected O, but got F4
		targetEnemy = enemy;
		EnemyController enemyController = targetEnemy;
		if ((object)targetEnemy == null || ((UnityEngine.Object)enemyController).m_CachedPtr == (IntPtr)0)
		{
			base.Despawn();
		}
		SpriteAnimation spriteAnimation = _spriteAnimation;
		if ((object)_spriteAnimation == null || ((UnityEngine.Object)spriteAnimation).m_CachedPtr == (IntPtr)0)
		{
			MakeSpriteAnimation();
		}
		GenerateParticleSystem();
		Transform cachedTransform = _cachedTransform;
		bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
		Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
		object obj = UnityEngine.Random.value;
		object obj2 = UnityEngine.Random.value;
		Transform cachedTransform2 = _cachedTransform;
		bool flag2 = (object)_cachedTransform == null;
		bool flag3 = ((UnityEngine.Object)cachedTransform2).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_position_Injected(((UnityEngine.Object)cachedTransform2).m_CachedPtr, ref value);
		Vector3 vector = default(Vector3);
		start = vector;
		_ = 0;
		bool flag4 = (object)targetEnemy == null;
		float2 float5 = targetEnemy.position;
		end = vector;
		_ = 0;
		t = 0f;
		bool flag5 = default(bool);
		float num = ((!flag5) ? 0.64f : (-0.64f));
		midYOffset = num;
	}

	private unsafe void GenerateParticleSystem()
	{
		//IL_0008: Expected O, but got Ref
		//IL_00af: Expected O, but got Ref
		//IL_00c9: Expected native int or pointer, but got O
		//IL_0253: Expected O, but got I4
		//IL_00e1: Expected O, but got Ref
		//IL_0108: Expected O, but got I
		//IL_011d: Expected native int or pointer, but got O
		//IL_0137: Expected O, but got I
		//IL_0157: Expected O, but got Ref
		//IL_0171: Expected native int or pointer, but got O
		//IL_0270: Expected O, but got I4
		//IL_0189: Expected O, but got Ref
		//IL_01a3: Expected native int or pointer, but got O
		//IL_029a: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ParticleSystem pfx = _pfx;
		if ((object)_pfx == null || ((UnityEngine.Object)pfx).m_CachedPtr == (IntPtr)0)
		{
			GameObject gameObject = base.gameObject;
			ParticleEmitterManager pfxManager = gameObject.AddComponent<ParticleEmitterManager>();
			_pfxManager = pfxManager;
			ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
			List<string> particleFrames = ParticleFrames;
			particleSystemConfig._frame = particleFrames;
			ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 88));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(15.000001f, 30.000002f));
			particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
			ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 56));
			_ = 0;
			_ = 1;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+50]");
			particleSystemConfig._quantity = (int?)(object)0;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(300f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-38]");
			particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-28]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 24));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(1f, 0f));
			particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)1;
			ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 8));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(1f, 1f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+18]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-80]");
			particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-70]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-60]");
			_ = 0;
			particleSystemConfig._on = false;
			Transform parent = base.transform;
			ParticleSystem pfx2 = _pfxManager.CreateEmitter(particleSystemConfig, parent);
			_pfx = pfx2;
		}
	}

	protected override void OnHasHitAnObject(IDamageable other)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null && --_penetrating <= 0)
		{
			base.Despawn();
		}
	}

	public unsafe override void InternalUpdate()
	{
		//IL_0008: Expected O, but got Ref
		//IL_030b: Expected O, but got I
		//IL_0053: Expected O, but got F4
		//IL_03ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b1: Expected O, but got Unknown
		//IL_03e5: Expected O, but got I
		//IL_08af: Expected O, but got F4
		//IL_08ea: Invalid comparison between I4 and F4
		//IL_0142: Expected F4, but got I4
		//IL_05d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05de: Expected O, but got Unknown
		//IL_061d: Expected O, but got I4
		//IL_065f: Expected O, but got Ref
		//IL_080e: Expected F4, but got O
		//IL_01b0: Expected O, but got Ref
		//IL_024d: Expected O, but got F4
		//IL_0916->IL02b3: Incompatible stack heights: 1 vs 0
		//IL_022a->IL02b3: Incompatible stack heights: 1 vs 0
		//IL_0882->IL02b3: Incompatible stack heights: 2 vs 0
		//IL_08a1->IL0837: Incompatible stack heights: 2 vs 1
		//IL_0290->IL02b3: Incompatible stack heights: 2 vs 0
		//IL_02b3->IL0837: Incompatible stack heights: 2 vs 1
		object obj2 = default(object);
		object obj = (object)(&obj2);
		ArcadeSprite arcadeSprite = targetEnemy;
		speed = 2f;
		if ((object)targetEnemy != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rax_v2 (ArcadeSprite)+260]");
			float num = default(float);
			if ((nint)0 == 0)
			{
				float2 float5 = targetEnemy.position;
				end = (Vector3)num;
				_ = 0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.EX_Rune1_Projectile)+10C]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.EX_Rune1_Projectile)+100]");
			object obj3 = num2 + 0;
			_ = end;
			object obj4 = end + start;
			float num3 = num + num;
			float num4 = (float)obj4 * 0.5f;
			float num5 = num3 * 0.5f;
			float num6 = (float)obj3 * 0.5f;
			Weapon weapon = _weapon;
			if ((object)_weapon != null && (object)((Equipment)weapon)._003COwner_003Ek__BackingField != null)
			{
				float2 float6 = ((Equipment)weapon)._003COwner_003Ek__BackingField.position;
				float num7 = num4 + num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1+6B]");
				float num8 = 0f + midYOffset;
				float num9 = num5 + midYOffset;
				float num10 = num6 + num6;
				if (num8 < num9)
				{
					num8 = num9;
				}
				float num11 = num8 + num8;
				Vector3 vector = start;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-79]");
				object obj5 = vector + 0;
				float num13 = default(float);
				float num12 = num13;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-75]");
				float num14 = num12 + 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.EX_Rune1_Projectile)+100]");
				nint num15 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.EX_Rune1_Projectile)+10C]");
				object obj6 = num15 + 0;
				float num16 = (float)obj5 * 0.5f;
				float num17 = num14 * 0.5f;
				float num18 = (float)obj6 * 0.5f;
				float num19 = num7 - num16;
				float num20 = num11 - num17;
				float num21 = num10 - num18;
				object obj7 = Time.deltaTime;
				float num22 = num18 * speed;
				float num23 = num22 * 0.6f;
				float num24 = num23 + t;
				if (!(0f > num24))
				{
					if (num24 > 1f)
					{
						num24 = 1f;
					}
				}
				else
				{
					num24 = 0f;
				}
				float num25 = 1f - num24;
				t = num24;
				float num26 = num25 * num25;
				float num27 = num26 * (float)start;
				float num28 = num26 * num13;
				float num29 = num26;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.EX_Rune1_Projectile)+100]");
				float num30 = num29 * 0f;
				float num31 = num25 + num25;
				float num32 = num31 * num24;
				float num33 = num32 * num19;
				float num34 = num32 * num20;
				float num35 = num32 * num21;
				float num36 = num33 + num27;
				float num37 = num34 + num28;
				float num38 = num35 + num30;
				float num39 = num24 * num24;
				float num40 = num39;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-79]");
				float num41 = num40 * 0f;
				float num42 = num39;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-75]");
				float num43 = num42 * 0f;
				float num44 = num39;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.EX_Rune1_Projectile)+10C]");
				float num45 = num44 * 0f;
				float num46 = num41 + num36;
				float num47 = num43 + num37;
				float num48 = num45 + num38;
				float num49 = num24 + num24;
				float num50 = num49 - 1f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
				object obj8 = num50 & 0;
				float num51 = 1f - (float)obj8;
				float num52 = num51 * 0.75f;
				float xScale = num52 + 0.25f;
				ArcadeSprite arcadeSprite2 = setScale(xScale, (float?)(object)0);
				Transform transform = base.transform;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v646 @ rax_v26 (UnityEngine.Transform)+10]");
				bool flag = (nint)0 == 0;
				Vector3 vector2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 121));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v646 @ rax_v26 (UnityEngine.Transform)+10]");
				Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)vector2);
				float num53 = num19 - (float)start;
				float num54 = num20 - num13;
				float num55 = num21;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.EX_Rune1_Projectile)+100]");
				float num56 = num55 - 0f;
				float num57 = num25 + num25;
				float num58 = num57 * num53;
				float num59 = num57 * num54;
				float num60 = num57 * num56;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-79]");
				float num61 = 0f - num19;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-75]");
				float num62 = 0f - num20;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Projectiles.EX_Rune1_Projectile)+10C]");
				float num63 = 0f - num21;
				float num64 = t + t;
				float num65 = num64 * num61;
				float num66 = num64 * num62;
				float num67 = num64 * num63;
				float num68 = num65 + num58;
				float num69 = num66 + num59;
				float num70 = num67 + num60;
				float num71 = num69 * num69;
				float num72 = num68 * num68;
				float num73 = num70 * num70;
				float num74 = num71 + num72;
				float num75 = num74 + num73;
				if (num75 > 1E-08f)
				{
					Transform transform2 = base.transform;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182C6C6E0");
					float num76 = ((!(num > 1E-05f)) ? ((float)Vector3.zeroVector) : num);
					if ((object)transform2 == null)
					{
						goto IL_02b3;
					}
					transform2.right = (Vector3)(&num76);
					num72 = num;
					num73 = num13;
				}
				ParticleSystem pfx = _pfx;
				if ((object)_pfx == null || ((UnityEngine.Object)pfx).m_CachedPtr == (IntPtr)0)
				{
					return;
				}
				Transform cachedTransform = _cachedTransform;
				if ((object)_cachedTransform != null)
				{
					bool flag2 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
					if ((object)_pfxManager != null)
					{
						_pfxManager.EmitParticleAt((Vector2)num);
						if (!(t < 0.75f))
						{
							BaseBody baseBody = body;
							if (body == null)
							{
								goto IL_02b3;
							}
							baseBody._enable = true;
						}
						if (!(t < 1f))
						{
							base.Despawn();
						}
						return;
					}
				}
			}
		}
		goto IL_02b3;
		IL_02b3:
		throw new NullReferenceException();
	}

	private float TriMap(float x)
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected O, but got Unknown
		float num = x + x;
		float num2 = num - 1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj = num2 & 0;
		return 1f - (float)obj;
	}
}
