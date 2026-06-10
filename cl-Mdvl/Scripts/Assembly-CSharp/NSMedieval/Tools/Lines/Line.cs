using UnityEngine;
using UnityEngine.UI.Extensions;

namespace NSMedieval.Tools.Lines
{
	[RequireComponent(typeof(UILineRenderer))]
	public class Line : MonoBehaviour
	{
		private UILineRenderer lineRenderer;

		private int linePointsCount = 2;

		private Color locked = new Color(33f / 85f, 0.3372549f, 32f / 85f, 1f);

		private Color unlocked = new Color(0.4392157f, 0.57254905f, 53f / 85f, 1f);

		private Color activated = new Color(0.9254902f, 0.70980394f, 0.12156863f, 1f);

		public void SetColorLocked()
		{
			lineRenderer.color = locked;
		}

		public void SetColorUnlocked()
		{
			lineRenderer.color = unlocked;
		}

		public void SetColorActivated()
		{
			lineRenderer.color = activated;
		}

		public void Draw(RectTransform outputRectTransform, RectTransform inputRectTransform)
		{
			if (lineRenderer == null)
			{
				lineRenderer = GetComponent<UILineRenderer>();
			}
			lineRenderer.Points = new Vector2[linePointsCount];
			float x = inputRectTransform.anchoredPosition.x - outputRectTransform.anchoredPosition.x;
			float y = inputRectTransform.anchoredPosition.y - outputRectTransform.anchoredPosition.y;
			lineRenderer.Points[0] = Vector3.zero;
			lineRenderer.Points[1] = new Vector2(x, y);
		}

		private void Awake()
		{
			lineRenderer = GetComponent<UILineRenderer>();
		}
	}
}
