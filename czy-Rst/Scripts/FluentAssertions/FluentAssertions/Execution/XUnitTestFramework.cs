namespace FluentAssertions.Execution
{
	internal class XUnitTestFramework : LateBoundTestFramework
	{
		protected internal override string AssemblyName => _003CassemblyName_003EP;

		protected override string ExceptionFullName => "Xunit.Sdk.XunitException";

		public XUnitTestFramework(string assemblyName)
		{
			_003CassemblyName_003EP = assemblyName;
			base._002Ector(loadAssembly: true);
		}
	}
}
