using UnityEngine;

public class ScrollviewResizer : MonoBehaviour
{
	public static void ResizeContent(RectTransform content, GameObject itemPrefab, int count, float spacing = 0f)
	{
		float size = (itemPrefab.GetComponent<RectTransform>().sizeDelta.y + spacing) * (float)count;
		content.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, size);
	}

	public static void ResizeContentByGrid(RectTransform content, GameObject itemPrefab, int totalCount, int xCount, float spacing = 0f)
	{
		int num = Mathf.CeilToInt((float)totalCount / (float)xCount);
		float size = (itemPrefab.GetComponent<RectTransform>().sizeDelta.y + spacing) * (float)num;
		content.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, size);
	}
}
