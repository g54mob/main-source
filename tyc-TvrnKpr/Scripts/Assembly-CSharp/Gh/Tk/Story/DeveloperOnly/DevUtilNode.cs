using System;
using System.Collections.Generic;
using Gh.Tk.Story.Actions.Visual;
using XNode;

namespace Gh.Tk.Story.DeveloperOnly
{
	[NodeWidth(300)]
	public class DevUtilNode : StoryNode, INodeActionProvider
	{
		public string input;

		public List<(string, Action)> GetActions()
		{
			return null;
		}

		private void FindPlayerPropGift()
		{
		}

		private void FindNeedUsages()
		{
		}

		private void FindNeedInWhitelist()
		{
		}

		private void FindNeedInPatronModifyNodes()
		{
		}

		private void FindNeedInGroupRequestAction()
		{
		}

		private void FindUnlockUsages()
		{
		}
	}
}
