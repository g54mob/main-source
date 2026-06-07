using System;
using UnityEngine.Rendering;

namespace SnapshotShaders.URP
{
	[Serializable]
	public sealed class AxisMaskParameter : VolumeParameter<AxisMask>
	{
		public AxisMaskParameter(AxisMask value, bool overrideState = false)
			: base(value, overrideState)
		{
		}
	}
}
