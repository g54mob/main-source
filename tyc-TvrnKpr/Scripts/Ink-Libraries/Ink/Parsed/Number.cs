using Ink.Runtime;

namespace Ink.Parsed
{
	public class Number : Expression
	{
		public object value;

		public Number(object value)
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
