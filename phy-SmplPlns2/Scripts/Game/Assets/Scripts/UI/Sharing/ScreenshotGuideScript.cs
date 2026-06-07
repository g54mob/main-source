using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Sharing
{
	public class ScreenshotGuideScript : MonoBehaviour
	{
		public enum ScreenshotGuideType
		{
			TopBottom = 0,
			LeftRight = 1
		}

		public float AspectRatio { get; set; }

		public ScreenshotGuideType GuideType { get; set; }

		protected virtual void Update()
		{
			float num = 1f;
			CanvasScaler componentInParent = GetComponentInParent<CanvasScaler>();
			if (componentInParent != null)
			{
				num = componentInParent.transform.localScale.x;
			}
			float num2 = (float)Screen.width / (float)Screen.height;
			float aspectRatio = AspectRatio;
			Image component = GetComponent<Image>();
			component.enabled = false;
			RectTransform component2 = GetComponent<RectTransform>();
			Vector2 sizeDelta = component2.sizeDelta;
			if (GuideType == ScreenshotGuideType.LeftRight)
			{
				if (num2 > aspectRatio)
				{
					float num3 = (float)Screen.height * aspectRatio;
					sizeDelta.x = ((float)Screen.width - num3) / 2f / num;
					if (sizeDelta.x > 5f)
					{
						component.enabled = true;
					}
				}
			}
			else if (num2 < aspectRatio)
			{
				float num4 = (float)Screen.width / aspectRatio;
				sizeDelta.y = ((float)Screen.height - num4) / 2f / num;
				if (sizeDelta.y > 5f)
				{
					component.enabled = true;
				}
			}
			component2.sizeDelta = sizeDelta;
		}
	}
}
