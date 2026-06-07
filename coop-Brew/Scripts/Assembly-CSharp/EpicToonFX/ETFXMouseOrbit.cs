using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace EpicToonFX
{
	public class ETFXMouseOrbit : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CAutoRotate_003Ed__25 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ETFXMouseOrbit _003C_003E4__this;

			private int _003ClerpSteps_003E5__2;

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
			public _003CAutoRotate_003Ed__25(int _003C_003E1__state)
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

		public Transform target;

		public float distance;

		public float xSpeed;

		public float ySpeed;

		public float yMinLimit;

		public float yMaxLimit;

		public float distanceMin;

		public float distanceMax;

		public float smoothTime;

		private float rotationYAxis;

		private float rotationXAxis;

		private float velocityX;

		private float maxVelocityX;

		private float velocityY;

		private readonly float autoRotationSmoothing;

		[HideInInspector]
		public bool isAutoRotating;

		[HideInInspector]
		public ETFXEffectController etfxEffectController;

		[HideInInspector]
		public ETFXEffectControllerPooled etfxEffectControllerPooled;

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void FixedUpdate()
		{
		}

		public static float ClampAngle(float angle, float min, float max)
		{
			return 0f;
		}

		public void InitializeAutoRotation()
		{
		}

		public void SetAutoRotationSpeed(float rotationSpeed)
		{
		}

		private void StopAutoRotation()
		{
		}

		[IteratorStateMachine(typeof(_003CAutoRotate_003Ed__25))]
		private IEnumerator AutoRotate()
		{
			return null;
		}
	}
}
