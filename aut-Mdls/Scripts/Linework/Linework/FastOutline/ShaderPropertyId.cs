using UnityEngine;

namespace Linework.FastOutline
{
	internal static class ShaderPropertyId
	{
		public static readonly int OutlineOccludedColor = Shader.PropertyToID("_OutlineOccludedColor");

		public static readonly int OutlineWidth = Shader.PropertyToID("_OutlineWidth");

		public static readonly int MinOutlineWidth = Shader.PropertyToID("_MinimumOutlineWidth");
	}
}
