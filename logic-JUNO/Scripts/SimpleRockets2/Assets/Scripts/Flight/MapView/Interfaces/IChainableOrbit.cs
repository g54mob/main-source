using System.Collections.Generic;
using Assets.Scripts.Flight.MapView.Orbits;
using Assets.Scripts.Flight.MapView.Orbits.Chain.SoiEncounters;
using ModApi.Flight.MapView;
using ModApi.Flight.Sim;

namespace Assets.Scripts.Flight.MapView.Interfaces
{
	public interface IChainableOrbit : ICameraFocusable
	{
		LinkedListNode<IChainableOrbit> ListNode { get; }

		bool Locked { get; }

		string Name { get; }

		MapOrbitInfo OrbitInfo { get; }

		bool PropagateChanges { get; set; }

		bool Selected { get; }

		double? TimeToNode { get; }

		double TrueAnomalyOnPreviousOrbit { get; }

		SoiEncounterNodeScript CheckAndCreateEncounter();

		void CheckForIncompatibleState();

		void OnAfterCameraPositioned();

		void OnDeselected();

		void OnSelected();

		void PerformValidityCheck();

		void SendPreviousNodeOrbitChanged(IOrbit previousOrbit);

		void SetOrbitLineDirty();
	}
}
