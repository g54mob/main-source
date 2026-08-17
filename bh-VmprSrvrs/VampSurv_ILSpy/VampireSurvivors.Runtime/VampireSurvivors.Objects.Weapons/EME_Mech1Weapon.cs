using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class EME_Mech1Weapon : EME_Weapon, EME_iCosmicRaveVFX
{
	private sealed class _003C_003Ec__DisplayClass27_0
	{
		public EME_Mech1Weapon _003C_003E4__this;

		public Vector2 pos;

		public Transform target;

		public BulletPool pool;
	}

	private sealed class _003C_003Ec__DisplayClass27_1
	{
		public int localIndex;

		public _003C_003Ec__DisplayClass27_0 CS_0024_003C_003E8__locals1;

		internal void _003CFire_FireGlimmerProjectile_003Eb__0()
		{
			_003C_003Ec__DisplayClass27_0 obj = CS_0024_003C_003E8__locals1;
			Vector2 pos = default(Vector2);
			Projectile projectile = obj._003C_003E4__this.FireOneProjectile(pos, localIndex, obj.target);
		}
	}

	private sealed class _003C_003Ec__DisplayClass27_2
	{
		public int localIndex;

		public _003C_003Ec__DisplayClass27_0 CS_0024_003C_003E8__locals2;

		internal void _003CFire_FireGlimmerProjectile_003Eb__1()
		{
			_003C_003Ec__DisplayClass27_0 obj = CS_0024_003C_003E8__locals2;
			Vector2 pos = obj._003C_003E4__this.RandomPosOnScreenEdge();
			obj.pos = pos;
			_003C_003Ec__DisplayClass27_0 obj2 = CS_0024_003C_003E8__locals2;
			Vector2 pos2 = default(Vector2);
			Projectile projectile = obj2._003C_003E4__this.FireOneProjectile(pos2, localIndex, obj2.target);
		}
	}

	private Projectile _BasicExplosionPrefab;

	private Projectile _HailstormExplosionPrefab;

	private BulletPool _cosmicRaveVFXpool;

	private Projectile _CosmicRaveVFXPrefab;

	public bool UprightCosmicWaveSilhouette;

	private Timer _glimmerShotTimer;

	protected BulletPool _basicExplosionPool;

	protected BulletPool _hailstormExplosionPool;

	protected override int _comboIndex1 => 3;

	protected override int _comboIndex2 => 6;

	protected override int _comboIndex3 => 9;

	protected override int ComboIndexFinal
	{
		get
		{
			//IL_0005: Expected I, but got O
			//IL_0015: Expected O, but got I
			//IL_0025: Expected O, but got I
			nint num = (nint)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ rdx_v1 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Mech1Weapon>)+5F8]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ rdx_v1 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Mech1Weapon>)+600]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v2 @ rax_v1 (should have been resolved before IL gen)");
			/*Error: End of method reached without returning.*/;
		}
	}

	public BulletPool BasicExplosionPool => _basicExplosionPool;

	public BulletPool HailstormExplosionPool => _hailstormExplosionPool;

	protected override WeaponType GetWeaponTypeForGlimmerLevel(int level)
	{
		//IL_000e: Expected O, but got I4
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		object obj = level - 1;
		object obj2 = default(object);
		if (obj2 == null)
		{
			object obj3 = obj - 1;
			if (obj2 == null)
			{
				if ((nint)obj3 != 1)
				{
					return WeaponType.VOID;
				}
				return WeaponType.EME_MECH_TECH_03;
			}
			return WeaponType.EME_MECH_TECH_02;
		}
		return WeaponType.EME_MECH_TECH_01;
	}

	protected override FiringAnimation GetFiringAnimation()
	{
		return FiringAnimation.Ranged;
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		((Weapon)this)._003CFreezeChance_003Ek__BackingField = 0.25f;
		_explosionType = WeaponType.FIREEXPLOSION;
	}

	protected override void OnStart()
	{
		//IL_008c: Expected I, but got O
		//IL_012f: Expected I, but got O
		//IL_02a8: Expected I, but got O
		((Weapon)this).OnStart();
		base.InitGlimmer1BulletPool();
		base.InitGlimmer2BulletPool();
		base.InitGlimmer3BulletPool();
		if (_basicExplosionPool != null)
		{
			goto IL_0167;
		}
		BulletPool basicExplosionPool = new BulletPool(_BasicExplosionPrefab, 20);
		_basicExplosionPool = basicExplosionPool;
		ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			ArcadePhysics physics = s_scene.physics;
			GameManager core = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v801 @ r8_v19 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Mech1Weapon>)+350]");
			ArcadePhysicsCallback collideCallback = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num = (nint)this;
			Collider collider = physics.add.overlap(_basicExplosionPool, core.Enemies, collideCallback, processCallback, callbackContext);
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				ArcadePhysics physics2 = s_scene2.physics;
				GameManager core2 = GM.Core;
				PhysicsManager physicsManager = core2._physicsManager;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v846 @ r8_v22 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Mech1Weapon>)+3A0]");
				ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
				nint num2 = (nint)this;
				Collider collider2 = physics2.add.overlap(_basicExplosionPool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
				goto IL_0167;
			}
		}
		goto IL_032c;
		IL_0167:
		if (_hailstormExplosionPool != null)
		{
			goto IL_02e0;
		}
		BulletPool hailstormExplosionPool = new BulletPool(_HailstormExplosionPrefab, 20);
		_hailstormExplosionPool = hailstormExplosionPool;
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene3 = ArcadePhysics.s_scene;
			ArcadePhysics physics3 = s_scene3.physics;
			GameManager core3 = GM.Core;
			ArcadePhysicsCallback collideCallback3 = OnBulletOverlapsEnemy_Freeze;
			Collider collider3 = physics3.add.overlap(_hailstormExplosionPool, core3.Enemies, collideCallback3, processCallback, callbackContext);
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene4 = ArcadePhysics.s_scene;
				ArcadePhysics physics4 = s_scene4.physics;
				GameManager core4 = GM.Core;
				PhysicsManager physicsManager2 = core4._physicsManager;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v849 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Mech1Weapon>)+3A0]");
				ArcadePhysicsCallback collideCallback4 = new ArcadePhysicsCallback(this, (IntPtr)0);
				nint num3 = (nint)this;
				Collider collider4 = physics4.add.overlap(_hailstormExplosionPool, physicsManager2._destructiblesGroup, collideCallback4, processCallback, callbackContext);
				goto IL_02e0;
			}
		}
		goto IL_032c;
		IL_032c:
		throw new NullReferenceException();
		IL_02e0:
		if (_cosmicRaveVFXpool == null)
		{
			BulletPool cosmicRaveVFXpool = new BulletPool(_CosmicRaveVFXPrefab, 20);
			_cosmicRaveVFXpool = cosmicRaveVFXpool;
		}
	}

	public void DisplayCosmicRaveVFX(float2 position)
	{
		Projectile projectile = _cosmicRaveVFXpool.SpawnAt(position, this);
	}

	protected bool OnBulletOverlapsEnemy_Freeze(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_0136: Expected I4, but got O
		if (first != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				EnemyController component = gameObject.GetComponent<EnemyController>();
				if ((object)component != null)
				{
					if (component._003CIsDead_003Ek__BackingField)
					{
						goto IL_0153;
					}
					if (second != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						GameObject gameObject2 = default(GameObject);
						if ((object)gameObject2 != null)
						{
							Projectile component2 = gameObject2.GetComponent<Projectile>();
							if ((object)component2 != null)
							{
								if (!component2.HasAlreadyHitObject(component))
								{
									bool flag = component2.TryFreeze(component);
									base.DealDamage(component);
								}
								goto IL_0153;
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0153:
		return false;
	}

	protected override void Fire_DoAttacks(BulletPool glimmerPool, bool skipTriggers = false)
	{
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Expected O, but got Unknown
		//IL_0114: Invalid comparison between O and F4
		//IL_00bf: Expected F4, but got O
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Vector2 vector = default(Vector2);
		base.Fire_FireBasicProjectile(vector, 0, _targetTransform);
		bool flag = glimmerPool == null;
		Vector2 vector2 = vector;
		if (!flag)
		{
			bool flag2 = _ShouldGlimmerNextFire;
			vector2 = vector;
			if (!flag2)
			{
				float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
				Fire_FireGlimmerProjectile(vector, 0, _targetTransform);
				vector2 = vector;
			}
		}
		float num = base.PInterval();
		float num2 = _lastFiringInterval - (float)vector2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj = num2 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num3 = base.PInterval();
			_lastFiringInterval = (float)vector2;
			base.ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	protected unsafe override void Fire_FireGlimmerProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
	{
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Expected O, but got Unknown
		//IL_021f: Invalid comparison between F4 and I4
		//IL_03c6: Invalid comparison between F4 and I4
		//IL_00b5: Expected F4, but got I4
		//IL_00f5: Expected I, but got O
		//IL_010e: Expected O, but got F4
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Expected O, but got Unknown
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Expected O, but got Unknown
		//IL_0199: Expected O, but got I4
		//IL_02ac: Expected I, but got O
		//IL_02c2: Expected O, but got I
		//IL_02cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d0: Expected O, but got Unknown
		//IL_05ba: Expected O, but got I4
		//IL_0174: Expected O, but got I4
		//IL_0339: Expected I, but got O
		//IL_0461: Expected I, but got O
		//IL_0477: Expected O, but got I
		//IL_0480: Unknown result type (might be due to invalid IL or missing references)
		//IL_0485: Expected O, but got Unknown
		//IL_05da: Expected O, but got I4
		//IL_05f1: Expected I, but got I8
		//IL_063e: Expected I4, but got F4
		//IL_063e: Expected O, but got F4
		//IL_063e: Expected I4, but got O
		//IL_04ee: Expected I, but got O
		//IL_0361: Invalid comparison between F4 and I4
		//IL_036f: Expected O, but got I4
		//IL_0668: Expected O, but got I4
		//IL_068f: Expected I, but got I8
		//IL_06bc: Expected I4, but got F4
		//IL_06bc: Expected O, but got F4
		//IL_06bc: Expected I4, but got O
		//IL_0322: Expected I, but got I8
		//IL_0704: Invalid comparison between F4 and I4
		//IL_04d7: Expected I, but got I8
		_003C_003Ec__DisplayClass27_0 obj = new _003C_003Ec__DisplayClass27_0();
		obj._003C_003E4__this = this;
		Vector2 vector = default(Vector2);
		obj.pos = vector;
		obj.target = target;
		BulletPool pool2 = default(BulletPool);
		obj.pool = pool2;
		bool flag = obj.pool != _glimmer1Pool;
		Vector2 vector2 = vector;
		float? num3 = default(float?);
		float num4 = default(float);
		float num5 = default(float);
		bool flag2 = default(bool);
		object obj5 = default(object);
		if (!flag)
		{
			float num = base.PSpeed();
			float num2 = (float)vector + (float)vector;
			if (!(num2 > 1f))
			{
				num2 = 1f;
			}
			PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.Sfx_eme_ballisticmissile, 500f, 1, 0f, num3, num4, num5, flag2, 1f);
			float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			float num6 = 1.06199776E+09f + 0.32f;
			obj.pos = position;
			nint num7 = (nint)this;
			float num8 = base.PAmount();
			vector2 = (Vector2)(num6 * 0.5f);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
			object obj3 = default(object);
			object obj2 = obj3 * 2;
			object obj4 = obj2 + 6;
			int num9;
			if ((nint)obj4 < 14)
			{
				bool flag3 = (nint)obj4 <= 0;
				obj5 = 1061997773;
				if (flag3)
				{
					goto IL_01a7;
				}
				num9 = 0;
			}
			else
			{
				obj4 = 14;
				num9 = 0;
			}
			Vector2 vector3 = default(Vector2);
			bool flag4;
			do
			{
				Projectile projectile = base.FireOneProjectile(vector3, num9, obj.target);
				num9++;
				flag4 = num9 < (nint)obj4;
				obj5 = 1061997773;
				vector2 = vector3;
			}
			while (flag4);
		}
		goto IL_01a7;
		IL_01a7:
		if (obj.pool == _glimmer2Pool)
		{
			float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
			vector2 = (Vector2)(obj5 + 0.32f);
			obj.pos = position2;
			float num10 = base.PAmount();
			float num11 = (float)vector2 + 8f;
			bool flag5 = !(num11 > 0f);
			bool flag6 = false;
			if (!flag5)
			{
				bool flag7;
				do
				{
					_003C_003Ec__DisplayClass27_1 obj6 = new _003C_003Ec__DisplayClass27_1();
					obj6.CS_0024_003C_003E8__locals1 = obj;
					obj6.localIndex = (flag6 ? 1 : 0);
					Action action = null;
					nint num12 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v689 @ r10_v8 (Il2CppMethodInfo)+8]");
					((Delegate)action).method_ptr = (IntPtr)0;
					((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass27_1._003CFire_FireGlimmerProjectile_003Eb__0);
					((Delegate)action).m_target = obj6;
					((Delegate)action).method_code = (IntPtr)action;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v689 @ r10_v8 (Il2CppMethodInfo)+4C]");
					object obj7 = (nint)0 >> 4;
					object obj8 = obj7 & 1;
					nint num13;
					if (obj8 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v689 @ r10_v8 (Il2CppMethodInfo)+52]");
						if ((nint)0 == 0)
						{
							num13 = unchecked((nint)6447293664L);
							goto IL_05d1;
						}
					}
					((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
					num13 = ((Delegate)action).method_ptr;
					goto IL_05d1;
					IL_05d1:
					object obj9 = 24;
					((Delegate)action).extra_arg = unchecked((nint)6447293568L);
					float num14 = (float)(flag6 ? 1 : 0) * 50f;
					float duration = num14 * 0.001f;
					Timer glimmerShotTimer = Timers.Register(duration, action, null, isLooped: false, (byte)(int)num3 != 0, (MonoBehaviour)num4, (int)num5, flag2 ? TimerType.UI : TimerType.GAME, isOnlineTimer: false, canPause: false);
					_glimmerShotTimer = glimmerShotTimer;
					flag6 = (byte)((flag6 ? 1u : 0u) + 1u) != 0;
					flag7 = num11 > (float)(flag6 ? 1 : 0);
					vector2 = (Vector2)flag6;
				}
				while (flag7);
			}
		}
		if (obj.pool != _glimmer3Pool)
		{
			return;
		}
		float num15 = base.PAmount();
		float num16 = (float)vector2 + 3f;
		if (!(num16 > 0f))
		{
			return;
		}
		bool flag8 = false;
		float num17 = 500f;
		do
		{
			_003C_003Ec__DisplayClass27_2 obj10 = new _003C_003Ec__DisplayClass27_2();
			obj10.CS_0024_003C_003E8__locals2 = obj;
			obj10.localIndex = (flag8 ? 1 : 0);
			Action action2 = null;
			nint num18 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v797 @ r10_v6 (Il2CppMethodInfo)+8]");
			((Delegate)action2).method_ptr = (IntPtr)0;
			((Delegate)action2).method = (nint)__ldftn(_003C_003Ec__DisplayClass27_2._003CFire_FireGlimmerProjectile_003Eb__1);
			((Delegate)action2).m_target = obj10;
			((Delegate)action2).method_code = (IntPtr)action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v797 @ r10_v6 (Il2CppMethodInfo)+4C]");
			object obj11 = (nint)0 >> 4;
			object obj12 = obj11 & 1;
			nint num19;
			if (obj12 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v797 @ r10_v6 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 0)
				{
					num19 = unchecked((nint)6447293664L);
					goto IL_065f;
				}
			}
			((Delegate)action2).method_code = (IntPtr)((Delegate)action2).m_target;
			num19 = ((Delegate)action2).method_ptr;
			goto IL_065f;
			IL_065f:
			object obj13 = 24;
			float duration2 = num17 * 0.001f;
			((Delegate)action2).extra_arg = unchecked((nint)6447293568L);
			Timer glimmerShotTimer2 = Timers.Register(duration2, action2, null, isLooped: false, (byte)(int)num3 != 0, (MonoBehaviour)num4, (int)num5, flag2 ? TimerType.UI : TimerType.GAME, isOnlineTimer: false, canPause: false);
			_glimmerShotTimer = glimmerShotTimer2;
			float num20 = 10f - (float)obj10.localIndex;
			if (!(num20 > 1f))
			{
				num20 = 1f;
			}
			flag8 = (byte)((flag8 ? 1u : 0u) + 1u) != 0;
			float num21 = num20 * 50f;
			num17 += num21;
		}
		while (num16 > (float)(flag8 ? 1 : 0));
	}

	public Vector2 RandomPosOnScreenEdge()
	{
		//IL_0049: Expected O, but got I
		//IL_0168: Expected O, but got F4
		//IL_0057: Invalid comparison between O and F4
		//IL_01b7: Expected O, but got F4
		//IL_01d8: Invalid comparison between O and F4
		//IL_0196: Expected O, but got F4
		//IL_015a->IL00d9: Incompatible stack heights: 1 vs 0
		//IL_0188->IL00d9: Incompatible stack heights: 1 vs 0
		Camera main = Camera.main;
		if ((object)main != null)
		{
			Transform transform = main.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				Transform transform2 = (Transform)(object)((Equipment)this)._003COwner_003Ek__BackingField;
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rbx_v8 (UnityEngine.Transform)+198]");
					Transform transform3 = (Transform)0;
					object obj = UnityEngine.Random.value;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rbx_v8 (UnityEngine.Transform)+198]");
					if ((nint)0 != 0)
					{
						object obj2 = default(object);
						if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.5f))
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rbx_v9 (UnityEngine.Transform)+28]");
							float num = 0f * 0.5f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rbx_v9 (UnityEngine.Transform)+28]");
							float num2 = 0f * 0.5f;
							float maxInclusive = num + (float)ret;
							float minInclusive = (float)ret - num2;
							float num3 = UnityEngine.Random.Range(minInclusive, maxInclusive);
							object obj3 = UnityEngine.Random.value;
							if (num3 > 0.5f)
							{
								goto IL_00d4;
							}
						}
						object obj4 = UnityEngine.Random.value;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rbx_v9 (UnityEngine.Transform)+2C]");
						float num4 = 0f * 0.5f;
						if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.5f))
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rbx_v9 (UnityEngine.Transform)+2C]");
							float num5 = 0f * 0.5f;
							object obj5 = default(object);
							float maxInclusive2 = num4 + (float)obj5;
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm8,eax\"");
							float minInclusive2 = (float)obj5 - num5;
							float num6 = UnityEngine.Random.Range(minInclusive2, maxInclusive2);
						}
						goto IL_00d4;
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_00d4:
		Vector2 result = default(Vector2);
		return result;
	}

	public void FireVolley(Vector2 pos, int _amount, Transform target = null)
	{
		//IL_0025: Expected I, but got O
		//IL_0033: Expected I, but got O
		//IL_0043: Expected O, but got I
		//IL_00c3: Expected O, but got I4
		//IL_007f: Expected O, but got I
		//IL_00b5: Expected O, but got I4
		//IL_0114: Expected O, but got I4
		if (_amount <= 0)
		{
			return;
		}
		int num = 0;
		BulletPool pool = default(BulletPool);
		do
		{
			Projectile projectile = base.FireOneProjectile(pos, num, target, pool);
			Projectile projectile2;
			if ((object)projectile == null)
			{
				projectile2 = null;
				goto IL_0202;
			}
			nint num2 = (nint)projectile;
			nint num3 = (nint)typeof(EME_MechProjectile);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rdx_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_MechProjectile>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ r9_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rdx_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EME_MechProjectile>)+130]");
			object obj3;
			if (num4 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ r9_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rax_v23+FFFFFFF8+v181 @ rax_v19*8]");
				if (0 == (nint)typeof(EME_MechProjectile))
				{
					obj3 = 1;
					goto IL_01db;
				}
			}
			obj3 = 0;
			goto IL_01db;
			IL_01db:
			bool flag = obj3 == null;
			projectile2 = null;
			if (!flag)
			{
				projectile2 = projectile;
			}
			goto IL_0202;
			IL_0202:
			if ((object)projectile2 != null && ((UnityEngine.Object)projectile2).m_CachedPtr != (IntPtr)0)
			{
				object obj4 = num + 1;
				float num5 = (float)obj4 * 0.5f;
				float num6 = num5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rbx_v3 (VampireSurvivors.Objects.Projectiles.Projectile)+E4]");
				float num7 = num6 * 0f;
				float num8 = num5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rbx_v3 (VampireSurvivors.Objects.Projectiles.Projectile)+E0]");
				float num9 = num8 * 0f;
				if ((num & 1) != 0)
				{
					num9 *= -1f;
					num7 *= -1f;
				}
			}
			num++;
		}
		while (num < _amount);
	}

	public override void Cleanup()
	{
		if (_glimmerShotTimer != null)
		{
			_glimmerShotTimer.Cancel();
		}
		((Weapon)this).Cleanup();
		if (base.glimmerUnlockTimer != null)
		{
			base.glimmerUnlockTimer.Cancel();
		}
	}

	public override void CheckArcanas()
	{
		CheckBeginningArcana();
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				((Weapon)this)._003CFreezeChance_003Ek__BackingField = 0.25f;
			}
		}
		GameManager gameMan2 = _gameMan;
		ArcanaManager arcanaManager2 = gameMan2._arcanaManager;
		List<ArcanaType> list2 = arcanaManager2._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rcx_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj2 = default(object);
			if ((nint)obj2 != -1)
			{
				GameManager gameMan3 = _gameMan;
				float heartOfFirePower = base.HeartOfFirePower;
				float newWeaponPower = default(float);
				gameMan3._arcanaManager.AddHeartOfFireWeapon(this, newWeaponPower);
			}
		}
	}
}
