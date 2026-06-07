using System;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace SnapshotShaders.URP
{
	[Serializable]
	public sealed class RenderPassEventParameter : VolumeParameter<RenderPassEvent>
	{
		public RenderPassEventParameter(RenderPassEvent value, bool overrideState = false)
			: base(value, overrideState)
		{
		}
	}
}
