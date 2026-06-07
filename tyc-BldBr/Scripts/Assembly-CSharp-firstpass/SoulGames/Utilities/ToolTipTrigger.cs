using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SoulGames.Utilities
{
	public class ToolTipTrigger : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI headerField;

		[SerializeField]
		private TextMeshProUGUI contentField;

		[SerializeField]
		private LayoutElement layoutElement;

		[SerializeField]
		private int wrapLimit;

		[SerializeField]
		private RectTransform rectTransform;

		private void Awake()
		{
			rectTransform = GetComponent<RectTransform>();
		}

		private void Update()
		{
			Vector2 vector = new Vector2(Input.mousePosition.x - 16f, Input.mousePosition.y + 16f);
			float x = vector.x / (float)Screen.width;
			float y = vector.y / (float)Screen.height;
			rectTransform.pivot = new Vector2(x, y);
			base.transform.position = vector;
		}

		public void SetText(string content, string header = "")
		{
			if (string.IsNullOrEmpty(header))
			{
				headerField.gameObject.SetActive(value: false);
			}
			else
			{
				headerField.gameObject.SetActive(value: true);
				headerField.text = header;
			}
			contentField.text = content;
			int length = headerField.text.Length;
			int length2 = contentField.text.Length;
			layoutElement.enabled = ((length > wrapLimit || length2 > wrapLimit) ? true : false);
		}
	}
}
