using System.Collections.Generic;
using UnityEngine;

namespace AwesomeTechnologies.Utility.BVHTree
{
	public struct BVHNode
	{
		public int IsLeaf;

		public int NodeType;

		public Vector3 Centroid;

		public Vector3 Min;

		public Vector3 Max;

		public int PrimID;

		public int PrimitivesCount;

		public int PrimitivesOffset;

		public int NodeID;

		public int ParentID;

		public int LChildID;

		public int RChildID;

		public int SplitAxis;

		public float SplitValue;

		public int NearNodeID;

		public int FarNodeID;

		public int SplitMethod;

		public static BVHNode CreateBVHNode()
		{
			return new BVHNode
			{
				NodeType = 0,
				IsLeaf = 0,
				Centroid = Vector3.zero,
				Min = Vector3.one * float.MaxValue,
				Max = Vector3.one * float.MinValue,
				PrimID = -1,
				PrimitivesCount = 0,
				PrimitivesOffset = 0,
				NodeID = 0,
				ParentID = -1,
				LChildID = 0,
				RChildID = 0,
				NearNodeID = 0,
				FarNodeID = 0,
				SplitAxis = 0,
				SplitMethod = 1
			};
		}

		public BVHNode(List<BVHTriangle> tris, List<BVHNode> nodes, ref List<BVHTriangle> finalPrims)
		{
			this = CreateBVHNode();
			Centroid = Vector3.zero;
			Min = Vector3.zero;
			Max = Vector3.zero;
			NodeID = 0;
			CalculateBBox(tris);
			nodes.Add(this);
			if (tris.Count > 0)
			{
				Build(0, tris, ref nodes, ref finalPrims);
			}
		}

		public void Build(int nodeID, List<BVHTriangle> tris, ref List<BVHNode> nodes, ref List<BVHTriangle> finalPrims)
		{
			BVHNode value = nodes[nodeID];
			if (tris.Count <= BVH.MaxPrimsCountPerNode)
			{
				value.IsLeaf = 1;
				value.PrimitivesCount = 1;
				value.PrimitivesOffset = finalPrims.Count;
				finalPrims.Add(tris[0]);
				nodes[nodeID] = value;
				return;
			}
			List<BVHTriangle> list = new List<BVHTriangle>();
			List<BVHTriangle> list2 = new List<BVHTriangle>();
			switch (value.SplitMethod)
			{
			case 0:
			{
				value.GetLongestAxisAndValue();
				int splitAxis = value.SplitAxis;
				if (list.Count == 0 || list2.Count == 0)
				{
					switch (splitAxis)
					{
					case 0:
						tris.Sort(CompareX);
						break;
					case 1:
						tris.Sort(CompareY);
						break;
					case 2:
						tris.Sort(CompareZ);
						break;
					}
					int num2 = tris.Count / 2;
					list = tris.GetRange(0, num2);
					list2 = tris.GetRange(num2, tris.Count - num2);
				}
				break;
			}
			case 1:
			{
				value.GetLongestAxisAndValue();
				float splitValue = value.SplitValue;
				int splitAxis = value.SplitAxis;
				switch (splitAxis)
				{
				case 0:
					list = tris.FindAll((BVHTriangle n) => n.Centroid.x < splitValue);
					list2 = tris.FindAll((BVHTriangle n) => n.Centroid.x >= splitValue);
					break;
				case 1:
					list = tris.FindAll((BVHTriangle n) => n.Centroid.y < splitValue);
					list2 = tris.FindAll((BVHTriangle n) => n.Centroid.y >= splitValue);
					break;
				case 2:
					list = tris.FindAll((BVHTriangle n) => n.Centroid.z < splitValue);
					list2 = tris.FindAll((BVHTriangle n) => n.Centroid.z >= splitValue);
					break;
				}
				if (list.Count == 0 || list2.Count == 0)
				{
					switch (splitAxis)
					{
					case 0:
						tris.Sort(CompareX);
						break;
					case 1:
						tris.Sort(CompareY);
						break;
					case 2:
						tris.Sort(CompareZ);
						break;
					}
					int num = tris.Count / 2;
					list = tris.GetRange(0, num);
					list2 = tris.GetRange(num, tris.Count - num);
				}
				break;
			}
			}
			BVHNode item = CreateBVHNode();
			BVHNode item2 = CreateBVHNode();
			item.NodeID = nodes.Count;
			item2.NodeID = nodes.Count + 1;
			item.ParentID = value.NodeID;
			item2.ParentID = value.NodeID;
			item.NodeType = 1;
			item2.NodeType = 2;
			value.LChildID = item.NodeID;
			value.RChildID = item2.NodeID;
			item.CalculateBBox(list);
			item2.CalculateBBox(list2);
			nodes.Add(item);
			nodes.Add(item2);
			nodes[nodeID] = value;
			Build(item.NodeID, list, ref nodes, ref finalPrims);
			Build(item2.NodeID, list2, ref nodes, ref finalPrims);
		}

