namespace NSMedieval.BuildingComponents
{
	public struct MeshVariationRules
	{
		public readonly string VariationId;

		public readonly int Angle;

		public readonly bool ShouldFlipRoof;

		public MeshVariationRules(int angle, string variationId, bool shouldFlipRoof)
		{
			Angle = angle;
			VariationId = variationId;
			ShouldFlipRoof = shouldFlipRoof;
		}

		public MeshVariationRules(int angle, string variationId)
		{
			Angle = angle;
			VariationId = variationId;
			ShouldFlipRoof = false;
		}
	}
}
