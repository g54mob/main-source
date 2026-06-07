using TMPro;
using UnityEngine;

namespace RainbowArt.CleanFlatUI
{
	[ExecuteAlways]
	public class Tooltip : MonoBehaviour
	{
		public enum Origin
		{
			Top = 0,
			Bottom = 1,
			Left = 2,
			Right = 3
		}

		public TextMeshProUGUI description;

		[SerializeField]
		private RectTransform arrowRect;

		[SerializeField]
		private uint distance;

		[SerializeField]
		private Animator animator;

		[SerializeField]
		private Origin origin;

		private bool bDelayedUpdate;

		public uint Distance
		{
			get
			{
				return distance;
			}
			set
			{
				distance = value;
			}
		}

		public Origin CurOrigin
		{
			get
			{
				return origin;
			}
			set
			{
				origin = value;
			}
		}

		public string DescriptionValue
		{
			get
			{
				if (description != null)
				{
					return description.text;
				}
				return "";
			}
			set
			{
				if (description != null)
				{
					description.text = value;
				}
			}
		}

		public void SetTooltipPosition(Vector3 position, float width, float height)
		{
			RectTransform component = GetComponent<RectTransform>();
			float num = width / 2f;
			float num2 = height / 2f;
			float x = position.x;
			float y = position.y;
			switch (origin)
			{
			case Origin.Top:
				y = position.y + num2 + (float)distance;
				break;
			case Origin.Bottom:
				y = position.y - num2 - (float)distance;
				break;
			case Origin.Left:
				x = position.x - num - (float)distance;
				break;
			case Origin.Right:
				x = position.x + num + (float)distance;
				break;
			}
			Vector3 anchoredPosition3D = new Vector3(x, y, 0f);
			component.anchoredPosition3D = anchoredPosition3D;
		}

		public void ShowTooltip()
		{
			base.gameObject.SetActive(value: true);
			if (animator != null)
			{
				animator.enabled = false;
				animator.gameObject.transform.localScale = Vector3.one;
				animator.gameObject.transform.localEulerAngles = Vector3.zero;
			}
			UpdateHeight();
			PlayAnimation();
		}

		public void HideTooltip()
		{
			base.gameObject.SetActive(value: false);
		}

		private void Update()
		{
			if (bDelayedUpdate)
			{
				bDelayedUpdate = false;
				UpdateHeight();
			}
		}

		private void UpdateHeight()
		{
			if (description != null)
			{
				RectTransform component = GetComponent<RectTransform>();
				float num = description.preferredHeight;
				float num2 = 0f;
				if (arrowRect != null)
				{
					num2 = arrowRect.rect.height;
				}
				switch (origin)
				{
				case Origin.Top:
				case Origin.Bottom:
					num = num + num2 + 40f;
					break;
				case Origin.Left:
				case Origin.Right:
					num += 40f;
					break;
				}
				component.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, num);
			}
		}

		public void UpdateHeightWhenLocalized()
		{
			if (description != null)
			{
				RectTransform component = GetComponent<RectTransform>();
				float num = description.preferredHeight;
				float num2 = 0f;
				if (arrowRect != null)
				{
					num2 = arrowRect.rect.height;
				}
				switch (origin)
				{
				case Origin.Top:
				case Origin.Bottom:
					num = num + num2 + 40f;
					break;
				case Origin.Left:
				case Origin.Right:
					num += 40f;
					break;
				}
				component.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, num);
			}
		}

		private void PlayAnimation()
		{
			if (animator != null)
			{
				if (!animator.enabled)
				{
					animator.enabled = true;
				}
				animator.Play("Transition", 0, 0f);
			}
		}
	}
}
