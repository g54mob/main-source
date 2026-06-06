using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PajamaLlama.SurvivalGuide
{
	internal class DrifterAttributePage : Page
	{
		public DrifterAttributes.Attribute Attribute { get; private set; }

		public DrifterAttributes Attributes { get; private set; }

		private DrifterAttributePage(DrifterAttributes.Attribute attribute, DrifterAttributes attributes)
			: base(attribute.SurvivalGuideLink, attribute.Name, null)
		{
			Attribute = attribute;
			Attributes = attributes;
		}

		internal static List<Page> Generate(DrifterAttributes drifterattributes, CategoryPage category)
		{
			List<Page> list = new List<Page>();
			foreach (DrifterAttributes.AttributeType item in from e in DrifterAttributes.ReturnAttributeTypes()
				orderby e.ToString()
				select e)
			{
				if (item != DrifterAttributes.AttributeType.None)
				{
					DrifterAttributes.Attribute attribute = drifterattributes.ReturnAttribute(item);
					if (attribute.ShowInRerollDropdown)
					{
						Page page = new DrifterAttributePage(attribute, drifterattributes);
						list.Add(page);
						category.AddEntry(page);
					}
				}
			}
			return list;
		}

		protected override List<WidgetContainer> GenerateWidgets(SurvivalGuideProperties survivalGuideProperties)
		{
			if (!survivalGuideProperties.TryReturnWidgetContainerStyle("vertical", out var style) || !survivalGuideProperties.TryReturnStyle("text-paragraph", out var widget))
			{
				Debug.LogException(new NotImplementedException());
				return new List<WidgetContainer>();
			}
			string text = Attribute.Description;
			text = text + "\n\n" + Attribute.ModifierTooltip;
			text = DrifterAttributes.ReplaceModifiers(text, Attributes, Attribute.Type, 1);
			return new List<WidgetContainer>
			{
				new WidgetContainer(style, new List<Tuple<BaseWidget, BaseWidget.BaseParameters>>
				{
					new Tuple<BaseWidget, BaseWidget.BaseParameters>(widget, new TextWidget.Parameters(text))
				})
			};
		}
	}
}
