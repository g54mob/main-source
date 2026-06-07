using System;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.Buttons
{
	public class IconFlipper : MonoBehaviour
	{
		[SerializeField]
		private Button _button;

		[SerializeField]
		private RectTransform _icon;

		private Vector3 flipVector = Vector3.one;

		public bool IsFlipped;

		public event Action<bool> FlippedStateChanged;

		private void Awake()
		{
			_button.onClick.AddListener(FlipIcon);
		}

		private void OnDestroy()
		{
			_button.onClick.RemoveListener(FlipIcon);
		}

		public void FlipIcon()
		{
			IsFlipped = !IsFlipped;
			flipVector.y = (IsFlipped ? (-1f) : 1f);
			_icon.localScale = flipVector;
			this.FlippedStateChanged(IsFlipped);
		}
	}
}
