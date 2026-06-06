using System;
using System.Collections.Generic;
using UnityEngine;

namespace PajamaLlama.SurvivalGuide
{
	internal class DrifterBackgroundPage : Page
	{
		public DrifterAttributesEffect Background { get; private set; }

		private DrifterBackgroundPage(DrifterAttributesEffect background)
			: base(background.SurvivalGuideIdentifier, background.Name, background.IconProperties.Sprite)
		{
			Background = background;
		}

		internal static List<Page> Generate(IReadOnlyList<DrifterAttributesEffect> backgrounds, CategoryPage category)
		{
			List<Page> list = new List<Page>(backgrounds.Count);
			foreach (DrifterAttributesEffect background in backgrounds)
			{
				Page page = new DrifterBackgroundPage(background);
				category.AddEntry(page);
				list.Add(page);
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
			List<WidgetContainer> list = new List<WidgetContainer>();
			list.Add(new WidgetContainer(style, new List<Tuple<BaseWidget, BaseWidget.BaseParameters>>
			{
				new Tuple<BaseWidget, BaseWidget.BaseParameters>(widget, new TextWidget.Parameters(Background.Description))
			}));
			list.AddRange(ReturnBackgroundAttributes(survivalGuideProperties, Background));
			return list;
		}

		private List<WidgetContainer> ReturnBackgroundAttributes(SurvivalGuideProperties survivalGuideProperties, DrifterAttributesEffect background)
		{
			if (!survivalGuideProperties.TryReturnWidgetContainerStyle("vertical", out var style) || !survivalGuideProperties.TryReturnStyle("text-subtitle-underlined", out var widget) || !survivalGuideProperties.TryReturnStyle("table-naked-left", out var widget2))
			{
				Debug.LogException(new NotImplementedException());
				return new List<WidgetContainer>();
			}
			List<List<TableWidget.Parameters.Entry>> rows = new List<List<TableWidget.Parameters.Entry>>();
			List<TableWidget.Parameters.Entry> list = new List<TableWidget.Parameters.Entry>();
			DrifterAttributeModifier[] modifiers = background.Modifiers;
			foreach (DrifterAttributeModifier drifterAttributeModifier in modifiers)
			{
				string text = string.Concat("<style=\"SGLink\"><link=\"Attribute_", drifterAttributeModifier.Type.ToString(), "\">", survivalGuideProperties.DrifterAttributes.ReturnAttributeName(drifterAttributeModifier.Type), "</link></style>");
				list.Add(new TableWidget.Parameters.Entry("row-link", text, 200f));
			}
			rows.Add(list);
			AddValueRows(ref rows, survivalGuideProperties, background);
			return new List<WidgetContainer>
			{
				new WidgetContainer(style, new List<Tuple<BaseWidget, BaseWidget.BaseParameters>>
				{
					new Tuple<BaseWidget, BaseWidget.BaseParameters>(widget, new TextWidget.Parameters(survivalGuideProperties.AttributesString)),
					new Tuple<BaseWidget, BaseWidget.BaseParameters>(widget2, new TableWidget.Parameters(rows))
				})
			};
		}

		private void AddValueRows(ref List<List<TableWidget.Parameters.Entry>> rows, SurvivalGuideProperties survivalGuideProperties, DrifterAttributesEffect background)
		{
			string text = "<color=#" + ColorUtility.ToHtmlStringRGBA(survivalGuideProperties.BackgroundPositiveModifierColor) + ">{0}</color>";
			string text2 = "<color=#" + ColorUtility.ToHtmlStringRGBA(survivalGuideProperties.BackgroundNegativeModifierColor) + ">{0}</color>";
			string text3 = "<color=#" + ColorUtility.ToHtmlStringRGBA(survivalGuideProperties.BackgroundNeutralModifierColor) + ">{0}</color>";
			Sprite affinitySprite = survivalGuideProperties.AffinitySprite;
			Color affinitySpriteColor = survivalGuideProperties.AffinitySpriteColor;
			float affinitySpriteSize = survivalGuideProperties.AffinitySpriteSize;
			int num = 0;
			bool flag;
			do
			{
				List<TableWidget.Parameters.Entry> list = new List<TableWidget.Parameters.Entry>();
				flag = false;
				DrifterAttributeModifier[] modifiers = background.Modifiers;
				foreach (DrifterAttributeModifier drifterAttributeModifier in modifiers)
				{
					if (drifterAttributeModifier.Affinity > 0)
					{
						int num2 = drifterAttributeModifier.Affinity - num;
						if (num2 > 0)
						{
							list.Add(new TableWidget.Parameters.Entry("row", affinitySprite, affinitySpriteColor, affinitySpriteSize));
							if (num2 > 1)
							{
								flag = true;
							}
						}
					}
					else
					{
						string format;
						if (num == 0)
						{
							format = ((drifterAttributeModifier.Modifier > 0) ? text : ((drifterAttributeModifier.Modifier < 0) ? text2 : text3));
							format = string.Format(format, drifterAttributeModifier.ToString());
						}
						else
						{
							format = "";
						}
						list.Add(new TableWidget.Parameters.Entry("row", format, 200f));
					}
				}
				rows.Add(list);
				num++;
			}
			while (flag);
		}
	}
}
