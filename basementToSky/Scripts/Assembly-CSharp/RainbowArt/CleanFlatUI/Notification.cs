using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	public class Notification : MonoBehaviour
	{
		public enum Origin
		{
			TopLeft = 0,
			TopCenter = 1,
			TopRight = 2,
			BottomLeft = 3,
			BottomCenter = 4,
			BottomRight = 5
		}

		[Serializable]
		public class NotificationEvent : UnityEvent
		{
		}

		[SerializeField]
		private Image icon;

		[SerializeField]
		private TextMeshProUGUI title;

		[SerializeField]
		private TextMeshProUGUI description;

		[SerializeField]
		private Animator animator;

		[SerializeField]
		private RectTransform background;

		[SerializeField]
		private float showTime = 2f;

		[SerializeField]
		private float offsetX;

		[SerializeField]
		private float offsetY;

		[SerializeField]
		private Origin origin = Origin.TopCenter;

		[SerializeField]
		private Button buttonClose;

		[SerializeField]
		private NotificationEvent onCancel = new NotificationEvent();

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

		public NotificationEvent OnCancel
		{
			get
			{
				return onCancel;
			}
			set
			{
				onCancel = value;
			}
		}

		public void ShowNotification()
		{
			base.gameObject.SetActive(value: true);
			InitButtons();
			InitAnimation();
			UpdatePosition();
			if (animator != null)
			{
				PlayAnimation(bShow: true);
			}
			if (background != null)
			{
				LayoutRebuilder.ForceRebuildLayoutImmediate(background);
			}
			StartTransition(bShow: true);
		}

		public void HideNotification()
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
			switch (origin)
			{
			case Origin.TopCenter:
				localPosition.x = (x + x2) / 2f + offsetX;
				localPosition.y = y2 - component2.rect.height / 2f + offsetY;
				break;
			case Origin.BottomCenter:
				localPosition.x = (x + x2) / 2f + offsetX;
				localPosition.y = y + component2.rect.height / 2f + offsetY;
				break;
			case Origin.TopLeft:
				localPosition.x = x + component2.rect.width / 2f + offsetX;
				localPosition.y = y2 - component2.rect.height / 2f + offsetY;
				break;
			case Origin.BottomLeft:
				localPosition.x = x + component2.rect.width / 2f + offsetX;
				localPosition.y = y + component2.rect.height / 2f + offsetY;
				break;
			case Origin.TopRight:
				localPosition.x = x2 - component2.rect.width / 2f + offsetX;
				localPosition.y = y2 - component2.rect.height / 2f + offsetY;
				break;
			case Origin.BottomRight:
				localPosition.x = x2 - component2.rect.width / 2f + offsetX;
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

		private void InitButtons()
		{
			if (buttonClose != null)
			{
				buttonClose.onClick.RemoveAllListeners();
				buttonClose.onClick.AddListener(OnCloseClick);
			}
		}

		private void OnCloseClick()
		{
			if (transitionCoroutine != null)
			{
				StopCoroutine(transitionCoroutine);
				transitionCoroutine = null;
			}
			HideNotification();
			onCancel.Invoke();
		}
	}
}
