using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class ToggleSwitch : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
	[SerializeField]
	private RectTransform anchor;

	[SerializeField]
	private Image visualArea;

	[SerializeField]
	private Slider sliderProperty;

	[SerializeField]
	private UIFieldProperties normal;

	[SerializeField]
	private UIFieldProperties hover;

	[SerializeField]
	private UIFieldProperties pressed;

	[SerializeField]
	private float fadeTime = 1f;

	[SerializeField]
	private AnimationCurve fadeCurve = new AnimationCurve();

	[SerializeField]
	private bool canOnlyTurnOn;

	[SerializeField]
	private bool canOnlyTurnOff;

	[SerializeField]
	private UnityEvent OnToggleOn;

	[SerializeField]
	private UnityEvent OnToggleOff;

	[SerializeField]
	private UnityEvent<bool> OnValueChanged = new UnityEvent<bool>();

	public bool isOn;

	private bool isHovering;

	private List<Coroutine> que = new List<Coroutine>();

	private void Start()
	{
	}

	public void Init(bool isOn)
	{
		this.isOn = isOn;
		if (isOn)
		{
			TurnSwitchOnNoNotify();
		}
		else
		{
			TurnSwitchOffNoNotify();
		}
	}

	public UnityEvent<bool> GetOnValueChangedEvent()
	{
		return OnValueChanged;
	}

	public void SetValueWithoutNotify(bool isOn)
	{
		Init(isOn);
	}

	public void TurnSwitchOffNoNotify()
	{
		isOn = false;
		if (!base.gameObject.activeInHierarchy || !base.enabled)
		{
			sliderProperty.SetValueWithoutNotify(0f);
			return;
		}
		if (sliderProperty.value != 0f && sliderProperty.value != 1f)
		{
			StopCoroutine(UIAnimator.SliderAnimator(sliderProperty, isOn ? 1 : 0, fadeCurve, fadeTime));
		}
		StartCoroutine(UIAnimator.SliderAnimator(sliderProperty, isOn ? 1 : 0, fadeCurve, fadeTime));
	}

	public void TurnSwitchOnNoNotify()
	{
		if (base.gameObject == null)
		{
			return;
		}
		isOn = true;
		if (!base.gameObject.activeInHierarchy || !base.enabled)
		{
			sliderProperty.SetValueWithoutNotify(1f);
			return;
		}
		if (sliderProperty.value != 0f && sliderProperty.value != 1f)
		{
			StopCoroutine(UIAnimator.SliderAnimator(sliderProperty, isOn ? 1 : 0, fadeCurve, fadeTime));
		}
		StartCoroutine(UIAnimator.SliderAnimator(sliderProperty, isOn ? 1 : 0, fadeCurve, fadeTime));
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (canOnlyTurnOff)
		{
			if (isOn)
			{
				isOn = false;
			}
		}
		else if (canOnlyTurnOn)
		{
			if (!isOn)
			{
				isOn = true;
			}
		}
		else
		{
			isOn = !isOn;
		}
		if (sliderProperty.value != 0f && sliderProperty.value != 1f)
		{
			StopCoroutine(UIAnimator.SliderAnimator(sliderProperty, isOn ? 1 : 0, fadeCurve, fadeTime));
		}
		StartCoroutine(UIAnimator.SliderAnimator(sliderProperty, isOn ? 1 : 0, fadeCurve, fadeTime));
		if (isOn)
		{
			OnToggleOn.Invoke();
		}
		else
		{
			OnToggleOff.Invoke();
		}
		OnValueChanged.Invoke(isOn);
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		UIAnimator.StopAllQuedRoutines(que, this);
		Coroutine item = StartCoroutine(UIAnimator.Fader(pressed, anchor, visualArea, fadeCurve, fadeTime));
		que.Add(item);
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		UIAnimator.StopAllQuedRoutines(que, this);
		Coroutine item = StartCoroutine(UIAnimator.Fader(isHovering ? hover : normal, anchor, visualArea, fadeCurve, fadeTime));
		que.Add(item);
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		UIAnimator.StopAllQuedRoutines(que, this);
		Coroutine item = StartCoroutine(UIAnimator.Fader(hover, anchor, visualArea, fadeCurve, fadeTime));
		que.Add(item);
		isHovering = true;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		UIAnimator.StopAllQuedRoutines(que, this);
		Coroutine item = StartCoroutine(UIAnimator.Fader(normal, anchor, visualArea, fadeCurve, fadeTime));
		que.Add(item);
		isHovering = false;
	}
}
