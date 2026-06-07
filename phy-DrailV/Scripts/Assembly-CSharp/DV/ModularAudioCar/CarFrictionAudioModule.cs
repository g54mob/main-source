using UnityEngine;

namespace DV.ModularAudioCar
{
	public class CarFrictionAudioModule : CarAudioModule
	{
		private const float FRICTION_SMOOTHING = 3f;

		public LayeredAudio frictionAudio;

		public float frictionVelocityMult = 1f;

		private TrainCar car;

		private float audioValue;

		public override bool ExternalUpdate
		{
			get
			{
				if (car.derailed)
				{
					if (audioValue == 0f)
					{
						return frictionAudio.GetLowestVolume() != 0f;
					}
					return true;
				}
				return false;
			}
		}

		public override void Initialize(TrainCar trainCar)
		{
			if (frictionAudio != null)
			{
				frictionAudio.Reset();
				frictionAudio.Stop();
			}
			car = trainCar;
			car.CollisionInfoDispenser.CollisionStayInfo += OnCollidedStay;
			car.CollisionInfoDispenser.CollisionExitInfo += OnCollidedExit;
			car.OnRerailed += OnRerail;
		}

		public override void Deinitialize()
		{
			audioValue = 0f;
			car.CollisionInfoDispenser.CollisionStayInfo -= OnCollidedStay;
			car.CollisionInfoDispenser.CollisionExitInfo -= OnCollidedExit;
			car.OnRerailed -= OnRerail;
			car = null;
		}

		public override void UpdateModule(float deltaTime)
		{
			frictionAudio.Set(audioValue);
		}

		private void OnCollidedExit(Collision col, bool becausePause)
		{
			audioValue = 0f;
		}

		private void OnRerail()
		{
			audioValue = 0f;
			if (frictionAudio != null)
			{
				frictionAudio.Stop();
			}
		}

		private void OnCollidedStay(Collision col, bool becausePause)
		{
			if (!becausePause)
			{
				float b = ((col.impulse.sqrMagnitude <= float.Epsilon) ? 0f : (col.relativeVelocity.magnitude * frictionVelocityMult));
				audioValue = Mathf.Lerp(audioValue, b, 3f * Time.fixedDeltaTime);
			}
		}
	}
}
