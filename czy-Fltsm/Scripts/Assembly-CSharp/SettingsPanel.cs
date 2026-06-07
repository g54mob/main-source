using UnityEngine;
using UnityEngine.Events;

public abstract class SettingsPanel : SelectableGroup
{
	[Header("Dialog Properties")]
	[SerializeField]
	private DialogProperties _resetDialogProperties;

	public UnityEvent Changed { get; private set; } = new UnityEvent();

	public void SetActive(bool value)
	{
		if (value)
		{
			ActivatePanel();
		}
		else
		{
			DeactivatePanel();
		}
	}

	public virtual void ActivatePanel()
	{
		base.gameObject.SetActive(value: true);
	}

	public virtual void ResetToDefault()
	{
		if ((bool)_resetDialogProperties)
		{
			PopupResetSettingDialog(_resetDialogProperties);
		}
		else
		{
			Reset();
		}
	}

	public virtual void DeactivatePanel()
	{
		base.gameObject.SetActive(value: false);
	}

	public abstract void Load(Settings settingsData);

	public abstract void ApplyChanges();

	public abstract bool HasChanges();

	protected abstract void Reset();

	public void UpdateApplyButton()
	{
		Changed.Invoke();
	}

	public void PopupResetSettingDialog(DialogProperties properties)
	{
		PopUpDialog.Instance.DialogFeedbackEvent.AddListener(HandleResetSettingDialog);
		PopUpDialog.Instance.TryOpenPopUpDialog(properties);
	}

	private void HandleResetSettingDialog(bool reset)
	{
		PopUpDialog.Instance.DialogFeedbackEvent.RemoveListener(HandleResetSettingDialog);
		if (reset)
		{
			Reset();
		}
	}
}
