using UnityEngine;

namespace Assets.Scripts.Flight.GameView.Effects
{
	public class LaunchSmokeScript : MonoBehaviour
	{
		private float _intensity;

		private float _rate = 10f;

		private float _scale;

		private float _time;

		public Vector3 BaseScale { get; set; }

		public float BaseSpeed { get; set; }

		public float RotationSpeed { get; set; }

		public LaunchSmokeZoneScript Zone { get; set; }

		public void AnimateTowardsCenterOfThrust(Vector3 center)
		{
			float num = Mathf.Clamp01(2f - _time);
			Vector3 localPosition = base.transform.localPosition;
			localPosition.x = center.x;
			localPosition.z = center.z;
			base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, localPosition, Time.deltaTime * 2f * num);
		}

		public void SetIntensity(float intensity)
		{
			_intensity = intensity;
		}

		protected virtual void Start()
		{
			base.transform.localScale = Vector3.zero;
		}

		protected virtual void Update()
		{
			_scale += _rate * BaseSpeed * _intensity * Time.deltaTime;
			base.transform.localScale = BaseScale * _scale;
			base.transform.Rotate(new Vector3(0f, RotationSpeed * Time.deltaTime, 0f));
			_time += Time.deltaTime;
			if (_time > 1f)
			{
				float num = (_time - 1f) * 6f * Mathf.Clamp(_intensity, 0.05f, 1f);
				base.transform.localPosition += Vector3.down * num * BaseSpeed * Time.deltaTime;
				if (base.transform.localPosition.y < (0f - base.transform.localScale.y) * 0.5f)
				{
					Zone.RemoveSmoke(this);
				}
			}
		}
	}
}
