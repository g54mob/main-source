using System;
using System.Collections.Generic;
using Assets.Scripts.Craft.Decals;
using Assets.Scripts.Craft.Parts.Events;
using BuoyancyToolkit;
using Cysharp.Threading.Tasks;
using Jundroo.Common.Meshes;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class FuselageScript : PartModifierScript
	{
		public class FuselageCorner
		{
			public int CornerStyleIndex { get; private set; }

			public List<int[]> Indices { get; private set; }

			public float ScalarZ { get; private set; }

			public Vector3i Scale { get; private set; }

			public bool SupportsSlant { get; set; }

			public FuselageCorner(int cornerStyleIndex, Vector3i scale, float scalarZ)
			{
				CornerStyleIndex = cornerStyleIndex;
				Scale = scale;
				Indices = new List<int[]>();
				ScalarZ = scalarZ;
			}

			public void AddVertex(int[] indices)
			{
				Indices.Add(indices);
			}

			public void SetPositions(Vector3[] targetPositions, Vector3[] vertices)
			{
				for (int i = 0; i < targetPositions.Length; i++)
				{
					Vector3 vector = targetPositions[i];
					for (int j = 0; j < Indices[i].Length; j++)
					{
						int num = Indices[i][j];
						vertices[num] = vector;
					}
				}
			}
		}

		public class FuselageEdge
		{
			public int AnchorIndex1 { get; set; }

			public int AnchorIndex2 { get; set; }

			public List<int> MiddleIndices { get; private set; }

			public bool UseDistanceFromLeadingEdge { get; set; }

			public FuselageEdge()
			{
				MiddleIndices = new List<int>();
			}

			public void UpdateEdge(Vector3[] verts, float distanceFromLeadingEdge)
			{
				Vector3 vector2;
				if (UseDistanceFromLeadingEdge)
				{
					Vector3 vector = verts[AnchorIndex2] - verts[AnchorIndex1];
					vector2 = verts[AnchorIndex1] + vector * distanceFromLeadingEdge;
				}
				else
				{
					vector2 = (verts[AnchorIndex1] + verts[AnchorIndex2]) * 0.5f;
				}
				for (int i = 0; i < MiddleIndices.Count; i++)
				{
					verts[MiddleIndices[i]] = vector2;
				}
			}
		}

		private class AdaptiveVertex
		{
			public int Index { get; set; }

			public Vector3 OriginalVertex { get; set; }

			public AdaptiveVertex(Vector3 v, int index)
			{
				OriginalVertex = v;
				Index = index;
			}
		}

		private static float[] _cornersInsetTemp = new float[16];

		private static Dictionary<string, (List<FuselageCorner> Corners, List<FuselageEdge> Edges)> _fuselageCornersAndEdgeCache = new Dictionary<string, (List<FuselageCorner>, List<FuselageEdge>)>();

		private static Vector3[] _syncNormalsTempArray = new Vector3[0];

		private static Vector3[] _syncNormalsTempArray224 = new Vector3[224];

		private static Vector3[] _syncNormalsTempArray392 = new Vector3[392];

		private static Vector3[] _syncNormalsTempArray448 = new Vector3[448];

		private static List<(int MyIndex, int OtherIndex)> _syncNormalsVertPair1TempList = new List<(int, int)>();

		private static List<(int MyIndex, int OtherIndex)> _syncNormalsVertPair2TempList = new List<(int, int)>();

		private static List<int> _syncNormalsVertPairDupsTempList = new List<int>();

		private static List<Vector3> _syncNormalsWorldPoints1TempList = new List<Vector3>();

		private static List<Vector3> _syncNormalsWorldPoints2TempList = new List<Vector3>();

		private int[] _backMergeVertices;

		private bool _backMergeVerticesWereCut;

		private List<int> _backNormals = new List<int>();

		private MeshCollider _collider;

		private Mesh _colliderMesh;

		private Mesh _cutMesh;

		private List<AdaptiveVertex> _frontCollider = new List<AdaptiveVertex>();

		private int[] _frontMergeVertices;

		private bool _frontMergeVerticesWereCut;

		private List<int> _frontNormals = new List<int>();

		private MeshFilter _meshFilter;

		private Mesh _nonCutMesh;

		private Vector3[] _nonMergedNormals;

		private Vector3[] _originalVertices;

		private List<AdaptiveVertex> _rearCollider = new List<AdaptiveVertex>();

		private bool _syncConnectedNormalsOnQueue;

		private bool _syncNormalsQueued;

		public bool Backwards
		{
			get
			{
				Vector3 forward = base.transform.forward;
				float num = -0.1f;
				if (!(forward.z < num) && !(forward.y < num))
				{
					return forward.z < num;
				}
				return true;
			}
		}

		public float ClampedSlant
		{
			get
			{
				float num = Fuselage.Offset.z / Fuselage.FrontScale.y;
				return Mathf.Clamp(Fuselage.InletSlant, 0f - num, num);
			}
		}

		public Collider Collider => _collider;

		public List<FuselageCorner> Corners { get; private set; }

		public List<FuselageEdge> Edges { get; private set; }

		public FuselageData Fuselage { get; set; }

		public bool IsCone => (Fuselage.FuselageType & FuselageType.Cone) != 0;

		public bool IsGlass => (Fuselage.FuselageType & FuselageType.Glass) != 0;

		public bool IsHollow => (Fuselage.FuselageType & FuselageType.Hollow) != 0;

		public bool IsInlet => (Fuselage.FuselageType & FuselageType.Inlet) != 0;

		public float MaxFuelCapacity => Fuselage.FuelVolume * 500f;

		private int[] BackMergeVertices
		{
			get
			{
				if (_backMergeVertices == null)
				{
					List<int> list = new List<int>();
					Mesh sharedMesh = _meshFilter.sharedMesh;
					Vector3[] vertices = sharedMesh.vertices;
					Vector3[] normals = sharedMesh.normals;
					for (int i = 0; i < sharedMesh.vertexCount; i++)
					{
						if (vertices[i].z < 0f && normals[i].z > -0.99f && normals[i].sqrMagnitude > 0.1f)
						{
							list.Add(i);
						}
					}
					_backMergeVertices = list.ToArray();
				}
				return _backMergeVertices;
			}
			set
			{
				_backMergeVertices = value;
			}
		}

		private int[] FrontMergeVertices
		{
			get
			{
				if (_frontMergeVertices == null)
				{
					List<int> list = new List<int>();
					Mesh sharedMesh = _meshFilter.sharedMesh;
					Vector3[] vertices = sharedMesh.vertices;
					Vector3[] normals = sharedMesh.normals;
					for (int i = 0; i < sharedMesh.vertexCount; i++)
					{
						if (vertices[i].z > 0f && normals[i].z < 0.99f && normals[i].sqrMagnitude > 0.1f)
						{
							list.Add(i);
						}
					}
					_frontMergeVertices = list.ToArray();
				}
				return _frontMergeVertices;
			}
			set
			{
				_frontMergeVertices = value;
			}
		}

		public event Action OnMeshRegenerated;

		public override void BuildPreStartInitializationPlan(PreStartInitializationPlan plan)
		{
			base.BuildPreStartInitializationPlan(plan);
			plan.Register(this, OnPreStart, PreStartInitializationFlags.FlightDefault);
		}

		public override void OnConnectedToPart(AttachPointData thisAttachPoint, PartData targetPart, AttachPointData targetAttachPoint, bool isSymmetryOperation)
		{
			if (!IsCone || thisAttachPoint.Id != 0 || !Fuselage.AutoSizeOnConnected)
			{
				return;
			}
			FuselageScript modifier = targetPart.PartScript.GetModifier<FuselageScript>();
			if (modifier != null)
			{
				Vector2 frontScale = Fuselage.FrontScale;
				if (targetAttachPoint.Id == 0)
				{
					frontScale = modifier.Fuselage.FrontScale;
				}
				else if (targetAttachPoint.Id == 1)
				{
					frontScale = modifier.Fuselage.RearScale;
				}
				if (frontScale.x > 0f && frontScale.y > 0f)
				{
					Fuselage.FrontScale = frontScale;
					UpdateMeshes(updateAttachPoints: false);
				}
			}
		}

		public override void OnMirrored(PartData sourcePart)
		{
			base.OnMirrored(sourcePart);
			Utilities.Swap(ref Fuselage.CornerTypes[0], ref Fuselage.CornerTypes[3]);
			Utilities.Swap(ref Fuselage.CornerTypes[1], ref Fuselage.CornerTypes[2]);
			Utilities.Swap(ref Fuselage.CornerTypes[4], ref Fuselage.CornerTypes[7]);
			Utilities.Swap(ref Fuselage.CornerTypes[5], ref Fuselage.CornerTypes[6]);
			FuselageData.FillParameters fillFront = Fuselage.FillFront;
			Utilities.Swap(ref fillFront.Left, ref fillFront.Right);
			Fuselage.FillFront = fillFront;
			fillFront = Fuselage.FillBack;
			Utilities.Swap(ref fillFront.Left, ref fillFront.Right);
			Fuselage.FillBack = fillFront;
			Fuselage.Offset = new Vector3(0f - Fuselage.Offset.x, Fuselage.Offset.y, Fuselage.Offset.z);
			UpdateMeshes();
		}

		public void QueueSyncNormals()
		{
			_syncNormalsQueued = true;
		}

		public void SyncNormals(bool updateConnected)
		{
			_syncNormalsQueued = false;
			_syncConnectedNormalsOnQueue = false;
			if (_nonMergedNormals == null)
			{
				_nonMergedNormals = _meshFilter.sharedMesh.normals;
			}
			bool flag = Fuselage.SmoothFront;
			bool smoothBack = Fuselage.SmoothBack;
			Vector3[] array;
			switch (_nonMergedNormals.Length)
			{
			case 224:
				array = _syncNormalsTempArray224;
				break;
			case 392:
				array = _syncNormalsTempArray392;
				break;
			case 448:
				array = _syncNormalsTempArray448;
				break;
			default:
				if (_syncNormalsTempArray.Length != _nonMergedNormals.Length)
				{
					_syncNormalsTempArray = new Vector3[_nonMergedNormals.Length];
				}
				array = _syncNormalsTempArray;
				break;
			}
			_nonMergedNormals.CopyTo(array, 0);
			AttachPointData attachPointData;
			AttachPointData attachPointData2;
			if (IsCone)
			{
				attachPointData = null;
				attachPointData2 = base.PartScript.Part.AttachPoints[0];
				flag = false;
			}
			else
			{
				attachPointData = base.PartScript.Part.AttachPoints[0];
				attachPointData2 = base.PartScript.Part.AttachPoints[1];
			}
			if ((flag || updateConnected) && !IsCone)
			{
				foreach (PartConnection partConnection in attachPointData.PartConnections)
				{
					PartData otherPart = partConnection.GetOtherPart(base.PartScript.Part);
					FuselageScript modifier = otherPart.PartScript.GetModifier<FuselageScript>();
					if (modifier != null)
					{
						AttachPointData otherAttachPoint = partConnection.GetOtherAttachPoint(attachPointData);
						bool flag2 = otherPart.AttachPoints.IndexOf(otherAttachPoint) == 0 && !modifier.IsCone;
						bool flag3 = (flag2 ? modifier.Fuselage.SmoothFront : modifier.Fuselage.SmoothBack);
						if (flag)
						{
							SyncNormalsWithOtherFuselage(modifier, thisFront: true, flag2, flag3, array);
						}
						if (flag3 && updateConnected)
						{
							modifier.QueueSyncNormals();
						}
					}
				}
			}
			if (smoothBack || updateConnected)
			{
				foreach (PartConnection partConnection2 in attachPointData2.PartConnections)
				{
					PartData otherPart2 = partConnection2.GetOtherPart(base.PartScript.Part);
					FuselageScript modifier2 = otherPart2.PartScript.GetModifier<FuselageScript>();
					if (modifier2 != null)
					{
						AttachPointData otherAttachPoint2 = partConnection2.GetOtherAttachPoint(attachPointData2);
						bool flag4 = otherPart2.AttachPoints.IndexOf(otherAttachPoint2) == 0 && !modifier2.IsCone;
						bool flag5 = (flag4 ? modifier2.Fuselage.SmoothFront : modifier2.Fuselage.SmoothBack);
						if (smoothBack)
						{
							SyncNormalsWithOtherFuselage(modifier2, thisFront: false, flag4, flag5, array);
						}
						if (flag5 && updateConnected)
						{
							modifier2.QueueSyncNormals();
						}
					}
				}
			}
			_meshFilter.sharedMesh.normals = array;
		}

		public void UpdateAttachPoints()
		{
			float max = float.PositiveInfinity;
			float min = float.NegativeInfinity;
			float max2 = float.PositiveInfinity;
			float min2 = float.NegativeInfinity;
			if (Fuselage.UseCutting)
			{
				(float MinX, float MaxX, float MinY, float MaxY) tuple = GetMinMax(Fuselage.FillFront, Fuselage.FrontScale);
				(float, float, float, float) tuple2 = GetMinMax(Fuselage.FillBack, Fuselage.RearScale);
				min = (tuple.MinX + tuple2.Item1) * 0.5f;
				max = (tuple.MaxX + tuple2.Item2) * 0.5f;
				min2 = (tuple.MinY + tuple2.Item3) * 0.5f;
				max2 = (tuple.MaxY + tuple2.Item4) * 0.5f;
			}
			Vector2 frontScale = Fuselage.FrontScale;
			Vector2 rearScale = Fuselage.RearScale;
			if (frontScale.x < 0.25f || frontScale.y < 0.25f || IsInlet)
			{
				EnableAttachPoint(0, enabled: false);
			}
			else
			{
				EnableAttachPoint(0, enabled: true);
			}
			Vector3 position = new Vector3(0f, 0f, 0.25f);
			position.x = position.x * Fuselage.FrontScale.x - Fuselage.Offset.x * 0.25f;
			position.y = position.y * Fuselage.FrontScale.y - Fuselage.Offset.y * 0.25f;
			position.z *= Fuselage.Offset.z;
			SetAttachPointPosition(0, position);
			if (base.PartScript.Part.AttachPoints.Count >= 2 && !base.PartScript.Part.AttachPoints[1].IsSurfaceAttachPoint)
			{
				if (rearScale.x < 0.25f || rearScale.y < 0.25f)
				{
					EnableAttachPoint(1, enabled: false);
				}
				else
				{
					EnableAttachPoint(1, enabled: true);
				}
				Vector3 position2 = new Vector3(0f, 0f, -0.25f);
				position2.x = position2.x * Fuselage.RearScale.x + Fuselage.Offset.x * 0.25f;
				position2.y = position2.y * Fuselage.RearScale.y + Fuselage.Offset.y * 0.25f;
				position2.z *= Fuselage.Offset.z;
				SetAttachPointPosition(1, position2);
				if (!IsInlet)
				{
					Vector3 position3 = new Vector3(0f, 0f, 0f);
					position3.x = (position.x + frontScale.x * 0.25f + position2.x + rearScale.x * 0.25f) / 2f;
					position3.x = Mathf.Clamp(position3.x, min, max);
					position3.y = Mathf.Clamp(position3.y, min2, max2);
					SetAttachPointPosition(5, position3);
					position3 = new Vector3(0f, 0f, 0f);
					position3.x = (position.x - frontScale.x * 0.25f + position2.x - rearScale.x * 0.25f) / 2f;
					position3.x = Mathf.Clamp(position3.x, min, max);
					position3.y = Mathf.Clamp(position3.y, min2, max2);
					SetAttachPointPosition(6, position3);
					position3 = new Vector3(0f, 0f, 0f);
					position3.y = (position.y + frontScale.y * 0.25f + position2.y + rearScale.y * 0.25f) / 2f;
					position3.x = Mathf.Clamp(position3.x, min, max);
					position3.y = Mathf.Clamp(position3.y, min2, max2);
					SetAttachPointPosition(3, position3);
					position3 = new Vector3(0f, 0f, 0f);
					position3.y = (position.y - frontScale.y * 0.25f + position2.y - rearScale.y * 0.25f) / 2f;
					position3.x = Mathf.Clamp(position3.x, min, max);
					position3.y = Mathf.Clamp(position3.y, min2, max2);
					SetAttachPointPosition(4, position3);
				}
			}
			static (float MinX, float MaxX, float MinY, float MaxY) GetMinMax(FuselageData.FillParameters fill, Vector2 size)
			{
				size *= 0.25f;
				float item = (fill.Left - 0.5f) * 2f * (0f - size.x);
				float item2 = (fill.Right - 0.5f) * 2f * size.x;
				float item3 = (fill.Bottom - 0.5f) * 2f * (0f - size.y);
				float item4 = (fill.Top - 0.5f) * 2f * size.y;
				return (MinX: item, MaxX: item2, MinY: item3, MaxY: item4);
			}
		}

		public void UpdateColliderMesh()
		{
			_collider.sharedMesh = null;
			FuselageData.FuselageColliderType fuselageColliderType = DetermineFuselageColliderType();
			if (fuselageColliderType == FuselageData.FuselageColliderType.ConvexMesh || fuselageColliderType == FuselageData.FuselageColliderType.NonConvexMesh)
			{
				_collider.convex = base.LoadContext != CraftLoadContext.Designer || fuselageColliderType != FuselageData.FuselageColliderType.NonConvexMesh;
				_collider.sharedMesh = _meshFilter.sharedMesh;
				return;
			}
			Vector3[] vertices = _colliderMesh.vertices;
			float max = float.PositiveInfinity;
			float min = float.NegativeInfinity;
			float max2 = float.PositiveInfinity;
			float min2 = float.NegativeInfinity;
			if (Fuselage.UseCutting)
			{
				min = (0f - (Fuselage.FillFront.Left - 0.5f)) * 0.5f;
				max = (Fuselage.FillFront.Right - 0.5f) * 0.5f;
				min2 = (0f - (Fuselage.FillFront.Bottom - 0.5f)) * 0.5f;
				max2 = (Fuselage.FillFront.Top - 0.5f) * 0.5f;
			}
			foreach (AdaptiveVertex item in _frontCollider)
			{
				Vector3 originalVertex = item.OriginalVertex;
				originalVertex.x = Mathf.Clamp(originalVertex.x, min, max);
				originalVertex.y = Mathf.Clamp(originalVertex.y, min2, max2);
				originalVertex.x = originalVertex.x * Fuselage.FrontScale.x - Fuselage.Offset.x * 0.25f;
				originalVertex.y = originalVertex.y * Fuselage.FrontScale.y - Fuselage.Offset.y * 0.25f;
				float num = originalVertex.y * ClampedSlant;
				originalVertex.z = originalVertex.z * Fuselage.Offset.z + num;
				vertices[item.Index] = originalVertex;
			}
			if (Fuselage.UseCutting)
			{
				min = (0f - (Fuselage.FillBack.Left - 0.5f)) * 0.5f;
				max = (Fuselage.FillBack.Right - 0.5f) * 0.5f;
				min2 = (0f - (Fuselage.FillBack.Bottom - 0.5f)) * 0.5f;
				max2 = (Fuselage.FillBack.Top - 0.5f) * 0.5f;
			}
			foreach (AdaptiveVertex item2 in _rearCollider)
			{
				Vector3 originalVertex2 = item2.OriginalVertex;
				originalVertex2.x = Mathf.Clamp(originalVertex2.x, min, max);
				originalVertex2.y = Mathf.Clamp(originalVertex2.y, min2, max2);
				originalVertex2.x = originalVertex2.x * Fuselage.RearScale.x + Fuselage.Offset.x * 0.25f;
				originalVertex2.y = originalVertex2.y * Fuselage.RearScale.y + Fuselage.Offset.y * 0.25f;
				originalVertex2.z *= Fuselage.Offset.z;
				vertices[item2.Index] = originalVertex2;
			}
			_colliderMesh.vertices = vertices;
			_collider.sharedMesh = _colliderMesh;
		}

		public void UpdateFuel()
		{
			if (base.LoadContext == CraftLoadContext.Designer)
			{
				FuelTankScript modifier = base.PartScript.GetModifier<FuelTankScript>();
				if (modifier != null)
				{
					float fuelPercentage = Fuselage.FuelPercentage;
					modifier.FuelTank.Capacity = MaxFuelCapacity * fuelPercentage;
					modifier.FuelTank.Fuel = modifier.FuelTank.Capacity;
				}
			}
		}

		public void UpdateMeshes(bool updateAttachPoints = true, bool isInitialize = false)
		{
			if (updateAttachPoints)
			{
				UpdateAttachPoints();
			}
			UpdateVisualMesh();
			UpdateFuel();
			UpdateColliderMesh();
			base.PartScript.ReinitializeCraftDecalRenderers();
			if (!isInitialize)
			{
				this.OnMeshRegenerated?.Invoke();
				Fuselage.InvokeOnMeshRegenerated();
			}
		}

		protected virtual void OnDestroy()
		{
			if (_colliderMesh != null)
			{
				UnityEngine.Object.Destroy(_colliderMesh);
				_colliderMesh = null;
			}
			if (base.LoadContext == CraftLoadContext.Designer)
			{
				base.PartScript.PartConnectionChanged -= OnPartConnectionChanged;
				if (base.PartScript.PartMaterialScript != null)
				{
					base.PartScript.PartMaterialScript.OnPaintedInDesigner -= OnPaintedInDesigner;
					base.PartScript.PartMaterialScript.OnBeforePaintInDesigner -= OnBeforePaintInDesigner;
				}
			}
			if (_nonCutMesh != null)
			{
				UnityEngine.Object.Destroy(_nonCutMesh);
			}
			if (_cutMesh != null)
			{
				UnityEngine.Object.Destroy(_cutMesh);
			}
		}

		protected override void OnInitialize()
		{
			_meshFilter = GetComponent<MeshFilter>();
			_colliderMesh = base.transform.parent.Find("Collider").GetComponent<MeshFilter>().mesh;
			_colliderMesh.name = $"FuselageCollider{base.PartScript.Part.Id}";
			_collider = base.transform.parent.Find("Collider").GetComponent<MeshCollider>();
			_nonCutMesh = _meshFilter.mesh;
			_originalVertices = _nonCutMesh.vertices;
			Vector3[] vertices = _colliderMesh.vertices;
			for (int i = 0; i < vertices.Length; i++)
			{
				Vector3 v = vertices[i];
				AdaptiveVertex item = new AdaptiveVertex(v, i);
				if (Utilities.CompareFloats(v.z, 0.25f, 0.01f))
				{
					_frontCollider.Add(item);
				}
				else
				{
					_rearCollider.Add(item);
				}
			}
			Vector3[] normals = _nonCutMesh.normals;
			for (int j = 0; j < normals.Length; j++)
			{
				if (Utilities.CompareFloats(normals[j].z, 1f, 0.01f))
				{
					_frontNormals.Add(j);
				}
				else if (Utilities.CompareFloats(normals[j].z, -1f, 0.01f))
				{
					_backNormals.Add(j);
				}
			}
			if (!_fuselageCornersAndEdgeCache.TryGetValue(base.PartScript.Part.PartType.PartTypeId, out (List<FuselageCorner>, List<FuselageEdge>) value))
			{
				value.Item1 = new List<FuselageCorner>();
				value.Item2 = new List<FuselageEdge>();
				BuildCorners(value.Item1, value.Item2, _nonCutMesh.vertices, IsInlet, IsHollow);
				_fuselageCornersAndEdgeCache.Add(base.PartScript.Part.PartType.PartTypeId, value);
			}
			(Corners, Edges) = value;
			if (base.LoadContext == CraftLoadContext.Designer)
			{
				base.PartScript.PartMaterialScript.OnBeforePaintInDesigner += OnBeforePaintInDesigner;
				base.PartScript.PartMaterialScript.OnPaintedInDesigner += OnPaintedInDesigner;
				base.PartScript.PartConnectionChanged += OnPartConnectionChanged;
			}
			UpdateMeshes(updateAttachPoints: true, isInitialize: true);
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterUpdate(OnUpdateInDesigner, CraftUpdateFlags.DesignerDefault);
		}

		private static FuselageCorner BuildCorner(List<FuselageCorner> corners, int cornerStyleIndex, int scaleX, int scaleY, int scaleZ, Vector3[] vertexPositions, Vector3[] verts, float scalarZ = 1f)
		{
			FuselageCorner fuselageCorner = new FuselageCorner(cornerStyleIndex, new Vector3i(scaleX, scaleY, scaleZ), scalarZ);
			for (int i = 0; i < vertexPositions.Length; i++)
			{
				Vector3 vec = vertexPositions[i];
				vec.x = (float)scaleX * vec.x;
				vec.y = (float)scaleY * vec.y;
				vec.z = (float)scaleZ * vec.z;
				List<int> list = new List<int>();
				for (int j = 0; j < verts.Length; j++)
				{
					if (Utilities.CompareVector3s(vec, verts[j], 0.1f))
					{
						list.Add(j);
					}
				}
				fuselageCorner.AddVertex(list.ToArray());
			}
			corners.Add(fuselageCorner);
			return fuselageCorner;
		}

		private static void BuildCorners(List<FuselageCorner> corners, List<FuselageEdge> edges, Vector3[] verts, bool isInlet, bool isHollow)
		{
			Vector3[] vertexPositions = new Vector3[7]
			{
				new Vector3(0.3f, 2.3f, 1f),
				new Vector3(0.8f, 2.2f, 1f),
				new Vector3(1.3f, 2f, 1f),
				new Vector3(1.7f, 1.7f, 1f),
				new Vector3(2f, 1.3f, 1f),
				new Vector3(2.2f, 0.8f, 1f),
				new Vector3(2.3f, 0.3f, 1f)
			};
			int cornerStyleIndex = 0;
			if (isInlet || isHollow)
			{
				Vector3[] array = new Vector3[7]
				{
					new Vector3(0.19042f, 1.59042f, 1f),
					new Vector3(0.55277f, 1.54272f, 1f),
					new Vector3(0.89042f, 1.40286f, 1f),
					new Vector3(1.18037f, 1.18037f, 1f),
					new Vector3(1.40286f, 0.89043f, 1f),
					new Vector3(1.54272f, 0.55277f, 1f),
					new Vector3(1.59043f, 0.19043f, 1f)
				};
				BuildCorner(corners, cornerStyleIndex, 1, 1, 1, vertexPositions, verts).SupportsSlant = true;
				BuildCorner(corners, cornerStyleIndex++, 1, 1, 1, array, verts).SupportsSlant = true;
				BuildCorner(corners, cornerStyleIndex, 1, -1, 1, vertexPositions, verts).SupportsSlant = true;
				BuildCorner(corners, cornerStyleIndex++, 1, -1, 1, array, verts).SupportsSlant = true;
				BuildCorner(corners, cornerStyleIndex, -1, -1, 1, vertexPositions, verts).SupportsSlant = true;
				BuildCorner(corners, cornerStyleIndex++, -1, -1, 1, array, verts).SupportsSlant = true;
				BuildCorner(corners, cornerStyleIndex, -1, 1, 1, vertexPositions, verts).SupportsSlant = true;
				BuildCorner(corners, cornerStyleIndex++, -1, 1, 1, array, verts).SupportsSlant = true;
				float scalarZ = 1f;
				if (isInlet)
				{
					scalarZ = 0.8f;
					for (int i = 0; i < array.Length; i++)
					{
						array[i].z = 0.8f;
					}
				}
				BuildCorner(corners, cornerStyleIndex, 1, 1, -1, vertexPositions, verts);
				BuildCorner(corners, cornerStyleIndex++, 1, 1, -1, array, verts, scalarZ);
				BuildCorner(corners, cornerStyleIndex, 1, -1, -1, vertexPositions, verts);
				BuildCorner(corners, cornerStyleIndex++, 1, -1, -1, array, verts, scalarZ);
				BuildCorner(corners, cornerStyleIndex, -1, -1, -1, vertexPositions, verts);
				BuildCorner(corners, cornerStyleIndex++, -1, -1, -1, array, verts, scalarZ);
				BuildCorner(corners, cornerStyleIndex, -1, 1, -1, vertexPositions, verts);
				BuildCorner(corners, cornerStyleIndex++, -1, 1, -1, array, verts, scalarZ);
				BuildEdge(edges, 1, 1, vertexPositions, verts, isInlet);
				BuildEdge(edges, 1, -1, vertexPositions, verts, isInlet);
				BuildEdge(edges, -1, 1, vertexPositions, verts, isInlet);
				BuildEdge(edges, -1, -1, vertexPositions, verts, isInlet);
			}
			else
			{
				BuildCorner(corners, cornerStyleIndex++, 1, 1, 1, vertexPositions, verts).SupportsSlant = true;
				BuildCorner(corners, cornerStyleIndex++, 1, -1, 1, vertexPositions, verts).SupportsSlant = true;
				BuildCorner(corners, cornerStyleIndex++, -1, -1, 1, vertexPositions, verts).SupportsSlant = true;
				BuildCorner(corners, cornerStyleIndex++, -1, 1, 1, vertexPositions, verts).SupportsSlant = true;
				BuildCorner(corners, cornerStyleIndex++, 1, 1, -1, vertexPositions, verts);
				BuildCorner(corners, cornerStyleIndex++, 1, -1, -1, vertexPositions, verts);
				BuildCorner(corners, cornerStyleIndex++, -1, -1, -1, vertexPositions, verts);
				BuildCorner(corners, cornerStyleIndex++, -1, 1, -1, vertexPositions, verts);
				BuildEdge(edges, 1, 1, vertexPositions, verts, isInlet);
				BuildEdge(edges, 1, -1, vertexPositions, verts, isInlet);
				BuildEdge(edges, -1, 1, vertexPositions, verts, isInlet);
				BuildEdge(edges, -1, -1, vertexPositions, verts, isInlet);
			}
		}

		private static void BuildEdge(List<FuselageEdge> edges, int scaleX, int scaleY, Vector3[] vertexPositions, Vector3[] verts, bool isInlet)
		{
			for (int i = 0; i < vertexPositions.Length; i++)
			{
				Vector3 vector = vertexPositions[i];
				Vector3 vec = new Vector3(vector.x * (float)scaleX, vector.y * (float)scaleY, 1f);
				Vector3 vec2 = new Vector3(vector.x * (float)scaleX, vector.y * (float)scaleY, -1f);
				Vector3 vec3 = new Vector3(vector.x * (float)scaleX, vector.y * (float)scaleY, 0f);
				FuselageEdge fuselageEdge = new FuselageEdge();
				edges.Add(fuselageEdge);
				if (isInlet)
				{
					fuselageEdge.UseDistanceFromLeadingEdge = true;
				}
				for (int j = 0; j < verts.Length; j++)
				{
					if (Utilities.CompareVector3s(vec, verts[j], 0.1f))
					{
						fuselageEdge.AnchorIndex1 = j;
					}
					else if (Utilities.CompareVector3s(vec2, verts[j], 0.1f))
					{
						fuselageEdge.AnchorIndex2 = j;
					}
					else if (Utilities.CompareVector3s(vec3, verts[j], 0.1f))
					{
						fuselageEdge.MiddleIndices.Add(j);
					}
				}
			}
		}

		private FuselageData.FuselageColliderType DetermineFuselageColliderType()
		{
			FuselageData.FuselageColliderType fuselageColliderType = Fuselage.ColliderType;
			if (fuselageColliderType == FuselageData.FuselageColliderType.Auto)
			{
				fuselageColliderType = (IsInlet ? FuselageData.FuselageColliderType.Basic : ((base.LoadContext != CraftLoadContext.Designer) ? FuselageData.FuselageColliderType.Basic : ((!Fuselage.UseCutting || !IsHollow) ? FuselageData.FuselageColliderType.ConvexMesh : FuselageData.FuselageColliderType.NonConvexMesh)));
			}
			return fuselageColliderType;
		}

		private void EnableAttachPoint(int index, bool enabled)
		{
			if (base.LoadContext == CraftLoadContext.Designer)
			{
				base.PartScript.AttachPointScripts[index].AttachPoint.DisplayWhenDragged = enabled;
			}
		}

		private Vector2[] GetCornerDeltas(FuselageCorner corner, int cornerType)
		{
			Vector2[] array = new Vector2[7];
			Vector2[] array2 = null;
			Vector2 vector;
			switch (cornerType)
			{
			case 2:
				vector = new Vector2(2f, 2f) * 0.25f;
				array2 = new Vector2[7]
				{
					new Vector2(0f, 2f) * 0.25f,
					new Vector2(0.51763797f, 1.931852f) * 0.25f,
					new Vector2(1f, 1.732051f) * 0.25f,
					new Vector2(1.414213f, 1.414214f) * 0.25f,
					new Vector2(1.73205f, 1f) * 0.25f,
					new Vector2(1.931851f, 0.51763904f) * 0.25f,
					new Vector2(1.999999f, 1.013279E-06f) * 0.25f
				};
				break;
			case 1:
			{
				float num = 0.8f;
				vector = new Vector2(1f, 1f) * 0.25f;
				array2 = new Vector2[7]
				{
					new Vector2(0f, 1f) * 0.25f,
					new Vector2(0.25f, 1f) * 0.25f,
					new Vector2(0.5f, 1f) * 0.25f,
					new Vector2(num, num) * 0.25f,
					new Vector2(1f, 0.5f) * 0.25f,
					new Vector2(1f, 0.25f) * 0.25f,
					new Vector2(1f, 0f) * 0.25f
				};
				break;
			}
			case 3:
				vector = new Vector2(2f, 2f) * 0.25f;
				array2 = new Vector2[7]
				{
					new Vector2(0f, 2f) * 0.25f,
					new Vector2(0.51763797f, 1.931852f) * 0.25f,
					new Vector2(1f, 1.732051f) * 0.25f,
					new Vector2(1.414213f, 1.414214f) * 0.25f,
					new Vector2(1.73205f, 1f) * 0.25f,
					new Vector2(1.931851f, 0.51763904f) * 0.25f,
					new Vector2(1.999999f, 1.013279E-06f) * 0.25f
				};
				break;
			default:
				vector = new Vector2(1f, 1f) * 0.25f;
				array2 = new Vector2[7]
				{
					new Vector2(0f, 1f) * 0.25f,
					new Vector2(0.25f, 1f) * 0.25f,
					new Vector2(0.5f, 1f) * 0.25f,
					new Vector2(1f, 1f) * 0.25f,
					new Vector2(1f, 0.5f) * 0.25f,
					new Vector2(1f, 0.25f) * 0.25f,
					new Vector2(1f, 0f) * 0.25f
				};
				break;
			}
			for (int i = 0; i < array.Length; i++)
			{
				array[i].x = (vector.x - array2[i].x) * (float)corner.Scale.x;
				array[i].y = (vector.y - array2[i].y) * (float)corner.Scale.y;
			}
			return array;
		}

		private Vector2[] GetCornerInsets(FuselageCorner corner, int cornerType)
		{
			Vector2[] array = null;
			switch (cornerType)
			{
			case 2:
			{
				array = new Vector2[7]
				{
					new Vector2(0f, 2f) * 0.25f,
					new Vector2(0.51763797f, 1.931852f) * 0.25f,
					new Vector2(1f, 1.732051f) * 0.25f,
					new Vector2(1.414213f, 1.414214f) * 0.25f,
					new Vector2(1.73205f, 1f) * 0.25f,
					new Vector2(1.931851f, 0.51763904f) * 0.25f,
					new Vector2(1.999999f, 1.013279E-06f) * 0.25f
				};
				for (int j = 0; j < array.Length; j++)
				{
					array[j] = array[j].normalized;
				}
				break;
			}
			case 1:
				array = new Vector2[7]
				{
					new Vector2(0f, 1f),
					new Vector2(0f, 1f),
					new Vector2(0f, 1f),
					new Vector2(0.5f, 0.5f),
					new Vector2(1f, 0f),
					new Vector2(1f, 0f),
					new Vector2(1f, 0f)
				};
				break;
			case 3:
			{
				array = new Vector2[7]
				{
					new Vector2(0f, 2f) * 0.25f,
					new Vector2(0.51763797f, 1.931852f) * 0.25f,
					new Vector2(1f, 1.732051f) * 0.25f,
					new Vector2(1.414213f, 1.414214f) * 0.25f,
					new Vector2(1.73205f, 1f) * 0.25f,
					new Vector2(1.931851f, 0.51763904f) * 0.25f,
					new Vector2(1.999999f, 1.013279E-06f) * 0.25f
				};
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = array[i].normalized;
				}
				break;
			}
			default:
				array = new Vector2[7]
				{
					new Vector2(0f, 1f),
					new Vector2(0f, 1f),
					new Vector2(0f, 1f),
					new Vector2(1f, 1f),
					new Vector2(1f, 0f),
					new Vector2(1f, 0f),
					new Vector2(1f, 0f)
				};
				break;
			}
			return array;
		}

		private void OnBeforePaintInDesigner(object sender, PartMaterialScript.PaintedEventArgs args)
		{
			if (args.UVsChanged && Fuselage.UseCutting)
			{
				_meshFilter.sharedMesh = _nonCutMesh;
			}
		}

		private void OnPaintedInDesigner(object sender, PartMaterialScript.PaintedEventArgs args)
		{
			if (!Fuselage.UseCutting || !args.UVsChanged)
			{
				return;
			}
			PerformMeshCut();
			base.PartScript.ReinitializeCraftDecalRenderers();
			if (_nonMergedNormals != null)
			{
				Vector3[] normals = _cutMesh.normals;
				if (_nonMergedNormals.Length != normals.Length)
				{
					_nonMergedNormals = normals;
				}
				else
				{
					normals.CopyTo(_nonMergedNormals, 0);
				}
			}
			QueueSyncNormals();
			_syncConnectedNormalsOnQueue = true;
		}

		private void OnPartConnectionChanged(object sender, PartConnectionChangedEventArgs e)
		{
			QueueSyncNormals();
		}

		private UniTask OnPreStart(AircraftScript craftScript, CraftLoadContext loadContext, bool async)
		{
			if (Fuselage.Buoyancy > 0f)
			{
				BuoyancyForce buoyancyForce = _collider.gameObject.AddComponent<BuoyancyForce>();
				buoyancyForce.Quality = BuoyancyQuality.Low;
				buoyancyForce.WeightFactor = 20f * Fuselage.Buoyancy;
				buoyancyForce.UseWeighting = true;
				buoyancyForce.ReduceBuoyancyIfBySelf = false;
				buoyancyForce.ImpactVelocityAdjustment = FloatingPartData.GetImpactVelocityAdjustmentCurve("Standard");
			}
			return UniTask.CompletedTask;
		}

		private void OnUpdateInDesigner(in CraftUpdateFrameData frame)
		{
			if (_syncNormalsQueued)
			{
				SyncNormals(_syncConnectedNormalsOnQueue);
			}
		}

		private void PerformMeshCut()
		{
			bool fillCut = Fuselage.FillCutFace;
			if (fillCut && IsHollow && Fuselage.InletThicknessFront == 0f && Fuselage.InletThicknessRear == 0f)
			{
				fillCut = false;
			}
			bool hasCut = false;
			FuselageData.FillParameters fillFront = Fuselage.FillFront;
			FuselageData.FillParameters fillBack = Fuselage.FillBack;
			if (fillFront.Top != 1f || fillBack.Top != 1f)
			{
				Cut(Vector3.up, fillFront.Top, fillBack.Top);
			}
			if (fillFront.Bottom != 1f || fillBack.Bottom != 1f)
			{
				Cut(Vector3.down, fillFront.Bottom, fillBack.Bottom);
			}
			if (fillFront.Left != 1f || fillBack.Left != 1f)
			{
				Cut(Vector3.left, fillFront.Left, fillBack.Left);
			}
			if (fillFront.Right != 1f || fillBack.Right != 1f)
			{
				Cut(Vector3.right, fillFront.Right, fillBack.Right);
			}
			if (hasCut)
			{
				FrontMergeVertices = null;
				BackMergeVertices = null;
				_meshFilter.sharedMesh = _cutMesh;
			}
			void Cut(Vector3 axis, float front, float back)
			{
				front = front * 2f - 1f;
				back = back * 2f - 1f;
				Vector3 vector = (-Fuselage.Offset + front * Mathf.Abs(Vector3.Dot(Fuselage.FrontScale, axis)) * axis) * 0.25f;
				Vector3 vector2 = (Fuselage.Offset + back * Mathf.Abs(Vector3.Dot(Fuselage.RearScale, axis)) * axis) * 0.25f;
				vector.z = 0f - vector.z;
				vector2.z = 0f - vector2.z;
				Vector3 lhs = vector2 - vector;
				Vector3 rhs = Vector3.Cross(axis, Vector3.forward);
				Vector3 normal = Vector3.Cross(lhs, rhs);
				if (_cutMesh == null)
				{
					_cutMesh = UnityEngine.Object.Instantiate(_nonCutMesh);
				}
				if (hasCut)
				{
					Mesh cutMesh = _cutMesh;
					Vector3 position = vector;
					Mesh cutMesh2 = _cutMesh;
					int planeFaceSubmesh = ((!fillCut) ? (-1) : 0);
					Vector3? planeFaceUv = new Vector3(base.PartScript.PartMaterialScript.MaterialIdPrimary, DecalLayers.DefaultRenderingLayerFloat, base.PartScript.Part.Id);
					FuselageCutter.Slice(cutMesh, position, normal, planeFaceSubmesh, null, planeFaceUv, cutMesh2);
				}
				else
				{
					Mesh nonCutMesh = _nonCutMesh;
					Vector3 position2 = vector;
					Mesh cutMesh2 = _cutMesh;
					int planeFaceSubmesh2 = ((!fillCut) ? (-1) : 0);
					Vector3? planeFaceUv = new Vector3(base.PartScript.PartMaterialScript.MaterialIdPrimary, DecalLayers.DefaultRenderingLayerFloat, base.PartScript.Part.Id);
					FuselageCutter.SliceResult result = FuselageCutter.Slice(nonCutMesh, position2, normal, planeFaceSubmesh2, null, planeFaceUv, cutMesh2);
					hasCut = FuselageCutter.DidApply(result);
				}
			}
		}

		private void SetAttachPointPosition(int index, Vector3 position)
		{
			if (Fuselage.Version > 1)
			{
				base.PartScript.Part.AttachPoints[index].Position = position;
			}
			if (base.LoadContext == CraftLoadContext.Designer)
			{
				base.PartScript.AttachPointScripts[index].transform.localPosition = position;
			}
		}

		private void SyncNormalsWithOtherFuselage(FuselageScript other, bool thisFront, bool otherFront, bool average, Vector3[] myNormals)
		{
			Vector3[] vertices = _meshFilter.sharedMesh.vertices;
			Vector3[] vertices2 = other._meshFilter.sharedMesh.vertices;
			Vector3[] otherNormals = other._nonMergedNormals;
			if (otherNormals == null)
			{
				otherNormals = (other._nonMergedNormals = other._meshFilter.sharedMesh.normals);
			}
			Transform transform = base.transform;
			Transform transform2 = other.transform;
			Matrix4x4 localToWorldMatrix = transform.localToWorldMatrix;
			Matrix4x4 localToWorldMatrix2 = transform2.localToWorldMatrix;
			int[] array = ((thisFront || IsCone) ? FrontMergeVertices : BackMergeVertices);
			int[] array2 = ((otherFront || other.IsCone) ? other.FrontMergeVertices : other.BackMergeVertices);
			if (Fuselage.UseCutting)
			{
				if (thisFront || IsCone)
				{
					_frontMergeVerticesWereCut = true;
				}
				else
				{
					_backMergeVerticesWereCut = true;
				}
				if (otherFront || other.IsCone)
				{
					other._frontMergeVerticesWereCut = true;
				}
				else
				{
					other._backMergeVerticesWereCut = true;
				}
			}
			Vector3 vector = Vector3.one;
			Vector3 vector2 = Vector3.one;
			if (base.LoadContext != CraftLoadContext.Designer)
			{
				vector = base.PartScript.Part.PartScale ?? vector;
				vector2 = other.PartScript.Part.PartScale ?? vector2;
			}
			_syncNormalsVertPair1TempList.Clear();
			List<(int, int)> syncNormalsVertPair1TempList = _syncNormalsVertPair1TempList;
			_syncNormalsWorldPoints1TempList.Clear();
			_syncNormalsWorldPoints2TempList.Clear();
			foreach (int num in array)
			{
				_syncNormalsWorldPoints1TempList.Add(localToWorldMatrix.MultiplyPoint3x4(new Vector3(vertices[num].x * vector.x, vertices[num].y * vector.y, vertices[num].z * vector.z)));
			}
			foreach (int num2 in array2)
			{
				_syncNormalsWorldPoints2TempList.Add(localToWorldMatrix2.MultiplyPoint3x4(new Vector3(vertices2[num2].x * vector2.x, vertices2[num2].y * vector2.y, vertices2[num2].z * vector2.z)));
			}
			for (int k = 0; k < array.Length; k++)
			{
				int item = array[k];
				Vector3 vector3 = _syncNormalsWorldPoints1TempList[k];
				for (int l = 0; l < array2.Length; l++)
				{
					int item2 = array2[l];
					Vector3 vector4 = _syncNormalsWorldPoints2TempList[l];
					if (Math.Abs(vector3.x - vector4.x) <= 0.01f && Math.Abs(vector3.y - vector4.y) <= 0.01f && Math.Abs(vector3.z - vector4.z) <= 0.01f)
					{
						syncNormalsVertPair1TempList.Add((item, item2));
					}
				}
			}
			_syncNormalsVertPair2TempList.Clear();
			List<(int, int)> syncNormalsVertPair2TempList = _syncNormalsVertPair2TempList;
			List<int> syncNormalsVertPairDupsTempList = _syncNormalsVertPairDupsTempList;
			for (int m = 0; m < syncNormalsVertPair1TempList.Count; m++)
			{
				(int, int) item3 = syncNormalsVertPair1TempList[m];
				if (item3.Item1 < 0)
				{
					continue;
				}
				syncNormalsVertPairDupsTempList.Clear();
				for (int n = m; n < syncNormalsVertPair1TempList.Count; n++)
				{
					(int, int) tuple = syncNormalsVertPair1TempList[n];
					if (tuple.Item1 == item3.Item1)
					{
						syncNormalsVertPairDupsTempList.Add(tuple.Item2);
						syncNormalsVertPair1TempList[n] = (-1, -1);
					}
				}
				Vector3 myNorm;
				if (syncNormalsVertPairDupsTempList.Count > 1)
				{
					myNorm = myNormals[item3.Item1].normalized;
					int num3 = syncNormalsVertPairDupsTempList[0];
					float num4 = Distance(num3);
					for (int num5 = 1; num5 < syncNormalsVertPairDupsTempList.Count; num5++)
					{
						int num6 = syncNormalsVertPairDupsTempList[num5];
						float num7 = Distance(num6);
						if (num7 < num4)
						{
							num3 = num6;
							num4 = num7;
						}
					}
					syncNormalsVertPair2TempList.Add((item3.Item1, num3));
				}
				else
				{
					syncNormalsVertPair2TempList.Add(item3);
				}
				float Distance(int otherInd)
				{
					return (myNorm - otherNormals[otherInd].normalized).sqrMagnitude;
				}
			}
			syncNormalsVertPair1TempList = syncNormalsVertPair2TempList;
			if (average)
			{
				foreach (var item8 in syncNormalsVertPair1TempList)
				{
					int item4 = item8.Item1;
					int item5 = item8.Item2;
					Vector3 direction = (transform.TransformDirection(_nonMergedNormals[item4]) + transform2.TransformDirection(otherNormals[item5])) / 2f;
					myNormals[item4] = transform.InverseTransformDirection(direction);
				}
				return;
			}
			foreach (var item9 in syncNormalsVertPair1TempList)
			{
				int item6 = item9.Item1;
				int item7 = item9.Item2;
				Vector3 direction2 = transform2.TransformDirection(otherNormals[item7]);
				myNormals[item6] = transform.InverseTransformDirection(direction2);
			}
		}

		private void UpdateVisualMesh()
		{
			_meshFilter.sharedMesh = _nonCutMesh;
			Vector3[] vertices = _nonCutMesh.vertices;
			int count = Corners.Count;
			if (_cornersInsetTemp.Length < count)
			{
				_cornersInsetTemp = new float[count];
			}
			float[] cornersInsetTemp = _cornersInsetTemp;
			for (int i = 0; i < count; i++)
			{
				cornersInsetTemp[i] = 0f;
			}
			if (IsCone)
			{
				Vector3 scale = new Vector3(Fuselage.FrontScale.x, Fuselage.FrontScale.y, Mathf.Abs(Fuselage.Offset.z) * 2f);
				scale *= 0.25f;
				scale *= 0.5f;
				for (int j = 0; j < vertices.Length; j++)
				{
					vertices[j] = _originalVertices[j];
					vertices[j].Scale(scale);
					vertices[j].x -= Fuselage.Offset.x * 0.25f * _originalVertices[j].z;
					vertices[j].y -= Fuselage.Offset.y * 0.25f * _originalVertices[j].z;
				}
			}
			else if (IsInlet || IsHollow)
			{
				cornersInsetTemp[7] = (cornersInsetTemp[5] = (cornersInsetTemp[3] = (cornersInsetTemp[1] = Fuselage.InletThicknessFront * 1f)));
				cornersInsetTemp[15] = (cornersInsetTemp[13] = (cornersInsetTemp[11] = (cornersInsetTemp[9] = Fuselage.InletThicknessRear * 1f)));
			}
			int num = -1;
			Vector3[] array = new Vector3[7];
			foreach (FuselageCorner corner in Corners)
			{
				num++;
				Vector3 vector = new Vector3(corner.Scale.x, corner.Scale.y, corner.Scale.z) * 0.25f;
				vector.z *= Fuselage.Offset.z;
				Vector2 vector2;
				if (corner.Scale.z > 0)
				{
					vector2 = Fuselage.FrontScale;
					vector.x = vector.x * Fuselage.FrontScale.x - Fuselage.Offset.x * 0.25f;
					vector.y = vector.y * Fuselage.FrontScale.y - Fuselage.Offset.y * 0.25f;
				}
				else
				{
					vector2 = Fuselage.RearScale;
					vector.x = vector.x * Fuselage.RearScale.x + Fuselage.Offset.x * 0.25f;
					vector.y = vector.y * Fuselage.RearScale.y + Fuselage.Offset.y * 0.25f;
				}
				int num2 = Fuselage.CornerTypes[corner.CornerStyleIndex];
				if (vector2.x == 0f || vector2.y == 0f)
				{
					num2 = 0;
				}
				Vector2[] cornerDeltas = GetCornerDeltas(corner, num2);
				float num3 = Mathf.Min(vector2.x, vector2.y);
				for (int k = 0; k < cornerDeltas.Length; k++)
				{
					switch (num2)
					{
					case 2:
						if (num3 < 2f)
						{
							cornerDeltas[k] *= num3 * 0.5f;
						}
						break;
					case 3:
						cornerDeltas[k].x *= vector2.x / 2f;
						cornerDeltas[k].y *= vector2.y / 2f;
						break;
					default:
						if (num3 < 1f)
						{
							cornerDeltas[k] *= num3;
						}
						break;
					}
				}
				Vector2[] array2 = null;
				float num4 = cornersInsetTemp[num];
				if (num4 > 0f)
				{
					array2 = GetCornerInsets(corner, num2);
				}
				for (int l = 0; l < array.Length; l++)
				{
					array[l].x = vector.x - cornerDeltas[l].x;
					array[l].y = vector.y - cornerDeltas[l].y;
					if (array2 != null)
					{
						array[l].x -= array2[l].x * Mathf.Sign(corner.Scale.x) * num4 * 0.1f * Mathf.Clamp01(num3);
						array[l].y -= array2[l].y * Mathf.Sign(corner.Scale.y) * num4 * 0.1f * Mathf.Clamp01(num3);
					}
					float num5 = 0f;
					if (corner.SupportsSlant)
					{
						num5 = array[l].y * ClampedSlant;
					}
					array[l].x *= corner.ScalarZ;
					array[l].y *= corner.ScalarZ;
					array[l].z = vector.z * corner.ScalarZ + num5;
				}
				corner.SetPositions(array, vertices);
			}
			foreach (FuselageEdge edge in Edges)
			{
				edge.UpdateEdge(vertices, Mathf.Clamp01(Fuselage.InletTrimSize));
			}
			_nonCutMesh.vertices = vertices;
			if (IsCone)
			{
				NormalSolver.RecalculateNormals(_nonCutMesh, 75f, 2);
			}
			else if (IsInlet)
			{
				NormalSolver.RecalculateNormals(_nonCutMesh, 60f, 2);
			}
			else
			{
				NormalSolver.RecalculateNormals(_nonCutMesh, 60f, 1);
			}
			Vector3[] normals = _nonCutMesh.normals;
			foreach (int frontNormal in _frontNormals)
			{
				normals[frontNormal] = new Vector3(0f, 0f, 1f);
			}
			foreach (int backNormal in _backNormals)
			{
				normals[backNormal] = new Vector3(0f, 0f, -1f);
			}
			_nonCutMesh.normals = normals;
			if (Fuselage.UseCutting)
			{
				PerformMeshCut();
			}
			else
			{
				if (_backMergeVerticesWereCut)
				{
					_backMergeVertices = null;
				}
				if (_frontMergeVerticesWereCut)
				{
					_frontMergeVertices = null;
				}
				_backMergeVerticesWereCut = false;
				_frontMergeVerticesWereCut = false;
			}
			if (_nonMergedNormals != null)
			{
				normals = _meshFilter.sharedMesh.normals;
				if (_nonMergedNormals.Length != normals.Length)
				{
					_nonMergedNormals = normals;
				}
				else
				{
					normals.CopyTo(_nonMergedNormals, 0);
				}
			}
			if (base.LoadContext == CraftLoadContext.Designer)
			{
				QueueSyncNormals();
				_syncConnectedNormalsOnQueue = true;
			}
			else
			{
				SyncNormals(updateConnected: false);
			}
			_meshFilter.sharedMesh.RecalculateBounds();
		}
	}
}
