using System.Reflection;
using ModApi.Craft;
using ModApi.Flight.GameView;
using ModApi.Flight.Sim;
using UnityEngine;

namespace Assets.Scripts.Flight.Sim
{
	[Obfuscation(Exclude = true)]
	public abstract class ShipNode : OrbitNode, IGameViewObject, ICameraTarget
	{
		public double Altitude { get; protected set; }

		public abstract Transform CameraTarget { get; }

		public abstract Vector3 CameraTargetPlanetPosition { get; }

		public bool Enabled { get; set; } = true;

		public abstract Vector3 FramePosition { get; }

		public abstract Vector3 FrameVelocity { get; }

		public abstract GameObject GameObject { get; }

		public string GameViewName => Name;

		public override IGameViewObject GameViewObject => this;

		public virtual bool IsLoadedInGameView { get; }

		public virtual bool IsPhysicsEnabled => false;

		public virtual bool IsPlayer { get; }

		IOrbitNode ICameraTarget.OrbitNode => this;

		public abstract Vector3 TargetRotation { get; }

		public abstract event GameViewObjectHandler LoadedIntoGameView;

		public abstract event GameViewObjectHandler UnloadedFromGameView;

		public abstract event GameViewObjectHandler UnloadingFromGameView;

		Transform IGameViewObject.LoadIntoGameView(IGameView gameView)
		{
			return OnLoadIntoGameView(gameView);
		}

		void IGameViewObject.OnReferenceFrameRecentered(IReferenceFrame referenceFrame, Vector3d positionDelta, Vector3d velocityDelta)
		{
			RecalculateFrameState(referenceFrame);
		}

		public abstract void RecalculateFrameState(IReferenceFrame referenceFrame);

		public abstract void SetIsPlayer(bool isPlayer, ICraftNode other);

		public abstract void SetPhysicsEnabled(bool enabled, PhysicsChangeReason reason);

		void IGameViewObject.UnloadFromGameView(bool flightEnd)
		{
			OnUnloadFromGameView(flightEnd);
		}

		public void UpdateLevelOfDetail(double distanceSquared)
		{
		}

		protected abstract Transform OnLoadIntoGameView(IGameView gameView);

		protected abstract void OnUnloadFromGameView(bool flightEnd);
	}
}
