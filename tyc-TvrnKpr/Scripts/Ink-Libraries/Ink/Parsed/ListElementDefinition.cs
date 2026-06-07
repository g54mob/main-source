using Ink.Runtime;

namespace Ink.Parsed
{
	public class ListElementDefinition : Object
	{
		public string name;

		public int? explicitValue;

		public int seriesValue;

		public bool inInitialList;

		public string fullName => null;

		public override string typeName => null;

		public ListElementDefinition(string name, bool inInitialList, int? explicitValue = null)
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
