using UnityEngine;

namespace Linework.Common.Utils
{
	public enum OutlineRenderQueue
	{
		Opaque = 0,
		Transparent = 1,
		[InspectorName("Opaque + Transparent")]
		OpaqueAndTransparent = 2
	}
}
