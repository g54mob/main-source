using System;
using System.Collections.Generic;
using UnityEngine;

namespace EasyRoads3Dv3
{
	[Serializable]
	public class ERDecal : ScriptableObject
	{
		public int id = 0;

		public new string name = "Decal Preset";

		public ERDecalType type = ERDecalType.StartEnd;

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

		public Material material;

		public Vector2 uvLeftTop = new Vector2(0.45f, 0.75f);

		public Vector2 uvRightBottom = new Vector2(0.55f, 0.25f);

		public float width = 0.5f;

		public float length = 5f;

		public float xOffset = 0f;

		public float startOffset = 0f;

		public float endOffset = 0f;

		public float endRotation = 0f;

		public List<Vector2> uvBreakPoints = new List<Vector2>();

		public List<float> distances = new List<float>();

		public ERDecalPosition position = ERDecalPosition.Both;

		public Vector2 uvLeftTop1 = new Vector2(0.45f, 0.75f);

		public Vector2 uvRightBottom1 = new Vector2(0.55f, 0.25f);

		public Vector2 uvLeftTop2 = new Vector2(0.45f, 0.75f);

		public Vector2 uvRightBottom2 = new Vector2(0.55f, 0.25f);

		public float width1 = 0f;

		public float width2 = 0f;

		public ERLaneDirectionOptions laneDirecionType = ERLaneDirectionOptions.Straight;

		public float distance = 50f;

		public float distanceToIntersection = 25f;

		public float distanceAtIntersection = 25f;

		public List<Vector2> shape = new List<Vector2>();

		public List<float> shapeUVs = new List<float>();

		public bool startEndSections = false;

		public bool interpolatedStartEndSections = false;

		public bool projector = false;

		public int renderingLayerMask = 0;

		public float drawDistance = 500f;

		public float fadeDistance = 0.9f;

		public bool affectsTransparency = true;

		public float overlap = 0.5f;

		public bool previewState = false;

		public GameObject previewDecalObject = null;

		public void Init(GameObject prefab, float baseWidth)
		{
			int minInclusive = 1;
			int maxExclusive = 999999999;
			id = UnityEngine.Random.Range(minInclusive, maxExclusive);
			decalPrefab = prefab;
			this.baseWidth = baseWidth;
			if (prefab != null)
			{
				OCCCOQCCOO();
			}
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
			target.type = source.type;
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
			target.material = source.material;
			target.uvLeftTop = source.uvLeftTop;
			target.uvRightBottom = source.uvRightBottom;
			target.width = source.width;
			target.length = source.length;
			target.xOffset = source.xOffset;
			target.startOffset = source.startOffset;
			target.endOffset = source.endOffset;
			target.uvBreakPoints = new List<Vector2>(source.uvBreakPoints);
			target.distances = new List<float>(source.distances);
			target.uvLeftTop1 = source.uvLeftTop1;
			target.uvRightBottom1 = source.uvRightBottom1;
			target.uvLeftTop2 = source.uvLeftTop2;
			target.uvRightBottom2 = source.uvRightBottom2;
			target.width1 = source.width1;
			target.width2 = source.width2;
			target.laneDirecionType = source.laneDirecionType;
			target.distance = source.distance;
			target.distanceToIntersection = source.distanceToIntersection;
			target.distanceAtIntersection = source.distanceAtIntersection;
			target.shape = new List<Vector2>(source.shape);
			target.shapeUVs = new List<float>(source.shapeUVs);
			target.startEndSections = source.startEndSections;
			target.interpolatedStartEndSections = source.interpolatedStartEndSections;
			target.projector = source.projector;
			target.renderingLayerMask = source.renderingLayerMask;
			target.drawDistance = source.drawDistance;
			target.fadeDistance = source.fadeDistance;
			target.affectsTransparency = source.affectsTransparency;
			target.overlap = source.overlap;
		}

