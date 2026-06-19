namespace IdSharp.Tagging.ID3v2
{
	public interface ITagRestrictions
	{
		TagSizeRestriction TagSizeRestriction { get; set; }

		TextEncodingRestriction TextEncodingRestriction { get; set; }

		TextFieldsSizeRestriction TextFieldsSizeRestriction { get; set; }

		ImageEncodingRestriction ImageEncodingRestriction { get; set; }

		ImageSizeRestriction ImageSizeRestriction { get; set; }
	}
}
