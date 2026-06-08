using System.Collections.Generic;

public class CloseCommandEvent : BaseGameEvent
{
	public CloseCommandEvent(int seed)
		: base(seed)
	{
	}

	public override void Initalize()
	{
		base.Probability = 0.05f * GlobalSettings.GameState.ThePlayer.CurrentDockedDungeon.CalculatedDifficultyValues.EventCloseValue;
		base.CheckFrequency = 600f;
		base.OneTimeEvent = true;
		base.Initalize();
	}

	public override void ExecuteEvent()
	{
		if (GlobalSettings.CrippledCommandList == null)
		{
			GlobalSettings.CrippledCommandList = new List<string>();
		}
		GlobalSettings.CrippledCommandList.Add("close");
		SystemMessageManager.ShowSystemMessage("Derelict no longer responding to 'close' command.", ConsoleMessageType.Error);
		base.ExecuteEvent();
	}
}
