using UnityEngine;
using XNode;

namespace Gh.Tk.Story
{
	[CreateAssetMenu(menuName = "Greenheart Custom/Story/Story Graph")]
	public class StoryGraph : NodeGraph
	{
		public override Node CopyNode(Node original)
		{
			return null;
		}
	}
}
