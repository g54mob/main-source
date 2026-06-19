using Pug.Conversion;
using Unity.Mathematics;

public class ClientBiomeSamplesConverter : SingleAuthoringComponentConverter<ClientBiomeSamplesAuthoring>
{
	protected override void Convert(ClientBiomeSamplesAuthoring authoring)
	{
		AddComponentData(new ClientBiomeSamplesCD
		{
			BasePosition = new int2(1, 1) * int.MaxValue
		});
		EnsureHasComponent<OnlyRelevantForConnectionCD>();
	}
}
