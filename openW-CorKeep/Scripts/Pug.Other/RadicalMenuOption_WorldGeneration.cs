using UnityEngine;
using UnityEngine.Events;

public class RadicalMenuOption_WorldGeneration : RadicalMenuOption
{
	public UnityEvent onPressEvent;

	public UnityEvent onSelectedEvent;

	public UnityEvent onDeselectedEvent;

	public GameObject selectedMarker;

	private bool isInteractable;

	public SpriteRenderer background;

	public PugText text;

	public Color inactiveTextColor;

	protected override void Awake()
	{
		base.Awake();
		selectedMarker.SetActive(value: false);
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
		base.OnActivated();
		onPressEvent?.Invoke();
	}
}
