using System.Collections.Generic;
using System.IO;

namespace Ink.Runtime
{
	public class StoryState
	{
		public const int kInkSaveStateVersion = 8;

		private const int kMinCompatibleLoadVersion = 8;

		private string _currentText;

		private List<string> _currentTags;

		private Dictionary<string, int> _visitCounts;

		private Dictionary<string, int> _turnIndices;

		private List<Object> _outputStream;

		private bool _outputStreamTextDirty;

		private bool _outputStreamTagsDirty;

		private List<Choice> _currentChoices;

		private StatePatch _patch;

		public int callstackDepth => 0;

		public List<Object> outputStream => null;

		public List<Choice> currentChoices => null;

		public List<Choice> generatedChoices => null;

		public List<string> currentErrors { get; private set; }

		public List<string> currentWarnings { get; private set; }

		public VariablesState variablesState { get; private set; }

		public CallStack callStack { get; set; }

		public List<Object> evaluationStack { get; private set; }

		public Pointer divertedPointer { get; set; }

		public int currentTurnIndex { get; private set; }

		public int storySeed { get; set; }

		public int previousRandom { get; set; }

		public bool didSafeExit { get; set; }

		public Story story { get; set; }

		public string currentPathString => null;

		public Pointer currentPointer
		{
			get
			{
				return default(Pointer);
			}
			set
			{
			}
		}

		public Pointer previousPointer
		{
			get
			{
				return default(Pointer);
			}
			set
			{
			}
		}

		public bool canContinue => false;

		public bool hasError => false;

		public bool hasWarning => false;

		public string currentText => null;

		public List<string> currentTags => null;

		public bool inExpressionEvaluation
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool outputStreamEndsInNewline => false;

		public bool outputStreamContainsContent => false;

		public bool inStringEvaluation => false;

		public string ToJson()
		{
			return null;
		}

		public void ToJson(Stream stream)
		{
		}

		public void LoadJson(string json)
		{
		}

		public int VisitCountAtPathString(string pathString)
		{
			return 0;
		}

		public int VisitCountForContainer(Container container)
		{
			return 0;
		}

		public void IncrementVisitCountForContainer(Container container)
		{
		}

		public void RecordTurnIndexVisitToContainer(Container container)
		{
		}

		public int TurnsSinceForContainer(Container container)
		{
			return 0;
		}

		private string CleanOutputWhitespace(string str)
		{
			return null;
		}

		public StoryState(Story story)
		{
		}

		public void GoToStart()
		{
		}

		public StoryState CopyAndStartPatching()
		{
			return null;
		}

		public void RestoreAfterPatch()
		{
		}

		public void ApplyAnyPatch()
		{
		}

		private void ApplyCountChanges(Container container, int newCount, bool isVisit)
		{
		}

		private void WriteJson(SimpleJson.Writer writer)
		{
		}

		private void LoadJsonObj(Dictionary<string, object> jObject)
		{
		}

		public void ResetErrors()
		{
		}

		public void ResetOutput(List<Object> objs = null)
		{
		}

		public void PushToOutputStream(Object obj)
		{
		}

		public void PopFromOutputStream(int count)
		{
		}

		private List<StringValue> TrySplittingHeadTailWhitespace(StringValue single)
		{
			return null;
		}

		private void PushToOutputStreamIndividual(Object obj)
		{
		}

		private void TrimNewlinesFromOutputStream()
		{
		}

		private void RemoveExistingGlue()
		{
		}

		public void PushEvaluationStack(Object obj)
		{
		}

		public Object PopEvaluationStack()
		{
			return null;
		}

		public Object PeekEvaluationStack()
		{
			return null;
		}

		public List<Object> PopEvaluationStack(int numberOfObjects)
		{
			return null;
		}

		public void ForceEnd()
		{
		}

		private void TrimWhitespaceFromFunctionEnd()
		{
		}

		public void PopCallstack(PushPopType? popType = null)
		{
		}

		public void SetChosenPath(Path path, bool incrementingTurnIndex)
		{
		}

		public void StartFunctionEvaluationFromGame(Container funcContainer, params object[] arguments)
		{
		}

		public void PassArgumentsToEvaluationStack(params object[] arguments)
		{
		}

		public bool TryExitFunctionEvaluationFromGame()
		{
			return false;
		}

		public object CompleteFunctionEvaluationFromGame()
		{
			return null;
		}

		public void AddError(string message, bool isWarning)
		{
		}

		private void OutputStreamDirty()
		{
		}
	}
}
