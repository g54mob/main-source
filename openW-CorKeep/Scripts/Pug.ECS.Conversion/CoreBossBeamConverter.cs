using Pug.Conversion;

public class CoreBossBeamConverter : SingleAuthoringComponentConverter<CoreBossBeamAuthoring>
{
	protected override void Convert(CoreBossBeamAuthoring authoring)
	{
		AddComponentData(new CoreBossBeamCD
		{
			startDuration = authoring.startDuration,
			loopDuration = authoring.loopDuration,
			endDuration = authoring.endDuration,
			hiddenEndDuration = authoring.hiddenEndDuration,
			internalState = authoring.internalState,
			timer = authoring.timer,
			dealDamageTimer = authoring.dealDamageTimer
		});
		EnsureHasBuffer<CoreBossBeamMovementInstructionBuffer>();
	}
}
