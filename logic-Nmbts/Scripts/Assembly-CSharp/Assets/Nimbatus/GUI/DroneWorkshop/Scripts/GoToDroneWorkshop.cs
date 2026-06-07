using Assets.Nimbatus.GUI.PlanetLocation.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts
{
	public class GoToDroneWorkshop : MonoBehaviour
	{
		public void OnClick()
		{
			PlanetLocationNavigator.PageToLoad = EPlanetLocationPage.Main;
			SceneManager.LoadScene("DroneWorkshopScene");
		}
	}
}
