namespace ModApi.Craft
{
	public interface IBodyWaterPhysics : IWaterPhysics<IBodyWaterPhysics>
	{
		PrecisionModeType? PrecisionModePartOverride { get; set; }

		bool IsPrecisionModePerPart { get; }
	}
}
