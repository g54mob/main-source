using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening;
using Gh.Tk;
using UnityEngine;

namespace Gh
{
	public class ThrowProjectiles : MonoBehaviour
	{
		public enum FaceAxis
		{
			X = 0,
			Y = 1,
			Z = 2
		}

		[CompilerGenerated]
		private sealed class _003CAnimateObject_003Ed__31 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public GameObjectX gox;

			public ThrowProjectiles _003C_003E4__this;

			public Action finishedCallback;

			private Transform _003ColdParent_003E5__2;

			private Transform _003CgoxTransform_003E5__3;

			private GameObject _003Cpivot_003E5__4;

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
			public _003CAnimateObject_003Ed__31(int _003C_003E1__state)
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

		public bool useSpawnPoint;

		public Transform spawnPoint;

		public Transform endPoint;

		public float arcHeight;

		public Ease arcEase;

		public float animationTime;

		public Vector3 centerOffset;

		public FaceAxis facingAxis;

		public bool randomizeStartPosition;

		public Vector3 positiveSpawnBounds;

		public Vector3 negativeSpawnBounds;

		public bool randomizeEndPosition;

		public Vector3 positiveEndBounds;

		public Vector3 negativeEndBounds;

		public Vector3 pivotTweenRotation;

		public bool randomiseEndRotation;

		public Vector3 endRotationNegative;

		public Vector3 endRotationPositive;

		public bool scaleUpFromZeroOnSpawn;

		public Ease scaleUpFromZeroEase;

		public float scaleUpFromZeroTime;

		public bool scaleSquashOnEnd;

		private Vector3 _startPoint;

		private Vector3 _endPoint;

		public Dictionary<string, TweenCallback> callbacks { get; set; }

		public void Awake()
		{
		}

		private TweenCallback GetCallback(string callback)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CAnimateObject_003Ed__31))]
		public IEnumerator AnimateObject(GameObjectX gox, Action finishedCallback = null)
		{
			return null;
		}
	}
}
