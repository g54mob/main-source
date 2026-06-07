using UnityEngine;

namespace Assets.Nimbatus.GUI.PlanetLocation.Scripts
{
	public class NavigateToPlanetLocationPage : MonoBehaviour
	{
		public EPlanetLocationPage Page;

		public void OnClick()
		{
			PlanetLocationNavigator.Instance.NavigateTowards(Page);
		}
	}
}
