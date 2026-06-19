using Pug.Conversion;

public class ScannerConverter : SingleAuthoringComponentConverter<ScannerAuthoring>
{
	protected override void Convert(ScannerAuthoring authoring)
	{
		AddComponentData(new ScannerCD
		{
			objectToScan = authoring.objectToScan,
			summonInsteadOfScan = authoring.summonInsteadOfScan,
			onlyInBiome = authoring.onlyInBiome
		});
	}
}
