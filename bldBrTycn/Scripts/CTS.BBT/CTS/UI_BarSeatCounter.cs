using CTS.Core;
using TMPro;
using UnityEngine;

namespace CTS
{
	public class UI_BarSeatCounter : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text _everyoneSeatCountText;

		[SerializeField]
		private TMP_Text _vampireSeatCountText;

		[SerializeField]
		private TMP_Text _allSeatCountText;

		private void Start()
		{
			SeatCounter.SeatCountChanged += SeatCountChanged;
			SeatCounter.SeatOccupedCountChanged += SeatOccupedCountChanged;
			UpdateTexts();
		}

		private void OnDestroy()
		{
			SeatCounter.SeatCountChanged -= SeatCountChanged;
			SeatCounter.SeatOccupedCountChanged -= SeatOccupedCountChanged;
		}

		private void SeatOccupedCountChanged(int human, int vampire)
		{
			UpdateTexts();
		}

		private void SeatCountChanged(int obj)
		{
			UpdateTexts();
		}

		private void UpdateTexts()
		{
			_everyoneSeatCountText.text = CTSSingleton<SeatCounter>.Instance.CurrentUsedHumanSeatCount + "/" + CTSSingleton<SeatCounter>.Instance.CurrentEveryoneSeatCount;
			_vampireSeatCountText.text = CTSSingleton<SeatCounter>.Instance.CurrentUsedVampireSeatCount + "/" + CTSSingleton<SeatCounter>.Instance.CurrentVampireSeatCount;
			_allSeatCountText.text = CTSSingleton<SeatCounter>.Instance.CurrentUsedHumanSeatCount + CTSSingleton<SeatCounter>.Instance.CurrentUsedVampireSeatCount + "/" + CTSSingleton<SeatCounter>.Instance.CurrentSeatCount;
		}
	}
}
