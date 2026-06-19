using Pug.Conversion;
using Unity.Entities;

public class CanBeScannedConverter : SingleAuthoringComponentConverter<CanBeScannedAuthoring>
{
	protected override void Convert(CanBeScannedAuthoring authoring)
	{
		AddComponentData(new CanBeScannedCD
		{
			objectData = authoring.objectData
		});
		EnsureHasComponent<DontDisableCD>();
		EnsureHasComponent<Disabled>();
	}
}
