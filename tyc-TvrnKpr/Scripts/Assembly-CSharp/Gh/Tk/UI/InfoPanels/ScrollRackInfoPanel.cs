using UnityEngine;

namespace Gh.Tk.UI.InfoPanels
{
	public class ScrollRackInfoPanel : PropInfoPanel
	{
		[SerializeField]
		private PaperSelectionButton3DUIView _currentSelectedPaper;

		[SerializeField]
		private PaperSelectionButton3DUIView _noSubscriptionSelected;

		[SerializeField]
		private BuyButton3DUIView _restockNowButton;

		public override void Start()
		{
		}

		private void OnMoneyChanged(object sender, EventArgs<int> e)
		{
		}

		private void ToggleSubscriptionSelection()
		{
		}

		public override void Refresh()
		{
		}

		private void UpdatePaperStats()
		{
		}

		private void UpdatePaperSelection()
		{
		}
	}
}
