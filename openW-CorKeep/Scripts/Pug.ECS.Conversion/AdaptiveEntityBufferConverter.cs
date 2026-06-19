using Pug.Conversion;

public class AdaptiveEntityBufferConverter : SingleAuthoringComponentConverter<AdaptiveEntityBufferAuthoring>
{
	protected override void Convert(AdaptiveEntityBufferAuthoring authoring)
	{
		EnsureHasBuffer<AdaptiveEntityBuffer>();
		foreach (AdaptiveCondition item in authoring.adaptiveCondition)
		{
			AddToBuffer(new AdaptiveEntityBuffer
			{
				adaptiveCondition = item
			});
		}
	}
}
