using Unity.Mathematics;

namespace Effectors.ReceiveMethods.Index
{
	public struct SphereSignalDescription
	{
		public readonly int3 centerIndex;

		public int radius;

		public readonly float signalValue;

		public SphereSignalDescription(int3 centerIndex, int radius, float signalValue)
		{
			this.centerIndex = default(int3);
			this.radius = 0;
			this.signalValue = 0f;
		}
	}
}
