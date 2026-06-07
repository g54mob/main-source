using System;
using System.Collections.Generic;
using ModApi.Common.Events;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Modifiers;
using ModApi.Flight;
using ModApi.Flight.GameView;
using ModApi.Levels;
using ModApi.Planet;
using ModApi.Scripts.State.Validation;
using UnityEngine;

namespace ModApi.Craft
{
	public interface ICraftScript
	{
		ICommandPod ActiveCommandPod { get; }

		AtmosphereSample AtmosphereSample { get; }

		Transform CameraFocus { get; set; }

		Transform CameraTarget { get; }

		Vector3 CameraTargetOffset { set; }

		Transform CenterOfMass { get; }

		IEnumerable<ICommandPod> CommandPods { get; }

		ICraftNode CraftNode { get; }

		CraftData Data { get; }

		Vector3 DragAcceleration { get; }

		ICraftFlightData FlightData { get; }

		Vector3 FramePosition { get; }

		Vector3 FrameVelocity { get; }

		ICraftFuelSources FuelSources { get; }

		Vector3 GravityForce { get; }

		float GravityMagnitude { get; }

		Vector3 GravityNormal { get; }

		Vector3 InertiaTensor { get; }

		InletAir InletAir { get; }

		bool IsPhysicsEnabled { get; }

		float Mass { get; }

		int NumAstronauts { get; }

		IPartHighlighter PartHighlighter { get; }

		ICommandPod PrimaryCommandPod { get; }

		float ReEntryIntensity { get; }

		IReferenceFrame ReferenceFrame { get; }

		IPartScript RootPart { get; }

		Vector3 SurfaceVelocity { get; }

		Transform Transform { get; }

		event ActiveCommandPodChandedHandler ActiveCommandPodChanged;

		event ActiveCommandPodChandedHandler ActiveCommandPodChanging;

		event CraftScriptDelegate CraftSplit;

		event SimpleNotificationDelegate CraftStructureChanged;

		event DockBeginDelegate DockBegin;

		event DockingDelegate DockComplete;

		event CraftScriptDelegate Initialized;

		event Action<Quaternion> NavballRotationUpdate;

		event Action<int, Vector3?> NavballVectorUpdate;

		event PartCollisionDelegate PartCollisionEnter;

		event PartDelegate PartExploded;

		event TimeMultiplierModeChangedDelegate TimeMultiplierModeChanged;

		void AddDebris(ICraftDebris debris);

		Bounds CalculateBounds();

		Bounds CalculateBounds(bool includeDisconnected);

		float CalculateWingArea();

		float CalculateWingLoading();

		void DestroyPart(PartData part, bool destroyPartGameObject);

		double GetAltitudeAboveGroundLevel(Vector3 framePosition);

		float GetAltitudeAboveSeaLevel(Vector3 framePosition);

		float GetAltitudeAboveSeaLevelWithWave(Vector3 framePosition);

		float GetAltitudeAboveSeaLevelWithWave(Vector3 framePosition, float waveOffset);

		float GetColliderSubmergedPercent(Collider collider);

		FuelMonitor GetOrCreateFuelMonitor();

		IPartScript GetPayloadPart(string payloadId, int contractNumber, string payloadTrackingId);

		float GetVerticalVelocity();

		void InitiateDragRecalculation();

		void OnDockBegin(IDockingPortScript portA, IDockingPortScript portB);

		void OnEngineActivationStatusChanged(bool activated);

		void QueueInertiaTensorRecalculation(IBodyScript bodyScript);

		void RaiseCraftSplitEvent();

		void RaiseDesignerCraftStructureChangedEvent();

		void SetActiveCommandPod(ICommandPod commandPod);

		void SetMassChanged();

		void SetPrimaryCommandPod(ICommandPod commandPod, bool saveUndoStep = true);

		void SetStructureChanged();

		void ValidateCraft(ValidationResult result);
	}
}
