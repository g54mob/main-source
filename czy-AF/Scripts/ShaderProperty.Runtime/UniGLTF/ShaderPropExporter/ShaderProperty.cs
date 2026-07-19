namespace UniGLTF.ShaderPropExporter
{
	public struct ShaderProperty
	{
		public string Key;

		public ShaderPropertyType ShaderPropertyType;

		public ShaderProperty(string key, ShaderPropertyType propType)
		{
			Key = key;
			ShaderPropertyType = propType;
		}
	}
}
