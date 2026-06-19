using Aggro.Core;
using Aggro.Core.Networking;

public class TimerPausedUI : EntityBehaviourBase
{
	public EaseUI pauseEaseUI;

	protected override void OnUpdatePresentation()
	{
		pauseEaseUI.show = NetworkAggroManagerBase<ShiftManager>.instance.serverTimersPaused;
	}
}
