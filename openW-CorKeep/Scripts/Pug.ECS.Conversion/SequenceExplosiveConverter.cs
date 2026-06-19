using Pug.Conversion;
using Unity.Mathematics;

public class SequenceExplosiveConverter : SingleAuthoringComponentConverter<SequenceExplosiveAuthoring>
{
	protected override void Convert(SequenceExplosiveAuthoring authoring)
	{
		AddComponentData(new SequenceExplosiveCD
		{
			sequenceExplosiveData = CreateAndAddSimpleBlobAsset(new SequenceExplosiveBlobData
			{
				beforeAnimationInitialDelay = authoring.initialDelay,
				animationInitialDelay = authoring.animationInitialDelay,
				triggerOnDeath = authoring.triggerOnDeath,
				useDirection = authoring.useDirection
			}),
			sequenceChargesData = CreateAndAddSimpleBlobArrayAsset(authoring.chargeSettings, delegate(SequenceExplosiveAuthoring.SequenceCharge x)
			{
				SequenceExplosiveAuthoring.SequenceCharge sequenceCharge = (authoring.useFirstItemSettingForAllCharges ? authoring.chargeSettings[0] : x);
				return new SequenceChargeBlobData
				{
					explosionID = sequenceCharge.explosionID,
					explosionVariation = sequenceCharge.variation,
					delayFromPrevious = sequenceCharge.delayFromPrevious,
					spreadFromPreviousDistance = sequenceCharge.spreadFromPreviousDistance,
					amountToSpawn = sequenceCharge.amountToSpawn,
					directionType = sequenceCharge.directionType,
					offsetRadians = math.radians(sequenceCharge.offsetDegrees)
				};
			})
		});
		EnsureHasComponent<HasExplodedCD>(componentIsEnabled: false);
		EnsureHasComponent<OwnerReferenceCD>();
		if (authoring.consumesConditionForMaxExplosions != ConditionID.None)
		{
			SetProperty("SequenceExplosion_ConsumeConditionForMaxExplosions", authoring.consumesConditionForMaxExplosions);
		}
	}
}
