using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Behaviour.UI
{
	public class UIStatusMessage : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
	{
		private static RectTransform MessageContainer;

		private static UIStatusMessage MessagePrefab;

		public CanvasGroup Transparency;

		public Image StatusIcon;

		public TMP_Text StatusText;

		[SerializeField]
		private RectTransform _closeButton;

		private float TimeLeft;

		private bool _persistent;

		private void Start()
		{
			float num = 0f;
			if (_persistent)
			{
				TimeLeft = float.MaxValue;
				_closeButton.gameObject.SetActive(value: true);
				num = 40f;
			}
			else
			{
				TimeLeft = 5f;
			}
			RectTransform rectTransform = (RectTransform)base.transform;
			rectTransform.sizeDelta = new Vector2(StatusText.preferredWidth + 64f + num, rectTransform.sizeDelta.y);
			StartCoroutine(FadeIn());
			UISounds.Button();
		}

		private void Update()
		{
			TimeLeft -= Time.deltaTime;
			if (TimeLeft < 0f)
			{
				StartCoroutine(FadeOut());
				TimeLeft = 999999f;
			}
		}

		public IEnumerator FadeIn()
		{
			Transparency.alpha = 0f;
			RectTransform t = (RectTransform)base.transform;
			float timeSpent = 0f;
			while (timeSpent < 0.25f)
			{
				float num = Mathf.SmoothStep(0f, 1f, timeSpent * 4f);
				Transparency.alpha = num;
				t.pivot = new Vector2(num, 0f);
				timeSpent += Time.deltaTime;
				yield return null;
			}
			t.pivot = new Vector2(1f, 0f);
			Transparency.alpha = 1f;
		}

		public IEnumerator FadeOut()
		{
			float timeSpent = 0f;
			while (timeSpent < 0.5f)
			{
				float num = Mathf.SmoothStep(0f, 1f, timeSpent * 2f);
				Transparency.alpha = 1f - num;
				timeSpent += Time.deltaTime;
				yield return null;
			}
			Object.Destroy(base.gameObject);
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			TimeLeft = 0f;
		}

		public void SetPersistent(bool persistent)
		{
			_persistent = persistent;
		}

		public static void Show(string text, string iconName, bool persistent)
		{
			Show(text, SpriteLibrary.Get(iconName), persistent);
		}

		public static void Show(string text, Sprite icon, bool persistent)
		{
			if (!MessageContainer)
			{
				return;
			}
			UIStatusMessage uIStatusMessage = Object.Instantiate(MessagePrefab, MessageContainer);
			uIStatusMessage.StatusText.TL(text);
			uIStatusMessage.StatusIcon.sprite = icon;
			uIStatusMessage.SetPersistent(persistent);
			int num = 0;
			while (true)
			{
				bool flag = true;
				foreach (RectTransform item in MessageContainer)
				{
					if (Mathf.RoundToInt(item.anchoredPosition.y) == num)
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					break;
				}
				num += 48;
			}
			((RectTransform)uIStatusMessage.transform).anchoredPosition = new Vector2(0f, num);
		}

		public static void InitParent(RectTransform container, UIStatusMessage prefab)
		{
			MessageContainer = container;
			MessagePrefab = prefab;
			container.DestroyChildren();
		}
	}
}
