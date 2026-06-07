using System;
using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[Serializable]
	public class ERDecal : ScriptableObject
	{
		public int id = 0;

		public new string name = "";

		public double roadType1 = 0.0;

		public double roadType2 = 0.0;

		public int connection = 0;

		public GameObject decalPrefab;

		public float baseWidth = 6f;

		public float meshWidth = 0f;

		public float scale = 1f;

		public Vector3 localScale = new Vector3(1f, 1f, 1f);

		public int priority = 0;

		public bool collapsed = false;

		public float heightOffset = 0.005f;

		public void Init(GameObject prefab, float baseWidth)
		{
			int min = 1;
			int max = 999999999;
			id = UnityEngine.Random.Range(min, max);
			decalPrefab = prefab;
			this.baseWidth = baseWidth;
			ODCDDQCCOC();
		}

		public static ERDecal CreateInstance(GameObject prefab, float baseWidth)
		{
			ERDecal eRDecal = ScriptableObject.CreateInstance<ERDecal>();
			eRDecal.Init(prefab, baseWidth);
			return eRDecal;
		}

		public static void CopyDecal(ERDecalClass source, ERDecal target)
		{
			target.id = source.id;
			target.name = source.name;
			target.roadType1 = source.roadType1;
			target.roadType2 = source.roadType2;
			target.connection = source.connection;
			target.decalPrefab = source.decalPrefab;
			target.baseWidth = source.baseWidth;
			target.meshWidth = source.meshWidth;
			target.scale = source.scale;
			target.localScale = source.localScale;
			target.priority = source.priority;
			target.collapsed = source.collapsed;
			target.heightOffset = source.heightOffset;
		}

		public void ODCDDQCCOC()
		{
			if (!(decalPrefab != null))
			{
				return;
			}
			Bounds bounds = default(Bounds);
			MeshFilter[] componentsInChildren = decalPrefab.GetComponentsInChildren<MeshFilter>();
			float num = 0f;
			MeshFilter[] array = componentsInChildren;
			foreach (MeshFilter meshFilter in array)
			{
				if (meshFilter.sharedMesh != null)
				{
					float num2 = meshFilter.sharedMesh.bounds.size.x * meshFilter.transform.localScale.x;
					if (num2 > num)
					{
						num = num2;
					}
				}
			}
			meshWidth = num;
		}

		public static ERDecal OCOQQQDOOQ(int id, List<ERDecal> decalPresets)
		{
			foreach (ERDecal decalPreset in decalPresets)
			{
				if (decalPreset != null && decalPreset.id == id)
				{
					return decalPreset;
				}
			}
			return null;
		}

		public static string[] OCDODDDCCD(List<ERDecal> decals, string firstItem, int id1, int id2, ref int _index1, ref int _index2)
		{
			List<string> list = new List<string>();
			int num = 0;
			string text = "";
			foreach (ERDecal decal in decals)
			{
				if (decal != null)
				{
					text = ((!(decal.decalPrefab != null)) ? "missing prefab" : decal.decalPrefab.name);
					list.Add(num + ". " + text);
					if (decal.id == id1)
					{
						_index1 = num + 1;
					}
					if (decal.id == id2)
					{
						_index2 = num + 1;
					}
					num++;
				}
			}
			if (list.Count == 0)
			{
				list.Add("No Decal Presets Available");
			}
			else if (firstItem != "")
			{
				list.Insert(0, firstItem);
			}
			return list.ToArray();
		}

		public static GameObject[] OCDOODQOQD(List<ERDecal> decals, ref List<int> priority, ref List<float> scale)
		{
			List<GameObject> list = new List<GameObject>();
			foreach (ERDecal decal in decals)
			{
				if (decal != null)
				{
					list.Add(decal.decalPrefab);
					priority.Add(decal.priority);
					scale.Add(decal.scale);
				}
			}
			return list.ToArray();
		}
	}
}
