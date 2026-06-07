namespace System.Reflection
{
	[AttributeUsage(AttributeTargets.Assembly)]
	public class AssemblyDataVersion : Attribute
	{
		private string _v;

		public string Version => _v;

		public AssemblyDataVersion(string version)
		{
			_v = version;
		}
	}
}
