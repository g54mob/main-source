using System;

namespace Sirenix.OdinInspector
{
	public sealed class ToggleGroupAttribute : PropertyGroupAttribute
	{
		public string ToggleGroupTitle;

		public bool CollapseOthersOnExpand;

		public string ToggleMemberName => null;

		[Obsolete]
		public string TitleStringMemberName { get; set; }

		public ToggleGroupAttribute(string toggleMemberName, float order = 0f, string groupTitle = null)
			: base(null, 0f)
		{
		}

		public ToggleGroupAttribute(string toggleMemberName, string groupTitle)
			: base(null, 0f)
		{
		}

		[Obsolete]
		public ToggleGroupAttribute(string toggleMemberName, float order, string groupTitle, string titleStringMemberName)
			: base(null, 0f)
		{
		}

		protected override void CombineValuesWith(PropertyGroupAttribute other)
		{
		}
	}
}
