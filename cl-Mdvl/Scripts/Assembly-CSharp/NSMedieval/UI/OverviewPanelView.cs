using System.Linq;
using NSEipix.View.UI;
using UnityEngine;
using UnityEngine.Serialization;

namespace NSMedieval.UI
{
	public abstract class OverviewPanelView : UIView
	{
		protected enum SortMode
		{
			Animal = 0,
			Name = 1,
			Age = 2,
			Assigned = 3,
			Haul = 4,
			Battle = 5,
			PestControl = 6,
			Train = 7,
			Slaughter = 8,
			Release = 9,
			InPen = 10,
			Hunt = 11,
			HuntRet = 12,
			Tame = 13,
			Tameable = 14,
			TameRet = 15,
			Group = 16,
			Count = 17,
			Value = 18,
			Health = 19,
			Freshness = 20,
			Fermentation = 21,
			Allow = 22,
			OnStockpile = 23,
			Weight = 24,
			Nutrition = 25,
			Quality = 26,
			DamagePerSecond = 27,
			Range = 28,
			Precision = 29,
			ArmorRating = 30,
			MeleeCoverAmount = 31,
			RangedCoverAmount = 32,
			TempMin = 33,
			TempMax = 34,
			OwnerName = 35,
			UrgentHaul = 36,
			Faction = 37,
			CaptiveLabourer = 38,
			ShackleMarked = 39,
			StripMarked = 40,
			ReleaseMarked = 41,
			RecruitMarked = 42
		}

		[FormerlySerializedAs("animalsGroup")]
		[SerializeField]
		private LayoutGroupView contentGroup;

		[SerializeField]
		protected SoundButton[] sortingButtons;

		[SerializeField]
		protected SortMode[] sortingButtonModes;

		protected bool SortDirection;

		private protected SortMode CurrentSortMode { get; private set; }

		protected LayoutGroupView ContentGroup => contentGroup;

		private void Awake()
		{
			CurrentSortMode = sortingButtonModes.First();
		}

		protected virtual void Start()
		{
			SoundButton[] array = sortingButtons;
			foreach (SoundButton sortingButton in array)
			{
				if (!(sortingButton == null))
				{
					sortingButton.onClick.RemoveAllListeners();
					sortingButton.onClick.AddListener(delegate
					{
						OnSortColumnClicked(sortingButton);
					});
				}
			}
			SetSortArrows(0);
		}

		protected abstract void SortEntries();

		private void OnSortColumnClicked(SoundButton sortButton)
		{
			int num = -1;
			for (int i = 0; i < sortingButtons.Length; i++)
			{
				if (sortingButtons[i] == sortButton)
				{
					num = i;
					break;
				}
			}
			if (num != -1)
			{
				SetSortMode(sortingButtonModes[num]);
				SetSortArrows(num);
			}
		}

		protected void SetSortMode(SortMode mode)
		{
			if (CurrentSortMode == mode)
			{
				SortDirection = !SortDirection;
				SortEntries();
			}
			else
			{
				SortDirection = false;
				CurrentSortMode = mode;
				SortEntries();
			}
		}

		private void SetSortArrows(int selectedButtonIndex)
		{
			for (int i = 0; i < sortingButtons.Length; i++)
			{
				TradingSortArrowImages component = sortingButtons[i].GetComponent<TradingSortArrowImages>();
				if (component != null)
				{
					bool upDown = i == selectedButtonIndex && SortDirection;
					component.SetArrows(upDown, i == selectedButtonIndex);
				}
			}
		}
	}
}
