using Pug.Conversion;

public class BossStatueConverter : SingleAuthoringComponentConverter<BossStatueAuthoring>
{
	protected override void Convert(BossStatueAuthoring authoring)
	{
		AddComponentData(new BossStatueCD
		{
			acceptsCrystalID = authoring.acceptsCrystalID,
			doneLoadingUp = authoring.doneLoadingUp,
			hasCrystal = authoring.hasCrystal,
			electricityLoadUpTimer = authoring.electricityLoadUpTimer,
			delayedActivationTimer = authoring.delayedActivationTimer
		});
	}
}
