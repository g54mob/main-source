using System;

namespace TH20.UI
{
	[Serializable]
	public class InfoMessageSourceBreakDuration : InfoMessageSourceStaffBreak
	{
		public override string GetMessage(Level level)
		{
			string text = _localisedString.Translation;
			int value = (int)(level.WorkLifeBalanceManager.GetBreakDuration(base.StaffType, -1) / GameAlgorithms.Config.SecondsPerDay);
			LocalisationParams.Set("DAYS", value);
			return LocalisationParams.Localise(ref text);
		}
	}
}
