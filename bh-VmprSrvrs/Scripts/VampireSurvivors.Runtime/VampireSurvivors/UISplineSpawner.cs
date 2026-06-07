using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Dreamteck.Splines;
using UnityEngine;

namespace VampireSurvivors
{
	public class UISplineSpawner : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CDoSpawning_003Ed__12 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public UISplineSpawner _003C_003E4__this;

			private int _003Ccount_003E5__2;

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
			public _003CDoSpawning_003Ed__12(int _003C_003E1__state)
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

		[SerializeField]
		private UISplineFollower _ContentToSpawn;

		private SplineComputer _spline;

		private float _interval;

		private float _duration;

		private float _currentTime;

		private float _intervalTime;

		private float _speed;

		private float _delay;

		private RectTransform _container;

		private List<UISplineFollower> _spawned;

		public void SetContainer(RectTransform rTran)
		{
		}

		public void StartSpawning(SplineComputer spline, float interval, float duration, float speed, float delay = 0f)
		{
		}

		[IteratorStateMachine(typeof(_003CDoSpawning_003Ed__12))]
		private IEnumerator DoSpawning()
		{
			return null;
		}

		private void OnDestroy()
		{
		}

		public void Clear()
		{
		}
	}
}
