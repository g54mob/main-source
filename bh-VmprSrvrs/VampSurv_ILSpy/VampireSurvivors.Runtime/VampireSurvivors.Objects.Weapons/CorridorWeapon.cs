using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using QFSW.MOP2;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Objects.VFX;

namespace VampireSurvivors.Objects.Weapons;

public class CorridorWeapon : Weapon
{
	private GameObject _CorridorProjectilePrefab;

	private GameObject _LancetPierceEffectPrefab;

	private ObjectPool _effectPool;

	private BulletPool _corridorPool;

	private int _ticks;

	private readonly List<Vector2> _targets;

	private readonly List<float> _angles;

	public override float PAmount()
	{
		return 6f;
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_003b: Expected I4, but got I8
		//IL_01e2: Expected O, but got I4
		//IL_0214: Expected O, but got I
		//IL_0224: Expected O, but got I
		//IL_027d: Expected O, but got I
		//IL_02b9: Expected O, but got I
		//IL_02c9: Expected O, but got I
		//IL_0330: Expected O, but got I
		//IL_0315: Expected O, but got I
		//IL_038b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0390: Expected O, but got Unknown
		//IL_03a5: Expected O, but got I
		base.InitWeapon(characterController, weaponType);
		string text = ((UnityEngine.Object)_LancetPierceEffectPrefab).GetName();
		ObjectPool objectPool = ObjectPool.Create(_LancetPierceEffectPrefab, text, 1, -1);
		objectPool._incrementalInstanceNames = true;
		if (!objectPool._003CInitialized_003Ek__BackingField)
		{
			objectPool._003CInitialized_003Ek__BackingField = true;
			objectPool.AutoFillName();
			objectPool.Populate(objectPool._defaultSize);
		}
		MasterObjectPooler._003CInstance_003Ek__BackingField.AddPool(objectPool._name, objectPool);
		_effectPool = objectPool;
		Projectile component = _CorridorProjectilePrefab.GetComponent<Projectile>();
		BulletPool corridorPool = new BulletPool(component);
		_corridorPool = corridorPool;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		ArcadePhysics physics = s_scene.physics;
		GameManager gameMan = _gameMan;
		ArcadePhysicsCallback arcadePhysicsCallback = OnCorridorOverlapsEnemy;
		ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		Collider collider = physics.add.overlap(_corridorPool, gameMan.Enemies, arcadePhysicsCallback, processCallback, callbackContext);
		List<Vector2> targets = _targets;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v230 @ rcx_v26 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+1C]");
		_ = (nint)0 + (nint)1;
		_ = 0;
		List<float> angles = _angles;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rcx_v28 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		_ = 0;
		ArcadeColliderType enemies = gameMan.Enemies;
		ArcadePhysicsCallback arcadePhysicsCallback2 = arcadePhysicsCallback;
		object obj = 0;
		ArcadeColliderType corridorPool2 = _corridorPool;
		Vector2 item = default(Vector2);
		bool flag;
		do
		{
			List<Vector2> targets2 = _targets;
			float num = (float)obj / 12f;
			float num2 = num * ((float)Math.PI * 2f);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ rbx_v9 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ rbx_v9 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ rbx_v9 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ rbx_v9 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v208 @ rdx_v15+18]");
			if (num3 >= 0)
			{
				targets2.AddWithResize(item);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ rbx_v9 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
				object obj4 = (nint)0 + (nint)1;
			}
			angles = _angles;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rcx_v28 (System.Collections.Generic.List`1<System.Single>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rcx_v28 (System.Collections.Generic.List`1<System.Single>)+10]");
			enemies = (ArcadeColliderType)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rcx_v28 (System.Collections.Generic.List`1<System.Single>)+18]");
			corridorPool2 = (ArcadeColliderType)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rcx_v28 (System.Collections.Generic.List`1<System.Single>)+18]");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ r8_v12 (ArcadeColliderType)+18]");
			if (num4 >= 0)
			{
				angles.AddWithResize(num2);
				float num5 = num2;
				enemies = (ArcadeColliderType)0;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rcx_v28 (System.Collections.Generic.List`1<System.Single>)+18]");
				object obj5 = (nint)0 + (nint)1;
				float num5 = num2;
			}
			obj++;
			flag = (nint)obj < 12;
			arcadePhysicsCallback2 = (ArcadePhysicsCallback)0;
		}
		while (flag);
	}

	public override void Cleanup()
	{
		ObjectPool effectPool = _effectPool;
		if ((object)_effectPool != null && ((UnityEngine.Object)effectPool).m_CachedPtr != (IntPtr)0)
		{
			_effectPool.ReleaseAll();
		}
		if (_corridorPool != null)
		{
			_corridorPool.Cleanup();
		}
		base.Cleanup();
	}

	public unsafe override void Fire(bool skipTriggers = false)
	{
		//IL_009f: Expected O, but got I
		//IL_0146: Expected O, but got I
		//IL_04ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f3: Expected O, but got Unknown
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Expected O, but got Unknown
		//IL_0528: Unknown result type (might be due to invalid IL or missing references)
		//IL_052d: Expected O, but got Unknown
		//IL_0536: Unknown result type (might be due to invalid IL or missing references)
		//IL_053b: Expected O, but got Unknown
		//IL_0574: Unknown result type (might be due to invalid IL or missing references)
		//IL_0579: Expected O, but got Unknown
		//IL_0213: Expected O, but got I
		//IL_025a: Expected O, but got I
		//IL_025a: Expected F4, but got I
		//IL_025a: Expected I4, but got O
		//IL_0263: Unknown result type (might be due to invalid IL or missing references)
		//IL_0268: Expected O, but got Unknown
		//IL_064f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0654: Expected O, but got Unknown
		//IL_06bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c1: Expected O, but got Unknown
		//IL_02e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ee: Expected O, but got Unknown
		//IL_02f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fc: Expected O, but got Unknown
		//IL_03ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d3: Expected O, but got Unknown
		//IL_03dc: Invalid comparison between O and F4
		//IL_040f: Expected F4, but got I
		//IL_00bf->IL044a: Incompatible stack heights: 1 vs 0
		//IL_010c->IL044a: Incompatible stack heights: 1 vs 0
		//IL_0166->IL044a: Incompatible stack heights: 2 vs 0
		//IL_051f->IL0488: Incompatible stack heights: 1 vs 0
		//IL_05c3->IL044a: Incompatible stack heights: 3 vs 0
		//IL_0233->IL044a: Incompatible stack heights: 4 vs 0
		//IL_0280->IL0595: Incompatible stack heights: 4 vs 3
		//IL_0617->IL044a: Incompatible stack heights: 5 vs 0
		//IL_068a->IL044a: Incompatible stack heights: 6 vs 0
		//IL_06ed->IL044a: Incompatible stack heights: 7 vs 0
		//IL_0434->IL044a: Incompatible stack heights: 7 vs 0
		if (++_ticks >= 12)
		{
			_ticks = 0;
		}
		object obj2 = default(object);
		if (_ticks == 9)
		{
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				Transform transform = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
				if ((object)transform != null)
				{
					_ = 0;
					_ = 0;
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					object obj = obj2 - 72;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)obj);
					Vector2 pos = default(Vector2);
					Projectile projectile = base.FireOneProjectile(pos, 0);
					goto IL_0488;
				}
			}
			goto IL_044a;
		}
		goto IL_0488;
		IL_0488:
		List<Vector2> targets = _targets;
		int ticks = _ticks;
		if (_targets != null)
		{
			int ticks2 = _ticks;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rcx_v35 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			bool flag2 = (nint)ticks2 >= (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rcx_v35 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rcx_v35 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
			if ((nint)0 != 0)
			{
				List<float> angles = _angles;
				int ticks3 = _ticks;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ rcx_v36+20+v156 @ rax_v39 (System.Int32)*8]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ rcx_v36+24+v156 @ rax_v39 (System.Int32)*8]");
				_ = 0;
				if (_angles != null)
				{
					int ticks4 = _ticks;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ rax_v40 (System.Collections.Generic.List`1<System.Single>)+18]");
					bool flag3 = (nint)ticks4 >= (nint)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ rax_v40 (System.Collections.Generic.List`1<System.Single>)+10]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ rax_v40 (System.Collections.Generic.List`1<System.Single>)+10]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ rcx_v37+20+v219 @ rdx_v27 (System.Int32)*4]");
						float num = 0f * 57.29578f;
						Transform cachedTransform = _cachedTransform;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
						object obj5 = num ^ 0;
						float num2 = (float)obj5 * ((float)Math.PI / 180f);
						_ = 0;
						object obj6 = obj2 - 56;
						object obj7 = obj2 - 72;
						Quaternion.Internal_FromEulerRad_Injected(ref *(Vector3*)obj7, out *(Quaternion*)obj6);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-38]");
						_ = 0;
						bool flag4 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
						object obj8 = obj2 - 40;
						Transform.set_localRotation_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref *(Quaternion*)obj8);
						Transform transform2 = null;
						while (true)
						{
							List<float> angles2 = _angles;
							int ticks5 = _ticks;
							if (_angles == null)
							{
								break;
							}
							int ticks6 = _ticks;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ rax_v49 (System.Collections.Generic.List`1<System.Single>)+18]");
							bool flag5 = (nint)ticks6 >= (nint)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ rax_v49 (System.Collections.Generic.List`1<System.Single>)+10]");
							object obj9 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ rax_v49 (System.Collections.Generic.List`1<System.Single>)+10]");
							if ((nint)0 == 0)
							{
								break;
							}
							Transform obj10 = transform2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ rdx_v31+20+v242 @ rcx_v44 (System.Int32)*4]");
							nint num3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+28]");
							FireOneLancet((int)obj10, num3, (Vector2)0);
							transform2 = (Transform)(transform2 + 1);
							if ((nint)transform2 < 6)
							{
								continue;
							}
							bool flag6 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
							IntPtr gcHandlePtr = Component.get_transform_Injected(((UnityEngine.Object)this).m_CachedPtr);
							Transform transform3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
							if ((object)transform3 == null)
							{
								break;
							}
							_ = 0;
							_ = 0;
							bool flag7 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
							object obj11 = obj2 - 72;
							Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out *(Vector3*)obj11);
							Transform cachedTransform2 = _cachedTransform;
							if ((object)_cachedTransform == null)
							{
								break;
							}
							_ = 0;
							bool flag8 = ((UnityEngine.Object)cachedTransform2).m_CachedPtr == (IntPtr)0;
							object obj12 = obj2 - 56;
							Transform.get_rotation_Injected(((UnityEngine.Object)cachedTransform2).m_CachedPtr, out *(Quaternion*)obj12);
							if ((object)_effectPool == null)
							{
								break;
							}
							nint num4 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1375 @ rdi_v23 (Il2CppMethodInfo)+38]");
							if ((nint)0 == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
							}
							Quaternion rotation = (Quaternion)(obj2 - 40);
							Vector3 position = (Vector3)(obj2 - 56);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-38]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-48]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-40]");
							_ = 0;
							GameObject obj13 = _effectPool.GetObject(position, rotation);
							Transform objectComponent = (Transform)(object)_effectPool.GetObjectComponent<LancetPierceEffect>(obj13);
							if ((object)objectComponent != null && ((UnityEngine.Object)objectComponent).m_CachedPtr != (IntPtr)0)
							{
								((LancetPierceEffect)(object)objectComponent).Play();
							}
							float num5 = base.PInterval();
							float num6 = _lastFiringInterval;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-38]");
							float num7 = num6 - 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
							object obj14 = num7 & 0;
							if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj14) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
							{
								float num8 = base.PInterval();
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp-38]");
								_lastFiringInterval = 0f;
								base.ResetFiringTimer();
							}
							if (!skipTriggers)
							{
								if ((object)((Equipment)this)._003COwner_003Ek__BackingField == null)
								{
									break;
								}
								((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
							}
							return;
						}
					}
				}
			}
		}
		goto IL_044a;
		IL_044a:
		throw new NullReferenceException();
	}

	private unsafe void FireOneLancet(int index, float angle, Vector2 targetPos)
	{
		//IL_007a: Expected I, but got O
		//IL_0082: Expected I, but got O
		//IL_0092: Expected O, but got I
		//IL_00cf: Expected O, but got I
		//IL_0218->IL01ba: Incompatible stack heights: 3 vs 1
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			Transform transform = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Vector2 ret;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)(&ret));
				Vector2 pos = default(Vector2);
				Projectile projectile = base.FireOneProjectile(pos, index);
				if ((object)projectile == null || ((UnityEngine.Object)projectile).m_CachedPtr == (IntPtr)0)
				{
					return;
				}
				nint num = (nint)typeof(LancetProjectile);
				nint num2 = (nint)projectile;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v638 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.LancetProjectile>)+130]");
				Vector2 vector = (Vector2)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v639 @ rcx_v27 (Il2CppClass<VampireSurvivors.Objects.Projectiles.LancetProjectile>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v638 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Projectiles.LancetProjectile>)+130]");
				if (num3 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v639 @ rcx_v27 (Il2CppClass<VampireSurvivors.Objects.Projectiles.LancetProjectile>)+C8]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v654 @ rax_v45+FFFFFFF8+v640 @ rax_v33 (UnityEngine.Vector2)*8]");
					if (0 == (nint)typeof(LancetProjectile))
					{
						((LancetProjectile)projectile).SetTargetPosition(targetPos);
					}
				}
				Transform cachedTransform = _cachedTransform;
				Quaternion.Internal_FromEulerRad_Injected(ref *(Vector3*)(&ret), out Quaternion _);
				bool flag2 = (object)_cachedTransform == null;
				bool flag3 = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
				Quaternion value = default(Quaternion);
				Transform.set_localRotation_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref value);
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void FireCorridor()
	{
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			Transform transform = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
				Vector2 pos = default(Vector2);
				Projectile projectile = base.FireOneProjectile(pos, 0);
				return;
			}
		}
		throw new NullReferenceException();
	}

	private ObjectPool GeneratePool(GameObject prefab, int defaultSize = 1, int maxSize = -1)
	{
		if ((object)prefab != null)
		{
			string text = ((UnityEngine.Object)prefab).GetName();
			ObjectPool objectPool = ObjectPool.Create(prefab, text, defaultSize, maxSize);
			if ((object)objectPool != null)
			{
				objectPool._incrementalInstanceNames = true;
				if (!objectPool._003CInitialized_003Ek__BackingField)
				{
					objectPool._003CInitialized_003Ek__BackingField = true;
					objectPool.AutoFillName();
					objectPool.Populate(objectPool._defaultSize);
				}
				if ((object)MasterObjectPooler._003CInstance_003Ek__BackingField != null)
				{
					MasterObjectPooler._003CInstance_003Ek__BackingField.AddPool(objectPool._name, objectPool);
					return objectPool;
				}
			}
		}
		return (ObjectPool)(object)new NullReferenceException();
	}

	private void CleanupPool(ObjectPool pool)
	{
		if ((object)pool != null && ((UnityEngine.Object)pool).m_CachedPtr != (IntPtr)0)
		{
			pool.ReleaseAll();
		}
	}

	private bool OnCorridorOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_0180: Expected I4, but got O
		//IL_00a6: Invalid comparison between O and F4
		if (first != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				EnemyController component = gameObject.GetComponent<EnemyController>();
				if ((object)component != null)
				{
					object obj = default(object);
					if (component._003CIsDead_003Ek__BackingField || ((object)component._003CResCorridor_003Ek__BackingField != null && System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f)))
					{
						goto IL_019d;
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
									float damage = component._hp * 0.5f;
									base.DealDamage(component, damage);
								}
								goto IL_019d;
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_019d:
		return false;
	}

	public CorridorWeapon()
	{
		List<Vector2> targets = new List<Vector2>();
		_targets = targets;
		_angles = new List<float>();
		base._002Ector();
	}
}
