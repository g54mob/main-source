using System;
using System.Collections.Generic;

namespace Pathfinding.Serialization
{
	public class GraphMeta
	{
		public Version version;

		public int graphs;

		public List<string> guids;

		public List<string> typeNames;

		public Type GetGraphType(int index, Type[] availableGraphTypes)
		{
			return null;
		}
	}
}
