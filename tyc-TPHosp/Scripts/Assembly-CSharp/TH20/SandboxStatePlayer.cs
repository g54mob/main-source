namespace TH20
{
	public class SandboxStatePlayer : MetagameState
	{
		private App _app;

		public SandboxStatePlayer(App app, MetagameMap map)
			: base(map)
		{
			_app = app;
		}

		public override void Enter()
		{
			MetagameMap.MapUI.ActivateUI();
		}

		public override void Resume(State resumedFrom)
		{
			MetagameMap.MapUI.ActivateUI();
		}

		public override void Suspend(State suspendedBy)
		{
			MetagameMap.MapUI.DeactivateUI();
		}

		public override void Exit()
		{
			MetagameMap.MapUI.DeactivateUI();
		}

		public void LaunchHospital(SandboxSettings settings, bool restartLevel = false, bool saveOldLevel = true, bool newGame = false)
		{
			if (base.Owner.TopState == this)
			{
				PushState(new SandboxStateInHospital(_app, MetagameMap, settings, restartLevel, saveOldLevel, newGame));
			}
		}

		public override bool CanQuickLoadInThisState()
		{
			return true;
		}
	}
}
