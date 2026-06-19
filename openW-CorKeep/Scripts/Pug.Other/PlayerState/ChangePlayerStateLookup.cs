using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;

namespace PlayerState
{
	public struct ChangePlayerStateLookup
	{
		[ReadOnly]
		public ComponentLookup<MeleeWeaponCD> meleeWeaponLookup;

		[ReadOnly]
		public ComponentLookup<OffHandCD> offHandLookup;

		[ReadOnly]
		public ComponentLookup<CooldownCD> cooldownLookup;

		[ReadOnly]
		public ComponentLookup<CastItemCD> castItemLookup;

		[ReadOnly]
		public ComponentLookup<ParchmentRecipeCD> parchmentRecipeLookup;

		[ReadOnly]
		public ComponentLookup<ScannerCD> scannerLookup;

		[ReadOnly]
		public BufferLookup<SummarizedConditionsBuffer> summarizedConditionsBufferLookup;

		[ReadOnly]
		public ComponentLookup<SittableCD> sittableLookup;

		[ReadOnly]
		public ComponentLookup<Simulate> simulateLookup;

		[ReadOnly]
		public ComponentLookup<DirectionCD> directionLookup;

		[ReadOnly]
		public ComponentLookup<TriggerEffectCD> triggerEffectLookup;

		[ReadOnly]
		public ComponentLookup<TileCD> tileLookup;

		public ComponentLookup<DisablePhysicsCD> disablePhysicsLookup;

		public ComponentLookup<ControlledByOtherEntityCD> controlledByOtherEntityLookup;

		public ComponentLookup<LocalTransform> localTransformLookup;

		[ReadOnly]
		public ComponentLookup<WaterSourceCD> waterSourceLookup;

		[ReadOnly]
		public ComponentLookup<PlayerGhost> playerGhostLookup;

		[ReadOnly]
		public ComponentLookup<VehicleCD> vehicleLookup;

		[ReadOnly]
		public ComponentLookup<BoatCD> boatLookup;

		[ReadOnly]
		public ComponentLookup<MinecartCD> minecartLookup;

		[ReadOnly]
		public ComponentLookup<MoveFreelyWeaponCD> moveFreelyWeaponLookup;
	}
}
