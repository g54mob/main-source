using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.LayoutElements
{
	public class PageIndicator : MonoBehaviour
	{
		[SerializeField]
		private RectTransform[] _dots;

		[SerializeField]
		private Color _dotColorDefault = Color.white;

		[SerializeField]
		private Color _dotColorActive = Color.white;

		private Vector2 _dotSizeDefault = Vector2.one * 10f;

		private Vector2 _dotSizeActive = Vector2.one * 14f;

		private Image[] _dotImages;

		private int _currentPage;

		private void OnEnable()
		{
			SetDotImages();
		}

		private void SetDotImages()
		{
			_dotImages = new Image[_dots.Length];
			for (int i = 0; i < _dots.Length; i++)
			{
				_dotImages[i] = _dots[i].GetComponent<Image>();
			}
		}

		public void Initialize(int pageCount, int startPage = 0)
		{
			SetDotImages();
			float num = 0f - (float)pageCount * 32f / 2f;
			for (int i = 0; i < _dots.Length; i++)
			{
				if (i < pageCount)
				{
					_dots[i].gameObject.SetActive(value: true);
					_dots[i].anchoredPosition = new Vector2(num + (float)i * 32f, 0f);
					_dots[i].sizeDelta = _dotSizeDefault;
					_dotImages[i].color = _dotColorDefault;
				}
				else
				{
					_dots[i].gameObject.SetActive(value: false);
				}
			}
			SetCurrentPage(startPage);
		}

		public void SetCurrentPage(int page)
		{
			_dots[_currentPage].sizeDelta = _dotSizeDefault;
			_dotImages[_currentPage].color = _dotColorDefault;
			_currentPage = page;
			_dots[_currentPage].sizeDelta = _dotSizeActive;
			_dotImages[_currentPage].color = _dotColorActive;
		}
	}
}
