using System;
using UnityEngine.Rendering;

namespace SnapshotShaders.URP
{
	[Serializable]
	public sealed class BlurTypeParameter : VolumeParameter<BlurType>
	{
		public BlurTypeParameter(BlurType value, bool overrideState = false)
			: base(value, overrideState)
		{
		}
	}
}
