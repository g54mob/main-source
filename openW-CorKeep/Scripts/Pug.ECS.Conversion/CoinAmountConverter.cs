using Pug.Conversion;

public class CoinAmountConverter : SingleAuthoringComponentConverter<CoinAmountAuthoring>
{
	protected override void Convert(CoinAmountAuthoring authoring)
	{
		AddComponentData(new CoinAmountCD
		{
			Value = authoring.Value
		});
	}
}
