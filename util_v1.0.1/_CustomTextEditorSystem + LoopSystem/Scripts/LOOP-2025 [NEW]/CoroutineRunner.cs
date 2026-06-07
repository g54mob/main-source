using System;
using System.Collections;
using UnityEngine;

namespace SPACE_LOOP_SYSTEM
{
    /// <summary>
    /// Safely executes interpreter coroutines with error handling.
    /// Catches exceptions and displays them to console.
    /// </summary>
    public class CoroutineRunner : MonoBehaviour
    {
        #region Fields
        private PythonInterpreter interpreter;
        private GameBuiltinMethods gameBuiltins;
        private ConsoleManager console;
        private Coroutine currentExecution;

		[Header("Console Manager")]
		[SerializeField] ConsoleManager _consoleManager;
		[Header("Error Display")]
		[SerializeField] private bool showErrorsInUnityConsole = true;  // Toggle in Inspector
		#endregion

		#region Events

		/// <summary>
		/// Event fired when script execution moves to a new line
		/// Parameters: (int lineNumber)
		/// Only fires when line number actually changes (not every frame)
		/// 
		/// Usage in other scripts:
		/// GetComponent<CoroutineRunner>().OnLineNumberChanged += (lineNum) => Debug.Log($"Line: {lineNum}");
		/// </summary>
		public event System.Action<int> OnLineNumberChanged;

		/// <summary>
		/// Event fired when script starts execution
		/// </summary>
		public event System.Action OnExecutionStarted;

		/// <summary>
		/// Event fired when script completes execution (success or error)
		/// </summary>
		public event System.Action OnExecutionCompleted;

		#endregion

		#region Unity Lifecycle
		// Replace the Awake() method
		private void Awake()
		{
			gameBuiltins = new GameBuiltinMethods();

			console = (this._consoleManager == null) ? GetComponent<ConsoleManager>() : this._consoleManager;
			if (console == null)
			{
				Debug.LogError("ConsoleManager not found! Add ConsoleManager component.");
			}

			// Pass console to interpreter so print() works
			interpreter = new PythonInterpreter(gameBuiltins, console);
			
			// ★ NEW: Subscribe to interpreter's line change events
			interpreter.OnLineChanged += HandleLineChanged;
		}

		private void OnDestroy()
		{
			// ★ NEW: Unsubscribe to prevent memory leaks
			if (interpreter != null)
			{
				interpreter.OnLineChanged -= HandleLineChanged;
			}
		}
		#endregion

		#region Event Handlers

		/// <summary>
		/// Handles line changes from interpreter and forwards to subscribers
		/// </summary>
		private void HandleLineChanged(int lineNumber)
		{
			// Forward the event to our subscribers
			if (OnLineNumberChanged != null)
			{
				OnLineNumberChanged(lineNumber);
			}
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Runs Python source code as a coroutine
		/// </summary>
		public void Run(string sourceCode)
		{
			// Stop any existing execution
			if (currentExecution != null)
			{
				StopCoroutine(currentExecution);
			}

			// Reset interpreter state
			interpreter.Reset();
			console.Clear();

			// Start new execution
			currentExecution = StartCoroutine(ExecuteCode(sourceCode));
		}

		/// <summary>
		/// Stops current execution
		/// </summary>
		public void Stop()
		{
			if (currentExecution != null)
			{
				StopCoroutine(currentExecution);
				currentExecution = null;
				console.WriteLine("<color=#cc8800>[Execution stopped]</color>");

				// ★ NEW: Fire completion event
				if (OnExecutionCompleted != null)
				{
					OnExecutionCompleted();
				}
			}
		}

		/// <summary>
		/// Returns the current line number being executed
		/// Returns -1 if not currently executing
		/// </summary>
		public int GetCurrentLineNumber()
		{
			if (interpreter != null)
			{
				return interpreter.GetCurrentLineNumber();
			}
			return -1;
		}

		#endregion

		#region Coroutine Execution
		private IEnumerator ExecuteCode(string sourceCode)
		{
			// ★ NEW: Fire execution started event
			if (OnExecutionStarted != null)
			{
				OnExecutionStarted();
			}

			// .NET 2.0 Compliance: Cannot yield inside try-catch
			// Solution: Get execution routine outside try-catch, then yield
			IEnumerator execution = null;
			bool hasError = false;
			string errorType = "";
			string errorMessage = "";

			try
			{
				// Lexical analysis
				Lexer lexer = new Lexer();
				var tokens = lexer.Tokenize(sourceCode);

				// Parsing
				Parser parser = new Parser();
				var ast = parser.Parse(tokens);

				// Get execution routine (don't start yet)
				execution = interpreter.Execute(ast);
			}
			catch (LexerError e)
			{
				hasError = true;
				errorType = "LEXER ERROR";
				errorMessage = e.Message;
			}
			catch (ParserError e)
			{
				hasError = true;
				errorType = "PARSER ERROR";
				errorMessage = e.Message;
			}
			catch (RuntimeError e)
			{
				hasError = true;
				errorType = "RUNTIME ERROR";
				errorMessage = e.Message;
			}
			catch (Exception e)
			{
				hasError = true;
				errorType = "UNEXPECTED ERROR";
				errorMessage = $"{e.Message}\n{e.StackTrace}";
			}

			// Handle errors before execution
			if (hasError)
			{
				string fullError = $"[{errorType}] {errorMessage}";

				Debug.LogError($"{errorType}: {errorMessage}");

				if (console != null)
					console.WriteLine(fullError, isError: true);

				currentExecution = null;

				// ★ NEW: Fire completion event
				if (OnExecutionCompleted != null)
				{
					OnExecutionCompleted();
				}

				yield break;
			}

			// Execute outside try-catch (safe to yield here)
			if (execution != null)
			{
				bool executionError = false;
				string executionErrorType = "";
				string executionErrorMessage = "";

				while (true)
				{
					bool hasMore = false;

					try
					{
						hasMore = execution.MoveNext();
					}
					catch (RuntimeError e)
					{
						executionError = true;
						executionErrorType = "RUNTIME ERROR";
						executionErrorMessage = e.Message;
						break;
					}
					catch (BreakException)
					{
						executionError = true;
						executionErrorType = "CONTROL FLOW ERROR";
						executionErrorMessage = "break statement used outside loop";
						break;
					}
					catch (ContinueException)
					{
						executionError = true;
						executionErrorType = "CONTROL FLOW ERROR";
						executionErrorMessage = "continue statement used outside loop";
						break;
					}
					catch (Exception e)
					{
						executionError = true;
						executionErrorType = "UNEXPECTED ERROR";
						executionErrorMessage = $"{e.Message}\n{e.StackTrace}";
						break;
					}

					if (!hasMore) break;

					// Check if we should yield for frame budget
					if (interpreter.ShouldYield())
					{
						yield return null;
					}

					// Yield any game commands
					if (execution.Current != null)
					{
						yield return execution.Current;
					}
				}

				// Display execution errors to BOTH Unity console and ConsoleManager
				if (executionError)
				{
					string fullError = $"[{executionErrorType}] {executionErrorMessage}";

					Debug.LogError($"{executionErrorType}: {executionErrorMessage}");

					if (console != null)
						console.WriteLine(fullError, isError: true);
				}
				else
				{
					if (console != null)
						console.WriteLine("<color=#88cc00>[Execution complete]</color>");
				}
			}

			currentExecution = null;

			// ★ NEW: Fire completion event
			if (OnExecutionCompleted != null)
			{
				OnExecutionCompleted();
			}
		}
		#endregion
	}
}
