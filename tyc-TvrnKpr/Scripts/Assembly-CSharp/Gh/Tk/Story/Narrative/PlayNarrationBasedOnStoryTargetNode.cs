using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using XNode;

namespace Gh.Tk.Story.Narrative
{
	[NodeTint("#466969")]
	public class PlayNarrationBasedOnStoryTargetNode : ConnectedStoryNode, IVoiceOverContentSource
	{
		[CompilerGenerated]
		private sealed class _003CGenerateParts_003Ed__2 : IEnumerable<VoiceOverPart>, IEnumerable, IEnumerator<VoiceOverPart>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private VoiceOverPart _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public PlayNarrationBasedOnStoryTargetNode _003C_003E4__this;

			private string language;

			public string _003C_003E3__language;

			private ItemNarrationConfig[] _003C_003E7__wrap1;

			private int _003C_003E7__wrap2;

			private VoiceOverType _003CvoType_003E5__4;

			private string _003CtranslationComment_003E5__5;

			private string[] _003C_003E7__wrap5;

			private int _003C_003E7__wrap6;

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
			public _003CGenerateParts_003Ed__2(int _003C_003E1__state)
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

		public ItemNarrationAsset itemNarrationConfig;

		public override void OnTrigger(ActiveStory story)
		{
		}

		[IteratorStateMachine(typeof(_003CGenerateParts_003Ed__2))]
		public IEnumerable<VoiceOverPart> GenerateParts(string language)
		{
			return null;
		}

		protected override void GenerateI18nEntriesInternal(string context)
		{
		}
	}
}
