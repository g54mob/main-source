namespace ModApi.Craft
{
	public interface IWaterPhysics<T> where T : IWaterPhysics<T>
	{
		IBodyScript BodyScript { get; }

		float DisplacedVolume { get; }

		float DisplacedVolumeScaled { get; }

		bool IsFullySubmerged { get; }

		bool IsInWater { get; }

		PrecisionModeType PrecisionMode { get; set; }

		float TotalDisplacementVolume { get; }

		float TotalDisplacementVolumeScaled { get; }

		float UnderWaterAmount { get; }

		event WaterPhysicsHandler<T> WaterEntered;

		event WaterPhysicsHandler<T> WaterExited;

		event WaterPhysicsHandler<T> WaterStay;

		void Dispose();

		void Update();
	}
}
