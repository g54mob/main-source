using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using NodeCanvas.Framework;
using UnityEngine;

namespace __Project__.Scripts.BT.CustomerHelperTasks.Actions
{
	public class StartHelpScale : ActionTask
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass6_0
		{
			public Scale scale;

			public Func<bool> _003C_003E9__1;

			internal bool _003CHandleWeighing_003Eb__0()
			{
				return false;
			}

			internal bool _003CHandleWeighing_003Eb__1()
			{
				return false;
			}
		}

		[CompilerGenerated]
		private sealed class _003CEnterKeys_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Scale scale;

			public ProductPaperBag productInstance;

			public StartHelpScale _003C_003E4__this;

			private string _003Cstr_003E5__2;

			private int _003Ci_003E5__3;

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
			public _003CEnterKeys_003Ed__8(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CHandleWeighing_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public StartHelpScale _003C_003E4__this;

			private _003C_003Ec__DisplayClass6_0 _003C_003E8__1;

			private CustomerHelper _003CcustomerHelper_003E5__2;

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
			public _003CHandleWeighing_003Ed__6(int _003C_003E1__state)
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

		private Coroutine m_Coroutine;

		public BBParameter<ICustomerHelperControllable> Scale;

		protected override void OnExecute()
		{
		}

		protected override void OnUpdate()
		{
		}

		protected override void OnStop()
		{
		}

		private float GetActionDelay()
		{
			return 0f;
		}

		[IteratorStateMachine(typeof(_003CHandleWeighing_003Ed__6))]
		private IEnumerator HandleWeighing()
		{
			return null;
		}

		private void PlayInteractionAnimation()
		{
		}

		[IteratorStateMachine(typeof(_003CEnterKeys_003Ed__8))]
		private IEnumerator EnterKeys(Scale scale, ProductPaperBag productInstance)
		{
			return null;
		}
	}
}
