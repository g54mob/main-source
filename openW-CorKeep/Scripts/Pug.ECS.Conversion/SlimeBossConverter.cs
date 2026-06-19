using Pug.Conversion;

public class SlimeBossConverter : SingleAuthoringComponentConverter<SlimeBossAuthoring>
{
	protected override void Convert(SlimeBossAuthoring authoring)
	{
		AddComponentData(new SlimeBossCD
		{
			shouldSetupNewRangeAttack = true
		});
	}
}
