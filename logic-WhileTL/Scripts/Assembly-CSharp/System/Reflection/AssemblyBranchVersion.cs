namespace System.Reflection
{
	[AttributeUsage(AttributeTargets.Assembly)]
	public class AssemblyBranchVersion : Attribute
	{
		private string _b;

		public string Branch => _b;

		public AssemblyBranchVersion(string branch)
		{
			_b = branch;
		}
	}
}
