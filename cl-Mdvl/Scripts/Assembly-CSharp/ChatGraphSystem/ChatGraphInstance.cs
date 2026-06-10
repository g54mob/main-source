using System;
using System.Collections.Generic;

namespace ChatGraphSystem
{
	public class ChatGraphInstance
	{
		private readonly Dictionary<string, DialogNode> dialogNodes;

		private readonly Dictionary<string, ChoiceNode> choiceNodes;

		public readonly string Id;

		public DialogNode CurrentNode { get; private set; }

		public IReadOnlyList<ChoiceNode> Choices { get; private set; }

		public bool HasEnded { get; private set; }

		public ChatGraphInstance(List<DialogNode> dialogNodes, List<ChoiceNode> choiceNodes, string id)
		{
			Id = id;
			this.dialogNodes = new Dictionary<string, DialogNode>();
			this.choiceNodes = new Dictionary<string, ChoiceNode>();
			foreach (ChoiceNode choiceNode2 in choiceNodes)
			{
				this.choiceNodes[choiceNode2.Id] = choiceNode2;
			}
			HashSet<string> hashSet = new HashSet<string>();
			foreach (DialogNode dialogNode2 in dialogNodes)
			{
				this.dialogNodes[dialogNode2.Id] = dialogNode2;
				foreach (string choiceId in dialogNode2.ChoiceIds)
				{
					ChoiceNode choiceNode = this.choiceNodes[choiceId];
					if (choiceNode.DestinationDialogId != null)
					{
						hashSet.Add(choiceNode.DestinationDialogId);
					}
				}
			}
			DialogNode dialogNode = null;
			foreach (DialogNode dialogNode3 in dialogNodes)
			{
				if (!hashSet.Contains(dialogNode3.Id))
				{
					dialogNode = dialogNode3;
					break;
				}
			}
			if (dialogNode == null)
			{
				throw new Exception("Failed to find start node");
			}
			SetCurrentNode(dialogNode);
		}

		public void MakeChoice(ChoiceNode choiceNode)
		{
			if (choiceNode.DestinationDialogId == null)
			{
				HasEnded = true;
			}
			else
			{
				SetCurrentNode(dialogNodes[choiceNode.DestinationDialogId]);
			}
		}

		private void SetCurrentNode(DialogNode dialogNode)
		{
			CurrentNode = dialogNode;
			List<ChoiceNode> list = new List<ChoiceNode>();
			foreach (string choiceId in CurrentNode.ChoiceIds)
			{
				list.Add(choiceNodes[choiceId]);
			}
			Choices = list;
		}
	}
}
