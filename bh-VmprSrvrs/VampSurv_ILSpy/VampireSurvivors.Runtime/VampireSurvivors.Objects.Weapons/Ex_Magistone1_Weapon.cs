using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Weapons;

public class Ex_Magistone1_Weapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass43_0
	{
		public int localIndex;

		public Ex_Magistone1_Weapon _003C_003E4__this;

		internal void _003CFire_003Eb__0()
		{
			//IL_012f: Expected O, but got I4
			//IL_00b4: Expected O, but got I
			//IL_00e9: Expected I, but got O
			//IL_0079->IL00f8: Incompatible stack heights: 1 vs 0
			//IL_009e->IL00f8: Incompatible stack heights: 1 vs 0
			//IL_00dc->IL00f8: Incompatible stack heights: 1 vs 0
			if ((object)_003C_003E4__this != null)
			{
				GameObject gameObject = _003C_003E4__this.gameObject;
				if ((object)gameObject != null)
				{
					bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
					object obj = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
					if (obj == null)
					{
						return;
					}
					GameObject gameObject2 = (GameObject)(object)_003C_003E4__this;
					if ((object)_003C_003E4__this != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdi_v7 (UnityEngine.GameObject)+58]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdi_v7 (UnityEngine.GameObject)+58]");
							float2 position = ((ArcadeSprite)0).position;
							Ex_Magistone1_Weapon ex_Magistone1_Weapon = _003C_003E4__this;
							if ((object)_003C_003E4__this != null)
							{
								nint num = (nint)gameObject2;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v246 @ r10_v2 (Il2CppClass<UnityEngine.GameObject>)+4D8] (should have been resolved before IL gen)");
								return;
							}
						}
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	private Projectile _FragmentPrefab;

	private bool _OverrideFragmentBounceY;

	private float _FragmentBounceY;

	private bool _OverrideFragmentSpeed;

	private float _FragmentSpeed;

	private BulletPool _fragmentPool;

	private int _baseFragmentAmount = 1;

	protected List<uint> _tints;

	private int _spawnCounter;

	public bool InverseAreaScalingForFragments => true;

	public bool SimulateZPlaneMovementForFragments => true;

	public bool EnableShadows => true;

	public bool EnableFragmentShadows => true;

	public bool UseSantaWaterTargeting => false;

	public bool FragmentsOnlyHitOnBounce => false;

	public bool OverrideFragmentBounceY => _OverrideFragmentBounceY;

	public float FragmentBounceY => _FragmentBounceY;

	public bool OverrideFragmentSpeed => _OverrideFragmentSpeed;

	public float FragmentSpeed => _FragmentSpeed;

	public BulletPool FragmentPool => _fragmentPool;

	public int FragmentAmount
	{
		get
		{
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0023: Expected I4, but got Unknown
			float num = base.PAmount();
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
			return (int)(num + _baseFragmentAmount);
		}
	}

	public float ProjectileScaleMultiplier => 0.5f;

	public List<uint> Tints => _tints;

	public int SpawnCounter => _spawnCounter;

	public override float PPower()
	{
		//IL_0007: Expected F4, but got I4
		return ((Equipment)this)._003CLevel_003Ek__BackingField;
	}

	protected override void OnStart()
	{
		//IL_0114: Expected I, but got O
		base.OnStart();
		if (_fragmentPool == null)
		{
			BulletPool bulletPool = new BulletPool(_FragmentPrefab);
			bulletPool.UpperLimit = 200;
			_fragmentPool = bulletPool;
			PhaserScene s_scene = ArcadePhysics.s_scene;
			ArcadePhysics physics = s_scene.physics;
			GameManager core = GM.Core;
			ArcadePhysicsCallback collideCallback = OnFragmentOverlapsEnemy;
			ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
			CallbackContext callbackContext = default(CallbackContext);
			Collider collider = physics.add.overlap(_fragmentPool, core.Enemies, collideCallback, processCallback, callbackContext);
			if ((object)GM.Core == null)
			{
				throw new NullReferenceException();
			}
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			ArcadePhysics physics2 = s_scene2.physics;
			GameManager core2 = GM.Core;
			PhysicsManager physicsManager = core2._physicsManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v456 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Weapons.Ex_Magistone1_Weapon>)+3A0]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num = (nint)this;
			Collider collider2 = physics2.add.overlap(_fragmentPool, physicsManager._destructiblesGroup, collideCallback2, processCallback, callbackContext);
		}
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		_spawnCounter = 0;
		SetTints();
	}

	protected virtual void SetTints()
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_019e: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_01c6: Expected O, but got I
		//IL_0156: Expected O, but got I
		List<uint> list = new List<uint>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ rdx_v4+18]");
		if (num >= 0)
		{
			list.AddWithResize(16711680u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 16711680;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rdx_v6+18]");
		if (num2 >= 0)
		{
			list.AddWithResize(255u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 255;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rdx_v8+18]");
		if (num3 >= 0)
		{
			list.AddWithResize(16776960u);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v2 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 16776960;
		}
		_tints = list;
	}

	public override void Fire(bool skipTriggers = false)
	{
		//IL_0050: Expected O, but got F4
		//IL_006d: Expected O, but got F4
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		//IL_0095: Expected F4, but got O
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Expected O, but got Unknown
		//IL_021f: Invalid comparison between O and F4
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Expected O, but got Unknown
		//IL_0101: Expected F4, but got O
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Vector2 vector = default(Vector2);
		Projectile projectile = FireOneProjectile(vector, 0, _targetTransform);
		float num = base.PAmount();
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
		object obj = num >> 31;
		float num2 = num - (float)obj;
		object obj2 = num2 >> 1;
		object obj3 = obj2 + 1;
		bool flag = (nint)obj3 <= 1;
		float num3 = (float)vector;
		if (!flag)
		{
			bool flag2 = true;
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			do
			{
				WeaponData currentWeaponData = _currentWeaponData;
				object obj4 = flag2 * currentWeaponData._003CrepeatInterval_003Ek__BackingField;
				if ((nint)obj4 <= 0)
				{
					Vector2 playerPos = base.PlayerPos;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA68F0");
					num3 = (float)playerPos;
				}
				else
				{
					_003C_003Ec__DisplayClass43_0 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass43_0();
					CS_0024_003C_003E8__locals8._003C_003E4__this = this;
					CS_0024_003C_003E8__locals8.localIndex = (flag2 ? 1 : 0);
					WeaponData currentWeaponData2 = _currentWeaponData;
					Action onComplete = delegate
					{
						//IL_012f: Expected O, but got I4
						//IL_00b4: Expected O, but got I
						//IL_00e9: Expected I, but got O
						//IL_0079->IL00f8: Incompatible stack heights: 1 vs 0
						//IL_009e->IL00f8: Incompatible stack heights: 1 vs 0
						//IL_00dc->IL00f8: Incompatible stack heights: 1 vs 0
						if ((object)CS_0024_003C_003E8__locals8._003C_003E4__this != null)
						{
							GameObject gameObject = CS_0024_003C_003E8__locals8._003C_003E4__this.gameObject;
							if ((object)gameObject != null)
							{
								bool flag3 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
								object obj6 = GameObject.get_activeSelf_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
								if (obj6 == null)
								{
									return;
								}
								GameObject gameObject2 = (GameObject)(object)CS_0024_003C_003E8__locals8._003C_003E4__this;
								if ((object)CS_0024_003C_003E8__locals8._003C_003E4__this != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdi_v7 (UnityEngine.GameObject)+58]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdi_v7 (UnityEngine.GameObject)+58]");
										float2 position2 = ((ArcadeSprite)0).position;
										Ex_Magistone1_Weapon ex_Magistone1_Weapon = CS_0024_003C_003E8__locals8._003C_003E4__this;
										if ((object)CS_0024_003C_003E8__locals8._003C_003E4__this != null)
										{
											nint num8 = (nint)gameObject2;
											Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v246 @ r10_v2 (Il2CppClass<UnityEngine.GameObject>)+4D8] (should have been resolved before IL gen)");
											return;
										}
									}
								}
							}
						}
						throw new NullReferenceException();
					};
					float num4 = (float)(flag2 ? 1 : 0) * currentWeaponData2._003CrepeatInterval_003Ek__BackingField;
					num3 = num4 * 0.001f;
					Timer lastShotTimer = Timers.Register(num3, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					_lastShotTimer = lastShotTimer;
				}
				flag2 = (byte)((flag2 ? 1u : 0u) + 1u) != 0;
			}
			while ((flag2 ? 1 : 0) < (nint)obj3);
		}
		float num5 = base.PInterval();
		float num6 = _lastFiringInterval - num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
		object obj5 = num6 & 0;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon))
		{
			float num7 = base.PInterval();
			_lastFiringInterval = num3;
			base.ResetFiringTimer();
		}
		if (!skipTriggers)
		{
			((Equipment)this)._003COwner_003Ek__BackingField.OnWeaponFired(this);
		}
	}

	public override Projectile FireOneProjectile(Vector2 pos, int index, Transform target = null, BulletPool pool = null)
	{
		//IL_00f2: Expected I, but got O
		//IL_0100: Expected I, but got O
		//IL_0110: Expected O, but got I
		//IL_0190: Expected O, but got I4
		//IL_014c: Expected O, but got I
		//IL_0182: Expected O, but got I4
		Projectile projectile;
		Projectile projectile2;
		object obj3;
		if (_isVisible)
		{
			GameManager core = GM.Core;
			if ((object)GM.Core != null && (object)core._stage != null)
			{
				if (!core._stage.IsCharacterNearYourPlayer(((Equipment)this)._003COwner_003Ek__BackingField))
				{
					goto IL_0205;
				}
				Vector2 spawnPosition = GetSpawnPosition(index, out var _);
				if (_projectilePool != null)
				{
					float2 pos2 = default(float2);
					projectile = _projectilePool.SpawnAt(pos2, this, index);
					bool flag = (object)projectile == null;
					projectile2 = null;
					if (!flag)
					{
						nint num = (nint)projectile;
						nint num2 = (nint)typeof(Ex_Magistone1_Projectile);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v230 @ rdx_v9 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Ex_Magistone1_Projectile>)+130]");
						object obj = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
						nint num3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v230 @ rdx_v9 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Ex_Magistone1_Projectile>)+130]");
						if (num3 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ r8_v7 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
							object obj2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v286 @ rax_v29+FFFFFFF8+v231 @ rax_v25*8]");
							if (0 == (nint)typeof(Ex_Magistone1_Projectile))
							{
								obj3 = 1;
								goto IL_0239;
							}
						}
						obj3 = 0;
						goto IL_0239;
					}
					goto IL_0260;
				}
			}
			return (Projectile)(object)new NullReferenceException();
		}
		goto IL_0205;
		IL_0205:
		return null;
		IL_0260:
		if ((object)projectile2 != null && ((UnityEngine.Object)projectile2).m_CachedPtr != (IntPtr)0)
		{
			int spawnCounter = _spawnCounter + 1;
			_spawnCounter = spawnCounter;
			((Ex_Magistone1_Projectile)projectile2).DropGem();
		}
		return projectile2;
		IL_0239:
		bool flag2 = obj3 == null;
		projectile2 = null;
		if (!flag2)
		{
			projectile2 = projectile;
		}
		goto IL_0260;
	}

	private unsafe Vector2 GetSpawnPosition(int index, out float spawnOffsetY)
	{
		//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Expected Ref, but got Unknown
		//IL_04f8: Expected Ref, but got F4
		//IL_0500: Expected O, but got F4
		//IL_02d5: Expected O, but got Ref
		//IL_05d6: Expected Ref, but got F4
		//IL_035e: Expected Ref, but got F4
		//IL_0378: Expected O, but got F4
		//IL_0637: Expected O, but got F4
		//IL_063c->IL063c: Incompatible stack heights: 1 vs 0
		Camera main = Camera.main;
		Bounds bounds = CameraExtensions.OrthographicBounds(main);
		float num2 = default(float);
		float num = num2 * 2f;
		float num3 = num * 0.95f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rax_v5 (UnityEngine.Bounds)+10]");
		float num4 = 0f * 2f;
		float num5 = num4 * 0.8f;
		float num6 = num2 * 2f;
		float num7 = num6 - num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rax_v5 (UnityEngine.Bounds)+10]");
		float num8 = 0f * 2f;
		float num9 = num7 * 0.5f;
		float num10 = num8 - num5;
		float num11 = num10 * 0.5f;
		Rectangle rectangle = new Rectangle();
		float num12 = (float)bounds.m_Center - num2;
		Vector3 ret = default(Vector3);
		ref float reference;
		if (rectangle != null)
		{
			float x = num12 + num9;
			rectangle._x = x;
			float num13 = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rax_v5 (UnityEngine.Bounds)+10]");
			float y = num13 - 0f;
			rectangle._y = y;
			rectangle._width = num3;
			rectangle._height = num5;
			GameManager core = GM.Core;
			if ((object)GM.Core != null && (object)((Equipment)this)._003COwner_003Ek__BackingField != null && (object)core._stage != null)
			{
				ref Unity.Mathematics.Random rng = ref *(Unity.Mathematics.Random*)(((Equipment)this)._003COwner_003Ek__BackingField + 176);
				Transform targetTransform = core._stage.PickRandomEnemyInRectBounds(rectangle, ref rng);
				_targetTransform = targetTransform;
				if (!IsHoming)
				{
					goto IL_037d;
				}
				GameManager core2 = GM.Core;
				if ((object)GM.Core != null && (object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
					if ((object)core2._stage != null)
					{
						EnemyController enemyController = core2._stage.FindClosestEnemy((Vector3)(&ret), excludeDead: true);
						bool flag = (object)enemyController == null;
						y = num2;
						rng = ref *(Unity.Mathematics.Random*)1;
						if (!flag)
						{
							bool flag2 = ((UnityEngine.Object)enemyController).m_CachedPtr == (IntPtr)0;
							y = num2;
							rng = ref *(Unity.Mathematics.Random*)1;
							if (!flag2)
							{
								float num14 = num2;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rax_v5 (UnityEngine.Bounds)+10]");
								float num15 = num14 + 0f;
								float2 position2 = enemyController.position;
								float num17 = default(float);
								float num16 = num15 - num17;
								reference = ref *(float*)num16;
								float2 position3 = enemyController.position;
								return (Vector2)num2;
							}
						}
						goto IL_037d;
					}
				}
			}
		}
		goto IL_0524;
		IL_0524:
		throw new NullReferenceException();
		IL_037d:
		Transform targetTransform2 = _targetTransform;
		if ((object)_targetTransform != null && ((UnityEngine.Object)targetTransform2).m_CachedPtr != (IntPtr)0)
		{
			float num18 = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rax_v5 (UnityEngine.Bounds)+10]");
			float num19 = num18 + 0f;
			object targetTransform3 = _targetTransform;
			if ((object)_targetTransform != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rdi_v10 (System.Object)+10]");
				if ((nint)0 == 0)
				{
					UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(_targetTransform);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rdi_v10 (System.Object)+10]");
					Transform.get_position_Injected((IntPtr)0, out ret);
					object obj = default(object);
					float num20 = num19 - (float)obj;
					reference = ref *(float*)num20;
					Ex_Magistone1_Weapon targetTransform4 = (Ex_Magistone1_Weapon)(object)_targetTransform;
					if ((object)_targetTransform != null)
					{
						bool flag3 = ((UnityEngine.Object)targetTransform4).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)targetTransform4).m_CachedPtr, out Vector3 _);
						return (Vector2)num2;
					}
				}
			}
			goto IL_0524;
		}
		float num21 = (float)bounds.m_Center - num2;
		float num22 = (float)bounds.m_Center + num2;
		float maxInclusive = num22 - num9;
		float minInclusive = num21 + num9;
		float num23 = UnityEngine.Random.Range(minInclusive, maxInclusive);
		float num24 = num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rax_v5 (UnityEngine.Bounds)+10]");
		float num25 = num24 - 0f;
		float num26 = num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rax_v5 (UnityEngine.Bounds)+10]");
		float num27 = num26 + 0f;
		float maxInclusive2 = num27 - num11;
		float minInclusive2 = num25 + num11;
		float num28 = UnityEngine.Random.Range(minInclusive2, maxInclusive2);
		float num29 = num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rax_v5 (UnityEngine.Bounds)+10]");
		float num30 = num29 + 0f;
		float num31 = num30 - num28;
		reference = ref *(float*)num31;
		return (Vector2)num2;
	}

	private unsafe bool OnFragmentOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_02e1: Expected I4, but got O
		//IL_00f7: Expected I, but got O
		//IL_00ff: Expected I, but got O
		//IL_010f: Expected O, but got I
		//IL_018f: Expected O, but got I4
		//IL_014b: Expected O, but got I
		//IL_0181: Expected O, but got I4
		//IL_0285: Expected O, but got Ref
		//IL_0285: Expected F4, but got O
		//IL_0348: Expected O, but got I4
		EnemyController component;
		Projectile component2;
		object obj3;
		if (first != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				component = gameObject.GetComponent<EnemyController>();
				if ((object)component != null)
				{
					if (component._003CIsDead_003Ek__BackingField)
					{
						goto IL_02fe;
					}
					if (second != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						GameObject gameObject2 = default(GameObject);
						if ((object)gameObject2 != null)
						{
							component2 = gameObject2.GetComponent<Projectile>();
							if ((object)component2 != null)
							{
								nint num = (nint)typeof(Ex_Magistone1_Projectile_Fragment);
								nint num2 = (nint)component2;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Ex_Magistone1_Projectile_Fragment>)+130]");
								object obj = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ r9_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
								nint num3 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Ex_Magistone1_Projectile_Fragment>)+130]");
								if (num3 >= 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ r9_v3 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
									object obj2 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ rcx_v22+FFFFFFF8+v338 @ rcx_v8*8]");
									if (0 == (nint)typeof(Ex_Magistone1_Projectile_Fragment))
									{
										obj3 = 1;
										goto IL_0304;
									}
								}
								obj3 = 0;
								goto IL_0304;
							}
						}
					}
				}
			}
		}
		goto IL_02d3;
		IL_02fe:
		return false;
		IL_02d3:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0304:
		bool flag = obj3 == null;
		Projectile projectile = null;
		if (!flag)
		{
			projectile = component2;
		}
		if ((object)projectile != null)
		{
			if (projectile.HasAlreadyHitObject(component))
			{
				goto IL_02fe;
			}
			float num4 = PPower();
			float num5 = base.CalcCritMul();
			object obj4 = default(object);
			float num6 = (float)obj4 * 0.5f;
			float value = (float)obj4 * num6;
			if (_playerOptions != null)
			{
				PlayerOptionsData config = _playerOptions.Config;
				if (config != null)
				{
					if (config._003CDamageNumbersEnabled_003Ek__BackingField)
					{
						float2 position = component.position;
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
						object obj5 = default(object);
						ShowDamage((float)position, (Vector3)(&obj5));
					}
					WeaponData currentWeaponData = _currentWeaponData;
					HitVfxType showHitVfx = ((_currentWeaponData == null) ? HitVfxType.Default : currentWeaponData._003ChitVFX_003Ek__BackingField);
					float knockback = base.Knockback;
					component.GetDamagedSpecial(value, showHitVfx, knockback, WeaponType.VOID, hasKb: false, (Vector3?)(object)0);
					goto IL_02fe;
				}
			}
		}
		goto IL_02d3;
	}

	protected unsafe override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_0200: Expected I4, but got O
		//IL_01a4: Expected O, but got Ref
		//IL_01a4: Expected F4, but got O
		//IL_0245: Expected O, but got I4
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
						goto IL_021d;
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
								if (component2.HasAlreadyHitObject(component))
								{
									goto IL_021d;
								}
								float num = PPower();
								if (_playerOptions != null)
								{
									PlayerOptionsData config = _playerOptions.Config;
									if (config != null)
									{
										if (config._003CDamageNumbersEnabled_003Ek__BackingField)
										{
											float2 position = component.position;
											Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
											object obj = default(object);
											ShowDamage((float)position, (Vector3)(&obj));
										}
										WeaponData currentWeaponData = _currentWeaponData;
										HitVfxType showHitVfx = ((_currentWeaponData == null) ? HitVfxType.Default : currentWeaponData._003ChitVFX_003Ek__BackingField);
										float knockback = base.Knockback;
										float num2 = default(float);
										component.GetDamagedSpecial(num2, showHitVfx, knockback, WeaponType.VOID, hasKb: false, (Vector3?)(object)0);
										float num3 = num2 + base._003CStatsInflictedDamage_003Ek__BackingField;
										base._003CStatsInflictedDamage_003Ek__BackingField = num3;
										goto IL_021d;
									}
								}
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_021d:
		return false;
	}

	private Color32 GetDamageColor(float value)
	{
		if (value < 60f)
		{
			if (!(value < 30f))
			{
				DamageNumberManager damageNumberManager = GameManager.DamageNumberManager;
				if ((object)GameManager.DamageNumberManager != null)
				{
					return damageNumberManager.Color003;
				}
			}
			else
			{
				DamageNumberManager damageNumberManager2 = GameManager.DamageNumberManager;
				if ((object)GameManager.DamageNumberManager != null)
				{
					return damageNumberManager2.Color000;
				}
			}
		}
		else if (!(value < 100f))
		{
			DamageNumberManager damageNumberManager3 = GameManager.DamageNumberManager;
			if ((object)GameManager.DamageNumberManager != null)
			{
				return damageNumberManager3.Color010;
			}
		}
		else
		{
			DamageNumberManager damageNumberManager4 = GameManager.DamageNumberManager;
			if ((object)GameManager.DamageNumberManager != null)
			{
				return damageNumberManager4.Color006;
			}
		}
		return (Color32)new NullReferenceException();
	}

	private void ShowDamage(float value, Vector3 position)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm6\"");
		if (value < 60f)
		{
			if (value < 30f)
			{
			}
		}
		else if (value < 100f)
		{
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AAE780");
	}

	public override void CheckArcanas()
	{
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
				HasCooldownSpeedBonus = true;
				IsHoming = true;
			}
		}
	}

	public override void ParadoxFire()
	{
		Fire(skipTriggers: true);
		Action onComplete = delegate
		{
			Fire(skipTriggers: true);
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.016f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		Action onComplete2 = delegate
		{
			Fire(skipTriggers: true);
		};
		Timer timer2 = Timers.Register(0.032f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		Action onComplete3 = delegate
		{
			Fire(skipTriggers: true);
		};
		Timer timer3 = Timers.Register(0.048f, onComplete3, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		Action onComplete4 = delegate
		{
			Fire(skipTriggers: true);
		};
		Timer timer4 = Timers.Register(0.064f, onComplete4, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	public override void SetVisible(bool visible)
	{
		_isVisible = visible;
		if (!visible)
		{
			DespawnAllProjectiles();
		}
	}

	public override void Cleanup()
	{
		DespawnAllProjectiles();
		base.Cleanup();
	}

	private void DespawnAllProjectiles()
	{
		//IL_004e: Expected O, but got I4
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected O, but got Unknown
		List<Projectile> spawnedProjectiles = _spawnedProjectiles;
		bool flag = spawnedProjectiles._size < 0;
		if (spawnedProjectiles._size == 0)
		{
			return;
		}
		object obj = spawnedProjectiles._size - 1;
		if (flag)
		{
			return;
		}
		while (true)
		{
			List<Projectile> spawnedProjectiles2 = _spawnedProjectiles;
			if ((nint)obj >= spawnedProjectiles2._size)
			{
				break;
			}
			Projectile[] items = spawnedProjectiles2._items;
			items[obj].Despawn();
			obj--;
			if ((nint)items[obj] < 0)
			{
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private void _003CParadoxFire_003Eb__51_0()
	{
		Fire(skipTriggers: true);
	}

	private void _003CParadoxFire_003Eb__51_1()
	{
		Fire(skipTriggers: true);
	}

	private void _003CParadoxFire_003Eb__51_2()
	{
		Fire(skipTriggers: true);
	}

	private void _003CParadoxFire_003Eb__51_3()
	{
		Fire(skipTriggers: true);
	}
}
