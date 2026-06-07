using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivors.UI
{
	public class AspectMask : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CWait_003Ed__29 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public AspectMask _003C_003E4__this;

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
			public _003CWait_003Ed__29(int _003C_003E1__state)
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
		private RectTransform _Top;

		[SerializeField]
		private RectTransform _Bottom;

		[SerializeField]
		private RectTransform _Left;

		[SerializeField]
		private RectTransform _Right;

		[SerializeField]
		private Canvas _Canvas;

		private RectTransform _rectTransform;

		private AspectRatioFitter _fitter;

		private int _prevWidth;

		private int _prevHeight;

		public static AspectMask Instance { get; private set; }

		public RectTransform Top => null;

		public RectTransform Bottom => null;

		public RectTransform Left => null;

		public RectTransform Right => null;

		private void Awake()
		{
		}

		public void Enable()
		{
		}

		public void Disable()
		{
		}

		private void SetImageEnabled(RectTransform obj, bool isEnabled)
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void OnResize()
		{
		}

		private void SetImageAlpha(Image image, float alpha)
		{
		}

		[IteratorStateMachine(typeof(_003CWait_003Ed__29))]
		private IEnumerator Wait()
		{
			return null;
		}

		private void CalculateHeight()
		{
		}

		private void CalculateWidth()
		{
		}
	}
}
