using Aggro.Core;

public class NitroHintUI : EntityBehaviourBase
{
	private NitroController _nitroController;

	public EaseUI easeUI;

	private bool hintEnabled;

	protected override void OnUpdatePresentation()
	{
		if (GameUtil.TryGetLocalPlayer(out var player))
		{
			_nitroController = player.GetObject<NitroController>();
			bool flag = _nitroController.nitroCharges > 0;
			if (!hintEnabled && flag)
			{
				hintEnabled = true;
				easeUI.EaseIn();
			}
			if (hintEnabled && !flag)
			{
				hintEnabled = false;
				easeUI.EaseOut();
			}
		}
	}
}
