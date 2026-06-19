using Pug.UnityExtensions;
using UnityEngine;
using UnityEngine.Events;

public class RadicalMenuOption_Done : RadicalMenuOption
{
	public UnityEvent doneEvent;

	public UnityEvent onSelectedEvent;

	public UnityEvent onDeselectedEvent;

	public GameObject selectedMarker;

	private bool isInteractable;

	public SpriteRenderer background;

	public PugText text;

	public Color inactiveTextColor;

	public UnityEvent errorEvent;

	protected override void Awake()
	{
		base.Awake();
		selectedMarker.SetActive(value: false);
		SetInteractable(interactable: false);
	}

	public void SetInteractable(bool interactable)
	{
		isInteractable = interactable;
		background.SetAlpha(interactable ? 1f : 0.125f);
		text.SetTempColor(interactable ? Color.white : inactiveTextColor);
	}

	public override void OnSelected()
	{
		base.OnSelected();
		selectedMarker.SetActive(value: true);
		onSelectedEvent?.Invoke();
	}

	public override void OnDeselected(bool playEffect = true)
	{
		base.OnDeselected(playEffect);
		selectedMarker.SetActive(value: false);
		onDeselectedEvent?.Invoke();
	}

	public override void OnActivated()
	{
		if (isInteractable)
		{
			base.OnActivated();
			doneEvent?.Invoke();
		}
		else
		{
			errorEvent?.Invoke();
		}
	}
}
