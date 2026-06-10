using System;
using System.Collections.Generic;

namespace ChatGraphSystem
{
	[Serializable]
	public abstract class BaseNode
	{
		public string Id;

		public readonly NodeType Type;

		protected List<string> NextNodeIds;

		protected BaseNode(NodeType type)
		{
			Id = Guid.NewGuid().ToString();
			Type = type;
			NextNodeIds = new List<string>();
		}
	}
}
