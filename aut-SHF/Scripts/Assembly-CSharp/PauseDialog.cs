using TMPro;
using UI;
using UnityEngine;

public class PauseDialog : BaseDialog
{
	[SerializeField]
	private TMP_Text title;

	[SerializeField]
	private GameObject unFreePauseGroup;

	[SerializeField]
	private GameObject slowModeButton;

	private const eMessageId defaultMessage = eMessageId.CommonWord_Pause;

	public override void Init()
	{
	}

	public override void Open()
	{
	}

	public override void Init<T>(T args)
	{
	}

	public override void Open<T>(T args)
	{
	}

	public void OnSlowMode()
	{
	}

	public override void PushEscape()
	{
	}

	public override void SetInFront()
	{
	}

	public void OpenAction(eMessageId messageId, bool isSlowMode)
	{
	}

	public override void Back()
	{
	}
}
