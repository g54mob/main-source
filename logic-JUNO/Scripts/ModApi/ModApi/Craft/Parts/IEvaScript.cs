using ModApi.Flight.GameView;

namespace ModApi.Craft.Parts
{
	public interface IEvaScript : ICameraTarget
	{
		bool ActiveWhileInCrewCompartment { get; }

		ICommandPod CrewCompartmentCommandPod { get; }

		bool EvaActive { get; }

		EvaControlSchemeType EvaControlScheme { get; }

		bool GrapplingHookEnabled { get; }

		bool InAtmosphere { get; }

		bool IsAtWaterSurface { get; }

		bool IsFpsActive { get; }

		bool IsGrounded { get; }

		bool IsGroundedOnRigidBody { get; }

		bool IsGroundedTerrain { get; }

		bool IsInWater { get; }

		bool IsPlayerCraft { get; }

		bool IsSwimmingEnabled { get; }

		bool IsWalking { get; }

		bool TetherAdjustLengthEnabled { get; }

		bool UnloadingFromCrewCompartmentInProgress { get; }

		event ActiveWhileInCrewCompartmentChangedHandler ActiveWhileInCrewCompartmentChanged;
	}
}
