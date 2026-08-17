using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class TP_SpiritTornado_Weapon : Weapon
{
	private BulletPool _invisibleProjectilePool;

	private Projectile _invisibleProjectilePrefab;

	private BulletPool _spiritGemProjectilePool;

	private Projectile _spiritGemProjectilePrefab;

	private BulletPool _gemExplosionProjectilePool;

	private Projectile _gemExplosionProjectilePrefab;

	private bool canPickupItems = true;

	private Timer pickupsResetTimer;

	private List<Pickup> itemsPickedUp;

	private bool _isManualFire;

	protected override FiringAnimation GetFiringAnimation()
	{
		return FiringAnimation.Magic;
	}

	public void SetManualFire()
	{
		_isManualFire = true;
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}

	protected override void OnStart()
	{
		//IL_0106: Expected I, but got O
		//IL_01a9: Expected I, but got O
		//IL_0263: Expected I, but got O
		//IL_03b5: Expected I, but got O
		//IL_0458: Expected I, but got O
		//IL_04cf: Expected I4, but got O
		base.OnStart();
		PhaserScene s_scene = ArcadePhysics.s_scene;
		ArcadePhysics physics = s_scene.physics;
		GameManager core = GM.Core;
		PhysicsManager physicsManager = core._physicsManager;
		ArcadePhysicsCallback collideCallback = OnBulletOverlapsPickup;
		ArcadePhysicsCallback arcadePhysicsCallback = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		Collider collider = physics.add.overlap(_projectilePool, physicsManager._pickupGroup, collideCallback, arcadePhysicsCallback, callbackContext);
		BulletPool invisibleProjectilePool = new BulletPool(_invisibleProjectilePrefab);
		_invisibleProjectilePool = invisibleProjectilePool;
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene2 = ArcadePhysics.s_scene;
			ArcadePhysics physics2 = s_scene2.physics;
			GameManager core2 = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v845 @ r8_v6 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_SpiritTornado_Weapon>)+370]");
			ArcadePhysicsCallback collideCallback2 = new ArcadePhysicsCallback(this, (IntPtr)0);
			nint num = (nint)this;
			Collider collider2 = physics2.add.overlap(_invisibleProjectilePool, core2.Enemies, collideCallback2, arcadePhysicsCallback, callbackContext);
			if ((object)GM.Core != null)
			{
				PhaserScene s_scene3 = ArcadePhysics.s_scene;
				ArcadePhysics physics3 = s_scene3.physics;
				GameManager core3 = GM.Core;
				PhysicsManager physicsManager2 = core3._physicsManager;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v867 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_SpiritTornado_Weapon>)+3A0]");
				ArcadePhysicsCallback collideCallback3 = new ArcadePhysicsCallback(this, (IntPtr)0);
				nint num2 = (nint)this;
				Collider collider3 = physics3.add.overlap(_invisibleProjectilePool, physicsManager2._destructiblesGroup, collideCallback3, arcadePhysicsCallback, callbackContext);
				BulletPool spiritGemProjectilePool = new BulletPool(_spiritGemProjectilePrefab);
				_spiritGemProjectilePool = spiritGemProjectilePool;
				if ((object)GM.Core != null)
				{
					PhaserScene s_scene4 = ArcadePhysics.s_scene;
					ArcadePhysics physics4 = s_scene4.physics;
					GameManager core4 = GM.Core;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v959 @ r8_v14 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_SpiritTornado_Weapon>)+370]");
					ArcadePhysicsCallback collideCallback4 = new ArcadePhysicsCallback(this, (IntPtr)0);
					nint num3 = (nint)this;
					Collider collider4 = physics4.add.overlap(_spiritGemProjectilePool, core4.Enemies, collideCallback4, arcadePhysicsCallback, callbackContext);
					if ((object)GM.Core != null)
					{
						PhaserScene s_scene5 = ArcadePhysics.s_scene;
						ArcadePhysics physics5 = s_scene5.physics;
						GameManager core5 = GM.Core;
						PhysicsManager physicsManager3 = core5._physicsManager;
						ArcadePhysicsCallback collideCallback5 = OnGemOverlapsPlayer;
						Collider collider5 = physics5.add.overlap(_spiritGemProjectilePool, physicsManager3._playerGroup, collideCallback5, arcadePhysicsCallback, callbackContext);
						BulletPool gemExplosionProjectilePool = new BulletPool(_gemExplosionProjectilePrefab);
						_gemExplosionProjectilePool = gemExplosionProjectilePool;
						if ((object)GM.Core != null)
						{
							PhaserScene s_scene6 = ArcadePhysics.s_scene;
							ArcadePhysics physics6 = s_scene6.physics;
							GameManager core6 = GM.Core;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1072 @ r8_v21 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_SpiritTornado_Weapon>)+370]");
							ArcadePhysicsCallback collideCallback6 = new ArcadePhysicsCallback(this, (IntPtr)0);
							nint num4 = (nint)this;
							Collider collider6 = physics6.add.overlap(_gemExplosionProjectilePool, core6.Enemies, collideCallback6, arcadePhysicsCallback, callbackContext);
							if ((object)GM.Core != null)
							{
								PhaserScene s_scene7 = ArcadePhysics.s_scene;
								ArcadePhysics physics7 = s_scene7.physics;
								GameManager core7 = GM.Core;
								PhysicsManager physicsManager4 = core7._physicsManager;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1094 @ r8_v24 (Il2CppClass<VampireSurvivors.Objects.Weapons.TP_SpiritTornado_Weapon>)+3A0]");
								ArcadePhysicsCallback collideCallback7 = new ArcadePhysicsCallback(this, (IntPtr)0);
								nint num5 = (nint)this;
								Collider collider7 = physics7.add.overlap(_gemExplosionProjectilePool, physicsManager4._destructiblesGroup, collideCallback7, arcadePhysicsCallback, callbackContext);
								Action onComplete = delegate
								{
									canPickupItems = true;
								};
								int repeat = default(int);
								TimerType type = default(TimerType);
								Timer timer = Timers.Register(0.1f, onComplete, null, isLooped: true, (byte)(int)arcadePhysicsCallback != 0, (MonoBehaviour)(object)callbackContext, repeat, type, isOnlineTimer: false, canPause: false);
								pickupsResetTimer = timer;
								float num6 = base.PInterval();
								float num7 = 0.1f * 0.5f;
								base._003CTotalTime_003Ek__BackingField = num7;
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public override void InternalUpdate()
	{
		base.InternalUpdate();
		if (!_isManualFire)
		{
			float deltaTime = PauseSystem.DeltaTime;
			float num = base.PInterval();
			float num2 = deltaTime * 1000f;
			if (!((base._003CTotalTime_003Ek__BackingField = num2 + base._003CTotalTime_003Ek__BackingField) < deltaTime))
			{
				base._003CTotalTime_003Ek__BackingField = 0f;
				base.Fire();
			}
		}
	}

	public override void ResetFiringTimer()
	{
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}

	public override void Fire(bool skipTriggers = false)
	{
		List<Pickup> list = itemsPickedUp;
		int version = list._version + 1;
		list._version = version;
		list._size = 0;
		if (list._size > 0)
		{
			Array.Clear(list._items, 0, list._size);
		}
		base.Fire(skipTriggers);
	}

	private bool OnBulletOverlapsPickup(CallbackContext context, ArcadeColliderType left, ArcadeColliderType right)
	{
		//IL_004a: Expected I, but got O
		//IL_0052: Expected I, but got O
		//IL_0062: Expected O, but got I
		//IL_00e2: Expected O, but got I4
		//IL_0549: Expected O, but got I
		//IL_009e: Expected O, but got I
		//IL_011c: Expected I, but got O
		//IL_0124: Expected I, but got O
		//IL_0134: Expected O, but got I
		//IL_00ef: Expected O, but got I
		//IL_00d4: Expected O, but got I4
		//IL_01b4: Expected O, but got I4
		//IL_057d: Expected O, but got I
		//IL_0170: Expected O, but got I
		//IL_01c1: Expected O, but got I
		//IL_01a6: Expected O, but got I4
		//IL_04f3: Expected I4, but got O
		//IL_034c: Expected I, but got O
		//IL_035a: Expected I, but got O
		//IL_036a: Expected O, but got I
		//IL_03ea: Expected O, but got I4
		//IL_03a6: Expected O, but got I
		//IL_04a2: Expected I, but got O
		//IL_03dc: Expected O, but got I4
		ArcadeColliderType arcadeColliderType2;
		ArcadeSprite arcadeSprite;
		nint num2;
		object obj3;
		ArcadeColliderType arcadeColliderType;
		if (canPickupItems)
		{
			if (left == null)
			{
				arcadeColliderType = left;
				arcadeColliderType2 = null;
				arcadeSprite = null;
				goto IL_0512;
			}
			nint num = (nint)typeof(Projectile);
			num2 = (nint)left;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v236 @ rdx_v19 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ r8_v17 (Il2CppClass<ArcadeColliderType>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v236 @ rdx_v19 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ r8_v17 (Il2CppClass<ArcadeColliderType>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v356 @ rax_v71+FFFFFFF8+v238 @ rax_v67*8]");
				if (0 == (nint)typeof(Projectile))
				{
					obj3 = 1;
					goto IL_0532;
				}
			}
			obj3 = 0;
			goto IL_0532;
		}
		goto IL_05b5;
		IL_0512:
		ArcadeSprite arcadeSprite2;
		if (right == null)
		{
			arcadeSprite2 = arcadeSprite;
			goto IL_0598;
		}
		nint num4 = (nint)typeof(Pickup);
		nint num5 = (nint)right;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v386 @ rdx_v18 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v387 @ r8_v16 (Il2CppClass<ArcadeColliderType>)+130]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v386 @ rdx_v18 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
		object obj6;
		if (num6 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v387 @ r8_v16 (Il2CppClass<ArcadeColliderType>)+C8]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v454 @ rax_v65+FFFFFFF8+v388 @ rax_v61*8]");
			if (0 == (nint)typeof(Pickup))
			{
				obj6 = 1;
				goto IL_0566;
			}
		}
		obj6 = 0;
		goto IL_0566;
		IL_05e2:
		object obj7;
		Projectile projectile;
		if (obj7 != null)
		{
			arcadeSprite = projectile;
		}
		goto IL_0604;
		IL_0604:
		bool flag = (object)arcadeSprite == null;
		Projectile projectile2 = projectile;
		if (!flag)
		{
			bool flag2 = ((UnityEngine.Object)arcadeSprite).m_CachedPtr == (IntPtr)0;
			projectile2 = projectile;
			if (!flag2)
			{
				projectile2 = projectile;
				arcadeSprite2.CheckRenderer();
				if ((object)arcadeSprite2._spriteRenderer == null)
				{
					goto IL_04e5;
				}
				Sprite sprite = arcadeSprite2._spriteRenderer.sprite;
				ArcadeSprite arcadeSprite3 = arcadeSprite.setFrame(sprite);
			}
		}
		nint num7 = (nint)arcadeSprite2;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v877 @ rax_v28 (Il2CppClass<ArcadeSprite>)+358] (should have been resolved before IL gen)");
		if (itemsPickedUp == null)
		{
			goto IL_04e5;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA3FE0");
		canPickupItems = false;
		goto IL_05b5;
		IL_05b5:
		return false;
		IL_0566:
		bool flag3 = obj6 == null;
		arcadeColliderType = (ArcadeColliderType)num5;
		arcadeSprite2 = arcadeSprite;
		if (!flag3)
		{
			arcadeColliderType = (ArcadeColliderType)num5;
			arcadeSprite2 = (ArcadeSprite)right;
		}
		goto IL_0598;
		IL_0532:
		bool flag4 = obj3 == null;
		arcadeColliderType = (ArcadeColliderType)num2;
		arcadeColliderType2 = null;
		arcadeSprite = null;
		if (!flag4)
		{
			arcadeColliderType = (ArcadeColliderType)num2;
			arcadeColliderType2 = left;
			arcadeSprite = null;
		}
		goto IL_0512;
		IL_04e5:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0598:
		if ((object)arcadeSprite2 != null && ((UnityEngine.Object)arcadeSprite2).m_CachedPtr != (IntPtr)0 && arcadeColliderType2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rsi_v3 (ArcadeColliderType)+10]");
			if ((nint)0 != 0)
			{
				if (itemsPickedUp == null)
				{
					goto IL_04e5;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA52F0");
				object obj8 = default(object);
				if (obj8 == null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rbx_v4 (ArcadeSprite)+F8]");
					if ((nint)0 == 6)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rbx_v4 (ArcadeSprite)+131]");
						if (0 == (nint)obj8)
						{
							float2 position = arcadeSprite2.position;
							float2 position2 = arcadeSprite2.position;
							if (_spiritGemProjectilePool == null)
							{
								goto IL_04e5;
							}
							float2 pos = default(float2);
							projectile = _spiritGemProjectilePool.SpawnAt(pos, this);
							if ((object)projectile != null)
							{
								nint num8 = (nint)projectile;
								nint num9 = (nint)typeof(TP_SpiritGem_Projectile);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v684 @ rdx_v17 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_SpiritGem_Projectile>)+130]");
								object obj9 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v683 @ r8_v15 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
								nint num10 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v684 @ rdx_v17 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_SpiritGem_Projectile>)+130]");
								if (num10 >= 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v683 @ r8_v15 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
									object obj10 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v740 @ rax_v49+FFFFFFF8+v685 @ rax_v45*8]");
									if (0 == (nint)typeof(TP_SpiritGem_Projectile))
									{
										obj7 = 1;
										goto IL_05e2;
									}
								}
								obj7 = 0;
								goto IL_05e2;
							}
							goto IL_0604;
						}
					}
				}
			}
		}
		goto IL_05b5;
	}

	public void SpawnGemExplosion()
	{
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		float2 position2 = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		float2 pos = default(float2);
		Projectile projectile = _gemExplosionProjectilePool.SpawnAt(pos, this);
	}

	protected bool OnGemOverlapsPlayer(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_0374: Expected I4, but got O
		//IL_011f: Expected I, but got O
		//IL_012d: Expected I, but got O
		//IL_013d: Expected O, but got I
		//IL_01bd: Expected O, but got I4
		//IL_0179: Expected O, but got I
		//IL_01af: Expected O, but got I4
		//IL_028d: Expected I, but got O
		//IL_0295: Expected I, but got O
		//IL_02a5: Expected O, but got I
		//IL_0325: Expected O, but got I4
		//IL_02e1: Expected O, but got I
		//IL_0317: Expected O, but got I4
		VampireSurvivors.Objects.Characters.CharacterController component;
		Projectile component2;
		Projectile projectile;
		Projectile projectile2;
		object obj3;
		if (first != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				component = gameObject.GetComponent<VampireSurvivors.Objects.Characters.CharacterController>();
				if ((object)component != null)
				{
					if (component._isDead || component.IsDisconnectedFromOnlinePlay)
					{
						goto IL_0358;
					}
					if (second != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						GameObject gameObject2 = default(GameObject);
						if ((object)gameObject2 != null)
						{
							component2 = gameObject2.GetComponent<Projectile>();
							if ((object)component2 == null)
							{
								projectile = null;
								projectile2 = null;
								goto IL_03c3;
							}
							nint num = (nint)component2;
							nint num2 = (nint)typeof(TP_SpiritGem_Projectile);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v349 @ rdx_v14 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_SpiritGem_Projectile>)+130]");
							object obj = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v348 @ r9_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
							nint num3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v349 @ rdx_v14 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_SpiritGem_Projectile>)+130]");
							if (num3 >= 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v348 @ r9_v6 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
								object obj2 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v405 @ rax_v50+FFFFFFF8+v350 @ rax_v46*8]");
								if (0 == (nint)typeof(TP_SpiritGem_Projectile))
								{
									obj3 = 1;
									goto IL_0396;
								}
							}
							obj3 = 0;
							goto IL_0396;
						}
					}
				}
			}
		}
		goto IL_0366;
		IL_0366:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_03c3:
		if ((object)projectile == null || ((UnityEngine.Object)projectile).m_CachedPtr == (IntPtr)0)
		{
			goto IL_0358;
		}
		float2 position = component.position;
		float2 position2 = component.position;
		if (_gemExplosionProjectilePool == null)
		{
			goto IL_0366;
		}
		float2 pos = default(float2);
		Projectile projectile3 = _gemExplosionProjectilePool.SpawnAt(pos, this);
		object obj6;
		if ((object)projectile3 != null)
		{
			nint num4 = (nint)typeof(TP_SpiritGem_Explosion_Projectile);
			nint num5 = (nint)projectile3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v536 @ rdx_v13 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_SpiritGem_Explosion_Projectile>)+130]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v537 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v536 @ rdx_v13 (Il2CppClass<VampireSurvivors.Objects.Projectiles.TP_SpiritGem_Explosion_Projectile>)+130]");
			if (num6 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v537 @ r8_v9 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+C8]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v591 @ rax_v38+FFFFFFF8+v538 @ rax_v34*8]");
				if (0 == (nint)typeof(TP_SpiritGem_Explosion_Projectile))
				{
					obj6 = 1;
					goto IL_03e5;
				}
			}
			obj6 = 0;
			goto IL_03e5;
		}
		goto IL_0402;
		IL_0358:
		return false;
		IL_03e5:
		if (obj6 != null)
		{
			projectile2 = projectile3;
		}
		goto IL_0402;
		IL_0402:
		if ((object)projectile2 != null)
		{
		}
		projectile.Despawn();
		return true;
		IL_0396:
		bool flag = obj3 == null;
		projectile = null;
		projectile2 = null;
		if (!flag)
		{
			projectile = component2;
			projectile2 = null;
		}
		goto IL_03c3;
	}

	public override void Cleanup()
	{
		_invisibleProjectilePool.Cleanup();
		_gemExplosionProjectilePool.Cleanup();
		_spiritGemProjectilePool.Cleanup();
		if (pickupsResetTimer != null)
		{
			pickupsResetTimer.Cancel();
		}
		base.Cleanup();
	}

	public TP_SpiritTornado_Weapon()
	{
		List<Pickup> list = new List<Pickup>();
		itemsPickedUp = list;
		base._002Ector();
	}

	private void _003COnStart_003Eb__12_0()
	{
		canPickupItems = true;
	}
}
