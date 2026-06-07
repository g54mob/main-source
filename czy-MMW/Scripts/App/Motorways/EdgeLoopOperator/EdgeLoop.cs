using System;
using System.Collections.Generic;
using UnityEngine;
using Utils;
using Utils.Geometry;

namespace Motorways.EdgeLoopOperator
{
	public class EdgeLoop
	{
		private class CornerBuildOrder
		{
			public readonly LinkedListNode<Vertex>[] targetNodes;

			public readonly Vector3 prevDirection;

			public readonly Vector3 nextDirection;

			public readonly float cornerDepth;

			public readonly int numberOfPoints;

			public readonly bool dualArcCorner;

			public bool Concave => targetNodes[0].Value.topologyType == TopologyType.Concave;

			public CornerBuildOrder(LinkedListNode<Vertex> targetNode, Vector3 prevDirection, Vector3 nextDirection, float cornerDepth, int numberOfPoints, bool dualArcCorner)
			{
				targetNodes = new LinkedListNode<Vertex>[1] { targetNode };
				this.prevDirection = prevDirection;
				this.nextDirection = nextDirection;
				this.cornerDepth = cornerDepth;
				this.numberOfPoints = numberOfPoints;
				this.dualArcCorner = dualArcCorner;
			}

			public CornerBuildOrder(LinkedListNode<Vertex>[] targetNodes, Vector3 prevDirection, Vector3 nextDirection, float cornerDepth, int numberOfPoints, bool dualArcCorner)
			{
				this.targetNodes = targetNodes;
				this.prevDirection = prevDirection;
				this.nextDirection = nextDirection;
				this.cornerDepth = cornerDepth;
				this.numberOfPoints = numberOfPoints;
				this.dualArcCorner = dualArcCorner;
			}
		}

		private class IntersectingEdgeReplacementOperation
		{
			public LinkedListNode<Vertex> p1;

			public LinkedListNode<Vertex> p2;

			public Vertex c;
		}

		private class TopologyQueryResult
		{
			public enum UpdateType
			{
				None = 0,
				Deletion = 1,
				Topology = 2
			}

			public bool match;

			public UpdateType updateType;

			public LinkedListNode<Vertex> nodeForUpdate;

			public TopologyType newTopologyType;
		}

		private class TopologyPattern
		{
			private readonly TopologyType[] _pattern;

			public readonly bool deletion;

			public readonly bool topologyUpdate;

			public readonly bool markTerminal;

			public readonly TopologyType newTopologyType;

			public readonly int updateIndex;

			public TopologyPattern(TopologyType t0, TopologyType t1, TopologyType t2, bool deletion, bool topologyUpdate, bool markTerminal, TopologyType newTopologyType = TopologyType.None, int updateIndex = 1)
			{
				_pattern = new TopologyType[3] { t0, t1, t2 };
				this.deletion = deletion;
				this.topologyUpdate = topologyUpdate;
				this.markTerminal = markTerminal;
				this.newTopologyType = newTopologyType;
				this.updateIndex = updateIndex;
			}

			public TopologyPattern(TopologyType[] pattern, bool deletion, bool topologyUpdate, bool markTerminal, TopologyType newTopologyType = TopologyType.None, int updateIndex = 1)
			{
				_pattern = pattern;
				this.deletion = deletion;
				this.topologyUpdate = topologyUpdate;
				this.markTerminal = markTerminal;
				this.newTopologyType = newTopologyType;
				this.updateIndex = updateIndex;
			}

			public bool Match(IReadOnlyList<LinkedListNode<Vertex>> query)
			{
				if (query.Count != _pattern.Length)
				{
					Diagnostics.FailAssert($"Cannot match with query of length {query.Count} with a pattern of length {_pattern.Length}!");
					return false;
				}
				for (int i = 0; i < _pattern.Length; i++)
				{
					if ((_pattern[i] & query[i].Value.topologyType) == 0)
					{
						return false;
					}
				}
				return true;
			}
		}

		private readonly LinkedList<Vertex> _vertices = new LinkedList<Vertex>();

		private readonly MapVisualGroupType _visualGroupType;

		private readonly MapMeshLayer _meshLayer;

