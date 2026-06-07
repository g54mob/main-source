using UnityEngine;

public class TerminalComputerScript : ImportantObjectClass
{
	private TerminalScript TScript;

	private void Start()
	{
		TScript = GameObject.Find("TerminalCanvas").GetComponent<TerminalScript>();
	}

	private void Update()
	{
	}

	public override void DoInteraction()
	{
		base.DoInteraction();
		if (!TScript.CanType)
		{
			TScript.ClearText();
			TScript.ClearConsole();
			TScript.CanType = true;
		}
	}
}
