using UnityEngine;
using UnityEngine.EventSystems;

public class LoadoutLabelController : MonoBehaviour
{
	public void PointerClickHandler(BaseEventData data)
	{
		PointerEventData pointerEventData = data as PointerEventData;
		GameObject pointerPress = pointerEventData.pointerPress;
		if (pointerEventData.button == PointerEventData.InputButton.Left && pointerEventData.clickCount != 1 && pointerEventData.clickCount == 2)
		{
			onLeftDoubleClick(pointerPress);
		}
	}

	public void onLeftDoubleClick(GameObject pressed)
	{
	}
}
