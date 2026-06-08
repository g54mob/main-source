using KitchenData;
using UnityEngine;

namespace Kitchen
{
	public class SeasonalContentToggle : MonoBehaviour
	{
		public Season SeasonActive;

		public GameObject Target;

		private void Awake()
		{
			if (!(Target == null))
			{
				Season season = Seasons.GetSeason();
				Target.SetActive(SeasonActive == season);
			}
		}
	}
}
