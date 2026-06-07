namespace Sirenix.OdinInspector
{
	public class BoxGroupAttribute : PropertyGroupAttribute
	{
		public bool ShowLabel;

		public bool CenterLabel;

		public string LabelText;

		public BoxGroupAttribute(string group, bool showLabel = true, bool centerLabel = false, float order = 0f)
			: base(null, 0f)
		{
		}

		public BoxGroupAttribute()
			: base(null, 0f)
		{
		}

		protected override void CombineValuesWith(PropertyGroupAttribute other)
		{
		}
	}
}
