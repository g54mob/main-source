using UnityEngine;

namespace Linework.EdgeDetection
{
	internal static class ShaderPropertyId
	{
		public static readonly int BackgroundColor = Shader.PropertyToID("_BackgroundColor");

		public static readonly int OutlineColorShadow = Shader.PropertyToID("_OutlineColorShadow");

		public static readonly int FillColor = Shader.PropertyToID("_FillColor");

		public static readonly int OutlineThickness = Shader.PropertyToID("_OutlineThickness");

		public static readonly int ReferenceResolution = Shader.PropertyToID("_ReferenceResolution");

		public static readonly int FadeStart = Shader.PropertyToID("_FadeStart");

		public static readonly int FadeDistance = Shader.PropertyToID("_FadeDistance");

		public static readonly int FadeColor = Shader.PropertyToID("_FadeColor");

		public static readonly int DepthSensitivity = Shader.PropertyToID("_DepthSensitivity");

		public static readonly int DepthDistanceModulation = Shader.PropertyToID("_DepthDistanceModulation");

		public static readonly int GrazingAngleMaskPower = Shader.PropertyToID("_GrazingAngleMaskPower");

		public static readonly int GrazingAngleMaskHardness = Shader.PropertyToID("_GrazingAngleMaskHardness");

		public static readonly int NormalSensitivity = Shader.PropertyToID("_NormalSensitivity");

		public static readonly int LuminanceSensitivity = Shader.PropertyToID("_LuminanceSensitivity");

		public static readonly int CameraSectioningTexture = Shader.PropertyToID("_CameraSectioningTexture");

		public static readonly int SectionTexture = Shader.PropertyToID("_SectionTexture");
	}
}
