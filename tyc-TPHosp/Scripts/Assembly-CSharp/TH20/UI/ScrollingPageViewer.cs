using UnityEngine;
using UnityEngine.UI;

namespace TH20.UI
{
	public class ScrollingPageViewer : MonoBehaviour
	{
		[SerializeField]
		private Button _previousPageButton;

		[SerializeField]
		private Button _nextPageButton;

		[SerializeField]
		private Sprite _defaultPreviousPageButtonSprite;

		[SerializeField]
		private Sprite _defaultNextPageButtonSprite;

		public float ScrollSpeed = 1f;

		public RectTransform PagesParent;

		private int _currentPage;

		private float _currentNormalizedPageOffset;

		public bool HasNextPage => _currentPage < PagesParent.childCount - 1;

		public bool HasPreviousPage => _currentPage > 0;

		protected void OnEnable()
		{
			if (_previousPageButton != null)
			{
				_previousPageButton.onClick.AddListener(GoToPreviousPage);
				if (!HasPreviousPage)
				{
					_previousPageButton.interactable = false;
				}
			}
			if (_nextPageButton != null)
			{
				_nextPageButton.onClick.AddListener(GoToNextPage);
				if (!HasNextPage)
				{
					_nextPageButton.interactable = false;
				}
			}
			for (int i = 0; i < PagesParent.childCount; i++)
			{
				RectTransform obj = (RectTransform)PagesParent.GetChild(i);
				obj.anchorMin = Vector2.zero;
				obj.anchorMax = Vector2.one;
				obj.sizeDelta = Vector2.zero;
				obj.anchoredPosition = new Vector2(((float)i - _currentNormalizedPageOffset) * PagesParent.rect.width, 0f);
			}
		}

		protected void OnValidate()
		{
			ScrollSpeed = Mathf.Max(ScrollSpeed, 0f);
		}

		protected void OnDisable()
		{
			_previousPageButton.onClick.RemoveListener(GoToPreviousPage);
			_nextPageButton.onClick.RemoveListener(GoToNextPage);
		}

		protected void Update()
		{
			float num = _currentPage;
			if (!Mathf.Approximately(num, _currentNormalizedPageOffset))
			{
				if (_currentNormalizedPageOffset < num)
				{
					_currentNormalizedPageOffset += Time.unscaledDeltaTime * ScrollSpeed;
					_currentNormalizedPageOffset = Mathf.Min(_currentNormalizedPageOffset, num);
				}
				else if (_currentNormalizedPageOffset > num)
				{
					_currentNormalizedPageOffset -= Time.unscaledDeltaTime * ScrollSpeed;
					_currentNormalizedPageOffset = Mathf.Max(_currentNormalizedPageOffset, num);
				}
				float num2 = Mathf.Floor(_currentNormalizedPageOffset) + Mathf.SmoothStep(0f, 1f, _currentNormalizedPageOffset % 1f);
				for (int i = 0; i < PagesParent.childCount; i++)
				{
					((RectTransform)PagesParent.GetChild(i)).anchoredPosition = new Vector2(((float)i - num2) * PagesParent.rect.width, 0f);
				}
			}
		}

		public void GoToPreviousPage()
		{
			IScrollingPageOverride component = ((RectTransform)PagesParent.GetChild(_currentPage)).GetComponent<IScrollingPageOverride>();
			if ((component == null || component.GoToPreviousPageOverride()) && HasPreviousPage)
			{
				RectTransform obj = (RectTransform)PagesParent.GetChild(_currentPage);
				_currentPage--;
				((RectTransform)PagesParent.GetChild(_currentPage)).GetComponent<IOnShowScrollingPageHandler>()?.OnShowScrollingPage();
				obj.GetComponent<IOnHideScrollingPageHandler>()?.OnHideScrollingPage();
				if (_nextPageButton != null)
				{
					_nextPageButton.interactable = true;
				}
				if (_previousPageButton != null && !HasPreviousPage)
				{
					_previousPageButton.interactable = false;
				}
			}
		}

		public void GoToNextPage()
		{
			IScrollingPageOverride component = ((RectTransform)PagesParent.GetChild(_currentPage)).GetComponent<IScrollingPageOverride>();
			if ((component == null || component.GoToNextPageOverride()) && HasNextPage)
			{
				RectTransform obj = (RectTransform)PagesParent.GetChild(_currentPage);
				_currentPage++;
				((RectTransform)PagesParent.GetChild(_currentPage)).GetComponent<IOnShowScrollingPageHandler>()?.OnShowScrollingPage();
				obj.GetComponent<IOnHideScrollingPageHandler>()?.OnHideScrollingPage();
				if (_previousPageButton != null)
				{
					_previousPageButton.interactable = true;
				}
				if (_nextPageButton != null && !HasNextPage)
				{
					_nextPageButton.interactable = false;
				}
			}
		}

		public void ChangePreviousPageButtonSprite(Sprite sprite)
		{
			Image component = _previousPageButton.GetComponent<Image>();
			if (component != null)
			{
				component.sprite = ((sprite != null) ? sprite : _defaultPreviousPageButtonSprite);
			}
		}

		public void ChangeNextPageButtonSprite(Sprite sprite)
		{
			Image component = _nextPageButton.GetComponent<Image>();
			if (component != null)
			{
				component.sprite = ((sprite != null) ? sprite : _defaultNextPageButtonSprite);
			}
		}
	}
}
