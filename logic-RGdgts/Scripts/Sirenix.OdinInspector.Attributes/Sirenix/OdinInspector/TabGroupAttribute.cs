using System.Collections.Generic;
using Sirenix.OdinInspector.Internal;

namespace Sirenix.OdinInspector
{
	public class TabGroupAttribute : PropertyGroupAttribute, ISubGroupProviderAttribute
	{
		public class TabSubGroupAttribute : PropertyGroupAttribute
		{
			public TabSubGroupAttribute(string groupId, float order)
				: base(null, 0f)
			{
			}
		}

		public const string DEFAULT_NAME = "_DefaultTabGroup";

		public string TabName;

		public bool UseFixedHeight;

		public bool Paddingless;

		public bool HideTabGroupIfTabGroupOnlyHasOneTab;

		public List<string> Tabs { get; private set; }

		public TabGroupAttribute(string tab, bool useFixedHeight = false, float order = 0f)
			: base(null, 0f)
		{
		}

		public TabGroupAttribute(string group, string tab, bool useFixedHeight = false, float order = 0f)
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
