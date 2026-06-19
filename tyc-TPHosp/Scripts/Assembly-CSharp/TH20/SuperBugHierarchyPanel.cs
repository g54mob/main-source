using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class SuperBugHierarchyPanel : SuperBugCreatorTabPanel
	{
		[SerializeField]
		private TMP_Text _parentText;

		[SerializeField]
		private TMP_Text _directionText;

		[SerializeField]
		private ButtonAnimator _reparentButton;

		[SerializeField]
		private Image _selectedParentIcon;

		private CollaborativeNode _selectedParentNode;

		private bool _reparentSelected;

		protected override void Start()
		{
			base.Start();
			_reparentButton.Button.onPrimaryDown.AddListener(OnReparentPressed);
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			_reparentButton.Button.onPrimaryDown.RemoveListener(OnReparentPressed);
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			_selectedParentNode = null;
			_reparentSelected = false;
		}

		protected override void Refresh()
		{
			_parentText.text = ((_selectedParentNode != null) ? $"Parent Node: {_selectedParentNode.NodeID}" : "Parent Node: 0 (Root)");
			_selectedParentIcon.overrideSprite = _selectedParentNode?.Definition?.Icon;
			_directionText.text = (_reparentSelected ? "Selected the node you to re-parent to the selected Node" : string.Empty);
			_reparentButton.CurrentState = (_reparentSelected ? ButtonAnimator.State.Selected : ButtonAnimator.State.Selectable);
		}

		private void OnReparentPressed()
		{
			_reparentSelected = !_reparentSelected;
			Refresh();
		}

		protected override void OnNodeSelected(CollaborativeNode node)
		{
			if (_reparentSelected)
			{
				CollaborativeNode collaborativeNode = _selectedParentNode ?? (NetworkView.Network.GetRootNode() as SuperBugNode);
				if (collaborativeNode == null)
				{
					_reparentSelected = false;
					_selectedParentNode = null;
					Refresh();
					return;
				}
				int parent = node.Parent;
				if (parent < 0)
				{
					_reparentSelected = false;
					_selectedParentNode = null;
					Refresh();
					return;
				}
				UnparentChildNode(NetworkView.Network.GetNode(parent), node);
				SetParentNode(collaborativeNode, node);
				OnDefinitionChanged.InvokeSafe();
				_reparentSelected = false;
				_selectedParentNode = null;
			}
			else
			{
				_selectedParentNode = (node as SuperBugNode) ?? (NetworkView.Network.GetRootNode() as SuperBugNode);
			}
			Refresh();
		}

		private void UnparentChildNode(ResearchNetwork.Node parentNode, ResearchNetwork.Node childNode)
		{
			if (parentNode == null || childNode == null)
			{
				return;
			}
			for (int i = 0; i < parentNode.Children.Count; i++)
			{
				if (parentNode.Children[i] == childNode.NodeID)
				{
					parentNode.Children.RemoveAt(i);
					break;
				}
			}
		}

		private void SetParentNode(ResearchNetwork.Node parentNode, ResearchNetwork.Node childNode)
		{
			if (parentNode != null && childNode != null)
			{
				parentNode.Children.Add(childNode.NodeID);
				childNode.Parent = parentNode.NodeID;
			}
		}
	}
}
