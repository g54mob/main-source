using Ink.Runtime;

namespace Ink.Parsed
{
	public abstract class Expression : Object
	{
		private Container _prototypeRuntimeConstantExpression;

		public bool outputWhenComplete { get; set; }

		public override Ink.Runtime.Object GenerateRuntimeObject()
		{
			return null;
		}

		public void GenerateConstantIntoContainer(Container container)
		{
		}

		public abstract void GenerateIntoContainer(Container container);
	}
}
