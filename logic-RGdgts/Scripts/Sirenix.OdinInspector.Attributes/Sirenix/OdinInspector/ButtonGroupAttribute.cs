namespace Sirenix.OdinInspector
{
	[ShowInInspector]
	[IncludeMyAttributes]
	public class ButtonGroupAttribute : PropertyGroupAttribute
	{
		public ButtonGroupAttribute(string group = "_DefaultGroup", float order = 0f)
			: base(null, 0f)
		{
		}
	}
}
