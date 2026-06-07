using System.Collections;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class DialogPanel : Panel, IFocusTarget
{
	[Header("Dialog Panel")]
	[Tooltip("Text component for the title for the dialog panel.")]
	[SerializeField]
	private TextMeshProUGUI _title;

	[Tooltip("Text component for the content text for the dialog panel.")]
	[SerializeField]
	[FormerlySerializedAs("_description")]
	private TextMeshProUGUI _message;

	[Space]
	[Tooltip("Gameobject for the confirm button for the dialog panel.")]
	[SerializeField]
	protected GameObject _buttonOk;

	[Tooltip("Text component of the confirm button for the dialog panel.")]
	[SerializeField]
	private TextMeshProUGUI _buttonOkText;

	[Space]
	[Tooltip("Gameobject for the cancel button for the dialog panel.")]
	[SerializeField]
	protected GameObject _buttonCancel;

	[Tooltip("Text component of the cancel button for the dialog panel.")]
	[SerializeField]
	private TextMeshProUGUI _buttonCancelText;

	[SerializeField]
	private Image _icon;

	private float _countdown;

	private Coroutine _runningCoroutine;

	public DialogProperties Properties { get; private set; }

	public int Priority => int.MaxValue;

	public GameObject SelectedGameObject => null;

	public bool SelectedGameObjectIsActiveAndEnabled => true;

	private void OnEnable()
	{
		FocusManager.RequestFocus(this);
	}

	private void OnDisable()
	{
		FocusManager.ReleaseFocus(this);
	}

	public void Initialize(DialogProperties properties, Vitals vitals = null, Bird bird = null, string message = null)
	{
		message = (string.IsNullOrEmpty(message) ? properties.ReturnMessage() : message);
		message = TextManager.ReplaceVariables(message, vitals);
		message = TextManager.ReplaceVariables(message, bird);
		SetProperties(properties, message);
		base.gameObject.SetActive(value: true);
		if (Properties.Timed)
		{
			_runningCoroutine = StartCoroutine(TimeOutCoroutine());
		}
	}

	public override void Close()
	{
		Cancel();
		base.Close();
	}

	protected virtual void SetProperties(DialogProperties properties, string message)
	{
		Properties = properties;
		_title.text = properties.ReturnTitle();
		_message.text = message;
		_message.horizontalAlignment = properties.MessageHorizontalAllignment;
		_message.verticalAlignment = properties.MessageVerticalAllignment;
		_buttonCancel.SetActive(Properties.EnableCancelButton);
		if (_buttonCancel.activeSelf)
		{
			_buttonCancelText.text = properties.LocalizedCancelButtonText.ToString().ToUpper();
		}
		_buttonOk.SetActive(Properties.EnableConfirmButton);
		if (_buttonOk.activeSelf)
		{
			_buttonOkText.text = properties.LocalizedConfirmButtonText.ToString().ToUpper();
		}
		if ((bool)_icon)
		{
			_icon.transform.parent.gameObject.SetActive(properties.Icon);
			_icon.overrideSprite = properties.Icon;
		}
	}

	public virtual void Cancel()
	{
		PopUpDialog.Instance.AnswerDialog(feedback: false);
		PopUpDialog.Instance.ShowQueuedPopUps();
		if (_runningCoroutine != null)
		{
			StopCoroutine(_runningCoroutine);
		}
	}

	public virtual void Ok()
	{
		if (_runningCoroutine != null)
		{
			StopCoroutine(_runningCoroutine);
		}
		PopUpDialog.Instance.AnswerDialog(feedback: true);
		PopUpDialog.Instance.ShowQueuedPopUps();
	}

	private IEnumerator TimeOutCoroutine()
	{
		_countdown = Properties.TimeOut;
		while (_countdown > 0f)
		{
			_message.text = Regex.Replace(Properties.ReturnMessage(), "%TIMER%", $"<b>{_countdown:0}</b>", RegexOptions.IgnoreCase);
			_countdown -= Time.unscaledDeltaTime;
			yield return null;
		}
		if (base.gameObject.activeSelf)
		{
			Close();
		}
		PopUpDialog.Instance.DialogFeedbackEvent.RemoveAllListeners();
	}

	public void OnFocusGained()
	{
	}

	public void OnFocusLost()
	{
	}

	public void OnCurrentSelectedSelectableChanged(Selectable selectable)
	{
	}
}
