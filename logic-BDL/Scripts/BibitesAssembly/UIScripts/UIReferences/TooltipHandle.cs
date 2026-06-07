using OneUseScripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UIScripts.UIReferences
{
	public class TooltipHandle : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI title;

		[SerializeField]
		private TextMeshProUGUI text;

		[SerializeField]
		private RectTransform canvasRect;

		private Camera cam;

		private LayoutElement layoutElement;

		public int characterWrapLimit = 80;

		private RectTransform rect;

		private void Awake()
		{
			layoutElement = GetComponent<LayoutElement>();
			rect = GetComponent<RectTransform>();
		}

		private void Start()
		{
			cam = UICamera.cam;
		}

		public void SetTooltip(string header = null, string content = null)
		{
			title.gameObject.SetActive(string.Empty != header);
			text.gameObject.SetActive(!string.IsNullOrEmpty(content));
			if (header != null)
			{
				title.text = header;
			}
			if (!string.IsNullOrEmpty(content))
			{
				text.gameObject.SetActive(value: true);
				text.text = content;
				layoutElement.enabled = title.text.Length > characterWrapLimit || content.Length > characterWrapLimit;
			}
			else
			{
				text.gameObject.SetActive(value: false);
				layoutElement.enabled = title.text.Length > characterWrapLimit;
			}
		}

		public void Update()
		{
			Vector2 screenPoint = Input.mousePosition;
			float x = ((screenPoint.x > (float)Screen.width / 2f) ? 1f : 0f);
			float y = ((screenPoint.y > (float)Screen.height / 2f) ? 1f : 0f);
			Vector3 localScale = canvasRect.localScale;
			float x2 = 10f * Mathf.Sign(screenPoint.x - (float)Screen.width / 2f) / localScale.x;
			float y2 = 10f * Mathf.Sign(screenPoint.y - (float)Screen.height / 2f) / localScale.y;
			RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, screenPoint, cam, out var localPoint);
			rect.localPosition = (Vector3)localPoint - new Vector3(x2, y2, 10f);
			rect.pivot = new Vector2(x, y);
		}
	}
}
