using Sirenix.OdinInspector;

namespace KitchenData.EditingGUI
{
	public class GroupAttribute : FoldoutGroupAttribute
	{
		public float PixelsPaddingTop = 8f;

		public float PixelsPaddingBottom = 8f;

		public float PixelsPaddingBetween = 2f;

		public GroupAttribute(string group_name)
			: base(group_name, expanded: true)
		{
		}

		public GroupAttribute(string group_name, float order)
			: base(group_name, expanded: true, order)
		{
		}

		public GroupAttribute(string group_name, bool expanded, float order = 0f)
			: base(group_name, expanded, order)
		{
		}
	}
}
