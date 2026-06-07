using System;
using System.Collections.Generic;
using System.Diagnostics;
using Sirenix.OdinInspector.Internal;

namespace Sirenix.OdinInspector
{
	[Conditional("UNITY_EDITOR")]
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
	public class TabGroupAttribute : PropertyGroupAttribute, ISubGroupProviderAttribute
	{
		[Conditional("UNITY_EDITOR")]
		public class TabSubGroupAttribute : PropertyGroupAttribute
		{
			public TabGroupAttribute Tab;

			public TabSubGroupAttribute(TabGroupAttribute tab, string groupId, float order)
				: base(null, 0f)
			{
			}

			protected override void CombineValuesWith(PropertyGroupAttribute other)
			{
			}
		}

		public const string DEFAULT_NAME = "_DefaultTabGroup";

		public string TabName;

		public string TabId;

		public bool UseFixedHeight;

		public bool Paddingless;

		public bool HideTabGroupIfTabGroupOnlyHasOneTab;

		public string TextColor;

		public SdfIconType Icon;

		public TabLayouting TabLayouting;

		public List<TabGroupAttribute> Tabs;

		public TabGroupAttribute(string tab, bool useFixedHeight = false, float order = 0f)
			: base(null, 0f)
		{
		}

		public TabGroupAttribute(string group, string tab, bool useFixedHeight = false, float order = 0f)
			: base(null, 0f)
		{
		}

		public TabGroupAttribute(string group, string tab, SdfIconType icon, bool useFixedHeight = false, float order = 0f)
			: base(null, 0f)
		{
		}

		protected override void CombineValuesWith(PropertyGroupAttribute other)
		{
		}

		IList<PropertyGroupAttribute> ISubGroupProviderAttribute.GetSubGroupAttributes()
		{
			return null;
		}

		string ISubGroupProviderAttribute.RepathMemberAttribute(PropertyGroupAttribute attr)
		{
			return null;
		}
	}
}
