using QFSW.QC;

public sealed class CustomSceneNameAttribute : SuggestorTagAttribute
{
	private readonly IQcSuggestorTag[] _tags = new IQcSuggestorTag[1] { default(CustomSceneNameTag) };

	public override IQcSuggestorTag[] GetSuggestorTags()
	{
		return _tags;
	}
}
