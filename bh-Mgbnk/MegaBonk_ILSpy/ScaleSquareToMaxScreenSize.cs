using UnityEngine;
using UnityEngine.UI;

public class ScaleSquareToMaxScreenSize : MonoBehaviour
{
	private RectTransform rect;

	public CanvasScaler canvasScaler;

	private void OnEnable()
	{
		//IL_0074: Invalid comparison between I4 and F4
		if (rect == null)
		{
			RectTransform component = GetComponent<RectTransform>();
			rect = component;
		}
		int width = Screen.width;
		int height = Screen.height;
		int num = width / height;
		Vector2 vector = default(Vector2);
		Vector2 sizeDelta = (((float)num > 1f) ? vector : vector);
		rect.sizeDelta = sizeDelta;
	}
}
