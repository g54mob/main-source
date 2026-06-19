using Pug.Conversion;

public class ManaConverter : SingleAuthoringComponentConverter<ManaAuthoring>
{
	protected override void Convert(ManaAuthoring authoring)
	{
		AddComponentData(new ManaCD
		{
			mana = authoring.startMana,
			maxMana = authoring.maxMana
		});
		AddComponentData(new MagicBarrierCD
		{
			barrierHealth = 0
		});
		AddComponentData(new MinionOwnerCD
		{
			minionCount = 0
		});
		EnsureHasBuffer<ManaChangeBuffer>();
	}
}
