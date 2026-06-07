namespace andywiecko.BurstTriangulator
{
	public enum HalfedgeState : byte
	{
		Unconstrained = 0,
		Constrained = 1,
		ConstrainedAndHoleBoundary = 2
	}
}
