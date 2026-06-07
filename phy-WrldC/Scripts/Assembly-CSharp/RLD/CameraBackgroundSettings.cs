using System;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class CameraBackgroundSettings : Settings
	{
		[SerializeField]
		private Color _firstColor = RTSystemValues.CameraBkGradientFirstColor;

		[SerializeField]
		private Color _secondColor = RTSystemValues.CameraBkGradientSecondColor;

		[SerializeField]
		private float _gradientOffset;

		[SerializeField]
		private bool _isVisible;

		public Color FirstColor
		{
			get
			{
				return _firstColor;
			}
			set
			{
				_firstColor = value;
			}
		}

		public Color SecondColor
		{
			get
			{
				return _secondColor;
			}
			set
			{
				_secondColor = value;
			}
		}

		public float GradientOffset
		{
			get
			{
				return _gradientOffset;
			}
			set
			{
				_gradientOffset = Mathf.Clamp(value, -1f, 1f);
			}
		}

		public bool IsVisible
		{
			get
			{
				return _isVisible;
			}
			set
			{
				_isVisible = value;
			}
		}
	}
}
