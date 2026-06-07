using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Febucci.UI.Core;
using Febucci.UI.Core.Parsing;
using UnityEngine;

namespace Febucci.UI.Actions
{
	[Serializable]
	[TagInfo("waitinput")]
	[CreateAssetMenu(fileName = "WaitAnyInput Action", menuName = "Text Animator/Actions/Wait Any Input", order = 1)]
	public sealed class WaitAnyInputAction : ActionScriptableBase
	{
		[CompilerGenerated]
		private sealed class _003CDoAction_003Ed__0 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

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
			public _003CDoAction_003Ed__0(int _003C_003E1__state)
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

		[IteratorStateMachine(typeof(_003CDoAction_003Ed__0))]
		public override IEnumerator DoAction(ActionMarker action, TypewriterCore typewriter, TypingInfo typingInfo)
		{
			return null;
		}
	}
}
