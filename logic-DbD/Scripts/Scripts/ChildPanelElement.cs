using UnityEngine;
using UnityEngine.EventSystems;

public class ChildPanelElement : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
{
	public void OnPointerDown(PointerEventData data)
	{
		Transform obj = UIUtils.FindPanelTransformFromChild(base.transform);
		UIUtils.SetPenultimateLayer(obj);
		TaskbarManager.SetTaskbarActive(obj.gameObject);
	}
}
