using Unity.Collections;
using Unity.Mathematics;

namespace andywiecko.BurstTriangulator
{
	public struct Status
	{
		private int value1;

		private int value2;

		private int value3;

		private int value4;

		public TriangulatorErrorType type;

		public bool IsError => false;

		public static Status Ok => default(Status);

		public static Status DegenerateInput => default(Status);

		public static Status SloanMaxItersExceeded => default(Status);

		public static Status IntegersDoNotSupportMeshRefinement => default(Status);

		public static Status RedudantHolesArray => default(Status);

		public static Status ConstraintEdgesMissingForAutoHolesAndBoundary => default(Status);

		public static Status ConstraintEdgesMissingForRestoreBoundary => default(Status);

		public static Status RefinementNotSupportedForCoordinateType => default(Status);

		public static Status RefinementThresholdAreaMustBePositive => default(Status);

		public static Status RefinementThresholdAngleOutOfRange => default(Status);

		public static Status PositionsLengthLessThan3(int length)
		{
			return default(Status);
		}

		public static Status PositionsMustBeFinite(int index)
		{
			return default(Status);
		}

		public static Status ConstraintsLengthNotDivisibleBy2(int length)
		{
			return default(Status);
		}

		public static Status DuplicatePosition(int index)
		{
			return default(Status);
		}

		public static Status DuplicateConstraint(int index1, int index2)
		{
			return default(Status);
		}

		public static Status ConstraintOutOfBounds(int index, int2 constraint, int positionLength)
		{
			return default(Status);
		}

		public static Status ConstraintSelfLoop(int index, int2 constraint)
		{
			return default(Status);
		}

		public static Status ConstraintIntersection(int index1, int index2)
		{
			return default(Status);
		}

		public static Status ConstraintArrayLengthMismatch(int constraintLength, int constraintTypeLength)
		{
			return default(Status);
		}

		public static Status HoleMustBeFinite(int index)
		{
			return default(Status);
		}

		public static Status SloanMaxItersMustBePositive(int sloanMaxIters)
		{
			return default(Status);
		}

		internal FixedString64Bytes ToFixedString()
		{
			return default(FixedString64Bytes);
		}

		public override string ToString()
		{
			return null;
		}
	}
}
