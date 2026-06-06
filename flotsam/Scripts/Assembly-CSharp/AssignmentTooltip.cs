using UnityEngine;

[DisallowMultipleComponent]
public class AssignmentTooltip : Tooltip
{
	[SerializeField]
	private DrifterAttributes _drifterAttributes;

	private AssignmentSetting _setting;

	public void Initialize(AssignmentSetting setting)
	{
		_setting = setting;
		LocalizedText = setting.Name;
	}

	public override string ParsedText()
	{
		string text = (((string)LocalizedText == null) ? LocalizedText.mTerm : LocalizedText.ToString());
		text = "<style=\"Tooltip Name\">" + text + "</style>";
		if (_setting != null)
		{
			text = text + "\n" + _setting.Description;
			_setting.GetTooltip(_drifterAttributes, text);
		}
		return text;
	}

	private string ReturnUsedInProperties(string joiner, BuildableProperties[] properties)
	{
		string text = "";
		bool flag = false;
		foreach (BuildableProperties buildableProperties in properties)
		{
			if (flag)
			{
				text += joiner;
			}
			text += buildableProperties.Name;
			flag = true;
		}
		return text;
	}
}
