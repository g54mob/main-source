using System;
using System.Collections.Generic;
using Gh.Tk.Story.Actions.Visual;
using XNode;

namespace Gh.Tk.Story.Structure
{
	[NodeTint("#4b662b")]
	public class SubGraphStartNode : BaseSubNode, INodeActionProvider
	{
		[Output(ShowBackingValue.Never, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection output;

		public List<(string, Action)> GetActions()
		{
			return null;
		}
	}
}
