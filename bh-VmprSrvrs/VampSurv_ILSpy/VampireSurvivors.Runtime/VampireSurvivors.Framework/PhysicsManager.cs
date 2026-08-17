using System;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Projectiles;
using Zenject;

namespace VampireSurvivors.Framework;

public class PhysicsManager : IInitializable, IDisposable
{
	public PhysicsGroup _playerGroup;

	public PhysicsGroup _playersWithWallCollisionGroup;

	public PhysicsGroup _enemyGroup;

	public PhysicsGroup _bulletGroup;

	public PhysicsGroup _pickupGroup;

	public PhysicsGroup _goToPlayerPickupGroup;

	public PhysicsGroup _destructiblesGroup;

	public PhysicsGroup _magnetGroup;

	public PhysicsGroup _doorGroup;

	private static PhysicsManager _sInstance;

	private GameManager _gameManager;

	private ItemType[] _goldItems = new ItemType[3]
	{
		ItemType.COIN,
		ItemType.COINBAG1,
		ItemType.COINBAGMAX
	};

	public bool PickupImmaterial;

	public static PhysicsManager Instance => _sInstance;

	public void Initialize()
	{
		_sInstance = this;
	}

	public void Dispose()
	{
		_sInstance = null;
	}

	public void InitPhysicsGroups(GameManager gameManager)
	{
		_gameManager = gameManager;
		GameManager gameManager2 = _gameManager;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		Factory add = s_scene.add;
		PhysicsGroup physicsGroup = (PhysicsGroup)new Group(600);
		((Group)physicsGroup)._002Ector(600);
		physicsGroup._physicsType = PhysicsType.DYNAMIC_BODY;
		RBush rBush = add._world.addGroupTree(physicsGroup);
		gameManager2.Enemies = physicsGroup;
		GameManager gameManager3 = _gameManager;
		PhysicsGroup enemies = gameManager3.Enemies;
		enemies._physicsType = PhysicsType.DYNAMIC_BODY;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		Factory add2 = s_scene2.add;
		PhysicsGroup physicsGroup2 = (PhysicsGroup)new Group(10);
		((Group)physicsGroup2)._002Ector(10);
		physicsGroup2._physicsType = PhysicsType.DYNAMIC_BODY;
		RBush rBush2 = add2._world.addGroupTree(physicsGroup2);
		_playerGroup = physicsGroup2;
		PhysicsGroup playerGroup = _playerGroup;
		playerGroup._physicsType = PhysicsType.DYNAMIC_BODY;
		PhaserScene s_scene3 = ArcadePhysics.s_scene;
		if (s_scene3.add != null)
		{
			PhysicsGroup physicsGroup3 = (PhysicsGroup)new Group(4);
			((Group)physicsGroup3)._002Ector(4);
			physicsGroup3._physicsType = PhysicsType.DYNAMIC_BODY;
			_playersWithWallCollisionGroup = physicsGroup3;
			PhysicsGroup playersWithWallCollisionGroup = _playersWithWallCollisionGroup;
			playersWithWallCollisionGroup._physicsType = PhysicsType.DYNAMIC_BODY;
			ArcadePhysics.s_world.addSubsetGroupTree(_playersWithWallCollisionGroup, _playerGroup);
			PhaserScene s_scene4 = ArcadePhysics.s_scene;
			if (s_scene4.add != null)
			{
				PhysicsGroup physicsGroup4 = (PhysicsGroup)new Group(600);
				((Group)physicsGroup4)._002Ector(600);
				physicsGroup4._physicsType = PhysicsType.DYNAMIC_BODY;
				_enemyGroup = physicsGroup4;
				PhysicsGroup enemyGroup = _enemyGroup;
				enemyGroup._physicsType = PhysicsType.DYNAMIC_BODY;
				GameManager gameManager4 = _gameManager;
				ArcadePhysics.s_world.addSubsetGroupTree(_enemyGroup, gameManager4.Enemies);
				GameManager gameManager5 = _gameManager;
				PhaserScene s_scene5 = ArcadePhysics.s_scene;
				Factory add3 = s_scene5.add;
				PhysicsGroup physicsGroup5 = (PhysicsGroup)new Group(50);
				((Group)physicsGroup5)._002Ector(50);
				physicsGroup5._physicsType = PhysicsType.DYNAMIC_BODY;
				RBush rBush3 = add3._world.addGroupTree(physicsGroup5);
				gameManager5.EnemiesThatIgnoreProjectiles = physicsGroup5;
				GameManager gameManager6 = _gameManager;
				PhysicsGroup enemiesThatIgnoreProjectiles = gameManager6.EnemiesThatIgnoreProjectiles;
				enemiesThatIgnoreProjectiles._physicsType = PhysicsType.DYNAMIC_BODY;
				PhaserScene s_scene6 = ArcadePhysics.s_scene;
				Factory add4 = s_scene6.add;
				PhysicsGroup physicsGroup6 = (PhysicsGroup)new Group(10);
				((Group)physicsGroup6)._002Ector(10);
				physicsGroup6._physicsType = PhysicsType.DYNAMIC_BODY;
				RBush rBush4 = add4._world.addGroupTree(physicsGroup6);
				_bulletGroup = physicsGroup6;
				PhysicsGroup bulletGroup = _bulletGroup;
				bulletGroup._physicsType = PhysicsType.DYNAMIC_BODY;
				PhaserScene s_scene7 = ArcadePhysics.s_scene;
				Factory add5 = s_scene7.add;
				PhysicsGroup physicsGroup7 = (PhysicsGroup)new Group(600);
				((Group)physicsGroup7)._002Ector(600);
				physicsGroup7._physicsType = PhysicsType.DYNAMIC_BODY;
				RBush rBush5 = add5._world.addGroupTree(physicsGroup7);
				_pickupGroup = physicsGroup7;
				PhysicsGroup pickupGroup = _pickupGroup;
				pickupGroup._physicsType = PhysicsType.DYNAMIC_BODY;
				PhaserScene s_scene8 = ArcadePhysics.s_scene;
				Factory add6 = s_scene8.add;
				PhysicsGroup physicsGroup8 = (PhysicsGroup)new Group(600);
				((Group)physicsGroup8)._002Ector(600);
				physicsGroup8._physicsType = PhysicsType.DYNAMIC_BODY;
				RBush rBush6 = add6._world.addGroupTree(physicsGroup8);
				_goToPlayerPickupGroup = physicsGroup8;
				PhysicsGroup goToPlayerPickupGroup = _goToPlayerPickupGroup;
				goToPlayerPickupGroup._physicsType = PhysicsType.DYNAMIC_BODY;
				PhaserScene s_scene9 = ArcadePhysics.s_scene;
				Factory add7 = s_scene9.add;
				PhysicsGroup physicsGroup9 = (PhysicsGroup)new Group(10);
				((Group)physicsGroup9)._002Ector(10);
				physicsGroup9._physicsType = PhysicsType.DYNAMIC_BODY;
				RBush rBush7 = add7._world.addGroupTree(physicsGroup9);
				_destructiblesGroup = physicsGroup9;
				PhysicsGroup destructiblesGroup = _destructiblesGroup;
				destructiblesGroup._physicsType = PhysicsType.DYNAMIC_BODY;
				PhaserScene s_scene10 = ArcadePhysics.s_scene;
				Factory add8 = s_scene10.add;
				PhysicsGroup physicsGroup10 = (PhysicsGroup)new Group(10);
				((Group)physicsGroup10)._002Ector(10);
				physicsGroup10._physicsType = PhysicsType.DYNAMIC_BODY;
				RBush rBush8 = add8._world.addGroupTree(physicsGroup10);
				_magnetGroup = physicsGroup10;
				PhysicsGroup magnetGroup = _magnetGroup;
				magnetGroup._physicsType = PhysicsType.DYNAMIC_BODY;
				PhaserScene s_scene11 = ArcadePhysics.s_scene;
				Factory add9 = s_scene11.add;
				PhysicsGroup physicsGroup11 = (PhysicsGroup)new Group(10);
				((Group)physicsGroup11)._002Ector(10);
				physicsGroup11._physicsType = PhysicsType.DYNAMIC_BODY;
				RBush rBush9 = add9._world.addGroupTree(physicsGroup11);
				_doorGroup = physicsGroup11;
				PhysicsGroup doorGroup = _doorGroup;
				doorGroup._physicsType = PhysicsType.DYNAMIC_BODY;
				return;
			}
		}
		throw new NullReferenceException();
	}

