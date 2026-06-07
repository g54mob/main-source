using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputPanel : DialogPanel, IFocusTarget
{
	[Header("Input Panel")]
	[SerializeField]
	private TMP_InputField _inputField;

	[SerializeField]
	private TMP_InputFieldNavigationWrapper _inputFieldWrapper;

	[Tooltip("If disabled, input will be limited to a single line of text")]
	[SerializeField]
	private bool _enableMultipleLines;

	[Header("Error Handling")]
	[SerializeField]
	private TextMeshProUGUI _regularExpressionError;

	private Regex _regularExpression;

	private void Update()
	{
		if (_regularExpression == null || !_regularExpression.IsMatch(_inputField.text))
		{
			_regularExpressionError.gameObject.SetActive(value: false);
			_buttonOk.gameObject.SetActive(value: true);
			if (!_enableMultipleLines && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)))
			{
				Ok();
			}
		}
		else
		{
			_regularExpressionError.text = base.Properties.LocalizedRegularExpressionError;
			_regularExpressionError.gameObject.SetActive(value: true);
			_buttonOk.gameObject.SetActive(value: false);
		}
	}

	public void Initialize(DialogProperties properties, string prefilledText = "")
	{
		Initialize(properties, null, null, null);
		_inputField.text = prefilledText;
		EventSystem.current.SetSelectedGameObject(_inputField.gameObject, null);
		_inputField.OnPointerClick(new PointerEventData(EventSystem.current));
		if (!string.IsNullOrEmpty(base.Properties.RegularExpression))
		{
			_regularExpression = new Regex(base.Properties.RegularExpression);
		}
		else
		{
			_regularExpression = null;
		}
	}

	protected override void SetProperties(DialogProperties properties, string message)
	{
		base.SetProperties(properties, message);
		_inputField.characterLimit = properties.CharacterLimit;
	}

	public void SetText(string text)
	{
		_inputFieldWrapper.SetText(text);
	}

	public override void Cancel()
	{
		PopUpDialog.Instance.AnswerInput("", dialogFeedback: false);
	}

	public override void Ok()
	{
		if (!_enableMultipleLines)
		{
			_inputField.text = _inputField.text.Replace("\n", "");
		}
		if (_regularExpression == null || !_regularExpression.IsMatch(_inputField.text))
		{
			PopUpDialog.Instance.AnswerInput(_inputField.text, dialogFeedback: true);
		}
	}

	public void Edit()
	{
		if ((bool)_inputFieldWrapper)
		{
			_inputFieldWrapper.OnSubmit(null);
		}
	}

	public bool IsBeingEdited()
	{
		return _inputFieldWrapper.IsBeingEdited;
	}
}
