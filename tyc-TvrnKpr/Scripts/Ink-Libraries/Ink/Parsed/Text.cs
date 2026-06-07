using Ink.Runtime;

namespace Ink.Parsed
{
	public class Text : Object
	{
		public string text { get; set; }

		public Text(string str)
		{
		}

		public override Ink.Runtime.Object GenerateRuntimeObject()
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
