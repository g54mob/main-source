using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Doozy.Engine.Touchy
{
	[AddComponentMenu("Doozy/Touchy/Gesture Listener", 13)]
	[DefaultExecutionOrder(-100)]
	public class GestureListener : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CSendGameEventsInTheNextFrame_003Ed__25 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public GestureListener _003C_003E4__this;

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
			public _003CSendGameEventsInTheNextFrame_003Ed__25(int _003C_003E1__state)
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

		public bool DebugMode;

		public bool GlobalListener;

		public bool OverrideTarget;

		public GameObject TargetGameObject;

		public GestureType GestureType;

		public Swipe SwipeDirection;

		public TouchInfoEvent OnGestureEvent;

		public Action<TouchInfo> OnGestureAction;

		public List<string> GameEvents;

		private static TouchySettings Settings => null;

		private bool DebugComponent => false;

		private void Reset()
		{
		}

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void RegisterToTouchDetector()
		{
		}

		private void UnregisterFromTouchDetector()
		{
		}

		private void HandleTap(TouchInfo touchInfo)
		{
		}

		private void HandleLongTap(TouchInfo touchInfo)
		{
		}

		private void HandleSwipe(TouchInfo touchInfo)
		{
		}

		private bool HasValidTarget(TouchInfo touchInfo)
		{
			return false;
		}

		private void TriggerListener(TouchInfo touchInfo)
		{
		}

		private void SendGameEvents()
		{
		}

		[IteratorStateMachine(typeof(_003CSendGameEventsInTheNextFrame_003Ed__25))]
		private IEnumerator SendGameEventsInTheNextFrame()
		{
			return null;
		}

		private static GestureListener AddToScene(bool selectGameObjectAfterCreation = false)
		{
			return null;
		}

		private static GestureListener AddToScene(GameObject parent, bool selectGameObjectAfterCreation = false)
		{
			return null;
		}
	}
}
