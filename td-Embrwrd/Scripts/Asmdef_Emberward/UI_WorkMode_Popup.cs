using UnityEngine.UI;

public class UI_WorkMode_Popup : APopupWindow
{
	public Text text;

	public float nearestMonsterDistance;

	private bool isCompletedWave;

	private float updateTextInterval;

	private float updateTextTimer;

	private int referenceFontSize;

	private int referenceResolutionHeight;

	private int lastFrameHeight;

	private bool isMainGame;

	protected override void ShowWindowProc()
	{
	}

	protected override void CloseWindowProc()
	{
	}

	private void OnRoundEnd()
	{
	}

	private void Update()
	{
	}

	private void UpdateFontSize()
	{
	}

	private void UpdateUIText_OtherScenes()
	{
	}

	private void UpdateUIText_MainGame()
	{
	}

	private string GetBar(float percent, int length)
	{
		return null;
	}

	private void OnApplicationFocus(bool focusStatus)
	{
	}

	public override void OnJoystickModeActivated()
	{
	}

	public override void OnMouseModeActivated()
	{
	}
}
