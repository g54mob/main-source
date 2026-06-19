using UnityEngine;

public class ConsoleHelpText : MonoBehaviour
{
	[Header("Settings:")]
	public readonly float heightPadPixels = 6f;

	public readonly float widthPadPixels = 10f;

	public float textBackgroundAlpha = 0.9f;

	public float backgroundAlpha;

	[Header("References:")]
	public PugText pugText;

	private void Awake()
	{
		if (!Manager.enableConsole)
		{
			base.gameObject.SetActive(value: false);
		}
		else if (Manager.prefs.HasOpenedConsoleCommands)
		{
			base.gameObject.SetActive(value: false);
		}
	}

	private void Update()
	{
		if (Manager.sceneHandler.isInGame && pugText.displayedTextStringLinesAmount == 0)
		{
			pugText.Render();
		}
		if (Manager.input.IsToggleConsoleButtonDown())
		{
			Manager.prefs.HasOpenedConsoleCommands = true;
			base.gameObject.SetActive(value: false);
		}
	}
}
