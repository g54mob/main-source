namespace Linework.EdgeDetection
{
	internal static class ShaderFeature
	{
		public const string DepthDiscontinuity = "DEPTH";

		public const string NormalDiscontinuity = "NORMALS";

		public const string LuminanceDiscontinuity = "LUMINANCE";

		public const string SectionDiscontinuity = "SECTIONS";

		public const string TextureUV0 = "TEXTURE_UV_SET_UV0";

		public const string TextureUV1 = "TEXTURE_UV_SET_UV1";

		public const string TextureUV2 = "TEXTURE_UV_SET_UV2";

		public const string TextureUV3 = "TEXTURE_UV_SET_UV3";

		public const string VertexColorChannelR = "VERTEX_COLOR_CHANNEL_R";

		public const string VertexColorChannelG = "VERTEX_COLOR_CHANNEL_G";

		public const string VertexColorChannelB = "VERTEX_COLOR_CHANNEL_B";

		public const string VertexColorChannelA = "VERTEX_COLOR_CHANNEL_A";

		public const string TextureChannelR = "TEXTURE_CHANNEL_R";

		public const string TextureChannelG = "TEXTURE_CHANNEL_G";

		public const string TextureChannelB = "TEXTURE_CHANNEL_B";

		public const string TextureChannelA = "TEXTURE_CHANNEL_A";

		public const string OperatorCross = "OPERATOR_CROSS";

		public const string OperatorSobel = "OPERATOR_SOBEL";

		public const string DebugDepth = "DEBUG_DEPTH";

		public const string DebugNormals = "DEBUG_NORMALS";

		public const string DebugLuminance = "DEBUG_LUMINANCE";

		public const string DebugSections = "DEBUG_SECTIONS";

		public const string DebugSectionsRawValues = "DEBUG_SECTIONS_RAW_VALUES";

		public const string OverrideShadow = "OVERRIDE_SHADOW";

		public const string ScaleWithResolution = "SCALE_WITH_RESOLUTION";

		public const string FadeInDistance = "FADE_IN_DISTANCE";

		public const string SectionsMask = "SECTIONS_MASK";

		public const string DepthMask = "DEPTH_MASK";

		public const string NormalsMask = "NORMALS_MASK";

		public const string LuminanceMask = "LUMINANCE_MASK";

		public const string ObjectId = "OBJECT_ID";

		public const string Particles = "PARTICLES";

		public const string InputVertexColor = "INPUT_VERTEX_COLOR";

		public const string InputTexture = "INPUT_TEXTURE";
	}
}
