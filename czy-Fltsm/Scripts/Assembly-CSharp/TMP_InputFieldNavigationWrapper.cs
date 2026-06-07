using I2.Loc;
using M4.Session;
using PajamaLlama.Utilities;
using Rewired.Integration.UnityUI;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TMP_InputFieldNavigationWrapper : Selectable, ISubmitHandler, IEventSystemHandler
{
	[Header("Input Field Navigation Wrapper")]
	[SerializeField]
	private TMP_InputField _inputField;

	[SerializeField]
	private LocalizedString _description;

	[SerializeField]
	[Tooltip("Should the InputField no longer be selected after the player has stopped editing?")]
	private bool _deselectOnEndEdit;

	private RewiredStandaloneInputModule _inputModule;

	private bool _isFocused;

	private UIState _uiState;

	public bool IsBeingEdited { get; private set; }

	protected override void Awake()
	{
		base.Awake();
		if (Application.isPlaying)
		{
			_inputModule = EventSystem.current.currentInputModule as RewiredStandaloneInputModule;
		}
	}

	protected override void OnEnable()
	{
		base.OnEnable();
		_inputField.onSelect.AddListener(InputField_OnSelect);
	}

	private void LateUpdate()
	{
		if (_isFocused)
		{
			if (FlotsamInputManager.GetButtonDown(_inputModule.SubmitActionId))
			{
				Finish(wasCanceled: false);
			}
			else if (FlotsamInputManager.GetButtonDown(_inputModule.CancelActionId))
			{
				Finish(wasCanceled: true);
			}
		}
		_isFocused = _inputField.isFocused;
	}

	protected override void OnDisable()
	{
		base.OnDisable();
		_inputField.onSelect.AddListener(InputField_OnSelect);
		_inputField.onDeselect.RemoveListener(InputField_OnDeselect);
		_inputField.onEndEdit.RemoveListener(OnEndEdit);
	}

	private void Finish(bool wasCanceled)
	{
		if (!wasCanceled)
		{
			_inputField.onSubmit.Invoke(_inputField.text);
		}
		_inputField.DeactivateInputField(_deselectOnEndEdit);
		if (_deselectOnEndEdit)
		{
			Deselect();
		}
		FinalUpdate.RegisterEndOfFrameOneShot(ResetUIState);
	}

	private void InputField_OnSelect(string value)
	{
		if (UIManager.State != UIState.Typing)
		{
			SetUIStateTyping();
			_inputField.onDeselect.AddListener(InputField_OnDeselect);
		}
	}

	private void InputField_OnDeselect(string value)
	{
		_inputField.onDeselect.RemoveListener(InputField_OnDeselect);
		ResetUIState();
	}

	public void SetText(string text)
	{
		if (IsBeingEdited)
		{
			Finish(wasCanceled: false);
		}
		_inputField.text = text;
	}

	public void OnSubmit(BaseEventData eventData)
	{
		if (Session.Platform.ItHandlesTextInput)
		{
			TextInputRequest.SingleLine(_description, (uint)_inputField.characterLimit, _inputField.text, OnTextInputCompleted);
			return;
		}
		_inputField.Select();
		_inputField.onEndEdit.AddListener(OnEndEdit);
		SetUIStateTyping();
	}

	private void OnTextInputCompleted(TextInputRequest input)
	{
		if (input.Succes)
		{
			_inputField.text = input.Text;
		}
	}

	private void OnEndEdit(string text)
	{
		_inputField.onEndEdit.RemoveListener(OnEndEdit);
		_isFocused = false;
		if (_deselectOnEndEdit)
		{
			Deselect();
		}
		else
		{
			Select();
		}
		FinalUpdate.RegisterEndOfFrameOneShot(ResetUIState);
	}

	private void Deselect()
	{
		EventSystem current = EventSystem.current;
		if ((bool)current && current.currentSelectedGameObject == _inputField.gameObject)
		{
			current.SetSelectedGameObject(null);
		}
	}

	private void SetUIStateTyping()
	{
		if (UIManager.State != UIState.Typing)
		{
			IsBeingEdited = true;
			_uiState = UIManager.State;
			UIManager.SetState(UIState.Typing);
		}
	}

	private void ResetUIState()
	{
		IsBeingEdited = false;
		if (UIManager.State == UIState.Typing)
		{
			UIManager.SetState(_uiState);
		}
	}
}
