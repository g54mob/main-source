using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TMPEffects.TextProcessing
{
	public interface ITagProcessorManager : IEnumerable<TagProcessor>, IEnumerable
	{
		ReadOnlyDictionary<char, ReadOnlyCollection<TagProcessor>> TagProcessors { get; }

		void AddProcessor(char prefix, TagProcessor processor, int priority = 0);

		bool RemoveProcessor(char prefix, TagProcessor processor);
	}
}
