using JUTPSEditor.JUHeader;
using UnityEngine;

namespace JUTPS.VehicleSystem
{
	[AddComponentMenu("JU TPS/Vehicle System/JU Vehicle Engine Sound")]
	public class JUVehicleEngineSound : MonoBehaviour
	{
		[JUHeader("Start Motor Audio Settings")]
		public AudioSource StartMotorAudioSource;

		public AudioClip StartMotorAudioClip;

		[JUHeader("Idle Motor Audio Settings")]
		public AudioSource MotorLoopAudioSource;

		public AudioClip MotorLoopAudioClip;

		[Range(0f, 1f)]
		public float IdleVolume = 0.7f;

		[Range(0f, 1f)]
		public float AccelerateVolume = 1f;

		[Range(-3f, 3f)]
		public float IdlePitch = 1f;

		[Range(-3f, 3f)]
		public float AcceleratePitch = 2f;

		public float AccelerateSpeed = 5f;

		public float DecelerateSpeed = 2f;

		public float StartDelay = 1f;

		[JUHeader("Stop Motor Audio Settings")]
		[Range(-3f, 3f)]
		public float StoppingPitch = 0.3f;

		public float StoppingSpeed = 1f;

		private Vehicle vehicle;

		private bool startedMotor;

		private bool motorOff;

		private void Start()
		{
			vehicle = GetComponent<Vehicle>();
			TurnOffMotor();
		}

		private void Update()
		{
			if (!MotorLoopAudioSource)
			{
				return;
			}
			if (vehicle.IsOn)
			{
				bool flag = vehicle.GetVerticalInput() > 0f;
				bool flag2 = vehicle.GetVerticalInput() < 0f;
				float magnitude = new Vector2(vehicle.GetHorizontalInput(), vehicle.GetVerticalInput()).magnitude;
				if (!startedMotor)
				{
					TurnOnMotor();
				}
				if (MotorLoopAudioSource.isPlaying)
				{
					float num = Mathf.Abs(AcceleratePitch - IdlePitch);
					float b = (flag ? (magnitude * AcceleratePitch) : (flag2 ? (IdlePitch + num / 2f) : IdlePitch));
					float b2 = (flag ? (magnitude * AccelerateVolume) : IdleVolume);
					MotorLoopAudioSource.pitch = Mathf.Lerp(MotorLoopAudioSource.pitch, b, (flag ? AccelerateSpeed : DecelerateSpeed) * Time.deltaTime);
					MotorLoopAudioSource.volume = Mathf.Lerp(MotorLoopAudioSource.volume, b2, (flag ? AccelerateSpeed : DecelerateSpeed) * Time.deltaTime);
				}
			}
			else if (!motorOff)
			{
				MotorLoopAudioSource.pitch = Mathf.MoveTowards(MotorLoopAudioSource.pitch, StoppingPitch, StoppingSpeed * Time.deltaTime);
				MotorLoopAudioSource.volume = Mathf.MoveTowards(MotorLoopAudioSource.volume, 0f, StoppingSpeed * Time.deltaTime);
				if (MotorLoopAudioSource.volume == 0f)
				{
					TurnOffMotor();
				}
			}
		}

		private void TurnOnMotor()
		{
			if (!startedMotor)
			{
				if ((bool)StartMotorAudioSource && (bool)StartMotorAudioClip)
				{
					StartMotorAudioSource.PlayOneShot(StartMotorAudioClip);
					StartMotorAudioSource.loop = false;
				}
				if ((bool)MotorLoopAudioSource && (bool)MotorLoopAudioClip)
				{
					MotorLoopAudioSource.clip = MotorLoopAudioClip;
					MotorLoopAudioSource.volume = 0f;
					MotorLoopAudioSource.loop = true;
					MotorLoopAudioSource.PlayDelayed(StartDelay);
				}
				motorOff = false;
				startedMotor = true;
			}
		}

		private void TurnOffMotor()
		{
			if (!motorOff)
			{
				MotorLoopAudioSource.volume = 0f;
				MotorLoopAudioSource.Stop();
				startedMotor = false;
				motorOff = true;
			}
		}
	}
}
