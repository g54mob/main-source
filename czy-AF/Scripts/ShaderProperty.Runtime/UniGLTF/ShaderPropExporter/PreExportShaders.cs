namespace UniGLTF.ShaderPropExporter
{
	public static class PreExportShaders
	{
		private const string GLTF_FOLDER = "GLTF";

		[PreExportShaders]
		private static SupportedShader[] SupportedShaders = new SupportedShader[6]
		{
			new SupportedShader("GLTF", "Standard"),
			new SupportedShader("GLTF", "Unlit/Color"),
			new SupportedShader("GLTF", "Unlit/Texture"),
			new SupportedShader("GLTF", "Unlit/Transparent"),
			new SupportedShader("GLTF", "Unlit/Transparent Cutout"),
			new SupportedShader("GLTF", "UniGLTF/UniUnlit")
		};

		private const string VRM_TARGET_FOLDER = "VRM";

		[PreExportShaders]
		public static SupportedShader[] VRMSupportedShaders = new SupportedShader[5]
		{
			new SupportedShader("VRM", "VRM/MToon"),
			new SupportedShader("VRM", "VRM/UnlitTexture"),
			new SupportedShader("VRM", "VRM/UnlitCutout"),
			new SupportedShader("VRM", "VRM/UnlitTransparent"),
			new SupportedShader("VRM", "VRM/UnlitTransparentZWrite")
		};
	}
}
