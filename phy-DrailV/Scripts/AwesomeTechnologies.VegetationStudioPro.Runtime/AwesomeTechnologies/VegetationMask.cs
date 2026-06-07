using System;
using System.Collections.Generic;
using System.Linq;
using AwesomeTechnologies.Utility;
using AwesomeTechnologies.Utility.Extentions;
using UnityEngine;

namespace AwesomeTechnologies
{
	[ExecuteInEditMode]
	public class VegetationMask : MonoBehaviour
	{
		public bool RemoveGrass = true;

		public bool RemovePlants = true;

		public bool RemoveTrees = true;

		public bool RemoveObjects = true;

		public bool RemoveLargeObjects = true;

		public float AdditionalGrassPerimiter;

		public float AdditionalPlantPerimiter;

		public float AdditionalTreePerimiter;

		public float AdditionalObjectPerimiter;

		public float AdditionalLargeObjectPerimiter;

		public float AdditionalGrassPerimiterMax;

		public float AdditionalPlantPerimiterMax;

		public float AdditionalTreePerimiterMax;

		public float AdditionalObjectPerimiterMax;

		public float AdditionalLargeObjectPerimiterMax;

		public float NoiseScaleGrass = 5f;

		public float NoiseScalePlant = 5f;

		public float NoiseScaleTree = 5f;

		public float NoiseScaleObject = 5f;

		public float NoiseScaleLargeObject = 5f;

		public string Id;

		public bool IncludeVegetationType;

		public List<Node> Nodes = new List<Node>();

		public bool ClosedArea = true;

		public bool ShowArea = true;

		public bool ShowHandles = true;

		public string MaskName = "";

		public LayerMask GroundLayerMask;

		public List<VegetationTypeSettings> VegetationTypeList = new List<VegetationTypeSettings>();

		private Vector3 _lastPosition;

		private Quaternion _lastRotation;

		private bool _needInit;

		private void Start()
		{
			_lastPosition = base.transform.position;
			_lastRotation = base.transform.rotation;
			if (Nodes.Count == 0)
			{
				CreateDefaultNodes();
			}
			PositionNodes();
		}

		public virtual void Awake()
		{
		}

		public void AddVegetationTypes(BaseMaskArea maskArea)
		{
			for (int i = 0; i <= VegetationTypeList.Count - 1; i++)
			{
				maskArea.VegetationTypeList.Add(new VegetationTypeSettings(VegetationTypeList[i]));
			}
		}

		private void OnEnable()
		{
			if (Id == "")
			{
				Id = Guid.NewGuid().ToString();
			}
		}

		public virtual void Reset()
		{
			if (Id == "")
			{
				Id = Guid.NewGuid().ToString();
			}
			ClearNodes();
			CreateDefaultNodes();
		}

		private void CreateDefaultNodes()
		{
			Bounds bounds = new Bounds(new Vector3(0f, 0f, 0f), new Vector3(6f, 1f, 6f));
			ClearNodes();
			for (int i = 0; i <= 3; i++)
			{
				Node node = new Node();
				switch (i)
				{
				case 0:
					node.Position = new Vector3(bounds.extents.x, bounds.extents.y, bounds.extents.z);
					break;
				case 1:
					node.Position = new Vector3(0f - bounds.extents.x, bounds.extents.y, bounds.extents.z);
					break;
				case 2:
					node.Position = new Vector3(0f - bounds.extents.x, bounds.extents.y, 0f - bounds.extents.z);
					break;
				case 3:
					node.Position = new Vector3(bounds.extents.x, bounds.extents.y, 0f - bounds.extents.z);
					break;
				}
				Nodes.Add(node);
			}
			PositionNodes();
		}

		public void ClearNodes()
		{
			Nodes.Clear();
		}

		public void PositionNodes()
		{
			for (int i = 0; i <= Nodes.Count - 1; i++)
			{
				RaycastHit[] array = (from h in Physics.RaycastAll(new Ray(base.transform.TransformPoint(Nodes[i].Position) + new Vector3(0f, 2000f, 0f), Vector3.down))
					orderby h.distance
					select h).ToArray();
				for (int num = 0; num <= array.Length - 1; num++)
				{
					if (array[num].collider is TerrainCollider || GroundLayerMask.Contains(array[num].collider.gameObject.layer))
					{
						Nodes[i].Position = base.transform.InverseTransformPoint(array[num].point);
						break;
					}
				}
			}
			UpdateVegetationMask();
		}

		public List<Vector3> GetWorldSpaceNodePositions()
		{
			List<Vector3> list = new List<Vector3>();
			for (int i = 0; i <= Nodes.Count - 1; i++)
			{
				list.Add(base.transform.TransformPoint(Nodes[i].Position));
			}
			return list;
		}

