using System.Text.RegularExpressions;
using I2.Loc;
using TMPro;
using UnityEngine;

public class CommunitySavesOverviewSlot : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _name;

	[SerializeField]
	private TextMeshProUGUI _date;

	[SerializeField]
	private TextMeshProUGUI _extraInfo;

	[Space]
	[SerializeField]
	private LocalizedString _extraInfoTerm = null;

	private CommunitySavesOverview _overview;

	private PlayerRun _run;

	private int _saveAmount;

	private int _autoSaveAmount;

	private long _fileSize;

	public void Activate(CommunitySavesOverview overview, PlayerRun run)
	{
		base.gameObject.SetActive(value: true);
		_overview = overview;
		_run = run;
		_name.text = run.CommunityName;
		_date.text = run.MostRecentSave.TimeStamp.ToString();
		_saveAmount = 0;
		_autoSaveAmount = 0;
		_fileSize = 0L;
		foreach (SaveInfo safe in run.Saves)
		{
			_fileSize += safe.Size;
			if (safe.Type == SaveType.Autosave)
			{
				_autoSaveAmount++;
			}
			else
			{
				_saveAmount++;
			}
		}
		string input = Regex.Replace(_extraInfoTerm, "%SAVES%", _saveAmount.ToString());
		input = Regex.Replace(input, "%AUTOSAVES%", _autoSaveAmount.ToString());
		input = Regex.Replace(input, "%FILESIZE%", _fileSize.ToByteString());
		_extraInfo.text = input;
	}

	public void Select()
	{
		if (!(_overview == null))
		{
			_overview.Select(_run);
		}
	}
}
