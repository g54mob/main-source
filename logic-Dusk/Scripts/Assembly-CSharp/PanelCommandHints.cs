using UnityEngine;
using UnityEngine.UI;

public class PanelCommandHints : MonoBehaviour
{
	public Text EnterCommand;

	public Text ExecuteCommand;

	public Text ClearCommand;

	public Text PageCommand;

	private void Awake()
	{
		if (ExecuteCommand != null)
		{
			ExecuteCommand.enabled = false;
		}
		if (ClearCommand != null)
		{
			ClearCommand.enabled = false;
		}
		if (PageCommand != null)
		{
			PageCommand.enabled = false;
		}
	}

	private void OnDestroy()
	{
		EnterCommand = null;
		ExecuteCommand = null;
		ClearCommand = null;
		PageCommand = null;
	}

	public void SetEnterActive()
	{
		SetEnterActive(EnterCommand.text);
	}

	public void SetEnterActive(string text)
	{
		EnterCommand.enabled = true;
		EnterCommand.text = text;
	}

	public void SetEnterInactive()
	{
		EnterCommand.enabled = false;
	}
}
