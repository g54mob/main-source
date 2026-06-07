using Aux;
using UnityEngine;
using UnityEngine.EventSystems;

public class CheckSelfTap : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	public void OnPointerClick(PointerEventData pointerEventData)
	{
		if (Input.touchCount == 1 && Input.GetTouch(0).tapCount == 2)
		{
			Debug.Log("action");
		}
	}

	private void Update()
	{
		if (Input.touchCount == 1)
		{
			Touch touch = Input.GetTouch(0);
			if (touch.phase == TouchPhase.Began && Helper.GetWorldRect(GetComponent<RectTransform>()).Contains(Helper.TouchToWorldPoint(touch, Program.mainCam)))
			{
				Debug.Log("action");
			}
		}
	}
}
