using UnityEngine;
using UnityEngine.UI;

namespace Rewired.Demos.GamepadTemplateUI
{
	[RequireComponent(typeof(Image))]
	public class ControllerUIEffect : MonoBehaviour
	{
		[SerializeField]
		private Color _highlightColor;

		private Image _image;

		private Color _color;

		private Color _origColor;

		private bool _isActive;

		private float _highlightAmount;

		private void Awake()
		{
		}

		public void Activate(float amount)
		{
		}

		public void Deactivate()
		{
		}

		private void RedrawImage()
		{
		}
	}
}
