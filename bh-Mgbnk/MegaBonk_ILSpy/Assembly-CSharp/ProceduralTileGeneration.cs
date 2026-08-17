using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Assets.Scripts.MapGeneration.ProceduralTiles;
using Cpp2ILInjected;
using UnityEngine;

public class ProceduralTileGeneration : MonoBehaviour
{
	public int debugSeed;

	public GameObject stairsMesh;

	public GameObject flatTile;

	public GameObject slopeTile;

	public GameObject ceilingTile;

	public GameObject wallFlat;

	public GameObject wallLeftUp;

	public GameObject wallLeftDown;

	public GameObject wallLeftCross;

	public List<GameObject> tiles;

	public List<GameObject> flatTiles;

	public List<GameObject> fillTiles;

	public GameObject collider;

	private StageData currentStage;

	private MapParameters currentMapParameters;

	public StageData testStage;

	public MapParameters testMapParameters;

	public GameObject newRoot;

	public GameObject tilesParent;

	public ProceduralTile[][] proceduralTiles;

	public unsafe Vector3 Generate(out Vector3 firstTileDirection, StageData stageData, MapParameters mapParameters, bool useDebugSeed = false)
	{
		//IL_001d: Expected O, but got I4
		//IL_0096: Expected O, but got I4
		//IL_009f: Expected O, but got I4
		//IL_01e6: Expected O, but got I4
		//IL_00bb: Expected O, but got I4
		//IL_00e7: Expected O, but got I4
		//IL_0129: Expected I, but got O
		//IL_0139: Expected O, but got I
		//IL_015c: Expected O, but got I4
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_040f: Expected O, but got I4
		//IL_054b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0550: Expected O, but got Unknown
		//IL_06b6: Expected O, but got I4
		//IL_0704: Expected O, but got I4
		//IL_0731: Unknown result type (might be due to invalid IL or missing references)
		//IL_0736: Expected O, but got Unknown
		//IL_074d: Expected native int or pointer, but got O
		//IL_075b: Expected native int or pointer, but got O
		//IL_0777: Expected O, but got I4
		//IL_07c5: Expected O, but got I4
		//IL_0800: Unknown result type (might be due to invalid IL or missing references)
		//IL_0805: Expected O, but got Unknown
		//IL_081c: Expected native int or pointer, but got O
		StageData stageData2 = default(StageData);
		currentStage = stageData2;
		MapParameters mapParameters2 = default(MapParameters);
		currentMapParameters = mapParameters2;
		ClearTiles();
		bool flag = (object)mapParameters2 == null;
		List<object>.Enumerator enumerator = (List<object>.Enumerator)0;
		GameObject gameObject = null;
		ProceduralTileGeneration proceduralTileGeneration = this;
		if (!flag)
		{
			ProceduralTile[][] array = new ProceduralTile[mapParameters2.size][];
			proceduralTiles = array;
			List<GameObject> list = new List<GameObject>();
			tiles = list;
			List<GameObject> list2 = new List<GameObject>();
			flatTiles = list2;
			object obj = 0;
			object obj2 = 0;
			object obj3 = default(object);
			GameObject gameObject2 = default(GameObject);
			object obj4 = default(object);
			object arg = default(object);
			object arg2 = default(object);
			List<object>.Enumerator enumerator3 = default(List<object>.Enumerator);
			GameObject gameObject7 = default(GameObject);
			List<object>.Enumerator enumerator4 = default(List<object>.Enumerator);
			Vector3 vector = default(Vector3);
			while (true)
			{
				if ((nint)obj2 < mapParameters2.size)
				{
					ProceduralTile[][] array2 = proceduralTiles;
					gameObject = (GameObject)mapParameters2.size;
					ProceduralTile[] array3 = new ProceduralTile[mapParameters2.size];
					bool flag2 = proceduralTiles == null;
					enumerator = (List<object>.Enumerator)0;
					proceduralTileGeneration = (ProceduralTileGeneration)(object)typeof(ProceduralTile[]);
					if (flag2)
					{
						break;
					}
					if (array3 != null)
					{
						nint num = (nint)array2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v584 @ rdx_v73 (Il2CppClass<ProceduralTile[][]>)+40]");
						gameObject = (GameObject)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
						bool flag3 = obj3 == null;
						enumerator = (List<object>.Enumerator)0;
						proceduralTileGeneration = (ProceduralTileGeneration)(object)array3;
						if (flag3)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180269410");
							throw gameObject2;
						}
					}
					if ((nint)obj < array2.Length)
					{
						array2[obj] = array3;
						obj++;
						obj2 = obj;
						continue;
					}
					throw new IndexOutOfRangeException();
				}
				Stopwatch stopwatch = new Stopwatch();
				bool flag4 = stopwatch == null;
				enumerator = (List<object>.Enumerator)0;
				gameObject = null;
				proceduralTileGeneration = (ProceduralTileGeneration)(object)stopwatch;
				if (flag4)
				{
					break;
				}
				stopwatch.Start();
				int seed;
				if (obj4 == null)
				{
					int num2 = UnityEngine.Random.Range(0, 2147483647);
					seed = num2;
				}
				else
				{
					seed = debugSeed;
				}
				NodeTree nodeTree = Maze.Generate(mapParameters2.size, mapParameters2.size, seed);
				debugSeed = seed;
				MazeHeightGenerator.GenerateHeight(this, nodeTree, seed, mapParameters2);
				if (nodeTree != null && nodeTree._003Cchildren_003Ek__BackingField != null)
				{
					NodeTree nodeTree2 = nodeTree._003Cchildren_003Ek__BackingField.get_Item(0);
					if (nodeTree2 != null)
					{
						object obj5 = (object)nodeTree2._003Cposition_003Ek__BackingField >> 32;
						object obj6 = (object)nodeTree._003Cposition_003Ek__BackingField >> 32;
						GameObject gameObject3 = (GameObject)(obj5 - obj6);
						List<object>.Enumerator enumerator2 = (List<object>.Enumerator)(nodeTree2._003Cposition_003Ek__BackingField - nodeTree._003Cposition_003Ek__BackingField);
						ref Vector3 reference = ref *(Vector3*)enumerator2;
						_ = 0;
						stopwatch.Stop();
						long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
						string text = $"Path generation took {arg} ms.";
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
						stopwatch.Restart();
						FillHoles();
						stopwatch.Stop();
						long elapsedMilliseconds2 = stopwatch.ElapsedMilliseconds;
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
						string text2 = $"Rendering took {arg2} ms.";
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
						StageData stageData3 = currentStage;
						if ((object)currentStage != null)
						{
							bool flag5 = stageData3.mapEdgeFillType == MapEdgeFillType.Island;
							if (!flag5)
							{
								object obj7 = stageData3.mapEdgeFillType - 1;
								if (!flag5)
								{
									if ((nint)obj7 == 1)
									{
										FillEdgesTrees();
									}
								}
								else
								{
									FillEdgesWalls();
								}
							}
							else
							{
								FillEdgesIsland();
							}
							IEnumerable<object> source = Enumerable.Concat((IEnumerable<object>)tiles, (IEnumerable<object>)fillTiles);
							List<object> list3 = Enumerable.ToList(source);
							if (collider != null)
							{
								UnityEngine.Object.DestroyImmediate(collider);
							}
							GameObject gameObject4 = MeshColliderCombiner.CombineMeshes((List<GameObject>)(object)list3);
							collider = gameObject4;
							if (tilesParent != null)
							{
								UnityEngine.Object.DestroyImmediate(tilesParent);
							}
							GameObject gameObject5 = (tilesParent = new GameObject("Tiles Parent"));
							proceduralTileGeneration = (ProceduralTileGeneration)(this + 176);
							bool flag6 = list3 == null;
							GameObject gameObject6 = gameObject3;
							enumerator = enumerator2;
							stageData2 = (StageData)(object)mapParameters2;
							reference = ref *(Vector3*)null;
							gameObject = gameObject5;
							if (flag6)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
							reference = ref *(Vector3*)null;
							while (enumerator3.MoveNext())
							{
								if ((object)gameObject7 != null)
								{
									Transform transform = gameObject7.transform;
									if ((object)tilesParent != null)
									{
										Transform parentInternal = tilesParent.transform;
										if ((object)transform != null)
										{
											transform.parentInternal = parentInternal;
											reference = ref *(Vector3*)null;
											continue;
										}
										throw new NullReferenceException();
									}
									throw new NullReferenceException();
								}
								throw new NullReferenceException();
							}
							((List<GameObject>.Enumerator*)(&enumerator3))->Dispose();
							StaticBatchingUtility.Combine(tilesParent);
							proceduralTileGeneration = (ProceduralTileGeneration)nodeTree._003Cposition_003Ek__BackingField;
							MapParameters mapParameters3 = currentMapParameters;
							bool flag7 = (object)currentMapParameters == null;
							gameObject6 = gameObject7;
							enumerator = enumerator4;
							stageData2 = (StageData)(object)mapParameters2;
							gameObject = null;
							if (flag7)
							{
								break;
							}
							object obj8 = mapParameters3.scaledTileWidth * mapParameters3.size;
							object obj9 = obj8 >> 31;
							object obj10 = obj8 - obj9;
							object obj11 = obj10 >> 1;
							int num3 = mapParameters3.scaledTileWidth >> 31;
							object obj12 = mapParameters3.scaledTileWidth - num3;
							object obj13 = obj12 >> 1;
							object obj14 = obj13 - obj11;
							object obj15 = nodeTree._003Cposition_003Ek__BackingField * mapParameters3.scaledTileWidth;
							float x = (float)obj14 + (float)obj15;
							((Vector3*)(nint)vector)->x = x;
							((Vector3*)(nint)vector)->y = 0f;
							object obj16 = mapParameters3.scaledTileWidth * mapParameters3.size;
							object obj17 = obj16 >> 31;
							object obj18 = obj16 - obj17;
							object obj19 = obj18 >> 1;
							int num4 = mapParameters3.scaledTileWidth >> 31;
							object obj20 = mapParameters3.scaledTileWidth - num4;
							object obj21 = obj20 >> 1;
							object obj22 = obj21 - obj19;
							object obj23 = (object)nodeTree._003Cposition_003Ek__BackingField >> 32;
							object obj24 = obj23 * mapParameters3.scaledTileWidth;
							float z = (float)obj22 + (float)obj24;
							((Vector3*)(nint)vector)->z = z;
							return vector;
						}
					}
				}
				return (Vector3)new NullReferenceException();
			}
		}
		throw new NullReferenceException();
	}

	public unsafe Vector3 TilePositionToWorldPosition(Vector2Int pos)
	{
		//IL_0040: Expected O, but got I4
		//IL_0049: Expected native int or pointer, but got O
		//IL_009c: Expected O, but got I4
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Expected O, but got Unknown
		//IL_00ee: Expected O, but got I4
		//IL_013c: Expected O, but got I4
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Expected O, but got Unknown
		//IL_0180: Expected native int or pointer, but got O
		//IL_019c: Expected native int or pointer, but got O
		MapParameters mapParameters = currentMapParameters;
		if ((object)currentMapParameters != null)
		{
			object obj = mapParameters.scaledTileWidth * mapParameters.size;
			Vector3 vector = default(Vector3);
			((Vector3*)(nint)vector)->y = 0f;
			object obj2 = obj >> 31;
			object obj3 = obj - obj2;
			object obj4 = obj3 >> 1;
			int num = mapParameters.scaledTileWidth >> 31;
			object obj5 = mapParameters.scaledTileWidth - num;
			object obj6 = obj5 >> 1;
			object obj7 = obj6 - obj4;
			object obj8 = pos * mapParameters.scaledTileWidth;
			object obj9 = (object)pos >> 32;
			object obj10 = mapParameters.scaledTileWidth * mapParameters.size;
			object obj11 = obj10 >> 31;
			object obj12 = obj10 - obj11;
			object obj13 = obj12 >> 1;
			int num2 = mapParameters.scaledTileWidth >> 31;
			object obj14 = mapParameters.scaledTileWidth - num2;
			object obj15 = obj14 >> 1;
			object obj16 = obj15 - obj13;
			object obj17 = obj9 * mapParameters.scaledTileWidth;
			float x = (float)obj7 + (float)obj8;
			((Vector3*)(nint)vector)->x = x;
			float z = (float)obj16 + (float)obj17;
			((Vector3*)(nint)vector)->z = z;
			return vector;
		}
		return (Vector3)new NullReferenceException();
	}

	public void FillHoles()
	{
		//IL_007e: Expected O, but got I4
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected O, but got Unknown
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Expected O, but got Unknown
		//IL_00ee: Expected O, but got I4
		if (fillTiles != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
			List<object>.Enumerator enumerator = default(List<object>.Enumerator);
			UnityEngine.Object obj = default(UnityEngine.Object);
			while (enumerator.MoveNext())
			{
				UnityEngine.Object.DestroyImmediate(obj);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
		}
		List<GameObject> list = new List<GameObject>();
		fillTiles = list;
		MapParameters mapParameters = currentMapParameters;
		ProceduralTileGeneration proceduralTileGeneration = null;
		ProceduralTileGeneration proceduralTileGeneration2 = null;
		while ((nint)proceduralTileGeneration2 < mapParameters.size)
		{
			object obj2 = 0;
			while (true)
			{
				mapParameters = currentMapParameters;
				proceduralTileGeneration2 = (ProceduralTileGeneration)(proceduralTileGeneration + 1);
				if ((nint)obj2 >= mapParameters.size)
				{
					break;
				}
				FillHole((Vector2Int)proceduralTileGeneration, (Vector2Int)proceduralTileGeneration2);
				FillHole((Vector2Int)proceduralTileGeneration, (Vector2Int)proceduralTileGeneration);
				object obj3 = obj2 + 1;
				object obj4 = 0;
				obj2 = obj3;
			}
			proceduralTileGeneration = proceduralTileGeneration2;
		}
	}

	private unsafe void FillHole(Vector2Int pos1, Vector2Int pos2)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0020: Expected O, but got I4
		//IL_0056: Expected O, but got I
		//IL_0069: Expected O, but got I4
		//IL_00a0: Expected O, but got I4
		//IL_00cc: Expected O, but got I
		//IL_00df: Expected O, but got I4
		//IL_017f: Expected O, but got I
		//IL_01ba: Expected O, but got I
		//IL_01f0: Expected O, but got I
		//IL_020f: Unsupported input type for neg.
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Expected O, but got Unknown
		//IL_023c: Expected O, but got I
		//IL_0250: Expected O, but got I
		//IL_029f: Expected O, but got I4
		//IL_02af: Expected O, but got I
		//IL_02d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d9: Expected I4, but got Unknown
		//IL_0ac6: Unsupported input type for neg.
		//IL_0ac6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0acb: Expected O, but got Unknown
		//IL_0ae0: Expected O, but got I
		//IL_0af0: Expected O, but got I
		//IL_0367: Expected O, but got I4
		//IL_0382: Unsupported input type for neg.
		//IL_0382: Unknown result type (might be due to invalid IL or missing references)
		//IL_0387: Expected O, but got Unknown
		//IL_114d: Unsupported input type for neg.
		//IL_114d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1152: Expected O, but got Unknown
		//IL_06f2: Unsupported input type for neg.
		//IL_06f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f7: Expected O, but got Unknown
		//IL_1332: Unsupported input type for neg.
		//IL_1332: Unknown result type (might be due to invalid IL or missing references)
		//IL_1337: Expected O, but got Unknown
		//IL_0f3c: Unsupported input type for neg.
		//IL_0f3c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f41: Expected O, but got Unknown
		//IL_0f80: Expected O, but got I
		//IL_0fc0: Expected O, but got I
		//IL_0d17: Unsupported input type for neg.
		//IL_0d17: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d1c: Expected O, but got Unknown
		//IL_0d31: Expected O, but got I
		//IL_096a: Unsupported input type for neg.
		//IL_096a: Unknown result type (might be due to invalid IL or missing references)
		//IL_096f: Expected O, but got Unknown
		//IL_1032: Unsupported input type for neg.
		//IL_1032: Unknown result type (might be due to invalid IL or missing references)
		//IL_1037: Expected O, but got Unknown
		//IL_1076: Expected O, but got I
		//IL_10b6: Expected O, but got I
		//IL_1ec8: Expected O, but got I4
		//IL_0ca5: Expected O, but got I
		//IL_0b91: Expected O, but got I4
		//IL_0b5e: Expected O, but got I4
		//IL_077f: Unsupported input type for neg.
		//IL_077f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0784: Expected O, but got Unknown
		//IL_1662: Expected I, but got O
		//IL_056a: Expected O, but got I
		//IL_057a: Expected O, but got I
		//IL_059a: Expected O, but got I
		//IL_05aa: Expected O, but got I
		//IL_1c92: Expected O, but got I
		//IL_0bce: Expected O, but got I4
		//IL_1aef: Unsupported input type for neg.
		//IL_1aef: Unknown result type (might be due to invalid IL or missing references)
		//IL_1af4: Expected O, but got Unknown
		//IL_09f7: Unsupported input type for neg.
		//IL_09f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_09fc: Expected O, but got Unknown
		//IL_201d: Expected O, but got I
		//IL_18a7: Expected I, but got O
		//IL_1276: Expected O, but got I4
		//IL_1d26: Unsupported input type for neg.
		//IL_1d26: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d2b: Expected O, but got Unknown
		//IL_2030: Expected I, but got O
		//IL_1263: Expected O, but got I
		//IL_079e: Expected O, but got I
		//IL_145b: Expected O, but got I4
		//IL_20e4: Expected I, but got O
		//IL_0a16: Expected O, but got I
		//IL_1780: Expected O, but got I4
		//IL_0686: Expected O, but got I
		//IL_049a: Unknown result type (might be due to invalid IL or missing references)
		//IL_049f: Expected O, but got Unknown
		//IL_1448: Expected O, but got I
		//IL_1d0b: Expected O, but got I
		//IL_0c54: Expected O, but got I
		//IL_19c0: Expected O, but got I4
		//IL_08f4: Expected O, but got I
		//IL_07c7: Expected O, but got I4
		//IL_1b42: Expected O, but got I
		//IL_0c35: Expected O, but got I
		//IL_0a3f: Expected O, but got I4
		//IL_052b: Expected O, but got I4
		//IL_047c: Expected O, but got I4
		//IL_0e5c: Expected O, but got I
		//IL_2045: Expected O, but got I
		//IL_0699: Expected O, but got I4
		//IL_1579: Unknown result type (might be due to invalid IL or missing references)
		//IL_157e: Expected O, but got Unknown
		//IL_046e: Expected O, but got I4
		//IL_0e42: Expected O, but got I
		//IL_0c71: Expected O, but got I4
		//IL_0c7a: Expected O, but got I4
		//IL_0907: Expected O, but got I4
		//IL_20f9: Expected O, but got I
		//IL_1b79: Expected I4, but got O
		//IL_185a: Unknown result type (might be due to invalid IL or missing references)
		//IL_185f: Expected I4, but got Unknown
		//IL_0e79: Expected O, but got I4
		//IL_0e82: Expected O, but got I4
		//IL_209c: Expected O, but got I
		//IL_20a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_20aa: Expected O, but got Unknown
		//IL_1be6: Expected O, but got I
		//IL_1bef: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bf4: Expected O, but got Unknown
		//IL_1c2a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c2f: Expected I4, but got Unknown
		//IL_1a9f: Expected I4, but got O
		//IL_17fe: Expected O, but got I
		//IL_1807: Unknown result type (might be due to invalid IL or missing references)
		//IL_180c: Expected O, but got Unknown
		//IL_181c: Expected O, but got I
		//IL_173f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1744: Expected I4, but got Unknown
		//IL_1d8c: Expected I4, but got O
		//IL_1a3e: Expected O, but got I
		//IL_1a47: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a4c: Expected O, but got Unknown
		//IL_1a5c: Expected O, but got I
		//IL_197f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1984: Expected I4, but got Unknown
		//IL_16eb: Expected O, but got I
		//IL_16f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_16f9: Expected O, but got Unknown
		//IL_1709: Expected O, but got I
		//IL_2158: Expected O, but got I
		//IL_2161: Unknown result type (might be due to invalid IL or missing references)
		//IL_2166: Expected O, but got Unknown
		//IL_1e01: Expected O, but got I
		//IL_1e0a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e0f: Expected O, but got Unknown
		//IL_1e3d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e42: Expected I4, but got Unknown
		//IL_192b: Expected O, but got I
		//IL_1934: Unknown result type (might be due to invalid IL or missing references)
		//IL_1939: Expected O, but got Unknown
		//IL_1949: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		MapParameters mapParameters = currentMapParameters;
		object obj3 = mapParameters.size - 1;
		if (System.Runtime.CompilerServices.Unsafe.As<Vector2Int, UIntPtr>(ref pos1) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
		{
			return;
		}
		MapParameters mapParameters2 = currentMapParameters;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+73]");
		object obj4 = 0;
		object obj5 = mapParameters2.size - 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+73]");
		if (0 > (nint)obj5)
		{
			return;
		}
		object obj6 = mapParameters2.size - 1;
		if (System.Runtime.CompilerServices.Unsafe.As<Vector2Int, UIntPtr>(ref pos2) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6))
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+7B]");
		object obj7 = 0;
		object obj8 = mapParameters2.size - 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+7B]");
		if (0 > (nint)obj8)
		{
			return;
		}
		ProceduralTile[][] array = proceduralTiles;
		ProceduralTile[] array2 = array[(object)pos1];
		ProceduralTile[] array3 = array[(object)pos2];
		ProceduralTile proceduralTile = array2[obj4];
		_ = 0;
		object obj9 = pos2 - pos1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+7B]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+73]");
		object obj10 = num - 0;
		ProceduralTile proceduralTile2 = array3[obj7];
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-31]");
		object obj11 = (nint)0 >> 32;
		_ = array3[obj7];
		ProceduralTile proceduralTile3 = array2[obj4];
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+6F]");
		TileEdge edge = proceduralTile3.GetEdge((Vector2Int)0);
		object obj12 = pos1 - pos2;
		object obj13 = 0 - obj11;
		ProceduralTile proceduralTile4 = array3[obj7];
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+6F]");
		TileEdge tileEdge = proceduralTile4.GetEdge((Vector2Int)0);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-51]");
		object obj14 = 0;
		bool flag = tileEdge == null;
		int posY = proceduralTile.posY;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v506 @ r10_v5+18]");
		int num2 = (int)((nint)posY + (nint)0);
		object obj15 = proceduralTile2.posY + tileEdge.offsetHeight;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-31]");
		object obj16 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-31]");
		_ = 0;
		_ = 0;
		int num3 = obj15 - num2;
		bool useEdgeTexture;
		Vector2Int vector2Int = default(Vector2Int);
		Vector2Int globalDirection = default(Vector2Int);
		EFillType fillType = default(EFillType);
		bool flip = default(bool);
		object obj25;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v506 @ r10_v5+1C]");
			if ((nint)0 == 0 && tileEdge.type == ETileEdgeType.Flat)
			{
				if (num3 < 0)
				{
					object obj17 = num2 - 1;
					object obj18 = pos1 - pos2;
					object obj19 = 0 - obj11;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-41]");
				useEdgeTexture = false;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-41]");
				_ = 0;
				int num4 = -num3;
				_ = 0;
				if (num3 < 0)
				{
					num4 = num3;
				}
				object obj20 = default(object);
				object obj24 = default(object);
				int num14 = default(int);
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-59]");
					nint num5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-39]");
					if (num5 >= 0)
					{
						break;
					}
					float num6 = ((num3 < 0) ? (-1f) : 1f);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-59]");
					float num7 = 0f * num6;
					float num8 = num7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-49]");
					float num9 = num8 + 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm1\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-59]");
					object obj21;
					object obj22;
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180418B20");
						if ((nint)obj20 > 1)
						{
							int num10 = num3 ^ num3;
							int num11 = num3 & num10;
							bool flag2 = num11 < 0;
							bool flag3 = num3 < 0;
							bool flag4 = num3 == 0;
							bool flag5 = flag3 == flag2;
							bool flag6 = !flag4;
							obj21 = flag6 & flag5;
							goto IL_1570;
						}
						obj22 = 3;
					}
					else
					{
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180418B20");
						object obj23 = obj24 - 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-59]");
						if (0 == (nint)obj23)
						{
							int num12 = num3 ^ num3;
							int num13 = num3 & num12;
							bool flag7 = num13 < 0;
							bool flag8 = num3 < 0;
							bool flag9 = num3 == 0;
							bool flag10 = flag8 != flag7;
							obj21 = flag10 | flag9;
							goto IL_1570;
						}
					}
					goto IL_158d;
					IL_158d:
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+67]");
					num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-31]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-29]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+67]");
					InstantiateFillTile(pos1, 0, wallFlat, vector2Int, globalDirection, fillType, flip, useEdgeTexture);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-59]");
					_ = (nint)0 + (nint)1;
					num4 = num14;
					continue;
					IL_1570:
					obj22 = obj21 + 1;
					goto IL_158d;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-29]");
				obj25 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-31]");
				obj16 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+67]");
				num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-11]");
				tileEdge = (TileEdge)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-51]");
				obj14 = 0;
				goto IL_160c;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-41]");
		useEdgeTexture = false;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-41]");
		_ = 0;
		obj25 = obj11;
		goto IL_160c;
		IL_1879:
		GameObject gameObject = default(GameObject);
		if (num3 < 0)
		{
			_ = 1;
			object obj26 = pos1 - pos2;
			gameObject = (GameObject)(0 - obj25);
		}
		else
		{
			_ = 3;
			if (num3 <= 0 && num3 >= 0)
			{
				goto IL_1fcd;
			}
			if (num3 < 0)
			{
				object obj27 = pos1 - pos2;
				gameObject = (GameObject)(0 - obj25);
			}
		}
		goto IL_1899;
		IL_1f2a:
		int height;
		FillWallSlopToSlop(num3, pos1, height, vector2Int);
		return;
		IL_20d6:
		nint num15 = (nint)typeof(Math);
		int num16 = -num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2237 @ rcx_v52 (Il2CppClass<System.Math>)+E4]");
		if ((nint)0 < (nint)0)
		{
			num16 = num3;
		}
		object obj28;
		if (num3 < 0)
		{
			num16--;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+67]");
			obj28 = -1;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+6F]");
			obj28 = 0;
		}
		object obj30;
		object obj31;
		GameObject gameObject2;
		if (num16 > 0)
		{
			bool flag11 = num3 < 0;
			object obj29 = 0;
			obj30 = 0;
			obj31 = obj28;
			if (!flag11)
			{
				goto IL_1e2b;
			}
			GameObject gameObject3 = default(GameObject);
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
				int height2 = obj28 - (object)gameObject2;
				if (obj29 == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-31]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-29]");
				_ = 0;
				GameObject tilePrefab = wallFlat;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-51]");
				InstantiateFillTile(pos1, height2, tilePrefab, vector2Int, globalDirection, fillType, flip, useEdgeTexture: false);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+6F]");
				obj28 = 0;
				obj29++;
				bool flag12 = (nint)obj29 < num16;
				gameObject2 = gameObject3;
				if (flag12)
				{
					continue;
				}
				goto IL_0e9d;
			}
			goto IL_1da7;
		}
		goto IL_20e9;
		IL_1e5d:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+67]");
		int height3 = (int)((nint)0 + (nint)num3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-29]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-31]");
		_ = 0;
		GameObject gameObject4 = default(GameObject);
		GameObject tilePrefab2 = gameObject4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-51]");
		InstantiateFillTile(pos1, height3, tilePrefab2, vector2Int, globalDirection, fillType, flip, useEdgeTexture: false);
		object obj32 = num3 + 1;
		if ((nint)obj32 > 2)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+67]");
			height = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-31]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-29]");
			_ = 0;
			goto IL_1f2a;
		}
		return;
		IL_1ab9:
		if (num3 > 0)
		{
			object obj33 = 1;
			goto IL_2022;
		}
		if (num3 < 0)
		{
			object obj33 = 3;
			goto IL_1ad9;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-31]");
		object obj34 = 0;
		goto IL_1c4a;
		IL_0e9d:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-49]");
		int num17 = 0;
		goto IL_20e9;
		IL_10ea:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v506 @ r10_v5+1C]");
		if ((nint)0 == 1 && tileEdge.type == ETileEdgeType.SlopeRight)
		{
			object obj35 = pos1 - pos2;
			object obj36 = 0 - obj25;
			bool flag13 = num3 < 0;
			GameObject gameObject5;
			UnityEngine.Object obj37;
			if (num3 != 0)
			{
				if (!flag13)
				{
					gameObject5 = wallLeftUp;
					obj37 = wallLeftDown;
				}
				else
				{
					gameObject5 = wallLeftDown;
					obj37 = wallLeftUp;
				}
			}
			else
			{
				gameObject5 = wallLeftCross;
				obj37 = null;
			}
			int height4 = num2;
			GameObject tilePrefab3 = gameObject5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-31]");
			InstantiateFillTile(pos1, height4, tilePrefab3, vector2Int, globalDirection, fillType, flip, useEdgeTexture: false);
			if (obj37 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+67]");
				int height5 = (int)((nint)0 + (nint)num3);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-31]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-29]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+6F]");
				nint num18 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-21]");
				InstantiateFillTile(pos1, height5, (GameObject)num18, vector2Int, globalDirection, fillType, flip, useEdgeTexture: false);
			}
			object obj38 = num3 + 1;
			if ((nint)obj38 > 2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-31]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-29]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+67]");
				height = 0;
				goto IL_1f2a;
			}
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v506 @ r10_v5+1C]");
		if ((nint)0 != 2 || tileEdge.type != ETileEdgeType.SlopeLeft)
		{
			return;
		}
		object obj39 = pos1 - pos2;
		object obj40 = 0 - obj25;
		GameObject gameObject6;
		UnityEngine.Object obj41;
		GameObject gameObject7;
		if (num3 != 0)
		{
			if (num3 <= 0)
			{
				gameObject6 = wallLeftDown;
				obj41 = wallLeftUp;
				goto IL_1f45;
			}
			gameObject6 = wallLeftUp;
			gameObject7 = wallLeftDown;
		}
		else
		{
			gameObject6 = wallLeftCross;
			gameObject7 = null;
		}
		obj41 = gameObject7;
		goto IL_1f45;
		IL_1899:
		GameObject gameObject8 = default(GameObject);
		while (true)
		{
			nint num19 = (nint)typeof(Math);
			int num20 = -num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1675 @ rcx_v95 (Il2CppClass<System.Math>)+E4]");
			if ((nint)0 < (nint)0)
			{
				num20 = num3;
			}
			object obj42;
			object obj43;
			if (num3 < 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+67]");
				obj42 = -1;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-59]");
				obj42 = 0;
				if (num3 > 0)
				{
					obj43 = 1;
					goto IL_19c5;
				}
			}
			obj43 = 0;
			goto IL_19c5;
			IL_19c5:
			if ((nint)obj43 >= num20)
			{
				break;
			}
			object obj44 = num20 - 1;
			if (num3 >= 0)
			{
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r8d,xmm0\"");
					num2 += obj42;
					if (obj43 != obj44)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-31]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-29]");
						_ = 0;
						int height6 = num2;
						GameObject tilePrefab4 = wallFlat;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-51]");
						InstantiateFillTile(pos1, height6, tilePrefab4, vector2Int, globalDirection, fillType, flip, useEdgeTexture: false);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-59]");
						obj42 = 0;
						obj43++;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-39]");
						obj44 = 0;
						object obj45 = obj43;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-49]");
						if ((nint)obj45 < 0)
						{
							continue;
						}
						goto IL_0a4e;
					}
					break;
				}
				continue;
			}
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
				int height7 = obj42 - (object)gameObject;
				if (obj43 == obj44)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-31]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-29]");
				_ = 0;
				GameObject tilePrefab5 = wallFlat;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-51]");
				InstantiateFillTile(pos1, height7, tilePrefab5, vector2Int, globalDirection, fillType, flip, useEdgeTexture: false);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-59]");
				obj42 = 0;
				obj43++;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-39]");
				obj44 = 0;
				object obj46 = obj43;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-49]");
				bool flag14 = (nint)obj46 < 0;
				gameObject = gameObject8;
				if (flag14)
				{
					continue;
				}
				goto IL_0a4e;
			}
			goto IL_1ab9;
			IL_0a4e:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-19]");
			useEdgeTexture = false;
			break;
		}
		goto IL_1fcd;
		IL_1b94:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-29]");
		_ = 0;
		int height8 = num2;
		GameObject tilePrefab6 = wallFlat;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-51]");
		InstantiateFillTile(pos1, height8, tilePrefab6, vector2Int, globalDirection, fillType, flip, useEdgeTexture: false);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-59]");
		object obj47 = 0;
		object obj48 = obj48 + 1;
		object obj49 = obj48;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-49]");
		if ((nint)obj49 < 0)
		{
			goto IL_1c18;
		}
		goto IL_2035;
		IL_1654:
		int num23 = default(int);
		while (true)
		{
			nint num21 = (nint)typeof(Math);
			int num22 = -num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1438 @ rcx_v111 (Il2CppClass<System.Math>)+E4]");
			if ((nint)0 < (nint)0)
			{
				num22 = num3;
			}
			object obj50;
			object obj51;
			if (num3 < 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+67]");
				obj50 = -1;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-59]");
				obj50 = 0;
				if (num3 > 0)
				{
					obj51 = 1;
					goto IL_1785;
				}
			}
			obj51 = 0;
			goto IL_1785;
			IL_1785:
			if ((nint)obj51 >= num22)
			{
				break;
			}
			object obj52 = num22 - 1;
			if (num3 >= 0)
			{
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r8d,xmm0\"");
					num2 += obj50;
					if (obj51 != obj52)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-31]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-29]");
						_ = 0;
						int height9 = num2;
						GameObject tilePrefab7 = wallFlat;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-51]");
						InstantiateFillTile(pos1, height9, tilePrefab7, vector2Int, globalDirection, fillType, flip, useEdgeTexture: false);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-59]");
						obj50 = 0;
						obj51++;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-39]");
						obj52 = 0;
						object obj53 = obj51;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-49]");
						if ((nint)obj53 < 0)
						{
							continue;
						}
						goto IL_07d6;
					}
					break;
				}
				continue;
			}
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
				int height10 = obj50 - num22;
				if (obj51 == obj52)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-31]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-29]");
				_ = 0;
				GameObject tilePrefab8 = wallFlat;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-51]");
				InstantiateFillTile(pos1, height10, tilePrefab8, vector2Int, globalDirection, fillType, flip, useEdgeTexture: false);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-59]");
				obj50 = 0;
				obj51++;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-39]");
				obj52 = 0;
				object obj54 = obj51;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-49]");
				bool flag15 = (nint)obj54 < 0;
				num22 = num23;
				if (flag15)
				{
					continue;
				}
				goto IL_07d6;
			}
			goto IL_1879;
			IL_07d6:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-19]");
			useEdgeTexture = false;
			break;
		}
		goto IL_1fcd;
		IL_2035:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-29]");
		obj25 = 0;
		goto IL_1c4a;
		IL_1c4a:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-39]");
		nint num24 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-41]");
		nint num25 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-19]");
		InstantiateFillTile(pos1, (int)num24, (GameObject)num25, vector2Int, globalDirection, fillType, flip, useEdgeTexture: false);
		return;
		IL_1fcd:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-31]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-29]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+67]");
		nint num26 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-21]");
		InstantiateFillTile(pos1, (int)num26, (GameObject)0, vector2Int, globalDirection, fillType, flip, useEdgeTexture);
		return;
		IL_160c:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v506 @ r10_v5+1C]");
		if ((nint)0 == 2 && tileEdge.type == ETileEdgeType.Flat)
		{
			if (num3 > 0)
			{
				_ = wallLeftUp;
				if (num3 > 1)
				{
					_ = 2;
					_ = wallLeftUp;
					goto IL_1654;
				}
			}
			else
			{
				_ = wallLeftDown;
			}
			if (num3 < 0)
			{
				_ = 1;
				object obj55 = pos1 - pos2;
				object obj56 = 0 - obj25;
			}
			else
			{
				_ = 3;
				if (num3 <= 0 && num3 >= 0)
				{
					goto IL_1fcd;
				}
				if (num3 < 0)
				{
					object obj57 = pos1 - pos2;
					object obj58 = 0 - obj25;
				}
			}
			goto IL_1654;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v506 @ r10_v5+1C]");
		if ((nint)0 == 1 && tileEdge.type == ETileEdgeType.Flat)
		{
			if (num3 > 0)
			{
				gameObject = wallLeftUp;
				_ = wallLeftUp;
				if (num3 > 1)
				{
					_ = 2;
					_ = wallLeftUp;
					goto IL_1899;
				}
			}
			else
			{
				gameObject = wallLeftDown;
				_ = wallLeftDown;
			}
			goto IL_1879;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v506 @ r10_v5+1C]");
		object obj62 = default(object);
		if ((nint)0 == 0)
		{
			if (tileEdge.type == ETileEdgeType.SlopeLeft)
			{
				object obj59 = pos1 - pos2;
				object obj60 = 0 - obj25;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-21]");
				object obj61 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v837 @ rax_v111+38]");
				obj62 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v837 @ rax_v111+38]");
				_ = 0;
				if (num3 < 0)
				{
					GameObject gameObject9 = wallLeftUp;
					_ = wallLeftUp;
					if (num3 < -1)
					{
						_ = wallLeftUp;
						object obj33 = 2;
						goto IL_1ad9;
					}
				}
				else
				{
					GameObject gameObject9 = wallLeftDown;
					_ = wallLeftDown;
				}
				goto IL_1ab9;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v506 @ r10_v5+1C]");
			if ((nint)0 == 0 && tileEdge.type == ETileEdgeType.SlopeRight)
			{
				object obj63 = pos1 - pos2;
				object obj64 = 0 - obj25;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-21]");
				object obj65 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1163 @ rax_v79+38]");
				num17 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1163 @ rax_v79+38]");
				_ = 0;
				gameObject2 = ((num3 >= 0) ? wallLeftDown : wallLeftUp);
				if (num3 >= -1)
				{
					if (num3 > 0)
					{
						goto IL_20d6;
					}
					if (num3 >= 0)
					{
						goto IL_1cc3;
					}
				}
				object obj66 = pos1 - pos2;
				gameObject2 = (GameObject)(0 - obj25);
				goto IL_20d6;
			}
		}
		if (num3 == 0)
		{
			goto IL_10ea;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v506 @ r10_v5+1C]");
		if ((nint)0 == 1 && tileEdge.type == ETileEdgeType.SlopeLeft)
		{
			object obj67 = pos1 - pos2;
			object obj68 = 0 - obj25;
			int num27 = num3 >> 63;
			int num28 = num27 & 8;
			int num29 = num27 & -8;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1189 @ rax_v72 (System.Int32)+58+this @ rcx (ProceduralTileGeneration)]");
			gameObject4 = (GameObject)0;
			int height11 = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1188 @ r9_v34 (System.Int32)+50+this @ rcx (ProceduralTileGeneration)]");
			nint num30 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+6F]");
			InstantiateFillTile(pos1, height11, (GameObject)num30, vector2Int, globalDirection, fillType, flip, useEdgeTexture: false);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v506 @ r10_v5+1C]");
			if ((nint)0 != 2 || tileEdge.type != ETileEdgeType.SlopeRight)
			{
				goto IL_10ea;
			}
			object obj69 = pos1 - pos2;
			object obj70 = 0 - obj25;
			int num31 = num3 >> 63;
			int num32 = num31 & 8;
			int num33 = num31 & -8;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1599 @ rax_v64 (System.Int32)+58+this @ rcx (ProceduralTileGeneration)]");
			gameObject4 = (GameObject)0;
			int height12 = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1598 @ r9_v30 (System.Int32)+50+this @ rcx (ProceduralTileGeneration)]");
			nint num34 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+6F]");
			InstantiateFillTile(pos1, height12, (GameObject)num34, vector2Int, globalDirection, fillType, flip, useEdgeTexture: false);
		}
		goto IL_1e5d;
		IL_1f45:
		int height13 = num2;
		GameObject tilePrefab9 = gameObject6;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-51]");
		InstantiateFillTile(pos1, height13, tilePrefab9, vector2Int, globalDirection, fillType, flip, useEdgeTexture: false);
		if (obj41 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+67]");
			int height14 = (int)((nint)0 + (nint)num3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-31]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-29]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+6F]");
			nint num35 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-21]");
			InstantiateFillTile(pos1, height14, (GameObject)num35, vector2Int, globalDirection, fillType, flip, useEdgeTexture: false);
		}
		object obj71 = num3 + 1;
		if ((nint)obj71 > 2)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-31]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-29]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+67]");
			height = 0;
			goto IL_1f2a;
		}
		return;
		IL_1c18:
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r8d,xmm0\"");
		num2 += obj47;
		if (obj48 != null)
		{
			goto IL_1b94;
		}
		goto IL_1c4a;
		IL_2022:
		nint num36 = (nint)typeof(Math);
		int num37 = -num3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1863 @ rcx_v79 (Il2CppClass<System.Math>)+E4]");
		if ((nint)0 < (nint)0)
		{
			num37 = num3;
		}
		object obj72;
		if (num3 < 0)
		{
			num37--;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+67]");
			obj72 = -1;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-59]");
			obj72 = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-31]");
		obj34 = 0;
		if (num37 > 0)
		{
			bool flag16 = num3 < 0;
			object obj73 = 0;
			obj48 = 0;
			obj47 = obj72;
			if (!flag16)
			{
				goto IL_1c18;
			}
			object obj75 = default(object);
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
				int height15 = obj72 - obj62;
				if (obj73 == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-29]");
				_ = 0;
				GameObject tilePrefab10 = wallFlat;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-51]");
				InstantiateFillTile(pos1, height15, tilePrefab10, vector2Int, globalDirection, fillType, flip, useEdgeTexture: false);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-59]");
				obj72 = 0;
				obj73++;
				object obj74 = obj73;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-49]");
				bool flag17 = (nint)obj74 < 0;
				obj62 = obj75;
				if (flag17)
				{
					continue;
				}
				goto IL_2035;
			}
			goto IL_1b94;
		}
		goto IL_2035;
		IL_1ad9:
		object obj76 = pos1 - pos2;
		obj62 = 0 - obj25;
		goto IL_2022;
		IL_1cc3:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-31]");
		_ = 0;
		int height16 = num17;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-21]");
		nint num38 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-41]");
		InstantiateFillTile(pos1, height16, (GameObject)num38, vector2Int, globalDirection, fillType, flip, useEdgeTexture: false);
		return;
		IL_1e2b:
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r8d,xmm0\"");
		num2 += obj31;
		if (obj30 != null)
		{
			goto IL_1da7;
		}
		goto IL_1e5d;
		IL_1da7:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-31]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-29]");
		_ = 0;
		int height17 = num2;
		GameObject tilePrefab11 = wallFlat;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-51]");
		InstantiateFillTile(pos1, height17, tilePrefab11, vector2Int, globalDirection, fillType, flip, useEdgeTexture: false);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1+6F]");
		obj31 = 0;
		obj30++;
		if ((nint)obj30 >= num16)
		{
			goto IL_0e9d;
		}
		goto IL_1e2b;
		IL_20e9:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rbp_v1-29]");
		obj25 = 0;
		goto IL_1cc3;
	}

	private void FillWallSlopeToFlat(int heightDifference, Vector2Int position, int height, Vector2Int globalDir, bool isFirstPieceSloped, bool useEdgeTextures = false)
	{
		//IL_002e: Expected O, but got I4
		//IL_003b: Unsupported input type for neg.
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected O, but got Unknown
		//IL_03ba: Expected I, but got O
		//IL_00fc: Expected O, but got I4
		//IL_00c5: Expected O, but got I4
		//IL_0121: Expected O, but got I4
		//IL_014d: Expected I4, but got O
		//IL_00dc: Expected O, but got I4
		//IL_0383: Unknown result type (might be due to invalid IL or missing references)
		//IL_0388: Expected O, but got Unknown
		//IL_0216: Expected O, but got I4
		//IL_02f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fa: Expected O, but got Unknown
		//IL_0171: Expected O, but got I4
		bool flag = default(bool);
		bool flag2 = default(bool);
		Vector2Int vector2Int;
		bool useEdgeTexture;
		if (heightDifference < 0)
		{
			object obj = (flag ? 1 : 0) >> 32;
			flag2 = (byte)(0u - (flag ? 1u : 0u)) != 0;
			vector2Int = (Vector2Int)(0 - obj);
			useEdgeTexture = flag2;
		}
		else
		{
			useEdgeTexture = flag;
			vector2Int = position;
		}
		nint num = (nint)typeof(Math);
		int num2 = -heightDifference;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rcx_v2 (Il2CppClass<System.Math>)+E4]");
		if ((nint)0 < (nint)0)
		{
			num2 = heightDifference;
		}
		int num3 = height - 1;
		if (heightDifference >= 0)
		{
			num3 = height;
		}
		object obj2 = default(object);
		object obj3;
		if (obj2 != null)
		{
			bool flag3 = heightDifference < 1;
			obj3 = 0;
			if (!flag3)
			{
				obj3 = 1;
			}
		}
		else
		{
			bool flag4 = heightDifference >= 0;
			obj3 = 0;
			if (!flag4)
			{
				num2--;
				obj3 = 0;
			}
		}
		if ((nint)obj3 >= num2)
		{
			return;
		}
		bool flag5 = heightDifference < 0;
		object obj4 = obj3;
		int num4 = num3;
		int num5 = (int)vector2Int;
		object obj5 = obj3;
		Vector2Int direction = default(Vector2Int);
		Vector2Int globalDirection = default(Vector2Int);
		EFillType fillType = default(EFillType);
		bool flip = default(bool);
		if (flag5)
		{
			bool flag6;
			bool flag7 = default(bool);
			do
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
				int height2 = num3 - (flag2 ? 1 : 0);
				if (obj2 != null)
				{
					object obj6 = num2 - 1;
					if (obj4 == obj6)
					{
						goto IL_0352;
					}
				}
				if (obj2 == null && obj4 == obj3)
				{
					break;
				}
				goto IL_0352;
				IL_0352:
				InstantiateFillTile(position, height2, wallFlat, direction, globalDirection, fillType, flip, useEdgeTexture);
				obj4++;
				flag6 = (nint)obj4 < num2;
				flag2 = flag7;
			}
			while (flag6);
			return;
		}
		bool flag8;
		do
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r8d,xmm0\"");
			num5 += num4;
			if (obj2 != null)
			{
				object obj7 = num2 - 1;
				if (obj5 == obj7)
				{
					goto IL_02c4;
				}
			}
			if (obj2 == null && obj5 == obj3)
			{
				break;
			}
			goto IL_02c4;
			IL_02c4:
			InstantiateFillTile(position, num5, wallFlat, direction, globalDirection, fillType, flip, useEdgeTexture);
			obj5++;
			flag8 = (nint)obj5 < num2;
			num4 = num3;
		}
		while (flag8);
	}

	private void FillWallSlopToSlop(int heightDifference, Vector2Int position, int height, Vector2Int globalDir)
	{
		//IL_0152: Expected I, but got O
		//IL_00b5: Expected O, but got I4
		//IL_00cd: Expected O, but got I4
		//IL_00d5: Expected I4, but got O
		//IL_00de: Expected O, but got I4
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Expected I4, but got Unknown
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Expected O, but got Unknown
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f7: Expected I4, but got Unknown
		//IL_0228: Unknown result type (might be due to invalid IL or missing references)
		//IL_022d: Expected O, but got Unknown
		bool flag = heightDifference < 0;
		int num = heightDifference + 1;
		if (!flag)
		{
			num = heightDifference;
		}
		int num2 = num - 1;
		if (num <= 0)
		{
			num2 = num;
		}
		if (num2 >= 0)
		{
		}
		bool flag2 = num2 >= 0;
		bool flag3 = default(bool);
		bool useEdgeTexture = flag3;
		if (!flag2)
		{
			num = 0 - (flag3 ? 1 : 0);
			useEdgeTexture = (byte)num != 0;
		}
		nint num3 = (nint)typeof(Math);
		int num4 = -num2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ rcx_v3 (Il2CppClass<System.Math>)+E4]");
		if ((nint)0 < (nint)0)
		{
			num4 = num2;
		}
		if (num4 <= 0)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm6\"");
		object obj = height + num;
		bool flag4 = num2 < 0;
		object obj2 = 0;
		int num5 = (int)position;
		object obj3 = 0;
		Vector2Int direction = default(Vector2Int);
		Vector2Int globalDirection = default(Vector2Int);
		EFillType fillType = default(EFillType);
		bool flip = default(bool);
		if (flag4)
		{
			do
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
				int height2 = obj - num;
				InstantiateFillTile(position, height2, wallFlat, direction, globalDirection, fillType, flip, useEdgeTexture);
				obj2++;
			}
			while ((nint)obj2 < num4);
		}
		else
		{
			do
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r8d,xmm0\"");
				num5 += obj;
				InstantiateFillTile(position, num5, wallFlat, direction, globalDirection, fillType, flip, useEdgeTexture);
				obj3++;
			}
			while ((nint)obj3 < num4);
		}
	}

	public unsafe GameObject InstantiateTile(Vector2Int pos, int height, GameObject tilePrefab, Vector3 direction, Vector3 parentDir)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0bff: Expected O, but got I4
		//IL_0024: Expected O, but got I4
		//IL_0036: Expected O, but got I4
		//IL_0084: Expected O, but got I4
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Expected O, but got Unknown
		//IL_00c8: Expected O, but got I4
		//IL_0123: Expected O, but got I4
		//IL_0158: Expected O, but got I
		//IL_0c2a: Expected O, but got I
		//IL_0d8e: Expected I, but got O
		//IL_0db7: Expected O, but got I
		//IL_0d69: Expected O, but got Ref
		//IL_0c46: Expected I, but got O
		//IL_0c87: Expected O, but got I
		//IL_0ca4: Expected O, but got I
		//IL_0cee: Invalid comparison between F4 and O
		//IL_0d0d: Invalid comparison between F4 and I4
		//IL_0d36: Expected O, but got I4
		//IL_01c1: Expected O, but got Ref
		//IL_01cf: Expected O, but got Ref
		//IL_01a9: Expected O, but got I
		//IL_02b3: Expected O, but got I
		//IL_02ee: Expected I, but got O
		//IL_02fe: Expected O, but got I
		//IL_0317: Expected O, but got I
		//IL_0380: Expected O, but got I
		//IL_039a: Unknown result type (might be due to invalid IL or missing references)
		//IL_039f: Expected O, but got Unknown
		//IL_0416: Expected O, but got I
		//IL_044c: Expected O, but got I
		//IL_048b: Expected O, but got I
		//IL_04e0: Expected O, but got I
		//IL_0559: Expected O, but got I4
		//IL_0586: Expected O, but got I
		//IL_05ab: Expected O, but got I4
		//IL_0616: Expected O, but got I4
		//IL_0679: Expected O, but got I
		//IL_06dc: Expected O, but got I4
		//IL_0707: Expected O, but got I4
		//IL_0743: Expected O, but got I4
		//IL_078b: Expected O, but got I4
		//IL_07b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_07bb: Expected O, but got Unknown
		//IL_07d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d5: Expected O, but got Unknown
		//IL_07ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ef: Expected O, but got Unknown
		//IL_0808: Expected O, but got I4
		//IL_0831: Expected O, but got Ref
		//IL_0874: Expected O, but got I4
		//IL_08af: Expected O, but got I4
		//IL_08e6: Expected O, but got I
		//IL_09c4: Expected O, but got Ref
		//IL_09d2: Expected O, but got Ref
		//IL_0a62: Expected O, but got I4
		//IL_0e03: Expected O, but got I4
		//IL_0e0c: Expected O, but got I4
		//IL_0ab2: Expected I, but got O
		//IL_0ac0: Expected O, but got Ref
		//IL_0b1b: Expected O, but got I4
		//IL_0b21: Expected O, but got I
		//IL_0b5c: Expected O, but got I4
		//IL_0b90: Expected O, but got I4
		//IL_0bc5: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		MapParameters mapParameters = currentMapParameters;
		bool flag = (object)currentMapParameters == null;
		Quaternion quaternion = (Quaternion)height;
		Vector3 vector = (Vector3)pos;
		GameObject gameObject = (GameObject)(object)this;
		if (flag)
		{
			goto IL_0bcf;
		}
		object obj3 = mapParameters.scaledTileWidth * mapParameters.size;
		object obj4 = height * mapParameters.scaledTileHeight;
		object obj5 = obj3 >> 31;
		object obj6 = obj3 - obj5;
		object obj7 = obj6 >> 1;
		int num = mapParameters.scaledTileWidth >> 31;
		object obj8 = mapParameters.scaledTileWidth - num;
		object obj9 = obj8 >> 1;
		object obj10 = obj9 - obj7;
		object obj11 = pos * mapParameters.scaledTileWidth;
		object obj12 = mapParameters.scaledTileWidth * mapParameters.size;
		object obj13 = obj12 >> 31;
		object obj14 = obj12 - obj13;
		object obj15 = obj14 >> 1;
		object obj16 = obj10 + obj11;
		int num2 = mapParameters.scaledTileWidth >> 31;
		object obj17 = mapParameters.scaledTileWidth - num2;
		object obj18 = obj17 >> 1;
		object obj19 = obj18 - obj15;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1+5B]");
		object obj20 = (nint)0 * (nint)mapParameters.scaledTileWidth;
		object obj21 = obj19 + obj20;
		bool flag2 = tilePrefab == flatTile;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1+6F]");
		object obj22 = 0;
		Vector3 vector2;
		object obj32;
		if (!flag2)
		{
			nint num3 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v614 @ rax_v93 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num4 = 0;
			_ = Vector3.zeroVector;
			object obj23 = obj22 - (object)Vector3.zeroVector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1-4D]");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1-3D]");
			object obj24 = num5 - 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ r14_v6+8]");
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v576 @ rcx_v54 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
			object obj25 = num6 - 0;
			object obj26 = obj24 * obj24;
			object obj27 = obj23 * obj23;
			object obj28 = obj25 * obj25;
			object obj29 = obj26 + obj27;
			object obj30 = obj29 + obj28;
			bool flag3 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)9.9999994E-11f) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj30);
			float num7 = 9.9999994E-11f - (float)obj30;
			bool flag4 = num7 == 0f;
			bool flag5 = !flag3;
			bool flag6 = !flag4;
			object obj31 = flag6 & flag5;
			if (obj31 == null)
			{
				vector2 = (Vector3)obj22;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ r14_v6+8]");
				obj32 = 0;
				goto IL_0d56;
			}
		}
		nint num8 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v639 @ rax_v88 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num9 = 0;
		vector2 = Vector3.forwardVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v640 @ rax_v89 (Il2CppStaticFields<UnityEngine.Vector3>)+50]");
		obj32 = 0;
		goto IL_0d56;
		IL_0d56:
		Vector3 forward = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 81));
		Quaternion quaternion2 = Quaternion.LookRotation(forward);
		quaternion = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 65));
		vector = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 81));
		_ = quaternion2.x;
		GameObject gameObject2 = UnityEngine.Object.Instantiate(tilePrefab, vector, quaternion);
		ProceduralTile[][] array = proceduralTiles;
		bool flag7 = proceduralTiles == null;
		gameObject = tilePrefab;
		if (!flag7)
		{
			if ((nint)pos >= array.Length)
			{
				goto IL_0dbc;
			}
			bool flag8 = (object)gameObject2 == null;
			gameObject = tilePrefab;
			if (!flag8)
			{
				ProceduralTile[] array2 = array[(object)pos];
				ProceduralTile component = gameObject2.GetComponent<ProceduralTile>();
				bool flag9 = array[(object)pos] == null;
				vector = (Vector3)0;
				gameObject = gameObject2;
				if (!flag9)
				{
					if ((object)component != null)
					{
						nint num10 = (nint)array2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v834 @ rdx_v44 (Il2CppClass<ProceduralTile[]>)+40]");
						vector = (Vector3)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v834 @ rdx_v44 (Il2CppClass<ProceduralTile[]>)+40]");
						GameObject gameObject3 = UnityEngine.Object.Instantiate((GameObject)(object)component, (Vector3)0, quaternion);
						bool flag10 = (object)gameObject3 == null;
						gameObject = (GameObject)(object)component;
						if (flag10)
						{
							GameObject gameObject4 = UnityEngine.Object.Instantiate(gameObject, vector, quaternion);
							throw gameObject4;
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1+5B]");
					if ((nint)0 >= (nint)array2.Length)
					{
						goto IL_0dbc;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1+5B]");
					object obj33 = (nint)0 + (nint)4;
					object obj34 = default(object);
					array2[obj34] = component;
					object obj35 = obj33 * 8;
					gameObject = (GameObject)(object)((object)array[(object)pos] + obj35);
					vector = (Vector3)proceduralTiles;
					if (proceduralTiles != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v503 @ rdx_v1 (UnityEngine.Vector3)+18]");
						if ((nint)pos >= 0)
						{
							goto IL_0dbc;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v503 @ rdx_v1 (UnityEngine.Vector3)+20+pos @ rdx (UnityEngine.Vector2Int)*8]");
						vector = (Vector3)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v503 @ rdx_v1 (UnityEngine.Vector3)+20+pos @ rdx (UnityEngine.Vector2Int)*8]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1+5B]");
							object obj36 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1+5B]");
							nint num11 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v503 @ rdx_v1 (UnityEngine.Vector3)+18]");
							if (num11 >= 0)
							{
								goto IL_0dbc;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v503 @ rdx_v1 (UnityEngine.Vector3)+20+v190 @ rax_v42*8]");
							vector = (Vector3)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v503 @ rdx_v1 (UnityEngine.Vector3)+20+v190 @ rax_v42*8]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1+5F]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ r14_v6+8]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1+77]");
								object obj37 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1+4F]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v851 @ rax_v45+8]");
								_ = 0;
								bool flag11 = (object)currentStage == null;
								gameObject = (GameObject)(object)currentStage;
								if (!flag11)
								{
									Material topMaterial = currentStage.GetTopMaterial();
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v503 @ rdx_v1 (UnityEngine.Vector3)+28]");
									bool flag12 = (nint)0 == 0;
									vector = (Vector3)0;
									gameObject = (GameObject)(object)currentStage;
									if (!flag12)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v503 @ rdx_v1 (UnityEngine.Vector3)+28]");
										((Renderer)0).SetMaterial(topMaterial);
										List<object> list = (List<object>)(object)tiles;
										bool flag13 = tiles == null;
										quaternion = (Quaternion)0;
										vector = (Vector3)topMaterial;
										gameObject = (GameObject)(object)tiles;
										if (!flag13)
										{
											int version = list._version + 1;
											list._version = version;
											vector = (Vector3)list._items;
											bool flag14 = list._items == null;
											quaternion = (Quaternion)0;
											gameObject = (GameObject)(object)tiles;
											if (!flag14)
											{
												int size = list._size;
												int size2 = list._size;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v503 @ rdx_v1 (UnityEngine.Vector3)+18]");
												if ((nint)size2 >= (nint)0)
												{
													((List<object>)(object)tiles).AddWithResize((object)gameObject2);
													quaternion = (Quaternion)0;
												}
												else
												{
													int size3 = list._size + 1;
													list._size = size3;
													int size4 = list._size;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v503 @ rdx_v1 (UnityEngine.Vector3)+18]");
													if ((nint)size4 >= (nint)0)
													{
														goto IL_0dbc;
													}
													quaternion = (Quaternion)list._size;
												}
												Transform transform = gameObject2.transform;
												bool flag15 = (object)tilePrefab == null;
												vector = (Vector3)0;
												gameObject = gameObject2;
												if (!flag15)
												{
													Transform transform2 = tilePrefab.transform;
													bool flag16 = (object)transform2 == null;
													vector = (Vector3)0;
													gameObject = tilePrefab;
													if (!flag16)
													{
														Vector3 localScale = transform2.localScale;
														gameObject = (GameObject)(object)currentMapParameters;
														bool flag17 = (object)currentMapParameters == null;
														quaternion = (Quaternion)0;
														vector = (Vector3)transform2;
														if (!flag17)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v507 @ rcx_v2 (UnityEngine.GameObject)+30]");
															Vector3 vector3 = (Vector3)(0 * localScale.x);
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v507 @ rcx_v2 (UnityEngine.GameObject)+30]");
															object obj38 = 0 * localScale.y;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v507 @ rcx_v2 (UnityEngine.GameObject)+30]");
															Vector3 vector4 = (Vector3)(0 * localScale.z);
															bool flag18 = (object)transform == null;
															quaternion = (Quaternion)0;
															vector = (Vector3)transform2;
															if (!flag18)
															{
																Vector3 localScale2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 81));
																transform.localScale = localScale2;
																bool flag19 = tilePrefab == flatTile;
																bool flag20 = !flag19;
																quaternion = (Quaternion)0;
																vector = (Vector3)flatTile;
																gameObject = tilePrefab;
																if (!flag20)
																{
																	bool flag21 = flatTiles == null;
																	quaternion = (Quaternion)0;
																	vector = (Vector3)flatTile;
																	gameObject = (GameObject)(object)flatTiles;
																	if (flag21)
																	{
																		goto IL_0bcf;
																	}
																	flatTiles.Add(gameObject2);
																	quaternion = (Quaternion)0;
																	vector = (Vector3)gameObject2;
																	gameObject = (GameObject)(object)flatTiles;
																}
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ rbp_v1+4F]");
																if ((nint)0 != 0)
																{
																	goto IL_0bca;
																}
																StageData stageData = currentStage;
																if ((object)currentStage != null)
																{
																	if (!(stageData.m_stairs != null) || !(tilePrefab != ceilingTile))
																	{
																		goto IL_0bca;
																	}
																	quaternion = (Quaternion)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 65));
																	vector = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 81));
																	_ = quaternion2.x;
																	GameObject gameObject5 = UnityEngine.Object.Instantiate(stairsMesh, vector, quaternion);
																	bool flag22 = (object)gameObject5 == null;
																	gameObject = stairsMesh;
																	if (!flag22)
																	{
																		Transform transform3 = gameObject5.transform;
																		Transform parentInternal = gameObject2.transform;
																		bool flag23 = (object)transform3 == null;
																		vector = (Vector3)0;
																		gameObject = gameObject2;
																		if (!flag23)
																		{
																			transform3.parentInternal = parentInternal;
																			Transform transform4 = gameObject5.transform;
																			gameObject = gameObject5;
																			bool flag24 = (object)transform4 == null;
																			quaternion = (Quaternion)0;
																			vector = (Vector3)0;
																			if (!flag24)
																			{
																				nint num12 = (nint)typeof(Vector3);
																				Vector3 localScale3 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 81));
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1028 @ rcx_v42 (Il2CppClass<UnityEngine.Vector3>)+B8]");
																				nint num13 = 0;
																				_ = Vector3.oneVector;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1030 @ rax_v70 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
																				_ = 0;
																				transform4.localScale = localScale3;
																				TileStairs component2 = gameObject5.GetComponent<TileStairs>();
																				bool flag25 = (object)component2 == null;
																				quaternion = (Quaternion)0;
																				vector = (Vector3)0;
																				gameObject = gameObject5;
																				if (!flag25)
																				{
																					vector = (Vector3)currentStage;
																					bool flag26 = (object)currentStage == null;
																					quaternion = (Quaternion)0;
																					gameObject = gameObject5;
																					if (!flag26)
																					{
																						bool flag27 = (object)component2.renderer == null;
																						quaternion = (Quaternion)0;
																						gameObject = (GameObject)(object)component2.renderer;
																						if (!flag27)
																						{
																							Renderer renderer = component2.renderer;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v503 @ rdx_v1 (UnityEngine.Vector3)+78]");
																							renderer.SetMaterial((Material)0);
																							goto IL_0bca;
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
						}
					}
				}
			}
		}
		goto IL_0bcf;
		IL_0bca:
		return gameObject2;
		IL_0bcf:
		throw new NullReferenceException();
		IL_0dbc:
		return (GameObject)(object)new IndexOutOfRangeException();
	}

	public GameObject InstantiateTile(Vector2Int pos, int height, int yDir, Vector2Int direction)
	{
		GameObject tilePrefab = ((yDir == 0) ? flatTile : slopeTile);
		Vector3 direction2 = default(Vector3);
		Vector3 parentDir = default(Vector3);
		return InstantiateTile(pos, height, tilePrefab, direction2, parentDir);
	}

	private unsafe void InstantiateFillTile(Vector2Int pos, int height, GameObject tilePrefab, Vector2Int direction, Vector2Int globalDirection, EFillType fillType, bool flip = false, bool useEdgeTexture = false)
	{
		//IL_000e: Expected O, but got Ref
		//IL_0029: Expected O, but got Ref
		//IL_0029: Expected O, but got Ref
		//IL_0155: Expected O, but got Ref
		IntPtr intPtr = default(IntPtr);
		Quaternion quaternion = Quaternion.LookRotation((Vector3)(&intPtr));
		float num = default(float);
		GameObject gameObject = UnityEngine.Object.Instantiate(tilePrefab, (Vector3)(&intPtr), (Quaternion)(&num));
		FillTile component = gameObject.GetComponent<FillTile>();
		EFillType type = default(EFillType);
		bool useEdgeTextures = default(bool);
		component.SetFillType(type, currentStage, useEdgeTextures);
		List<object> list = (List<object>)(object)fillTiles;
		int version = list._version + 1;
		list._version = version;
		object[] items = list._items;
		if (list._size >= items.Length)
		{
			list.AddWithResize((object)gameObject);
		}
		else
		{
			int size = list._size + 1;
			list._size = size;
			int num2 = default(int);
			items[num2] = gameObject;
		}
		Transform transform = tilePrefab.transform;
		Vector3 localScale = transform.localScale;
		object obj = default(object);
		Transform transform2 = default(Transform);
		if (obj == null)
		{
			transform2 = gameObject.transform;
		}
		transform2.localScale = (Vector3)(&num);
	}

	private void FillEdges()
	{
		//IL_0044: Expected O, but got I4
		StageData stageData = currentStage;
		bool flag = stageData.mapEdgeFillType == MapEdgeFillType.Island;
		if (!flag)
		{
			object obj = stageData.mapEdgeFillType - 1;
			if (!flag)
			{
				if ((nint)obj == 1)
				{
					FillEdgesTrees();
				}
			}
			else
			{
				FillEdgesWalls();
			}
		}
		else
		{
			FillEdgesIsland();
		}
	}

	private void FillEdgesIsland()
	{
		//IL_0018: Expected O, but got I4
		//IL_0021: Expected O, but got I4
		//IL_0133: Expected O, but got I4
		//IL_013c: Expected O, but got I4
		//IL_0145: Expected O, but got I4
		//IL_01f0: Expected O, but got I4
		//IL_01f9: Expected O, but got I4
		//IL_0047: Expected O, but got I4
		//IL_02c9: Expected O, but got I4
		//IL_02d2: Expected O, but got I4
		//IL_021b: Expected O, but got I4
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Expected O, but got Unknown
		//IL_03a2: Expected O, but got I4
		//IL_03ab: Expected O, but got I4
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Expected I4, but got Unknown
		//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cb: Expected O, but got Unknown
		//IL_02f4: Expected O, but got I4
		//IL_0259: Unknown result type (might be due to invalid IL or missing references)
		//IL_025e: Expected I4, but got Unknown
		//IL_028c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0291: Expected O, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_0332: Unknown result type (might be due to invalid IL or missing references)
		//IL_0337: Expected I4, but got Unknown
		//IL_0365: Unknown result type (might be due to invalid IL or missing references)
		//IL_036a: Expected O, but got Unknown
		//IL_041d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0422: Expected I4, but got Unknown
		//IL_043e: Expected O, but got I4
		//IL_0451: Unknown result type (might be due to invalid IL or missing references)
		//IL_0456: Expected O, but got Unknown
		ProceduralTile[][] array = proceduralTiles;
		Vector2Int vector2Int = (Vector2Int)0;
		Vector2Int vector2Int2 = (Vector2Int)0;
		int num = 2147483647;
		while ((nint)vector2Int < array.Length)
		{
			ProceduralTile[][] array2 = proceduralTiles;
			Vector2Int vector2Int3 = (Vector2Int)0;
			while (true)
			{
				ProceduralTile[] array3 = array2[(object)vector2Int2];
				if ((nint)vector2Int3 >= array3.Length)
				{
					break;
				}
				ProceduralTile[] array4 = array2[(object)vector2Int2];
				ProceduralTile proceduralTile = array4[(object)vector2Int3];
				int num2 = proceduralTile.posY;
				vector2Int3++;
				if (proceduralTile.posY >= num)
				{
					num2 = num;
				}
				num = num2;
			}
			vector2Int2++;
			vector2Int = vector2Int2;
			array = array2;
		}
		MapParameters mapParameters = currentMapParameters;
		object obj = num - 1;
		Vector2Int vector2Int4 = (Vector2Int)0;
		Vector2Int vector2Int5 = (Vector2Int)0;
		Vector2Int dir = default(Vector2Int);
		bool useEdgeTextures = default(bool);
		while ((nint)vector2Int5 < mapParameters.size)
		{
			ProceduralTile[][] array5 = proceduralTiles;
			ProceduralTile[] array6 = array5[(object)vector2Int4];
			ProceduralTile proceduralTile2 = array6[0];
			int desiredHeightOffset = obj - proceduralTile2.posY;
			FillEdge(vector2Int4, desiredHeightOffset, isFacingOut: true, dir, useEdgeTextures);
			mapParameters = currentMapParameters;
			vector2Int4++;
			vector2Int5 = vector2Int4;
		}
		MapParameters mapParameters2 = currentMapParameters;
		Vector2Int vector2Int6 = (Vector2Int)0;
		Vector2Int vector2Int7 = (Vector2Int)0;
		bool flag;
		do
		{
			MapParameters mapParameters3 = currentMapParameters;
			if ((nint)vector2Int7 < mapParameters2.size)
			{
				ProceduralTile[][] array7 = proceduralTiles;
				Vector2Int vector2Int8 = (Vector2Int)(mapParameters3.size - 1);
				ProceduralTile[] array8 = array7[(object)vector2Int8];
				ProceduralTile proceduralTile3 = array8[(object)vector2Int6];
				int desiredHeightOffset2 = obj - proceduralTile3.posY;
				FillEdge(vector2Int8, desiredHeightOffset2, isFacingOut: true, dir, useEdgeTextures);
				mapParameters2 = currentMapParameters;
				vector2Int6++;
				flag = (object)currentMapParameters != null;
				vector2Int7 = vector2Int6;
				continue;
			}
			Vector2Int vector2Int9 = (Vector2Int)0;
			Vector2Int vector2Int10 = (Vector2Int)0;
			bool flag2;
			do
			{
				MapParameters mapParameters4 = currentMapParameters;
				if ((nint)vector2Int10 < mapParameters3.size)
				{
					ProceduralTile[][] array9 = proceduralTiles;
					object obj2 = mapParameters4.size - 1;
					ProceduralTile[] array10 = array9[(object)vector2Int9];
					ProceduralTile proceduralTile4 = array10[obj2];
					int desiredHeightOffset3 = obj - proceduralTile4.posY;
					FillEdge(vector2Int9, desiredHeightOffset3, isFacingOut: true, dir, useEdgeTextures);
					mapParameters3 = currentMapParameters;
					vector2Int9++;
					flag2 = (object)currentMapParameters != null;
					vector2Int10 = vector2Int9;
					continue;
				}
				Vector2Int vector2Int11 = (Vector2Int)0;
				Vector2Int vector2Int12 = (Vector2Int)0;
				bool flag3;
				do
				{
					if ((nint)vector2Int12 < mapParameters4.size)
					{
						ProceduralTile[][] array11 = proceduralTiles;
						ProceduralTile[] array12 = array11[0];
						ProceduralTile proceduralTile5 = array12[(object)vector2Int11];
						int desiredHeightOffset4 = obj - proceduralTile5.posY;
						FillEdge((Vector2Int)0, desiredHeightOffset4, isFacingOut: true, dir, useEdgeTextures);
						mapParameters4 = currentMapParameters;
						vector2Int11++;
						flag3 = (object)currentMapParameters != null;
						vector2Int12 = vector2Int11;
						continue;
					}
					return;
				}
				while (flag3);
				break;
			}
			while (flag2);
			break;
		}
		while (flag);
		throw new NullReferenceException();
	}

	private unsafe void FillEdgesWalls()
	{
		//IL_0022: Expected O, but got I4
		//IL_002f: Expected I4, but got I8
		//IL_0038: Expected O, but got I4
		//IL_0150: Expected O, but got I4
		//IL_0159: Expected O, but got I4
		//IL_0161: Expected I4, but got O
		//IL_0236: Expected O, but got I4
		//IL_023f: Expected O, but got I4
		//IL_0055: Expected O, but got I4
		//IL_006b: Expected I4, but got O
		//IL_031b: Expected O, but got I4
		//IL_0324: Expected O, but got I4
		//IL_0261: Expected O, but got I4
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Expected O, but got Unknown
		//IL_0400: Expected O, but got I4
		//IL_0409: Expected O, but got I4
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e7: Expected O, but got Unknown
		//IL_0346: Expected O, but got I4
		//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d7: Expected O, but got Unknown
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Expected O, but got Unknown
		//IL_04ee: Expected O, but got I4
		//IL_04f7: Expected O, but got I4
		//IL_03b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bc: Expected O, but got Unknown
		//IL_0506: Expected O, but got I4
		//IL_0479: Expected O, but got I4
		//IL_048c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0491: Expected O, but got Unknown
		//IL_04c2: Expected O, but got I4
		//IL_059d: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a2: Expected O, but got Unknown
		//IL_06f2: Expected O, but got I4
		//IL_055b: Expected O, but got Ref
		//IL_0564: Unknown result type (might be due to invalid IL or missing references)
		//IL_0569: Expected O, but got Unknown
		//IL_058f: Expected O, but got Ref
		ProceduralTile[][] array = proceduralTiles;
		Vector2Int vector2Int = (Vector2Int)0;
		int num = -2147483648;
		Vector2Int vector2Int2 = (Vector2Int)0;
		while ((nint)vector2Int2 < array.Length)
		{
			ProceduralTile[][] array2 = proceduralTiles;
			Vector2Int vector2Int3 = (Vector2Int)0;
			while (true)
			{
				bool flag = (byte)(int)array2[(object)vector2Int] != 0;
				Vector2Int vector2Int4 = vector2Int3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v214 @ r9_v9 (System.Boolean)+18]");
				if ((nint)vector2Int4 >= 0)
				{
					break;
				}
				ProceduralTile[] array3 = array2[(object)vector2Int];
				ProceduralTile proceduralTile = array3[(object)vector2Int3];
				int num2 = proceduralTile.posY;
				vector2Int3++;
				if (proceduralTile.posY <= num)
				{
					num2 = num;
				}
				num = num2;
			}
			vector2Int++;
			array = array2;
			vector2Int2 = vector2Int;
		}
		MapParameters mapParameters = currentMapParameters;
		int num3 = num + 2;
		Vector2Int vector2Int5 = (Vector2Int)0;
		Vector2Int vector2Int6 = (Vector2Int)0;
		int num4 = (int)array;
		Vector2Int vector2Int7 = default(Vector2Int);
		bool flag2 = default(bool);
		bool flag3;
		Vector3 forwardVector = default(Vector3);
		do
		{
			if ((nint)vector2Int6 < mapParameters.size)
			{
				ProceduralTile[][] array4 = proceduralTiles;
				ProceduralTile[] array5 = array4[(object)vector2Int5];
				ProceduralTile proceduralTile2 = array5[0];
				num4 = num3 - proceduralTile2.posY;
				FillEdge(vector2Int5, num4, isFacingOut: false, vector2Int7, flag2);
				mapParameters = currentMapParameters;
				vector2Int5++;
				flag3 = (object)currentMapParameters != null;
				bool flag = false;
				vector2Int6 = vector2Int5;
				continue;
			}
			MapParameters mapParameters2 = currentMapParameters;
			Vector2Int vector2Int8 = (Vector2Int)0;
			Vector2Int vector2Int9 = (Vector2Int)0;
			bool flag4;
			do
			{
				MapParameters mapParameters3 = currentMapParameters;
				if ((nint)vector2Int9 < mapParameters2.size)
				{
					ProceduralTile[][] array6 = proceduralTiles;
					Vector2Int vector2Int10 = (Vector2Int)(mapParameters3.size - 1);
					ProceduralTile[] array7 = array6[(object)vector2Int10];
					ProceduralTile proceduralTile3 = array7[(object)vector2Int8];
					num4 = num3 - proceduralTile3.posY;
					FillEdge(vector2Int10, num4, isFacingOut: false, vector2Int7, flag2);
					mapParameters2 = currentMapParameters;
					vector2Int8++;
					flag4 = (object)currentMapParameters != null;
					bool flag = false;
					vector2Int9 = vector2Int8;
					continue;
				}
				Vector2Int vector2Int11 = (Vector2Int)0;
				Vector2Int vector2Int12 = (Vector2Int)0;
				bool flag5;
				do
				{
					MapParameters mapParameters4 = currentMapParameters;
					if ((nint)vector2Int12 < mapParameters3.size)
					{
						ProceduralTile[][] array8 = proceduralTiles;
						object obj = mapParameters4.size - 1;
						ProceduralTile[] array9 = array8[(object)vector2Int11];
						ProceduralTile proceduralTile4 = array9[obj];
						num4 = num3 - proceduralTile4.posY;
						FillEdge(vector2Int11, num4, isFacingOut: false, vector2Int7, flag2);
						mapParameters3 = currentMapParameters;
						vector2Int11++;
						flag5 = (object)currentMapParameters != null;
						bool flag = false;
						vector2Int12 = vector2Int11;
						continue;
					}
					Vector2Int vector2Int13 = (Vector2Int)0;
					Vector2Int vector2Int14 = (Vector2Int)0;
					bool flag6;
					do
					{
						if ((nint)vector2Int14 < mapParameters4.size)
						{
							ProceduralTile[][] array10 = proceduralTiles;
							ProceduralTile[] array11 = array10[0];
							ProceduralTile proceduralTile5 = array11[(object)vector2Int13];
							num4 = num3 - proceduralTile5.posY;
							FillEdge((Vector2Int)0, num4, isFacingOut: false, vector2Int7, flag2);
							mapParameters4 = currentMapParameters;
							vector2Int13++;
							flag6 = (object)currentMapParameters != null;
							bool flag = false;
							vector2Int14 = vector2Int13;
							vector2Int12 = (Vector2Int)0;
							continue;
						}
						MapParameters mapParameters5 = currentMapParameters;
						Vector2Int vector2Int15 = (Vector2Int)0;
						Vector2Int vector2Int16 = (Vector2Int)0;
						while ((nint)vector2Int16 < mapParameters5.size)
						{
							Vector2Int vector2Int17 = (Vector2Int)0;
							while (true)
							{
								mapParameters5 = currentMapParameters;
								if ((nint)vector2Int17 >= mapParameters5.size)
								{
									break;
								}
								Vector3 zeroVector = Vector3.zeroVector;
								GameObject gameObject = InstantiateTile(vector2Int15, num3, ceilingTile, (Vector3)vector2Int7, (Vector3)flag2);
								Transform transform = gameObject.transform;
								transform.Rotate((Vector3)(&forwardVector), 180f);
								Vector2Int vector2Int18 = vector2Int17 + 1;
								forwardVector = Vector3.forwardVector;
								vector2Int17 = vector2Int18;
								bool flag = false;
								vector2Int12 = (Vector2Int)(&forwardVector);
							}
							vector2Int15++;
							vector2Int16 = vector2Int15;
						}
						return;
					}
					while (flag6);
					break;
				}
				while (flag5);
				break;
			}
			while (flag4);
			break;
		}
		while (flag3);
		throw new NullReferenceException();
	}

	private void FillEdgesTrees()
	{
		//IL_0013: Expected O, but got I4
		//IL_001c: Expected O, but got I4
		//IL_00bb: Expected O, but got I4
		//IL_00c4: Expected O, but got I4
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_0176: Expected O, but got I4
		//IL_017f: Expected O, but got I4
		//IL_010a: Expected O, but got I4
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Expected O, but got Unknown
		//IL_01f0: Expected O, but got I4
		//IL_01f9: Expected O, but got I4
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Expected O, but got Unknown
		//IL_021b: Expected O, but got I4
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0233: Expected O, but got Unknown
		MapParameters mapParameters = currentMapParameters;
		Vector2Int vector2Int = (Vector2Int)0;
		Vector2Int vector2Int2 = (Vector2Int)0;
		Vector2Int dir = default(Vector2Int);
		bool useEdgeTextures = default(bool);
		bool flag;
		do
		{
			if ((nint)vector2Int < mapParameters.size)
			{
				FillEdge(vector2Int2, 2, isFacingOut: false, dir, useEdgeTextures);
				mapParameters = currentMapParameters;
				vector2Int2++;
				flag = (object)currentMapParameters != null;
				vector2Int = vector2Int2;
				continue;
			}
			MapParameters mapParameters2 = currentMapParameters;
			Vector2Int vector2Int3 = (Vector2Int)0;
			Vector2Int vector2Int4 = (Vector2Int)0;
			bool flag2;
			do
			{
				MapParameters mapParameters3 = currentMapParameters;
				if ((nint)vector2Int3 < mapParameters2.size)
				{
					Vector2Int pos = (Vector2Int)(mapParameters3.size - 1);
					FillEdge(pos, 2, isFacingOut: false, dir, useEdgeTextures);
					mapParameters2 = currentMapParameters;
					vector2Int4++;
					flag2 = (object)currentMapParameters != null;
					vector2Int3 = vector2Int4;
					continue;
				}
				Vector2Int vector2Int5 = (Vector2Int)0;
				Vector2Int vector2Int6 = (Vector2Int)0;
				bool flag3;
				do
				{
					MapParameters mapParameters4 = currentMapParameters;
					if ((nint)vector2Int5 < mapParameters3.size)
					{
						FillEdge(vector2Int6, 2, isFacingOut: false, dir, useEdgeTextures);
						mapParameters3 = currentMapParameters;
						vector2Int6++;
						flag3 = (object)currentMapParameters != null;
						vector2Int5 = vector2Int6;
						continue;
					}
					Vector2Int vector2Int7 = (Vector2Int)0;
					Vector2Int vector2Int8 = (Vector2Int)0;
					while ((nint)vector2Int7 < mapParameters4.size)
					{
						FillEdge((Vector2Int)0, 2, isFacingOut: false, dir, useEdgeTextures);
						mapParameters4 = currentMapParameters;
						vector2Int8++;
						vector2Int7 = vector2Int8;
					}
					return;
				}
				while (flag3);
				break;
			}
			while (flag2);
			break;
		}
		while (flag);
		throw new NullReferenceException();
	}

	private void FillEdge(Vector2Int pos1, int desiredHeightOffset, bool isFacingOut, Vector2Int dir, bool useEdgeTextures = false)
	{
		//IL_0022: Expected O, but got I4
		//IL_0069: Expected O, but got I4
		//IL_00c4: Unsupported input type for neg.
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Expected O, but got Unknown
		//IL_027a: Expected I4, but got O
		//IL_019a: Expected I4, but got O
		//IL_0178: Unsupported input type for neg.
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Expected I4, but got Unknown
		//IL_054b: Unsupported input type for neg.
		//IL_054b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0550: Expected O, but got Unknown
		//IL_0966: Expected O, but got I4
		//IL_0837: Expected I, but got O
		//IL_05a3: Unsupported input type for neg.
		//IL_05a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a8: Expected O, but got Unknown
		//IL_03cf: Unsupported input type for neg.
		//IL_03cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d4: Expected O, but got Unknown
		//IL_02a0: Expected O, but got I4
		//IL_0a3b: Expected O, but got I4
		//IL_06ef: Expected I, but got O
		//IL_0427: Unsupported input type for neg.
		//IL_0427: Unknown result type (might be due to invalid IL or missing references)
		//IL_042c: Expected O, but got Unknown
		//IL_04f3: Expected O, but got I4
		//IL_0506: Expected O, but got I4
		//IL_0983: Expected O, but got I4
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Expected O, but got Unknown
		//IL_0680: Unknown result type (might be due to invalid IL or missing references)
		//IL_0685: Expected O, but got Unknown
		//IL_0a7b: Expected I4, but got O
		//IL_0a84: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a89: Expected O, but got Unknown
		//IL_08df: Expected I4, but got O
		//IL_08e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ed: Expected O, but got Unknown
		//IL_0377: Expected O, but got I4
		//IL_038a: Expected O, but got I4
		//IL_05bd: Expected I4, but got O
		//IL_09c3: Expected I4, but got O
		//IL_09cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_09d1: Expected O, but got Unknown
		//IL_0797: Expected I4, but got O
		//IL_07a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a5: Expected O, but got Unknown
		//IL_0441: Expected I4, but got O
		MapParameters mapParameters = currentMapParameters;
		object obj = mapParameters.size - 1;
		if (System.Runtime.CompilerServices.Unsafe.As<Vector2Int, UIntPtr>(ref pos1) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
		{
			return;
		}
		MapParameters mapParameters2 = currentMapParameters;
		object obj2 = (object)pos1 >> 32;
		object obj3 = mapParameters2.size - 1;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
		{
			return;
		}
		ProceduralTile[][] array = proceduralTiles;
		ProceduralTile[] array2 = array[(object)pos1];
		Vector2Int vector2Int2 = default(Vector2Int);
		Vector2Int vector2Int = vector2Int2;
		bool flag = default(bool);
		if (!flag)
		{
			vector2Int = 0 - vector2Int2;
		}
		object obj4 = default(object);
		ProceduralTile proceduralTile = array2[obj4];
		TileEdge edge = array2[obj4].GetEdge(vector2Int);
		int num = edge.offsetHeight + proceduralTile.posY;
		if (desiredHeightOffset == 0 || edge.type != ETileEdgeType.Flat)
		{
			goto IL_0272;
		}
		bool flag3;
		int num3;
		if (desiredHeightOffset < 0)
		{
			int num2 = num - 1;
			bool flag2 = (byte)(int)(0 - vector2Int) != 0;
			flag3 = flag2;
			num3 = num2;
		}
		else
		{
			flag3 = (byte)(int)vector2Int != 0;
			num3 = num;
		}
		int num4 = -desiredHeightOffset;
		if (desiredHeightOffset < 0)
		{
			num4 = desiredHeightOffset;
		}
		int num5 = num;
		int num6 = 0;
		Vector2Int direction = default(Vector2Int);
		Vector2Int globalDirection = default(Vector2Int);
		EFillType fillType = default(EFillType);
		bool flip = default(bool);
		object obj6 = default(object);
		object obj8 = default(object);
		for (object obj5 = 0; (nint)obj5 < num4; InstantiateFillTile(pos1, num4, wallFlat, direction, globalDirection, fillType, flip, flag3), obj5++, num5 = num4, num6 = num4)
		{
			float num7 = ((desiredHeightOffset < 0) ? (-1f) : 1f);
			float num8 = (float)obj5 * num7;
			float num9 = num8 + (float)num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm1\"");
			if (obj5 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180418B20");
				if ((nint)obj6 <= 1)
				{
				}
				continue;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180418B20");
			object obj7 = obj8 - 1;
			if (obj5 != obj7)
			{
				continue;
			}
			goto IL_0272;
		}
		Vector2Int vector2Int3 = (Vector2Int)flag3;
		goto IL_069f;
		IL_093f:
		Vector2Int vector2Int4 = vector2Int;
		goto IL_0829;
		IL_06e1:
		Vector2Int vector2Int5;
		int num14 = default(int);
		while (true)
		{
			nint num10 = (nint)typeof(Math);
			int num11 = -desiredHeightOffset;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1040 @ rcx_v31 (Il2CppClass<System.Math>)+E4]");
			if ((nint)0 < (nint)0)
			{
				num11 = desiredHeightOffset;
			}
			bool flag4 = desiredHeightOffset < 0;
			int num12 = num5 - 1;
			if (!flag4)
			{
				num12 = num5;
			}
			bool flag5 = desiredHeightOffset < 1;
			object obj9 = 0;
			if (!flag5)
			{
				obj9 = 1;
			}
			if ((nint)obj9 >= num11)
			{
				break;
			}
			object obj10 = num11 - 1;
			bool flag6 = desiredHeightOffset < 0;
			int num13 = num12;
			object obj11 = obj9;
			if (!flag6)
			{
				goto IL_07c1;
			}
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
				int height = num12 - num13;
				if (obj9 == obj10)
				{
					break;
				}
				InstantiateFillTile(pos1, height, wallFlat, direction, globalDirection, fillType, flip, (byte)(int)vector2Int5 != 0);
				obj9++;
				bool flag7 = (nint)obj9 < num11;
				num13 = num14;
				if (flag7)
				{
					continue;
				}
				goto IL_0439;
			}
			goto IL_076f;
			IL_076f:
			InstantiateFillTile(pos1, num6, wallFlat, direction, globalDirection, fillType, flip, (byte)(int)vector2Int5 != 0);
			obj11++;
			if ((nint)obj11 >= num11)
			{
				goto IL_0439;
			}
			goto IL_07c1;
			IL_0439:
			flag3 = (byte)(int)vector2Int3 != 0;
			break;
			IL_07c1:
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r8d,xmm0\"");
			num6 += num12;
			if (obj11 == obj10)
			{
				continue;
			}
			goto IL_076f;
		}
		ProceduralTileGeneration proceduralTileGeneration = this;
		goto IL_09f5;
		IL_09f5:
		GameObject tilePrefab;
		proceduralTileGeneration.InstantiateFillTile(pos1, num5, tilePrefab, direction, globalDirection, fillType, flip, flag3);
		return;
		IL_07f7:
		vector2Int5 = vector2Int;
		goto IL_06e1;
		IL_0272:
		flag3 = (byte)(int)vector2Int != 0;
		vector2Int3 = vector2Int;
		num5 = num;
		num6 = 0;
		goto IL_069f;
		IL_069f:
		if (edge.type != ETileEdgeType.SlopeLeft)
		{
			if (edge.type != ETileEdgeType.SlopeRight)
			{
				return;
			}
			if (desiredHeightOffset > 0)
			{
				bool flag8 = desiredHeightOffset <= 1;
				tilePrefab = wallLeftUp;
				if (!flag8)
				{
					tilePrefab = wallLeftUp;
					goto IL_07f7;
				}
			}
			else
			{
				tilePrefab = wallLeftDown;
			}
			if (desiredHeightOffset < 0)
			{
				Vector2Int vector2Int6 = 0 - vector2Int;
				vector2Int5 = vector2Int6;
			}
			else
			{
				if (desiredHeightOffset > 0)
				{
					goto IL_07f7;
				}
				bool flag9 = desiredHeightOffset >= 0;
				proceduralTileGeneration = this;
				if (flag9)
				{
					goto IL_09f5;
				}
				Vector2Int vector2Int7 = 0 - vector2Int;
				vector2Int5 = vector2Int7;
			}
			goto IL_06e1;
		}
		if (desiredHeightOffset > 0)
		{
			bool flag10 = desiredHeightOffset <= 1;
			tilePrefab = wallLeftUp;
			if (!flag10)
			{
				tilePrefab = wallLeftUp;
				goto IL_093f;
			}
		}
		else
		{
			tilePrefab = wallLeftDown;
		}
		if (desiredHeightOffset < 0)
		{
			Vector2Int vector2Int8 = 0 - vector2Int;
			vector2Int4 = vector2Int8;
		}
		else
		{
			if (desiredHeightOffset > 0)
			{
				goto IL_093f;
			}
			bool flag11 = desiredHeightOffset >= 0;
			proceduralTileGeneration = this;
			if (flag11)
			{
				goto IL_09f5;
			}
			Vector2Int vector2Int9 = 0 - vector2Int;
			vector2Int4 = vector2Int9;
		}
		goto IL_0829;
		IL_0829:
		int num19 = default(int);
		while (true)
		{
			nint num15 = (nint)typeof(Math);
			int num16 = -desiredHeightOffset;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v937 @ rcx_v14 (Il2CppClass<System.Math>)+E4]");
			if ((nint)0 < (nint)0)
			{
				num16 = desiredHeightOffset;
			}
			bool flag12 = desiredHeightOffset < 0;
			int num17 = num5 - 1;
			if (!flag12)
			{
				num17 = num5;
			}
			bool flag13 = desiredHeightOffset < 1;
			object obj12 = 0;
			if (!flag13)
			{
				obj12 = 1;
			}
			if ((nint)obj12 >= num16)
			{
				break;
			}
			object obj13 = num16 - 1;
			bool flag14 = desiredHeightOffset < 0;
			int num18 = num17;
			object obj14 = obj12;
			if (!flag14)
			{
				goto IL_0909;
			}
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
				int height2 = num17 - num18;
				if (obj12 == obj13)
				{
					break;
				}
				InstantiateFillTile(pos1, height2, wallFlat, direction, globalDirection, fillType, flip, (byte)(int)vector2Int4 != 0);
				obj12++;
				bool flag15 = (nint)obj12 < num16;
				num18 = num19;
				if (flag15)
				{
					continue;
				}
				goto IL_05b5;
			}
			goto IL_08b7;
			IL_08b7:
			InstantiateFillTile(pos1, num6, wallFlat, direction, globalDirection, fillType, flip, (byte)(int)vector2Int4 != 0);
			obj14++;
			if ((nint)obj14 >= num16)
			{
				goto IL_05b5;
			}
			goto IL_0909;
			IL_05b5:
			flag3 = (byte)(int)vector2Int3 != 0;
			break;
			IL_0909:
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r8d,xmm0\"");
			num6 += num17;
			if (obj14 == obj13)
			{
				continue;
			}
			goto IL_08b7;
		}
		proceduralTileGeneration = this;
		goto IL_09f5;
	}

	private unsafe Vector3 GetMapToZeroPositionOffset()
	{
		//IL_0040: Expected O, but got I4
		//IL_0049: Expected native int or pointer, but got O
		//IL_009c: Expected O, but got I4
		//IL_00d0: Expected O, but got I4
		//IL_0101: Expected native int or pointer, but got O
		//IL_012b: Expected O, but got I4
		//IL_0150: Expected native int or pointer, but got O
		MapParameters mapParameters = currentMapParameters;
		if ((object)currentMapParameters != null)
		{
			object obj = mapParameters.scaledTileWidth * mapParameters.size;
			Vector3 vector = default(Vector3);
			((Vector3*)(nint)vector)->y = 0f;
			object obj2 = obj >> 31;
			object obj3 = obj - obj2;
			object obj4 = obj3 >> 1;
			int num = mapParameters.scaledTileWidth >> 31;
			object obj5 = mapParameters.scaledTileWidth - num;
			object obj6 = obj5 >> 1;
			float x = (float)obj6 - (float)obj4;
			object obj7 = mapParameters.scaledTileWidth * mapParameters.size;
			object obj8 = obj7 >> 31;
			object obj9 = obj7 - obj8;
			object obj10 = obj9 >> 1;
			((Vector3*)(nint)vector)->x = x;
			int num2 = mapParameters.scaledTileWidth >> 31;
			object obj11 = mapParameters.scaledTileWidth - num2;
			object obj12 = obj11 >> 1;
			float z = (float)obj12 - (float)obj10;
			((Vector3*)(nint)vector)->z = z;
			return vector;
		}
		return (Vector3)new NullReferenceException();
	}

	public unsafe Vector3 GetWorldSize()
	{
		//IL_002d: Expected O, but got Ref
		//IL_018b: Expected native int or pointer, but got O
		//IL_01ad: Expected native int or pointer, but got O
		//IL_01d3: Expected native int or pointer, but got O
		//IL_0080: Invalid comparison between I4 and F4
		//IL_00fd: Invalid comparison between F4 and I8
		if (tiles != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
			List<object>.Enumerator enumerator = default(List<object>.Enumerator);
			GameObject gameObject = default(GameObject);
			while (enumerator.MoveNext())
			{
				bool flag = (object)gameObject == null;
				List<object>.Enumerator enumerator2 = (List<object>.Enumerator)(&enumerator);
				if (!flag)
				{
					Transform transform = gameObject.transform;
					if ((object)transform != null)
					{
						if (2.1474836E+09f > transform.position.y)
						{
							Transform transform2 = gameObject.transform;
							if ((object)transform2 == null)
							{
								throw new NullReferenceException();
							}
							Vector3 position = transform2.position;
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r14d,dword ptr [rax+4]\"");
						}
						Transform transform3 = gameObject.transform;
						if ((object)transform3 != null)
						{
							if (transform3.position.y > 2.1474836E+09f)
							{
								Transform transform4 = gameObject.transform;
								if ((object)transform4 == null)
								{
									throw new NullReferenceException();
								}
								Vector3 position2 = transform4.position;
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si esi,dword ptr [rax+4]\"");
							}
							continue;
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			((List<GameObject>.Enumerator*)(&enumerator))->Dispose();
			MapParameters mapParameters = currentMapParameters;
			if ((object)currentMapParameters != null)
			{
				float x = (float)mapParameters.size * (float)mapParameters.scaledTileWidth;
				Vector3 vector = default(Vector3);
				((Vector3*)(nint)vector)->x = x;
				float y = 2.1474836E+09f - 2.1474836E+09f;
				((Vector3*)(nint)vector)->y = y;
				float z = (float)mapParameters.size * (float)mapParameters.scaledTileWidth;
				((Vector3*)(nint)vector)->z = z;
				return vector;
			}
		}
		throw new NullReferenceException();
	}

	public unsafe Vector3 GetWorldCenter()
	{
		//IL_0204: Expected native int or pointer, but got O
		//IL_021c: Expected O, but got I8
		//IL_0244: Expected native int or pointer, but got O
		//IL_0252: Expected native int or pointer, but got O
		//IL_002d: Expected O, but got Ref
		//IL_0080: Invalid comparison between I4 and F4
		//IL_00fd: Invalid comparison between F4 and I8
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
		List<object>.Enumerator enumerator = default(List<object>.Enumerator);
		GameObject gameObject = default(GameObject);
		Vector3 vector = default(Vector3);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				bool flag = (object)gameObject == null;
				List<object>.Enumerator enumerator2 = (List<object>.Enumerator)(&enumerator);
				if (!flag)
				{
					Transform transform = gameObject.transform;
					if ((object)transform != null)
					{
						if (2.1474836E+09f > transform.position.y)
						{
							Transform transform2 = gameObject.transform;
							if ((object)transform2 == null)
							{
								throw new NullReferenceException();
							}
							Vector3 position = transform2.position;
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r14d,dword ptr [rax+4]\"");
						}
						Transform transform3 = gameObject.transform;
						if ((object)transform3 != null)
						{
							if (transform3.position.y > 2.1474836E+09f)
							{
								Transform transform4 = gameObject.transform;
								if ((object)transform4 == null)
								{
									break;
								}
								Vector3 position2 = transform4.position;
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si esi,dword ptr [rax+4]\"");
							}
							continue;
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			((List<GameObject>.Enumerator*)(&enumerator))->Dispose();
			((Vector3*)(nint)vector)->x = 0f;
			object obj = 2147483648L - 2147483647;
			float num = (float)obj * 0.5f;
			float y = num + 2.1474836E+09f;
			((Vector3*)(nint)vector)->y = y;
			((Vector3*)(nint)vector)->z = 0f;
			return vector;
		}
		throw new NullReferenceException();
	}

	private void ClearTiles()
	{
		if (tiles != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
			List<object>.Enumerator enumerator = default(List<object>.Enumerator);
			UnityEngine.Object obj = default(UnityEngine.Object);
			while (enumerator.MoveNext())
			{
				UnityEngine.Object.DestroyImmediate(obj);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
		}
	}
}
