using Pug.Conversion;

public class SummoningItemConverter : SingleAuthoringComponentConverter<SummoningItemAuthoring>
{
	protected override void Convert(SummoningItemAuthoring authoring)
	{
		EnsureHasBuffer<SummoningItemBuffer>();
		foreach (ObjectID item in authoring.availableBossesToSummon)
		{
			AddToBuffer(new SummoningItemBuffer
			{
				bossToSummon = item
			});
		}
	}
}
