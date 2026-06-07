using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

namespace Gh.Tk
{
	public static class VoiceOverHighlightsExtensions
	{
		public class HighlightTextFadeOutAction
		{
			private readonly Action _action;

			public HighlightTextFadeOutAction(Action action)
			{
			}

			public void FadeOut()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CGetInteractiveFictionLines_003Ed__1 : IEnumerable<TMP_CharacterInfo[]>, IEnumerable, IEnumerator<TMP_CharacterInfo[]>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private TMP_CharacterInfo[] _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private TMP_Text text;

			public TMP_Text _003C_003E3__text;

			private List<TMP_CharacterInfo> _003CcurrentLine_003E5__2;

			private TMP_CharacterInfo[] _003C_003E7__wrap2;

			private int _003C_003E7__wrap3;

			TMP_CharacterInfo[] IEnumerator<TMP_CharacterInfo[]>.Current
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
			public _003CGetInteractiveFictionLines_003Ed__1(int _003C_003E1__state)
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
			IEnumerator<TMP_CharacterInfo[]> IEnumerable<TMP_CharacterInfo[]>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		public static string[] GetInteractiveFictionLines(this string text)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CGetInteractiveFictionLines_003Ed__1))]
		public static IEnumerable<TMP_CharacterInfo[]> GetInteractiveFictionLines(this TMP_Text text)
		{
			return null;
		}

		public static HighlightTextFadeOutAction HighlightLine(this TMP_Text text, TMP_CharacterInfo[] characters, GameObject characterHighlightParticlePrefab, float voiceOverTextStaggerTextDuration = 0.8f)
		{
			return null;
		}

		private static HighlightTextFadeOutAction HighlightCharacter(this TMP_Text text, TMP_CharacterInfo charInfo, float delay, GameObject characterHighlightParticlePrefab)
		{
			return null;
		}
	}
}
