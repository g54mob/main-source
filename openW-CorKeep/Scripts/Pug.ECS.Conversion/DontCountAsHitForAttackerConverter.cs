using Pug.Conversion;

public class DontCountAsHitForAttackerConverter : SingleAuthoringComponentConverter<DontCountAsHitForAttackerAuthoring>
{
	protected override void Convert(DontCountAsHitForAttackerAuthoring forAttackerAuthoring)
	{
		EnsureHasComponent<DontCountAsHitForAttackerCD>();
	}
}
