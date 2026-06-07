using System;
using System.Text.RegularExpressions;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/UI/Dialog Properties/Save")]
public class SaveDialogProperties : DialogProperties
{
	[NonSerialized]
	private SaveInfo _saveInfo;

	public void Initialize(SaveInfo saveInfo)
	{
		_saveInfo = saveInfo;
	}

	public override string ReturnTitle()
	{
		return base.ReturnTitle();
	}

	public override string ReturnMessage()
	{
		if (_saveInfo == null)
		{
			return base.ReturnMessage();
		}
		return Regex.Replace(base.ReturnMessage(), "%SAVENAME%", _saveInfo.Name, RegexOptions.IgnoreCase);
	}
}
