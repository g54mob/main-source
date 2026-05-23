using TMPro;
using UnityEngine;

namespace RainbowArt.CleanFlatUI
{
	[ExecuteAlways]
	public class TooltipSpecial : MonoBehaviour
	{
		private enum Origin
		{
			Top = 0,
			RightTop = 1,
			LeftTop = 2,
			Bottom = 3,
			RightBottom = 4,
			LeftBottom = 5
		}

		[SerializeField]
		private TextMeshProUGUI description;

		[SerializeField]
		private Animator animator;

		private float parentWidth;

		private float parentHeight;

		private Origin origin;

		private bool bDelayedUpdate;

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

		public void InitTooltip(Vector2 mousePosition, RectTransform areaScope)
		{
			UpdateHeight();
			UpdatePosition(mousePosition, areaScope);
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
				float size = description.preferredHeight + 40f;
				component.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, size);
			}
		}

		private void UpdatePosition(Vector2 mousePosition, RectTransform areaScope)
		{
			RectTransform component = GetComponent<RectTransform>();
			component.localPosition = new Vector3(mousePosition.x, mousePosition.y, 0f);
			Vector3[] array = new Vector3[4];
			component.GetWorldCorners(array);
			Vector3[] array2 = new Vector3[4];
			float num = 0f;
			float num2 = 0f;
			for (int i = 0; i < 4; i++)
			{
				array2[i] = areaScope.InverseTransformPoint(array[i]);
			}
			if (array2[2].x >= areaScope.rect.xMax)
			{
				if (array2[0].x - component.rect.width / 2f < areaScope.rect.xMin)
				{
					num = array2[0].x - component.rect.width / 2f - areaScope.rect.xMin;
				}
				if (array2[2].y >= areaScope.rect.yMax)
				{
					origin = Origin.LeftBottom;
					if (array2[0].y - component.rect.height < areaScope.rect.yMin)
					{
						num2 = array2[0].y - component.rect.height - areaScope.rect.yMin;
					}
				}
				else
				{
					origin = Origin.LeftTop;
				}
			}
			else if (array2[0].x <= areaScope.rect.xMin)
			{
				if (array2[2].x + component.rect.width / 2f > areaScope.rect.xMax)
				{
					num = array2[2].x + component.rect.width / 2f - areaScope.rect.xMax;
				}
				if (array2[2].y >= areaScope.rect.yMax)
				{
					origin = Origin.RightBottom;
					if (array2[0].y - component.rect.height < areaScope.rect.yMin)
					{
						num2 = array2[0].y - component.rect.height - areaScope.rect.yMin;
					}
				}
				else
				{
					origin = Origin.RightTop;
				}
			}
			else if (array2[2].y >= areaScope.rect.yMax)
			{
				if (array2[0].y - component.rect.height < areaScope.rect.yMin)
				{
					num2 = array2[0].y - component.rect.height - areaScope.rect.yMin;
				}
				origin = Origin.Bottom;
			}
			else
			{
				origin = Origin.Top;
			}
			Vector3 localPosition = component.localPosition;
			float width = component.rect.width;
			float height = component.rect.height;
			switch (origin)
			{
			case Origin.RightTop:
				localPosition.x = localPosition.x + width / 2f - num;
				break;
			case Origin.LeftTop:
				localPosition.x = localPosition.x - width / 2f - num;
				break;
			case Origin.Bottom:
				localPosition.y = localPosition.y - height - num2;
				break;
			case Origin.RightBottom:
				localPosition.x = localPosition.x + width / 2f - num;
				localPosition.y = localPosition.y - height - num2;
				break;
			case Origin.LeftBottom:
				localPosition.x = localPosition.x - width / 2f - num;
				localPosition.y = localPosition.y - height - num2;
				break;
			}
			component.localPosition = localPosition;
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
