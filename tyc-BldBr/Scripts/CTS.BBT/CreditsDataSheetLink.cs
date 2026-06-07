using UnityEngine;

[CreateAssetMenu(fileName = "CreditDataSheetLink", menuName = "Sheet/CreditDataSheetLink")]
public class CreditsDataSheetLink : ScriptableObject
{
	[Header("Never use a file with : 'edit#gid=0' at the end!")]
	[SerializeField]
	private string _sheetPath;

	public void GiveTheGooglePath(string googlePath)
	{
		_sheetPath = googlePath;
	}

	public string GetFullPath()
	{
		return _sheetPath;
	}

	public string GetCleanedPath()
	{
		string text = _sheetPath.Replace("https://docs.google.com/spreadsheets/d/", "");
		if (text.Contains("/edit?usp=drive_link"))
		{
			text = text.Replace("/edit?usp=drive_link", "");
		}
		else if (text.Contains("/edit?usp=sharing"))
		{
			text = text.Replace("/edit?usp=sharing", "");
		}
		return text;
	}
}