	public void InitPhysicsColliders()
	{
		PhaserScene s_scene = ArcadePhysics.s_scene;
		ArcadePhysics physics = s_scene.physics;
		GameManager gameManager = _gameManager;
		ArcadePhysicsCallback collideCallback = OnPlayerOverlapsEnemy;
		ArcadePhysicsCallback arcadePhysicsCallback = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		Collider collider = physics.add.collider(_playerGroup, gameManager.Enemies, collideCallback, arcadePhysicsCallback, callbackContext);
		Collider collider2 = collider.setName("Player>Enemies");
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		ArcadePhysics physics2 = s_scene2.physics;
		GameManager gameManager2 = _gameManager;
		ArcadePhysicsCallback collideCallback2 = OnPlayerOverlapsEnemy;
		Collider collider3 = physics2.add.collider(_playerGroup, gameManager2.EnemiesThatIgnoreProjectiles, collideCallback2, arcadePhysicsCallback, callbackContext);
		Collider collider4 = collider3.setName("Player>EnemiesThatIgnoreProjectiles");
		PhaserScene s_scene3 = ArcadePhysics.s_scene;
		if ((object)s_scene3.physics != null)
		{
			ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
			CallbackContext callbackContext2 = default(CallbackContext);
			CircleSpecificCollider circleSpecificCollider = new CircleSpecificCollider(ArcadePhysics.s_world, overlapOnly: false, _enemyGroup, (ArcadeColliderType)(object)arcadePhysicsCallback, (ArcadePhysicsCallback)(object)callbackContext, processCallback, callbackContext2);
			Collider collider5 = circleSpecificCollider.setName("Enemies>Enemies");
			PhaserScene s_scene4 = ArcadePhysics.s_scene;
			if ((object)s_scene4.physics != null)
			{
				World s_world = ArcadePhysics.s_world;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B4520");
				PhaserScene s_scene5 = ArcadePhysics.s_scene;
				ArcadePhysics physics3 = s_scene5.physics;
				ArcadePhysicsCallback collideCallback3 = OnPlayerOverlapsPickup;
				Collider collider6 = physics3.add.overlap(_playerGroup, _pickupGroup, collideCallback3, arcadePhysicsCallback, callbackContext);
				Collider collider7 = collider6.setName("Player>Pickups");
				PhaserScene s_scene6 = ArcadePhysics.s_scene;
				ArcadePhysics physics4 = s_scene6.physics;
				ArcadePhysicsCallback collideCallback4 = OnPlayerOverlapsPickup;
				Collider collider8 = physics4.add.overlap(_playerGroup, _goToPlayerPickupGroup, collideCallback4, arcadePhysicsCallback, callbackContext);
				Collider collider9 = collider8.setName("Player>GoToPlayerPickups");
				PhaserScene s_scene7 = ArcadePhysics.s_scene;
				ArcadePhysics physics5 = s_scene7.physics;
				ArcadePhysicsCallback collideCallback5 = OnMagnetOverlapsPickup;
				Collider collider10 = physics5.add.overlap(_magnetGroup, _pickupGroup, collideCallback5, arcadePhysicsCallback, callbackContext);
				Collider collider11 = collider10.setName("Magnet>Pickups");
				return;
			}
		}
		throw new NullReferenceException();
	}

