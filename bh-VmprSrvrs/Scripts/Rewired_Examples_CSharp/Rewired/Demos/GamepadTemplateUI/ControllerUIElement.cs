using UnityEngine;
using UnityEngine.UI;

namespace Rewired.Demos.GamepadTemplateUI
{
	[RequireComponent(typeof(Image))]
	public class ControllerUIElement : MonoBehaviour
	{
		[SerializeField]
		private Color _highlightColor;

		[SerializeField]
		private ControllerUIEffect _positiveUIEffect;

		[SerializeField]
		private ControllerUIEffect _negativeUIEffect;

		[SerializeField]
		private Text _label;

		[SerializeField]
		private Text _positiveLabel;

		[SerializeField]
		private Text _negativeLabel;

		[SerializeField]
		private ControllerUIElement[] _childElements;

		private Image _image;

		private Color _color;

		private Color _origColor;

		private bool _isActive;

		private float _highlightAmount;

		private bool hasEffects => false;

		private void Awake()
		{
		}

		public void Activate(float amount)
		{
		}

		public void Deactivate()
		{
		}

		public void SetLabel(string text, AxisRange labelType)
		{
		}

		public void ClearLabels()
		{
		}

		private void RedrawImage()
		{
		}
	}
}
