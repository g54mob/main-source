using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Sirenix.OdinInspector
{
	[Conditional("UNITY_EDITOR")]
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
	public sealed class ToggleGroupAttribute : PropertyGroupAttribute
	{
		public string ToggleGroupTitle;

		public bool CollapseOthersOnExpand;

		public string ToggleMemberName => null;

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Add a $ infront of group title instead, i.e: \"$MyStringMember\".")]
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