		private readonly TopologyPattern[] _topologyPatterns = new TopologyPattern[11]
		{
			new TopologyPattern(TopologyType.Flat, TopologyType.Concave, TopologyType.Convex, deletion: true, topologyUpdate: true, markTerminal: true, TopologyType.Concave, 0),
			new TopologyPattern(TopologyType.Convex, TopologyType.Concave, TopologyType.Flat, deletion: true, topologyUpdate: true, markTerminal: true, TopologyType.Concave, 2),
			new TopologyPattern(TopologyType.ComplexCorner, TopologyType.Concave, TopologyType.Convex, deletion: true, topologyUpdate: false, markTerminal: true, TopologyType.None, 0),
			new TopologyPattern(TopologyType.Convex, TopologyType.Concave, TopologyType.ComplexCorner, deletion: true, topologyUpdate: false, markTerminal: true, TopologyType.None, 2),
			new TopologyPattern(TopologyType.Convex, TopologyType.Concave, TopologyType.Convex, deletion: true, topologyUpdate: false, markTerminal: false),
			new TopologyPattern(TopologyType.Concave, TopologyType.Convex, TopologyType.Flat | TopologyType.ComplexCorner, deletion: false, topologyUpdate: false, markTerminal: true),
			new TopologyPattern(TopologyType.Flat | TopologyType.ComplexCorner, TopologyType.Convex, TopologyType.Concave, deletion: false, topologyUpdate: false, markTerminal: true),
			new TopologyPattern(TopologyType.Convex, TopologyType.Concave, TopologyType.Concave, deletion: true, topologyUpdate: false, markTerminal: true, TopologyType.None, 2),
			new TopologyPattern(TopologyType.Concave, TopologyType.Concave, TopologyType.Convex, deletion: true, topologyUpdate: false, markTerminal: true, TopologyType.None, 0),
			new TopologyPattern(TopologyType.Concave, TopologyType.Convex, TopologyType.Convex, deletion: false, topologyUpdate: false, markTerminal: true),
			new TopologyPattern(TopologyType.Convex, TopologyType.Convex, TopologyType.Concave, deletion: false, topologyUpdate: false, markTerminal: true)
		};

		private readonly float _splitVertexCardinalEdgeShiftScalar = Mathf.Sqrt(2f) - 1f;

		public LinkedList<Vertex> DebugVertices => _vertices;

		public bool IsEmpty => _vertices.Count == 0;

		public EdgeLoop(MapVisualGroupType visualGroupType, MapMeshLayer meshLayer)
		{
			_visualGroupType = visualGroupType;
			_meshLayer = meshLayer;
		}

