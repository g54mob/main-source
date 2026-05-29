using System.Collections.Generic;

public class WarningDatabase : PTSMonoBehaviour
{
	public CurrentTimeBIOS timeBios;

	public List<Warning> warning;

	public void AddWarningToSystem(int idImageLevel, string level, string keywords, string dateAndTime, string source, int idWarning, string description, string user, string type)
	{
	}

	public void ClearWarnings(string type)
	{
	}

	public void ClearWarnings()
	{
	}

	public void EnsureMaxWarnings(int maxWarnings = 250)
	{
	}

	public string GetDateAndTime()
	{
		return null;
	}

	public string GetOnlyDate()
	{
		return null;
	}
}
