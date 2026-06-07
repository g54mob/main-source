using UnityEngine;

namespace Gh.Tk
{
	public class MouseParallax2DImage : MonoBehaviour
	{
		public Button3DUIView button;

		public float rangeMultiplier;

		public float lerpInMultiplier;

		public AnimationCurve curveIn;

		public float lerpOutMultiplier;

		public AnimationCurve curveOut;

		private bool _allowUpdate;

		private Vector2 _currentOffset;

		private float _lerpTime;

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		private void Button_OnIsHoveredChanged(object sender, EventArgs<bool> e)
		{
		}

		private void Update()
		{
		}
	}
}
