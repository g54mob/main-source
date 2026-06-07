using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class AdaptiveBlockScript : PartModifierScript
	{
		private class AdaptiveAngle
		{
			public AttachPointScript AttachPoint { get; set; }

			public bool IsHardAngle { get; set; }

			public List<AdaptiveVertex> Vertices { get; private set; }

			public AdaptiveAngle()
			{
				Vertices = new List<AdaptiveVertex>();
			}
		}

		private class AdaptiveCorner
		{
			public List<AdaptiveEdge> Edges { get; private set; }

			public bool IsHardCorner { get; set; }

			public Vector3 SmoothScale { get; set; }

			public List<AdaptiveVertex> Vertices { get; private set; }

			public AdaptiveCorner()
			{
				Edges = new List<AdaptiveEdge>();
				Vertices = new List<AdaptiveVertex>();
			}
		}

		private class AdaptiveEdge
		{
			public List<AttachPointScript.AttachPointEdge> AttachPointEdges { get; private set; }

			public int ConnectionCount { get; set; }

			public Vector3 EdgeVector { get; set; }

			public bool EnableSmoothing { get; set; }

			public bool IsHardEdge { get; set; }

			public bool SmoothX { get; set; }

			public bool SmoothY { get; set; }

			public bool SmoothZ { get; set; }

			public List<AdaptiveVertex> Vertices { get; private set; }

			public AdaptiveEdge(Vector3 edgeVector)
			{
				EnableSmoothing = true;
				Vertices = new List<AdaptiveVertex>();
				EdgeVector = edgeVector;
				AttachPointEdges = new List<AttachPointScript.AttachPointEdge>();
			}
		}

		private class AdaptiveVertex
		{
			public bool Connected { get; set; }

			public bool HardEdge { get; set; }

			public int Index { get; set; }

			public bool IsCorner { get; set; }

			public Vector3 OriginalVertex { get; set; }

			public bool SmoothX { get; set; }

			public bool SmoothY { get; set; }

			public bool SmoothZ { get; set; }

			public AdaptiveVertex(Vector3 v, int index)
			{
				OriginalVertex = v;
				Index = index;
			}
		}

		private const float VectorCompareEpsilon = 0.01f;

		private static int _numAdaptiveUpdatesInFrame;

		private static bool _updateAdaptiveBlockStatesStarted;

		private static bool _updatingAdaptiveBlockStates;

		private Dictionary<int, AdaptiveVertex> _adaptiveVertices = new Dictionary<int, AdaptiveVertex>();

		private List<AdaptiveAngle> _angles = new List<AdaptiveAngle>();

		private Vector3 _angleScalar = new Vector3(0.8f, 0.9f, 0.9f);

		private List<AdaptiveCorner> _corners = new List<AdaptiveCorner>();

		private List<AdaptiveEdge> _edges = new List<AdaptiveEdge>();

		private MeshFilter _meshFilter;

		private bool _smoothCorners;

		private int _state;

		public static bool UpdatingAdaptiveBlockStates => _updatingAdaptiveBlockStates;

		public AdaptiveBlockData AdaptiveBlock { get; set; }

		public static void UpdateAdaptiveBlockStates(IEnumerable<PartData> parts)
		{
			_updatingAdaptiveBlockStates = true;
			_updateAdaptiveBlockStatesStarted = false;
			foreach (PartData part in parts)
			{
				AdaptiveBlockScript modifier = part.PartScript.GetModifier<AdaptiveBlockScript>();
				if (modifier != null)
				{
					modifier.ResetState();
				}
			}
		}

		public override void BuildPreStartInitializationPlan(PreStartInitializationPlan plan)
		{
			base.BuildPreStartInitializationPlan(plan);
			plan.Register(this, OnPreStart);
		}

		public List<AttachPointScript.AttachPointEdge> GetAttachPointEdges(Vector3 edgeVector)
		{
			List<AttachPointScript.AttachPointEdge> list = new List<AttachPointScript.AttachPointEdge>();
			Vector3 vec = base.transform.TransformDirection(edgeVector);
			foreach (AttachPointScript attachPointScript in base.PartScript.AttachPointScripts)
			{
				foreach (AttachPointScript.AttachPointEdge edge in attachPointScript.Edges)
				{
					if (Utilities.CompareVector3s(attachPointScript.WorldNormal + attachPointScript.transform.TransformDirection(edge.LocalEdgeNormal), vec, 0.01f))
					{
						list.Add(edge);
					}
				}
			}
			return list;
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterLateUpdate(OnLateUpdateDesigner, CraftUpdateFlags.DesignerDefault);
			registrar.RegisterUpdate(OnUpdateNonFlight, CraftUpdateFlags.NonFlightScenesDefault);
		}

		private void AdaptVertices(AdaptiveEdge edge, bool hardEdge, bool connectedEdge)
		{
			foreach (AttachPointScript.AttachPointEdge attachPointEdge in edge.AttachPointEdges)
			{
				if (hardEdge)
				{
					attachPointEdge.IsHardEdge = true;
				}
			}
			foreach (AdaptiveVertex vertex in edge.Vertices)
			{
				if (connectedEdge)
				{
					vertex.Connected = true;
				}
				if (hardEdge)
				{
					vertex.HardEdge = hardEdge;
					vertex.SmoothX = false;
					vertex.SmoothY = false;
					vertex.SmoothZ = false;
				}
				else if (!vertex.HardEdge && !connectedEdge && edge.EnableSmoothing)
				{
					vertex.SmoothX = edge.SmoothX || vertex.SmoothX;
					vertex.SmoothY = edge.SmoothY || vertex.SmoothY;
					vertex.SmoothZ = edge.SmoothZ || vertex.SmoothZ;
				}
			}
		}

		private void AddEdgeConnection(Vector3 edgeVector, bool hardConnection)
		{
			foreach (AdaptiveEdge edge in _edges)
			{
				if (!Utilities.CompareVector3s(edge.EdgeVector, edgeVector, 0.01f))
				{
					continue;
				}
				if (hardConnection)
				{
					edge.IsHardEdge = true;
				}
				edge.ConnectionCount++;
				foreach (AttachPointScript.AttachPointEdge attachPointEdge in edge.AttachPointEdges)
				{
					if (hardConnection)
					{
						attachPointEdge.IsHardEdge = true;
					}
				}
			}
		}

		private void BuildAngle(AttachPointScript attachPoint, Vector3[] vertices, IEnumerable<int> indices)
		{
			AdaptiveAngle adaptiveAngle = new AdaptiveAngle();
			adaptiveAngle.AttachPoint = attachPoint;
			foreach (int index in indices)
			{
				adaptiveAngle.Vertices.Add(GetAdaptiveVertex(index, vertices[index]));
			}
			_angles.Add(adaptiveAngle);
		}

		private AdaptiveEdge BuildEdge(Vector3[] vertices, Vector3 edgeVector, Vector3? vertexPosition = null)
		{
			AdaptiveEdge adaptiveEdge = new AdaptiveEdge(edgeVector);
			if (edgeVector.x != 0f)
			{
				adaptiveEdge.SmoothX = true;
			}
			if (edgeVector.y != 0f)
			{
				adaptiveEdge.SmoothY = true;
			}
			if (edgeVector.z != 0f)
			{
				adaptiveEdge.SmoothZ = true;
			}
			_edges.Add(adaptiveEdge);
			if (!vertexPosition.HasValue)
			{
				vertexPosition = edgeVector;
			}
			for (int i = 0; i < vertices.Length; i++)
			{
				Vector3 v = vertices[i];
				if ((vertexPosition.Value.x == 0f || Utilities.CompareFloats(v.x, vertexPosition.Value.x, 0.001f)) && (vertexPosition.Value.y == 0f || Utilities.CompareFloats(v.y, vertexPosition.Value.y, 0.001f)) && (vertexPosition.Value.z == 0f || Utilities.CompareFloats(v.z, vertexPosition.Value.z, 0.001f)))
				{
					adaptiveEdge.Vertices.Add(GetAdaptiveVertex(i, v));
				}
			}
			List<AttachPointScript.AttachPointEdge> attachPointEdges = GetAttachPointEdges(edgeVector);
			adaptiveEdge.AttachPointEdges.AddRange(attachPointEdges);
			return adaptiveEdge;
		}

		private AdaptiveVertex GetAdaptiveVertex(int i, Vector3 v)
		{
			if (!_adaptiveVertices.ContainsKey(i))
			{
				_adaptiveVertices[i] = new AdaptiveVertex(v, i);
			}
			else
			{
				_adaptiveVertices[i].IsCorner = true;
			}
			return _adaptiveVertices[i];
		}

		private AttachPointScript GetAttachPoint(Vector3 localAttachPointNormal)
		{
			foreach (AttachPointScript attachPointScript in base.PartScript.AttachPointScripts)
			{
				if (Utilities.CompareVector3s(attachPointScript.AttachPoint.Normal, localAttachPointNormal, 0.01f))
				{
					return attachPointScript;
				}
			}
			return null;
		}

		private void OnLateUpdateDesigner(in CraftUpdateFrameData frame)
		{
			if (base.LoadContext != CraftLoadContext.Designer)
			{
				return;
			}
			if (_updatingAdaptiveBlockStates)
			{
				_updateAdaptiveBlockStatesStarted = true;
				foreach (AdaptiveEdge edge in _edges)
				{
					edge.ConnectionCount = 0;
					edge.IsHardEdge = false;
					foreach (AttachPointScript.AttachPointEdge attachPointEdge in edge.AttachPointEdges)
					{
						attachPointEdge.IsHardEdge = false;
					}
				}
				foreach (PartConnection partConnection in base.PartScript.Part.PartConnections)
				{
					AttachPointScript attachPointScript = null;
					AttachPointScript attachPointScript2 = null;
					if (partConnection.PartA == base.PartScript.Part)
					{
						attachPointScript = partConnection.AttachPointsB[0].AttachPointScript;
						attachPointScript2 = partConnection.AttachPointsA[0].AttachPointScript;
					}
					else
					{
						attachPointScript = partConnection.AttachPointsA[0].AttachPointScript;
						attachPointScript2 = partConnection.AttachPointsB[0].AttachPointScript;
					}
					if (!attachPointScript.AttachPoint.IsSurfaceAttachPoint)
					{
						if (attachPointScript.AttachPoint.AdaptiveIgnore)
						{
							continue;
						}
						foreach (AttachPointScript.AttachPointEdge edge2 in attachPointScript.Edges)
						{
							Vector3 vector = attachPointScript.transform.TransformDirection(edge2.LocalEdgeNormal);
							Vector3 direction = -attachPointScript.WorldNormal + vector;
							direction = base.transform.InverseTransformDirection(direction);
							AddEdgeConnection(direction, edge2.IsHardEdge);
						}
						continue;
					}
					foreach (AttachPointScript.AttachPointEdge edge3 in attachPointScript2.Edges)
					{
						Vector3 vector2 = attachPointScript2.transform.TransformDirection(edge3.LocalEdgeNormal);
						Vector3 direction2 = attachPointScript2.WorldNormal + vector2;
						direction2 = base.transform.InverseTransformDirection(direction2);
						AddEdgeConnection(direction2, hardConnection: false);
					}
				}
				foreach (AdaptiveAngle angle in _angles)
				{
					if (angle.AttachPoint != null)
					{
						angle.IsHardAngle = !angle.AttachPoint.AttachPoint.IsAvailable;
					}
				}
				foreach (AdaptiveCorner corner in _corners)
				{
					corner.IsHardCorner = false;
					foreach (AdaptiveEdge edge4 in corner.Edges)
					{
						corner.IsHardCorner = corner.IsHardCorner || edge4.IsHardEdge;
					}
				}
				int num = 0;
				for (int i = 0; i < _edges.Count; i++)
				{
					if (_edges[i].IsHardEdge || _edges[i].ConnectionCount > 1)
					{
						int num2 = 1 << i;
						num |= num2;
					}
					if (_edges[i].ConnectionCount > 0)
					{
						int num3 = 1 << i + 12;
						num |= num3;
					}
				}
				for (int j = 0; j < _angles.Count; j++)
				{
					if (_angles[j].IsHardAngle)
					{
						int num4 = 1 << j + 24;
						num |= num4;
					}
				}
				for (int k = 0; k < _corners.Count; k++)
				{
					if (_corners[k].IsHardCorner)
					{
						int num5 = 1 << k + 28;
						num |= num5;
					}
				}
				if (num != AdaptiveBlock.State)
				{
					_numAdaptiveUpdatesInFrame++;
					AdaptiveBlock.State = num;
					UpdateState(num);
				}
			}
			else if (_state != AdaptiveBlock.State)
			{
				_state = AdaptiveBlock.State;
				UpdateMesh();
			}
		}

		private UniTask OnPreStart(AircraftScript craftScript, CraftLoadContext loadContext, bool async)
		{
			_meshFilter = GetComponent<MeshFilter>();
			Vector3[] vertices = _meshFilter.mesh.vertices;
			if (AdaptiveBlock.MeshType == "Block")
			{
				BuildEdge(vertices, new Vector3(1f, 1f, 0f));
				BuildEdge(vertices, new Vector3(1f, -1f, 0f));
				BuildEdge(vertices, new Vector3(-1f, 1f, 0f));
				BuildEdge(vertices, new Vector3(-1f, -1f, 0f));
				BuildEdge(vertices, new Vector3(0f, 1f, 1f));
				BuildEdge(vertices, new Vector3(0f, 1f, -1f));
				BuildEdge(vertices, new Vector3(0f, -1f, 1f));
				BuildEdge(vertices, new Vector3(0f, -1f, -1f));
				BuildEdge(vertices, new Vector3(1f, 0f, 1f));
				BuildEdge(vertices, new Vector3(1f, 0f, -1f));
				BuildEdge(vertices, new Vector3(-1f, 0f, 1f));
				BuildEdge(vertices, new Vector3(-1f, 0f, -1f));
			}
			else if (AdaptiveBlock.MeshType == "Curved")
			{
				_smoothCorners = true;
				BuildEdge(vertices, new Vector3(0f, 1f, -1f)).EnableSmoothing = false;
				BuildEdge(vertices, new Vector3(0f, -1f, 1f)).EnableSmoothing = false;
				BuildEdge(vertices, new Vector3(1f, -1f, 0f)).EnableSmoothing = false;
				BuildEdge(vertices, new Vector3(-1f, -1f, 0f)).EnableSmoothing = false;
				BuildEdge(vertices, new Vector3(1f, 0f, -1f)).EnableSmoothing = false;
				BuildEdge(vertices, new Vector3(-1f, 0f, -1f)).EnableSmoothing = false;
				List<int> list = new List<int>();
				List<int> list2 = new List<int>();
				Vector3 vector = new Vector3(0f, -1f, -1f);
				for (int i = 0; i < vertices.Length; i++)
				{
					Vector3 vector2 = vertices[i];
					bool flag = false;
					bool flag2 = false;
					if (vector2.x < -0.99f)
					{
						flag = true;
					}
					else if (vector2.x > 0.99f)
					{
						flag2 = true;
					}
					if (!(flag || flag2))
					{
						continue;
					}
					Vector3 vector3 = vertices[i] - vector;
					if (vector3.y * vector3.y + vector3.z * vector3.z > 3.8f)
					{
						if (flag)
						{
							list.Add(i);
						}
						else
						{
							list2.Add(i);
						}
					}
				}
				BuildAngle(GetAttachPoint(new Vector3(-1f, 0f, 0f)), vertices, list);
				BuildAngle(GetAttachPoint(new Vector3(1f, 0f, 0f)), vertices, list2);
			}
			else if (AdaptiveBlock.MeshType == "AngledCorner")
			{
				AdaptiveEdge adaptiveEdge = BuildEdge(vertices, new Vector3(-1f, 0f, -1f));
				AdaptiveEdge adaptiveEdge2 = BuildEdge(vertices, new Vector3(0f, 1f, -1f));
				AdaptiveCorner adaptiveCorner = new AdaptiveCorner
				{
					SmoothScale = new Vector3(0.8f, 0.8f, 1f)
				};
				foreach (AdaptiveVertex vertex in adaptiveEdge.Vertices)
				{
					foreach (AdaptiveVertex vertex2 in adaptiveEdge2.Vertices)
					{
						if (vertex.Index == vertex2.Index)
						{
							adaptiveCorner.Vertices.Add(vertex);
						}
					}
				}
				foreach (AdaptiveEdge edge in _edges)
				{
					edge.EnableSmoothing = false;
					adaptiveCorner.Edges.Add(edge);
				}
				_corners.Add(adaptiveCorner);
			}
			else if (AdaptiveBlock.MeshType == "Angled")
			{
				_smoothCorners = true;
				BuildEdge(vertices, new Vector3(0f, 1f, -1f)).EnableSmoothing = false;
				BuildEdge(vertices, new Vector3(0f, -1f, 1f)).EnableSmoothing = false;
				BuildEdge(vertices, new Vector3(1f, -1f, 0f)).EnableSmoothing = false;
				BuildEdge(vertices, new Vector3(-1f, -1f, 0f)).EnableSmoothing = false;
				BuildEdge(vertices, new Vector3(1f, 0f, -1f)).EnableSmoothing = false;
				BuildEdge(vertices, new Vector3(-1f, 0f, -1f)).EnableSmoothing = false;
				List<int> list3 = new List<int>();
				List<int> list4 = new List<int>();
				for (int j = 0; j < vertices.Length; j++)
				{
					Vector3 vector4 = vertices[j];
					bool flag3 = false;
					bool flag4 = false;
					if (vector4.x < -0.99f)
					{
						flag3 = true;
					}
					else if (vector4.x > 0.99f)
					{
						flag4 = true;
					}
					if ((flag3 || flag4) && Utilities.CompareFloats(vector4.y + vector4.z, 0f, 0.01f))
					{
						if (flag3)
						{
							list3.Add(j);
						}
						else
						{
							list4.Add(j);
						}
					}
				}
				BuildAngle(GetAttachPoint(new Vector3(-1f, 0f, 0f)), vertices, list3);
				BuildAngle(GetAttachPoint(new Vector3(1f, 0f, 0f)), vertices, list4);
			}
			UpdateState(AdaptiveBlock.State);
			_state = AdaptiveBlock.State;
			UpdateMesh();
			if (base.LoadContext != CraftLoadContext.Designer)
			{
				base.enabled = false;
			}
			return UniTask.CompletedTask;
		}

		private void OnUpdateNonFlight(in CraftUpdateFrameData frame)
		{
			if (_updatingAdaptiveBlockStates)
			{
				if (_updateAdaptiveBlockStatesStarted && _numAdaptiveUpdatesInFrame == 0)
				{
					_updatingAdaptiveBlockStates = false;
				}
				_numAdaptiveUpdatesInFrame = 0;
			}
			_updateAdaptiveBlockStatesStarted = false;
		}

		private void RecalculateNormals(Vector3[] vertices)
		{
			_meshFilter.mesh.RecalculateNormals();
		}

		private void ResetState()
		{
			AdaptiveBlock.State = 0;
			UpdateState(0);
		}

		private void UpdateMesh()
		{
			Vector3[] vertices = _meshFilter.mesh.vertices;
			foreach (AdaptiveVertex value in _adaptiveVertices.Values)
			{
				Vector3 originalVertex = value.OriginalVertex;
				if (value.SmoothX)
				{
					originalVertex.x *= 0.8f;
				}
				if (value.SmoothY)
				{
					originalVertex.y *= 0.8f;
				}
				if (value.SmoothZ)
				{
					originalVertex.z *= 0.8f;
				}
				vertices[value.Index] = originalVertex;
			}
			foreach (AdaptiveAngle angle in _angles)
			{
				if (angle.IsHardAngle)
				{
					continue;
				}
				foreach (AdaptiveVertex vertex in angle.Vertices)
				{
					if (!vertex.HardEdge && _smoothCorners)
					{
						Vector3 vector = new Vector3(0f, -1f, -1f);
						Vector3 originalVertex2 = vertex.OriginalVertex;
						originalVertex2 = Vector3.Scale(originalVertex2 - vector, _angleScalar);
						originalVertex2 += vector;
						vertices[vertex.Index] = originalVertex2;
					}
				}
			}
			foreach (AdaptiveCorner corner in _corners)
			{
				if (corner.IsHardCorner)
				{
					continue;
				}
				foreach (AdaptiveVertex vertex2 in corner.Vertices)
				{
					Vector3 originalVertex3 = vertex2.OriginalVertex;
					originalVertex3 = Vector3.Scale(originalVertex3, corner.SmoothScale);
					vertices[vertex2.Index] = originalVertex3;
				}
			}
			_meshFilter.mesh.vertices = vertices;
			RecalculateNormals(vertices);
		}

		private void UpdateState(int state)
		{
			foreach (AdaptiveEdge edge in _edges)
			{
				edge.ConnectionCount = 0;
				edge.IsHardEdge = false;
				foreach (AttachPointScript.AttachPointEdge attachPointEdge in edge.AttachPointEdges)
				{
					attachPointEdge.IsHardEdge = false;
				}
			}
			foreach (AdaptiveVertex value in _adaptiveVertices.Values)
			{
				value.SmoothX = false;
				value.SmoothY = false;
				value.SmoothZ = false;
				value.HardEdge = false;
				value.Connected = false;
			}
			for (int i = 0; i < _edges.Count; i++)
			{
				int num = 1 << i;
				bool hardEdge = (state & num) > 0;
				int num2 = 1 << i + 12;
				bool connectedEdge = (state & num2) > 0;
				AdaptVertices(_edges[i], hardEdge, connectedEdge);
			}
			for (int j = 0; j < _angles.Count; j++)
			{
				int num3 = 1 << j + 24;
				_angles[j].IsHardAngle = (state & num3) > 0;
			}
			for (int k = 0; k < _corners.Count; k++)
			{
				int num4 = 1 << k + 28;
				_corners[k].IsHardCorner = (state & num4) > 0;
			}
		}
	}
}
