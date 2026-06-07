using System.Collections.Generic;
using MoreMountains.Feedbacks;
using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.Feel
{
	[AddComponentMenu("")]
	public class Falcon : MonoBehaviour
	{
		[Header("Input")]
		[Tooltip("a key to use to jump")]
		public KeyCode ActionKey = KeyCode.Space;

		[Tooltip("a secondary key to use to jump")]
		public KeyCode ActionKeyAlt = KeyCode.Joystick1Button0;

		[Header("Bindings")]
		[Tooltip("the various wigglers that make the car move")]
		public List<MMWiggle> Wigglers;

		[Tooltip("the wiggler associated to the camera")]
		public MMWiggle CameraWiggler;

		[Tooltip("the ground's panning texture")]
		public MMPanningTexture Offsetter;

		[Tooltip("the particles that are supposed to loop (rocks etc)")]
		public List<ParticleSystem> ParticleLoops;

		[Tooltip("the on/off emitters (wind, smoke)")]
		public List<ParticleSystem> ParticleEmitters;

		[Tooltip("the wheels' auto rotators")]
		public List<MMAutoRotate> AutoRotaters;

		[Header("Settings")]
		[Tooltip("the speed at which the wheel should rotate")]
		public float RotationSpeed = 20f;

		[Header("Feedbacks")]
		[Tooltip("a feedback to call when the car starts driving")]
		public MMFeedbacks DriveFeedback;

		[Tooltip("a feedback to call when the car stops")]
		public MMFeedbacks StopFeedback;

		protected bool _turning;

		protected virtual void Start()
		{
			SetCar(status: false);
		}

		protected virtual void SetCar(bool status)
		{
			foreach (MMWiggle wiggler in Wigglers)
			{
				wiggler.PositionActive = status;
			}
			foreach (ParticleSystem particleEmitter in ParticleEmitters)
			{
				if (status)
				{
					particleEmitter.Play();
				}
				else
				{
					particleEmitter.Stop();
				}
			}
			foreach (ParticleSystem particleLoop in ParticleLoops)
			{
				if (status)
				{
					particleLoop.Play();
				}
				else
				{
					particleLoop.Pause();
				}
			}
			foreach (MMAutoRotate autoRotater in AutoRotaters)
			{
				autoRotater.Rotating = status;
			}
			Offsetter.TextureShouldPan = status;
			CameraWiggler.PositionActive = status;
			CameraWiggler.RotationActive = status;
		}

		protected virtual void Update()
		{
			HandleInput();
			HandleCar();
		}

		protected virtual void HandleInput()
		{
			if (FeelDemosInputHelper.CheckMainActionInputPressed())
			{
				Drive();
			}
			if (FeelDemosInputHelper.CheckMainActionInputUpThisFrame())
			{
				TurnStop();
			}
		}

		protected virtual void HandleCar()
		{
			_ = _turning;
		}

		protected virtual void Drive()
		{
			if (!_turning)
			{
				DriveFeedback?.PlayFeedbacks();
				SetCar(status: true);
			}
			_turning = true;
		}

		protected virtual void TurnStop()
		{
			DriveFeedback?.StopFeedbacks();
			StopFeedback?.PlayFeedbacks();
			SetCar(status: false);
			_turning = false;
		}
	}
}
