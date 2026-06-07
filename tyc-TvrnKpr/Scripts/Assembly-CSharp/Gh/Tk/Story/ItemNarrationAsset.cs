using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Gh.Tk.Story.Narrative;
using UnityEngine;

namespace Gh.Tk.Story
{
	[CreateAssetMenu(fileName = "ItemNarrationAsset", menuName = "Greenheart Custom/Story/Config/ItemNarrationAsset")]
	public class ItemNarrationAsset : ScriptableObjectX
	{
		[CompilerGenerated]
		private sealed class _003CGenerateParts_003Ed__3 : IEnumerable<VoiceOverPart>, IEnumerable, IEnumerator<VoiceOverPart>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private VoiceOverPart _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public ItemNarrationAsset _003C_003E4__this;

			private string language;

			public string _003C_003E3__language;

			private ItemNarrationConfig[] _003C_003E7__wrap1;

			private int _003C_003E7__wrap2;

			private VoiceOverType _003CvoType_003E5__4;

			private string[] _003C_003E7__wrap4;

			private int _003C_003E7__wrap5;

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
			public _003CGenerateParts_003Ed__3(int _003C_003E1__state)
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

		public ItemNarrationConfig[] items;

		private const string _narrationsUsedKey = "narrationsUsed";

		public (string, NarrationType, AdvisorState) GetPick(IDataStore narrationUsedStore, ISelectable obj)
		{
			return default((string, NarrationType, AdvisorState));
		}

		[IteratorStateMachine(typeof(_003CGenerateParts_003Ed__3))]
		public override IEnumerable<VoiceOverPart> GenerateParts(string language)
		{
			return null;
		}
	}
}
