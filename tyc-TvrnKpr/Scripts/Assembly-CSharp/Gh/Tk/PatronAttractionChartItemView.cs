using System.Collections.Generic;
using Gh.Tk.UI.Dialogs;
using UnityEngine;

namespace Gh.Tk
{
	public class PatronAttractionChartItemView : MonoBehaviour
	{
		public ChartItemInteractable3DUIView interactableView;

		public GameObject[] _models;

		private readonly Dictionary<GameObject, Tuple<List<Transform>, List<Transform>>> _backers;

		public void SetState(int tier, bool active, bool hideBacker = false)
		{
		}

		private void InitBackers()
		{
		}

		public void SetData(PatronAttractionChart.AttractionChartItem chartItem)
		{
		}
	}
}
