using System;
using System.Collections.Generic;
using I18n;
using TMPro;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs.MealDesigner
{
	public class RaceRow3DUIView : MonoBehaviour
	{
		public GameObject ratingPrefab;

		[SerializeField]
		private List<Transform> slots;

		private List<Tuple<Button3DUIView, TextMeshPro>> _ratings;

		[SerializeField]
		private TextMeshProI18n _raceText;

		private void Awake()
		{
		}

		public void SetData(string race, (int rating, Func<TooltipData> tooltip)[] data)
		{
		}

		private string GetRatingSymbol(int rating)
		{
			return null;
		}
	}
}
