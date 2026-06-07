using System;
using System.Collections.Generic;
using PajamaLlama.JSON;
using UnityEngine;

namespace PajamaLlama.SurvivalGuide
{
	internal class JSONPage : Page
	{
		public string Path { get; private set; }

		public JSONPage(string id, string name, Sprite icon, string path)
			: base(id, name, icon)
		{
			Path = path;
		}

		protected override List<WidgetContainer> GenerateWidgets(SurvivalGuideProperties survivalGuideProperties)
		{
			string filePath = string.Concat(Application.streamingAssetsPath + survivalGuideProperties.GuidePath + Path);
			List<WidgetContainer> list = new List<WidgetContainer>();
			if (JSONExtensions.TryReadJSON(filePath, out var output))
			{
				if (!JSONExtensions.TryReturnParameter<List<object>>(output, "widget-containers", out var parameter))
				{
					throw new NotImplementedException("A Survival Guide page must widget containers.");
				}
				foreach (Dictionary<string, object> item in parameter)
				{
					if (item != null)
					{
						list.Add(CreateJSONWidgetContainer(survivalGuideProperties, item));
					}
				}
			}
			return list;
		}

		private WidgetContainer CreateJSONWidgetContainer(SurvivalGuideProperties survivalGuideProperties, Dictionary<string, object> parameters)
		{
			if (!JSONExtensions.TryReturnParameter<string>(parameters, "layoutStyle", out var parameter))
			{
				throw new NotImplementedException("A Widget Container must have a Layout Style.");
			}
			if (!survivalGuideProperties.TryReturnWidgetContainerStyle(parameter, out var style))
			{
				throw new NotImplementedException("A Widget Container must have a <b>valid</b> Layout Style.");
			}
			if (!JSONExtensions.TryReturnParameter<List<object>>(parameters, "data", out var parameter2))
			{
				throw new NotImplementedException("A Widget Container page must have data.");
			}
			return new WidgetContainer(style, CreateJSONWidgets(survivalGuideProperties, parameter2));
		}

		private static List<Tuple<BaseWidget, BaseWidget.BaseParameters>> CreateJSONWidgets(SurvivalGuideProperties survivalGuideProperties, List<object> parameters)
		{
			List<Tuple<BaseWidget, BaseWidget.BaseParameters>> list = new List<Tuple<BaseWidget, BaseWidget.BaseParameters>>();
			foreach (Dictionary<string, object> parameter in parameters)
			{
				list.Add(CreateJSONWidget(survivalGuideProperties, parameter));
			}
			return list;
		}

		private static Tuple<BaseWidget, BaseWidget.BaseParameters> CreateJSONWidget(SurvivalGuideProperties survivalGuideProperties, Dictionary<string, object> parameters)
		{
			if (!JSONExtensions.TryReturnParameter<string>(parameters, "type", out var parameter))
			{
				throw new NotImplementedException("A Widget must have a type.");
			}
			if (!survivalGuideProperties.TryReturnStyle(parameter, out var widget))
			{
				throw new NotImplementedException("A Widget must have a <b>valid</b> type.");
			}
			JSONExtensions.TryReturnParameter<Dictionary<string, object>>(parameters, "parameters", out var parameter2);
			return new Tuple<BaseWidget, BaseWidget.BaseParameters>(widget, widget.CreateParameters(parameter2));
		}
	}
}
