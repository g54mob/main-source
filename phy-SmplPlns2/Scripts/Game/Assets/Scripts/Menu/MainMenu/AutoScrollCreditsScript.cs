using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Menu.MainMenu
{
	[RequireComponent(typeof(ScrollRect))]
	public class AutoScrollCreditsScript : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
	{
		private bool _isPointerDown;

		[SerializeField]
		[Tooltip("Should the scroll position reset to the top when enabled?")]
		private bool _resetOnEnable = true;

		[Header("References")]
		[SerializeField]
		[Tooltip("The ScrollRect component to control. If empty, will try to get it from this GameObject.")]
		private ScrollRect _scrollRect;

		[Header("Scrolling Settings")]
		[SerializeField]
		[Tooltip("Speed of the automatic scroll (normalized units per second). Positive value scrolls down.")]
		private float _scrollSpeed = 0.02f;

		private float _targetNormalizedPos;

		public void OnPointerDown(PointerEventData eventData)
		{
			if (_scrollRect != null && eventData.button == PointerEventData.InputButton.Left)
			{
				_isPointerDown = true;
			}
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			if (_scrollRect != null && eventData.button == PointerEventData.InputButton.Left)
			{
				_isPointerDown = false;
				_targetNormalizedPos = _scrollRect.verticalNormalizedPosition;
			}
		}

		public void ResetScrollPosition()
		{
			if (_scrollRect != null)
			{
				_targetNormalizedPos = 1f;
				_scrollRect.verticalNormalizedPosition = 1f;
				_isPointerDown = false;
			}
		}

		protected void Awake()
		{
			if (_scrollRect == null)
			{
				_scrollRect = GetComponent<ScrollRect>();
			}
			if (_scrollRect == null)
			{
				Debug.LogError("AutoScrollCredits: ScrollRect component not found or assigned!", this);
				base.enabled = false;
			}
		}

		protected void OnEnable()
		{
			if (_scrollRect != null && _resetOnEnable)
			{
				_scrollRect.verticalNormalizedPosition = 1f;
				_targetNormalizedPos = 1f;
			}
			else if (_scrollRect != null)
			{
				_targetNormalizedPos = _scrollRect.verticalNormalizedPosition;
			}
			_isPointerDown = false;
		}

		protected void Update()
		{
			if (!(_scrollRect == null))
			{
				if (!_isPointerDown && _targetNormalizedPos > 0f)
				{
					_targetNormalizedPos -= _scrollSpeed * Time.deltaTime;
					_targetNormalizedPos = Mathf.Max(0f, _targetNormalizedPos);
					_scrollRect.verticalNormalizedPosition = _targetNormalizedPos;
				}
				else if (_isPointerDown)
				{
					_targetNormalizedPos = _scrollRect.verticalNormalizedPosition;
				}
				_ = _scrollRect.verticalNormalizedPosition;
				_ = 0f;
			}
		}
	}
}
