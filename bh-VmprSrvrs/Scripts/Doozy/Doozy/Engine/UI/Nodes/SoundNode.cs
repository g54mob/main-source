using Doozy.Engine.Nody.Attributes;
using Doozy.Engine.Nody.Models;
using Doozy.Engine.Soundy;

namespace Doozy.Engine.UI.Nodes
{
	[NodeMenu("Sound", 1, false, false)]
	public class SoundNode : Node
	{
		public enum SoundActions
		{
			Play = 0,
			Stop = 1,
			Pause = 2,
			Unpause = 3,
			Mute = 4,
			Unmute = 5
		}

		public SoundyData SoundData;

		public SoundActions SoundAction;

		public bool HasSound => false;

		public override void OnCreate()
		{
		}

		public override void AddDefaultSockets()
		{
		}

		public override void CopyNode(Node original)
		{
		}

		public override void OnEnter(Node previousActiveNode, Connection connection)
		{
		}

		public override void CheckForErrors()
		{
		}
	}
}
