using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	public class QuestWindow : MonoBehaviour
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
		public class QuestEvent : UnityEvent
		{
		}

		[SerializeField]
		private Image questIcon;

		[SerializeField]
		private TextMeshProUGUI questTitle;

		[SerializeField]
		private TextMeshProUGUI questDescription;

		[SerializeField]
		private Animator animator;

		[SerializeField]
		private float showTime = 3f;

		[SerializeField]
		private float offsetX;

		[SerializeField]
		private float offsetY;

		[SerializeField]
		private Origin origin = Origin.TopCenter;

		[SerializeField]
		private Button buttonClose;

		[SerializeField]
		private QuestEvent onQuestClosed = new QuestEvent();

		private float disableTime = 0.5f;

		private List<Canvas> tempCanvasList = new List<Canvas>();

		private IEnumerator transitionCoroutine;

		private IEnumerator disableCoroutine;

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

		public string Title
		{
			get
			{
				if (!(questTitle != null))
				{
					return "";
				}
				return questTitle.text;
			}
			set
			{
				if (questTitle != null)
				{
					questTitle.text = value;
				}
			}
		}

		public string Description
		{
			get
			{
				if (!(questDescription != null))
				{
					return "";
				}
				return questDescription.text;
			}
			set
			{
				if (questDescription != null)
				{
					questDescription.text = value;
				}
			}
		}

		public Sprite Icon
		{
			get
			{
				if (!(questIcon != null))
				{
					return null;
				}
				return questIcon.sprite;
			}
			set
			{
				if (!(questIcon == null))
				{
					if (value != null)
					{
						questIcon.gameObject.SetActive(value: true);
						questIcon.sprite = value;
					}
					else
					{
						questIcon.gameObject.SetActive(value: false);
						questIcon.sprite = null;
					}
				}
			}
		}

		public QuestEvent OnQuestClosed => onQuestClosed;

		public static event Action<QuestWindow> OnQuestWindowCreated;

		private void Start()
		{
			ShowQuest();
			QuestWindow.OnQuestWindowCreated?.Invoke(this);
		}

		public void ShowQuest()
		{
			InitButtons();
			InitAnimation();
			questIcon.gameObject.SetActive(value: false);
			if (animator != null)
			{
				PlayAnimation(show: true);
			}
		}

		public void HideQuest()
		{
			questIcon.gameObject.SetActive(value: true);
			StartTransition(show: false);
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
			HideQuest();
			onQuestClosed?.Invoke();
		}

		private void InitAnimation()
		{
			if (animator != null)
			{
				animator.enabled = false;
				animator.transform.localScale = Vector3.one;
				animator.transform.localEulerAngles = Vector3.zero;
			}
		}

		private void PlayAnimation(bool show)
		{
			if (!animator.enabled)
			{
				animator.enabled = true;
			}
			string stateName = (show ? "In" : "Out");
			animator.Play(stateName, 0, 0f);
		}

		private void StartTransition(bool show)
		{
			if (show)
			{
				if (transitionCoroutine != null)
				{
					StopCoroutine(transitionCoroutine);
				}
				transitionCoroutine = ShowRoutine();
				StartCoroutine(transitionCoroutine);
			}
			else
			{
				if (disableCoroutine != null)
				{
					StopCoroutine(disableCoroutine);
				}
				disableCoroutine = HideRoutine();
				StartCoroutine(disableCoroutine);
			}
		}

		private IEnumerator ShowRoutine()
		{
			yield return new WaitForSeconds(showTime);
			if (animator != null)
			{
				PlayAnimation(show: false);
				yield return new WaitForSeconds(disableTime);
			}
			base.gameObject.SetActive(value: false);
		}

		private IEnumerator HideRoutine()
		{
			yield return new WaitForSeconds(1f);
			if (animator != null)
			{
				PlayAnimation(show: false);
				yield return new WaitForSeconds(disableTime);
			}
			UnityEngine.Object.Destroy(base.gameObject);
		}

		private void UpdatePosition()
		{
			tempCanvasList.Clear();
			GetComponentsInParent(includeInactive: false, tempCanvasList);
			if (tempCanvasList.Count != 0)
			{
				Canvas obj = tempCanvasList.Find((Canvas c) => c.isRootCanvas) ?? tempCanvasList[tempCanvasList.Count - 1];
				tempCanvasList.Clear();
				RectTransform component = obj.GetComponent<RectTransform>();
				RectTransform component2 = GetComponent<RectTransform>();
				Vector3[] array = new Vector3[4];
				component.GetWorldCorners(array);
				Vector3 vector = component2.parent.InverseTransformPoint(array[0]);
				Vector3 vector2 = component2.parent.InverseTransformPoint(array[2]);
				component2.anchoredPosition3D = InitPosition;
				Vector3 localPosition = component2.localPosition;
				float num = component2.rect.width / 2f;
				float num2 = component2.rect.height / 2f;
				switch (origin)
				{
				case Origin.TopCenter:
					localPosition = new Vector3((vector.x + vector2.x) / 2f + offsetX, vector2.y - num2 + offsetY, 0f);
					break;
				case Origin.BottomCenter:
					localPosition = new Vector3((vector.x + vector2.x) / 2f + offsetX, vector.y + num2 + offsetY, 0f);
					break;
				case Origin.TopLeft:
					localPosition = new Vector3(vector.x + num + offsetX, vector2.y - num2 + offsetY, 0f);
					break;
				case Origin.BottomLeft:
					localPosition = new Vector3(vector.x + num + offsetX, vector.y + num2 + offsetY, 0f);
					break;
				case Origin.TopRight:
					localPosition = new Vector3(vector2.x - num + offsetX, vector2.y - num2 + offsetY, 0f);
					break;
				case Origin.BottomRight:
					localPosition = new Vector3(vector2.x - num + offsetX, vector.y + num2 + offsetY, 0f);
					break;
				}
				localPosition.x = Mathf.Clamp(localPosition.x, vector.x + num, vector2.x - num);
				localPosition.y = Mathf.Clamp(localPosition.y, vector.y + num2, vector2.y - num2);
				component2.localPosition = localPosition;
			}
		}
	}
}
