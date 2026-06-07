using Motorways.UI;

namespace Motorways.Actions
{
	public class EditMenuNavigateAction : MotorwaysPlayerAction
	{
		protected EditMenuPanel EditMenu;

		public override void InitializeAction(PlayerActionGroup owningGroup, float timestamp)
		{
			base.InitializeAction(owningGroup, timestamp);
			MakeExclusive();
		}

		public override void Tick(float frameTime)
		{
			base.Tick(frameTime);
			EditMenu = base.Scope.Get<EditMenuPanel>();
			if (EditMenu == null || !EditMenu.IsOpen)
			{
				OnActionComplete();
			}
			else
			{
				OnTick();
			}
		}

		protected virtual void OnTick()
		{
		}
	}
}
