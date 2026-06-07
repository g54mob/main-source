using Ink.Runtime;

namespace Ink.Parsed
{
	public class Return : Object
	{
		public Expression returnedExpression { get; protected set; }

		public Return(Expression returnedExpression = null)
		{
		}

		public override Ink.Runtime.Object GenerateRuntimeObject()
		{
			return null;
		}
	}
}
