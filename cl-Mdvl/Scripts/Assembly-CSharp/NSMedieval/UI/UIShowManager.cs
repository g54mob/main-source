using NSEipix.Base;
using UnityEngine;

namespace NSMedieval.UI
{
	public class UIShowManager : MonoSingleton<UIShowManager>
	{
		[SerializeField]
		private ShowHideUIElement topLeftButtons;

		[SerializeField]
		private ShowHideUIElement viewControls;

		[SerializeField]
		private ShowHideUIElement legendHeatmaps;

		[SerializeField]
		private ShowHideUIElement workersGroup;

		[SerializeField]
		private ShowHideUIElement bottomLeftGroup;

		[SerializeField]
		private ShowHideUIElement timeControls;

		[SerializeField]
		private ShowHideUIElement dateTimeGroup;

		[SerializeField]
		private ShowHideUIElement topRightButtons;

		[SerializeField]
		private ShowHideUIElement messagesPanel;

		[SerializeField]
		private ShowHideUIElement constructionGroup;

		[SerializeField]
		private ShowHideUIElement ordersGroup;

		public ShowHideUIElement TimeControls => timeControls;

		public void ShowConstruction()
		{
			constructionGroup.Show();
		}

		public void ShowOrders()
		{
			ordersGroup.Show();
		}

		public void ShowTimeControls()
		{
			timeControls.Show();
		}

		public void HideTimeControls()
		{
			timeControls.Hide();
		}

		public void ShowViewControls()
		{
			viewControls.Show();
		}

		public void ShowTopLeftButtons()
		{
			topLeftButtons.Show();
		}

		public void ShowWorkersGroup()
		{
			workersGroup.Show();
		}

		public void ShowAll()
		{
			topLeftButtons.Show();
			viewControls.Show();
			legendHeatmaps.Show();
			workersGroup.Show();
			timeControls.Show();
			dateTimeGroup.Show();
			topRightButtons.Show();
			messagesPanel.Show();
			constructionGroup.Show();
			ordersGroup.Show();
			bottomLeftGroup.Hide();
		}

		public void HideAll()
		{
			topLeftButtons.Hide();
			viewControls.Hide();
			legendHeatmaps.Hide();
			workersGroup.Hide();
			timeControls.Hide();
			dateTimeGroup.Hide();
			topRightButtons.Hide();
			messagesPanel.Hide();
			constructionGroup.Hide();
			ordersGroup.Hide();
			bottomLeftGroup.Hide();
		}
	}
}
