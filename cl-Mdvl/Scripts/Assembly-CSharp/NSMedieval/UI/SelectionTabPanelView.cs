using NSMedieval.State;

namespace NSMedieval.UI
{
	public abstract class SelectionTabPanelView : UIView
	{
		public void ShowPanel(HumanoidInstance humanoid)
		{
			SetupTabPanel(humanoid);
			Show();
		}

		protected abstract void SetupTabPanel(HumanoidInstance humanoid);
	}
}
