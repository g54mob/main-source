using System.Collections.Generic;
using Ink.Parsed;
using Ink.Runtime;

namespace Ink
{
	public class Compiler
	{
		public class Options
		{
			public string sourceFilename;

			public List<string> pluginNames;

			public bool countAllVisits;

			public ErrorHandler errorHandler;

			public IFileHandler fileHandler;
		}

		public class CommandLineInputResult
		{
			public bool requestsExit;

			public int choiceIdx;

			public string divertedPath;

			public string output;
		}

		public struct DebugSourceRange
		{
			public int length;

			public DebugMetadata debugMetadata;

			public string text;
		}

		private string _inputString;

		private Options _options;

		private InkParser _parser;

		private Ink.Parsed.Story _parsedStory;

		private Ink.Runtime.Story _runtimeStory;

		private PluginManager _pluginManager;

		private bool _hadParseError;

		private List<DebugSourceRange> _debugSourceRanges;

		public Ink.Parsed.Story parsedStory => null;

		public Compiler(string inkSource, Options options = null)
		{
		}

		public Ink.Parsed.Story Parse()
		{
			return null;
		}

		public Ink.Runtime.Story Compile()
		{
			return null;
		}

		public CommandLineInputResult ReadCommandLineInput(string userInput)
		{
			return null;
		}

		public void RetrieveDebugSourceForLatestContent()
		{
		}

		private DebugMetadata DebugMetadataForContentAtOffset(int offset)
		{
			return null;
		}

		private void OnParseError(string message, ErrorType errorType)
		{
		}
	}
}
