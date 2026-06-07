using System.Collections.Generic;
using System.Text;

namespace Ink.Runtime
{
	public class ProfileNode
	{
		public readonly string key;

		public bool openInUI;

		private Dictionary<string, ProfileNode> _nodes;

		private double _selfMillisecs;

		private double _totalMillisecs;

		private int _selfSampleCount;

		private int _totalSampleCount;

		public bool hasChildren => false;

		public int totalMillisecs => 0;

		public IEnumerable<KeyValuePair<string, ProfileNode>> descendingOrderedNodes => null;

		public string ownReport => null;

		public ProfileNode()
		{
		}

		public ProfileNode(string key)
		{
		}

		public void AddSample(string[] stack, double duration)
		{
		}

		private void AddSample(string[] stack, int stackIdx, double duration)
		{
		}

		private void AddSampleToNode(string[] stack, int stackIdx, double duration)
		{
		}

		private void PrintHierarchy(StringBuilder sb, int indent)
		{
		}

		private void Pad(StringBuilder sb, int spaces)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
