using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace VampireSurvivors
{
	public class UICamera : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CWaitAndCacheDefaultOrtoSize_003Ed__7 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public UICamera _003C_003E4__this;

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
			public _003CWaitAndCacheDefaultOrtoSize_003Ed__7(int _003C_003E1__state)
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

		private Camera _camera;

		private Camera _main;

		public static Camera _cameraUI;

		private static float _defaultSize;

		public static float ParticleScaleFactor => 0f;

		private void Start()
		{
		}

		[IteratorStateMachine(typeof(_003CWaitAndCacheDefaultOrtoSize_003Ed__7))]
		private IEnumerator WaitAndCacheDefaultOrtoSize()
		{
			return null;
		}

		private void Update()
		{
		}

		public static Vector3 UIToGame(Vector3 worldPos)
		{
			return default(Vector3);
		}
	}
}
