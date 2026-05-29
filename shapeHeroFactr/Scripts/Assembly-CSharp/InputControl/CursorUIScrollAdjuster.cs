using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace InputControl
{
	[RequireComponent(typeof(ScrollRect))]
	public class CursorUIScrollAdjuster : MonoBehaviour
	{
		[SerializeField]
		private ScrollRect _scrollRect;

		[SerializeField]
		private bool _invertVerticalScroll;

		[SerializeField]
		private bool _invertHorizontalScroll;

		[SerializeField]
		private float _margin;

		[SerializeField]
		private bool _debugLog;

		private RectTransform _contentRect;

		private List<CursorUIGroup> _cursorUIGroups;

		private Vector2 _lastScrollPosition;

		private void Reset()
		{
		}

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void UpdateScrollToSelected(CursorUIGroup group)
		{
		}

		private void AdjustScrollVertical(RectTransform selectedRect)
		{
		}

		private void AdjustScrollHorizontal(RectTransform selectedRect)
		{
		}

		private int GetCurrentIndexFromGroup(CursorUIGroup group)
		{
			return 0;
		}
	}
}
