using System;
using System.Collections.Generic;
using Assets.Scripts.Flight.MapView.Interfaces;
using ModApi.Flight.MapView;

namespace Assets.Scripts.Flight.MapView.Orbits.Chain.Interfaces
{
	public interface IChainNodeSelection : IDisposable
	{
		bool HasSelection { get; }

		IChainableOrbit Selected { get; }

		event ChainNodeSelectionHandler ChainNodeSelectionChanged;

		void SelectNext(CameraTransitionSpeed transitionSpeed, bool repositionCamDuringTransition);

		void SelectPrevious(CameraTransitionSpeed transitionSpeed, bool repositionCamDuringTransition);

		void SetSelected(LinkedListNode<IChainableOrbit> chainNode, CameraTransitionSpeed transitionSpeed, bool repositionCamDuringTransition);

		void SetSelected(LinkedListNode<IChainableOrbit> chainNode);

		void ToggleSelected();
	}
}
