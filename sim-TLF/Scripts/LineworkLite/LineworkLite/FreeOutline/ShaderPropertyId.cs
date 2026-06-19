using UnityEngine;

namespace LineworkLite.FreeOutline
{
	internal static class ShaderPropertyId
	{
		public static readonly int OutlineOccludedColor = Shader.PropertyToID("_OutlineOccludedColor");

		public static readonly int OutlineWidth = Shader.PropertyToID("_OutlineWidth");

		public static readonly int MinOutlineWidth = Shader.PropertyToID("_MinimumOutlineWidth");

		public static readonly int ReferenceResolution = Shader.PropertyToID("_ReferenceResolution");
	}
}
