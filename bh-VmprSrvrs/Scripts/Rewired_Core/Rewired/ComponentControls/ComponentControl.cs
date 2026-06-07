using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Rewired.ComponentControls
{
	[Serializable]
	[DisallowMultipleComponent]
	public abstract class ComponentControl : MonoBehaviour, IComponentControl
	{
		private sealed class uTIvGErzkWXVWlvNAumpyAINFeUb : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int ecROhXQHlWITeHBACqSsWlQjipqS;

			private object JLaulyVDFeSGBuqYKkyndMdupJPQ;

			public ComponentControl AULJocNqFqdoBKxuWmMnzFVyJAwf;

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
			public uTIvGErzkWXVWlvNAumpyAINFeUb(int P_0)
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

		private IComponentController _controller;

		[NonSerialized]
		private bool LlzSGMWMbIozAWwtXdbkZIexiQBm;

		[NonSerialized]
		private bool cFGfXUWVzJLkMyeXUWMzcQXmDfKe;

		private int _lastUpdateFrame;

		internal abstract bool vyrVtCzNlydzNJRdcivKgpNOfUbi { get; }

		internal bool udUUzYVhucsrTSuUTCYaWWkzrGJL => false;

		[CustomObfuscation(rename = false)]
		internal ComponentControl()
		{
		}

		public abstract void ClearValue();

		void IComponentControl.Update()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Awake()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Start()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnEnable()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDisable()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDestroy()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnValidate()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnCanvasGroupChanged()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnTransformParentChanged()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void OnDidApplyAnimationProperties()
		{
		}

		[CustomObfuscation(rename = false)]
		internal virtual void Reset()
		{
		}

		internal virtual void HFvohMUOstAUOCfejghrHDohTlWob()
		{
		}

		internal virtual bool kCMMqxCXpgLJLruKfzlhHdqYwqkJ()
		{
			return false;
		}

		internal virtual void ovQttAnDCMvdhhOqGlwLyWzBptAN()
		{
		}

		internal virtual void HzbXIgvDEecKGiVrHsiaugTjTUln()
		{
		}

		internal virtual void noSANRUEqtKuHmySzautBIlAHAWcA()
		{
		}

		internal virtual void GTRDyimMWaAVahmkfoYBnobmVDON()
		{
		}

		internal virtual void nvUORnqFfBpcibUOpygLfKlyxCZD()
		{
		}

		internal virtual void zwkdLoCQYQUJBkkwofvYaZBZJijLA()
		{
		}

		internal bool FEZyLcEJynkvxRDuujtkpuaRxmGm()
		{
			return false;
		}

		internal bool ivnyrTndsfaviuzGuswpZVRibosK()
		{
			return false;
		}

		internal IComponentController mdhyfCTwiwatLzpxzVoceLqQAKdBA()
		{
			return null;
		}

		[CustomObfuscation(rename = false)]
		internal abstract IComponentController FindController();

		[CustomObfuscation(rename = false)]
		internal abstract Type GetRequiredControllerType();

		[IteratorStateMachine(typeof(uTIvGErzkWXVWlvNAumpyAINFeUb))]
		private IEnumerator BMgDURuOImAuwazrwXWUgIrSLBbL()
		{
			return null;
		}

		private void BgVuEwtgVKyeJECrgDCftxJocGXj()
		{
		}

		private bool uOYKbBtjpwmFzRobfHUNugRGluWm(bool P_0, bool P_1)
		{
			return false;
		}

		private void QcMQLHJJRuqEBkWBvIewIbyghWYU()
		{
		}

		private void SDFsmeimDzWdtpImJGPjonSJDpzw()
		{
		}
	}
}