		public static void OCCOCDDOCQ(ERDecal source, ERDecal target, bool updateID = true)
		{
			if (updateID)
			{
				target.id = source.id;
			}
			target.name = source.name;
			target.type = source.type;
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
			target.material = source.material;
			target.uvLeftTop = source.uvLeftTop;
			target.uvRightBottom = source.uvRightBottom;
			target.width = source.width;
			target.length = source.length;
			target.xOffset = source.xOffset;
			target.startOffset = source.startOffset;
			target.endOffset = source.endOffset;
			target.uvBreakPoints = new List<Vector2>(source.uvBreakPoints);
			target.distances = new List<float>(source.distances);
			target.uvLeftTop1 = source.uvLeftTop1;
			target.uvRightBottom1 = source.uvRightBottom1;
			target.uvLeftTop2 = source.uvLeftTop2;
			target.uvRightBottom2 = source.uvRightBottom2;
			target.width1 = source.width1;
			target.width2 = source.width2;
			target.laneDirecionType = source.laneDirecionType;
			target.distance = source.distance;
			target.distanceToIntersection = source.distanceToIntersection;
			target.distanceAtIntersection = source.distanceAtIntersection;
			target.shape = new List<Vector2>(source.shape);
			target.shapeUVs = new List<float>(source.shapeUVs);
			target.startEndSections = source.startEndSections;
			target.interpolatedStartEndSections = source.interpolatedStartEndSections;
			target.projector = source.projector;
			target.renderingLayerMask = source.renderingLayerMask;
			target.drawDistance = source.drawDistance;
			target.fadeDistance = source.fadeDistance;
			target.affectsTransparency = source.affectsTransparency;
			target.overlap = source.overlap;
		}

		public void OCCCOQCCOO()
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

		public static ERDecal OOCQOOODDC(int id, List<ERDecal> decalPresets)
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

		public static ERDecal OCDDCQOQOO(List<ERDecal> decalPresets, ERLaneDirectionOptions direction)
		{
			if (decalPresets == null)
			{
				return null;
			}
			foreach (ERDecal decalPreset in decalPresets)
			{
				if (decalPreset != null && decalPreset.laneDirecionType == direction && decalPreset.type == ERDecalType.LaneDirectionMarking)
				{
					return decalPreset;
				}
			}
			return null;
		}

		public static List<ERDecal> FilterByType(List<ERDecal> lst, ERDecalType type)
		{
			List<ERDecal> list = new List<ERDecal>();
			foreach (ERDecal item in lst)
			{
				if (item != null && item.type == type)
				{
					list.Add(item);
				}
			}
			return list;
		}

