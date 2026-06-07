using UnityEngine;

public class StickyCanvas : MonoBehaviour
{
	private RectTransform rectTransform;

	public void SetCanvasSize(int scale)
	{
		rectTransform = GetComponent<RectTransform>();
		if (SaveData.ins.verticalMode)
		{
			float size = (float)Screen.height * 2f / (float)scale;
			rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, size);
			rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 504f);
			rectTransform.anchoredPosition = new Vector3(0f, 0f, 90f);
		}
		else
		{
			float size2 = (float)Screen.width * (1f - Mathf.Abs(GameManager.ins.mainCam.rect.x)) * 2f / (float)scale;
			rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 296f);
			rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size2);
			rectTransform.anchoredPosition = new Vector3(0f, 0.25f, 90f);
		}
	}
}
