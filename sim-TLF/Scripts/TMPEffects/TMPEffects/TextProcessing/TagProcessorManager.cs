using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TMPEffects.TextProcessing
{
	public class TagProcessorManager : ITagProcessorManager, IEnumerable<TagProcessor>, IEnumerable
	{
		private Dictionary<char, List<TagProcessor>> tagProcessors;

		private Dictionary<char, ReadOnlyCollection<TagProcessor>> tagProcessorsRO;

		public ReadOnlyDictionary<char, ReadOnlyCollection<TagProcessor>> TagProcessors { get; private set; }

		public TagProcessorManager()
		{
			tagProcessors = new Dictionary<char, List<TagProcessor>>();
			tagProcessorsRO = new Dictionary<char, ReadOnlyCollection<TagProcessor>>();
			TagProcessors = new ReadOnlyDictionary<char, ReadOnlyCollection<TagProcessor>>(tagProcessorsRO);
		}

		public void AddProcessor(char prefix, TagProcessor processor, int priority = 0)
		{
			if (processor == null)
			{
				throw new ArgumentNullException("processor");
			}
			if (tagProcessors.TryGetValue(prefix, out var value))
			{
				if (priority > value.Count || priority < 0)
				{
					value.Add(processor);
				}
				else
				{
					value.Insert(priority, processor);
				}
			}
			else
			{
				value = new List<TagProcessor> { processor };
				tagProcessors.Add(prefix, value);
				tagProcessorsRO.Add(prefix, new ReadOnlyCollection<TagProcessor>(value));
			}
		}

		public bool RemoveProcessor(char prefix, TagProcessor processor)
		{
			if (processor == null)
			{
				throw new ArgumentNullException("processor");
			}
			if (!tagProcessors.TryGetValue(prefix, out var value))
			{
				return false;
			}
			value.IndexOf(processor);
			if (!value.Remove(processor))
			{
				return false;
			}
			if (value.Count == 0)
			{
				tagProcessors.Remove(prefix);
				tagProcessorsRO.Remove(prefix);
			}
			return true;
		}

		public void Clear()
		{
			tagProcessors.Clear();
			tagProcessorsRO.Clear();
		}

		public void RegisterTo(TMPEffectsTextProcessor textProcessor)
		{
			foreach (KeyValuePair<char, List<TagProcessor>> tagProcessor in tagProcessors)
			{
				foreach (TagProcessor item in tagProcessor.Value)
				{
					textProcessor.AddProcessor(tagProcessor.Key, item);
				}
			}
		}

		public void UnregisterFrom(TMPEffectsTextProcessor textProcessor)
		{
			foreach (KeyValuePair<char, List<TagProcessor>> tagProcessor in tagProcessors)
			{
				foreach (TagProcessor item in tagProcessor.Value)
				{
					textProcessor.RemoveProcessor(tagProcessor.Key, item);
				}
			}
		}

		public IEnumerator<TagProcessor> GetEnumerator()
		{
			foreach (List<TagProcessor> value in tagProcessors.Values)
			{
				foreach (TagProcessor item in value)
				{
					yield return item;
				}
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
