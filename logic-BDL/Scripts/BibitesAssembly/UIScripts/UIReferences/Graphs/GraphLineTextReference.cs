using TMPro;
using UnityEngine;
using Utility;

namespace UIScripts.UIReferences.Graphs
{
	public class GraphLineTextReference : MonoBehaviour
	{
		[SerializeField]
		private RectTransform rt;

		[SerializeField]
		private TooltipTrigger tooltip;

		[SerializeField]
		private RectTransform textrt;

		[SerializeField]
		private TextMeshProUGUI lineText;

		[SerializeField]
		private TextMeshProUGUI lineTextRight;

		[SerializeField]
		private Transform line;

		private float minHeight = 13f;

		private float defaultHeight = 17f;

		private float maxHeight = 20f;

		public int maxRatio = 1;

		public void InitializeLine(string text, float? minSize, float? maxSize = null)
		{
			lineText.text = text;
			lineTextRight.text = text;
			tooltip.UpdateText(text);
			minHeight = minSize ?? minHeight;
			maxHeight = maxSize ?? maxHeight;
		}

		public void InitializeLine(TimeFormat time)
		{
			if (time.val < 0.0001f)
			{
				lineText.text = "now";
			}
			else
			{
				lineText.text = time.FormattedTimeValue(1, " ", smallUnits: true, spaceBeforeUnits: false, Timescale.Minutes) + " ago";
			}
			lineTextRight.text = lineText.text;
			tooltip.UpdateText(lineText.text);
		}

		public void SetHeightAndSpace(float height, float? maxSize = null)
		{
			base.transform.localPosition = new Vector2(0f, height);
			maxHeight = maxSize ?? maxHeight;
		}

		public void InitializeLine(TimeFormat time, float? minSize, float? maxSize = null)
		{
			lineText.text = time.FormattedTimeValue(1, " ", smallUnits: true, spaceBeforeUnits: false, Timescale.Minutes) + " ago";
			lineTextRight.text = lineText.text;
			tooltip.UpdateText(lineText.text);
			minHeight = minSize ?? minHeight;
			maxHeight = maxSize ?? maxHeight;
		}

		public void UpdateLineScaleToMatchParent(float scale)
		{
			float y = ((scale > 1f) ? Mathf.Lerp(minHeight, defaultHeight, 1f / scale) : Mathf.Lerp(defaultHeight + (defaultHeight - minHeight), defaultHeight, scale));
			textrt.sizeDelta = new Vector2(textrt.sizeDelta.x, y);
			line.localScale = new Vector3(1f, 1f / scale);
		}

		public void InverseParentScale(Vector2 parentScale)
		{
			Vector2 vector = Vector2.one / parentScale;
			float num = rt.rect.height * vector.y;
			textrt.localScale = vector;
			line.localScale = new Vector3(1f, vector.y, 1f);
			maxRatio = Mathf.CeilToInt(num / maxHeight);
		}

		public void SetActive(bool active = true)
		{
			base.gameObject.SetActive(active);
		}
	}
}
