using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PolyStang
{
	public class CarController : MonoBehaviour
	{
		public enum Axel
		{
			Front = 0,
			Rear = 1
		}

		[Serializable]
		public struct Wheel
		{
			public WheelCollider wheelCollider;

			public Axel axel;
		}

		public enum TypeOfSpeedLimit
		{
			noSpeedLimit = 0,
			simple = 1,
			squareRoot = 2
		}

		[CompilerGenerated]
		private sealed class _003CDisableTheTriggerColliderAfterDealy_003Ed__44 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CarController _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CDisableTheTriggerColliderAfterDealy_003Ed__44(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CResetingTrollerPosition_003Ed__41 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CarController _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CResetingTrollerPosition_003Ed__41(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[Header("Accelerations and deaccelerations")]
		public float maxAcceleration;

		public float brakeAcceleration;

		public float torqueMultiplier;

		public float noInputDeacceleration;

		[Header("Steering")]
		public float turnSensitivity;

		public float maxSteerAngle;

		[Header("Speed limit")]
		public float frontMaxSpeed;

		public float rearMaxSpeed;

		public float empiricalCoefficient;

		public TypeOfSpeedLimit typeOfSpeedLimit;

		private float frontSpeedReducer;

		private float rearSpeedReducer;

		[Header("Audio")]
		[SerializeField]
		private float minPitch;

		[SerializeField]
		private float maxPitch;

		[SerializeField]
		private float pitchMultiplier;

		private AudioSource carAudioSource;

		[Header("Impact")]
		[SerializeField]
		private float minImpactVelocity;

		[SerializeField]
		private float impactSoundCooldown;

		private float lastImpactTime;

		[Header("General")]
		public Vector3 _centerOfMass;

		public List<Wheel> wheels;

		private Vector2 move;

		private Rigidbody carRb;

		private Action<InputAction.CallbackContext> movePerformed;

		private Action<InputAction.CallbackContext> dropPerformed;

		private InputController inputManager;

		private bool isPlayerDriving;

		[SerializeField]
		private Transform playerSeat;

		[SerializeField]
		private TrolleyTrigger trolleyTrigger;

		private void Start()
		{
		}

		private void FixedUpdate()
		{
		}

		private void Move()
		{
		}

		private void Steer()
		{
		}

		private void BrakeAndDeacceleration()
		{
		}

		public void TakeTheWheel()
		{
		}

		private void LeaveTheTrolley()
		{
		}

		public void StopCar()
		{
		}

		public void ResetTrolleyPosition()
		{
		}

		[IteratorStateMachine(typeof(_003CResetingTrollerPosition_003Ed__41))]
		private IEnumerator ResetingTrollerPosition()
		{
			return null;
		}

		private void HandleAudio()
		{
		}

		private void TurnOffCollidersInTrolley()
		{
		}

		[IteratorStateMachine(typeof(_003CDisableTheTriggerColliderAfterDealy_003Ed__44))]
		private IEnumerator DisableTheTriggerColliderAfterDealy()
		{
			return null;
		}

		private void TurnBackOnCollidersInTRolley()
		{
		}

		private void OnCollisionEnter(Collision collision)
		{
		}

		private void OnDestroy()
		{
		}
	}
}
