using System.Collections.Generic;

namespace Ink.Parsed
{
	public class Path
	{
		private FlowLevel? _baseTargetLevel;

		private List<string> _components;

		public FlowLevel baseTargetLevel => default(FlowLevel);

		public bool baseLevelIsAmbiguous => false;

		public string firstComponent => null;

		public int numberOfComponents => 0;

		public string dotSeparatedComponents => null;

		public Path(FlowLevel baseFlowLevel, List<string> components)
		{
		}

		public Path(List<string> components)
		{
		}

		public Path(string ambiguousName)
		{
		}

		public override string ToString()
		{
			return null;
		}

		public Object ResolveFromContext(Object context)
		{
			return null;
		}

		private Object ResolveBaseTarget(Object originalContext)
		{
			return null;
		}

		private Object ResolveTailComponents(Object rootTarget)
		{
			return null;
		}

		private Object TryGetChildFromContext(Object context, string childName, FlowLevel? minimumLevel, bool forceDeepSearch = false)
		{
			return null;
		}
	}
}