	public static void TakePickup(Pickup pickupItem, VampireSurvivors.Objects.Characters.CharacterController playerCharacter)
	{
		//IL_005e: Expected I, but got O
		//IL_0066: Expected I, but got O
		//IL_0076: Expected O, but got I
		//IL_00b2: Expected O, but got I
		//IL_00ef: Expected O, but got I
		pickupItem._targetPlayer = playerCharacter;
		GameManager core = GM.Core;
		if (core._multiplayer.IsOnlineMultiplayer)
		{
			nint num = (nint)typeof(NetworkPickup);
			nint num2 = (nint)pickupItem;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rdx_v6 (Il2CppClass<VampireSurvivors.NetworkPickup>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rdx_v6 (Il2CppClass<VampireSurvivors.NetworkPickup>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rax_v12+FFFFFFF8+v230 @ rax_v11*8]");
				if (0 == (nint)typeof(NetworkPickup))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [pickupItem @ rcx (VampireSurvivors.Objects.Pickups.Pickup)+148]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rax_v13+160]");
					if ((nint)0 > (nint)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v61 @ r8_v4 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+438] (should have been resolved before IL gen)");
						return;
					}
				}
			}
		}
		pickupItem.GetTaken();
	}

	private bool OnPlayerOverlapsEnemy(CallbackContext context, ArcadeColliderType first, ArcadeColliderType second)
	{
		//IL_0589: Expected I4, but got O
		//IL_0013: Expected I, but got O
		//IL_001b: Expected I, but got O
		//IL_002b: Expected O, but got I
		//IL_00ab: Expected O, but got I4
		//IL_0067: Expected O, but got I
		//IL_009d: Expected O, but got I4
		//IL_0160: Expected I, but got O
		//IL_0168: Expected I, but got O
		//IL_0178: Expected O, but got I
		//IL_01f8: Expected O, but got I4
		//IL_01b4: Expected O, but got I
		//IL_01ea: Expected O, but got I4
		//IL_055a: Expected I, but got O
		//IL_056c: Expected I, but got O
		//IL_0337: Expected O, but got I
		//IL_03e4: Expected O, but got I
		//IL_0419: Expected O, but got I
		if (second == null)
		{
			goto IL_057b;
		}
		nint num = (nint)typeof(EnemyController);
		nint num2 = (nint)second;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ r8_v2 (Il2CppClass<ArcadeColliderType>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Characters.EnemyController>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ r8_v2 (Il2CppClass<ArcadeColliderType>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rax_v45+FFFFFFF8+v55 @ rax_v4*8]");
			if (0 == (nint)typeof(EnemyController))
			{
				obj3 = 1;
				goto IL_05a6;
			}
		}
		obj3 = 0;
		goto IL_05a6;
		IL_05c8:
		return false;
		IL_05ce:
		object obj4;
		bool flag = obj4 == null;
		ArcadeColliderType arcadeColliderType = null;
		if (!flag)
		{
			arcadeColliderType = first;
		}
		ArcadeColliderType arcadeColliderType2;
		if (arcadeColliderType != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rdi_v6 (ArcadeColliderType)+134]");
			if ((nint)0 == 30)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rbx_v3 (ArcadeColliderType)+209]");
				if ((nint)0 != 0)
				{
					goto IL_05c8;
				}
			}
			GameManager gameManager = _gameManager;
			if ((object)_gameManager != null)
			{
				List<VampireSurvivors.Objects.Characters.CharacterController> characters = gameManager._characters;
				if (gameManager._characters != null)
				{
					if (characters._size > 1)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rdi_v6 (ArcadeColliderType)+289]");
						if ((nint)0 != 0 || ((VampireSurvivors.Objects.Characters.CharacterController)arcadeColliderType).IsDisconnectedFromOnlinePlay)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rbx_v3 (ArcadeColliderType)+B0]");
							object obj5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rbx_v3 (ArcadeColliderType)+B0]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rax_v17+58]");
								if ((nint)0 > (nint)0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rax_v17+18]");
									if ((nint)0 > (nint)0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rax_v17+A0]");
										if ((nint)0 == 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rbx_v3 (ArcadeColliderType)+98]");
											object obj6 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rbx_v3 (ArcadeColliderType)+98]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rax_v33+3B8]");
												object obj7 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rax_v33+3B8]");
												if ((nint)0 != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rbx_v3 (ArcadeColliderType)+1D8]");
													nint num4 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rax_v34+18]");
													if (num4 >= 0)
													{
														goto IL_04a1;
													}
													if (((VampireSurvivors.Objects.Characters.CharacterController)arcadeColliderType).TryGettingChomped())
													{
														((EnemyController)arcadeColliderType2).FeedOnPlayer();
													}
													goto IL_05c8;
												}
											}
											goto IL_057b;
										}
									}
								}
								goto IL_04a1;
							}
							goto IL_057b;
						}
					}
					float attackPower = ((EnemyController)arcadeColliderType2).AttackPower;
					nint num5 = (nint)arcadeColliderType;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v563 @ rax_v12 (Il2CppClass<ArcadeColliderType>)+5F8] (should have been resolved before IL gen)");
					nint num6 = (nint)arcadeColliderType2;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v567 @ rax_v14 (Il2CppClass<ArcadeColliderType>)+3A8] (should have been resolved before IL gen)");
					goto IL_05c8;
				}
			}
		}
		goto IL_057b;
		IL_057b:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_04a1:
		float2 position = ((ArcadeSprite)arcadeColliderType2).position;
		if ((object)_gameManager == null)
		{
			goto IL_057b;
		}
		bool includeFollowers = default(bool);
		VampireSurvivors.Objects.Characters.CharacterController closestPlayer = _gameManager.GetClosestPlayer(position, PlayerInclusionMode.OnlyAlive, 3.4028235E+38f, includeFollowers);
		if ((object)closestPlayer != null && ((UnityEngine.Object)closestPlayer).m_CachedPtr != (IntPtr)0)
		{
			Transform transform = closestPlayer.transform;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180BA5BF0");
		}
		goto IL_05c8;
		IL_05a6:
		bool flag2 = obj3 == null;
		arcadeColliderType2 = null;
		if (!flag2)
		{
			arcadeColliderType2 = second;
		}
		if (arcadeColliderType2 == null)
		{
			goto IL_057b;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rbx_v3 (ArcadeColliderType)+260]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rbx_v3 (ArcadeColliderType)+245]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ rbx_v3 (ArcadeColliderType)+244]");
				if ((nint)0 == 0)
				{
					if (first == null)
					{
						goto IL_057b;
					}
					nint num7 = (nint)typeof(VampireSurvivors.Objects.Characters.CharacterController);
					nint num8 = (nint)first;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rdx_v4 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController>)+130]");
					object obj8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ r8_v4 (Il2CppClass<ArcadeColliderType>)+130]");
					nint num9 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rdx_v4 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController>)+130]");
					if (num9 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ r8_v4 (Il2CppClass<ArcadeColliderType>)+C8]");
						object obj9 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v441 @ rax_v41+FFFFFFF8+v427 @ rax_v8*8]");
						if (0 == (nint)typeof(VampireSurvivors.Objects.Characters.CharacterController))
						{
							obj4 = 1;
							goto IL_05ce;
						}
					}
					obj4 = 0;
					goto IL_05ce;
				}
			}
		}
		goto IL_05c8;
	}

	private bool OnPlayerOverlapsPickup(CallbackContext context, ArcadeColliderType player, ArcadeColliderType pickup)
	{
		//IL_0301: Expected I, but got O
		//IL_000d: Expected I, but got O
		//IL_001d: Expected O, but got I
		//IL_0314: Expected I4, but got O
		//IL_0059: Expected O, but got I
		//IL_0108: Expected I, but got O
		//IL_0110: Expected I, but got O
		//IL_0120: Expected O, but got I
		//IL_01a0: Expected O, but got I4
		//IL_015c: Expected O, but got I
		//IL_0192: Expected O, but got I4
		//IL_01fd: Expected I, but got O
		nint num = (nint)typeof(Pickup);
		nint num2 = (nint)pickup;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rdx_v1 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ r8_v3 (Il2CppClass<ArcadeColliderType>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rdx_v1 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
		object obj5;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ r8_v3 (Il2CppClass<ArcadeColliderType>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rax_v7+FFFFFFF8+v55 @ rax_v6*8]");
			if (0 == (nint)typeof(Pickup))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [pickup @ r9 (ArcadeColliderType)+120]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [pickup @ r9 (ArcadeColliderType)+140]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [pickup @ r9 (ArcadeColliderType)+A8]");
						if (player != null)
						{
							goto IL_02ed;
						}
					}
				}
				nint num4 = (nint)typeof(VampireSurvivors.Objects.Characters.CharacterController);
				nint num5 = (nint)player;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rdx_v5 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController>)+130]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ r8_v5 (Il2CppClass<ArcadeColliderType>)+130]");
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rdx_v5 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController>)+130]");
				if (num6 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ r8_v5 (Il2CppClass<ArcadeColliderType>)+C8]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v329 @ rax_v21+FFFFFFF8+v224 @ rax_v10*8]");
					if (0 == (nint)typeof(VampireSurvivors.Objects.Characters.CharacterController))
					{
						obj5 = 1;
						goto IL_0314;
					}
				}
				obj5 = 0;
				goto IL_0314;
			}
		}
		InvalidCastException ex = new InvalidCastException();
		return (byte)(int)ex != 0;
		IL_02db:
		ArcadeColliderType arcadeColliderType;
		TakePickup((Pickup)pickup, (VampireSurvivors.Objects.Characters.CharacterController)arcadeColliderType);
		goto IL_02ed;
		IL_0314:
		bool flag = obj5 == null;
		arcadeColliderType = null;
		if (!flag)
		{
			arcadeColliderType = player;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdi_v6 (ArcadeColliderType)+289]");
		if ((nint)0 == 0 && !((VampireSurvivors.Objects.Characters.CharacterController)arcadeColliderType).IsDisconnectedFromOnlinePlay)
		{
			nint num7 = (nint)arcadeColliderType;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v378 @ r8_v6 (Il2CppClass<ArcadeColliderType>)+778] (should have been resolved before IL gen)");
			object obj6 = default(object);
			if (obj6 != null)
			{
				if (!PickupImmaterial)
				{
					goto IL_02db;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [pickup @ r9 (ArcadeColliderType)+120]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [pickup @ r9 (ArcadeColliderType)+140]");
					if ((nint)0 == 0)
					{
						ArcadeSprite arcadeSprite = ((ArcadeSprite)pickup).setVisible(false);
						ItemType[] goldItems = _goldItems;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [pickup @ r9 (ArcadeColliderType)+F8]");
						if (Enumerable.Contains((IEnumerable<System.Int32Enum>)(object)goldItems, (System.Int32Enum)0))
						{
							goto IL_02db;
						}
					}
				}
			}
		}
		goto IL_02ed;
		IL_02ed:
		return false;
	}

	private bool OnMagnetOverlapsPickup(CallbackContext context, ArcadeColliderType magnet, ArcadeColliderType pickup)
	{
		//IL_06ed: Expected I, but got O
		//IL_0017: Expected I, but got O
		//IL_0027: Expected O, but got I
		//IL_0063: Expected O, but got I
		//IL_00a6: Expected I, but got O
		//IL_00c7: Expected I, but got O
		//IL_00d7: Expected O, but got I
		//IL_010f: Expected O, but got I
		//IL_0148: Expected O, but got I
		//IL_019f: Expected O, but got I
		//IL_01c6: Expected O, but got I
		//IL_0669: Expected I, but got O
		//IL_0503: Expected I, but got O
		//IL_050b: Expected I, but got O
		//IL_051b: Expected O, but got I
		//IL_059b: Expected O, but got I4
		//IL_0557: Expected O, but got I
		//IL_058d: Expected O, but got I4
		//IL_05b5: Expected I, but got O
		//IL_02db->IL070d: Incompatible stack heights: 9 vs 7
		//IL_02e0->IL02e0: Incompatible stack heights: 9 vs 6
		//IL_068b->IL0642: Incompatible stack heights: 10 vs 4
		//IL_03bc->IL070d: Incompatible stack heights: 10 vs 7
		//IL_03dc->IL070d: Incompatible stack heights: 10 vs 7
		//IL_07cd->IL0648: Incompatible stack heights: 10 vs 9
		//IL_05d7->IL0642: Incompatible stack heights: 10 vs 4
		//IL_0451->IL070d: Incompatible stack heights: 12 vs 7
		//IL_07b5->IL0642: Incompatible stack heights: 13 vs 4
		//IL_0493->IL070d: Incompatible stack heights: 13 vs 7
		//IL_0642->IL07a3: Incompatible stack heights: 12 vs 13
		nint num = (nint)typeof(Pickup);
		ArcadeColliderType arcadeColliderType;
		if (pickup == null)
		{
			arcadeColliderType = null;
			goto IL_0098;
		}
		nint num2 = (nint)pickup;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdx_v1 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ r8_v20 (Il2CppClass<ArcadeColliderType>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdx_v1 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ r8_v20 (Il2CppClass<ArcadeColliderType>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rax_v58+FFFFFFF8+v58 @ rax_v55*8]");
			bool flag = 0 != (nint)typeof(Pickup);
			arcadeColliderType = pickup;
			if (!flag)
			{
				goto IL_0098;
			}
		}
		throw new InvalidCastException();
		IL_07a3:
		GameManager gameManager;
		Vector2 pos;
		gameManager.SpawnPickupEffectsParticles(pos);
		goto IL_0642;
		IL_0648:
		bool flag2 = arcadeColliderType == null;
		nint num4 = (nint)arcadeColliderType;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v866 @ r8_v12 (Il2CppClass<ArcadeColliderType>)+358] (should have been resolved before IL gen)");
		object obj3 = default(object);
		if (obj3 == null)
		{
			goto IL_0642;
		}
		Transform transform = ((Component)arcadeColliderType).transform;
		bool flag3 = (object)transform == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rax_v30 (UnityEngine.Transform)+10]");
		bool flag4 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rax_v30 (UnityEngine.Transform)+10]");
		Transform.get_position_Injected((IntPtr)0, out Vector3 _);
		bool flag5 = (object)_gameManager == null;
		Vector2 vector = default(Vector2);
		pos = vector;
		gameManager = _gameManager;
		goto IL_07a3;
		IL_070d:
		GameManager core = GM.Core;
		bool flag6 = (object)GM.Core == null;
		bool flag7 = core._multiplayer == null;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			goto IL_0648;
		}
		bool flag8 = arcadeColliderType == null;
		nint num5 = (nint)typeof(NetworkPickup);
		nint num6 = (nint)arcadeColliderType;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v829 @ rdx_v21 (Il2CppClass<VampireSurvivors.NetworkPickup>)+130]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v830 @ r8_v15 (Il2CppClass<ArcadeColliderType>)+130]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v829 @ rdx_v21 (Il2CppClass<VampireSurvivors.NetworkPickup>)+130]");
		object obj6;
		if (num7 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v830 @ r8_v15 (Il2CppClass<ArcadeColliderType>)+C8]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v869 @ rax_v46+FFFFFFF8+v853 @ rax_v38*8]");
			if (0 == (nint)typeof(NetworkPickup))
			{
				obj6 = 1;
				goto IL_0730;
			}
		}
		obj6 = 0;
		goto IL_0730;
		IL_0642:
		return false;
		IL_0098:
		nint num8 = (nint)typeof(MagnetZone);
		bool flag9 = magnet == null;
		nint num9 = (nint)magnet;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rdx_v8 (Il2CppClass<VampireSurvivors.Objects.MagnetZone>)+130]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ r8_v6 (Il2CppClass<ArcadeColliderType>)+130]");
		nint num10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rdx_v8 (Il2CppClass<VampireSurvivors.Objects.MagnetZone>)+130]");
		bool flag10 = num10 < 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ r8_v6 (Il2CppClass<ArcadeColliderType>)+C8]");
		object obj8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rax_v13+FFFFFFF8+v130 @ rax_v12*8]");
		bool flag11 = 0 != (nint)typeof(MagnetZone);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [magnet @ r8 (ArcadeColliderType)+68]");
		VampireSurvivors.Objects.Characters.CharacterController characterController = (VampireSurvivors.Objects.Characters.CharacterController)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [magnet @ r8 (ArcadeColliderType)+68]");
		bool flag12 = (nint)0 == 0;
		if (!characterController._isDead)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [magnet @ r8 (ArcadeColliderType)+68]");
			if (!((VampireSurvivors.Objects.Characters.CharacterController)0).IsDisconnectedFromOnlinePlay)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [magnet @ r8 (ArcadeColliderType)+68]");
				if (((VampireSurvivors.Objects.Characters.CharacterController)0).DoesWantPickup((Pickup)arcadeColliderType))
				{
					GameManager core2 = GM.Core;
					bool flag13 = (object)GM.Core == null;
					bool flag14 = core2._multiplayer == null;
					if (core2._multiplayer.IsOnlineMultiplayer)
					{
						GameManager core3 = GM.Core;
						bool flag15 = (object)GM.Core == null;
						bool flag16 = core3._playerOptions == null;
						PlayerOptionsData config = core3._playerOptions.Config;
						bool flag17 = config == null;
						if (config._003CSelectedOnlineFreeRoam_003Ek__BackingField)
						{
							goto IL_070d;
						}
					}
					bool flag18 = arcadeColliderType == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rbx_v6 (ArcadeColliderType)+F8]");
					if ((nint)0 == 6)
					{
						GameManager gameManager2 = _gameManager;
						bool flag19 = (object)_gameManager == null;
						GameSessionData gameSessionData = gameManager2._gameSessionData;
						bool flag20 = gameManager2._gameSessionData == null;
						VampireSurvivors.Objects.Characters.CharacterController activeCharacter = gameSessionData._activeCharacter;
						bool flag21 = (object)gameSessionData._activeCharacter == null;
						if (!activeCharacter._isDead && !gameSessionData._activeCharacter.IsDisconnectedFromOnlinePlay)
						{
							GameManager gameManager3 = _gameManager;
							bool flag22 = (object)_gameManager == null;
							ArcanaManager arcanaManager = gameManager3._arcanaManager;
							bool flag23 = gameManager3._arcanaManager == null;
							if (!arcanaManager._003CPewPew_003Ek__BackingField)
							{
								GameSessionData gameSessionData2 = gameManager3._gameSessionData;
								bool flag24 = gameManager3._gameSessionData == null;
								characterController = gameSessionData2._activeCharacter;
							}
						}
					}
					goto IL_070d;
				}
			}
		}
		goto IL_0642;
		IL_0730:
		bool flag25 = obj6 == null;
		ArcadeColliderType arcadeColliderType2 = null;
		if (!flag25)
		{
			arcadeColliderType2 = arcadeColliderType;
		}
		if (arcadeColliderType2 == null)
		{
			goto IL_0648;
		}
		nint num11 = (nint)arcadeColliderType2;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v927 @ r8_v16 (Il2CppClass<ArcadeColliderType>)+428] (should have been resolved before IL gen)");
		object obj9 = default(object);
		if (obj9 == null)
		{
			goto IL_0642;
		}
		Transform transform2 = ((Component)arcadeColliderType).transform;
		bool flag26 = (object)transform2 == null;
		Vector3 position = transform2.position;
		bool flag27 = (object)_gameManager == null;
		pos = vector;
		gameManager = _gameManager;
		goto IL_07a3;
	}

	private bool OnBulletOverlapsDoor(CallbackContext context, ArcadeColliderType bullet, ArcadeColliderType door)
	{
		//IL_00a4: Expected I, but got O
		//IL_000d: Expected I, but got O
		//IL_001d: Expected O, but got I
		//IL_00b7: Expected I4, but got O
		//IL_0059: Expected O, but got I
		nint num = (nint)typeof(Projectile);
		nint num2 = (nint)bullet;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rdx_v1 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ r8_v2 (Il2CppClass<ArcadeColliderType>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ rdx_v1 (Il2CppClass<VampireSurvivors.Objects.Projectiles.Projectile>)+130]");
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ r8_v2 (Il2CppClass<ArcadeColliderType>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rax_v6+FFFFFFF8+v42 @ rax_v5*8]");
			if (0 == (nint)typeof(Projectile))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v41 @ r8_v2 (Il2CppClass<ArcadeColliderType>)+368] (should have been resolved before IL gen)");
				return false;
			}
		}
		InvalidCastException ex = new InvalidCastException();
		return (byte)(int)ex != 0;
	}
}
