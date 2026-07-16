using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OutlineOnHover : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler, IMoveHandler
{
	[SerializeField]
	private AudioClip hoverClip;

	private AudioSource audioSource;

	public Image outline;

	[NonSerialized]
	public bool outlineLock;

	private Image border;

	[SerializeField]
	private UnitAudioController unitAudioController;

	public static Action OnNBCNavigate;

	private void Awake()
	{
		audioSource = GetComponent<AudioSource>();
		border = GetComponent<Image>();
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (PlayerManager.Instance.Players[0].IsGamepad)
		{
			return;
		}
		if (outline == null)
		{
			unitAudioController.PlayOnChannel(0);
			return;
		}
		EventSystem.current.SetSelectedGameObject(base.gameObject);
		if (!outlineLock && border.enabled && outline != null)
		{
			outline.enabled = true;
		}
		if (audioSource != null && border.enabled)
		{
			audioSource.clip = hoverClip;
			audioSource.Play();
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		if (!(outline == null) && !outlineLock && border.enabled && outline != null)
		{
			outline.enabled = false;
		}
	}

	public void OnSelect(BaseEventData eventData)
	{
		if (PlayerManager.Instance.Players[0].IsGamepad && !outlineLock && border.enabled && outline != null)
		{
			outline.enabled = true;
		}
	}

	public void OnDeselect(BaseEventData eventData)
	{
		if (!outlineLock && border.enabled && outline != null)
		{
			outline.enabled = false;
		}
	}

	public void SetOutlineLocked(bool locked)
	{
		outlineLock = locked;
		outline.enabled = locked;
	}

	public void OnMove(AxisEventData eventData)
	{
		OnNBCNavigate?.Invoke();
		if (unitAudioController != null)
		{
			GetComponent<UnitAudioController>().PlayChannel0();
		}
	}
}
