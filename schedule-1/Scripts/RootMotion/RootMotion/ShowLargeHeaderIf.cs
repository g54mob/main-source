namespace RootMotion
{
	public class ShowLargeHeaderIf : ShowIfAttribute
	{
		public string name;

		public string color;

		public ShowLargeHeaderIf(string name, string propertyName, object propertyValue = null, object otherPropertyValue = null, bool indent = false, ShowIfMode mode = ShowIfMode.Hidden)
			: base(null, null, null, indent: false, default(ShowIfMode))
		{
		}

		public ShowLargeHeaderIf(string name, string color, string propertyName, object propertyValue = null, object otherPropertyValue = null, bool indent = false, ShowIfMode mode = ShowIfMode.Hidden)
			: base(null, null, null, indent: false, default(ShowIfMode))
		{
		}
	}
}
