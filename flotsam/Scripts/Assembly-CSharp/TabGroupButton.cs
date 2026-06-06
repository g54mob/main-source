using UnityEngine;
using UnityEngine.EventSystems;

public class TabGroupButton : CustomButton
{
	public bool IsSelected;

	[Space]
	[SerializeField]
	private TabGroup _tabGroup;

	[SerializeField]
	private GameObject _content;

	protected override void Awake()
	{
		base.Awake();
		if (_tabGroup != null)
		{
			_tabGroup.Subscribe(this);
		}
	}

	public void Deactivate()
	{
		IsSelected = false;
		base.targetGraphic.color = base.colors.normalColor;
		_content.SetActive(value: false);
	}

	public void Activate()
	{
		IsSelected = true;
		base.targetGraphic.color = base.colors.pressedColor;
		_content.SetActive(value: true);
	}

	public override void OnPointerClick(PointerEventData eventData)
	{
		base.OnPointerClick(eventData);
		_tabGroup.Select(this);
	}
}
