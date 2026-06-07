using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillNodeSelectable : Selectable, ISubmitHandler, IEventSystemHandler
{
	private bool isHolding;

	private UpgradeTreeButton ourUpgradeTreeButton;

	protected override void Start()
	{
		base.transition = Transition.None;
	}

	private void Update()
	{
		if (Application.isPlaying && ourUpgradeTreeButton == null)
		{
			ourUpgradeTreeButton = base.gameObject.GetComponent<UpgradeTreeButton>();
		}
	}

	public override void OnSelect(BaseEventData eventData)
	{
		base.OnSelect(eventData);
		SimulatePointerEnter();
	}

	public override void OnDeselect(BaseEventData eventData)
	{
		base.OnDeselect(eventData);
		SimulatePointerExit();
	}

	public void OnSubmit(BaseEventData eventData)
	{
		SimulatePointerClick();
		SimulatePointerDown();
	}

	public void SimulatePointerEnter()
	{
		ExecuteEvents.Execute(base.gameObject, new PointerEventData(EventSystem.current), delegate(IPointerEnterHandler handler, BaseEventData data)
		{
			handler.OnPointerEnter((PointerEventData)data);
		});
	}

	public void SimulatePointerExit()
	{
		ExecuteEvents.Execute(base.gameObject, new PointerEventData(EventSystem.current), delegate(IPointerExitHandler handler, BaseEventData data)
		{
			handler.OnPointerExit((PointerEventData)data);
		});
	}

	public void SimulatePointerDown()
	{
		ExecuteEvents.Execute(base.gameObject, new PointerEventData(EventSystem.current), delegate(IPointerDownHandler handler, BaseEventData data)
		{
			handler.OnPointerDown((PointerEventData)data);
		});
	}

	public void SimulatePointerUp()
	{
		ExecuteEvents.Execute(base.gameObject, new PointerEventData(EventSystem.current), delegate(IPointerUpHandler handler, BaseEventData data)
		{
			handler.OnPointerUp((PointerEventData)data);
		});
	}

	public void SimulatePointerClick()
	{
		ExecuteEvents.Execute(base.gameObject, new PointerEventData(EventSystem.current), delegate(IPointerClickHandler handler, BaseEventData data)
		{
			handler.OnPointerClick((PointerEventData)data);
		});
	}
}
