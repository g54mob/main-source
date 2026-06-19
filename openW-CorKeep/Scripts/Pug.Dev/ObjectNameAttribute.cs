using QFSW.QC;

public sealed class ObjectNameAttribute : SuggestorTagAttribute
{
	private readonly IQcSuggestorTag[] _tags = new IQcSuggestorTag[1] { default(ObjectNameSuggestorTag) };

	public override IQcSuggestorTag[] GetSuggestorTags()
	{
		return _tags;
	}
}
