public class RadicalOptionsMenuOption_TargetFrameRate : RadicalMenuOption
{
	private static string[] descriptions = new string[7] { "uncapped", "30", "45", "60", "120", "144", "165" };

	private static int[] values = new int[7] { -1, 30, 45, 60, 120, 144, 165 };

	public override void OnParentMenuActivation()
	{
		UpdateText(Manager.prefs.targetFrameRate);
		base.OnParentMenuActivation();
	}

	public override OptionActiveState GetActiveStateInCurrentScene()
	{
		if (Manager.prefs.vsync)
		{
			return OptionActiveState.GRAYED_OUT;
		}
		return base.GetActiveStateInCurrentScene();
	}

	public override void OnActivated()
	{
		base.OnActivated();
		OnSkimRight();
	}

	private void ChangeLevel(int amount)
	{
		int targetFrameRate = Manager.prefs.targetFrameRate;
		int i;
		for (i = 0; i < values.Length && targetFrameRate > values[i]; i++)
		{
		}
		int num = i + amount;
		if (num < 0)
		{
			num = values.Length - 1;
		}
		else if (num >= values.Length)
		{
			num = 0;
		}
		Manager.prefs.targetFrameRate = values[num];
		UpdateText(Manager.prefs.targetFrameRate);
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

	public void UpdateText(int frameRate)
	{
		int i;
		for (i = 0; i < values.Length && values[i] != frameRate; i++)
		{
		}
		if (i == values.Length)
		{
			valueText.localize = false;
			valueText.Render(frameRate.ToString());
		}
		else if (i == 0)
		{
			valueText.localize = true;
			valueText.Render(descriptions[i]);
		}
		else
		{
			valueText.localize = false;
			valueText.Render(descriptions[i]);
		}
	}
}
