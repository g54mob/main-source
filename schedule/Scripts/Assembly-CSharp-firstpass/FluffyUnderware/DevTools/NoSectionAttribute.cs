namespace FluffyUnderware.DevTools
{
	public class NoSectionAttribute : SectionAttribute
	{
		public NoSectionAttribute()
			: base(null, expanded: false, fix: false, 0)
		{
		}
	}
}
