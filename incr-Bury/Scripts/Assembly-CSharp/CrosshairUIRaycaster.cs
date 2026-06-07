using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CrosshairUIRaycaster : MonoBehaviour
{
	public Camera cam;

	public float maxDistance = 10f;

	private GameObject currentUI;

	private void Update()
	{
		cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
		PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
		pointerEventData.position = new Vector2(Screen.width / 2, Screen.height / 2);
		List<RaycastResult> list = new List<RaycastResult>();
		EventSystem.current.RaycastAll(pointerEventData, list);
		GameObject gameObject = null;
		if (list.Count > 0)
		{
			gameObject = ((!(list[0].distance > maxDistance)) ? list[0].gameObject : null);
		}
		if (gameObject != currentUI)
		{
			if (currentUI != null)
			{
				ExecuteEvents.Execute(currentUI, pointerEventData, ExecuteEvents.pointerExitHandler);
			}
			if (gameObject != null)
			{
				ExecuteEvents.Execute(gameObject, pointerEventData, ExecuteEvents.pointerEnterHandler);
			}
			currentUI = gameObject;
		}
		if (currentUI != null && Input.GetMouseButtonDown(0))
		{
			ExecuteEvents.Execute(currentUI, pointerEventData, ExecuteEvents.pointerClickHandler);
		}
	}
}
