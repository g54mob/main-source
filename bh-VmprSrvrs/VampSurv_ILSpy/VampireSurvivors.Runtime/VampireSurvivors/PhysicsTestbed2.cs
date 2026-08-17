using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Tilemaps;

namespace VampireSurvivors;

public class PhysicsTestbed2 : MonoBehaviour
{
	private GameObject _EnemyPrefab;

	private GameObject _ProjectilePrefab;

	protected bool _freeze = true;

	public PhysicsGroup Enemies;

	public PhysicsGroup Projectiles;

	public PhaserTilemap[] _tilemaps;

	private static PhysicsTestbed2 _sInstance;

	private List<ArcadeSprite> _spawned;

	private List<Vector2> _spawnedPositions;

	public static PhysicsTestbed2 Instance => _sInstance;

	private void Awake()
	{
		_sInstance = this;
	}

	private void Start()
	{
		PhaserScene s_scene = ArcadePhysics.s_scene;
		Factory add = s_scene.add;
		PhysicsGroup physicsGroup = (PhysicsGroup)new Group(10);
		((Group)physicsGroup)._002Ector(10);
		physicsGroup._physicsType = PhysicsType.DYNAMIC_BODY;
		RBush rBush = add._world.addGroupTree(physicsGroup);
		Enemies = physicsGroup;
		PhysicsGroup enemies = Enemies;
		enemies._physicsType = PhysicsType.DYNAMIC_BODY;
		PhaserScene s_scene2 = ArcadePhysics.s_scene;
		Factory add2 = s_scene2.add;
		PhysicsGroup physicsGroup2 = (PhysicsGroup)new Group(10);
		((Group)physicsGroup2)._002Ector(10);
		physicsGroup2._physicsType = PhysicsType.DYNAMIC_BODY;
		RBush rBush2 = add2._world.addGroupTree(physicsGroup2);
		Projectiles = physicsGroup2;
		PhysicsGroup projectiles = Projectiles;
		projectiles._physicsType = PhysicsType.DYNAMIC_BODY;
		SpawnEnemies();
		SpawnProjectiles();
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 363 Invalid \"Jump target not found in method: 0x1871F4C40\"");
		throw new NullReferenceException();
	}

	private unsafe void InitPhysics()
	{
		//IL_011a: Expected O, but got I4
		//IL_0123: Expected O, but got I4
		//IL_012c: Expected O, but got I4
		//IL_05b4: Expected I, but got O
		//IL_05ca: Expected O, but got Ref
		//IL_0267: Unknown result type (might be due to invalid IL or missing references)
		//IL_026c: Expected O, but got Unknown
		//IL_0295: Expected O, but got I4
		//IL_0528->IL0319: Incompatible stack heights: 1 vs 0
		//IL_057b->IL0319: Incompatible stack heights: 2 vs 0
		//IL_05f9->IL0319: Incompatible stack heights: 3 vs 0
		//IL_0211->IL0319: Incompatible stack heights: 3 vs 0
		//IL_0628->IL0319: Incompatible stack heights: 3 vs 0
		//IL_0245->IL0319: Incompatible stack heights: 3 vs 0
		//IL_0286->IL0319: Incompatible stack heights: 3 vs 0
		//IL_02a2->IL062d: Incompatible stack heights: 3 vs 0
		PhaserScene s_scene = ArcadePhysics.s_scene;
		if (ArcadePhysics.s_scene != null && (object)s_scene.physics != null)
		{
			ArcadeColliderType @object = default(ArcadeColliderType);
			ArcadePhysicsCallback collideCallback = default(ArcadePhysicsCallback);
			ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
			CallbackContext callbackContext = default(CallbackContext);
			CircleSpecificCollider circleSpecificCollider = new CircleSpecificCollider(ArcadePhysics.s_world, overlapOnly: false, Enemies, @object, collideCallback, processCallback, callbackContext);
			if (circleSpecificCollider != null)
			{
				Collider collider = circleSpecificCollider.setName("Enemies>Enemies");
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				if (ArcadePhysics.s_scene != null && (object)s_scene2.physics != null)
				{
					ArcadeColliderType s_world = (ArcadeColliderType)ArcadePhysics.s_world;
					if (ArcadePhysics.s_world != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rbx_v9 (ArcadeColliderType)+50]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B4520");
							PhaserScene s_scene3 = ArcadePhysics.s_scene;
							if (ArcadePhysics.s_scene != null && (object)s_scene3.physics != null)
							{
								TilemapSetCollider tilemapSetCollider = new TilemapSetCollider(ArcadePhysics.s_world, overlapOnly: false, Enemies, @object, collideCallback, processCallback, callbackContext);
								if (tilemapSetCollider != null)
								{
									Collider collider2 = tilemapSetCollider.setName("Enemies>Tilemap");
									PhaserScene s_scene4 = ArcadePhysics.s_scene;
									if (ArcadePhysics.s_scene != null && (object)s_scene4.physics != null)
									{
										TilemapSetCollider tilemapSetCollider2 = new TilemapSetCollider(ArcadePhysics.s_world, overlapOnly: false, Projectiles, @object, collideCallback, processCallback, callbackContext);
										if (tilemapSetCollider2 != null)
										{
											Collider collider3 = tilemapSetCollider2.setName("Projectiles>Tilemap");
											PhaserTilemap[] tilemaps = _tilemaps;
											bool flag = _tilemaps == null;
											object obj = 0;
											object obj2 = 0;
											object obj3 = 0;
											if (!flag)
											{
												Vector3 position = default(Vector3);
												while (true)
												{
													if ((nint)obj3 < tilemaps.Length)
													{
														PhaserTilemap[] tilemaps2 = _tilemaps;
														if (_tilemaps == null)
														{
															break;
														}
														PhaserTilemap phaserTilemap = tilemaps2[obj2];
														if ((object)tilemaps2[obj2] == null)
														{
															break;
														}
														object layer = phaserTilemap._layer;
														if ((object)phaserTilemap._layer == null)
														{
															break;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rbx_v16 (System.Object)+10]");
														bool flag2 = (nint)0 == 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rbx_v16 (System.Object)+10]");
														IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
														Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
														ArcadeColliderType layer2 = (ArcadeColliderType)(object)phaserTilemap._layer;
														if ((object)phaserTilemap._layer == null)
														{
															break;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rbx_v17 (ArcadeColliderType)+10]");
														bool flag3 = (nint)0 == 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rbx_v17 (ArcadeColliderType)+10]");
														Tilemap.get_localBounds_Injected((IntPtr)0, out Bounds ret);
														if ((object)transform == null)
														{
															break;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
														bool flag4 = ((Collider)(object)transform)._name == null;
														Transform.TransformPoint_Injected((IntPtr)((Collider)(object)transform)._name, ref position, out Vector3 _);
														tilemaps2[obj2].UpdateTilemapBounds((Bounds)(&ret));
														TilemapSetCollider.TilemapSet[] tilemapSets = tilemapSetCollider._tilemapSets;
														if (tilemapSetCollider._tilemapSets == null)
														{
															break;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v291 @ rcx_v73 (TilemapSet[])+20+v226 @ rbp_v10*8]");
														if ((nint)0 == 0)
														{
															break;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B44C0");
														TilemapSetCollider.TilemapSet[] tilemapSets2 = tilemapSetCollider2._tilemapSets;
														if (tilemapSetCollider2._tilemapSets == null)
														{
															break;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v292 @ rcx_v76 (TilemapSet[])+20+v226 @ rbp_v10*8]");
														if ((nint)0 == 0)
														{
															break;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B44C0");
														tilemaps = _tilemaps;
														obj2++;
														if (_tilemaps == null)
														{
															break;
														}
														obj = 0;
														obj3 = obj2;
														continue;
													}
													PhaserScene s_scene5 = ArcadePhysics.s_scene;
													if (ArcadePhysics.s_scene == null || (object)s_scene5.physics == null)
													{
														break;
													}
													ArcadeColliderType s_world2 = (ArcadeColliderType)ArcadePhysics.s_world;
													if (ArcadePhysics.s_world == null)
													{
														break;
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rbx_v13 (ArcadeColliderType)+50]");
													if ((nint)0 == 0)
													{
														break;
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809B4520");
													PhaserScene s_scene6 = ArcadePhysics.s_scene;
													if (ArcadePhysics.s_scene == null || (object)s_scene6.physics == null)
													{
														break;
													}
													ArcadeColliderType s_world3 = (ArcadeColliderType)ArcadePhysics.s_world;
													if (ArcadePhysics.s_world == null)
													{
														break;
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rbx_v14 (ArcadeColliderType)+50]");
													if ((nint)0 == 0)
													{
														break;
													}
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
		throw new NullReferenceException();
	}

	private unsafe void SpawnEnemies()
	{
		//IL_0485: Expected O, but got I4
		//IL_048e: Expected O, but got I4
		//IL_04b2: Expected O, but got I
		//IL_033f: Expected O, but got I
		//IL_003a: Expected O, but got I8
		//IL_0074: Expected O, but got I8
		//IL_00c4: Expected O, but got Ref
		//IL_00c4: Expected O, but got Ref
		//IL_0230: Expected O, but got I
		//IL_02cb: Expected O, but got I
		//IL_0290: Expected O, but got I
		//IL_0447: Unknown result type (might be due to invalid IL or missing references)
		//IL_044c: Expected O, but got Unknown
		//IL_003f->IL0325: Incompatible stack heights: 1 vs 0
		//IL_0079->IL0493: Incompatible stack heights: 1 vs 0
		//IL_0121->IL0319: Incompatible stack heights: 1 vs 0
		//IL_0170->IL0319: Incompatible stack heights: 1 vs 0
		//IL_03e4->IL0319: Incompatible stack heights: 2 vs 0
		//IL_0439->IL0319: Incompatible stack heights: 3 vs 0
		//IL_0250->IL0319: Incompatible stack heights: 3 vs 0
		//IL_02b5->IL043e: Incompatible stack heights: 3 vs 4
		//IL_046d->IL04a2: Incompatible stack heights: 4 vs 0
		UnityEngine.Random.InitState(10);
		object obj = 0;
		List<Vector2> list = (List<Vector2>)10;
		IntPtr intPtr = default(IntPtr);
		Quaternion identityQuaternion = default(Quaternion);
		object obj5 = default(object);
		IntPtr intPtr2 = default(IntPtr);
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				bool flag = obj2 == null;
				list = (List<Vector2>)6573110936L;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v297 @ rax_v11 (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				bool flag2 = obj3 == null;
				list = (List<Vector2>)6573110936L;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v340 @ rax_v14 (should have been resolved before IL gen)");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v509 @ rbx_v4 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
			}
			UnityEngine.Object obj4 = UnityEngine.Object.Instantiate((UnityEngine.Object)_EnemyPrefab, (Vector3)(&intPtr), (Quaternion)(&identityQuaternion));
			if ((object)obj4 == null)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			bool flag3 = obj5 == null;
			List<object> spawned = (List<object>)(object)_spawned;
			ArcadeSprite component = ((GameObject)obj5).GetComponent<ArcadeSprite>();
			if (_spawned == null)
			{
				break;
			}
			int version = spawned._version + 1;
			spawned._version = version;
			object[] items = spawned._items;
			if (spawned._items == null)
			{
				break;
			}
			if (spawned._size >= items.Length)
			{
				((List<object>)(object)_spawned).AddWithResize((object)component);
			}
			else
			{
				int size = spawned._size + 1;
				spawned._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			List<Vector2> spawnedPositions = _spawnedPositions;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v685 @ rax_v25 (System.Object)+10]");
			bool flag4 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v685 @ rax_v25 (System.Object)+10]");
			IntPtr gcHandlePtr = GameObject.get_transform_Injected((IntPtr)0);
			Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
			if ((object)transform == null)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v696 @ rax_v33 (UnityEngine.Transform)+10]");
			bool flag5 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v696 @ rax_v33 (UnityEngine.Transform)+10]");
			IntPtr ret;
			Transform.get_position_Injected((IntPtr)0, out *(Vector3*)(&ret));
			if (_spawnedPositions == null)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rbx_v9 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rbx_v9 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rbx_v9 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			list = (List<Vector2>)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rbx_v9 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
			if ((nint)0 == 0)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rbx_v9 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rdx_v5 (Il2CppMethodInfo)+18]");
			if (num3 >= 0)
			{
				_spawnedPositions.AddWithResize((Vector2)(nint)intPtr2);
				num2 = intPtr2;
				nint num4 = 0;
				IntPtr intPtr3 = intPtr2;
				list = _spawnedPositions;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rbx_v9 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
				object obj6 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rbx_v9 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rdx_v5 (Il2CppMethodInfo)+18]");
				bool flag6 = num5 >= 0;
				nint num4 = 0;
				IntPtr intPtr3 = ret;
			}
			obj++;
			bool flag7 = (nint)obj < 500;
			identityQuaternion = Quaternion.identityQuaternion;
			if (!flag7)
			{
				return;
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void SpawnProjectiles()
	{
		//IL_0354: Expected O, but got I4
		//IL_04ed: Expected O, but got I
		//IL_04b0: Expected O, but got I
		//IL_005c: Expected O, but got I8
		//IL_009a: Expected O, but got I8
		//IL_00ea: Expected O, but got Ref
		//IL_00ea: Expected O, but got Ref
		//IL_0256: Expected O, but got I
		//IL_02f1: Expected O, but got I
		//IL_02b6: Expected O, but got I
		//IL_046b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0470: Expected O, but got Unknown
		//IL_0147->IL033f: Incompatible stack heights: 1 vs 0
		//IL_0196->IL033f: Incompatible stack heights: 1 vs 0
		//IL_0408->IL033f: Incompatible stack heights: 2 vs 0
		//IL_045d->IL033f: Incompatible stack heights: 3 vs 0
		//IL_0276->IL033f: Incompatible stack heights: 3 vs 0
		//IL_02db->IL0462: Incompatible stack heights: 3 vs 4
		//IL_0491->IL04dd: Incompatible stack heights: 4 vs 0
		object obj = 0;
		PhysicsTestbed2 physicsTestbed = this;
		IntPtr intPtr = default(IntPtr);
		Quaternion identityQuaternion = default(Quaternion);
		object obj5 = default(object);
		IntPtr intPtr2 = default(IntPtr);
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj2 == null)
				{
					MissingMethodException ex = new MissingMethodException();
					throw ex;
				}
				physicsTestbed = (PhysicsTestbed2)6573110936L;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v178 @ rax_v9 (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj3 == null)
				{
					break;
				}
				physicsTestbed = (PhysicsTestbed2)6573110936L;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v220 @ rax_v12 (should have been resolved before IL gen)");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v361 @ rbx_v4 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
			}
			UnityEngine.Object obj4 = UnityEngine.Object.Instantiate((UnityEngine.Object)_ProjectilePrefab, (Vector3)(&intPtr), (Quaternion)(&identityQuaternion));
			if ((object)obj4 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				bool flag = obj5 == null;
				List<object> spawned = (List<object>)(object)_spawned;
				ArcadeSprite component = ((GameObject)obj5).GetComponent<ArcadeSprite>();
				if (_spawned != null)
				{
					int version = spawned._version + 1;
					spawned._version = version;
					object[] items = spawned._items;
					if (spawned._items != null)
					{
						if (spawned._size >= items.Length)
						{
							((List<object>)(object)_spawned).AddWithResize((object)component);
						}
						else
						{
							int size = spawned._size + 1;
							spawned._size = size;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						}
						List<Vector2> spawnedPositions = _spawnedPositions;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v519 @ rax_v23 (System.Object)+10]");
						bool flag2 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v519 @ rax_v23 (System.Object)+10]");
						IntPtr gcHandlePtr = GameObject.get_transform_Injected((IntPtr)0);
						Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
						if ((object)transform != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v586 @ rax_v31 (UnityEngine.Transform)+10]");
							bool flag3 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v586 @ rax_v31 (UnityEngine.Transform)+10]");
							IntPtr ret;
							Transform.get_position_Injected((IntPtr)0, out *(Vector3*)(&ret));
							if (_spawnedPositions != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rbx_v9 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+1C]");
								_ = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rbx_v9 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
								nint num2 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rbx_v9 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
								physicsTestbed = (PhysicsTestbed2)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rbx_v9 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rbx_v9 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
									nint num3 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rdx_v1 (Il2CppMethodInfo)+18]");
									if (num3 >= 0)
									{
										_spawnedPositions.AddWithResize((Vector2)(nint)intPtr2);
										num2 = intPtr2;
										nint num4 = 0;
										IntPtr intPtr3 = intPtr2;
										physicsTestbed = (PhysicsTestbed2)(object)_spawnedPositions;
									}
									else
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rbx_v9 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
										object obj6 = (nint)0 + (nint)1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rbx_v9 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
										nint num5 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rdx_v1 (Il2CppMethodInfo)+18]");
										bool flag4 = num5 >= 0;
										nint num4 = 0;
										IntPtr intPtr3 = ret;
									}
									obj++;
									bool flag5 = (nint)obj < 500;
									identityQuaternion = Quaternion.identityQuaternion;
									if (!flag5)
									{
										return;
									}
									continue;
								}
							}
						}
					}
				}
			}
			throw new NullReferenceException();
		}
		MissingMethodException ex2 = new MissingMethodException();
		throw ex2;
	}

	private void LateUpdate()
	{
		//IL_0037: Expected O, but got I4
		//IL_0040: Expected O, but got I4
		//IL_024c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0251: Expected O, but got Unknown
		//IL_00b8->IL0177: Incompatible stack heights: 1 vs 0
		//IL_00ef->IL0177: Incompatible stack heights: 1 vs 0
		//IL_0204->IL0177: Incompatible stack heights: 2 vs 0
		//IL_0142->IL0177: Incompatible stack heights: 3 vs 0
		//IL_026b->IL0177: Incompatible stack heights: 5 vs 0
		//IL_0177->IL0270: Incompatible stack heights: 5 vs 0
		if (!_freeze)
		{
			return;
		}
		List<Vector2> spawnedPositions = _spawnedPositions;
		if (_spawnedPositions != null)
		{
			object obj = 0;
			object obj2 = 0;
			Vector3 value = default(Vector3);
			while (true)
			{
				object obj3 = obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rax_v22 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
				if ((nint)obj3 < 0)
				{
					List<ArcadeSprite> spawned = _spawned;
					if (_spawned == null)
					{
						break;
					}
					bool flag = (nint)obj >= spawned._size;
					ArcadeSprite[] items = spawned._items;
					if (spawned._items == null)
					{
						break;
					}
					object obj4 = items[obj];
					if ((object)items[obj] == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rdi_v12 (System.Object)+10]");
					bool flag2 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rdi_v12 (System.Object)+10]");
					IntPtr gcHandlePtr = Component.get_transform_Injected((IntPtr)0);
					Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
					List<Vector2> spawnedPositions2 = _spawnedPositions;
					if (_spawnedPositions == null)
					{
						break;
					}
					object obj5 = obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rcx_v25 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
					bool flag3 = (nint)obj5 >= 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rcx_v25 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
					if ((nint)0 == 0)
					{
						break;
					}
					bool flag4 = (object)transform == null;
					bool flag5 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
					spawnedPositions = _spawnedPositions;
					obj++;
					if (_spawnedPositions == null)
					{
						break;
					}
					obj2 = obj;
					continue;
				}
				return;
			}
		}
		throw new NullReferenceException();
	}

	public PhysicsTestbed2()
	{
		List<ArcadeSprite> spawned = new List<ArcadeSprite>();
		_spawned = spawned;
		List<Vector2> spawnedPositions = new List<Vector2>();
		_spawnedPositions = spawnedPositions;
	}
}
