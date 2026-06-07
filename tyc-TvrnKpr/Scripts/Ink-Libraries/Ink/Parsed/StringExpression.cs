using System.Collections.Generic;
using Ink.Runtime;

namespace Ink.Parsed
{
	public class StringExpression : Expression
	{
		public bool isSingleString => false;

		public StringExpression(List<Object> content)
		{
		}

		public override void GenerateIntoContainer(Container container)
		{
		}

		public override string ToString()
		{
			return null;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
