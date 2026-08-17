using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Assets.Scripts.Game.MapGeneration;
using Assets.Scripts.Managers;
using Cpp2ILInjected;
using UnityEngine;
using Utility;

public class GenerateTileObjects : MonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<int, float> _003C_003E9__6_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal float _003CMapSpecificTiles_003Eb__6_0(int _)
		{
			return UnityEngine.Random.value;
		}
	}

	public GameObject tileObjectsParent;

	public GameObject bossSpawner;

	public GameObject bossSpawnerFinal;

	public GameObject graveyardBossPortal;

	public GameObject arrowPrefabTest;

	public unsafe void Generate(List<GameObject> allFlatTiles, StageData stageData)
	{
		//IL_012a: Expected I, but got O
		//IL_0a42: Expected O, but got I
		//IL_0a52: Expected O, but got I
		//IL_02d5: Expected O, but got Ref
		//IL_0ad3: Expected O, but got Ref
		//IL_0ad3: Expected O, but got Ref
		//IL_0314: Expected O, but got Ref
		//IL_0a88: Expected O, but got Ref
		//IL_022f: Expected O, but got Ref
		//IL_03ec: Expected O, but got I4
		//IL_080b: Expected O, but got I4
		//IL_04b4: Expected O, but got I
		//IL_053b: Expected O, but got I
		//IL_055b: Expected O, but got I
		//IL_056b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0570: Expected O, but got Unknown
		//IL_0513: Expected O, but got Ref
		//IL_06a9: Expected O, but got Ref
		//IL_06a9: Expected O, but got Ref
		//IL_0b40: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b45: Expected O, but got Unknown
		//IL_09ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b2: Expected O, but got Unknown
		//IL_0709: Expected O, but got Ref
		//IL_0724: Expected O, but got Ref
		//IL_0740: Expected O, but got Ref
		if (tileObjectsParent != null)
		{
			UnityEngine.Object.DestroyImmediate(tileObjectsParent);
		}
		GameObject gameObject = new GameObject("TileObjectsParent");
		tileObjectsParent = gameObject;
		List<GameObject> list = (List<GameObject>)(object)new List<object>(allFlatTiles);
		GameObject original;
		float x;
		Vector3 position3;
		object obj3 = default(object);
		float x2 = default(float);
		if (list != null)
		{
			((List<object>)(object)list).RemoveAt(0);
			int index = list._size - 1;
			GameObject gameObject2 = list.get_Item(index);
			int index2 = list._size - 1;
			((List<object>)(object)list).RemoveAt(index2);
			MapSpecificTiles(list, stageData);
			nint num = (nint)typeof(MapController);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v966 @ rcx_v26 (Il2CppClass<Assets.Scripts.Managers.MapController>)+B8]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v600 @ rax_v39+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v600 @ rax_v39+10]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ rdx_v22+58]");
				if ((nint)0 != 8)
				{
					bool flag = MapController.IsLastStage();
					if ((object)gameObject2 != null)
					{
						GameObject gameObject3;
						if (!flag)
						{
							original = bossSpawner;
							Transform transform = gameObject2.transform;
							if ((object)transform == null)
							{
								goto IL_09d0;
							}
							Vector3 position = transform.position;
							gameObject3 = bossSpawner;
						}
						else
						{
							original = bossSpawnerFinal;
							Transform transform2 = gameObject2.transform;
							if ((object)transform2 == null)
							{
								goto IL_09d0;
							}
							Vector3 position2 = transform2.position;
							gameObject3 = bossSpawnerFinal;
						}
						if ((object)gameObject3 != null)
						{
							Transform transform3 = gameObject3.transform;
							if ((object)transform3 != null)
							{
								x = transform3.rotation.x;
								position3 = (Vector3)(&obj3);
								goto IL_0a77;
							}
						}
					}
				}
				else if ((object)gameObject2 != null)
				{
					ProceduralTile component = gameObject2.GetComponent<ProceduralTile>();
					if ((object)component != null)
					{
						Vector3 vector = VectorExtensions.XZVector((Vector3)(&obj3));
						Quaternion quaternion = Quaternion.LookRotation((Vector3)(&x2), (Vector3)(&obj3));
						original = graveyardBossPortal;
						Transform transform4 = gameObject2.transform;
						if ((object)transform4 != null)
						{
							x2 = transform4.position.x;
							x = quaternion.x;
							position3 = (Vector3)(&x2);
							goto IL_0a77;
						}
					}
				}
			}
		}
		goto IL_09d0;
		IL_05ba:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18114D740");
		List<Vector3>.Enumerator enumerator = default(List<Vector3>.Enumerator);
		GameObject[] flatTilePrefabs;
		float num3 = default(float);
		List<Vector3>.Enumerator enumerator2 = default(List<Vector3>.Enumerator);
		GenerateTileObjects generateTileObjects;
		while (enumerator.MoveNext())
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
			bool flag2 = MyRandom.random == null;
			GameObject random = (GameObject)(object)MyRandom.random;
			if (!flag2)
			{
				int num2 = ((List<T>)(object)MyRandom.random).IndexOf((T)null);
				if (num2 < flatTilePrefabs.Length)
				{
					bool flag3 = (object)flatTilePrefabs[num2] == null;
					random = (GameObject)(object)MyRandom.random;
					if (!flag3)
					{
						Transform transform5 = flatTilePrefabs[num2].transform;
						bool flag4 = (object)transform5 == null;
						random = flatTilePrefabs[num2];
						if (!flag4)
						{
							Quaternion rotation = transform5.rotation;
							GameObject gameObject4 = UnityEngine.Object.Instantiate(flatTilePrefabs[num2], (Vector3)(&x2), (Quaternion)(&num3));
							bool flag5 = (object)gameObject4 == null;
							random = flatTilePrefabs[num2];
							if (!flag5)
							{
								Transform transform6 = gameObject4.transform;
								float num4 = UnityEngine.Random.Range(0f, 360f);
								Quaternion quaternion2 = Quaternion.Internal_FromEulerRad((Vector3)(&obj3));
								bool flag6 = (object)transform6 == null;
								random = (GameObject)(&enumerator2);
								if (!flag6)
								{
									transform6.localRotation = (Quaternion)(&num3);
									gameObject4.SetActive(value: true);
									Transform transform7 = gameObject4.transform;
									random = generateTileObjects.tileObjectsParent;
									if ((object)generateTileObjects.tileObjectsParent != null)
									{
										Transform parentInternal = generateTileObjects.tileObjectsParent.transform;
										if ((object)transform7 != null)
										{
											transform7.parentInternal = parentInternal;
											continue;
										}
										throw new NullReferenceException();
									}
									throw new NullReferenceException();
								}
								throw new NullReferenceException();
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				throw new IndexOutOfRangeException();
			}
			throw new NullReferenceException();
		}
		enumerator.Dispose();
		GenerateTileObjects generateTileObjects2 = default(GenerateTileObjects);
		if ((object)generateTileObjects2.tileObjectsParent != null)
		{
			MeshFilter[] componentsInChildren = generateTileObjects2.tileObjectsParent.GetComponentsInChildren<MeshFilter>();
			bool flag7 = componentsInChildren == null;
			object obj4 = 0;
			if (!flag7)
			{
				while (true)
				{
					if ((nint)obj4 < componentsInChildren.Length)
					{
						if ((object)componentsInChildren[obj4] == null)
						{
							break;
						}
						Transform transform8 = componentsInChildren[obj4].transform;
						if ((object)transform8 == null)
						{
							break;
						}
						Transform parent = transform8.parent;
						if (parent != null)
						{
							GameObject gameObject5 = componentsInChildren[obj4].gameObject;
							if ((object)gameObject5 == null)
							{
								break;
							}
							if (!gameObject5.isStatic)
							{
								GameObject gameObject6 = componentsInChildren[obj4].gameObject;
								if ((object)gameObject6 == null)
								{
									break;
								}
								if (!gameObject6.CompareTag("Ignore"))
								{
									Transform transform9 = componentsInChildren[obj4].transform;
									if ((object)transform9 == null)
									{
										break;
									}
									transform9.parentInternal = null;
								}
							}
						}
						obj4++;
						continue;
					}
					StaticBatchingUtility.Combine(generateTileObjects2.tileObjectsParent);
					return;
				}
			}
		}
		goto IL_09d0;
		IL_0a77:
		GameObject gameObject7 = UnityEngine.Object.Instantiate(original, position3, (Quaternion)(&x));
		if ((object)stageData != null)
		{
			StageTilePrefabs stageTilePrefabs = stageData.stageTilePrefabs;
			if (stageData.stageTilePrefabs != null)
			{
				flatTilePrefabs = stageTilePrefabs.flatTilePrefabs;
				if (stageTilePrefabs.flatTilePrefabs == null || flatTilePrefabs.Length == 0)
				{
					return;
				}
				List<Vector3> list2 = new List<Vector3>();
				if (stageData.stageTilePrefabs != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si r12d,xmm0\"");
					object obj5 = default(object);
					bool flag8 = (nint)obj5 <= 0;
					object obj6 = 0;
					if (flag8)
					{
						bool flag9 = list2 == null;
						generateTileObjects = this;
						if (!flag9)
						{
							goto IL_05ba;
						}
					}
					else
					{
						while (MyRandom.random != null)
						{
							int index3 = ((List<T>)(object)MyRandom.random).IndexOf((T)null);
							GameObject gameObject8 = list.get_Item(index3);
							if ((object)gameObject8 == null)
							{
								break;
							}
							Transform transform10 = gameObject8.transform;
							if ((object)transform10 == null)
							{
								break;
							}
							Vector3 position4 = transform10.position;
							if (list2 == null)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1502 @ rax_v44 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+1C]");
							_ = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1502 @ rax_v44 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
							object obj7 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1502 @ rax_v44 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
							if ((nint)0 == 0)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1502 @ rax_v44 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
							nint num5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v262 @ rdx_v60+18]");
							if (num5 >= 0)
							{
								list2.AddWithResize((Vector3)(&x2));
								x2 = position4.x;
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1502 @ rax_v44 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
								object obj8 = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1502 @ rax_v44 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
								object obj9 = (nint)0 * (nint)2;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1502 @ rax_v44 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
								object obj10 = 0 + obj9;
								_ = position4.x;
								_ = position4.z;
							}
							((List<object>)(object)list).RemoveAt(index3);
							obj6++;
							if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5))
							{
								continue;
							}
							goto IL_0589;
						}
					}
				}
			}
		}
		goto IL_09d0;
		IL_09d0:
		throw new NullReferenceException();
		IL_0589:
		generateTileObjects = generateTileObjects2;
		goto IL_05ba;
	}

	private unsafe void MapSpecificTiles(List<GameObject> available, StageData stageData)
	{
		//IL_01fb: Expected O, but got Ref
		//IL_0381: Expected O, but got Ref
		//IL_0381: Expected O, but got Ref
		//IL_0237: Expected O, but got Ref
		//IL_0237: Expected O, but got Ref
		//IL_0260: Expected O, but got I
		StageTilePrefabs stageTilePrefabs = stageData.stageTilePrefabs;
		GameObject[] mapSpecificTilesPrefabs = stageTilePrefabs.mapSpecificTilesPrefabs;
		if (mapSpecificTilesPrefabs.Length == 0)
		{
			return;
		}
		IEnumerable<int> source = Enumerable.Range(0, available._size);
		Func<int, float> keySelector = _003C_003Ec._003C_003E9__6_0;
		if (_003C_003Ec._003C_003E9__6_0 == null)
		{
			keySelector = (_003C_003Ec._003C_003E9__6_0 = (int _) => UnityEngine.Random.value);
		}
		IOrderedEnumerable<int> source2 = Enumerable.OrderBy(source, keySelector);
		List<int> list = Enumerable.ToList(source2);
		List<GameObject> list2 = new List<GameObject>();
		StageTilePrefabs stageTilePrefabs2 = stageData.stageTilePrefabs;
		int num = 1;
		Material grassMaterial = default(Material);
		float x = default(float);
		Vector3 upVector = default(Vector3);
		StageData stageData2 = default(StageData);
		float x2 = default(float);
		float x3 = default(float);
		while (true)
		{
			int num2 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v640 @ rax_v13 (System.Collections.Generic.List`1<System.Int32>)+18]");
			if ((nint)num2 >= (nint)0)
			{
				break;
			}
			int num3 = list.get_Item(num);
			if (num3 != 0)
			{
				GameObject gameObject = available.get_Item(num3);
				ProceduralTile component = gameObject.GetComponent<ProceduralTile>();
				int index = num3 - 1;
				GameObject gameObject2 = available.get_Item(index);
				ProceduralTile component2 = gameObject2.GetComponent<ProceduralTile>();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v808 @ rax_v28 (ProceduralTile)+3C]");
				if ((nint)0 != 0)
				{
					GameObject gameObject3 = available.get_Item(num3);
					Transform transform = gameObject3.transform;
					Vector3 position = transform.position;
					GameObject gameObject4 = available.get_Item(num3);
					Transform transform2 = gameObject4.transform;
					Quaternion rotation = transform2.rotation;
					Vector3 vector = VectorExtensions.XZVector((Vector3)(&grassMaterial));
					Quaternion quaternion = Quaternion.LookRotation((Vector3)(&x), (Vector3)(&upVector));
					StageTilePrefabs stageTilePrefabs3 = stageData2.stageTilePrefabs;
					GameObject[] mapSpecificTilesPrefabs2 = stageTilePrefabs3.mapSpecificTilesPrefabs;
					GameObject gameObject5 = UnityEngine.Object.Instantiate(mapSpecificTilesPrefabs2[0], (Vector3)(&x2), (Quaternion)(&x3));
					GameObject position2 = available.get_Item(num3);
					GameObject gameObject6 = UnityEngine.Object.Instantiate((GameObject)(object)list2, (Vector3)position2, (Quaternion)0);
					bool flag = list2._size >= stageTilePrefabs2.numSpecificTiles;
					x = vector.x;
					upVector = Vector3.upVector;
					x2 = position.x;
					x3 = quaternion.x;
					grassMaterial = ((StageData)(object)component2).grassMaterial;
					if (flag)
					{
						break;
					}
				}
			}
			num++;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
		List<object>.Enumerator enumerator = default(List<object>.Enumerator);
		object item = default(object);
		while (enumerator.MoveNext())
		{
			bool flag2 = ((List<object>)(object)available).Remove(item);
		}
		((List<GameObject>.Enumerator*)(&enumerator))->Dispose();
	}
}
