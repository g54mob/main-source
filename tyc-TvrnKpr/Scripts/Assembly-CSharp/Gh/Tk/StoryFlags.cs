using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Gh.Tk.Story;

namespace Gh.Tk
{
	public static class StoryFlags
	{
		public static event EventHandler<EventArgs<string>> StoryFlagValueChanged
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

		public static int GetStoryFlagValue(ActiveStory story, string id)
		{
			return 0;
		}

		private static IEnumerable<DataStore> GetDataSources(ActiveStory story)
		{
			return null;
		}

		public static void UpdateStoryFlagValue(ActiveStory story, string id, int value)
		{
		}

		public static void ProcessTextForStoryFlagInstructions(ActiveStory story, StringBuilderPool.DisposableStringBuilder sb)
		{
		}

		public static void RaiseStoryFlagValueChanged(string key)
		{
		}
	}
}
