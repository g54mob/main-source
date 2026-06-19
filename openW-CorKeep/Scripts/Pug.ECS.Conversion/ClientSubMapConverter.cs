using Pug.Conversion;

public class ClientSubMapConverter : SingleAuthoringComponentConverter<ClientSubMapAuthoring>
{
	protected override void Convert(ClientSubMapAuthoring authoring)
	{
		EnsureHasComponent<ClientSubMapLayerCD>();
		EnsureHasComponent<OnlyRelevantForConnectionCD>();
	}
}
