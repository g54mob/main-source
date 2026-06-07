using System;
using System.Collections.Generic;
using Gh.Tk.UI.Dialogs.MealDesigner;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs
{
	public class RaceFlavourRatings3DUIView : MonoBehaviour
	{
		public GameObject raceRowPrefab;

		[SerializeField]
		private List<Transform> _raceSlots;

		[SerializeField]
		private TierRow3DUIView _tierRow;

		private Dictionary<string, RaceRow3DUIView> _raceRows;

		private void Clear()
		{
		}

		public void SetRaceRatings(int middleTier, Dictionary<string, List<(int rating, Func<TooltipData> tooltip)>> raceRatings)
		{
		}
	}
}
