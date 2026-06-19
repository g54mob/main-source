using UnityEngine;

namespace TH20
{
	public class BuildAnimationComponent : MonoBehaviour
	{
		private float _time;

		private float _lastKeyTime;

		private AnimationCurve _curve;

		public static float GetAnimationTime(int x, int y, float speed)
		{
			return (float)(x + y) / speed;
		}

		public void StartAnimation(AnimationCurve curve, float timeOffset)
		{
			_curve = curve;
			_time = timeOffset;
			_lastKeyTime = _curve[_curve.length - 1].time;
			base.gameObject.transform.localScale = Vector3.zero;
		}

		private void Update()
		{
			_time += Time.deltaTime;
			if (_time >= _lastKeyTime)
			{
				base.gameObject.transform.localScale = Vector3.one;
				Object.Destroy(this);
			}
			else
			{
				float num = ((_time <= 0f) ? 0f : 1f);
				float f = Mathf.Max(_curve.Evaluate(_time), 0f);
				base.gameObject.transform.localScale = new Vector3(num, Mathf.Pow(f, 2f), num);
			}
		}
	}
}
