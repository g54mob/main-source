using System.Collections.Generic;
using System.Xml.Linq;
using Jundroo.Common.Utils;
using Jundroo.Juicy.Widgets;
using Jundroo.Juicy.Widgets.Extra;

namespace Jundroo.Juicy
{
	public interface IWidgetContext
	{
		IDynamicExpressionSource ExpressionSource { get; set; }

		ILinkHandler LinkHandler { get; }

		IResourceLoader ResourceLoader { get; }

		Widget Root { get; }

		ITooltipService TooltipService { get; }

		Widget CreateWidget(XElement widgetElement, Widget parent, Stylesheet stylesheet);

		Widget CreateWidgetFromTemplate(string templateId, Widget parent, IEnumerable<XAttribute> instanceAttributes = null, Stylesheet stylesheet = null);

		void HideTooltip(Widget widget);

		void LateUpdate();

		Widget LoadWidgetFromXml(string xmlPath, Widget parent);

		void PlaySound(SoundData sound, float volumeMultiplier = 1f);

		bool PreprocessElement(XElement childElement);

		void ShowTooltip(Widget widget);
	}
}
