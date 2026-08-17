using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class EnemyWeapon
{
	public EnemyProjectile _projectilePrefab;

	private EnemyBulletPool _projectilePool;

	public unsafe EnemyWeapon(EnemyProjectile projectilePrefab)
	{
		//IL_0476: Expected I, but got O
		//IL_04bb: Expected I, but got O
		//IL_0099: Expected I, but got O
		//IL_00f0: Expected I, but got O
		//IL_0127: Expected I, but got O
		//IL_0169: Expected I, but got O
		//IL_01f4: Expected I, but got O
		//IL_0222: Expected O, but got I
		//IL_0275: Expected I, but got O
		//IL_0285: Expected O, but got I
		//IL_0295: Expected O, but got I
		//IL_0330: Expected I, but got O
		//IL_0376: Expected I, but got O
		//IL_03b5: Expected I, but got O
		//IL_03e9: Expected O, but got Ref
		//IL_05ae: Expected I, but got O
		_projectilePrefab = projectilePrefab;
		EnemyBulletPool projectilePool = new EnemyBulletPool(_projectilePrefab);
		_projectilePool = projectilePool;
		nint num = (nint)typeof(ArcadePhysics);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ rax_v7 (Il2CppClass<ArcadePhysics>)+B8]");
		nint num2 = 0;
		PhaserScene s_scene = ArcadePhysics.s_scene;
		if (ArcadePhysics.s_scene != null)
		{
			ArcadePhysics physics = s_scene.physics;
			if ((object)s_scene.physics != null)
			{
				nint num3 = (nint)typeof(PhysicsManager);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v614 @ rax_v16 (Il2CppClass<VampireSurvivors.Framework.PhysicsManager>)+B8]");
				nint num4 = 0;
				PhysicsManager sInstance = PhysicsManager._sInstance;
				bool flag = PhysicsManager._sInstance == null;
				num2 = num4;
				if (!flag)
				{
					ArcadePhysicsCallback arcadePhysicsCallback = OnPlayerOverlapsEnemyBullet;
					bool flag2 = physics.add == null;
					num2 = (nint)arcadePhysicsCallback;
					if (!flag2)
					{
						ArcadePhysicsCallback arcadePhysicsCallback2 = default(ArcadePhysicsCallback);
						CallbackContext callbackContext = default(CallbackContext);
						Collider collider = physics.add.overlap(sInstance._playerGroup, _projectilePool, arcadePhysicsCallback, arcadePhysicsCallback2, callbackContext);
						bool flag3 = collider == null;
						num2 = (nint)physics.add;
						if (!flag3)
						{
							Collider collider2 = collider.setName("Player>EnemyBullets");
							bool flag4 = (object)projectilePrefab == null;
							num2 = (nint)collider;
							if (!flag4)
							{
								if (!projectilePrefab.ShouldHitWalls())
								{
									return;
								}
								nint num5 = (nint)typeof(GM);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v724 @ rax_v26 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
								nint num6 = 0;
								GameManager core = GM.Core;
								bool flag5 = (object)GM.Core == null;
								num2 = num6;
								if (!flag5)
								{
									Stage stage = core._stage;
									if ((object)core._stage == null || ((UnityEngine.Object)stage).m_CachedPtr == (IntPtr)0)
									{
										return;
									}
									num2 = (nint)GM.Core;
									if ((object)GM.Core != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v358 @ rcx_v36 (Il2CppStaticFields<ArcadePhysics>)+B8]");
										object obj = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v358 @ rcx_v36 (Il2CppStaticFields<ArcadePhysics>)+B8]");
										if ((nint)0 != 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v338 @ rax_v34+88]");
											if ((nint)0 == 0)
											{
												return;
											}
											num2 = (nint)GM.Core;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v358 @ rcx_v36 (Il2CppStaticFields<ArcadePhysics>)+B8]");
											object obj2 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ rax_v36+208]");
											object obj3 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ rax_v36+208]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184FED160");
												object obj4 = default(object);
												if (obj4 != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v340 @ rax_v37+18]");
													if ((nint)0 != 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185004430");
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v842 @ r8_v10 (Il2CppClass<VampireSurvivors.Objects.Weapons.EnemyWeapon>)+180]");
														ArcadePhysicsCallback arcadePhysicsCallback3 = new ArcadePhysicsCallback(this, (IntPtr)0);
														nint num7 = (nint)this;
														World world = default(World);
														ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
														CallbackContext callbackContext2 = default(CallbackContext);
														TilemapSetCollider tilemapSetCollider = new TilemapSetCollider(world, overlapOnly: false, _projectilePool, (ArcadeColliderType)(object)arcadePhysicsCallback2, (ArcadePhysicsCallback)(object)callbackContext, processCallback, callbackContext2);
														bool flag6 = tilemapSetCollider == null;
														num2 = (nint)tilemapSetCollider;
														if (!flag6)
														{
															Collider collider3 = tilemapSetCollider.setName("Projectiles>Tilemap");
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ r15_v6+60]");
															bool flag7 = (nint)0 == 0;
															num2 = (nint)tilemapSetCollider;
															if (!flag7)
															{
																PhaserTilemap phaserTilemap = null;
																ArcadeColliderType projectilePool2 = _projectilePool;
																List<PhaserTilemap>.Enumerator enumerator = default(List<PhaserTilemap>.Enumerator);
																if (enumerator.MoveNext())
																{
																	PhaserTilemap phaserTilemap2 = null;
																	List<PhaserTilemap>.Enumerator enumerator2 = (List<PhaserTilemap>.Enumerator)(&enumerator);
																	throw new NullReferenceException();
																}
																num2 = (nint)ArcadePhysics.s_scene;
																if (ArcadePhysics.s_scene != null && ArcadePhysics.s_world != null)
																{
																	World s_world = ArcadePhysics.s_world;
																	if (ArcadePhysics.s_world != null && s_world._colliders != null)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B4520");
																		return;
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public void Fire(float2 position)
	{
		bool includeFollowers = default(bool);
		VampireSurvivors.Objects.Characters.CharacterController closestPlayer = GM.Core.GetClosestPlayer(position, PlayerInclusionMode.AlivePreferred, 3.4028235E+38f, includeFollowers);
		float2 position2 = closestPlayer.position;
		object obj2 = default(object);
		object obj3 = default(object);
		object obj = obj2 - obj3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185015910");
		float2 direction = default(float2);
		EnemyProjectile enemyProjectile = _projectilePool.SpawnAt(position, direction);
		if ((object)enemyProjectile != null && ((UnityEngine.Object)enemyProjectile).m_CachedPtr != (IntPtr)0)
		{
			BaseBody body = enemyProjectile.body;
			if (enemyProjectile.body != null)
			{
				body._transform.ForceFullReupdate();
			}
		}
	}

	private bool OnPlayerOverlapsEnemyBullet(CallbackContext context, ArcadeColliderType first, ArcadeColliderType second)
	{
		//IL_0022: Expected I, but got O
		//IL_002a: Expected I, but got O
		//IL_003a: Expected O, but got I
		//IL_00ba: Expected O, but got I4
		//IL_0076: Expected O, but got I
		//IL_01ce: Expected I4, but got O
		//IL_00ac: Expected O, but got I4
		//IL_00df: Expected I, but got O
		//IL_00e7: Expected I, but got O
		//IL_00f7: Expected O, but got I
		//IL_0133: Expected O, but got I
		//IL_0170: Expected O, but got I
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected O, but got Unknown
		//IL_023a: Expected I, but got O
		ArcadeColliderType arcadeColliderType2;
		ArcadeColliderType arcadeColliderType;
		if (first == null)
		{
			arcadeColliderType = null;
			arcadeColliderType2 = null;
			goto IL_01ee;
		}
		nint num = (nint)typeof(VampireSurvivors.Objects.Characters.CharacterController);
		nint num2 = (nint)first;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ r8_v7 (Il2CppClass<ArcadeColliderType>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ r8_v7 (Il2CppClass<ArcadeColliderType>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v16+FFFFFFF8+v51 @ rax_v12*8]");
			if (0 == (nint)typeof(VampireSurvivors.Objects.Characters.CharacterController))
			{
				obj3 = 1;
				goto IL_020b;
			}
		}
		obj3 = 0;
		goto IL_020b;
		IL_020b:
		bool flag = obj3 == null;
		arcadeColliderType = null;
		arcadeColliderType2 = null;
		if (!flag)
		{
			arcadeColliderType = first;
			arcadeColliderType2 = null;
		}
		goto IL_01ee;
		IL_01ee:
		if (second != null)
		{
			nint num4 = (nint)typeof(EnemyProjectile);
			nint num5 = (nint)second;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ r10_v2 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EnemyProjectile>)+130]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ r8_v3 (Il2CppClass<ArcadeColliderType>)+130]");
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ r10_v2 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EnemyProjectile>)+130]");
			if (num6 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ r8_v3 (Il2CppClass<ArcadeColliderType>)+C8]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rax_v6+FFFFFFF8+v135 @ rax_v5*8]");
				if (0 == (nint)typeof(EnemyProjectile))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ r10_v2 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EnemyProjectile>)+130]");
					object obj6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rax_v6+FFFFFFF8+v189 @ r8_v4*8]");
					object obj7 = 0 - typeof(EnemyProjectile);
					if (obj7 == null)
					{
						arcadeColliderType2 = second;
					}
					nint num7 = (nint)arcadeColliderType2;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v236 @ rax_v8 (Il2CppClass<ArcadeColliderType>)+288] (should have been resolved before IL gen)");
					return false;
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	protected virtual bool OnBulletOverlapsWall(CallbackContext context, ArcadeColliderType bullet, ArcadeColliderType tile)
	{
		//IL_0013: Expected I, but got O
		//IL_001b: Expected I, but got O
		//IL_002b: Expected O, but got I
		//IL_0067: Expected O, but got I
		//IL_00a2: Expected I, but got O
		//IL_00d4: Expected I, but got O
		//IL_00e4: Expected O, but got I
		//IL_01ed: Expected I4, but got O
		//IL_0120: Expected O, but got I
		//IL_015d: Expected I, but got O
		//IL_016d: Expected O, but got I
		//IL_017d: Expected O, but got I
		//IL_01c1: Expected O, but got I4
		//IL_01b3: Expected O, but got I4
		//IL_0217: Expected I, but got O
		nint num = (nint)typeof(EnemyProjectile);
		nint num2 = (nint)bullet;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rdx_v4 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EnemyProjectile>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ r8_v3 (Il2CppClass<ArcadeColliderType>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rdx_v4 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EnemyProjectile>)+130]");
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ r8_v3 (Il2CppClass<ArcadeColliderType>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rax_v7+FFFFFFF8+v48 @ rax_v6*8]");
			if (0 == (nint)typeof(EnemyProjectile))
			{
				nint num4 = (nint)typeof(PhaserTile);
				if (tile == null)
				{
					ArcadeColliderType arcadeColliderType = null;
					goto IL_0155;
				}
				nint num5 = (nint)tile;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ r8_v4 (Il2CppClass<PhaserTile>)+130]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ r10_v3 (Il2CppClass<ArcadeColliderType>)+130]");
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ r8_v4 (Il2CppClass<PhaserTile>)+130]");
				if (num6 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ r10_v3 (Il2CppClass<ArcadeColliderType>)+C8]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rax_v18+FFFFFFF8+v110 @ rax_v17*8]");
					bool flag = 0 != (nint)typeof(PhaserTile);
					ArcadeColliderType arcadeColliderType = tile;
					if (!flag)
					{
						goto IL_0155;
					}
				}
				InvalidCastException ex = new InvalidCastException();
				return (byte)(int)ex != 0;
			}
		}
		throw new NullReferenceException();
		IL_0155:
		nint num7 = (nint)bullet;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rdx_v4 (Il2CppClass<VampireSurvivors.Objects.Projectiles.EnemyProjectile>)+130]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rax_v9 (Il2CppClass<ArcadeColliderType>)+C8]");
		object obj6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rax_v10+FFFFFFF8+v168 @ rcx_v7*8]");
		object obj7 = ((0 != (nint)typeof(EnemyProjectile)) ? ((object)0) : ((object)1));
		bool flag2 = obj7 == null;
		ArcadeColliderType arcadeColliderType2 = null;
		if (!flag2)
		{
			arcadeColliderType2 = bullet;
		}
		nint num8 = (nint)arcadeColliderType2;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v221 @ rax_v12 (Il2CppClass<ArcadeColliderType>)+298] (should have been resolved before IL gen)");
		return false;
	}
}