		public virtual void UpdateVegetationMask()
		{
		}

		public void DeleteNode(Node node)
		{
			Nodes.Remove(node);
		}

		public void AddNodesToEnd(Vector3[] worldPositions)
		{
			for (int i = 0; i <= worldPositions.Length - 1; i++)
			{
				AddNodeToEnd(worldPositions[i]);
			}
		}

		public void AddNodesToEnd(Vector3[] worldPositions, float[] customWidth, bool[] active)
		{
			for (int i = 0; i <= worldPositions.Length - 1; i++)
			{
				AddNodeToEnd(worldPositions[i], customWidth[i], active[i]);
			}
		}

		public void AddNodeToEnd(Vector3 worldPosition)
		{
			Node item = new Node
			{
				Position = base.transform.InverseTransformPoint(worldPosition)
			};
			Nodes.Add(item);
		}

		public void AddNodeToEnd(Vector3 worldPosition, float customWidth, bool active)
		{
			Node item = new Node
			{
				Position = base.transform.InverseTransformPoint(worldPosition),
				CustomWidth = customWidth,
				OverrideWidth = true,
				Active = active
			};
			Nodes.Add(item);
		}

		public void AddNode(Vector3 worldPosition)
		{
			if (Nodes.Count == 0)
			{
				AddNodeToEnd(worldPosition);
				return;
			}
			Node node = FindClosestNode(worldPosition);
			Node nextNode = GetNextNode(node);
			Node previousNode = GetPreviousNode(node);
			LineSegment3D lineSegment3D = new LineSegment3D(base.transform.TransformPoint(node.Position), base.transform.TransformPoint(nextNode.Position));
			LineSegment3D lineSegment3D2 = new LineSegment3D(base.transform.TransformPoint(node.Position), base.transform.TransformPoint(previousNode.Position));
			float num = lineSegment3D.DistanceTo(worldPosition);
			float num2 = lineSegment3D2.DistanceTo(worldPosition);
			Node item = new Node
			{
				Position = base.transform.InverseTransformPoint(worldPosition)
			};
			int nodeIndex = GetNodeIndex(node);
			if (num < num2)
			{
				if (nodeIndex == Nodes.Count - 1)
				{
					Nodes.Add(item);
				}
				else
				{
					Nodes.Insert(nodeIndex + 1, item);
				}
			}
			else
			{
				Nodes.Insert(nodeIndex, item);
			}
		}

		public int GetNodeIndex(Node node)
		{
			int result = 0;
			for (int i = 0; i <= Nodes.Count - 1; i++)
			{
				if (Nodes[i] == node)
				{
					result = i;
					break;
				}
			}
			return result;
		}

		public Node GetNextNode(Node node)
		{
			int num = 0;
			for (int i = 0; i <= Nodes.Count - 1; i++)
			{
				if (Nodes[i] == node)
				{
					num = i;
					break;
				}
			}
			if (num == Nodes.Count - 1)
			{
				return Nodes[0];
			}
			return Nodes[num + 1];
		}

		public Node GetPreviousNode(Node node)
		{
			int num = 0;
			for (int i = 0; i <= Nodes.Count - 1; i++)
			{
				if (Nodes[i] == node)
				{
					num = i;
					break;
				}
			}
			if (num == 0)
			{
				return Nodes[Nodes.Count - 1];
			}
			return Nodes[num - 1];
		}

		public Node FindClosestNode(Vector3 worldPosition)
		{
			Node result = null;
			float num = float.MaxValue;
			for (int i = 0; i <= Nodes.Count - 1; i++)
			{
				float num2 = Vector3.Distance(worldPosition, base.transform.TransformPoint(Nodes[i].Position));
				if (num2 < num)
				{
					num = num2;
					result = Nodes[i];
				}
			}
			return result;
		}

		private void DrawGizmos()
		{
			_ = ShowArea;
		}

		public virtual void OnDrawGizmosSelected()
		{
			DrawGizmos();
		}

		private Vector3 GetMaskCenter()
		{
			List<Vector3> worldSpaceNodePositions = GetWorldSpaceNodePositions();
			return GetMeanVector(worldSpaceNodePositions.ToArray());
		}

		private Vector3 GetMeanVector(Vector3[] positions)
		{
			if (positions.Length == 0)
			{
				return Vector3.zero;
			}
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			for (int i = 0; i < positions.Length; i++)
			{
				Vector3 vector = positions[i];
				num += vector.x;
				num2 += vector.y;
				num3 += vector.z;
			}
			return new Vector3(num / (float)positions.Length, num2 / (float)positions.Length, num3 / (float)positions.Length);
		}
	}
}
