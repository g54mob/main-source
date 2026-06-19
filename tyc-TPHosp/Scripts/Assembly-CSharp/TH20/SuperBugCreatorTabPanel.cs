using System;
using UnityEngine;

namespace TH20
{
	public class SuperBugCreatorTabPanel : MonoBehaviour
	{
		public Action OnDefinitionChanged;

		protected SuperBugDefinition Definition;

		protected SuperBugNetworkView NetworkView;

		protected SuperBugNode SelectedNode;

		protected virtual void Start()
		{
		}

		protected virtual void OnDestroy()
		{
			if (NetworkView != null)
			{
				SuperBugNetworkView networkView = NetworkView;
				networkView.OnNetworkNodeSelected = (Action<CollaborativeNode>)Delegate.Remove(networkView.OnNetworkNodeSelected, new Action<CollaborativeNode>(OnNodeSelected));
			}
		}

		protected virtual void OnEnable()
		{
			Refresh();
		}

		public void Initialise(SuperBugNetworkView networkViewItem)
		{
			NetworkView = networkViewItem;
			SuperBugNetworkView networkView = NetworkView;
			networkView.OnNetworkNodeSelected = (Action<CollaborativeNode>)Delegate.Combine(networkView.OnNetworkNodeSelected, new Action<CollaborativeNode>(OnNodeSelected));
		}

		public void SetDefinition(SuperBugDefinition definition)
		{
			Definition = definition;
		}

		protected virtual void Refresh()
		{
		}

		protected virtual void OnNodeSelected(CollaborativeNode node)
		{
			SelectedNode = (node as SuperBugNode) ?? (NetworkView.Network.GetRootNode() as SuperBugNode);
			Refresh();
		}
	}
}
