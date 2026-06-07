using System.Collections.Generic;
using UnityEngine;

namespace CTS
{
	public class SelectionMap_ManagerVFXStars : MonoBehaviour
	{
		[SerializeField]
		private List<MapSelection> _mapSelectionList = new List<MapSelection>();

		private void Start()
		{
			SelectionMapManagerScore.OnMapWinStars += LevelWinStars;
		}

		private void LevelWinStars(MapInfoSO obj)
		{
			foreach (MapSelection mapSelection in _mapSelectionList)
			{
				if (mapSelection.MapInfo == obj)
				{
					mapSelection.GetComponent<SelectionMap_CityStarsVFX>().Launchfullanim();
					SelectionMapManagerScore.OnMapWinStars -= LevelWinStars;
					break;
				}
			}
		}

		private void OnDestroy()
		{
			SelectionMapManagerScore.OnMapWinStars -= LevelWinStars;
		}
	}
}
