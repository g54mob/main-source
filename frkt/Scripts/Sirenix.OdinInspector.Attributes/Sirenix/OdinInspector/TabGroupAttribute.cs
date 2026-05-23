using System;
using System.Collections.Generic;
using System.Diagnostics;
using Sirenix.OdinInspector.Internal;
using UnityEngine;

namespace Sirenix.OdinInspector
{
	[Conditional("UNITY_EDITOR")]
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
	public class TabGroupAttribute : PropertyGroupAttribute, ISubGroupProviderAttribute
	{
		[Conditional("UNITY_EDITOR")]
		public class TabSubGroupAttribute : PropertyGroupAttribute
		{
			public string Name;

			public SdfIconType Icon;

			[ColorResolver]
			public string TextColor;

			public TabSubGroupAttribute(TabGroupAttribute tab, string groupId, float order)
				: base(null, 0f)
			{
			}

			public TabSubGroupAttribute(string groupId, float order, string tabName, SdfIconType tabIcon, string textColor)
				: base(null, 0f)
			{
			}

			protected override void CombineValuesWith(PropertyGroupAttribute other)
			{
			}
		}

		public const string DEFAULT_NAME = "_DefaultTabGroup";

		[HideInInspector]
		public string TabName;

		[HideInInspector]
		public string TabId;

		public bool UseFixedHeight;

		public bool Paddingless;

		[LabelWidth(270f)]
		public bool HideTabGroupIfTabGroupOnlyHasOneTab;

		[HideInInspector]
		public string TextColor;

		[HideInInspector]
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
