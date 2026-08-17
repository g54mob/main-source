using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts._Data.MapsAndStages;
using Assets.Scripts.Game.MapGeneration;
using Assets.Scripts.Game.Spawning;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations;
using Assets.Scripts.Managers;
using Assets.Scripts.MapGeneration;
using Assets.Scripts.MapGeneration.ProceduralTiles;
using Cpp2ILInjected;
using UnityEngine;

public class MapGenerationController : MonoBehaviour
{
	private sealed class _003CGenerateMap_003Ed__39 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MapGenerationController _003C_003E4__this;

		private Mesh _003CworldMesh_003E5__2;

		private StageData _003CstageData_003E5__3;

		private MapData _003CmapData_003E5__4;

		private Vector3 _003CworldSize_003E5__5;

		private Vector3 _003CworldCenter_003E5__6;

		private Vector3 _003CspawnPosition_003E5__7;

		private Vector3 _003CspawnDirection_003E5__8;

		private Vector3 _003CworldAreaNew_003E5__9;

		private Vector3 _003CworldCenterNew_003E5__10;

		private float _003CworldAreaMagnitude_003E5__11;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		public _003CGenerateMap_003Ed__39(int _003C_003E1__state)
		{
			((IDisposable)this).Dispose();
			this._003C_003E1__state = _003C_003E1__state;
		}

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_0008: Expected O, but got Ref
			//IL_0cb9: Expected I4, but got I8
			//IL_001d: Expected O, but got I4
			//IL_0ca5: Expected I4, but got I8
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			//IL_0039: Expected O, but got Unknown
			//IL_0b73: Expected I4, but got I8
			//IL_1923: Expected I, but got O
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Expected O, but got Unknown
			//IL_1aaa: Expected I, but got O
			//IL_0929: Expected I4, but got I8
			//IL_1a34: Expected I, but got O
			//IL_1b7f: Expected I, but got O
			//IL_1a6f: Expected I, but got O
			//IL_00a5: Expected I4, but got I8
			//IL_1bba: Expected I, but got O
			//IL_0ef4: Expected O, but got I
			//IL_0f26: Expected O, but got I4
			//IL_00f5: Expected O, but got I4
			//IL_18f4: Expected I4, but got O
			//IL_0adf: Expected O, but got I4
			//IL_0ae8: Expected O, but got I4
			//IL_1091: Unknown result type (might be due to invalid IL or missing references)
			//IL_1096: Expected Ref, but got Unknown
			//IL_10b6: Expected O, but got I4
			//IL_10c9: Expected O, but got F4
			//IL_0c6d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c72: Expected O, but got Unknown
			//IL_13b0: Expected I, but got O
			//IL_1b01: Expected I, but got O
			//IL_1b1f: Expected O, but got F4
			//IL_0fa3: Expected O, but got Ref
			//IL_09c7: Expected I, but got O
			//IL_09cf: Expected I, but got O
			//IL_09df: Expected O, but got I
			//IL_1bf5: Expected I, but got O
			//IL_013c: Expected O, but got Ref
			//IL_0155: Expected F4, but got O
			//IL_0150: Expected native int or pointer, but got O
			//IL_016a: Expected F4, but got I
			//IL_0165: Expected native int or pointer, but got O
			//IL_019e: Expected F4, but got I4
			//IL_019e: Expected F4, but got I4
			//IL_019e: Expected O, but got Ref
			//IL_01b1: Expected O, but got F4
			//IL_110d: Expected O, but got F4
			//IL_0a1b: Expected O, but got I
			//IL_1459: Expected I, but got O
			//IL_1486: Expected O, but got I
			//IL_1496: Unknown result type (might be due to invalid IL or missing references)
			//IL_149b: Expected O, but got Unknown
			//IL_14c1: Expected O, but got Ref
			//IL_14f0: Expected O, but got Ref
			//IL_14fe: Expected O, but got Ref
			//IL_113d: Expected O, but got F4
			//IL_0b3b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b40: Expected O, but got Unknown
			//IL_1704: Expected I, but got O
			//IL_176a: Expected I, but got O
			//IL_0a71: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a76: Expected I4, but got Unknown
			//IL_079d: Expected O, but got Ref
			//IL_152f: Expected I, but got O
			//IL_153d: Expected O, but got Ref
			//IL_158f: Expected O, but got Ref
			//IL_159d: Expected O, but got Ref
			//IL_15df: Expected O, but got F4
			//IL_15f2: Expected I, but got O
			//IL_01f1: Expected O, but got Ref
			//IL_0235: Expected O, but got Ref
			//IL_0243: Expected O, but got Ref
			//IL_1229: Expected O, but got Ref
			//IL_0831: Expected O, but got Ref
			//IL_086e: Expected I, but got O
			//IL_1240: Expected O, but got Ref
			//IL_124e: Expected O, but got Ref
			//IL_11f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_11fa: Expected Ref, but got Unknown
			//IL_1200: Unknown result type (might be due to invalid IL or missing references)
			//IL_1205: Expected Ref, but got Unknown
			//IL_105b: Expected O, but got Ref
			//IL_17a1: Expected I, but got O
			//IL_182b: Expected I, but got O
			//IL_1861: Expected I, but got O
			//IL_0295: Expected O, but got Ref
			//IL_02a8: Expected O, but got Ref
			//IL_02d5: Expected F4, but got I4
			//IL_16b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_16bb: Expected O, but got Unknown
			//IL_02f6: Expected O, but got F4
			//IL_0313: Expected O, but got I4
			//IL_08b8: Expected O, but got Ref
			//IL_12e8: Expected O, but got Ref
			//IL_12f6: Expected O, but got Ref
			//IL_034e: Expected O, but got I
			//IL_03be: Expected O, but got Ref
			//IL_03cc: Expected O, but got Ref
			//IL_043c: Expected O, but got Ref
			//IL_0453: Expected O, but got Ref
			//IL_0461: Expected O, but got Ref
			//IL_0512: Expected O, but got Ref
			//IL_055a: Expected F4, but got I4
			//IL_055a: Expected F4, but got I4
			//IL_055a: Expected O, but got Ref
			//IL_05be: Expected O, but got Ref
			//IL_05cc: Expected O, but got Ref
			object obj = default(object);
			Vector3 vector = (Vector3)(&obj);
			MapGenerationController mapGenerationController = _003C_003E4__this;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			bool flag = _003C_003E1__state == 0;
			bool result;
			int num13 = default(int);
			ref Vector3 reference = default(ref Vector3);
			Vector3 vector2 = default(Vector3);
			float num31 = default(float);
			if (!flag)
			{
				object obj2 = _003C_003E1__state - 1;
				if (!flag)
				{
					object obj3 = obj2 - 1;
					if (!flag)
					{
						object obj4 = obj3 - 1;
						if (!flag)
						{
							bool flag2 = (nint)obj4 != 1;
							result = false;
							if (!flag2)
							{
								MapData mapData = _003CmapData_003E5__4;
								_003C_003E1__state = -1;
								if ((nint)mapData.mapType == (nint)obj4)
								{
									PlayerCamera playerCamera = UnityEngine.Object.FindAnyObjectByType<PlayerCamera>(FindObjectsInactive.Include);
									_ = 0;
									Mesh mesh = null;
									object obj5 = 0;
									float num = 999f;
									float num2 = -0f;
									int attempts = default(int);
									bool onlyUseGroundLayer = default(bool);
									bool debug = default(bool);
									object obj10 = default(object);
									bool flag4;
									do
									{
										nint num3 = (nint)typeof(Vector3);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2273 @ rax_v192 (Il2CppClass<UnityEngine.Vector3>)+B8]");
										nint num4 = 0;
										float num5 = (float)Vector3.upVector * num;
										float num6 = num5 + (float)_003CworldCenter_003E5__6;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2274 @ rcx_v158 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
										float num7 = 0f * num;
										float num8 = num7;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MapGenerationController+<GenerateMap>d__39)+50]");
										float num9 = num8 + 0f;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2274 @ rcx_v158 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
										float num10 = 0f * num;
										float num11 = num10;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MapGenerationController+<GenerateMap>d__39)+54]");
										float num12 = num11 + 0f;
										GameManager instance = GameManager.Instance;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
										bool canSpawnInWater = (byte)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj, 96)) != 0;
										Vector3 center = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj, 48));
										((Vector3*)(nint)vector)->x = (float)_003CworldSize_003E5__5;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MapGenerationController+<GenerateMap>d__39)+48]");
										((Vector3*)(nint)vector)->z = 0f;
										Vector3 objectSpawnPosition = SpawnPositions.GetObjectSpawnPosition(center, (Vector3)(&obj), 5f, num13, out reference, attempts, onlyUseGroundLayer, debug, canSpawnInWater, 9999f, 1f);
										_003CspawnPosition_003E5__7 = (Vector3)objectSpawnPosition.x;
										_ = objectSpawnPosition.z;
										nint num14 = (nint)typeof(Vector3);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2523 @ rax_v199 (Il2CppClass<UnityEngine.Vector3>)+B8]");
										nint num15 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2524 @ rcx_v166 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
										nint num16 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2524 @ rcx_v166 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
										object obj6 = num16 + 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MapGenerationController+<GenerateMap>d__39)+60]");
										object obj7 = obj6 + 0;
										_003CspawnPosition_003E5__7 = vector2;
										Vector3 insideUnitSphere = UnityEngine.Random.insideUnitSphere;
										Vector3 v = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj, 16));
										_ = insideUnitSphere.x;
										_ = insideUnitSphere.z;
										Vector3 vector3 = VectorExtensions.XZVector(v);
										object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj, 96));
										object obj9 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj, 192));
										_ = vector3.x;
										_ = vector3.z;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
										_003CspawnDirection_003E5__8 = (Vector3)obj10;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2612 @ rax_v204+8]");
										_ = 0;
										Mesh mesh2 = mesh;
										bool flag3;
										do
										{
											nint num17 = (nint)typeof(Vector3);
											Vector3 axis = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj, 32));
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2733 @ rax_v207 (Il2CppClass<UnityEngine.Vector3>)+B8]");
											nint num18 = 0;
											float angle = (float)mesh2 * 60f;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2739 @ rax_v208 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
											_ = 0;
											_ = Vector3.upVector;
											Quaternion quaternion = Quaternion.AngleAxis(angle, axis);
											Vector3 vector4 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj, 48));
											Quaternion quaternion2 = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj, 112));
											_ = _003CspawnDirection_003E5__8;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MapGenerationController+<GenerateMap>d__39)+6C]");
											_ = 0;
											_ = quaternion.x;
											Vector3 vector5 = quaternion2 * vector4;
											object obj11 = vector5.z ^ num2;
											nint num19 = (nint)typeof(Vector3);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v726 @ rax_v213 (Il2CppClass<UnityEngine.Vector3>)+B8]");
											nint num20 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v791 @ rcx_v177 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
											float num21 = 0f * 3.5f;
											float num22 = num21;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MapGenerationController+<GenerateMap>d__39)+5C]");
											float num23 = num22 + 0f;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v791 @ rcx_v177 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
											float num24 = 0f * 3.5f;
											float num25 = vector5.y * 3f;
											float num26 = num24;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MapGenerationController+<GenerateMap>d__39)+60]");
											float num27 = num26 + 0f;
											float num28 = num23 + num25;
											float num29 = vector5.z * 3f;
											float num30 = num27 + num29;
											Vector3 portalOffsetPosition = playerCamera.GetPortalOffsetPosition((Vector3)(&num31));
											float num32 = num28 + portalOffsetPosition.y;
											float num33 = num30 + portalOffsetPosition.z;
											object obj12 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj, 64));
											object obj13 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj, 80));
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331420");
											GameManager instance2 = GameManager.Instance;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
											ref RaycastHit hitInfo = ref System.Runtime.CompilerServices.Unsafe.As<object, RaycastHit>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj, 96));
											Vector3 direction = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj, 64));
											Vector3 origin = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj, 128));
											if (!Physics.SphereCast(origin, 0.25f, direction, out hitInfo, num13, (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref reference)))
											{
												_003CspawnDirection_003E5__8 = (Vector3)vector5.x;
												_ = vector5.y;
												_ = vector5.z;
												obj5 = 1;
											}
											mesh2 = (Mesh)(mesh2 + 1);
											flag3 = (nint)mesh2 < 6;
											num2 = -0f;
										}
										while (flag3);
										if (obj5 != null)
										{
											break;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1 (UnityEngine.Vector3)+1B0]");
										object obj14 = (nint)0 + (nint)1;
										flag4 = (nint)obj14 < 50;
										mesh = null;
										num = 999f;
										num2 = -0f;
									}
									while (flag4);
									Transform transform = mapGenerationController.spawnPlatform.transform;
									Quaternion rotation = transform.rotation;
									Quaternion rotation2 = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj, 112));
									Vector3 position = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj, 128));
									_ = rotation.x;
									_ = _003CspawnPosition_003E5__7;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MapGenerationController+<GenerateMap>d__39)+60]");
									_ = 0;
									GameObject gameObject = UnityEngine.Object.Instantiate(mapGenerationController.spawnPlatform, position, rotation2);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MapGenerationController+<GenerateMap>d__39)+6C]");
									float num34 = 0f * 3f;
									float num35 = num34;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MapGenerationController+<GenerateMap>d__39)+60]");
									float num36 = num35 + 0f;
									Quaternion quaternion3 = Quaternion.LookRotation((Vector3)(&num31));
									Quaternion rotation3 = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj, 112));
									Vector3 position2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj, 128));
									_ = quaternion3.x;
									GameObject gameObject2 = UnityEngine.Object.Instantiate(mapGenerationController.spawnPortal, position2, rotation3);
									SpawnPlayerPortal component = gameObject2.GetComponent<SpawnPlayerPortal>();
									component.StartPortal();
									MeshRenderer component2 = gameObject.GetComponent<MeshRenderer>();
									StageData stageData = _003CstageData_003E5__3;
									((Renderer)component2).SetMaterial(stageData.triplanarMaterial);
									GameManager instance3 = GameManager.Instance;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
									bool canSpawnInWater2 = (byte)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj, 96)) != 0;
									Vector3 size = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj, 128));
									_ = _003CworldSize_003E5__5;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MapGenerationController+<GenerateMap>d__39)+48]");
									_ = 0;
									bool debug2 = default(bool);
									Vector3 objectSpawnPosition2 = SpawnPositions.GetObjectSpawnPosition((Vector3)(&num31), size, 5f, num13, out reference, attempts, onlyUseGroundLayer, debug2, canSpawnInWater2, 9999f, 1f);
									GameObject gameObject3 = (MapController.IsLastStage() ? mapGenerationController.bossPortalFinal : mapGenerationController.bossPortal);
									Transform transform2 = gameObject3.transform;
									Quaternion rotation4 = transform2.rotation;
									Quaternion rotation5 = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj, 112));
									Vector3 position3 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj, 128));
									_ = rotation4.x;
									_ = objectSpawnPosition2.x;
									_ = objectSpawnPosition2.z;
									GameObject gameObject4 = UnityEngine.Object.Instantiate(gameObject3, position3, rotation5);
								}
								SpawnInteractables interactablesSpawner = mapGenerationController.interactablesSpawner;
								interactablesSpawner.worldArea = _003CworldAreaNew_003E5__9;
								interactablesSpawner.worldCenter = _003CworldCenterNew_003E5__10;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MapGenerationController+<GenerateMap>d__39)+78]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MapGenerationController+<GenerateMap>d__39)+84]");
								_ = 0;
								interactablesSpawner.areaMagnitude = _003CworldAreaMagnitude_003E5__11;
								mapGenerationController.interactablesSpawner.SpawnRails();
								mapGenerationController.interactablesSpawner.SpawnChests();
								mapGenerationController.interactablesSpawner.SpawnShrines();
								mapGenerationController.interactablesSpawner.SpawnOther();
								StageData stageData2 = _003CstageData_003E5__3;
								if (stageData2.grassMaterial != null)
								{
									StageData stageData3 = _003CstageData_003E5__3;
									if (stageData3.grassPerChunk > 0)
									{
										mapGenerationController.grassRenderer.Set(stageData3.grassMaterial, stageData3.grassPerChunk);
										GameObject gameObject5 = mapGenerationController.grassRenderer.gameObject;
										gameObject5.SetActive(value: true);
									}
								}
								Transform transform3 = mapGenerationController.colliderBox.transform;
								nint num37 = (nint)typeof(Vector3);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2751 @ rdx_v80 (Il2CppClass<UnityEngine.Vector3>)+B8]");
								nint num38 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MapGenerationController+<GenerateMap>d__39)+44]");
								float num39 = 0f * 0.5f;
								float num40 = num39;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2752 @ rax_v156 (Il2CppStaticFields<UnityEngine.Vector3>)+2C]");
								float num41 = num40 * 0f;
								float num42 = num41;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MapGenerationController+<GenerateMap>d__39)+54]");
								float num43 = num42 + 0f;
								nint num44 = (nint)typeof(Vector3);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v627 @ rdx_v81 (Il2CppClass<UnityEngine.Vector3>)+B8]");
								nint num45 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v684 @ rax_v158 (Il2CppStaticFields<UnityEngine.Vector3>)+2C]");
								float num46 = 0f * 20f;
								float num47 = num46 + num43;
								transform3.position = (Vector3)(&num31);
								MapData mapData2 = _003CmapData_003E5__4;
								if (mapData2.mapType != EMapType.Tiles)
								{
									MapData mapData3 = _003CmapData_003E5__4;
									if (mapData3.mapType != EMapType.ProceduralMesh)
									{
									}
								}
								Transform transform4 = mapGenerationController.colliderBox.transform;
								transform4.localScale = (Vector3)(&num31);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MapGenerationController+<GenerateMap>d__39)+48]");
								float num48 = 0f * 0.5f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MapGenerationController+<GenerateMap>d__39)+54]");
								float num49 = 0f - num48;
								nint num50 = (nint)typeof(MapInfo);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3038 @ rcx_v135 (Il2CppClass<Assets.Scripts.MapGeneration.MapInfo>)+B8]");
								nint num51 = 0;
								MapInfo.mapBoundsLower = vector2;
								nint num52 = (nint)typeof(MapInfo);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MapGenerationController+<GenerateMap>d__39)+48]");
								float num53 = 0f * 0.5f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3047 @ rax_v165 (Il2CppClass<Assets.Scripts.MapGeneration.MapInfo>)+B8]");
								nint num54 = 0;
								float num55 = num53;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MapGenerationController+<GenerateMap>d__39)+54]");
								float num56 = num55 + 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MapGenerationController+<GenerateMap>d__39)+44]");
								float num57 = 0f * 0.5f;
								float num58 = num57;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MapGenerationController+<GenerateMap>d__39)+50]");
								float num59 = num58 + 0f;
								MapInfo.mapBoundsUpper = vector2;
								nint num60 = (nint)typeof(MapInfo);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3055 @ rax_v166 (Il2CppClass<Assets.Scripts.MapGeneration.MapInfo>)+B8]");
								nint num61 = 0;
								MapInfo.mapCenter = _003CworldCenter_003E5__6;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MapGenerationController+<GenerateMap>d__39)+54]");
								_ = 0;
								nint num62 = (nint)typeof(MapInfo);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v729 @ rax_v167 (Il2CppClass<Assets.Scripts.MapGeneration.MapInfo>)+B8]");
								nint num63 = 0;
								MapInfo.mapSize = _003CworldSize_003E5__5;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MapGenerationController+<GenerateMap>d__39)+48]");
								_ = 0;
								_003CstageData_003E5__3.ApplyFogAndSky(mapGenerationController.sunLight);
								GameObject gameObject6 = _003CstageData_003E5__3.SpawnParticles();
								StageData stageData4 = _003CstageData_003E5__3;
								Color fogColor = (Color)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj, 112));
								_ = stageData4.fogColor;
								mapGenerationController.minimapMesh.Set(_003CworldMesh_003E5__2, fogColor);
								isGenerating = false;
								Action a_GenerationComplete = A_GenerationComplete;
								if (A_GenerationComplete != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v3110.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
								}
								result = false;
							}
							goto IL_139d;
						}
						_003C_003E1__state = -1;
						RandomObjectPlacer randomObjectPlacer = mapGenerationController.randomObjectPlacer;
						MapData mapData4 = _003CmapData_003E5__4;
						if (MapController.HasPlayerInventory())
						{
							PlayerInventory playerInventory = MapController.GetPlayerInventory(null);
							ItemBase item = playerInventory.itemInventory.GetItem(EItem.Beacon);
							if (item != null)
							{
								nint num64 = (nint)typeof(ItemBeacon);
								nint num65 = (nint)item;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v522 @ r8_v32 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations.ItemBeacon>)+130]");
								object obj15 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v389 @ r9_v23 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemBase>)+130]");
								nint num66 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v522 @ r8_v32 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemImplementations.ItemBeacon>)+130]");
								if (num66 >= 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v389 @ r9_v23 (Il2CppClass<Assets.Scripts.Inventory__Items__Pickups.Items.ItemBase>)+C8]");
									object obj16 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v755 @ rcx_v114+FFFFFFF8+v2209 @ rcx_v113*8]");
									if (0 == (nint)typeof(ItemBeacon))
									{
										RandomMapObject chargeShrineSpawns = randomObjectPlacer.chargeShrineSpawns;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180439050");
										object obj17 = default(object);
										int amount = obj17 + chargeShrineSpawns.amount;
										chargeShrineSpawns.amount = amount;
									}
								}
							}
						}
						RandomMapObject[] randomObjectsOverride = mapData4.randomObjectsOverride;
						bool flag5 = randomObjectsOverride.Length != 0;
						RandomMapObject[] array = randomObjectsOverride;
						if (!flag5)
						{
							array = randomObjectPlacer.randomObjects;
						}
						mapGenerationController.randomObjectPlacer.RandomObjectSpawner(randomObjectPlacer.chargeShrineSpawns, mapData4.numShrinesPotsAndOtherMultiplier);
						mapGenerationController.randomObjectPlacer.RandomObjectSpawner(randomObjectPlacer.greedShrineSpawns, mapData4.numShrinesPotsAndOtherMultiplier);
						object obj18 = 0;
						object obj19 = 0;
						while ((nint)obj19 < array.Length)
						{
							if ((nint)obj18 < array.Length)
							{
								mapGenerationController.randomObjectPlacer.RandomObjectSpawner(array[obj18], mapData4.numShrinesPotsAndOtherMultiplier);
								obj18++;
								obj19 = obj18;
								continue;
							}
							goto IL_18e6;
						}
						_003C_003E2__current = null;
						_003C_003E1__state = 4;
					}
					else
					{
						_003C_003E1__state = -1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MapGenerationController+<GenerateMap>d__39)+48]");
						_ = 0;
						_003CworldAreaNew_003E5__9 = _003CworldSize_003E5__5;
						_ = 1065353216;
						nint num67 = (nint)typeof(Vector3);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ rax_v112 (Il2CppClass<UnityEngine.Vector3>)+B8]");
						nint num68 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MapGenerationController+<GenerateMap>d__39)+44]");
						float num69 = 0f * 0.5f;
						float num70 = num69 + 50f;
						float num71 = num70;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v207 @ rcx_v93 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
						float num72 = num71 * 0f;
						float num73 = num72;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MapGenerationController+<GenerateMap>d__39)+54]");
						float num74 = num73 + 0f;
						_003CworldCenterNew_003E5__10 = vector2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MapGenerationController+<GenerateMap>d__39)+78]");
						float num75 = 0f * (float)_003CworldAreaNew_003E5__9;
						_003CworldAreaMagnitude_003E5__11 = num75;
						RandomObjectPlacer randomObjectPlacer2 = mapGenerationController.randomObjectPlacer;
						randomObjectPlacer2.size = _003CworldAreaNew_003E5__9;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MapGenerationController+<GenerateMap>d__39)+78]");
						_ = 0;
						RandomObjectPlacer randomObjectPlacer3 = mapGenerationController.randomObjectPlacer;
						randomObjectPlacer3.center = _003CworldCenterNew_003E5__10;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MapGenerationController+<GenerateMap>d__39)+84]");
						_ = 0;
						StageData stageData5 = _003CstageData_003E5__3;
						RandomMapObject[] randomMapObjects = stageData5.randomMapObjects;
						Mesh mesh3 = null;
						Mesh mesh4 = null;
						while ((nint)mesh4 < randomMapObjects.Length)
						{
							if ((nint)mesh3 < randomMapObjects.Length)
							{
								mapGenerationController.randomObjectPlacer.RandomObjectSpawner(randomMapObjects[(object)mesh3], 1f);
								mesh3 = (Mesh)(mesh3 + 1);
								mesh4 = mesh3;
								continue;
							}
							goto IL_18e6;
						}
						_003C_003E2__current = null;
						_003C_003E1__state = 3;
					}
					goto IL_19e1;
				}
				_003C_003E1__state = -1;
				goto IL_0e20;
			}
			_003C_003E1__state = -1;
			Action a_PreGeneration = A_PreGeneration;
			if (A_PreGeneration != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v85.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
			isGenerating = true;
			int mapSeed = UnityEngine.Random.Range(0, 2147483647);
			MapGenerationController.mapSeed = mapSeed;
			_003CworldMesh_003E5__2 = null;
			mapGenerationController.gameManager.CreateInstances();
			_003CstageData_003E5__3 = MapController._003CcurrentStage_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18034A790");
			MapData mapData5 = default(MapData);
			_003CmapData_003E5__4 = mapData5;
			nint num76 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2458 @ rax_v47 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num77 = 0;
			_003CworldSize_003E5__5 = Vector3.zeroVector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2459 @ rcx_v40 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
			_ = 0;
			nint num78 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2504 @ rax_v50 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num79 = 0;
			_003CworldCenter_003E5__6 = Vector3.zeroVector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2505 @ rcx_v42 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
			_ = 0;
			nint num80 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2554 @ rax_v53 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num81 = 0;
			_003CspawnPosition_003E5__7 = Vector3.zeroVector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2555 @ rcx_v44 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
			_ = 0;
			nint num82 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2605 @ rax_v56 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num83 = 0;
			_003CspawnDirection_003E5__8 = Vector3.zeroVector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2606 @ rcx_v46 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
			_ = 0;
			mapGenerationController.cryptParent.SetActive(value: false);
			MapData mapData6 = _003CmapData_003E5__4;
			if (mapData6.mapType != EMapType.Tiles)
			{
				if (mapData6.mapType == EMapType.ProceduralMesh)
				{
					GameObject gameObject7 = mapGenerationController.water.gameObject;
					gameObject7.SetActive(value: true);
					mapGenerationController.water.Set(_003CmapData_003E5__4, _003CstageData_003E5__3);
					StageData stageData6 = _003CstageData_003E5__3;
					TerrainData proceduralTerrainData = stageData6.proceduralTerrainData;
					if (proceduralTerrainData.useFalloff)
					{
						goto IL_0e20;
					}
					mapGenerationController.proceduralMapWorldEdges.SetActive(value: true);
					Transform transform5 = mapGenerationController.proceduralMapWorldEdges.transform;
					Vector3 localScale = transform5.localScale;
					Transform transform6 = mapGenerationController.proceduralMapWorldEdges.transform;
					transform6.localScale = (Vector3)(&num31);
					_003C_003E2__current = null;
					_003C_003E1__state = 1;
					goto IL_19e1;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18034A7E0");
				Vector3 vector6 = mapGenerationController.proceduralTileGeneration.Generate(out *(Vector3*)(this + 100), _003CstageData_003E5__3, (MapParameters)num13, (byte)System.Runtime.CompilerServices.Unsafe.AsPointer(ref reference) != 0);
				_003CspawnPosition_003E5__7 = (Vector3)vector6.x;
				_ = vector6.z;
				_ = vector6.x;
				_ = vector6.z;
				nint num84 = (nint)typeof(MapGenerationController);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2959 @ rax_v65 (Il2CppClass<MapGenerationController>)+B8]");
				nint num85 = 0;
				_003CtileSpawnPosition_003Ek__BackingField = (Vector3)vector6.x;
				_ = vector6.z;
				nint num86 = (nint)typeof(MapGenerationController);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v716 @ rax_v67 (Il2CppClass<MapGenerationController>)+B8]");
				nint num87 = 0;
				_003CtileSpawnDir_003Ek__BackingField = _003CspawnDirection_003E5__8;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MapGenerationController+<GenerateMap>d__39)+6C]");
				_ = 0;
				Vector3 worldSize = mapGenerationController.proceduralTileGeneration.GetWorldSize();
				_003CworldSize_003E5__5 = (Vector3)worldSize.x;
				_ = worldSize.z;
				Vector3 worldCenter = mapGenerationController.proceduralTileGeneration.GetWorldCenter();
				_003CworldCenter_003E5__6 = (Vector3)worldCenter.x;
				_ = worldCenter.z;
				ProceduralTileGeneration proceduralTileGeneration = mapGenerationController.proceduralTileGeneration;
				mapGenerationController.RandomTileObjects.Generate(proceduralTileGeneration.flatTiles, _003CstageData_003E5__3);
				ProceduralTileGeneration proceduralTileGeneration2 = mapGenerationController.proceduralTileGeneration;
				MeshFilter component3 = proceduralTileGeneration2.collider.GetComponent<MeshFilter>();
				Mesh sharedMesh = component3.sharedMesh;
				_003CworldMesh_003E5__2 = sharedMesh;
				MapData mapData7 = _003CmapData_003E5__4;
				if (mapData7.eMap == EMap.Graveyard)
				{
					mapGenerationController.CryptGeneration(MapGenerationController.mapSeed, out *(Vector3*)(this + 88), out *(Vector3*)(this + 100));
				}
				Quaternion quaternion4 = Quaternion.LookRotation((Vector3)(&num31));
				Quaternion rotation6 = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj, 112));
				Vector3 position4 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj, 128));
				_ = quaternion4.x;
				_ = _003CspawnPosition_003E5__7;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MapGenerationController+<GenerateMap>d__39)+60]");
				_ = 0;
				GameObject gameObject8 = UnityEngine.Object.Instantiate(mapGenerationController.spawnPortal, position4, rotation6);
				SpawnPlayerPortal component4 = gameObject8.GetComponent<SpawnPlayerPortal>();
				component4.StartPortal();
				StageData stageData7 = _003CstageData_003E5__3;
				if (stageData7.mapEdgeFillType == MapEdgeFillType.None)
				{
					Vector3 worldSize2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj, 128));
					Vector3 worldCenter2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj, 64));
					_ = _003CworldSize_003E5__5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MapGenerationController+<GenerateMap>d__39)+48]");
					_ = 0;
					_ = _003CworldCenter_003E5__6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MapGenerationController+<GenerateMap>d__39)+54]");
					_ = 0;
					mapGenerationController.mapEdges.Set(worldCenter2, worldSize2, _003CstageData_003E5__3);
				}
			}
			goto IL_133f;
			IL_139d:
			return result;
			IL_19e1:
			result = true;
			goto IL_139d;
			IL_133f:
			_003C_003E2__current = null;
			_003C_003E1__state = 2;
			goto IL_19e1;
			IL_0e20:
			GameObject gameObject9 = mapGenerationController.proceduralMapMeshGenerator.gameObject;
			gameObject9.SetActive(value: true);
			mapGenerationController.proceduralMapMeshGenerator.GenerateMap(_003CmapData_003E5__4, _003CstageData_003E5__3, MapGenerationController.mapSeed);
			nint num88 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2319 @ rax_v18 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num89 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v764 @ rcx_v14 (Il2CppStaticFields<UnityEngine.Vector3>)+50]");
			float num90 = 0f * 20f;
			_003CspawnDirection_003E5__8 = vector2;
			MapGenerator proceduralMapMeshGenerator = mapGenerationController.proceduralMapMeshGenerator;
			MapDisplay mapDisplay = proceduralMapMeshGenerator._003Cdisplay_003Ek__BackingField;
			Mesh sharedMesh2 = mapDisplay.meshFilter.sharedMesh;
			_003CworldMesh_003E5__2 = sharedMesh2;
			MapGenerator proceduralMapMeshGenerator2 = mapGenerationController.proceduralMapMeshGenerator;
			MapDisplay mapDisplay2 = proceduralMapMeshGenerator2._003Cdisplay_003Ek__BackingField;
			Bounds bounds = mapDisplay2.meshCollider.bounds;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v706 @ rax_v25 (UnityEngine.Bounds)+14]");
			nint num91 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v706 @ rax_v25 (UnityEngine.Bounds)+14]");
			object obj20 = num91 + 0;
			_003CworldSize_003E5__5 = vector2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (MapGenerationController+<GenerateMap>d__39)+44]");
			float num92 = 0f * 0.5f;
			_003CworldCenter_003E5__6 = (Vector3)0;
			_ = 0;
			Transform transform7 = mapGenerationController.minimapMesh.transform;
			MapGenerator proceduralMapMeshGenerator3 = mapGenerationController.proceduralMapMeshGenerator;
			MapDisplay mapDisplay3 = proceduralMapMeshGenerator3._003Cdisplay_003Ek__BackingField;
			Transform transform8 = mapDisplay3.meshRenderer.transform;
			Vector3 localScale2 = transform8.localScale;
			Vector3 localScale3 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj, 128));
			_ = localScale2.x;
			_ = localScale2.z;
			transform7.localScale = localScale3;
			StageData stageData8 = _003CstageData_003E5__3;
			((Renderer)mapGenerationController.proceduralMeshRenderer).SetMaterial(stageData8.triplanarMaterial);
			goto IL_133f;
			IL_18e6:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			return (byte)(int)ex != 0;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			NotSupportedException ex = new NotSupportedException();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			throw ex;
		}
	}

	public MapData testMapData;

	public StageData testStageData;

	public ProceduralTileGeneration proceduralTileGeneration;

	public RandomObjectPlacer randomObjectPlacer;

	public GenerateTileObjects RandomTileObjects;

	public MinimapMesh minimapMesh;

	public GameObject colliderBox;

	public GameObject spawnPortal;

	public GameObject bossPortal;

	public GameObject spawnPlatform;

	public GameObject bossPortalFinal;

	public GameObject graveyardBossPortal;

	public GameManager gameManager;

	public SpawnInteractables interactablesSpawner;

	public GrassChunkManager grassRenderer;

	public MapEdges mapEdges;

	public MeshRenderer proceduralMeshRenderer;

	public Water water;

	public GameObject proceduralMapWorldEdges;

	public MapGenerator proceduralMapMeshGenerator;

	public static Action A_GenerationComplete;

	public static Action A_PreGeneration;

	public Light sunLight;

	public static bool isGenerating;

	public GameObject cryptParent;

	public GameObject cryptExitOutside;

	public RsgController rsgController;

	public int testSeed;

	private static Vector3 _003CtileSpawnPosition_003Ek__BackingField;

	private static Vector3 _003CtileSpawnDir_003Ek__BackingField;

	public static int mapSeed;

	public unsafe static Vector3 tileSpawnPosition
	{
		get
		{
			//IL_0013: Expected I, but got O
			//IL_0031: Expected F4, but got O
			//IL_002c: Expected native int or pointer, but got O
			//IL_0046: Expected F4, but got I
			//IL_0041: Expected native int or pointer, but got O
			nint num = (nint)typeof(MapGenerationController);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rax_v2 (Il2CppClass<MapGenerationController>)+B8]");
			nint num2 = 0;
			Vector3 vector = default(Vector3);
			((Vector3*)(nint)vector)->x = (float)_003CtileSpawnPosition_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ rax_v3 (Il2CppStaticFields<MapGenerationController>)+1C]");
			((Vector3*)(nint)vector)->z = 0f;
			return vector;
		}
		private set
		{
			//IL_0013: Expected I, but got O
			//IL_0031: Expected O, but got F4
			nint num = (nint)typeof(MapGenerationController);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rax_v2 (Il2CppClass<MapGenerationController>)+B8]");
			nint num2 = 0;
			_003CtileSpawnPosition_003Ek__BackingField = (Vector3)value.x;
			_ = value.z;
		}
	}

	public unsafe static Vector3 tileSpawnDir
	{
		get
		{
			//IL_0013: Expected I, but got O
			//IL_0031: Expected F4, but got O
			//IL_002c: Expected native int or pointer, but got O
			//IL_0046: Expected F4, but got I
			//IL_0041: Expected native int or pointer, but got O
			nint num = (nint)typeof(MapGenerationController);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rax_v2 (Il2CppClass<MapGenerationController>)+B8]");
			nint num2 = 0;
			Vector3 vector = default(Vector3);
			((Vector3*)(nint)vector)->x = (float)_003CtileSpawnDir_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ rax_v3 (Il2CppStaticFields<MapGenerationController>)+28]");
			((Vector3*)(nint)vector)->z = 0f;
			return vector;
		}
		private set
		{
			//IL_0013: Expected I, but got O
			//IL_0031: Expected O, but got F4
			nint num = (nint)typeof(MapGenerationController);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rax_v2 (Il2CppClass<MapGenerationController>)+B8]");
			nint num2 = 0;
			_003CtileSpawnDir_003Ek__BackingField = (Vector3)value.x;
			_ = value.z;
		}
	}

	private void Awake()
	{
		if (MapController._003CcurrentStage_003Ek__BackingField == null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
			MapController.TestMap(testMapData, testStageData);
		}
		_003CGenerateMap_003Ed__39 obj = new _003CGenerateMap_003Ed__39(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj);
	}

	private unsafe void CryptGeneration(int seed, out Vector3 spawnPos, out Vector3 spawnDir)
	{
		//IL_0008: Expected O, but got Ref
		//IL_03eb: Expected I, but got O
		//IL_0409: Expected I, but got O
		//IL_0428: Unknown result type (might be due to invalid IL or missing references)
		//IL_042d: Expected O, but got Unknown
		//IL_043e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0443: Expected O, but got Unknown
		//IL_0454: Unknown result type (might be due to invalid IL or missing references)
		//IL_0459: Expected O, but got Unknown
		//IL_006a: Expected O, but got Ref
		//IL_007d: Expected O, but got Ref
		//IL_0090: Expected O, but got Ref
		//IL_00f1: Expected F4, but got I
		//IL_016d: Expected O, but got Ref
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Expected O, but got Unknown
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Expected O, but got Unknown
		//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Expected O, but got Unknown
		//IL_028e: Expected O, but got Ref
		//IL_02a6: Expected O, but got Ref
		//IL_046c: Expected I, but got O
		//IL_047a: Expected O, but got Ref
		//IL_04bd: Expected I, but got O
		//IL_02e8: Expected O, but got Ref
		//IL_02f6: Expected O, but got Ref
		//IL_037d: Expected Ref, but got F4
		//IL_03c7: Expected Ref, but got F4
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		cryptParent.SetActive(value: true);
		this.rsgController.Generate(seed, RsgController.EDungeonType.Normal, out System.Runtime.CompilerServices.Unsafe.As<object, float>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 95)));
		RsgController rsgController = this.rsgController;
		nint num = (nint)typeof(MapGenerationController);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v434 @ rcx_v6 (Il2CppClass<MapGenerationController>)+B8]");
		nint num2 = 0;
		nint num3 = (nint)typeof(MapGenerationController);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rcx_v8 (Il2CppClass<MapGenerationController>)+B8]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rcx_v8 (Il2CppClass<MapGenerationController>)+B8]");
		nint num5 = 0;
		object obj3 = _003CtileSpawnDir_003Ek__BackingField ^ -0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rax_v12 (Il2CppStaticFields<MapGenerationController>)+24]");
		object obj4 = 0 ^ -0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rax_v12 (Il2CppStaticFields<MapGenerationController>)+28]");
		object obj5 = 0 ^ -0f;
		Vector3 cameraDir = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 49));
		Vector3 dir = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 33));
		Vector3 pos = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 17));
		_ = _003CtileSpawnDir_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v454 @ rax_v10 (Il2CppStaticFields<MapGenerationController>)+28]");
		_ = 0;
		_ = _003CtileSpawnPosition_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v436 @ rax_v8 (Il2CppStaticFields<MapGenerationController>)+1C]");
		_ = 0;
		rsgController._003CrsgEnd_003Ek__BackingField.SetTeleportTransform(pos, dir, cameraDir);
		GameManager obj6 = gameManager;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+5F]");
		obj6.StartDungeon(0f);
		ProceduralTileGeneration proceduralTileGeneration = this.proceduralTileGeneration;
		List<GameObject> flatTiles = proceduralTileGeneration.flatTiles;
		int index = flatTiles._size - 1;
		GameObject gameObject = flatTiles.get_Item(index);
		Transform transform = gameObject.transform;
		ProceduralTile component = transform.GetComponent<ProceduralTile>();
		Vector3 v = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 49));
		object obj7 = component._003CparentDir_003Ek__BackingField ^ -0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rax_v17 (ProceduralTile)+50]");
		object obj8 = 0 ^ -0f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rax_v17 (ProceduralTile)+54]");
		object obj9 = 0 ^ -0f;
		Vector3 vector = VectorExtensions.XZVector(v);
		RsgController rsgController2 = this.rsgController;
		GraveyardBossRoom roomBoss = rsgController2.roomBoss;
		Vector3 position = transform.position;
		float num6 = vector.x * 15f;
		float num7 = vector.y * 15f;
		float num8 = num6 + position.x;
		float num9 = vector.z * 15f;
		float num10 = num7 + position.y;
		float num11 = num9 + position.z;
		_ = vector.x;
		Vector3 dir2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 49));
		_ = vector.y;
		Vector3 pos2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 33));
		_ = vector.z;
		roomBoss.interactableGhostBossLeave.SetTeleportTransform(pos2, dir2);
		nint num12 = (nint)typeof(MapGenerationController);
		Vector3 forward = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 17));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v505 @ rax_v22 (Il2CppClass<MapGenerationController>)+B8]");
		nint num13 = 0;
		_ = _003CtileSpawnDir_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v509 @ rax_v23 (Il2CppStaticFields<MapGenerationController>)+28]");
		_ = 0;
		Quaternion quaternion = Quaternion.LookRotation(forward);
		nint num14 = (nint)typeof(MapGenerationController);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v527 @ rax_v27 (Il2CppClass<MapGenerationController>)+B8]");
		nint num15 = 0;
		Quaternion rotation = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 33));
		Vector3 position2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 17));
		_ = quaternion.x;
		_ = _003CtileSpawnPosition_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v528 @ rcx_v22 (Il2CppStaticFields<MapGenerationController>)+1C]");
		_ = 0;
		GameObject gameObject2 = UnityEngine.Object.Instantiate(cryptExitOutside, position2, rotation);
		gameObject2.SetActive(value: true);
		RsgController rsgController3 = this.rsgController;
		RsgStart rsgStart = rsgController3._003CrsgStart_003Ek__BackingField;
		Vector3 position3 = rsgStart.spawnTransform.position;
		ref Vector3 reference = ref *(Vector3*)position3.x;
		_ = position3.z;
		RsgController rsgController4 = this.rsgController;
		RsgStart rsgStart2 = rsgController4._003CrsgStart_003Ek__BackingField;
		Vector3 forward2 = rsgStart2.spawnTransform.forward;
		ref Vector3 reference2 = ref *(Vector3*)forward2.x;
		_ = forward2.z;
	}

	private IEnumerator GenerateMap()
	{
		_003CGenerateMap_003Ed__39 obj = new _003CGenerateMap_003Ed__39(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}
}
