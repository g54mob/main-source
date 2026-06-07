using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace Gh.Tk
{
	public class OutlineOverlay3DUIView : MonoBehaviour
	{
		[Header("Outline")]
		[SerializeField]
		private RectTransform _outlineTransform;

		public float maxOffset;

		public float minOffset;

		public float durationSeconds;

		public Ease easing;

		private float _currentOffset;

		private TweenerCore<float, float, FloatOptions> _tween;

		private void OnEnable()
		{
		}

		private void SetOffset(float offset)
		{
		}
	}
}
