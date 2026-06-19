using TMPro;
using UnityEngine;

namespace HeneGames.Airplane
{
	public class RunwayUIManager : MonoBehaviour
	{
		[SerializeField]
		private Runway runway;

		[SerializeField]
		private TextMeshProUGUI debugText;

		[SerializeField]
		private GameObject uiContent;

		private void Update()
		{
			if (runway.AirplaneIsLanding())
			{
				uiContent.SetActive(value: true);
				debugText.text = "Airplane is landing";
			}
			else if (runway.AirplaneLandingCompleted())
			{
				uiContent.SetActive(value: true);
				debugText.text = "Press space to launch";
			}
			else if (runway.AriplaneIsTakingOff())
			{
				uiContent.SetActive(value: true);
				debugText.text = "Airplane is taking off";
			}
			else
			{
				uiContent.SetActive(value: false);
				debugText.text = "";
			}
		}
	}
}
