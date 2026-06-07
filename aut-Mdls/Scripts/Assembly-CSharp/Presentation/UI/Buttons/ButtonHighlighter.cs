using UnityEngine;

namespace Presentation.UI.Buttons
{
	public class ButtonHighlighter : MonoBehaviour
	{
		[SerializeField]
		private GameObject _highlightObject;

		private bool _activated;

		public static GameObject _currentlyHighlighted;

		public bool Activated
		{
			get
			{
				return _activated;
			}
			set
			{
				_activated = value;
				if (_activated && _currentlyHighlighted != null)
				{
					_currentlyHighlighted.SetActive(value: false);
				}
				_highlightObject.SetActive(_activated);
				_currentlyHighlighted = (_activated ? _highlightObject : null);
			}
		}

		private void Awake()
		{
			if (!(_highlightObject == null))
			{
				_highlightObject.SetActive(value: false);
			}
		}
	}
}
