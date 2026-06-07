using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuUtility : MonoBehaviour
{
	public static void ClearSelection()
	{
		EventSystem.current.SetSelectedGameObject(null);
	}

	public static void ScrollPage(ScrollRect s, int dir)
	{
		RectTransform content = s.content;
		float y = content.anchoredPosition.y;
		float height = s.GetComponent<RectTransform>().rect.height;
		content.anchoredPosition = new Vector2(0f, y + height * (float)(-dir) * 0.75f);
	}

	public static void JumpToItem(Transform t, ScrollRect parent)
	{
		if (null == parent)
		{
			return;
		}
		RectTransform content = parent.content;
		if (t is RectTransform rectTransform)
		{
			Canvas.ForceUpdateCanvases();
			float height = parent.GetComponent<RectTransform>().rect.height;
			float num = height * 0.5f;
			float y = parent.transform.InverseTransformPoint(rectTransform.position).y;
			float num2 = parent.transform.InverseTransformPoint(content.position).y - y;
			float num3 = height * 0.2f;
			float num4 = 0f - num + num3;
			float num5 = num - num3;
			if (y < num4)
			{
				float num6 = height - num3;
				content.anchoredPosition = new Vector2(0f, num2 - num6);
			}
			else if (y > num5)
			{
				float num7 = num3;
				content.anchoredPosition = new Vector2(0f, num2 - num7);
			}
		}
	}

	public static void JumpToItem(LayoutItem t, ScrollRect parent)
	{
		if (!(null == parent))
		{
			RectTransform content = parent.content;
			float height = parent.GetComponent<RectTransform>().rect.height;
			float num = height * 0.5f;
			float y = t.y;
			float num2 = content.anchoredPosition.y - y;
			float num3 = height * 0.2f;
			float num4 = 0f - num + num3;
			float num5 = num - num3;
			float max = content.rect.height - height;
			float y2 = Mathf.Clamp(y - num, 0f, max);
			content.anchoredPosition = new Vector2(0f, y2);
		}
	}
}