		public void GetLongestAxisAndValue()
		{
			float num = Mathf.Abs(Min.x - Max.x);
			if (num < 1E-06f)
			{
				num = 0f;
			}
			float num2 = Mathf.Abs(Min.y - Max.y);
			if (num2 < 1E-06f)
			{
				num2 = 0f;
			}
			float num3 = Mathf.Abs(Min.z - Max.z);
			if (num3 < 1E-06f)
			{
				num3 = 0f;
			}
			float[] array = new float[3] { num, num2, num3 };
			float num4 = Mathf.Max(array);
			for (int i = 0; i < array.Length; i++)
			{
				if (num4 == array[i])
				{
					SplitAxis = i;
					SplitValue = Centroid[i];
					return;
				}
			}
			SplitAxis = 0;
			SplitValue = 0f;
			Debug.LogError("NOTE:BBox longest side is not calculated properly!");
		}

		public GameObject CalculateBBox(List<BVHTriangle> tris)
		{
			for (int i = 0; i < tris.Count; i++)
			{
				Min = new Vector3(Mathf.Min(Min.x, tris[i].V0.x), Mathf.Min(Min.y, tris[i].V0.y), Mathf.Min(Min.z, tris[i].V0.z));
				Max = new Vector3(Mathf.Max(Max.x, tris[i].V0.x), Mathf.Max(Max.y, tris[i].V0.y), Mathf.Max(Max.z, tris[i].V0.z));
				Min = new Vector3(Mathf.Min(Min.x, tris[i].V1.x), Mathf.Min(Min.y, tris[i].V1.y), Mathf.Min(Min.z, tris[i].V1.z));
				Max = new Vector3(Mathf.Max(Max.x, tris[i].V1.x), Mathf.Max(Max.y, tris[i].V1.y), Mathf.Max(Max.z, tris[i].V1.z));
				Min = new Vector3(Mathf.Min(Min.x, tris[i].V2.x), Mathf.Min(Min.y, tris[i].V2.y), Mathf.Min(Min.z, tris[i].V2.z));
				Max = new Vector3(Mathf.Max(Max.x, tris[i].V2.x), Mathf.Max(Max.y, tris[i].V2.y), Mathf.Max(Max.z, tris[i].V2.z));
			}
			Centroid = (Min + Max) / 2f;
			return null;
		}

		private static int CompareX(BVHTriangle h1, BVHTriangle h2)
		{
			if (h1.Centroid.x - h2.Centroid.x < 0f)
			{
				return -1;
			}
			return 1;
		}

		private static int CompareY(BVHTriangle h1, BVHTriangle h2)
		{
			if (h1.Centroid.y - h2.Centroid.y < 0f)
			{
				return -1;
			}
			return 1;
		}

		private static int CompareZ(BVHTriangle h1, BVHTriangle h2)
		{
			if (h1.Centroid.z - h2.Centroid.z < 0f)
			{
				return -1;
			}
			return 1;
		}
	}
}
