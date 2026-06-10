using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.StatsSystem;
using NSMedieval.Tools;
using UnityEngine;

namespace NSMedieval.FloatingOverlaySystem
{
	public class XpPopupFloatingElement : PriorityTextPopupFloatingElement
	{
		private Color color;

		private string xpLocalised = string.Empty;

		public void XpGained(SkillType skill, int amount)
		{
			if (string.IsNullOrEmpty(xpLocalised))
			{
				xpLocalised = MonoSingleton<LocalizationController>.Instance.GetText("general_xp");
			}
			string text = TextFormatting.GetFormatedXpAmountUp(amount, xpLocalised) + " <sprite=\"" + skill.ToString().ToLower() + "\" index=0>";
			InstantiatePopupTextElement(text, color);
		}
	}
}
