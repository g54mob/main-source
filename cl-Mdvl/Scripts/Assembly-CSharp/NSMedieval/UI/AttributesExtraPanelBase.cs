using System.Collections.Generic;
using System.Linq;
using NSEipix;
using NSMedieval.StatsSystem;
using NSMedieval.UI.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public abstract class AttributesExtraPanelBase : SelectionExtraPanelBase
	{
		[SerializeField]
		private LayoutGroupView statGroup;

		[SerializeField]
		private RectTransform rect;

		private readonly List<AttributeLayoutItemView> attributes = new List<AttributeLayoutItemView>();

		protected override void SetupTabPanel()
		{
			IEnumerable<AttributeLocalized> enumerable = GetAttributes();
			int num = 0;
			AttributeGroup[] attributeGroups = EnumValues.AttributeGroups;
			foreach (AttributeGroup group in attributeGroups)
			{
				if (group == AttributeGroup.None || !enumerable.Any((AttributeLocalized attLoc) => attLoc.Group.Equals(group)))
				{
					continue;
				}
				attributes.GetAt(statGroup, num).SetGroup(AttributeUtils.GetLocalizedAttributeGroup(group), num);
				num++;
				foreach (AttributeLocalized item in enumerable)
				{
					if (item.Group == group && !item.LocalizedName.Equals(string.Empty))
					{
						attributes.GetAt(statGroup, num++).SetStatData(item, base.CreatureBase, num);
					}
				}
			}
			attributes.SetActiveFromIndex(num, active: false);
			LayoutRebuilder.ForceRebuildLayoutImmediate(rect);
		}

		protected override void UpdateTabPanel()
		{
			SetupTabPanel();
		}

		protected abstract IEnumerable<AttributeLocalized> GetAttributes();
	}
}
