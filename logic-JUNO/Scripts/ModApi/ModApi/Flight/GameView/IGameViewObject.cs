using UnityEngine;

namespace ModApi.Flight.GameView
{
	public interface IGameViewObject : ICameraTarget
	{
		bool Enabled { get; set; }

		Vector3 FramePosition { get; }

		GameObject GameObject { get; }

		string GameViewName { get; }

		bool IsLoadedInGameView { get; }

		bool IsPhysicsEnabled { get; }

		event GameViewObjectHandler LoadedIntoGameView;

		event GameViewObjectHandler UnloadedFromGameView;

		event GameViewObjectHandler UnloadingFromGameView;

		Transform LoadIntoGameView(IGameView gameView);

		void OnReferenceFrameRecentered(IReferenceFrame referenceFrame, Vector3d positionDelta, Vector3d velocityDelta);

		void RecalculateFrameState(IReferenceFrame referenceFrame);

		void SetPhysicsEnabled(bool enabled, PhysicsChangeReason reason);

		void UnloadFromGameView(bool flightEnd);

		void UpdateLevelOfDetail(double distanceSquared);
	}
}
