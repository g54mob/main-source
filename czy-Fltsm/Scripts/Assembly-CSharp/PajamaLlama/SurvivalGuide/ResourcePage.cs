using System;
using System.Collections.Generic;
using I2.Loc;
using UnityEngine;

namespace PajamaLlama.SurvivalGuide
{
	internal class ResourcePage : Page
	{
		private static List<Producer> _producers;

		public ItemProperties Properties { get; private set; }

		public ResourcePage(ItemProperties itemProperties)
			: base(itemProperties.SurvivalGuideIdentifier, itemProperties.LocalizedNameTerm, itemProperties.InventorySprite)
		{
			Properties = itemProperties;
		}

		internal static List<Page> Generate(ItemProperties[] items, BuildableProperties[] buildables, CategoryPage category)
		{
			if (_producers == null)
			{
				_producers = new List<Producer>();
			}
			else
			{
				_producers.Clear();
			}
			for (int i = 0; i < buildables.Length; i++)
			{
				if (buildables[i].Prefab.TryGetComponent<Producer>(out var component))
				{
					_producers.Add(component);
				}
			}
			List<Page> list = new List<Page>(items.Length);
			foreach (ItemProperties itemProperties in items)
			{
				if (!itemProperties.IsSuperItem)
				{
					Page page = new ResourcePage(itemProperties);
					category.AddEntry(page);
					list.Add(page);
				}
			}
			return list;
		}

		protected override List<WidgetContainer> GenerateWidgets(SurvivalGuideProperties survivalGuideProperties)
		{
			if (!survivalGuideProperties.TryReturnWidgetContainerStyle("vertical", out var _) || !survivalGuideProperties.TryReturnStyle("text-paragraph", out var _))
			{
				Debug.LogException(new NotImplementedException());
				return new List<WidgetContainer>();
			}
			List<WidgetContainer> list = new List<WidgetContainer>();
			list.AddRange(ReturnResourceInfo(survivalGuideProperties));
			using ListPool<Producer>.List list2 = ListPool<Producer>.Get();
			using ListPool<Producer>.List list3 = ListPool<Producer>.Get();
			foreach (Producer producer in _producers)
			{
				if (producer.ReturnProducesItem(Properties))
				{
					list2.Add(producer);
				}
				if (producer.ReturnUsesItem(Properties))
				{
					list3.Add(producer);
				}
			}
			list.AddRange(ReturnResourceProducers(survivalGuideProperties, survivalGuideProperties.ProducedInString, list2));
			list.AddRange(ReturnResourceProducers(survivalGuideProperties, survivalGuideProperties.UsedInString, list3));
			return list;
		}

		private List<WidgetContainer> ReturnResourceInfo(SurvivalGuideProperties survivalGuideProperties)
		{
			if (!survivalGuideProperties.TryReturnWidgetContainerStyle("vertical", out var style) || !survivalGuideProperties.TryReturnStyle("labelledimagevalue-paragraph", out var widget) || !survivalGuideProperties.TryReturnStyle("padding", out var widget2))
			{
				Debug.LogException(new NotImplementedException());
				return new List<WidgetContainer>();
			}
			List<Tuple<BaseWidget, BaseWidget.BaseParameters>> list = new List<Tuple<BaseWidget, BaseWidget.BaseParameters>>
			{
				new Tuple<BaseWidget, BaseWidget.BaseParameters>(widget, new LabelledImageValueWidget.Parameters(survivalGuideProperties.ItemTypeString, $"<color=#{ColorUtility.ToHtmlStringRGBA(Properties.ItemType.LabelColor)}>{Properties.ItemType.Name}</color>", Properties.ItemType.Icon, 40f, null, survivalGuideProperties.ItemTypeBackgroundSprite, Properties.ItemType.Color))
			};
			if (Properties.Quality != null)
			{
				list.Add(new Tuple<BaseWidget, BaseWidget.BaseParameters>(widget, new LabelledImageValueWidget.Parameters(survivalGuideProperties.FoodQualityString, $"<color=#{ColorUtility.ToHtmlStringRGBA(Properties.Quality.LabelColor)}>{Properties.Quality.Name}</color>", Properties.Quality.Icon, 40f)));
			}
			if (Properties.ConsumptionPollution > 0)
			{
				list.Add(new Tuple<BaseWidget, BaseWidget.BaseParameters>(widget, new LabelledImageValueWidget.Parameters(survivalGuideProperties.FoodPollutionString, Properties.ConsumptionPollution.ToString(), survivalGuideProperties.PollutionSprite, 40f)));
			}
			if (GameManager.Settings.BuildableSettings.WeightMode == BuildableSettings.WeightModes.Items)
			{
				list.Add(new Tuple<BaseWidget, BaseWidget.BaseParameters>(widget, new LabelledImageValueWidget.Parameters(survivalGuideProperties.WeightString, Properties.Weight.ToString(), survivalGuideProperties.WeightSprite, 40f)));
			}
			list.Add(new Tuple<BaseWidget, BaseWidget.BaseParameters>(widget2, new PaddingWidget.Parameters(20f)));
			return new List<WidgetContainer>
			{
				new WidgetContainer(style, list)
			};
		}

		private static List<WidgetContainer> ReturnResourceProducers(SurvivalGuideProperties survivalGuideProperties, LocalizedString title, List<Producer> producers)
		{
			if (!survivalGuideProperties.TryReturnWidgetContainerStyle("vertical", out var style) || !survivalGuideProperties.TryReturnStyle("text-subtitle-underlined", out var widget) || !survivalGuideProperties.TryReturnStyle("labelledimage-paragraph", out var widget2))
			{
				Debug.LogException(new NotImplementedException());
				return new List<WidgetContainer>();
			}
			if (producers.Count <= 0)
			{
				return new List<WidgetContainer>();
			}
			List<Tuple<BaseWidget, BaseWidget.BaseParameters>> list = new List<Tuple<BaseWidget, BaseWidget.BaseParameters>>
			{
				new Tuple<BaseWidget, BaseWidget.BaseParameters>(widget, new TextWidget.Parameters(title))
			};
			Vector2 dimensions = new Vector2(40f, 40f);
			foreach (Producer producer in producers)
			{
				BuildableProperties properties = producer.GetComponent<Buildable>().Properties;
				string text = "<style=\"SGLink\"><link=" + properties.SurvivalGuideIdentifier + ">" + properties.Name + "</link></style>";
				list.Add(new Tuple<BaseWidget, BaseWidget.BaseParameters>(widget2, new LabelledImageWidget.Parameters(text, properties.IconSprite, dimensions, properties.SurvivalGuideIdentifier)));
			}
			return new List<WidgetContainer>
			{
				new WidgetContainer(style, list)
			};
		}
	}
}
