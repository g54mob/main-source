using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.GUI.General
{
	[RequireComponent(typeof(ScrollRect))]
	public class ScrollRectScrollbarThief : MonoBehaviour
	{
		[SerializeField]
		private ScrollRect _thief;

		[SerializeField]
		private ScrollRect _victim;

		[SerializeField]
		private bool _horizontal;

		[SerializeField]
		private bool _vertical;

		private void OnEnable()
		{
			if ((bool)_thief && (bool)_victim)
			{
				if (_thief.horizontal)
				{
					_thief.horizontalScrollbar = _victim.horizontalScrollbar;
					_victim.horizontalScrollbar = null;
				}
				if (_thief.vertical)
				{
					_thief.verticalScrollbar = _victim.verticalScrollbar;
					_victim.verticalScrollbar = null;
				}
			}
		}

		private void OnDisable()
		{
			if ((bool)_thief && (bool)_victim)
			{
				if (_thief.horizontal)
				{
					_victim.horizontalScrollbar = _thief.horizontalScrollbar;
					_thief.horizontalScrollbar = null;
				}
				if (_thief.vertical)
				{
					_victim.verticalScrollbar = _thief.verticalScrollbar;
					_thief.verticalScrollbar = null;
				}
			}
		}
	}
}
