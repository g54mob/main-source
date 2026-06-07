namespace DynamicCSharp.Security
{
	public struct AssemblySecurityError
	{
		public string assemblyName;

		public string moduleName;

		public string securityMessage;

		public string securityType;

		public override string ToString()
		{
			return string.Format("Security Check Failed ({0}) : [{1}, {2}] : {3}", securityType, assemblyName, moduleName, securityMessage);
		}
	}
}
