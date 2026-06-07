using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Sirenix.OdinInspector
{
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
	[Conditional("UNITY_EDITOR")]
	public sealed class ToggleGroupAttribute : PropertyGroupAttribute
	{
		public string ToggleGroupTitle;

		public bool CollapseOthersOnExpand;

		public string ToggleMemberName => null;

		[Obsolete("Add a $ infront of group title instead, i.e: \"$MyStringMember\".")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public string TitleStringMemberName { get; set; }

		public ToggleGroupAttribute(string toggleMemberName, float order = 0f, string groupTitle = null)
			: base(null, 0f)
		{
		}

		public ToggleGroupAttribute(string toggleMemberName, string groupTitle)
			: base(null, 0f)
		{
		}

		[Obsolete("Use [ToggleGroup(\"toggleMemberName\", groupTitle: \"$titleStringMemberName\")] instead")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public ToggleGroupAttribute(string toggleMemberName, float order, string groupTitle, string titleStringMemberName)
			: base(null, 0f)
		{
		}

		protected override void CombineValuesWith(PropertyGroupAttribute other)
		{
		}
	}
}
