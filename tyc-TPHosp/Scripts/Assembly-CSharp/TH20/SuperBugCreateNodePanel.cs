using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class SuperBugCreateNodePanel : SuperBugCreatorTabPanel
	{
		[SerializeField]
		private DynamicButton _createButton;

		[SerializeField]
		private ButtonAnimator _deleteButton;

		[SerializeField]
		private Image _selectedNodeIcon;

		[SerializeField]
		private TMP_Text _parentNodeLabel;

		[SerializeField]
		private Sprite _defaultNodeIcon;

		protected override void Start()
		{
			_createButton.onPrimaryDown.AddListener(OnCreateButton);
			_deleteButton.Button.onPrimaryDown.AddListener(OnDeleteButton);
			base.Start();
		}

		protected override void OnDestroy()
		{
			_createButton.onPrimaryDown.RemoveListener(OnCreateButton);
			_deleteButton.Button.onPrimaryDown.RemoveListener(OnDeleteButton);
			base.OnDestroy();
		}

		protected override void Refresh()
		{
			_selectedNodeIcon.overrideSprite = SelectedNode?.Definition?.Icon;
			_deleteButton.CurrentState = ((SelectedNode == null || SelectedNode.IsRoot) ? ButtonAnimator.State.Unselectable : ButtonAnimator.State.Selectable);
			_parentNodeLabel.text = ((SelectedNode == null || SelectedNode.IsRoot) ? "Parent Node: 0 (Root Node)" : $"Parent Node: {SelectedNode.NodeID}");
		}

		private void OnCreateButton()
		{
			SuperBugNode superBugNode = new SuperBugNode();
			superBugNode.NodeID = Definition.Network.Count;
			superBugNode.Parent = ((SelectedNode != null) ? SelectedNode.NodeID : 0);
			superBugNode.ProgressBoost = 0;
			if (SelectedNode == null)
			{
				superBugNode.Parent = 0;
				superBugNode.Position = new Vector2(150f, 0f);
				NetworkView.Network.GetRootNode().Children.Add(superBugNode.NodeID);
			}
			else
			{
				superBugNode.Parent = SelectedNode.NodeID;
				superBugNode.Position = SelectedNode.Position + new Vector2(300f, 0f);
				SelectedNode.Children.Add(superBugNode.NodeID);
			}
			ResearchNodeDefinition researchNodeDefinition = new ResearchNodeDefinition();
			researchNodeDefinition.CompletionsRequired = 1;
			researchNodeDefinition.Icon = _defaultNodeIcon;
			superBugNode.SetDefinition(researchNodeDefinition);
			Definition.Network.Add(superBugNode);
			Refresh();
			OnDefinitionChanged.InvokeSafe();
		}

		private void OnDeleteButton()
		{
			if (SelectedNode != null && !SelectedNode.IsRoot)
			{
				DeleteNode(SelectedNode);
				Refresh();
			}
		}

		private void DeleteNode(CollaborativeNode node)
		{
			int parent = node.Parent;
			ResearchNetwork.Node node2 = NetworkView.Network.GetNode(parent);
			if (node2 != null)
			{
				for (int i = 0; i < node.Children.Count; i++)
				{
					int num = node.Children[i];
					NetworkView.Network.GetNode(num).Parent = parent;
					node2.Children.Add(num);
				}
				Definition.Network.RemoveAt(node.NodeID);
				DecrementAllNodeIDsAbove(node.NodeID);
				OnDefinitionChanged.InvokeSafe();
			}
		}

		private void DecrementAllNodeIDsAbove(int nodeID)
		{
			for (int i = 0; i < Definition.Network.Count; i++)
			{
				SuperBugNode superBugNode = Definition.Network[i];
				if (superBugNode.NodeID > nodeID)
				{
					superBugNode.NodeID--;
				}
				for (int j = 0; j < superBugNode.Children.Count; j++)
				{
					if (superBugNode.Children[j] == nodeID)
					{
						superBugNode.Children.RemoveAt(j);
						break;
					}
				}
				for (int k = 0; k < superBugNode.Children.Count; k++)
				{
					int num = superBugNode.Children[k];
					if (num > nodeID)
					{
						superBugNode.Children[k] = num - 1;
					}
				}
			}
		}
	}
}
