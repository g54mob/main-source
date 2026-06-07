using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class ToggleAudioEffect : UIAudioEffectBase, IPointerEnterHandler, IEventSystemHandler
{
	[SerializeField]
	private AudioClip toggleOverClip;

	[SerializeField]
	private AudioClip toggleOnClip;

	[SerializeField]
	private AudioClip toggleOffClip;

	private Toggle toggle;

	public AudioClip ToggleOverClip
	{
		set
		{
			toggleOverClip = value;
		}
	}

	public AudioClip ToggleOnClip
	{
		set
		{
			toggleOnClip = value;
		}
	}

	public AudioClip ToggleOffClip
	{
		set
		{
			toggleOffClip = value;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		toggle = GetComponent<Toggle>();
		toggle.onValueChanged.AddListener(ValueChangedHandler);
	}

	private void ValueChangedHandler(bool isOn)
	{
		if (isOn && toggleOnClip != null)
		{
			PlayAudio(toggleOnClip);
		}
		else if (toggleOffClip != null)
		{
			PlayAudio(toggleOffClip);
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (!(toggleOverClip == null) && toggle.IsInteractable())
		{
			PlayAudio(toggleOverClip);
		}
	}
}
