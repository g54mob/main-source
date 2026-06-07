using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class DrifterListItem : UIComponent, IPointerClickHandler, IEventSystemHandler
{
	[SerializeField]
	private TextMeshProUGUI _label;

	[SerializeField]
	private bool _clickOnPointerEnter;

	public Agent Drifter { get; private set; }

	public UnityEvent<DrifterListItem> OnClick { get; private set; } = new UnityEvent<DrifterListItem>();

	protected override void OnDisable()
	{
		OnClick.RemoveAllListeners();
	}

	public void Initialize(Agent drifter)
	{
		Drifter = drifter;
		OnClick.RemoveAllListeners();
		_label.text = drifter.Name;
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left)
		{
			OnClick.Invoke(this);
		}
	}

	public override void OnPointerEnter(PointerEventData eventData)
	{
		base.OnPointerEnter(eventData);
		if (_clickOnPointerEnter)
		{
			OnClick.Invoke(this);
		}
	}
}
