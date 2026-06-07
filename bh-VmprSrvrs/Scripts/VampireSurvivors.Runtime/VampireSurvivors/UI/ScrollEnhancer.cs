using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivors.UI
{
	public class ScrollEnhancer : MonoBehaviour
	{
		[SerializeField]
		private bool _DEBUGTHIS;

		[SerializeField]
		private bool _AutoInitialize;

		[SerializeField]
		private bool _HideSliderWhenNotNeeded;

		public bool RequiresMouseOverForScroll;

		[SerializeField]
		private float _scrollSpeed;

		[SerializeField]
		private RectTransform _scroll;

		[SerializeField]
		private RectTransform _content;

		[SerializeField]
		private Scrollbar _scrollbar;

		[SerializeField]
		private Slider _Slider;

		[SerializeField]
		private float _OffsetWhenSliderShown;

		private GameObject _previouslySelected;

		private Vector3 _baseScrollViewPosition;

		private void Awake()
		{
		}

		private void Update()
		{
		}

		public void Initialize(float scrollSpeed, RectTransform content, Scrollbar scrollbar, Slider slider, float offset)
		{
		}

		protected void OnSliderDrag(float val)
		{
		}

		public void ForceScrollAlignment()
		{
		}

		public void LogOnValueChange(float val)
		{
		}

		public void SetScrollbarActive(bool on)
		{
		}

		protected void ScrollWithSelection(RectTransform _scrollRect, RectTransform _content)
		{
		}
	}
}
