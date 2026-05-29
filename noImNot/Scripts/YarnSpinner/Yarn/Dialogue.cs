using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Yarn.Analysis;
using Yarn.Markup;

namespace Yarn
{
	public class Dialogue : IAttributeMarkerProcessor
	{
		internal class StandardLibrary : Library
		{
			private static Random Random;
		}

		public const string DefaultStartNodeName = "Start";

		private Program program;

		private VirtualMachine vm;

		private readonly LineParser lineParser;

		private static readonly Regex ValuePlaceholderRegex;

		public IVariableStorage VariableStorage { get; set; }

		public Logger LogDebugMessage { get; set; }

		public Logger LogErrorMessage { get; set; }

		internal Program Program
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool IsActive => false;

		public LineHandler LineHandler
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string LanguageCode { get; set; }

		public OptionsHandler OptionsHandler
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public CommandHandler CommandHandler
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public NodeStartHandler NodeStartHandler
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public NodeCompleteHandler NodeCompleteHandler
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public DialogueCompleteHandler DialogueCompleteHandler
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public PrepareForLinesHandler PrepareForLinesHandler
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Library Library { get; internal set; }

		public IEnumerable<string> NodeNames => null;

		public string CurrentNode => null;

		public Dialogue(IVariableStorage variableStorage)
		{
		}

		public void SetProgram(Program program)
		{
		}

		public void AddProgram(Program program)
		{
		}

		internal void LoadProgram(string fileName)
		{
		}

		public void SetNode(string startNode = "Start")
		{
		}

		public void SetSelectedOption(int selectedOptionID)
		{
		}

		public void Continue()
		{
		}

		public void Stop()
		{
		}

		public string GetStringIDForNode(string nodeName)
		{
			return null;
		}

		public IEnumerable<string> GetTagsForNode(string nodeName)
		{
			return null;
		}

		public void UnloadAll()
		{
		}

		internal string GetByteCode()
		{
			return null;
		}

		public bool NodeExists(string nodeName)
		{
			return false;
		}

		public void Analyse(Context context)
		{
		}

		public MarkupParseResult ParseMarkup(string line)
		{
			return default(MarkupParseResult);
		}

		public static string ExpandSubstitutions(string text, IList<string> substitutions)
		{
			return null;
		}

		string IAttributeMarkerProcessor.ReplacementTextForMarker(MarkupAttributeMarker marker)
		{
			return null;
		}

		private bool IsNodeVisited(string nodeName)
		{
			return false;
		}

		private float GetNodeVisitCount(string nodeName)
		{
			return 0f;
		}
	}
}
