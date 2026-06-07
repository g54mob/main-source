using System;
using System.Collections.Generic;

namespace PajamaLlama.SurvivalGuide
{
	internal class WidgetContainer
	{
		internal WidgetContainerLayoutStyle Layout { get; private set; }

		internal List<Tuple<BaseWidget, BaseWidget.BaseParameters>> Widgets { get; private set; }

		internal WidgetContainer(WidgetContainerLayoutStyle layout, List<Tuple<BaseWidget, BaseWidget.BaseParameters>> widgets)
		{
			Layout = layout;
			Widgets = widgets;
		}
	}
}
