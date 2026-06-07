namespace System.Reflection
{
	[AttributeUsage(AttributeTargets.Assembly)]
	public class AssemblyComponentName : Attribute
	{
		private string _name;

		public string Name => _name;

		public AssemblyComponentName(string name)
		{
			_name = name;
		}
	}
}
