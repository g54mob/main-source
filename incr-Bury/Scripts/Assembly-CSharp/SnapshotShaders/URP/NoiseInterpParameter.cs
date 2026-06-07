using System;
using UnityEngine.Rendering;

namespace SnapshotShaders.URP
{
	[Serializable]
	public sealed class NoiseInterpParameter : VolumeParameter<NoiseInterpolation>
	{
		public NoiseInterpParameter(NoiseInterpolation value, bool overrideState = false)
			: base(value, overrideState)
		{
		}
	}
}
