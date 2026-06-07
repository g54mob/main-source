using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace UMA.Examples
{
	[AddComponentMenu("Camera-Control/Mouse Orbit with zoom")]
	public class UMAMouseOrbitImproved : MonoBehaviour
	{
		public enum mouseBtnOpts
		{
			Left = 0,
			Right = 1,
			Middle = 2
		}

		public enum targetOpts
		{
			Head = 0,
			Chest = 1,
			Spine = 2,
			Hips = 3,
			LeftFoot = 4,
			LeftHand = 5,
			LeftLowerArm = 6,
			LeftLowerLeg = 7,
			LeftShoulder = 8,
			LeftUpperArm = 9,
			LeftUpperLeg = 10,
			RightFoot = 11,
			RightHand = 12,
			RightLowerArm = 13,
			RightLowerLeg = 14,
			RightShoulder = 15,
			RightUpperArm = 16,
			RightUpperLeg = 17
		}

		private class TempTransform
		{
			public Vector3 position;

			public Quaternion rotation;
		}

		[CompilerGenerated]
		private sealed class _003CSwitchTargetCoroutine_003Ed__34 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public UMAMouseOrbitImproved _003C_003E4__this;

			public Transform _dstTarget;

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
			public _003CSwitchTargetCoroutine_003Ed__34(int _003C_003E1__state)
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

		public mouseBtnOpts mouseButtonToUse;

		public Transform target;

		public float distance;

		public float xSpeed;

		public float ySpeed;

		public float scrollrate;

		public float yMinLimit;

		public float yMaxLimit;

		public float distanceMin;

		public float distanceMax;

		public Vector3 Offset;

		public bool AlwaysOn;

		public float ZoomSensitivity;

		[Tooltip("use this to enable the user to orbit the camera around the character on touchscreen devices")]
		public bool singleTouchOrbiting;

		[Tooltip("use this to enable the user to pinch to zoom the camera on touchscreen devices")]
		public bool pinchToZoom;

		public bool Clip;

		public targetOpts TargetBone;

		private string[] targetStrings;

		private UMAData umaData;

		private Rigidbody _rigidbody;

		private GameObject TargetGO;

		private bool switchingTarget;

		private float smoothing;

		private float defaultx;

		private float defaulty;

		private float defaultdistance;

		private float x;

		private float y;

		private void Start()
		{
		}

		public void Reset()
		{
		}

		public void SwitchTarget(Transform _dstTarget)
		{
		}

		[IteratorStateMachine(typeof(_003CSwitchTargetCoroutine_003Ed__34))]
		private IEnumerator SwitchTargetCoroutine(Transform _dstTarget)
		{
			return null;
		}

		private Vector3 GetTarget(Transform dstTarget = null)
		{
			return default(Vector3);
		}

		private void LateUpdate()
		{
		}

		private TempTransform UpdatePos(Transform dstTarget = null)
		{
			return null;
		}

		public static float ClampAngle(float angle, float min, float max)
		{
			return 0f;
		}
	}
}
