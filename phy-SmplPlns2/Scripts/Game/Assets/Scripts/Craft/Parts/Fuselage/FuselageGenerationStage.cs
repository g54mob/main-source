namespace Assets.Scripts.Craft.Parts.Fuselage
{
	public enum FuselageGenerationStage
	{
		None = 0,
		Setup = 1,
		BaseMesh = 2,
		FindNeighbours = 3,
		Smoothing = 4,
		Cutting = 5,
		MeshModifiers = 6,
		ColliderBake = 7,
		Finalise = 8,
		End = 9
	}
}
