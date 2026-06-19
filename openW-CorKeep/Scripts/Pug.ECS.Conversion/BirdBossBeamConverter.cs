using Pug.Conversion;

public class BirdBossBeamConverter : SingleAuthoringComponentConverter<BirdBossBeamAuthoring>
{
	protected override void Convert(BirdBossBeamAuthoring authoring)
	{
		AddComponentData(new BirdBossBeamCD
		{
			startDuration = authoring.startDuration,
			loopDuration = authoring.loopDuration,
			endDuration = authoring.endDuration,
			hiddenEndDuration = authoring.hiddenEndDuration,
			startDamageDelay = authoring.startDamageDelay,
			moveDirection = authoring.moveDirection,
			moveSpeed = authoring.moveSpeed,
			moveSideWays = authoring.moveSideWays,
			internalState = authoring.internalState,
			timer = authoring.timer,
			dealDamageTimer = authoring.dealDamageTimer
		});
	}
}
