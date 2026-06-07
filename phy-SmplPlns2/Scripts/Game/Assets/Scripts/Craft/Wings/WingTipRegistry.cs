using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Assets.Scripts.Craft.Wings
{
	public static class WingTipRegistry
	{
		private static Dictionary<string, Func<XElement, WingTipStyle>> _wingTipStyle = new Dictionary<string, Func<XElement, WingTipStyle>> { 
		{
			"Rounded",
			(XElement xml) => new RoundedTip(xml)
		} };

		public static WingTipStyle Resolve(XElement xml)
		{
			string text = xml.GetStringAttributeOrNullIfWhitespace("style") ?? throw new ArgumentException("Wing tip is missing style element");
			return (_wingTipStyle.GetValueOrDefault(text, null) ?? throw new ArgumentException("Wingtip style '" + text + "' not found"))(xml);
		}
	}
}