		public static string[] ODODOQDDCO(ref List<ERDecal> decals, string firstItem, int id1, int id2, ref int _index1, ref int _index2, ERDecalType type, ERDecalPosition position)
		{
			List<string> list = new List<string>();
			List<ERDecal> list2 = new List<ERDecal>();
			int num = 0;
			string text = "";
			foreach (ERDecal decal in decals)
			{
				if (decal != null && decal.type == type && (type != ERDecalType.StartEnd || position == decal.position || decal.position == ERDecalPosition.Both))
				{
					list.Add(string.Concat(str2: (!(decal.decalPrefab != null) && type == ERDecalType.StartEnd) ? "missing prefab" : ((!(decal.decalPrefab != null)) ? decal.name : decal.decalPrefab.name), str0: num.ToString(), str1: ". "));
					if (decal.id == id1)
					{
						_index1 = num + 1;
					}
					if (decal.id == id2)
					{
						_index2 = num + 1;
					}
					list2.Add(decal);
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
			decals = list2;
			return list.ToArray();
		}

		public static int OOCOCCQDQO(List<ERDecal> decals, int tindex, ERDecalType type)
		{
			List<string> list = new List<string>();
			int num = 0;
			foreach (ERDecal decal in decals)
			{
				if (decal != null && decal.type == type)
				{
					num++;
					if (num == tindex)
					{
						return decal.id;
					}
				}
			}
			return -1;
		}

		public void UpdateShape(QDQDOOQQDQODD roadType)
		{
			float x = roadType.roadShape[0].x;
			float num = x;
			num -= width * 0.5f;
			float num2 = num;
			shape.Clear();
			int num3 = 0;
			float num4 = 0f;
			float num5 = 0f;
			Vector3 vector = Vector2.zero;
			Vector2 zero = Vector2.zero;
			Vector2 vector2 = Vector2.zero;
			bool flag = false;
			int num6 = 0;
			List<Vector2> nodes = roadType.roadShapeData.nodes;
			while (!flag)
			{
				if (num6 == 0)
				{
					Vector2 zero2 = Vector2.zero;
					zero2.y += heightOffset;
					if (xOffset < width * 0.5f)
					{
						shape.Add(zero2);
						num5 = 0f;
					}
					if (shape.Count == 0 || xOffset == 0f || nodes[0].y != 0f || nodes[1].y != 0f)
					{
						zero2.x = width * 0.5f - xOffset;
						num5 = zero2.x;
						if (shape.Count == 0 || nodes[0].y != 0f || nodes[1].y != 0f)
						{
							zero2.y += nodes[0].y;
							shape.Add(zero2);
						}
					}
					else if (!(xOffset < 0f))
					{
					}
					zero = zero2;
					vector2 = nodes[0];
					num3++;
				}
				float num7 = Vector3.Distance(vector2, nodes[num3]);
				if (num7 + num5 > width)
				{
					float num8 = width - num5;
					Vector3 vector3 = new Vector3(vector2.x, nodes[num3 - 1].y, 0f);
					Vector3 vector4 = new Vector3(nodes[num3].x, nodes[num3].y, 0f);
					vector = (vector4 - vector3).normalized;
					Vector3 vector5 = new Vector3(shape[shape.Count - 1].x, shape[shape.Count - 1].y, 0f) + vector * num8;
					shape.Add(new Vector2(vector5.x, vector5.y));
					flag = true;
				}
				else if (num3 > 0)
				{
					num7 = Mathf.Abs(vector2.x - nodes[num3].x);
					Vector2 vector6 = new Vector2(shape[shape.Count - 1].x + num7, nodes[num3].y + heightOffset);
					shape.Add(vector6);
					num5 += num7;
					zero = vector6;
					vector2 = nodes[num3];
					num3++;
					if (nodes[num3 - 1] == nodes[num3])
					{
						num3++;
					}
					if (num3 == nodes.Count)
					{
						flag = true;
					}
				}
				num6++;
			}
			shapeUVs.Clear();
			for (int i = 0; i < shape.Count; i++)
			{
				shapeUVs.Add(Mathf.Lerp(uvRightBottom.x, uvLeftTop.x, shape[i].x / width));
				Vector2 value = shape[i];
				value.x -= width * 0.5f;
				value.x *= -1f;
				shape[i] = value;
			}
			shape.Reverse();
			shapeUVs.Reverse();
		}

		public static GameObject[] OOCQOQQOQC(List<ERDecal> decals, ref List<int> priority, ref List<float> scale)
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

		public void MatchDistances(ref List<float> distances, List<Vector2> uvBreakPoints, float length)
		{
			if (distances.Count != uvBreakPoints.Count)
			{
				if (uvBreakPoints.Count > distances.Count)
				{
					for (int i = distances.Count; i < uvBreakPoints.Count; i++)
					{
						distances.Add(0f);
					}
				}
				else if (uvBreakPoints.Count == 0)
				{
					distances.Clear();
				}
				else
				{
					int num;
					for (num = uvBreakPoints.Count; num < distances.Count; num++)
					{
						distances.RemoveAt(num);
						num--;
					}
				}
			}
			SetBreakPointDistances(ref distances, uvBreakPoints, length);
		}

		public void SetBreakPointDistances(ref List<float> distances, List<Vector2> uvBreakPoints, float length)
		{
			for (int i = 0; i < uvBreakPoints.Count; i++)
			{
				distances[i] = uvBreakPoints[i].y * length;
			}
		}
	}
}
