using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using RootMotion.FinalIK;
using UnityEngine;

namespace RootMotion.Demos
{
	public class MechSpiderLeg : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CStep_003Ed__33 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public MechSpiderLeg _003C_003E4__this;

			public Vector3 stepStartPosition;

			public Vector3 targetPosition;

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
			public _003CStep_003Ed__33(int _003C_003E1__state)
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

		public MechSpider mechSpider;

		public MechSpiderLeg unSync;

		public Vector3 offset;

		public float minDelay;

		public float maxOffset;

		public float stepSpeed;

		public float footHeight;

		public float velocityPrediction;

		public float raycastFocus;

		public AnimationCurve yOffset;

		public Transform foot;

		public Vector3 footUpAxis;

		public float footRotationSpeed;

		public ParticleSystem sand;

		private IK ik;

		private float stepProgress;

		private float lastStepTime;

		private Vector3 defaultPosition;

		private RaycastHit hit;

		private Quaternion lastFootLocalRotation;

		private Vector3 smoothHitNormal;

		private Vector3 lastStepPosition;

		public bool isStepping => false;

		public Vector3 position
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		private void Awake()
		{
		}

		private void AfterIK()
		{
		}

		private void Start()
		{
		}

		private Vector3 GetStepTarget(out bool stepFound, float focus, float distance)
		{
			stepFound = default(bool);
			return default(Vector3);
		}

		private void UpdatePosition(float distance)
		{
		}

		private void Update()
		{
		}

		[IteratorStateMachine(typeof(_003CStep_003Ed__33))]
		private IEnumerator Step(Vector3 stepStartPosition, Vector3 targetPosition)
		{
			return null;
		}
	}
}
