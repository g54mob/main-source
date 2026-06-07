using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Gh.Tk.Story
{
	public abstract class ScriptableObjectX : ScriptableObject, IVoiceOverContentSource
	{
		[CompilerGenerated]
		private sealed class _003CGenerateParts_003Ed__1 : IEnumerable<VoiceOverPart>, IEnumerable, IEnumerator<VoiceOverPart>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private VoiceOverPart _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			VoiceOverPart IEnumerator<VoiceOverPart>.Current
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
			public _003CGenerateParts_003Ed__1(int _003C_003E1__state)
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

			[DebuggerHidden]
			IEnumerator<VoiceOverPart> IEnumerable<VoiceOverPart>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		public virtual void GenerateI18nEntries(string context)
		{
		}

		[IteratorStateMachine(typeof(_003CGenerateParts_003Ed__1))]
		public virtual IEnumerable<VoiceOverPart> GenerateParts(string language)
		{
			return null;
		}
	}
}
