using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	[ExecuteAlways]
	public class ToastContentFitter : MonoBehaviour
	{
		public enum Origin
		{
			Top = 0,
			Center = 1,
			Bottom = 2
		}

		[SerializeField]
		private Image icon;

		[SerializeField]
		private TextMeshProUGUI title;

		[SerializeField]
		private TextMeshProUGUI description;

		[SerializeField]
		private float maxDescriptionWidth = 600f;

		[SerializeField]
		private Animator animator;

		[SerializeField]
		private float showTime = 2f;

		[SerializeField]
		private float offsetX;

		[SerializeField]
		private float offsetY;

		[SerializeField]
		private Origin origin = Origin.Center;

		private float disableTime = 1f;

		private List<Canvas> tempCanvasList = new List<Canvas>();

		private IEnumerator transitionCoroutine;

		private IEnumerator diableCoroutine;

		private Vector3? initAnchoredPosition;

		private Vector3 InitPosition
		{
			get
			{
				if (!initAnchoredPosition.HasValue)
				{
					initAnchoredPosition = GetComponent<RectTransform>().anchoredPosition3D;
				}
				return initAnchoredPosition ?? Vector3.zero;
			}
		}

		public float ShowTime
		{
			get
			{
				return showTime;
			}
			set
			{
				showTime = value;
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

		public float OffsetX
		{
			get
			{
				return offsetX;
			}
			set
			{
				offsetX = value;
			}
		}

		public float OffsetY
		{
			get
			{
				return offsetY;
			}
			set
			{
				offsetY = value;
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

		public string TitleValue
		{
			get
			{
				if (title != null)
				{
					return title.text;
				}
				return "";
			}
			set
			{
				if (title != null)
				{
					title.text = value;
				}
			}
		}

		public Sprite IconValue
		{
			get
			{
				if (icon != null)
				{
					return icon.sprite;
				}
				return null;
			}
			set
			{
				if (icon != null)
				{
					if (value != null)
					{
						icon.gameObject.SetActive(value: true);
						icon.sprite = value;
					}
					else
					{
						icon.gameObject.SetActive(value: false);
						icon.sprite = null;
					}
				}
			}
		}

		public float MaxDescriptionWidth
		{
			get
			{
				if (maxDescriptionWidth <= 0f)
				{
					maxDescriptionWidth = 100f;
				}
				else if (maxDescriptionWidth >= 1920f)
				{
					maxDescriptionWidth = 1800f;
				}
				return maxDescriptionWidth;
			}
			set
			{
				if (value <= 0f)
				{
					value = 100f;
				}
				else if (value >= 1920f)
				{
					value = 1800f;
				}
				maxDescriptionWidth = value;
			}
		}

		public void ShowToast()
		{
			base.gameObject.SetActive(value: true);
			InitAnimation();
			UpdateHeightAndWidth();
			UpdatePosition();
			if (animator != null)
			{
				PlayAnimation(bShow: true);
			}
			StartTransition(bShow: true);
		}

		public void HideToast()
		{
			StartTransition(bShow: false);
		}

		private void UpdatePosition()
		{
			tempCanvasList.Clear();
			GetComponentsInParent(includeInactive: false, tempCanvasList);
			if (tempCanvasList.Count == 0)
			{
				return;
			}
			Canvas canvas = tempCanvasList[tempCanvasList.Count - 1];
			for (int i = 0; i < tempCanvasList.Count; i++)
			{
				if (tempCanvasList[i].isRootCanvas)
				{
					canvas = tempCanvasList[i];
					break;
				}
			}
			tempCanvasList.Clear();
			RectTransform component = canvas.GetComponent<RectTransform>();
			RectTransform component2 = GetComponent<RectTransform>();
			Vector3[] array = new Vector3[4];
			component.GetWorldCorners(array);
			Vector3 vector = component2.parent.InverseTransformPoint(array[0]);
			Vector3 vector2 = component2.parent.InverseTransformPoint(array[2]);
			component2.anchoredPosition3D = InitPosition;
			Vector3 localPosition = component2.localPosition;
			float x = vector.x;
			float x2 = vector2.x;
			float y = vector.y;
			float y2 = vector2.y;
			localPosition.x = (x + x2) / 2f + offsetX;
			switch (origin)
			{
			case Origin.Center:
				localPosition.y = (y + y2) / 2f + offsetY;
				break;
			case Origin.Top:
				localPosition.y = y2 - component2.rect.height / 2f + offsetY;
				break;
			case Origin.Bottom:
				localPosition.y = y + component2.rect.height / 2f + offsetY;
				break;
			}
			float min = x + component2.rect.width / 2f;
			float max = x2 - component2.rect.width / 2f;
			float min2 = y + component2.rect.height / 2f;
			float max2 = y2 - component2.rect.height / 2f;
			localPosition.x = Mathf.Clamp(localPosition.x, min, max);
			localPosition.y = Mathf.Clamp(localPosition.y, min2, max2);
			component2.localPosition = localPosition;
		}

		private void InitAnimation()
		{
			if (animator != null)
			{
				animator.enabled = false;
				animator.gameObject.transform.localScale = Vector3.one;
				animator.gameObject.transform.localEulerAngles = Vector3.zero;
			}
		}

		private void PlayAnimation(bool bShow)
		{
			if (!animator.enabled)
			{
				animator.enabled = true;
			}
			if (bShow)
			{
				animator.Play("In", 0, 0f);
			}
			else
			{
				animator.Play("Out", 0, 0f);
			}
		}

		private void StartTransition(bool bShow)
		{
			if (bShow)
			{
				if (transitionCoroutine != null)
				{
					StopCoroutine(transitionCoroutine);
					transitionCoroutine = null;
				}
				transitionCoroutine = UpdateTransition();
				StartCoroutine(transitionCoroutine);
			}
			else
			{
				if (diableCoroutine != null)
				{
					StopCoroutine(diableCoroutine);
					diableCoroutine = null;
				}
				diableCoroutine = DisableTransition();
				StartCoroutine(diableCoroutine);
			}
		}

		private IEnumerator UpdateTransition()
		{
			yield return new WaitForSeconds(showTime);
			if (animator != null)
			{
				PlayAnimation(bShow: false);
				yield return new WaitForSeconds(disableTime);
			}
			base.gameObject.SetActive(value: false);
		}

		private IEnumerator DisableTransition()
		{
			if (animator != null)
			{
				PlayAnimation(bShow: false);
				yield return new WaitForSeconds(disableTime);
			}
			base.gameObject.SetActive(value: false);
		}

		private void UpdateHeightAndWidth()
		{
			if (description != null)
			{
				RectTransform component = GetComponent<RectTransform>();
				RectTransform component2 = description.GetComponent<RectTransform>();
				float num = MaxDescriptionWidth;
				float num2 = ((description.preferredWidth < num) ? description.preferredWidth : num);
				Vector2 size = component2.rect.size;
				Vector2 size2 = component.rect.size;
				component.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size2.x + num2 - size.x);
				float preferredHeight = description.preferredHeight;
				component.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, size2.y + preferredHeight - size.y);
			}
		}
	}
}
