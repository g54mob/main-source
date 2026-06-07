using System.Collections.Generic;
using UnityEngine;

namespace DarkTonic.MasterAudio
{
	[AddComponentMenu("Dark Tonic/Master Audio/Button Clicker")]
	public class ButtonClicker : MonoBehaviour
	{
		public const float SmallSizeMultiplier = 0.9f;

		public const float LargeSizeMultiplier = 1.1f;

		public bool resizeOnClick;

		public bool resizeClickAllSiblings;

		public bool resizeOnHover;

		public bool resizeHoverAllSiblings;

		public string mouseDownSound;

		public string mouseUpSound;

		public string mouseClickSound;

		public string mouseOverSound;

		public string mouseOutSound;

		private Vector3 _originalSize;

		private Vector3 _smallerSize;

		private Vector3 _largerSize;

		private Transform _trans;

		private readonly Dictionary<Transform, Vector3> _siblingClickScaleByTransform;

		private readonly Dictionary<Transform, Vector3> _siblingHoverScaleByTransform;

		private void Awake()
		{
		}

		private void OnPress(bool isDown)
		{
		}

		private void OnClick()
		{
		}

		private void OnHover(bool isOver)
		{
		}
	}
}
