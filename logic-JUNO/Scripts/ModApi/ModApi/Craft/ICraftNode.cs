using System.Collections.Generic;
using ModApi.Flight;
using ModApi.Flight.GameView;
using ModApi.Flight.Sim;
using ModApi.State;
using UnityEngine;

namespace ModApi.Craft
{
	public interface ICraftNode : IGameViewObject, ICameraTarget, IOrbitNode, INode
	{
		bool AllowPlayerControl { get; set; }

		double Altitude { get; }

		double AltitudeAboveTerrain { get; }

		double AltitudeAgl { get; }

		bool CanWarp { get; }

		string ContractTrackingId { get; set; }

		CraftControls Controls { get; }

		float CraftMass { get; }

		int CraftPartCount { get; }

		ICraftScript CraftScript { get; }

		bool DestroyOnExitFlightScene { get; set; }

		Vector3d? GroundedSurfacePosition { get; }

		Quaterniond? GroundedSurfaceRotation { get; }

		Vector3d? GroundedSurfaceVelocity { get; }

		bool HasCommandPod { get; }

		Quaterniond Heading { get; }

		bool InContactWithPlanet { get; }

		bool InContactWithWater { get; }

		IReadOnlyCollection<InitialCraftNodeData> InitialCraftNodeData { get; }

		List<int> InitialCraftNodeIds { get; }

		bool IsPlayer { get; }

		Vector2d LatLon { get; }

		int NodeId { get; }

		IReferenceFrame ReferenceFrame { get; }

		Vector3d SurfaceVelocity { get; }

		double WaterDepth { get; }

		event CraftNodeMergeDelegate CraftNodeMerged;

		event PhysicsChangedHandler PhysicsDisabled;

		event PhysicsChangedHandler PhysicsEnabled;

		event TimeMultiplierModeChangedDelegate TimeMultiplierModeChanged;

		void ClearUnusedInitialCraftNodeData();

		void CopyInitialCraftNodeData(ICraftNode source);

		InitialCraftNodeData GetInitialCraftNodeData(int craftNodeId);

		void SetName(string name);
	}
}