		private float GetDiagonalShiftDistance()
		{
			return _meshLayer switch
			{
				MapMeshLayer.Land => 0.3f, 
				MapMeshLayer.MountainA => 0.7f, 
				MapMeshLayer.MountainB => 0.1f, 
				MapMeshLayer.MountainC => -0.2f, 
				MapMeshLayer.Shadow => 0f, 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}

		public Vector2[] Get2DPointArray()
		{
			Vector2[] array = new Vector2[_vertices.Count];
			int num = 0;
			foreach (Vertex vertex in _vertices)
			{
				array[num] = vertex.position;
				num++;
			}
			return array;
		}

		public void AddPoint(Vector3 position, TopologyType topologyType)
		{
			_vertices.AddLast(new Vertex(position, topologyType));
		}

		public void Decimate()
		{
			LinkedListNode<Vertex> linkedListNode = _vertices.First;
			LinkedListNode<Vertex> linkedListNode2 = linkedListNode;
			List<LinkedListNode<Vertex>> list = new List<LinkedListNode<Vertex>>();
			do
			{
				Vector3 position = linkedListNode.Value.position;
				if (Mathf.Abs(position.x % 1f) > float.Epsilon || Mathf.Abs(position.y % 1f) > float.Epsilon)
				{
					list.Add(linkedListNode);
				}
				linkedListNode = linkedListNode.LoopingNext();
			}
			while (linkedListNode != linkedListNode2);
			foreach (LinkedListNode<Vertex> item in list)
			{
				_vertices.Remove(item);
			}
		}

		public void DiagonalizeSteppedSections()
		{
			MarkComplexCorners();
			LinkedListNode<Vertex> linkedListNode = _vertices.First;
			LinkedListNode<Vertex> linkedListNode2 = linkedListNode;
			LinkedListNode<Vertex>[] array = new LinkedListNode<Vertex>[3];
			List<TopologyQueryResult> list = new List<TopologyQueryResult>();
			do
			{
				array[0] = linkedListNode.LoopingPrevious();
				array[1] = linkedListNode;
				array[2] = linkedListNode.LoopingNext();
				foreach (TopologyQueryResult item in QueryTopology(array))
				{
					if (item.match)
					{
						list.Add(item);
					}
				}
				linkedListNode = linkedListNode.LoopingNext();
			}
			while (linkedListNode != linkedListNode2);
			foreach (TopologyQueryResult item2 in list)
			{
				if (item2.updateType == TopologyQueryResult.UpdateType.Deletion)
				{
					_vertices.Remove(item2.nodeForUpdate);
				}
				else if (item2.updateType == TopologyQueryResult.UpdateType.Topology)
				{
					item2.nodeForUpdate.Value.topologyType = item2.newTopologyType;
				}
			}
			DeleteFlatVertices(onlyDiagonals: true);
		}

		private void MarkComplexCorners()
		{
			LinkedListNode<Vertex> linkedListNode = _vertices.First;
			LinkedListNode<Vertex> linkedListNode2 = linkedListNode;
			LinkedListNode<Vertex>[] array = new LinkedListNode<Vertex>[4];
			TopologyPattern topologyPattern = new TopologyPattern(new TopologyType[4]
			{
				TopologyType.Convex,
				TopologyType.Concave,
				TopologyType.Concave,
				TopologyType.Convex
			}, deletion: false, topologyUpdate: false, markTerminal: false);
			List<LinkedListNode<Vertex>> list = new List<LinkedListNode<Vertex>>();
			array[0] = linkedListNode2;
			for (int i = 1; i < array.Length; i++)
			{
				array[i] = array[i - 1].LoopingNext();
			}
			do
			{
				if (topologyPattern.Match(array))
				{
					LinkedListNode<Vertex>[] array2 = array;
					foreach (LinkedListNode<Vertex> linkedListNode3 in array2)
					{
						linkedListNode3.Value.isComplexCorner = true;
						list.Add(linkedListNode3);
					}
				}
				for (int k = 0; k < array.Length; k++)
				{
					if (k == array.Length - 1)
					{
						array[k] = array[k].LoopingNext();
					}
					else
					{
						array[k] = array[k + 1];
					}
				}
				linkedListNode = linkedListNode.LoopingNext();
			}
			while (linkedListNode != linkedListNode2);
			foreach (LinkedListNode<Vertex> item in list)
			{
				item.Value.topologyType = TopologyType.ComplexCorner;
			}
		}

		private void UnmarkComplexCorners()
		{
			LinkedListNode<Vertex> linkedListNode = _vertices.First;
			LinkedListNode<Vertex> linkedListNode2 = linkedListNode;
			do
			{
				if (linkedListNode.Value.isComplexCorner)
				{
					linkedListNode.Value.topologyType = CalculateTopology(linkedListNode);
				}
				linkedListNode = linkedListNode.LoopingNext();
			}
			while (linkedListNode != linkedListNode2);
		}

		private TopologyType CalculateTopology(LinkedListNode<Vertex> node)
		{
			Vertex value = node.LoopingPrevious().Value;
			Vertex value2 = node.LoopingNext().Value;
			return CalculateTopology(node.Value.position, value2.position, value.position);
		}

		private TopologyType CalculateTopology(Vector3 a, Vector3 b, Vector3 c)
		{
			Vector3 lhs = b - a;
			Vector3 rhs = c - a;
			Vector3 vector = Vector3.Cross(lhs, rhs);
			if (vector.z > Mathf.Epsilon)
			{
				return TopologyType.Concave;
			}
			if (vector.z < 0f - Mathf.Epsilon)
			{
				return TopologyType.Convex;
			}
			return TopologyType.Flat;
		}

		public void ShiftDiagonalsInland()
		{
			CalculateCornerAngles();
			CalculateMoveVectors();
			LinkedListNode<Vertex> linkedListNode = _vertices.First;
			LinkedListNode<Vertex> linkedListNode2 = linkedListNode;
			do
			{
				Vertex value = linkedListNode.Value;
				value.position += value.cachedMoveVector;
				linkedListNode = linkedListNode.LoopingNext();
			}
			while (linkedListNode != linkedListNode2);
			PairCloseVertices();
			PreparePairedVertsForArcCreation();
			DeleteFlatVertices(onlyDiagonals: false);
			UnmarkComplexCorners();
		}

		public void SmoothCorners()
		{
			CalculateCornerAngles();
			CalculateVertexInfoForSmoothCorners();
			LinkedListNode<Vertex> linkedListNode = _vertices.First;
			LinkedListNode<Vertex> linkedListNode2 = linkedListNode;
			List<CornerBuildOrder> list = new List<CornerBuildOrder>();
			do
			{
				Vertex value = linkedListNode.Value;
				LinkedListNode<Vertex> linkedListNode3 = linkedListNode.LoopingNext();
				LinkedListNode<Vertex> linkedListNode4 = linkedListNode.LoopingPrevious();
				if (value.HasPairedVertex)
				{
					LinkedListNode<Vertex> linkedListNode5;
					LinkedListNode<Vertex> linkedListNode6;
					if (linkedListNode.Value.PairedVertex == linkedListNode3.Value)
					{
						linkedListNode5 = linkedListNode;
						linkedListNode6 = linkedListNode3;
						linkedListNode = linkedListNode3;
						if (linkedListNode == linkedListNode2)
						{
							break;
						}
					}
					else
					{
						linkedListNode5 = linkedListNode4;
						linkedListNode6 = linkedListNode;
					}
					Vertex value2 = linkedListNode5.Value;
					Vertex value3 = linkedListNode6.Value;
					Vector3 position = linkedListNode5.LoopingPrevious().Value.position;
					Vector3 position2 = linkedListNode6.LoopingNext().Value.position;
					Vector3 normalized = (position - value2.position).normalized;
					Vector3 normalized2 = (position2 - value3.position).normalized;
					list.Add(new CornerBuildOrder(new LinkedListNode<Vertex>[2] { linkedListNode5, linkedListNode6 }, normalized, normalized2, 0.08f, 12, dualArcCorner: false));
				}
				else
				{
					Vector3 position3 = value.position;
					Vector3 position4 = linkedListNode3.Value.position;
					Vector3 normalized3 = (linkedListNode4.Value.position - position3).normalized;
					Vector3 normalized4 = (position4 - position3).normalized;
					if (_visualGroupType == MapVisualGroupType.Land)
					{
						if (value.isRightAngle)
						{
							if (value.topologyType == TopologyType.Concave && value.GetProximity() == Vertex.Proximity.Far)
							{
								list.Add(new CornerBuildOrder(linkedListNode, normalized3, normalized4, 1.18f, 20, dualArcCorner: false));
							}
							else if (value.topologyType == TopologyType.Concave && value.GetProximity() == Vertex.Proximity.Close)
							{
								list.Add(new CornerBuildOrder(linkedListNode, normalized3, normalized4, 0.2f, 8, dualArcCorner: false));
							}
							else
							{
								list.Add(new CornerBuildOrder(linkedListNode, normalized3, normalized4, 0.3f, 8, dualArcCorner: false));
							}
						}
						else if (value.GetProximity() == Vertex.Proximity.Close)
						{
							if (value.topologyType == TopologyType.Convex)
							{
								list.Add(new CornerBuildOrder(linkedListNode, normalized3, normalized4, 0.2f, 9, dualArcCorner: false));
							}
							else
							{
								list.Add(new CornerBuildOrder(linkedListNode, normalized3, normalized4, 0.18f, 7, dualArcCorner: false));
							}
						}
						else if (value.GetProximity() == Vertex.Proximity.Medium)
						{
							if (value.topologyType == TopologyType.Convex)
							{
								list.Add(new CornerBuildOrder(linkedListNode, normalized3, normalized4, 0.565f, 10, dualArcCorner: false));
							}
							else
							{
								list.Add(new CornerBuildOrder(linkedListNode, normalized3, normalized4, 0.45f, 10, dualArcCorner: false));
							}
						}
						else if (value.topologyType == TopologyType.Convex)
						{
							list.Add(new CornerBuildOrder(linkedListNode, normalized3, normalized4, 0.64f, 12, dualArcCorner: false));
						}
						else
						{
							list.Add(new CornerBuildOrder(linkedListNode, normalized3, normalized4, 0.47f, 14, dualArcCorner: false));
						}
					}
					else if (_visualGroupType == MapVisualGroupType.Mountains)
					{
						if (value.isRightAngle)
						{
							if (value.topologyType == TopologyType.Convex)
							{
								if (value.GetProximity() == Vertex.Proximity.Far && _meshLayer == MapMeshLayer.MountainA)
								{
									list.Add(new CornerBuildOrder(linkedListNode, normalized3, normalized4, 0.97f, 13, dualArcCorner: true));
								}
								else
								{
									list.Add(new CornerBuildOrder(linkedListNode, normalized3, normalized4, 0.3f, 8, dualArcCorner: false));
								}
							}
							else if (value.GetProximity() == Vertex.Proximity.Far && _meshLayer == MapMeshLayer.MountainA)
							{
								list.Add(new CornerBuildOrder(linkedListNode, normalized3, normalized4, 0.82f, 12, dualArcCorner: false));
							}
							else
							{
								list.Add(new CornerBuildOrder(linkedListNode, normalized3, normalized4, 0.2f, 8, dualArcCorner: false));
							}
						}
						else if (_meshLayer != MapMeshLayer.MountainA)
						{
							list.Add(new CornerBuildOrder(linkedListNode, normalized3, normalized4, 0.1f, 7, dualArcCorner: false));
						}
						else if (value.topologyType == TopologyType.Convex)
						{
							list.Add(new CornerBuildOrder(linkedListNode, normalized3, normalized4, 0.27f, 7, dualArcCorner: false));
						}
						else
						{
							list.Add(new CornerBuildOrder(linkedListNode, normalized3, normalized4, 0.7425f, 11, dualArcCorner: false));
						}
					}
				}
				linkedListNode = linkedListNode.LoopingNext();
			}
			while (linkedListNode != linkedListNode2);
			foreach (CornerBuildOrder item in list)
			{
				BuildCorner(item);
			}
		}

		private List<TopologyQueryResult> QueryTopology(IReadOnlyList<LinkedListNode<Vertex>> patternQuery)
		{
			List<TopologyQueryResult> list = new List<TopologyQueryResult>();
			TopologyPattern[] topologyPatterns = _topologyPatterns;
			foreach (TopologyPattern topologyPattern in topologyPatterns)
			{
				if (topologyPattern.Match(patternQuery))
				{
					if (topologyPattern.deletion)
					{
						patternQuery[0].Value.inDiagonalSection = true;
						patternQuery[2].Value.inDiagonalSection = true;
						list.Add(new TopologyQueryResult
						{
							match = true,
							updateType = TopologyQueryResult.UpdateType.Deletion,
							nodeForUpdate = patternQuery[1]
						});
					}
					if (topologyPattern.topologyUpdate)
					{
						list.Add(new TopologyQueryResult
						{
							match = true,
							updateType = TopologyQueryResult.UpdateType.Topology,
							nodeForUpdate = patternQuery[topologyPattern.updateIndex],
							newTopologyType = topologyPattern.newTopologyType
						});
					}
					if (topologyPattern.markTerminal)
					{
						patternQuery[topologyPattern.updateIndex].Value.inDiagonalSection = true;
						patternQuery[topologyPattern.updateIndex].Value.diagonalSectionTerminal = true;
					}
				}
			}
			return list;
		}

		private void DeleteFlatVertices(bool onlyDiagonals)
		{
			List<LinkedListNode<Vertex>> list = new List<LinkedListNode<Vertex>>();
			LinkedListNode<Vertex> linkedListNode = _vertices.First;
			LinkedListNode<Vertex> linkedListNode2 = linkedListNode;
			do
			{
				if (onlyDiagonals)
				{
					if (linkedListNode.Value.inDiagonalSection && !linkedListNode.Value.diagonalSectionTerminal)
					{
						list.Add(linkedListNode);
					}
				}
				else if (linkedListNode.Value.topologyType == TopologyType.Flat || (linkedListNode.Value.inDiagonalSection && !linkedListNode.Value.diagonalSectionTerminal))
				{
					list.Add(linkedListNode);
				}
				linkedListNode = linkedListNode.LoopingNext();
			}
			while (linkedListNode != linkedListNode2);
			foreach (LinkedListNode<Vertex> item in list)
			{
				_vertices.Remove(item);
			}
		}

		private void CalculateMoveVectors()
		{
			LinkedListNode<Vertex> linkedListNode = _vertices.First;
			LinkedListNode<Vertex> linkedListNode2 = linkedListNode;
			List<LinkedListNode<Vertex>> list = new List<LinkedListNode<Vertex>>();
			do
			{
				Vertex value = linkedListNode.Value;
				if (value.inDiagonalSection)
				{
					if (!value.diagonalSectionTerminal)
					{
						Diagnostics.FailAssert("Unhandled topology! All flat diagonal vertices should have been deleted by now.");
						return;
					}
					LinkedListNode<Vertex> linkedListNode3 = linkedListNode.LoopingNext();
					LinkedListNode<Vertex> linkedListNode4 = linkedListNode.LoopingPrevious();
					Vector3 position = linkedListNode3.Value.position;
					Vector3 position2 = linkedListNode4.Value.position;
					if (!value.dontRecalculateMoveVector)
					{
						bool flag = value.position.IsCardinal2D(position);
						bool flag2 = value.position.IsCardinal2D(position2);
						Vector3 vector2;
						if (value.topologyType == TopologyType.ComplexCorner)
						{
							LinkedListNode<Vertex> linkedListNode5;
							LinkedListNode<Vertex> linkedListNode6;
							if (linkedListNode3.Value.topologyType == TopologyType.ComplexCorner && (linkedListNode3.Value.position - linkedListNode.Value.position).magnitude < 2f)
							{
								linkedListNode5 = linkedListNode3;
								linkedListNode6 = linkedListNode3.LoopingNext();
							}
							else
							{
								linkedListNode5 = linkedListNode4;
								linkedListNode6 = linkedListNode4.LoopingPrevious();
							}
							Vector3 vector = linkedListNode6.Value.position - linkedListNode5.Value.position;
							linkedListNode5.Value.cachedMoveVector = vector.normalized * (1f - GetDiagonalShiftDistance());
							linkedListNode5.Value.dontRecalculateMoveVector = true;
							if (!linkedListNode5.Value.HasPairedVertex && !linkedListNode6.Value.HasPairedVertex)
							{
								Vertex.PairVertices(linkedListNode5.Value, linkedListNode6.Value);
							}
							list.Add(linkedListNode);
							vector2 = Vector3.zero;
						}
						else if (value.isAcuteAngle)
						{
							Vertex vertex = new Vertex(value)
							{
								diagonalSectionTerminal = false,
								inDiagonalSection = false,
								dontRecalculateMoveVector = true
							};
							Vertex.PairVertices(value, vertex);
							if (flag)
							{
								Vector3 vector3 = position - value.position;
								vertex.cachedMoveVector = vector3.normalized * (GetDiagonalShiftDistance() * _splitVertexCardinalEdgeShiftScalar);
								vector2 = -vector3.RotateCCW2D();
								_vertices.AddAfter(linkedListNode, vertex);
							}
							else
							{
								Vector3 vector4 = position2 - value.position;
								vertex.cachedMoveVector = vector4.normalized * (GetDiagonalShiftDistance() * _splitVertexCardinalEdgeShiftScalar);
								vector2 = -vector4.RotateCW2D();
								_vertices.AddBefore(linkedListNode, vertex);
							}
						}
						else if (flag)
						{
							vector2 = position - value.position;
						}
						else if (flag2)
						{
							vector2 = position2 - value.position;
						}
						else
						{
							if (value.topologyType != TopologyType.Concave)
							{
								Diagnostics.FailAssert("Unhandled topology! There should never be a case where two diagonal edges meet at a convex vertex.");
								return;
							}
							Vector3 normalized = (position2 - value.position).normalized;
							vector2 = (position - value.position).normalized - normalized;
							Vertex value2 = new Vertex(value)
							{
								dontRecalculateMoveVector = true,
								cachedMoveVector = vector2.normalized * GetDiagonalShiftDistance()
							};
							_vertices.AddAfter(linkedListNode, value2);
						}
						if (value.topologyType == TopologyType.Concave)
						{
							vector2 = -vector2;
						}
						value.cachedMoveVector = vector2.normalized * GetDiagonalShiftDistance();
					}
				}
				linkedListNode = linkedListNode.LoopingNext();
			}
			while (linkedListNode != linkedListNode2);
			foreach (LinkedListNode<Vertex> item in list)
			{
				item.List.Remove(item);
			}
		}

		private void PairCloseVertices()
		{
			LinkedListNode<Vertex> linkedListNode = _vertices.First;
			LinkedListNode<Vertex> linkedListNode2 = linkedListNode;
			do
			{
				Vertex value = linkedListNode.Value;
				Vertex value2 = linkedListNode.LoopingNext().Value;
				if (!value.HasPairedVertex && value.topologyType != TopologyType.Flat && value2.topologyType != TopologyType.Flat && (value.position - value2.position).magnitude < 0.5f)
				{
					Vertex.PairVertices(value, value2);
					value.isComplexCorner = true;
					value2.isComplexCorner = true;
				}
				linkedListNode = linkedListNode.LoopingNext();
			}
			while (linkedListNode != linkedListNode2);
		}

		private void PreparePairedVertsForArcCreation()
		{
			LinkedListNode<Vertex> linkedListNode = _vertices.First;
			LinkedListNode<Vertex> linkedListNode2 = linkedListNode;
			List<IntersectingEdgeReplacementOperation> list = new List<IntersectingEdgeReplacementOperation>();
			do
			{
				LinkedListNode<Vertex> linkedListNode3 = linkedListNode;
				if (linkedListNode3.Value.HasPairedVertex && linkedListNode3.Value.isComplexCorner)
				{
					Vertex pairedVertex = linkedListNode3.Value.PairedVertex;
					LinkedListNode<Vertex> linkedListNode4 = linkedListNode.LoopingNext();
					if (linkedListNode4.Value != pairedVertex)
					{
						linkedListNode = linkedListNode.LoopingNext();
						continue;
					}
					LinkedListNode<Vertex> linkedListNode5 = linkedListNode.LoopingPrevious();
					LinkedListNode<Vertex> linkedListNode6 = linkedListNode4;
					LinkedListNode<Vertex> linkedListNode7 = linkedListNode4.LoopingNext();
					float magnitude = (linkedListNode3.Value.position - linkedListNode6.Value.position).magnitude;
					bool flag = false;
					if (linkedListNode3.Value.position.IsCardinal2D(linkedListNode5.Value.position))
					{
						Vector3 normalized = (linkedListNode5.Value.position - linkedListNode3.Value.position).normalized;
						linkedListNode3.Value.position += normalized * (magnitude * _splitVertexCardinalEdgeShiftScalar);
						flag = true;
					}
					if (linkedListNode6.Value.position.IsCardinal2D(linkedListNode7.Value.position))
					{
						Vector3 normalized2 = (linkedListNode7.Value.position - linkedListNode6.Value.position).normalized;
						linkedListNode6.Value.position += normalized2 * (magnitude * _splitVertexCardinalEdgeShiftScalar);
						flag = true;
					}
					if (!flag && LineIntersection.IntersectLines(linkedListNode5.Value.position, linkedListNode3.Value.position, linkedListNode6.Value.position, linkedListNode7.Value.position, out var intersect))
					{
						Vertex c = new Vertex(newTopologyType: (!(Vector3.Cross(linkedListNode5.Value.position - (Vector3)intersect, linkedListNode7.Value.position - (Vector3)intersect).z < 0f)) ? TopologyType.Convex : TopologyType.Concave, newPosition: intersect)
						{
							diagonalSectionTerminal = true,
							inDiagonalSection = true,
							isRightAngle = true
						};
						list.Add(new IntersectingEdgeReplacementOperation
						{
							p1 = linkedListNode3,
							p2 = linkedListNode6,
							c = c
						});
					}
				}
				linkedListNode = linkedListNode.LoopingNext();
			}
			while (linkedListNode != linkedListNode2);
			foreach (IntersectingEdgeReplacementOperation item in list)
			{
				_vertices.AddAfter(item.p1, item.c);
				_vertices.Remove(item.p1);
				_vertices.Remove(item.p2);
			}
		}

		private void CalculateCornerAngles()
		{
			LinkedListNode<Vertex> linkedListNode = _vertices.First;
			LinkedListNode<Vertex> linkedListNode2 = linkedListNode;
			do
			{
				Vertex value = linkedListNode.Value;
				Vector3 position = value.position;
				Vector3 position2 = linkedListNode.LoopingNext().Value.position;
				Vector3 position3 = linkedListNode.LoopingPrevious().Value.position;
				Vector3 vector = position2 - position;
				Vector3 vector2 = position3 - position;
				float num = Mathf.Atan2(vector.y, vector.x);
				float num2 = Mathf.Atan2(vector2.y, vector2.x) - num;
				if (num2 < 0f)
				{
					num2 += (float)Math.PI * 2f;
				}
				value.isRightAngle = Mathf.Approximately(num2, (float)Math.PI / 2f) || Mathf.Approximately(num2, 4.712389f);
				value.isAcuteAngle = Mathf.Approximately(num2, (float)Math.PI / 4f);
				linkedListNode = linkedListNode.LoopingNext();
			}
			while (linkedListNode != linkedListNode2);
		}

		private void CalculateVertexInfoForSmoothCorners()
		{
			LinkedListNode<Vertex> linkedListNode = _vertices.First;
			LinkedListNode<Vertex> linkedListNode2 = linkedListNode;
			do
			{
				Vertex value = linkedListNode.Value;
				Vector3 position = value.position;
				Vertex value2 = linkedListNode.LoopingNext().Value;
				Vertex value3 = linkedListNode.LoopingPrevious().Value;
				Vector3 position2 = value2.position;
				Vector3 position3 = value3.position;
				Vector3 vector = position2 - position;
				Vector3 vector2 = position3 - position;
				float sqrDistanceToClosestConnectedVertex = Mathf.Min(vector.sqrMagnitude, vector2.sqrMagnitude);
				value.sqrDistanceToClosestConnectedVertex = sqrDistanceToClosestConnectedVertex;
				linkedListNode = linkedListNode.LoopingNext();
			}
			while (linkedListNode != linkedListNode2);
		}

		private void BuildCorner(CornerBuildOrder buildOrder)
		{
			Vector3 position = buildOrder.targetNodes[0].Value.position;
			Vector3 position2 = buildOrder.targetNodes[buildOrder.targetNodes.Length - 1].Value.position;
			(Vector3, Vector3) curveStartPoints = GetCurveStartPoints(position, position2, buildOrder.prevDirection, buildOrder.nextDirection, buildOrder.cornerDepth);
			foreach (Vector3 smoothPoint in GetSmoothPoints(curveStartPoints.Item1, buildOrder.prevDirection, curveStartPoints.Item2, buildOrder.nextDirection, buildOrder.numberOfPoints, buildOrder.Concave, buildOrder.dualArcCorner))
			{
				Vertex value = new Vertex(smoothPoint, buildOrder.targetNodes[0].Value.topologyType);
				buildOrder.targetNodes[0].List.AddBefore(buildOrder.targetNodes[0], value);
			}
			LinkedListNode<Vertex>[] targetNodes = buildOrder.targetNodes;
			foreach (LinkedListNode<Vertex> linkedListNode in targetNodes)
			{
				linkedListNode.List.Remove(linkedListNode);
			}
		}

		private (Vector3, Vector3) GetCurveStartPoints(Vector3 curveBaseStart, Vector3 curveBaseEnd, Vector3 prevDirection, Vector3 nextDirection, float cornerDepth)
		{
			Vector3 item = curveBaseStart + prevDirection * cornerDepth;
			Vector3 item2 = curveBaseEnd + nextDirection * cornerDepth;
			return (item, item2);
		}

		private List<Vector3> GetSmoothPoints(Vector3 startPosition, Vector3 startDirection, Vector3 endPosition, Vector3 endDirection, int numberOfPoints, bool concave, bool dualArc)
		{
			List<Vector3> list = new List<Vector3>();
			Vector3 normal = startDirection.RotateCW2D();
			Vector3 normal2 = endDirection.RotateCCW2D();
			Vector3 arcCenterFromNormals = GetArcCenterFromNormals(startPosition, normal, endPosition, normal2);
			Vector3[] array = ((!dualArc) ? new Vector3[2] { arcCenterFromNormals, arcCenterFromNormals } : new Vector3[2]
			{
				Vector3.Lerp(arcCenterFromNormals, startPosition, 0.32f),
				Vector3.Lerp(arcCenterFromNormals, endPosition, 0.32f)
			});
			Vector3 vector = startPosition - arcCenterFromNormals;
			Vector3 vector2 = endPosition - arcCenterFromNormals;
			float num = vector.magnitude;
			if (dualArc)
			{
				num *= 0.68f;
			}
			float num2 = Mathf.Atan2(vector.y, vector.x);
			float num3 = Mathf.Atan2(vector2.y, vector2.x) - num2;
			if (concave)
			{
				if (num3 < 0f)
				{
					num3 += (float)Math.PI * 2f;
				}
			}
			else if (num3 > (float)Math.PI)
			{
				num3 = 0f - ((float)Math.PI * 2f - num3);
			}
			float num4 = num2;
			for (int i = 0; i < numberOfPoints; i++)
			{
				float num5 = (float)i / (float)(numberOfPoints - 1) * num3;
				float f = num4 + num5;
				Vector3 vector3 = ((i < numberOfPoints / 2) ? array[0] : array[1]);
				Vector3 item = new Vector3(vector3.x + num * Mathf.Cos(f), vector3.y + num * Mathf.Sin(f));
				list.Add(item);
			}
			return list;
		}

		private Vector3 GetArcCenterFromNormals(Vector3 point1, Vector3 normal1, Vector3 point2, Vector3 normal2)
		{
			if (LineIntersection.IntersectLines(point1, point1 + normal1, point2, point2 + normal2, out var intersect, LineIntersection.LineIntersectMode.Lines))
			{
				return intersect;
			}
			Diagnostics.FailAssert("No intersection found!");
			return default(Vector3);
		}
	}
}
