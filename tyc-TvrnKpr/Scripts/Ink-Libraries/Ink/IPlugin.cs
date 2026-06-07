using Ink.Parsed;
using Ink.Runtime;

namespace Ink
{
	public interface IPlugin
	{
		void PostParse(Ink.Parsed.Story parsedStory);

		void PostExport(Ink.Parsed.Story parsedStory, Ink.Runtime.Story runtimeStory);
	}
}
