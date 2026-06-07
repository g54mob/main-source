using Unity.Mathematics;

namespace Assets.Scripts.Craft.Wings.Runtime
{
	public struct MassPropertiesOutput
	{
		public float Mass;

		public float3 CentreOfMass;

		public float FuelVolume;

		public float3 FuelVolumeCentroid;
	}
}
