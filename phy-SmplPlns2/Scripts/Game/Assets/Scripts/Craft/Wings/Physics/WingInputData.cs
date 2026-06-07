using Unity.Mathematics;

namespace Assets.Scripts.Craft.Wings.Physics
{
	public struct WingInputData
	{
		public float altitude;

		public float3 velocity;

		public float3 angularVelocity;

		public Atmosphere.Properties atmosphere;

		public override string ToString()
		{
			return $"alt {altitude}\n" + $"vel {velocity}\n" + $"ang {angularVelocity}\n" + $"{atmosphere}";
		}
	}
}
