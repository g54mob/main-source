using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace TMPEffects.TextProcessing
{
	public class TagProcessorManager : ITagProcessorManager, IEnumerable<TagProcessor>, IEnumerable
	{
		[CompilerGenerated]
		private sealed class _003CGetEnumerator_003Ed__10 : IEnumerator<TagProcessor>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private TagProcessor _003C_003E2__current;

			public TagProcessorManager _003C_003E4__this;

			private Dictionary<char, List<TagProcessor>>.ValueCollection.Enumerator _003C_003E7__wrap1;

			private List<TagProcessor>.Enumerator _003C_003E7__wrap2;

			TagProcessor IEnumerator<TagProcessor>.Current
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
			public _003CGetEnumerator_003Ed__10(int _003C_003E1__state)
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
		}

		private Dictionary<char, List<TagProcessor>> tagProcessors;

		private Dictionary<char, ReadOnlyCollection<TagProcessor>> tagProcessorsRO;

		public ReadOnlyDictionary<char, ReadOnlyCollection<TagProcessor>> TagProcessors { get; private set; }

		public void AddProcessor(char prefix, TagProcessor processor, int priority = 0)
		{
		}

		public bool RemoveProcessor(char prefix, TagProcessor processor)
		{
			return false;
		}

		public void Clear()
		{
		}

		public void RegisterTo(TMPEffectsTextProcessor textProcessor)
		{
		}

		public void UnregisterFrom(TMPEffectsTextProcessor textProcessor)
		{
		}

		[IteratorStateMachine(typeof(_003CGetEnumerator_003Ed__10))]
		public IEnumerator<TagProcessor> GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}
}
