using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace Ink.Runtime
{
	public class Story : Object
	{
		private enum OutputStateChange
		{
			NoChange = 0,
			ExtendedBeyondNewline = 1,
			NewlineRemoved = 2
		}

		public delegate object ExternalFunction(object[] args);

		public delegate void VariableObserver(string variableName, object newValue);

		private struct ExternalFunctionDef
		{
			public ExternalFunction function;

			public bool lookaheadSafe;
		}

		public const int inkVersionCurrent = 20;

		private const int inkVersionMinimumCompatible = 18;

		private List<Container> _prevContainers;

		private Container _mainContentContainer;

		private ListDefinitionsOrigin _listDefinitions;

		private Dictionary<string, ExternalFunctionDef> _externals;

		private Dictionary<string, VariableObserver> _variableObservers;

		private bool _hasValidatedExternals;

		private Container _temporaryEvaluationContainer;

		private StoryState _state;

		private bool _asyncContinueActive;

		private StoryState _stateSnapshotAtLastNewline;

		private bool _sawLookaheadUnsafeFunctionAfterNewline;

		private int _recursiveContinueCount;

		private bool _asyncSaving;

		private Profiler _profiler;

		public List<Choice> currentChoices => null;

		public string currentText => null;

		public List<string> currentTags => null;

		public List<string> currentErrors => null;

		public List<string> currentWarnings => null;

		public bool hasError => false;

		public bool hasWarning => false;

		public VariablesState variablesState => null;

		public ListDefinitionsOrigin listDefinitions => null;

		public StoryState state => null;

		public bool canContinue => false;

		public bool asyncContinueComplete => false;

		public bool allowExternalFunctionFallbacks { get; set; }

		public List<string> globalTags => null;

		private DebugMetadata currentDebugMetadata => null;

		private int currentLineNumber => 0;

		public Container mainContentContainer => null;

		public event ErrorHandler onError
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

		public event Action onDidContinue
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

		public event Action<Choice> onMakeChoice
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

		public event Action<string, object[]> onEvaluateFunction
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

		public event Action<string, object[], string, object> onCompleteEvaluateFunction
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

		public event Action<string, object[]> onChoosePathString
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

		public Profiler StartProfiling()
		{
			return null;
		}

		public void EndProfiling()
		{
		}

		public Story(Container contentContainer, List<ListDefinition> lists = null)
		{
		}

		public Story(string jsonString)
		{
		}

		public string ToJson()
		{
			return null;
		}

		public void ToJson(Stream stream)
		{
		}

		private void ToJson(SimpleJson.Writer writer)
		{
		}

		public void ResetState()
		{
		}

		private void ResetErrors()
		{
		}

		public void ResetCallstack()
		{
		}

		private void ResetGlobals()
		{
		}

		public string Continue()
		{
			return null;
		}

		public void ContinueAsync(float millisecsLimitAsync)
		{
		}

		private void ContinueInternal(float millisecsLimitAsync = 0f)
		{
		}

		private bool ContinueSingleStep()
		{
			return false;
		}

		private OutputStateChange CalculateNewlineOutputStateChange(string prevText, string currText, int prevTagCount, int currTagCount)
		{
			return default(OutputStateChange);
		}

		public string ContinueMaximally()
		{
			return null;
		}

		public SearchResult ContentAtPath(Path path)
		{
			return default(SearchResult);
		}

		public Container KnotContainerWithName(string name)
		{
			return null;
		}

		public Pointer PointerAtPath(Path path)
		{
			return default(Pointer);
		}

		private void StateSnapshot()
		{
		}

		private void RestoreStateSnapshot()
		{
		}

		private void DiscardSnapshot()
		{
		}

		public StoryState CopyStateForBackgroundThreadSave()
		{
			return null;
		}

		public void BackgroundSaveComplete()
		{
		}

		private void Step()
		{
		}

		private void VisitContainer(Container container, bool atStart)
		{
		}

		private void VisitChangedContainersDueToDivert()
		{
		}

		private Choice ProcessChoice(ChoicePoint choicePoint)
		{
			return null;
		}

		private bool IsTruthy(Object obj)
		{
			return false;
		}

		private bool PerformLogicAndFlowControl(Object contentObj)
		{
			return false;
		}

		public void ChoosePathString(string path, bool resetCallstack = true, params object[] arguments)
		{
		}

		private void IfAsyncWeCant(string activityStr)
		{
		}

		public void ChoosePath(Path p, bool incrementingTurnIndex = true)
		{
		}

		public void ChooseChoiceIndex(int choiceIdx)
		{
		}

		public bool HasFunction(string functionName)
		{
			return false;
		}

		public object EvaluateFunction(string functionName, params object[] arguments)
		{
			return null;
		}

		public object EvaluateFunction(string functionName, out string textOutput, params object[] arguments)
		{
			textOutput = null;
			return null;
		}

		public Object EvaluateExpression(Container exprContainer)
		{
			return null;
		}

		public void CallExternalFunction(string funcName, int numberOfArguments)
		{
		}

		public void BindExternalFunctionGeneral(string funcName, ExternalFunction func, bool lookaheadSafe = true)
		{
		}

		private object TryCoerce<T>(object value)
		{
			return null;
		}

		public void BindExternalFunction(string funcName, Func<object> func, bool lookaheadSafe = false)
		{
		}

		public void BindExternalFunction(string funcName, Action act, bool lookaheadSafe = false)
		{
		}

		public void BindExternalFunction<T>(string funcName, Func<T, object> func, bool lookaheadSafe = false)
		{
		}

		public void BindExternalFunction<T>(string funcName, Action<T> act, bool lookaheadSafe = false)
		{
		}

		public void BindExternalFunction<T1, T2>(string funcName, Func<T1, T2, object> func, bool lookaheadSafe = false)
		{
		}

		public void BindExternalFunction<T1, T2>(string funcName, Action<T1, T2> act, bool lookaheadSafe = false)
		{
		}

		public void BindExternalFunction<T1, T2, T3>(string funcName, Func<T1, T2, T3, object> func, bool lookaheadSafe = false)
		{
		}

		public void BindExternalFunction<T1, T2, T3>(string funcName, Action<T1, T2, T3> act, bool lookaheadSafe = false)
		{
		}

		public void BindExternalFunction<T1, T2, T3, T4>(string funcName, Func<T1, T2, T3, T4, object> func, bool lookaheadSafe = false)
		{
		}

		public void BindExternalFunction<T1, T2, T3, T4>(string funcName, Action<T1, T2, T3, T4> act, bool lookaheadSafe = false)
		{
		}

		public void UnbindExternalFunction(string funcName)
		{
		}

		public void ValidateExternalBindings()
		{
		}

		private void ValidateExternalBindings(Container c, HashSet<string> missingExternals)
		{
		}

		private void ValidateExternalBindings(Object o, HashSet<string> missingExternals)
		{
		}

		public void ObserveVariable(string variableName, VariableObserver observer)
		{
		}

		public void ObserveVariables(IList<string> variableNames, VariableObserver observer)
		{
		}

		public void RemoveVariableObserver(VariableObserver observer = null, string specificVariableName = null)
		{
		}

		private void VariableStateDidChangeEvent(string variableName, Object newValueObj)
		{
		}

		public List<string> TagsForContentAtPath(string path)
		{
			return null;
		}

		private List<string> TagsAtStartOfFlowContainerWithPathString(string pathString)
		{
			return null;
		}

		public virtual string BuildStringOfHierarchy()
		{
			return null;
		}

		private string BuildStringOfContainer(Container container)
		{
			return null;
		}

		private void NextContent()
		{
		}

		private bool IncrementContentPointer()
		{
			return false;
		}

		private bool TryFollowDefaultInvisibleChoice()
		{
			return false;
		}

		private int NextSequenceShuffleIndex()
		{
			return 0;
		}

		public void Error(string message, bool useEndLineNumber = false)
		{
		}

		public void Warning(string message)
		{
		}

		private void AddError(string message, bool isWarning = false, bool useEndLineNumber = false)
		{
		}

		private void Assert(bool condition, string message = null, params object[] formatParams)
		{
		}
	}
}
