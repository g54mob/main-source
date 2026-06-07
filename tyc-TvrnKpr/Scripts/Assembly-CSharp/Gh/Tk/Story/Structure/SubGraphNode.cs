using System.Collections.Generic;
using XNode;

namespace Gh.Tk.Story.Structure
{
	[NodeTint("#808080")]
	public class SubGraphNode : StoryNode
	{
		public static string IdsKey;

		public NodeGraph subGraph;

		[Input(ShowBackingValue.Unconnected, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection input;

		[Output(ShowBackingValue.Never, ConnectionType.Multiple, TypeConstraint.None, false, dynamicPortList = true)]
		public NodeConnection[] outputs;

		public bool allowUnconnectedOutputs;

		public const string EndPointName_Key = "endPointName";

		public override void OnTrigger(ActiveStory story)
		{
		}

		private IEnumerable<BaseSubNode> GetAllSubNodes()
		{
			return null;
		}

		public void ParsePorts()
		{
		}

		public void CompleteSubStory(ActiveStory subGraphStory, ActiveStory endStory)
		{
		}
	}
}
