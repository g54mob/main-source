using TMPro;
using UnityEngine;

public class TextTooltip : MonoBehaviour
{
	public RectTransform tooltipAnchor;

	public RectTransform cursorAnchor;

	public TextMeshProUGUI label;

	private void Awake()
	{
	}

	public void SetPosition(RectTransform rt, bool useVertical)
	{
		Vector3 position = rt.position;
		float scaleFactor = MenuManager.Instance.canvas.scaleFactor;
		Rect screenSpaceRect = MenuManager.Instance.GetScreenSpaceRect(rt);
		Vector3 position2;
		if (useVertical)
		{
			position2 = new Vector3(screenSpaceRect.x + screenSpaceRect.width * 0.5f, screenSpaceRect.y + screenSpaceRect.height, 0f);
			float num = tooltipAnchor.rect.width * scaleFactor;
			bool num2 = position2.x + num * 0.5f - (float)Screen.width > 0f;
			Vector3 position3 = StartupManager.Instance.mainCamera.ScreenToWorldPoint(position2);
			position3.z = position.z;
			cursorAnchor.position = position3;
			if (num2)
			{
				tooltipAnchor.pivot = new Vector2(1f, 0f);
			}
			else
			{
				tooltipAnchor.pivot = new Vector2(0.5f, 0f);
			}
			tooltipAnchor.anchoredPosition = new Vector2(0f, 5f);
		}
		else if (position.x < 0f)
		{
			position2 = new Vector3(screenSpaceRect.x + screenSpaceRect.width, screenSpaceRect.y + screenSpaceRect.height * 0.5f, 0f);
			Vector3 position4 = StartupManager.Instance.mainCamera.ScreenToWorldPoint(position2);
			position4.z = position.z;
			cursorAnchor.position = position4;
			tooltipAnchor.pivot = new Vector2(0f, 0.5f);
			tooltipAnchor.anchoredPosition = new Vector2(5f, 0f);
		}
		else
		{
			position2 = new Vector3(screenSpaceRect.x, screenSpaceRect.y + screenSpaceRect.height * 0.5f, 0f);
			Vector3 position5 = StartupManager.Instance.mainCamera.ScreenToWorldPoint(position2);
			position5.z = position.z;
			cursorAnchor.position = position5;
			tooltipAnchor.pivot = new Vector2(1f, 0.5f);
			tooltipAnchor.anchoredPosition = new Vector2(-5f, 0f);
		}
		StartupManager.Instance.mainCamera.WorldToScreenPoint(tooltipAnchor.transform.position);
		float num3 = tooltipAnchor.rect.height * scaleFactor;
		float num4 = position2.y + num3 * 0.5f - ((float)Screen.height - 20f * scaleFactor);
		float num5 = position2.y - num3 * 0.5f - 20f * scaleFactor;
		if (num4 > 0f)
		{
			tooltipAnchor.pivot = new Vector2(tooltipAnchor.pivot.x, 1f);
			tooltipAnchor.anchoredPosition = new Vector2(tooltipAnchor.anchoredPosition.x, 0f);
		}
		else if (num5 < 0f)
		{
			tooltipAnchor.pivot = new Vector2(tooltipAnchor.pivot.x, 0f);
			tooltipAnchor.anchoredPosition = new Vector2(tooltipAnchor.anchoredPosition.x, 1f);
		}
	}

	public void SetPosition(Vector3 p)
	{
		cursorAnchor.position = p;
		if (cursorAnchor.anchoredPosition.x < 0f)
		{
			tooltipAnchor.pivot = new Vector2(0f, 0.5f);
			tooltipAnchor.anchoredPosition = new Vector2(5f, 0f);
		}
		else
		{
			tooltipAnchor.pivot = new Vector2(1f, 0.5f);
			tooltipAnchor.anchoredPosition = new Vector2(-5f, 0f);
		}
	}

	private void Update()
	{
	}
}
