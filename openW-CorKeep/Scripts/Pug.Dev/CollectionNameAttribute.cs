using QFSW.QC;

public sealed class CollectionNameAttribute : SuggestorTagAttribute
{
	private readonly IQcSuggestorTag[] _tags = new IQcSuggestorTag[1] { default(CollectionNameTag) };

	public override IQcSuggestorTag[] GetSuggestorTags()
	{
		return _tags;
	}
}
