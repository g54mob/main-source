namespace Yarn
{
	public struct Line
	{
		public string ID;

		public string[] Substitutions;

		internal Line(string stringID)
		{
			ID = null;
			Substitutions = null;
		}
	}
}
