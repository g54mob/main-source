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
	[CreateAssetMenu(fileName = "Speed Action", menuName = "Text Animator/Actions/Speed", order = 1)]
	[TagInfo("speed")]
	public sealed class SpeedAction : ActionScriptableBase
	{
		[CompilerGenerated]
		private sealed class _003CDoAction_003Ed__1 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SpeedAction _003C_003E4__this;

			public ActionMarker action;

			public TypingInfo typingInfo;

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
			public _003CDoAction_003Ed__1(int _003C_003E1__state)
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

		[Tooltip("Speed used in case the action does not have the first parameter")]
		public float defaultSpeed;

		[IteratorStateMachine(typeof(_003CDoAction_003Ed__1))]
		public override IEnumerator DoAction(ActionMarker action, TypewriterCore typewriter, TypingInfo typingInfo)
		{
			return null;
		}
	}
}
