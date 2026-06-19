using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class CameraShakeEffectComponent : CameraEffect
	{
		private float _duration;

		private float _elapsed;

		private float _speed;

		private float _magnitude;

		private bool _affectPosition;

		private bool _affectRotation;

		private bool _useUnscaledTime;

		private readonly AnimationCurve damper = new AnimationCurve(new Keyframe(0f, 1f), new Keyframe(0.9f, 0.33f, -2f, -2f), new Keyframe(1f, 0f, -5.65f, -5.65f));

		public void Shake(float duration, float speed, float magnitude, bool position, bool rotation, bool useUnscaledTime = false)
		{
			_duration = duration;
			_elapsed = 0f;
			_speed = speed;
			_magnitude = magnitude;
			_affectPosition = position;
			_affectRotation = rotation;
			_useUnscaledTime = useUnscaledTime;
		}

		public override void Apply(Camera cam)
		{
			float num = (_useUnscaledTime ? Time.unscaledDeltaTime : Time.deltaTime);
			if (cam != null && num > 0f)
			{
				if (_affectPosition)
				{
					cam.transform.position += ShakePosition();
				}
				if (_affectRotation)
				{
					cam.transform.rotation *= ShakeRotation();
				}
				_elapsed += num;
				if (_elapsed >= _duration)
				{
					Object.Destroy(this);
				}
			}
		}

		private Vector3 ShakePosition()
		{
			float num = damper.Evaluate(_elapsed / _duration) * _magnitude;
			float x = Mathf.PerlinNoise(_elapsed * _speed, 0f) * num - num / 2f;
			float y = Mathf.PerlinNoise(0f, _elapsed * _speed) * num - num / 2f;
			return new Vector3(x, y, 0f);
		}

		private Quaternion ShakeRotation()
		{
			float num = damper.Evaluate(_elapsed / _duration) * _magnitude;
			float x = Mathf.PerlinNoise(_elapsed * _speed, 0f) * num - num / 2f;
			float y = Mathf.PerlinNoise(0f, _elapsed * _speed) * num - num / 2f;
			float z = Mathf.PerlinNoise(0.5f, _elapsed * _speed * 0.5f) * num - num / 2f;
			return Quaternion.Euler(new Vector3(x, y, z));
		}
	}
}
