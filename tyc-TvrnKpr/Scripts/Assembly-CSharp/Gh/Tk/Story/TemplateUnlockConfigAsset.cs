using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Gh.Tk.Story
{
	[CreateAssetMenu(fileName = "ItemNarrationAsset", menuName = "Greenheart Custom/Story/Config/TemplateUnlockConfigAsset")]
	public class TemplateUnlockConfigAsset : ScriptableObjectX
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass1_0
		{
			public float tavernStar;

			public ListPoolX.DisposablePooledList<string> unlockedProps;

			public DictionaryPoolX.DisposableDictionary<string, IGrouping<string, TemplateItemUnlockConfig>> propGroups;
		}

		[CompilerGenerated]
		private sealed class _003CGetPossiblePropUnlocks_003Ed__1 : IEnumerable<(string, int)>, IEnumerable, IEnumerator<(string, int)>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private (string propKey, int weighting) _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public TemplateUnlockConfigAsset _003C_003E4__this;

			private _003C_003Ec__DisplayClass1_0 _003C_003E8__1;

			private TemplateItemUnlockConfig[] _003C_003E7__wrap1;

			private int _003C_003E7__wrap2;

			(string, int) IEnumerator<(string, int)>.Current
			{
				[DebuggerHidden]
				get
				{
					return default((string, int));
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
			public _003CGetPossiblePropUnlocks_003Ed__1(int _003C_003E1__state)
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

			private void _003C_003Em__Finally1()
			{
			}

			private void _003C_003Em__Finally2()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<(string, int)> IEnumerable<(string, int)>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		public TemplateItemUnlockConfig[] items;

		[IteratorStateMachine(typeof(_003CGetPossiblePropUnlocks_003Ed__1))]
		public IEnumerable<(string, int)> GetPossiblePropUnlocks()
		{
			return null;
		}
	}
}
