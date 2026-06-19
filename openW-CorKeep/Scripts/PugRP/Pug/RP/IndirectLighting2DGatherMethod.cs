using System;

namespace Pug.RP
{
	[Serializable]
	public enum IndirectLighting2DGatherMethod
	{
		PathTracing = 0,
		MultiResolution = 1,
		RadianceCascades = 2
	}
}
