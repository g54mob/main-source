namespace Simulator.GameWorld
{
	public class ReserveDesk_HUDTab_Employee : ReserveDesk_HUDTab
	{
		protected override void OnSetActive()
		{
			UpdateContent();
		}

		protected override void OnSetInactive()
		{
		}

		protected virtual void UpdateContent()
		{
		}
	}
}
