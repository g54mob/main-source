using System.Collections.Generic;
using Ink.Runtime;

namespace Ink.Parsed
{
	public class ExternalDeclaration : Object, INamedContent
	{
		public string name { get; set; }

		public List<string> argumentNames { get; set; }

		public ExternalDeclaration(string name, List<string> argumentNames)
		{
		}

		public override Ink.Runtime.Object GenerateRuntimeObject()
		{
			return null;
		}
	}
}
