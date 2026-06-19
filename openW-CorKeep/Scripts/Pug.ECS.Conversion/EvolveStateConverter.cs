using Pug.Conversion;

public class EvolveStateConverter : SingleAuthoringComponentConverter<EvolveStateAuthoring>
{
	protected override void Convert(EvolveStateAuthoring authoring)
	{
		AddComponentData(new EvolveStateCD
		{
			toEvolveInto = authoring.toEvolveInto,
			foodAmountToEvolve = authoring.foodAmountToEvolve
		});
	}
}
