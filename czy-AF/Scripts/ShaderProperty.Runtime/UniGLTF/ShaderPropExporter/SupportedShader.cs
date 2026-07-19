namespace UniGLTF.ShaderPropExporter
{
	public struct SupportedShader
	{
		public string TargetFolder;

		public string ShaderName;

		public SupportedShader(string targetFolder, string shaderName)
		{
			TargetFolder = targetFolder;
			ShaderName = shaderName;
		}
	}
}
