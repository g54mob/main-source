using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Infrastructure.Project.Services.Curtain
{
	public class LoadingCurtain : MonoBehaviour
	{
		private sealed class bfu : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int swf;

			private object swg;

			public LoadingCurtain swh;

			private float swi;

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
			public bfu(int a)
			{
			}

			[DebuggerHidden]
			private void iqv()
			{
			}

			void IDisposable.Dispose()
			{
				//ILSpy generated this explicit interface implementation from .override directive in iqv
				this.iqv();
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
			private void iqx()
			{
			}

			void IEnumerator.Reset()
			{
				//ILSpy generated this explicit interface implementation from .override directive in iqx
				this.iqx();
			}
		}

		private sealed class bfv : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int swj;

			private object swk;

			public LoadingCurtain swl;

			private float swm;

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
			public bfv(int a)
			{
			}

			[DebuggerHidden]
			private void iqz()
			{
			}

			void IDisposable.Dispose()
			{
				//ILSpy generated this explicit interface implementation from .override directive in iqz
				this.iqz();
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
			private void irb()
			{
			}

			void IEnumerator.Reset()
			{
				//ILSpy generated this explicit interface implementation from .override directive in irb
				this.irb();
			}
		}

		[SerializeField]
		private CanvasGroup m_showBG;

		[SerializeField]
		private RectTransform m_loadingBG;

		[SerializeField]
		private RectTransform m_transitionBG;

		[SerializeField]
		private CanvasGroup m_group;

		private float swn;

		private float swo;

		private float swp;

		private float swq;

		private bool swr;

		private bool sws;

		private void Start()
		{
		}

		public void ird()
		{
		}

		[IteratorStateMachine(typeof(bfv))]
		private IEnumerator ire()
		{
			return null;
		}

		[IteratorStateMachine(typeof(bfu))]
		private IEnumerator irf()
		{
			return null;
		}

		private void irg(float a)
		{
		}
	}
}
