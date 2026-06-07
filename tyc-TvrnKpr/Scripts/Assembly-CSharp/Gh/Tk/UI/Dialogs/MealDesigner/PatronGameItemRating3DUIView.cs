using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs.MealDesigner
{
	public class PatronGameItemRating3DUIView : Button3DUIView, INestedTooltipProvider, ITooltipProvider
	{
		public PatronAttractionChartItemView[] pawnPrefabs;

		public Transform socket;

		public ObjectProgressBar3DUIView progressBar;

		public TextMeshPro numberText;

		private List<PatronAttractionChartItemView> _chartItems;

		private int? _ratingPreview;

		public int Rating { get; private set; }

		protected override void Awake()
		{
		}

		public void SetData(string race, int tier, IPatronRatable ratableTemplate, string category = null, bool forceDisabled = false, bool showOnlyTargetRating = false)
		{
		}

		public void SetRatingPreview(int? rating)
		{
		}

		private int GetPastVisitorCount(string race, int tier)
		{
			return 0;
		}

		private int GetPastVisitorCount(string race)
		{
			return 0;
		}

		private string GetVisitorInformation(string race, int tier)
		{
			return null;
		}

		private void Clear()
		{
		}

		protected override void OnDestroy()
		{
		}

		public int GetId()
		{
			return 0;
		}

		public Tooltip3DUIView GetParent()
		{
			return null;
		}
	}
}
