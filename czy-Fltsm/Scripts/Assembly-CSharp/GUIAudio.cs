using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GUIAudio : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerClickHandler, ISelectHandler, ISubmitHandler
{
	[Tooltip("The audio clip played when either a button is clicked")]
	[SerializeField]
	[FormerlySerializedAs("_guiClickActivate")]
	private AudioClipProperties _onClick;

	[Tooltip("The audio clip played when a toggle is turned on. Defaults to 'On Click' if null.")]
	[SerializeField]
	private AudioClipProperties _onToggleOn;

	[Tooltip("The audio clip played when toggle is turned off. Default to 'On Toggle On' if null.")]
	[SerializeField]
	private AudioClipProperties _onToggleOff;

	[Tooltip("This is the sound that plays when you hover over this GUI element.")]
	[SerializeField]
	[FormerlySerializedAs("_guiHoverAudio")]
	private AudioClipProperties _onPointerEnter;

	[Tooltip("The audio clip played when OnSubmit is triggered. Defaults to 'On Click' if null.")]
	[SerializeField]
	[ConditionalHide("_submitUsesOnClick", HideInInspector = true, Inverse = true)]
	private AudioClipProperties _onSubmit;

	[Tooltip("The audio clip played when OnSelected is triggered. Defaults to 'On Trigger Enter' if null")]
	[SerializeField]
	[ConditionalHide("_onSelectUsesOnPointerEnter", HideInInspector = true, Inverse = true)]
	private AudioClipProperties _onSelect;

	[Tooltip("Audioclip properties to play on the creation of this object.")]
	[SerializeField]
	private AudioClipProperties _onCreation;

	[Tooltip("Audioclip properties to play when a player clicks on something without being able to use it.")]
	[SerializeField]
	private AudioClipProperties _guiClickError;

	[Tooltip("Audiocilp properties to play when the object is enabled.")]
	[SerializeField]
	private AudioClipProperties _onEnable;

	private UIInteractableToggle _menuToggleComp;

	private Toggle _toggle;

	private UIInteractableToggle _uiInteractableToggle;

	private Button _button;

	private void Start()
	{
		if (_onToggleOn == null)
		{
			_onToggleOn = _onClick;
		}
		if (_onToggleOff == null)
		{
			_onToggleOff = _onToggleOn;
		}
		if (_onSubmit == null)
		{
			_onSubmit = _onClick;
		}
		if (_onSelect == null)
		{
			_onSelect = _onPointerEnter;
		}
		_button = GetComponent<Button>();
		if ((bool)_button)
		{
			_button.onClick.AddListener(OnButtonClick);
		}
		_toggle = GetComponent<Toggle>();
		if ((bool)_toggle)
		{
			_toggle.onValueChanged.AddListener(OnToggleValueChanged);
		}
		_uiInteractableToggle = GetComponent<UIInteractableToggle>();
		if ((bool)_uiInteractableToggle)
		{
			_uiInteractableToggle.ToggleUpdatedEvent += PlayGUIClickMenuToggle;
		}
		Play(_onCreation);
	}

	private void OnEnable()
	{
		Play(_onEnable);
	}

	private void OnDestroy()
	{
		if ((bool)_toggle)
		{
			_toggle.onValueChanged.RemoveListener(OnToggleValueChanged);
		}
		if ((bool)_uiInteractableToggle)
		{
			_uiInteractableToggle.ToggleUpdatedEvent -= PlayGUIClickMenuToggle;
		}
		if ((bool)_button)
		{
			_button.onClick.RemoveListener(OnButtonClick);
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		Play(_onPointerEnter);
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (!_button)
		{
			Play(_onClick);
		}
	}

	public void OnSelect(BaseEventData eventData)
	{
		Play(_onPointerEnter);
	}

	public void OnSubmit(BaseEventData eventData)
	{
		Play(_onSubmit);
	}

	public void OnButtonClick()
	{
		Play(_onClick);
	}

	public void OnToggleValueChanged(bool value)
	{
		if (value)
		{
			Play(_onToggleOn);
		}
		else
		{
			Play(_onToggleOff);
		}
	}

	public void PlayGUIClickError()
	{
		Play(_guiClickError);
	}

	public void PlayGUIClickMenuToggle()
	{
		OnToggleValueChanged((bool)_menuToggleComp && _menuToggleComp.IsOn);
	}

	private void Play(AudioClipProperties audioClipProperties)
	{
		if ((bool)audioClipProperties)
		{
			AudioManager.Play(audioClipProperties);
		}
	}
}
