public interface INavigator
{
	byte RequiredClearance { get; }

	byte PreferredClearance { get; }

	int TransitionCost { get; }

	float ReturnTerrainPenalty(Navigator.TerrainType terrain);
}
