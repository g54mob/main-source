using UnityEngine;

public class RadicalOptionsMenuOption_MaxQueuedFrames : RadicalMenuOption
{
	public override void OnParentMenuActivation()
	{
		UpdateText(Manager.prefs.maxQueuedFrames);
		base.OnParentMenuActivation();
	}

	public override OptionActiveState GetActiveStateInCurrentScene()
	{
		return base.GetActiveStateInCurrentScene();
	}

	public override void OnActivated()
	{
		base.OnActivated();
		OnSkimRight();
	}

	public override bool OnSkimRight()
	{
		ChangeLevel(1);
		return true;
	}

	public override bool OnSkimLeft()
	{
		ChangeLevel(-1);
		return true;
	}

	private void ChangeLevel(int amount)
	{
		Manager.prefs.maxQueuedFrames = Mathf.Clamp(Manager.prefs.maxQueuedFrames + amount, 0, 6);
		UpdateText(Manager.prefs.maxQueuedFrames);
	}

	private void UpdateText(int maxQueuedFrames)
	{
		valueText.Render(maxQueuedFrames.ToString());
	}
}
