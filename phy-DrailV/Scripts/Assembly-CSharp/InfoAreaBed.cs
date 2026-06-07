using System.ComponentModel;
using DV;

public class InfoAreaBed : InfoArea
{
	private const InteractionInfoType sleepAllowedInfo = InteractionInfoType.Bed;

	private const InteractionInfoType sleepDisabledInfo = InteractionInfoType.BedDisabled;

	private void Awake()
	{
		UpdateInfo();
		Globals.G.GameParams.PropertyChanged += OnGameParamsChanged;
	}

	private void OnDestroy()
	{
		Globals.G.GameParams.PropertyChanged -= OnGameParamsChanged;
	}

	private void OnGameParamsChanged(object sender, PropertyChangedEventArgs e)
	{
		if (!(e.PropertyName != "SleepCooldownInHours"))
		{
			UpdateInfo();
		}
	}

	private void UpdateInfo()
	{
		bool flag = Globals.G.GameParams.SleepCooldownInHours >= 0;
		infoType = (flag ? InteractionInfoType.Bed : InteractionInfoType.BedDisabled);
	}
}
