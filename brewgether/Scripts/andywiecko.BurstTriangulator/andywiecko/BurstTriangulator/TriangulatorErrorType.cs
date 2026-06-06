namespace andywiecko.BurstTriangulator
{
	public enum TriangulatorErrorType : byte
	{
		Ok = 0,
		PositionsLengthLessThan3 = 1,
		PositionsMustBeFinite = 2,
		ConstraintsLengthNotDivisibleBy2 = 3,
		DuplicatePosition = 4,
		DuplicateConstraint = 5,
		ConstraintOutOfBounds = 6,
		ConstraintSelfLoop = 7,
		ConstraintIntersection = 8,
		DegenerateInput = 9,
		SloanMaxItersExceeded = 10,
		IntegersDoNotSupportMeshRefinement = 11,
		ConstraintArrayLengthMismatch = 12,
		HoleMustBeFinite = 13,
		RedudantHolesArray = 14,
		ConstraintEdgesMissingForAutoHolesAndBoundary = 15,
		ConstraintEdgesMissingForRestoreBoundary = 16,
		RefinementNotSupportedForCoordinateType = 17,
		SloanMaxItersMustBePositive = 18,
		RefinementThresholdAreaMustBePositive = 19,
		RefinementThresholdAngleOutOfRange = 20
	}
}
