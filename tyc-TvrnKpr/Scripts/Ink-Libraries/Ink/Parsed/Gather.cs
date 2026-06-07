using Ink.Runtime;

namespace Ink.Parsed
{
	public class Gather : Object, IWeavePoint, INamedContent
	{
		public string name { get; set; }

		public int indentationDepth { get; protected set; }

		public Container runtimeContainer => null;

		public Gather(string name, int indentationDepth)
		{
		}

		public override Ink.Runtime.Object GenerateRuntimeObject()
		{
			return null;
		}

		public override void ResolveReferences(Story context)
		{
		}
	}
}
