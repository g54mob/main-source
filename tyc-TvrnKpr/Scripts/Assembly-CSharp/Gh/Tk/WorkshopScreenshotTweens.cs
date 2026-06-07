using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Gh.Tk
{
	public class WorkshopScreenshotTweens : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CShowScreenshotCoroutine_003Ed__16 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public WorkshopScreenshotTweens _003C_003E4__this;

			public int index;

			private ResourceRequest _003CscreenshotRequest_003E5__2;

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
			public _003CShowScreenshotCoroutine_003Ed__16(int _003C_003E1__state)
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

		private string _screenshotsPath;

		public string[] screenshotNames;

		private GameObject[] _screenshots;

		public float minTimeToChange;

		public float maxTimeToChange;

		private float _currentTime;

		private int _currentIndex;

		private float _nextChangeTime;

		private bool _isLoading;

		private void Awake()
		{
		}

		private void OnResetUI(object sender, EventArgs e)
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void ResetLoop()
		{
		}

		private void Update()
		{
		}

		private void ShowScreenshot(int index)
		{
		}

		[IteratorStateMachine(typeof(_003CShowScreenshotCoroutine_003Ed__16))]
		private IEnumerator ShowScreenshotCoroutine(int index)
		{
			return null;
		}

		private void UpdateActiveScreenshot()
		{
		}
	}
}
