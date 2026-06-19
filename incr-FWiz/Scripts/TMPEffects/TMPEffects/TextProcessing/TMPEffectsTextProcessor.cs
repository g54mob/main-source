using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Text;
using TMPEffects.Tags;
using TMPro;

namespace TMPEffects.TextProcessing
{
	public class TMPEffectsTextProcessor : ITextPreprocessor, ITagProcessorManager, IEnumerable<TagProcessor>, IEnumerable
	{
		public delegate void TMPTextProcessorEventHandler(string text);

		private class Indices
		{
			public int start;

			public int end;

			public bool startSet;

			public bool endSet;

			public readonly TMPEffectTagIndices indices;

			public Indices(TMPEffectTagIndices indices)
			{
			}
		}

		private TagProcessorManager processors;

		private StringBuilder sb;

		private Stack<TMP_Style> styles;

		public TMP_Text TextComponent { get; private set; }

		public ReadOnlyDictionary<char, ReadOnlyCollection<TagProcessor>> TagProcessors => null;

		public event TMPTextProcessorEventHandler BeginPreProcess
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event TMPTextProcessorEventHandler FinishPreProcess
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event TMPTextProcessorEventHandler BeginAdjustIndices
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event TMPTextProcessorEventHandler FinishAdjustIndices
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public TMPEffectsTextProcessor(TMP_Text text)
		{
		}

		public void AddProcessor(char prefix, TagProcessor processor, int priority = 0)
		{
		}

		public bool RemoveProcessor(char prefix, TagProcessor processor)
		{
			return false;
		}

		public IEnumerator<TagProcessor> GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		public string PreprocessText(string text)
		{
			return null;
		}

		public void AdjustIndices()
		{
		}

		private bool HandleTag(ref ParsingUtility.TagInfo tagInfo, int textIndex, int order)
		{
			return false;
		}
	}
}
