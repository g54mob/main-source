using NSMedieval.State;
using NSMedieval.Types;

namespace NSMedieval.FloatingOverlaySystem
{
	public class DamagePopupFloatingElement : PriorityTextPopupFloatingElement
	{
		public void FireDamage(CombatHitInfo info)
		{
			DamagePopup.GenerateContent(info, out var text, out var color);
			if (!(text == string.Empty))
			{
				InstantiatePopupTextElement(text, color);
			}
		}

		public void HitMessed(CombatMissType missType)
		{
			string text = DamagePopup.GenerateMissContent(missType);
			InstantiatePopupTextElement(text);
		}
	}
}
