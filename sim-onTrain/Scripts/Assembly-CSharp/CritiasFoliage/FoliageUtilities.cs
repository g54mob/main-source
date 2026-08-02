using System;
using System.Collections.Generic;
using UnityEngine;

namespace CritiasFoliage
{
	public class FoliageUtilities
	{
		public static GameObject ExtractFromFoliagePrefab(GameObject foliageType, EExtractType extractType, bool shouldBeStatic)
		{
			GameObject gameObject = null;
			switch (extractType)
			{
			case EExtractType.COLLIDERS:
			case EExtractType.RENDERERS:
			case EExtractType.RENDERERS_FOR_COLLIDER_MESHES_NAVMESH:
			{
				Type[] array = null;
				Type type = null;
				switch (extractType)
				{
				case EExtractType.COLLIDERS:
					array = new Type[1] { typeof(Collider) };
					type = typeof(Collider);
					break;
				case EExtractType.RENDERERS_FOR_COLLIDER_MESHES_NAVMESH:
					array = new Type[2]
					{
						typeof(Collider),
						typeof(MeshFilter)
					};
					type = typeof(Renderer);
					break;
				case EExtractType.RENDERERS:
					array = new Type[2]
					{
						typeof(Collider),
						typeof(MeshFilter)
					};
					type = typeof(Renderer);
					break;
				}
				if (array != null)
				{
					for (int i = 0; i < array.Length; i++)
					{
						if (foliageType.GetComponentInChildren(array[i]) == null)
						{
							return null;
						}
					}
				}
				gameObject = UnityEngine.Object.Instantiate(foliageType);
				gameObject.name = extractType.ToString() + "_Prototype_" + foliageType.name;
				if (extractType == EExtractType.COLLIDERS)
				{
					LODGroup component = gameObject.GetComponent<LODGroup>();
					if ((bool)component)
					{
						UnityEngine.Object.DestroyImmediate(component);
					}
				}
				for (int num = gameObject.transform.childCount - 1; num >= 0; num--)
				{
					GameObject gameObject2 = gameObject.transform.GetChild(num).gameObject;
					if (gameObject2.GetComponent(type) == null)
					{
						UnityEngine.Object.DestroyImmediate(gameObject2);
					}
				}
				Component[] componentsInChildren = gameObject.GetComponentsInChildren<Component>();
				for (int j = 0; j < componentsInChildren.Length; j++)
				{
					if (extractType == EExtractType.COLLIDERS)
					{
						if (!componentsInChildren[j].GetType().IsSubclassOf(type) && !(componentsInChildren[j] is Transform))
						{
							UnityEngine.Object.DestroyImmediate(componentsInChildren[j]);
						}
					}
					else if (!componentsInChildren[j].GetType().IsSubclassOf(type) && !(componentsInChildren[j] is Transform) && !(componentsInChildren[j] is LODGroup) && !(componentsInChildren[j] is MeshFilter))
					{
						UnityEngine.Object.DestroyImmediate(componentsInChildren[j]);
					}
				}
				break;
			}
			case EExtractType.NON_MODIFIED:
				gameObject = UnityEngine.Object.Instantiate(foliageType);
				gameObject.name = extractType.ToString() + "_Prototype_" + foliageType.name;
				break;
			}
			return gameObject;
		}

		public static Bounds LocalToWorld(ref Bounds box, Matrix4x4 m)
		{
			return LocalToWorld(ref box, ref m);
		}

		public static Bounds LocalToWorld(ref Bounds box, ref Matrix4x4 m)
		{
			Bounds result = new Bounds(Vector3.zero, Vector3.zero);
			result.min = new Vector3(m[12], m[13], m[14]);
			result.max = new Vector3(m[12], m[13], m[14]);
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					float num = m[i, j] * box.min[j];
					float num2 = m[i, j] * box.max[j];
					if (num < num2)
					{
						Vector3 min = result.min;
						Vector3 max = result.max;
						min[i] += num;
						max[i] += num2;
						result.min = min;
						result.max = max;
					}
					else
					{
						Vector3 min = result.min;
						Vector3 max = result.max;
						min[i] += num2;
						max[i] += num;
						result.min = min;
						result.max = max;
					}
				}
			}
			return result;
		}

		public static void Shuffle<T>(IList<T> collection)
		{
			for (int i = 0; i < collection.Count; i++)
			{
				T value = collection[i];
				int index = UnityEngine.Random.Range(0, collection.Count);
				collection[i] = collection[index];
				collection[index] = value;
			}
		}

		public static int GetStableHashCode(string str)
		{
			int num = 352654597;
			int num2 = num;
			for (int i = 0; i < str.Length; i += 2)
			{
				num = ((num << 5) + num) ^ str[i];
				if (i == str.Length - 1)
				{
					break;
				}
				num2 = ((num2 << 5) + num2) ^ str[i + 1];
			}
			return num + num2 * 1566083941;
		}

		public static int GetStableHashCode(ref string str)
		{
			int num = 352654597;
			int num2 = num;
			for (int i = 0; i < str.Length; i += 2)
			{
				num = ((num << 5) + num) ^ str[i];
				if (i == str.Length - 1)
				{
					break;
				}
				num2 = ((num2 << 5) + num2) ^ str[i + 1];
			}
			return num + num2 * 1566083941;
		}
	}
}
