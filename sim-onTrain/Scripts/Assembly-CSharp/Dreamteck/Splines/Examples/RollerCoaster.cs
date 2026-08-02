using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dreamteck.Splines.Examples
{
	public class RollerCoaster : MonoBehaviour
	{
		[Serializable]
		public class CoasterSound
		{
			public float startPercent;

			public float endPercent = 1f;

			public AudioSource source;

			public float startPitch = 1f;

			public float endPitch = 1f;
		}

		public float speed = 10f;

		public float minSpeed = 1f;

		public float maxSpeed = 20f;

		public float frictionForce = 0.1f;

		public float gravityForce = 1f;

		public float slopeRange = 60f;

		private SplineFollower follower;

		public AnimationCurve speedGain;

		public AnimationCurve speedLoss;

		public float brakeSpeed;

		public float brakeReleaseSpeed;

		private float brakeTime;

		private float brakeForce;

		private float addForce;

		public CoasterSound[] sounds;

		public AudioSource brakeSound;

		public AudioSource boostSound;

		public float soundFadeLength = 0.15f;

		private void Start()
		{
			follower = GetComponent<SplineFollower>();
			follower.onEndReached += OnEndReached;
			Cursor.lockState = CursorLockMode.Locked;
		}

		private void OnEndReached(double last)
		{
			List<SplineComputer> list = new List<SplineComputer>();
			List<int> list2 = new List<int>();
			List<int> list3 = new List<int>();
			follower.spline.GetConnectedComputers(list, list2, list3, 1.0, follower.direction, includeEqual: true);
			if (list.Count == 0)
			{
				return;
			}
			for (int i = 0; i < list.Count; i++)
			{
				if (list3[i] != 0)
				{
					list.RemoveAt(i);
					list2.RemoveAt(i);
					list3.RemoveAt(i);
					i--;
				}
			}
			float distance = follower.CalculateLength(0.0, follower.result.percent);
			follower.spline = list[UnityEngine.Random.Range(0, list.Count)];
			follower.SetDistance(distance);
		}

		private void Update()
		{
			float num = Vector3.Dot(base.transform.forward, Vector3.down);
			float num2 = Mathf.Lerp((0f - slopeRange) / 90f, slopeRange / 90f, (num + 1f) / 2f);
			speed -= Time.deltaTime * frictionForce * (1f - brakeForce);
			float num3 = 0f;
			float num4 = Mathf.InverseLerp(minSpeed, maxSpeed, speed);
			num3 = ((!(num2 > 0f)) ? (gravityForce * num2 * speedLoss.Evaluate(1f - num4) * Time.deltaTime) : (gravityForce * num2 * speedGain.Evaluate(num4) * Time.deltaTime));
			speed += num3 * (1f - brakeForce);
			speed = Mathf.Clamp(speed, minSpeed, maxSpeed);
			if (addForce > 0f)
			{
				float num5 = addForce;
				addForce = Mathf.MoveTowards(addForce, 0f, Time.deltaTime * 30f);
				speed += num5 - addForce;
			}
			follower.followSpeed = speed;
			follower.followSpeed *= 1f - brakeForce;
			if (brakeTime > Time.time)
			{
				brakeForce = Mathf.MoveTowards(brakeForce, 1f, Time.deltaTime * brakeSpeed);
			}
			else
			{
				brakeForce = Mathf.MoveTowards(brakeForce, 0f, Time.deltaTime * brakeReleaseSpeed);
			}
			num4 = Mathf.Clamp01(speed / maxSpeed) * (1f - brakeForce);
			for (int i = 0; i < sounds.Length; i++)
			{
				if (num4 < sounds[i].startPercent - soundFadeLength || num4 > sounds[i].endPercent + soundFadeLength)
				{
					if (sounds[i].source.isPlaying)
					{
						sounds[i].source.Pause();
					}
					continue;
				}
				if (!sounds[i].source.isPlaying)
				{
					sounds[i].source.UnPause();
				}
				float volume = 1f;
				if (num4 < sounds[i].startPercent + soundFadeLength)
				{
					volume = Mathf.InverseLerp(sounds[i].startPercent, sounds[i].startPercent + soundFadeLength, num4);
				}
				else if (num4 > sounds[i].endPercent)
				{
					volume = Mathf.InverseLerp(sounds[i].endPercent + soundFadeLength, sounds[i].endPercent, num4);
				}
				float t = Mathf.InverseLerp(sounds[i].startPercent, sounds[i].endPercent, num4);
				sounds[i].source.volume = volume;
				sounds[i].source.pitch = Mathf.Lerp(sounds[i].startPitch, sounds[i].endPitch, t);
			}
		}

		public void AddBrake(float time)
		{
			brakeTime = Time.time + time;
			brakeSound.Stop();
			brakeSound.Play();
		}

		public void RemoveBrake()
		{
			brakeTime = 0f;
		}

		public void AddForce(float amount)
		{
			addForce = amount;
			boostSound.Stop();
			boostSound.Play();
		}
	}
}
