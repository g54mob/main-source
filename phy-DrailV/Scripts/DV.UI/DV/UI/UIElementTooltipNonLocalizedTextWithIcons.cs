using System.Collections.Generic;
using DV.UIFramework;
using UnityEngine;

namespace DV.UI
{
	public class UIElementTooltipNonLocalizedTextWithIcons : UIElementTooltipNonLocalizedText, ITooltipIcons
	{
		public List<Sprite> icons = new List<Sprite>();

		public List<Sprite> GetIcons()
		{
			return icons;
		}
	}
}
