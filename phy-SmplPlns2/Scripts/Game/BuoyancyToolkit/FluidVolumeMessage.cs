using UnityEngine;

namespace BuoyancyToolkit
{
	public struct FluidVolumeMessage
	{
		public FluidVolume fluidVolume;

		public Collider collider;

		public FluidVolumeMessage(FluidVolume fluidVolume, Collider collider)
		{
			this.fluidVolume = fluidVolume;
			this.collider = collider;
		}
	}
}
