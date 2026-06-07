namespace System.Reflection
{
	[AttributeUsage(AttributeTargets.Assembly)]
	public class AssemblyShortTitle : Attribute
	{
		private string _d;

		public string ShortTitle => _d;

		public AssemblyShortTitle(string shortDescription)
		{
			_d = shortDescription;
		}
	}
}
