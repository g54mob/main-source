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
				: base(groupId, order)
			{
				Tab = tab;
			}

			protected override void CombineValuesWith(PropertyGroupAttribute other)
			{
				if (other is TabSubGroupAttribute tabSubGroupAttribute)
				{
					if (Tab.TextColor == null)
					{
						Tab.TextColor = tabSubGroupAttribute.Tab.TextColor;
					}
					if (Tab.Icon == SdfIconType.None)
					{
						Tab.Icon = tabSubGroupAttribute.Tab.Icon;
					}
					if (Tab.TabName != null)
					{
						Tab.TabName = tabSubGroupAttribute.Tab.TabName;
					}
				}
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
			: this("_DefaultTabGroup", tab, useFixedHeight, order)
		{
		}

		public TabGroupAttribute(string group, string tab, bool useFixedHeight = false, float order = 0f)
			: base(group, order)
		{
			TabId = tab;
			UseFixedHeight = useFixedHeight;
			Tabs = new List<TabGroupAttribute>();
		}

		public TabGroupAttribute(string group, string tab, SdfIconType icon, bool useFixedHeight = false, float order = 0f)
			: this(group, tab, useFixedHeight, order)
		{
			Icon = icon;
		}

		protected override void CombineValuesWith(PropertyGroupAttribute other)
		{
			TabGroupAttribute tabGroupAttribute = other as TabGroupAttribute;
			if (tabGroupAttribute.TabId != null)
			{
				if (tabGroupAttribute.TabLayouting != TabLayouting.MultiRow)
				{
					TabLayouting = tabGroupAttribute.TabLayouting;
				}
				UseFixedHeight = UseFixedHeight || tabGroupAttribute.UseFixedHeight;
				Paddingless = Paddingless || tabGroupAttribute.Paddingless;
				HideTabGroupIfTabGroupOnlyHasOneTab = HideTabGroupIfTabGroupOnlyHasOneTab || tabGroupAttribute.HideTabGroupIfTabGroupOnlyHasOneTab;
				Tabs.Add(tabGroupAttribute);
			}
		}

		IList<PropertyGroupAttribute> ISubGroupProviderAttribute.GetSubGroupAttributes()
		{
			int num = 0;
			List<PropertyGroupAttribute> list = new List<PropertyGroupAttribute>(Tabs.Count)
			{
				new TabSubGroupAttribute(this, GroupID + "/" + TabId, num++)
			};
			foreach (TabGroupAttribute tab in Tabs)
			{
				list.Add(new TabSubGroupAttribute(tab, GroupID + "/" + tab.TabId, num++));
			}
			return list;
		}

		string ISubGroupProviderAttribute.RepathMemberAttribute(PropertyGroupAttribute attr)
		{
			TabGroupAttribute tabGroupAttribute = (TabGroupAttribute)attr;
			return GroupID + "/" + tabGroupAttribute.TabId;
		}
	}
}
