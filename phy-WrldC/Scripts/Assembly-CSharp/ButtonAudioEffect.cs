using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonAudioEffect : UIAudioEffectBase, IPointerEnterHandler, IEventSystemHandler, IPointerDownHandler
{
	[SerializeField]
	private AudioClip mouseOverClip;

	[SerializeField]
	private AudioClip mouseClickClip;

	private Button button;

	public AudioClip MouseOverClip
	{
		set
		{
			mouseOverClip = value;
		}
	}

	public AudioClip MouseClickClip
	{
		set
		{
			mouseClickClip = value;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		button = GetComponent<Button>();
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (!(mouseOverClip == null) && button.IsInteractable())
		{
			PlayAudio(mouseOverClip);
		}
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		if (!(mouseClickClip == null) && button.IsInteractable())
		{
			PlayAudio(mouseClickClip);
		}
	}
}
