using System.Collections.Generic;
using UnityEngine;

namespace Presentation.UI.WorldMap
{
	public class WorldUI : MonoBehaviour
	{
		[SerializeField]
		private List<CityWorldMapUI> _cityUIs;

		private void Start()
		{
			foreach (CityWorldMapUI cityUI in _cityUIs)
			{
				cityUI.Initialize();
			}
			foreach (CityWorldMapUI cityUI2 in _cityUIs)
			{
				cityUI2.LoadExistingLines();
			}
		}

		public CityWorldMapUI GetCityUI(string levelGuidStr)
		{
			foreach (CityWorldMapUI cityUI in _cityUIs)
			{
				if (cityUI.CityData.GuidStr == levelGuidStr)
				{
					return cityUI;
				}
			}
			return null;
		}
	}
}
