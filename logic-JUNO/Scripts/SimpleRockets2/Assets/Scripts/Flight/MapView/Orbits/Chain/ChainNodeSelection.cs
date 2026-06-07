using System;
using System.Collections.Generic;
using Assets.Scripts.Flight.MapView.Interfaces;
using Assets.Scripts.Flight.MapView.Interfaces.Contexts;
using Assets.Scripts.Flight.MapView.Orbits.Chain.Interfaces;
using Assets.Scripts.Flight.MapView.Orbits.Chain.ManeuverNodes;
using ModApi.Flight.MapView;
using ModApi.Flight.Sim;
using ModApi.Ioc;

namespace Assets.Scripts.Flight.MapView.Orbits.Chain
{
	public class ChainNodeSelection : IChainNodeSelection, IDisposable
	{
		private ICurrentCameraTarget _cameraTarget;

		private IChainNodeList _chainNodeList;

		private LinkedListNode<IChainableOrbit> _lastSelectedNode;

		private IMapView _mapView;

		private LinkedListNode<IChainableOrbit> _selectedNode;

		public bool HasSelection => Selected != null;

		public IChainableOrbit Selected => _selectedNode?.Value;

		public event ChainNodeSelectionHandler ChainNodeSelectionChanged;

		public ChainNodeSelection(IIocContainer ioc, ICraftContext craftContext)
		{
			ioc.Register((IChainNodeSelection)this, (IContext)craftContext);
			_chainNodeList = ioc.Resolve<IChainNodeList>(craftContext);
			_chainNodeList.RemovingNode += OnRemovingNode;
			_chainNodeList.NodeAdded += OnNodeAdded;
			IMapViewContext context = ioc.Resolve<IMapViewContext>(craftContext);
			_cameraTarget = ioc.Resolve<ICurrentCameraTarget>(context);
			_mapView = ioc.Resolve<IMapView>(context);
		}

		public virtual void Dispose()
		{
			if (_chainNodeList != null)
			{
				_chainNodeList.NodeAdded -= OnNodeAdded;
				_chainNodeList.RemovingNode -= OnRemovingNode;
			}
			this.ChainNodeSelectionChanged = null;
		}

		public void SelectNext(CameraTransitionSpeed transitionSpeed, bool repositionCamDuringTransition)
		{
			LinkedListNode<IChainableOrbit> linkedListNode = null;
			linkedListNode = ((Selected != null) ? Selected.ListNode.Next : ((_lastSelectedNode == null) ? _chainNodeList.ChainNodes.First : _lastSelectedNode.Next));
			if (linkedListNode != null)
			{
				SetSelected(linkedListNode, transitionSpeed, repositionCamDuringTransition);
			}
		}

		public void SelectPrevious(CameraTransitionSpeed transitionSpeed, bool repositionCamDuringTransition)
		{
			LinkedListNode<IChainableOrbit> linkedListNode = null;
			linkedListNode = ((Selected != null) ? Selected.ListNode.Previous : ((_lastSelectedNode == null) ? _chainNodeList.ChainNodes.First : _lastSelectedNode.Previous));
			if (linkedListNode != null)
			{
				SetSelected(linkedListNode, transitionSpeed, repositionCamDuringTransition);
			}
		}

		public void SetSelected(LinkedListNode<IChainableOrbit> chainNode)
		{
			SetSelected(chainNode, null, repositionCamDuringTransition: true);
		}

		public void SetSelected(LinkedListNode<IChainableOrbit> chainNode, CameraTransitionSpeed transitionSpeed, bool repositionCamDuringTransition)
		{
			SetSelected(chainNode, (CameraTransitionSpeed?)transitionSpeed, repositionCamDuringTransition);
		}

		public void ToggleSelected()
		{
			if (!HasSelection)
			{
				SelectNode(_lastSelectedNode);
			}
			else
			{
				DeselectCurrentNode();
			}
		}

		private void DeselectCurrentNode()
		{
			_selectedNode?.Value.OnDeselected();
			_selectedNode = null;
		}

		private void OnNodeAdded(IChainNodeList source, LinkedListNode<IChainableOrbit> node, NodeListChangeCategory category)
		{
			if (node.Value is ManeuverNodeScript && category == NodeListChangeCategory.Normal)
			{
				SetSelected(node, CameraTransitionSpeed.Medium, repositionCamDuringTransition: false);
			}
		}

		private void OnRemovingNode(IChainNodeList source, LinkedListNode<IChainableOrbit> node, NodeListChangeCategory category)
		{
			if (Selected != node.Value || !(node.Value is OrbitChainNodeScript))
			{
				return;
			}
			IPlanetNode parent = node.Value.OrbitInfo.OrbitNode.Parent;
			LinkedListNode<IChainableOrbit> chainNode = null;
			if (node.Next != null && MapUtils.SamePlanet(parent, node.Next.Value.OrbitInfo.OrbitNode.Parent))
			{
				chainNode = node.Next;
			}
			else
			{
				for (LinkedListNode<IChainableOrbit> previous = node.Previous; previous != null; previous = previous.Previous)
				{
					if (MapUtils.SamePlanet(parent, previous.Value.OrbitInfo.OrbitNode.Parent))
					{
						chainNode = previous;
						break;
					}
				}
			}
			SetSelected(chainNode, CameraTransitionSpeed.Default, repositionCamDuringTransition: true);
		}

		private void SelectNode(LinkedListNode<IChainableOrbit> chainNode)
		{
			if (chainNode != null)
			{
				_lastSelectedNode = chainNode;
			}
			else
			{
				chainNode = _chainNodeList.ChainNodes.First;
			}
			_selectedNode = chainNode;
			_selectedNode?.Value.OnSelected();
		}

		private void SetSelected(LinkedListNode<IChainableOrbit> chainNode, CameraTransitionSpeed? transitionSpeed, bool repositionCamDuringTransition)
		{
			DeselectCurrentNode();
			SelectNode(chainNode);
			this.ChainNodeSelectionChanged?.Invoke(chainNode);
			if (transitionSpeed.HasValue && chainNode != null)
			{
				_mapView.SetInspectorFocus(chainNode.Value, transitionSpeed.Value, repositionCamDuringTransition);
			}
		}
	}
}
