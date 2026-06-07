using UnityEngine;

namespace Motorways.EdgeLoopOperator
{
	public class Vertex
	{
		public enum Proximity
		{
			Close = 0,
			Medium = 1,
			Far = 2
		}

		public Vector3 position;

		public TopologyType topologyType;

		public bool diagonalSectionTerminal;

		public bool inDiagonalSection;

		public Vector3 cachedMoveVector = Vector3.zero;

		public bool dontRecalculateMoveVector;

		public float sqrDistanceToClosestConnectedVertex = -1f;

		public bool isRightAngle;

		public bool isAcuteAngle;

		public bool isComplexCorner;

		public Vertex? PairedVertex { get; private set; }

		public bool HasPairedVertex => PairedVertex != null;

		public Proximity GetProximity()
		{
			if (isRightAngle)
			{
				if (sqrDistanceToClosestConnectedVertex < 0.5f)
				{
					return Proximity.Close;
				}
				if (sqrDistanceToClosestConnectedVertex <= 4f)
				{
					return Proximity.Medium;
				}
				return Proximity.Far;
			}
			if (sqrDistanceToClosestConnectedVertex < 0.5f)
			{
				return Proximity.Close;
			}
			if (sqrDistanceToClosestConnectedVertex <= 2f)
			{
				return Proximity.Medium;
			}
			return Proximity.Far;
		}

		public Vertex(Vector3 newPosition, TopologyType newTopologyType)
		{
			position = newPosition;
			topologyType = newTopologyType;
		}

		public Vertex(Vertex copyTarget)
		{
			position = copyTarget.position;
			topologyType = copyTarget.topologyType;
			diagonalSectionTerminal = copyTarget.diagonalSectionTerminal;
			inDiagonalSection = copyTarget.inDiagonalSection;
			cachedMoveVector = copyTarget.cachedMoveVector;
			sqrDistanceToClosestConnectedVertex = copyTarget.sqrDistanceToClosestConnectedVertex;
			isRightAngle = copyTarget.isRightAngle;
			isAcuteAngle = copyTarget.isAcuteAngle;
			isComplexCorner = copyTarget.isComplexCorner;
		}

		public static void PairVertices(Vertex a, Vertex b)
		{
			if (a.HasPairedVertex || b.HasPairedVertex)
			{
				Diagnostics.FailAssert($"Vertex {a} and/or {b} is/are already paired!");
				return;
			}
			a.PairedVertex = b;
			b.PairedVertex = a;
		}
	}
}
