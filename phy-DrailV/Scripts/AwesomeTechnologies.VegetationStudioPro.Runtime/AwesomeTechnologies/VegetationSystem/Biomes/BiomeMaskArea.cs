using System;
using System.Collections.Generic;
using System.Linq;
using AwesomeTechnologies.Utility;
using AwesomeTechnologies.VegetationStudio;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace AwesomeTechnologies.VegetationSystem.Biomes
{
	[ExecuteInEditMode]
	public class BiomeMaskArea : MonoBehaviour
	{
		public List<Node> Nodes = new List<Node>();

		public bool ClosedArea = true;

		public bool ShowArea = true;

		public bool ShowHandles = true;

		public string MaskName = "";

		private bool _needInit;

		public string Id;

		public BiomeType BiomeType;

		public LayerMask GroundLayerMask;

		public AnimationCurve BlendCurve = new AnimationCurve();

		public AnimationCurve InverseBlendCurve = new AnimationCurve();

		public AnimationCurve TextureBlendCurve = new AnimationCurve();

		public float BlendDistance = 5f;

		public float NoiseScale = 20f;

		public bool UseNoise = true;

		private PolygonBiomeMask _currentMaskArea;

		private Vector3 _lastPosition;

		private Quaternion _lastRotation;

		private Vector3 _lastLossyScale;

		public void UpdateBiomeMask()
		{
			if (base.enabled && base.gameObject.activeSelf)
			{
				List<Vector3> worldSpaceNodePositions = GetWorldSpaceNodePositions();
				List<bool> disableEdgeList = GetDisableEdgeList();
				PolygonBiomeMask polygonBiomeMask = new PolygonBiomeMask
				{
					BiomeType = BiomeType,
					BlendDistance = BlendDistance,
					UseNoise = UseNoise,
					NoiseScale = NoiseScale
				};
				polygonBiomeMask.AddPolygon(worldSpaceNodePositions, disableEdgeList);
				if (!ValidateAnimationCurve(BlendCurve))
				{
					BlendCurve = CreateResetAnimationCurve();
				}
				if (!ValidateAnimationCurve(InverseBlendCurve))
				{
					InverseBlendCurve = CreateResetAnimationCurve();
				}
				if (!ValidateAnimationCurve(TextureBlendCurve))
				{
					TextureBlendCurve = CreateResetAnimationCurve();
				}
				polygonBiomeMask.SetCurve(BlendCurve.GenerateCurveArray(4096));
				polygonBiomeMask.SetInverseCurve(InverseBlendCurve.GenerateCurveArray(4096));
				polygonBiomeMask.SetTextureCurve(TextureBlendCurve.GenerateCurveArray(4096));
				if (_currentMaskArea != null)
				{
					VegetationStudioManager.RemoveBiomeMask(_currentMaskArea);
					_currentMaskArea = null;
				}
				_currentMaskArea = polygonBiomeMask;
				VegetationStudioManager.AddBiomeMask(polygonBiomeMask);
				RefreshPostProcessVolume();
			}
		}

		public bool ValidateAnimationCurve(AnimationCurve curve)
		{
			if (float.IsNaN(curve.Evaluate(0.5f)))
			{
				return false;
			}
			return true;
		}

		private AnimationCurve CreateResetAnimationCurve()
		{
			AnimationCurve animationCurve = new AnimationCurve();
			animationCurve.AddKey(0f, 0.5f);
			animationCurve.AddKey(1f, 0.5f);
			return animationCurve;
		}

		private List<bool> GetDisableEdgeList()
		{
			List<bool> list = new List<bool>();
			for (int i = 0; i <= Nodes.Count - 1; i++)
			{
				list.Add(Nodes[i].DisableEdge);
			}
			return list;
		}

		private void Start()
		{
			_lastPosition = base.transform.position;
			_lastRotation = base.transform.rotation;
			_lastLossyScale = base.transform.lossyScale;
			if (Nodes.Count == 0)
			{
				CreateDefaultNodes();
			}
		}

		private void OnDisable()
		{
			if (_currentMaskArea != null)
			{
				VegetationStudioManager.RemoveBiomeMask(_currentMaskArea);
				_currentMaskArea = null;
			}
		}

		private void Update()
		{
			if ((!Application.isPlaying || _needInit) && (_lastPosition != base.transform.position || _lastRotation != base.transform.rotation || _needInit || _lastLossyScale != base.transform.lossyScale))
			{
				PositionNodes();
				_lastPosition = base.transform.position;
				_lastRotation = base.transform.rotation;
				_lastLossyScale = base.transform.lossyScale;
				_needInit = false;
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
			BlendCurve.AddKey(0f, 0f);
			BlendCurve.AddKey(1f, 1f);
			InverseBlendCurve.AddKey(0f, 1f);
			InverseBlendCurve.AddKey(1f, 0f);
			TextureBlendCurve.AddKey(0f, 0f);
			TextureBlendCurve.AddKey(1f, 1f);
		}

		public void ClearNodes()
		{
			Nodes.Clear();
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

		public void AddNodesToEnd(Vector3[] worldPositions, bool[] disableEdges)
		{
			for (int i = 0; i <= worldPositions.Length - 1; i++)
			{
				AddNodeToEnd(worldPositions[i], disableEdges[i]);
			}
		}

		public void AddNodesToEnd(Vector3[] worldPositions, float[] customWidth, bool[] active)
		{
			for (int i = 0; i <= worldPositions.Length - 1; i++)
			{
				AddNodeToEnd(worldPositions[i], customWidth[i], active[i]);
			}
		}

		public void AddNodesToEnd(Vector3[] worldPositions, float[] customWidth, bool[] active, bool[] disableEdges)
		{
			for (int i = 0; i <= worldPositions.Length - 1; i++)
			{
				AddNodeToEnd(worldPositions[i], customWidth[i], active[i], disableEdges[i]);
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

		public void AddNodeToEnd(Vector3 worldPosition, bool disableEdge)
		{
			Node item = new Node
			{
				Position = base.transform.InverseTransformPoint(worldPosition),
				DisableEdge = disableEdge
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

		public void AddNodeToEnd(Vector3 worldPosition, float customWidth, bool active, bool disableEdge)
		{
			Node item = new Node
			{
				Position = base.transform.InverseTransformPoint(worldPosition),
				CustomWidth = customWidth,
				OverrideWidth = true,
				Active = active,
				DisableEdge = disableEdge
			};
			Nodes.Add(item);
		}

		private void OnEnable()
		{
			if (Id == "")
			{
				Id = Guid.NewGuid().ToString();
			}
			_needInit = true;
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
			UpdateBiomeMask();
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

		public List<Vector3> GetWorldSpaceNodePositions()
		{
			List<Vector3> list = new List<Vector3>();
			for (int i = 0; i <= Nodes.Count - 1; i++)
			{
				list.Add(base.transform.TransformPoint(Nodes[i].Position));
			}
			return list;
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
			if (!VegetationStudioManager.ShowBiomes)
			{
				DrawGizmos();
			}
		}

		public virtual void OnDrawGizmos()
		{
			if (VegetationStudioManager.ShowBiomes)
			{
				DrawGizmos();
			}
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

		public void RefreshPostProcessVolume()
		{
			PostProcessProfileInfo postProcessProfileInfo = VegetationStudioManager.GetPostProcessProfileInfo(BiomeType);
			RefreshPostProcessVolume(postProcessProfileInfo, VegetationStudioManager.GetPostProcessingLayer());
		}

		public void RefreshPostProcessVolume(PostProcessProfileInfo postProcessProfileInfo, LayerMask postProcessLayer)
		{
			base.gameObject.layer = postProcessLayer;
			if (postProcessProfileInfo == null)
			{
				PostProcessVolume component = base.gameObject.GetComponent<PostProcessVolume>();
				if ((bool)component)
				{
					UnityEngine.Object.DestroyImmediate(component);
				}
				MeshCollider component2 = base.gameObject.GetComponent<MeshCollider>();
				if ((bool)component2)
				{
					UnityEngine.Object.DestroyImmediate(component2);
				}
				return;
			}
			PostProcessVolume postProcessVolume = base.gameObject.GetComponent<PostProcessVolume>();
			if (!postProcessVolume)
			{
				postProcessVolume = base.gameObject.AddComponent<PostProcessVolume>();
			}
			postProcessVolume.blendDistance = postProcessProfileInfo.BlendDistance;
			postProcessVolume.priority = postProcessProfileInfo.Priority;
			postProcessVolume.weight = postProcessProfileInfo.Weight;
			postProcessVolume.profile = postProcessProfileInfo.PostProcessProfile;
			postProcessVolume.enabled = postProcessProfileInfo.Enabled;
			MeshCollider meshCollider = base.gameObject.GetComponent<MeshCollider>();
			if (!meshCollider)
			{
				meshCollider = base.gameObject.AddComponent<MeshCollider>();
			}
			meshCollider.convex = true;
			meshCollider.enabled = postProcessProfileInfo.Enabled;
			meshCollider.isTrigger = true;
			Vector3[] array = new Vector3[Nodes.Count];
			for (int i = 0; i <= Nodes.Count - 1; i++)
			{
				array[i] = Nodes[i].Position;
			}
			meshCollider.sharedMesh = MeshUtils.ExtrudeMeshFromPolygon(array, postProcessProfileInfo.VolumeHeight);
		}
	}
}
