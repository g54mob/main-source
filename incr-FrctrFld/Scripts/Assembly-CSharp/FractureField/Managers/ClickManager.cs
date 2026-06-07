using System.Collections.Generic;
using Reactivity;
using UnityEngine;

namespace FractureField.Managers
{
	public class ClickManager : MonoBehaviour
	{
		private long _lastClickTime;

		private readonly Queue<long> _clicksInLast10Seconds;

		private Vector3 _lastTouchPosition;

		private readonly Dictionary<int, Vector3> _lastTouchPositions;

		private bool _isRetriggeringClick;

		public RLong TimeBetweenClicksMS { get; }

		public RInt ClicksInLast10Seconds { get; }

		private void Update()
		{
		}

		private void HandleMobileTouch()
		{
		}

		[HideInCallstack]
		private void HandleMouseClick()
		{
		}

		private void HandleClick(bool isDown, Vector3 clickPosition, int touchId)
		{
		}

		public void RetriggerLastClick()
		{
		}
	}
}
