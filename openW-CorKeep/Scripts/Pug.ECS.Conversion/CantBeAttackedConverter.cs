using Pug.Conversion;

public class CantBeAttackedConverter : SingleAuthoringComponentConverter<CantBeAttackedAuthoring>
{
	protected override void Convert(CantBeAttackedAuthoring authoring)
	{
		EnsureHasComponent<CantBeAttackedCD>();
		if (authoring.removeAfterFirstFrame)
		{
			EnsureHasComponent<CantBeAttackedForOneFrameCD>();
		}
	}
}
