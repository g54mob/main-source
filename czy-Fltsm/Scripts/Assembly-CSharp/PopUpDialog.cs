using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using I2.Loc;
using M4.Session;
using UnityEngine;
using UnityEngine.Events;

public class PopUpDialog : MonoBehaviour, ICancelable
{
	public class FeedbackEvent : UnityEvent<bool>
	{
	}

	public delegate void InputEventHandler(string input, bool dialogFeedback);

	[SerializeField]
	[Tooltip("Big text input panel")]
	private InputPanel _bigInputPanel;

	[SerializeField]
	[Tooltip("Smaller version of input panel")]
	private InputPanel _smallInputPanel;

	[SerializeField]
	[Tooltip("General dialog panel")]
	private DialogPanel _generalDialogPanel;

	[SerializeField]
	private DialogProperties[] _dialogProperties;

	private DialogProperties _properties;

	private List<DialogProperties> _queuedPopUps;

	public FeedbackEvent DialogFeedbackEvent = new FeedbackEvent();

	public Action OnPopUpClosed;

	private static PopUpDialog _instance;

	public bool CanPopup { get; private set; } = true;

	public static PopUpDialog Instance => _instance;

	public event InputEventHandler InputEvent;

	private void Awake()
	{
		if (_instance != null && _instance != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		else
		{
			_instance = this;
		}
		if (_queuedPopUps == null)
		{
			_queuedPopUps = new List<DialogProperties>();
		}
	}

	public bool TryOpenPopUpDialog(DialogProperties properties, Vitals vitals = null, Bird bird = null, string message = null)
	{
		if (!CanPopup)
		{
			return false;
		}
		_properties = properties;
		_generalDialogPanel.Initialize(properties, vitals, bird, message);
		if (_properties.PauseGame && GameManager.UIManager != null)
		{
			GameManager.UIManager.PauseGame();
		}
		SetCanPopup(canPopup: false);
		return true;
	}

	public bool TryOpenDialog(DialogProperties.ID id)
	{
		if (TryGetDialogProperties(id, out var dialogProperties))
		{
			return TryOpenPopUpDialog(dialogProperties);
		}
		return false;
	}

	public bool TryOpenDialog(DialogProperties.ID id, LocalizedString message)
	{
		if (TryGetDialogProperties(id, out var dialogProperties))
		{
			return TryOpenPopUpDialog(dialogProperties, null, null, message);
		}
		return false;
	}

	public void AnswerDialog(bool feedback)
	{
		_generalDialogPanel.gameObject.SetActive(value: false);
		SetCanPopup(canPopup: true);
		if (DialogFeedbackEvent != null)
		{
			DialogFeedbackEvent.Invoke(feedback);
			DialogFeedbackEvent.RemoveAllListeners();
		}
		if (OnPopUpClosed != null)
		{
			OnPopUpClosed();
			OnPopUpClosed = null;
		}
		if (_properties.PauseGame && GameManager.UIManager != null)
		{
			GameManager.UIManager.UnpauseGame();
		}
	}

	public bool TryPopUpInput(DialogProperties properties, string prefilledText = "")
	{
		if (Session.Platform.ItHandlesTextInput)
		{
			TextInputRequest.SingleLine(properties.Title, (uint)Mathf.Clamp(properties.CharacterLimit, 0f, 4.2949673E+09f), prefilledText, OnTextInputRequestResult);
			return true;
		}
		if (CanPopup)
		{
			SetCanPopup(canPopup: false);
			_properties = properties;
			if (_bigInputPanel.gameObject.activeInHierarchy)
			{
				_bigInputPanel.Cancel();
			}
			if (_smallInputPanel.gameObject.activeInHierarchy)
			{
				_smallInputPanel.Cancel();
			}
			if (properties.BigPanel)
			{
				_bigInputPanel.Initialize(properties, prefilledText);
			}
			else
			{
				_smallInputPanel.Initialize(properties, prefilledText);
			}
			if (_properties.PauseGame && GameManager.UIManager != null)
			{
				GameManager.UIManager.PauseGame(UIState.Typing);
			}
			return true;
		}
		return false;
	}

	public void AnswerInput(string input, bool dialogFeedback)
	{
		SetCanPopup(canPopup: true);
		if (this.InputEvent != null)
		{
			this.InputEvent(input, dialogFeedback);
		}
		if (OnPopUpClosed != null)
		{
			OnPopUpClosed();
			OnPopUpClosed = null;
		}
		_bigInputPanel.gameObject.SetActive(value: false);
		_smallInputPanel.gameObject.SetActive(value: false);
		CursorManager.LockCursorState();
		if (_properties != null && _properties.PauseGame && GameManager.UIManager != null)
		{
			GameManager.UIManager.UnpauseGame();
		}
	}

	public void ClosePopUp()
	{
		if (CanPopup)
		{
			Debug.LogWarning("Bad code!");
			return;
		}
		_generalDialogPanel.gameObject.SetActive(value: false);
		if (DialogFeedbackEvent != null)
		{
			DialogFeedbackEvent.RemoveAllListeners();
		}
		if (this.InputEvent != null)
		{
			Delegate[] invocationList = this.InputEvent.GetInvocationList();
			foreach (Delegate obj in invocationList)
			{
				InputEvent -= (InputEventHandler)obj;
			}
		}
		if (OnPopUpClosed != null)
		{
			OnPopUpClosed();
			OnPopUpClosed = null;
		}
		SetCanPopup(canPopup: true);
		if (_properties.PauseGame && GameManager.UIManager != null)
		{
			GameManager.UIManager.UnpauseGame();
		}
	}

	public bool TryCancel()
	{
		return false;
	}

	private void SetCanPopup(bool canPopup)
	{
		if (CanPopup != canPopup)
		{
			CanPopup = canPopup;
			if (CanPopup)
			{
				FlotsamInputManager.RemoveCancelable(this);
			}
			else
			{
				FlotsamInputManager.PushCancelable(this);
			}
		}
	}

	private void OnTextInputRequestResult(TextInputRequest textInputRequest)
	{
		if (this.InputEvent != null)
		{
			this.InputEvent(textInputRequest.Text, textInputRequest.Succes);
		}
	}

	private bool TryGetDialogProperties(DialogProperties.ID id, out DialogProperties dialogProperties)
	{
		int num = _dialogProperties.Length;
		while (0 < num--)
		{
			dialogProperties = _dialogProperties[num];
			if (dialogProperties.Id == id)
			{
				return true;
			}
		}
		dialogProperties = null;
		return false;
	}

	public void QueuePopUp(DialogProperties dialogProperties)
	{
		_queuedPopUps.AddUnique(dialogProperties);
	}

	public void ShowQueuedPopUps()
	{
		StartCoroutine(ShowQueuedPopUpsCoroutine());
	}

	private IEnumerator ShowQueuedPopUpsCoroutine()
	{
		while (_queuedPopUps.Count > 0)
		{
			if (CanPopup)
			{
				DialogProperties dialogProperties = _queuedPopUps.FirstOrDefault();
				if (dialogProperties != null && TryOpenPopUpDialog(dialogProperties))
				{
					_queuedPopUps.RemoveAt(0);
				}
			}
			yield return null;
		}
	}
}
