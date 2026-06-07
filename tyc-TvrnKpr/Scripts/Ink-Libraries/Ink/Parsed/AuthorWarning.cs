using Ink.Runtime;

namespace Ink.Parsed
{
	public class AuthorWarning : Object
	{
		public string warningMessage;

		public AuthorWarning(string message)
		{
		}

		public override Ink.Runtime.Object GenerateRuntimeObject()
		{
			return null;
		}
	}
}
