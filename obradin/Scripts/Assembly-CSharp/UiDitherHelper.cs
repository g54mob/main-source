using UnityEngine;

public class UiDitherHelper : MonoBehaviour
{
	public OneBit oneBit;

	public Canvas canvas;

	public Vector2 QuantizeAndMatchAnchoredPosition(RectTransform rt)
	{
		Vector2 anchoredPosition = rt.anchoredPosition;
		anchoredPosition.y = Mathf.Round(anchoredPosition.y);
		Vector2 result = anchoredPosition - rt.anchoredPosition;
		rt.anchoredPosition = anchoredPosition;
		oneBit.basicSettings.ditherOffset = new Vector2(0f, (0f - rt.anchoredPosition.y) / (float)Resolution.bufferH);
		return result;
	}
}
