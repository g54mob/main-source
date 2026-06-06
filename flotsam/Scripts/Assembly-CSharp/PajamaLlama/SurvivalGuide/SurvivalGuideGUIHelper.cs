using UnityEngine;

namespace PajamaLlama.SurvivalGuide
{
	public class SurvivalGuideGUIHelper : MonoBehaviour
	{
		public void OpenSurvivalGuidePage(string link)
		{
			new StringEvent(GameEventType.OpenSurvivalGuidePage, link).Dispatch();
		}
	}
}
