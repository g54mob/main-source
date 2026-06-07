using System;
using UnityEngine;
using UnityEngine.UI;

namespace Rewired.UI.ControlMapper
{
	[AddComponentMenu(null)]
	public class UISliderControl : UIControl
	{
		public Image iconImage;

		public Slider slider;

		private bool _showIcon;

		private bool _showSlider;

		public bool showIcon
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool showSlider
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public override void SetCancelCallback(Action cancelCallback)
		{
		}
	}
}
