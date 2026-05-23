using UnityEngine;

namespace Linework.WideOutline
{
	internal static class ShaderPropertyId
	{
		public static readonly int OutlineOccludedColor = Shader.PropertyToID("_OutlineOccludedColor");

		public static readonly int OutlineWidth = Shader.PropertyToID("_OutlineWidth");

		public static readonly int OutlineGap = Shader.PropertyToID("_OutlineGap");

		public static readonly int RenderScale = Shader.PropertyToID("_RenderScale");

		public static readonly int AxisWidthId = Shader.PropertyToID("_AxisWidth");

		public static readonly int SilhouetteBuffer = Shader.PropertyToID("_SilhouetteBuffer");

		public static readonly int InformationBuffer = Shader.PropertyToID("_InformationBuffer");

		public static readonly int SilhouetteDepthBuffer = Shader.PropertyToID("_SilhouetteDepthBuffer");
	}
}
