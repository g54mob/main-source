using QFSW.QC;

public sealed class LoadoutNameAttribute : SuggestorTagAttribute
{
	private readonly IQcSuggestorTag[] _tags = new IQcSuggestorTag[1] { default(LoadoutNameTag) };

	public override IQcSuggestorTag[] GetSuggestorTags()
	{
		return _tags;
	}
}
