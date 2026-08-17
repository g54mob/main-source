using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class EME_Greatsword1Weapon : EME_Weapon
{
	private sealed class _003C_003Ec__DisplayClass21_0
	{
		public EME_Greatsword1Weapon _003C_003E4__this;

		public Vector2 pos;

		public Transform target;

		public BulletPool pool;
	}

	private sealed class _003C_003Ec__DisplayClass21_1
	{
		public int localIndex;

		public _003C_003Ec__DisplayClass21_0 CS_0024_003C_003E8__locals1;

		internal void _003CFire_FireGlimmerProjectile_003Eb__0()
		{
			_003C_003Ec__DisplayClass21_0 obj = CS_0024_003C_003E8__locals1;
			Vector2 pos = default(Vector2);
			Projectile projectile = obj._003C_003E4__this.FireOneProjectile(pos, localIndex, obj.target);
		}
	}

	private Projectile _AbsetzenBeamPrefab;

	private BulletPool _absetzenBeamPool;

	private Timer _glimmerShotTimer;

	private float _absetzenAmount;

	private const float _abzentzenFireDelay = 250f;

	private readonly List<AbsetzenInstance> _absetzenInstances;

	protected override int EvolutionLevel => 6;

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
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ rdx_v1 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Greatsword1Weapon>)+5F8]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ rdx_v1 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Greatsword1Weapon>)+600]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v2 @ rax_v1 (should have been resolved before IL gen)");
			/*Error: End of method reached without returning.*/;
		}
	}

	public float AbzentzenFireDelay => 250f;

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
				return WeaponType.EME_GREATSWORD_TECH_03;
			}
			return WeaponType.EME_GREATSWORD_TECH_02;
		}
		return WeaponType.EME_GREATSWORD_TECH_01;
	}

	protected override void OnStart()
	{
		//IL_0106: Expected I, but got O
		((Weapon)this).OnStart();
		InitGlimmer1BulletPool();
		base.InitGlimmer2BulletPool();
		base.InitGlimmer3BulletPool();
		if (_absetzenBeamPool == null)
		{
			BulletPool absetzenBeamPool = new BulletPool(_AbsetzenBeamPrefab, 20);
			_absetzenBeamPool = absetzenBeamPool;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			ArcadePhysics physics = s_scene.physics;
			GameManager core = GM.Core;
			ArcadePhysicsCallback collideCallback = OnBulletOverlapsEnemyHighDamage;
			ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
			CallbackContext callbackContext = default(CallbackContext);
			Collider collider = physics.add.overlap(_absetzenBeamPool, core.Enemies, collideCallback, processCallback, callbackContext);
			if ((object)GM.Core == null)
			{
				throw new NullReferenceException();
			}
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			ArcadePhysics physics2 = s_scene2.physics;
			GameManager core2 = GM.Core;
			PhysicsManager physicsManager = core2._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Greatsword1Weapon>)+3A0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num = (nint)this;
			Collider collider2 = physics2.add.overlap(_absetzenBeamPool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
		}
		((Weapon)this)._003CCanCrit_003Ek__BackingField = true;
	}

	protected override void Fire_FireBasicProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
	{
		((Weapon)this)._003CCanCrit_003Ek__BackingField = true;
		BulletPool glimmerBulletPool = base.GetGlimmerBulletPool(_fireCounter, out var _);
		if (glimmerBulletPool != _glimmer1Pool)
		{
			Projectile projectile = base.FireOneProjectile(pos, index, target);
		}
	}

	protected unsafe override void Fire_FireGlimmerProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
	{
		//IL_0061: Expected F4, but got O
		//IL_009b: Expected F4, but got O
		//IL_00a4: Expected O, but got I4
		//IL_026a: Expected I, but got O
		//IL_013c: Expected I, but got O
		//IL_0152: Expected O, but got I
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Expected O, but got Unknown
		//IL_01c9: Expected I, but got O
		//IL_03c5: Expected O, but got I4
		//IL_03dc: Expected I, but got I8
		//IL_042d: Expected O, but got F4
		//IL_042d: Expected I4, but got O
		//IL_01fb: Invalid comparison between F4 and I4
		//IL_020a: Expected O, but got I4
		//IL_01b2: Expected I, but got I8
		_003C_003Ec__DisplayClass21_0 obj = new _003C_003Ec__DisplayClass21_0();
		obj._003C_003E4__this = this;
		obj.pos = pos;
		obj.target = target;
		BulletPool pool2 = default(BulletPool);
		obj.pool = pool2;
		if (obj.pool == null)
		{
			return;
		}
		((Weapon)this)._003CCanCrit_003Ek__BackingField = true;
		bool flag = obj.pool != _glimmer1Pool;
		float num = (float)pos;
		object obj3 = default(object);
		object obj2 = obj3;
		BulletPool bulletPool = default(BulletPool);
		float num6 = default(float);
		if (!flag)
		{
			float num2 = base.PAmount();
			bool flag2 = (nint)pos <= 0;
			num = (float)pos;
			obj2 = 0;
			if (!flag2)
			{
				bool flag3 = false;
				int repeat = default(int);
				TimerType type = default(TimerType);
				bool flag4;
				do
				{
					_003C_003Ec__DisplayClass21_1 obj4 = new _003C_003Ec__DisplayClass21_1();
					obj4.CS_0024_003C_003E8__locals1 = obj;
					obj4.localIndex = (flag3 ? 1 : 0);
					WeaponData currentWeaponData = _currentWeaponData;
					Action action = null;
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v644 @ r10_v6 (Il2CppMethodInfo)+8]");
					((Delegate)action).method_ptr = (IntPtr)0;
					((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass21_1._003CFire_FireGlimmerProjectile_003Eb__0);
					((Delegate)action).m_target = obj4;
					((Delegate)action).method_code = (IntPtr)action;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v644 @ r10_v6 (Il2CppMethodInfo)+4C]");
					object obj5 = (nint)0 >> 4;
					object obj6 = obj5 & 1;
					nint num4;
					if (obj6 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v644 @ r10_v6 (Il2CppMethodInfo)+52]");
						if ((nint)0 == 0)
						{
							num4 = unchecked((nint)6447293664L);
							goto IL_03bc;
						}
					}
					((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
					num4 = ((Delegate)action).method_ptr;
					goto IL_03bc;
					IL_03bc:
					object obj7 = 24;
					((Delegate)action).extra_arg = unchecked((nint)6447293568L);
					float num5 = (float)(flag3 ? 1 : 0) * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
					num = num5 * 0.001f;
					Timer glimmerShotTimer = Timers.Register(num, action, null, isLooped: false, (byte)(int)bulletPool != 0, (MonoBehaviour)num6, repeat, type, isOnlineTimer: false, canPause: false);
					_glimmerShotTimer = glimmerShotTimer;
					flag3 = (byte)((flag3 ? 1u : 0u) + 1u) != 0;
					float num7 = base.PAmount();
					flag4 = num > (float)(flag3 ? 1 : 0);
					obj2 = 0;
				}
				while (flag4);
			}
		}
		float2 pos2 = default(float2);
		if (obj.pool == _glimmer2Pool)
		{
			AbsetzenInstance absetzenInstance = new AbsetzenInstance(this, _targetTransform, obj.pool, bulletPool, num6);
			nint num8 = (nint)this;
			float num9 = base.PAmount();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181B93760");
			int amount = default(int);
			absetzenInstance.FireProjectiles(amount, pos2, obj.target);
			List<object> absetzenInstances = (List<object>)(object)_absetzenInstances;
			int version = absetzenInstances._version + 1;
			absetzenInstances._version = version;
			object[] items = absetzenInstances._items;
			if (absetzenInstances._size >= items.Length)
			{
				absetzenInstances.AddWithResize((object)absetzenInstance);
			}
			else
			{
				int size = absetzenInstances._size + 1;
				absetzenInstances._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
		}
		if (obj.pool == _glimmer3Pool)
		{
			Projectile projectile = base.FireOneProjectile(pos2, index, obj.target);
		}
	}

	public unsafe override void InternalUpdate()
	{
		//IL_0018: Expected O, but got I4
		//IL_0156: Expected O, but got Ref
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Expected O, but got Unknown
		//IL_011f: Expected O, but got I4
		//IL_00c4: Expected O, but got I4
		base.InternalUpdate();
		List<AbsetzenInstance> absetzenInstances = _absetzenInstances;
		bool flag = (nint)_absetzenInstances < 0;
		AbsetzenInstance absetzenInstance = (AbsetzenInstance)(absetzenInstances._size - 1);
		IntPtr intPtr = default(IntPtr);
		nint num = intPtr;
		if (!flag)
		{
			object obj;
			do
			{
				List<AbsetzenInstance> absetzenInstances2 = _absetzenInstances;
				if ((nint)absetzenInstance < absetzenInstances2._size)
				{
					AbsetzenInstance[] items = absetzenInstances2._items;
					AbsetzenInstance absetzenInstance2 = items[(object)absetzenInstance];
					bool flag2 = (absetzenInstance2._beamFired ? 1 : 0) < (false ? 1 : 0);
					if (absetzenInstance2._beamFired)
					{
						AbsetzenInstance absetzenInstance3 = (AbsetzenInstance)_absetzenInstances.Remove(absetzenInstance);
						absetzenInstance3.Cleanup();
						flag2 = (nint)_absetzenInstances < 0;
						bool flag3 = ((List<object>)(object)_absetzenInstances).Remove((object)absetzenInstance3);
						num = 0;
					}
					absetzenInstance = (AbsetzenInstance)(absetzenInstance - 1);
					obj = !flag2;
					continue;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				throw new NullReferenceException();
			}
			while (obj != null);
		}
		List<AbsetzenInstance> absetzenInstances3 = _absetzenInstances;
		int num2 = (int)num;
		List<AbsetzenInstance>.Enumerator enumerator = default(List<AbsetzenInstance>.Enumerator);
		if (enumerator.MoveNext())
		{
			AbsetzenInstance absetzenInstance4 = null;
			List<AbsetzenInstance>.Enumerator enumerator2 = (List<AbsetzenInstance>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
	}

	public override void Cleanup()
	{
		//IL_0048: Expected O, but got I4
		//IL_01f9: Expected O, but got I
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Expected O, but got Unknown
		//IL_010a: Expected O, but got I
		//IL_0146: Expected O, but got I
		if (_glimmerShotTimer != null)
		{
			_glimmerShotTimer.Cancel();
		}
		List<AbsetzenInstance> absetzenInstances = _absetzenInstances;
		bool flag = (nint)_absetzenInstances < 0;
		object obj = absetzenInstances._size - 1;
		if (!flag)
		{
			do
			{
				List<AbsetzenInstance> absetzenInstances2 = _absetzenInstances;
				if ((nint)obj < absetzenInstances2._size)
				{
					AbsetzenInstance[] items = absetzenInstances2._items;
					object item = items[obj];
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rdi_v7 (System.Object)+10]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rcx_v13+1C]");
					_ = (nint)0 + (nint)1;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rcx_v13+18]");
					if ((nint)0 > (nint)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rcx_v13+10]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rcx_v13+18]");
						Array.Clear((Array)num, 0, 0);
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rdi_v7 (System.Object)+38]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rdi_v7 (System.Object)+38]");
						((Timer)0).Cancel();
					}
					bool flag2 = ((List<object>)(object)_absetzenInstances).Remove(item);
					obj--;
					continue;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return;
			}
			while ((nint)_absetzenInstances >= 0);
		}
		((Weapon)this).Cleanup();
		if (base.glimmerUnlockTimer != null)
		{
			base.glimmerUnlockTimer.Cancel();
		}
	}

	protected override void InitGlimmer1BulletPool()
	{
		//IL_0137: Expected I, but got O
		Projectile glimmer1Prefab = _Glimmer1Prefab;
		if ((object)_Glimmer1Prefab != null && ((UnityEngine.Object)glimmer1Prefab).m_CachedPtr != (IntPtr)0)
		{
			BulletPool glimmer1Pool = new BulletPool(_Glimmer1Prefab, 20);
			_glimmer1Pool = glimmer1Pool;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			ArcadePhysics physics = s_scene.physics;
			GameManager core = GM.Core;
			ArcadePhysicsCallback collideCallback = OnBulletOverlapsEnemyHighDamage;
			ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
			CallbackContext callbackContext = default(CallbackContext);
			Collider collider = physics.add.overlap(_glimmer1Pool, core.Enemies, collideCallback, processCallback, callbackContext);
			if ((object)GM.Core == null)
			{
				throw new NullReferenceException();
			}
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			ArcadePhysics physics2 = s_scene2.physics;
			GameManager core2 = GM.Core;
			PhysicsManager physicsManager = core2._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v529 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Greatsword1Weapon>)+3A0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num = (nint)this;
			Collider collider2 = physics2.add.overlap(_glimmer1Pool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
		}
	}

	private bool OnBulletOverlapsEnemyHighDamage(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_015c: Expected I4, but got O
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
						goto IL_0179;
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
									float num = base.PPower();
									float num2 = base.CalcCritMul();
									object obj = default(object);
									float num3 = (float)obj * 4f;
									float damage = (float)obj * num3;
									base.DealDamage(component, damage);
								}
								goto IL_0179;
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0179:
		return false;
	}

	public override void CheckArcanas()
	{
		CheckBeginningArcana();
		GameManager gameMan = _gameMan;
		ArcanaManager arcanaManager = gameMan._arcanaManager;
		List<ArcanaType> list = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rcx_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				((Weapon)this)._003CCanCrit_003Ek__BackingField = true;
			}
		}
	}

	public EME_Greatsword1Weapon()
	{
		List<AbsetzenInstance> absetzenInstances = new List<AbsetzenInstance>();
		_absetzenInstances = absetzenInstances;
		base._002Ector();
	}
}
