using System.Collections.Generic;
using Ink.Runtime;

namespace Ink.Parsed
{
	public class List : Expression
	{
		public List<string> itemNameList;

		public List(List<string> itemNameList)
		{
		}

		public override void GenerateIntoContainer(Container container)
		{
		}
	}
}
