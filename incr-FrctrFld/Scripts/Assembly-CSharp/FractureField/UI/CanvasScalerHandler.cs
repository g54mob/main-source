using UnityEngine;

namespace FractureField.UI
{
	public class CanvasScalerHandler : MonoBehaviour
	{
		[SerializeField]
		private RectTransform _rect;

		[Header("Scale Adjustment")]
		[SerializeField]
		private bool _shouldScale;

		[Header("Height Adjustment")]
		[SerializeField]
		private bool _expandHeightAgainstScale;

		[SerializeField]
		private float _originalHeight;

		[Header("Position Movement")]
		[SerializeField]
		private bool _shouldAdjustPosition;

		[SerializeField]
		private bool _anchoredToBottom;

		[SerializeField]
		private float _yPosAtScale1;

		[SerializeField]
		private bool _isStretch;

		[SerializeField]
		private bool _isFullHeight;

		[SerializeField]
		private bool _ignoreNotch;

		public void OnScaleChanged(float scale)
		{
		}
	}
}
