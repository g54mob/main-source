// LABELED DIFF FOR ScriptRunner.cs
// Add these changes to your existing ScriptRunner.cs
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;


// LABELED DIFF FOR ScriptRunner.cs
// Add line execution tracking and console integration

// ADD after the using statements (around line 6):
using TMPro;
using System.Text;

namespace GptDeepResearch
{
	public class ScriptRunner : MonoBehaviour
	{
		[Header("Performance Settings")]
		public int loopBatchSize = 100;  // Configurable batch size for loop iterations


		// ADD: New enum for script states
		public enum ScriptState
		{
			Stop,     // Default state - Run button enabled, input editable
			Running   // Executing state - Run button disabled, input read-only
		}

		[Header("UI References")]
		public TMP_InputField scriptInput;
		public TMP_InputField consoleOutput;
		// REMOVE: public LineHighlighter lineHighlighter; // We're removing LineHighlighter

		// ADD: New UI references for line number highlighting
		[Header("Line Number References")]
		[SerializeField] InputFieldLineNumbers InputFieldLineNumbers_ref;
		public TextMeshProUGUI lineNumbersText;  // Reference to line_number tmp component

		// ADD: New UI reference for Run, Reset button
		[Header("Control Buttons")]
		public Button runButton;
		public Button stopButton;

		[Header("Settings")]
		public static float stepDelay = 1f / 100;

		[Header("error prefix")]
		[SerializeField] string errorPrefix = "main_script.py ";
		[SerializeField] TMP_InputField title_inputfield;

		public string ErrorLog { get; private set; } = "";
		private bool isExecuting = false;

		// ADD: Current state and line tracking
		private ScriptState currentState = ScriptState.Stop;
		private int currentExecutingLine = -1;
		private List<string> codeLines = new List<string>();

		// MODIFY the Start method (around line 60):
		void Start()
		{
			// ad
			this.errorPrefix = title_inputfield.text;

			// MODIFY: Register with GlobalScriptManager
			GlobalScriptManager.RegisterRunner(this);

			// MODIFY: Subscribe to global events
			GlobalScriptManager.OnStopAllRunners += StopExecution;
			GlobalScriptManager.OnClearConsole += ClearConsole;

			if (runButton != null)
				runButton.onClick.AddListener(() =>
				{
					OnRunButtonPressed();
				});

			// ADD: Subscribe to Reset button
			if (stopButton != null)
				stopButton.onClick.AddListener(() =>
				{
					OnStopButtonPressed();
				});

			// ADD: Subscribe to line execution events for highlighting
			ExecutionTracker.OnLineExecuted += OnLineExecuted;
			ExecutionTracker.OnExecutionStarted += OnExecutionStarted;
			ExecutionTracker.OnExecutionStopped += OnExecutionStopped;

			// ADD: Initialize state
			SetState(ScriptState.Stop);
		}


		// MODIFY OnDestroy method (around line 80):
		void OnDestroy()
		{
			// ADD: Unregister from GlobalScriptManager
			GlobalScriptManager.UnregisterRunner(this);
			GlobalScriptManager.OnStopAllRunners -= StopExecution;
			GlobalScriptManager.OnClearConsole -= ClearConsole;

			// ADD: Unsubscribe from execution events
			ExecutionTracker.OnLineExecuted -= OnLineExecuted;
			ExecutionTracker.OnExecutionStarted -= OnExecutionStarted;
			ExecutionTracker.OnExecutionStopped -= OnExecutionStopped;
		}

		// ADD new event handlers (around line 160):
		// REPLACE the OnExecutionStarted method:
		private void OnExecutionStarted(ScriptRunner executingScript)
		{
			// Only update highlighting if this is the script that started
			if (executingScript == this)
			{
				UpdateLineNumberHighlighting();
			}
		}

		// REPLACE the OnExecutionStopped method:
		private void OnExecutionStopped(ScriptRunner executingScript)
		{
			// Only update if this was the executing script OR if we had highlighting active
			if (executingScript == this || currentExecutingLine != -1)
			{
				currentExecutingLine = -1;
				UpdateLineNumberHighlighting();
			}
		}


		// MODIFY: Rename and change behavior
		private void OnRunButtonPressed()
		{
			// Let GlobalScriptManager handle the coordination
			GlobalScriptManager.StartRunner(this);

			// Start our execution
			RunScript();
		}

		// MODIFY the OnResetButtonPressed method (around line 120):
		private void OnStopButtonPressed()
		{
			// REPLACE: Properly stop execution first
			if (isExecuting)
			{
				// Stop all running coroutines (this will stop the script execution)
				StopAllCoroutines();
				isExecuting = false;
				currentExecutingLine = -1;
				UpdateLineNumberHighlighting();
				ExecutionTracker.NotifyExecutionStopped();
			}

			// Log reset message immediately
			ConsoleManager.LogInfo("===stop===");

			// Start scene reset coroutine AFTER stopping execution
			StartCoroutine(ResetSceneAndGlobal());
		}

		// ADD new method that won't be killed by StopAllCoroutines:
		private IEnumerator ResetSceneAndGlobal()
		{
			// Reset scene state
			yield return ResetSceneState();

			// Then coordinate with GlobalScriptManager
			GlobalScriptManager.ResetAllRunners();
		}


		// MODIFY the ResetWithScene method (around line 130): not used anywhere at the movement
		private IEnumerator ResetWithSceneAndMessage()
		{
			// Stop any running execution first
			if (isExecuting)
			{
				StopExecution();
				Debug.Log("reached 0");
				yield return null; // Wait a frame
				Debug.Log("reached 1");
			}
			Debug.Log("reached 2");

			// Reset scene state
			yield return ResetSceneState();
			Debug.Log("reached 3");

			// REPLACE: Log reset message with new format
			ConsoleManager.LogInfo("===reset===");

			// Then coordinate with GlobalScriptManager
			GlobalScriptManager.ResetAllRunners();
		}

		// KEEP the original ResetWithScene method for other uses:
		private IEnumerator ResetWithScene()
		{
			// Stop any running execution first
			if (isExecuting)
			{
				StopExecution();
				yield return null; // Wait a frame
			}

			// Reset scene state
			yield return ResetSceneState();

			// Then coordinate with GlobalScriptManager  
			GlobalScriptManager.ResetAllRunners();
		}


		//REPLACE - Replace the entire RunScript() method in ScriptRunner.cs with this:
		internal void RunScript()
		{
			if (isExecuting)
			{
				Debug.Log("Script is already running!");
				return;
			}

			ErrorLog = "";

			// Get the script text
			string Pgrm = scriptInput.text;

			if (this.enableInputSanitization)
			{
				// Sanitize input text before processing
				string sanitizedText = SanitizeScriptText(scriptInput.text);

				// Update the input field with sanitized text if it changed
				if (sanitizedText != scriptInput.text)
				{
					scriptInput.text = sanitizedText;
					if(this.dontLogSanitized == false)
						ConsoleManager.LogInfo("Script text was sanitized to remove problematic characters.");
				}

				// Early validation - check if we have actual content
				if (string.IsNullOrWhiteSpace(sanitizedText))
				{
					if(this.dontLogSanitized == false)
						ConsoleManager.LogError("Script is empty or contains only whitespace.");
					return;
				}

				Pgrm = sanitizedText;
			}
			else
			{
				// When sanitization is disabled, still check for empty content
				if (string.IsNullOrWhiteSpace(Pgrm))
				{
					ConsoleManager.LogError("Script is empty or contains only whitespace.");
					return;
				}
			}

			// Update code lines for line highlighting
			UpdateCodeLines();

			try
			{
				// Use the processed script text for lexing
				var lexer = new PythonLexer(Pgrm);
				var parser = new PythonParser(lexer.Tokens);
				List<Stmt> ast = parser.Parse();

				var interpreter = new PythonInterpreter();
				isExecuting = true;

				// Notify execution started
				ExecutionTracker.NotifyExecutionStarted(this);

				// Start with scene reset, then execute script
				StartCoroutine(ExecuteWithSceneReset(interpreter, ast));
			}
			catch (System.Exception ex)
			{
				ReportError(ex.Message);
				isExecuting = false;
				ExecutionTracker.NotifyExecutionStopped();
				GlobalScriptManager.OnScriptError(this);
			}
		}

		// ADD: New method to handle scene reset + script execution
		/// <summary>
		/// Get the current batch size for this script runner
		/// </summary>
		public int GetLoopBatchSize()
		{
			return loopBatchSize;
		}

		//ADD - Insert this method after the GetLoopBatchSize() method in ScriptRunner.cs (around line 200):

		/// <summary>
		/// Sanitize input text to remove problematic characters that cause lexer errors
		/// </summary>
		[Header("ad must")]
		[SerializeField] bool enableInputSanitization = true;
		[SerializeField] bool dontLogSanitized = true;
		/// <summary>
		/// Sanitize input text to remove problematic characters that cause lexer errors
		/// </summary>
		private string SanitizeScriptText(string input)
		{
			if (string.IsNullOrEmpty(input))
				return "";

			// Step 1: Remove BOM (Byte Order Mark) if present
			if (input.Length > 0 && input[0] == '\uFEFF')
			{
				input = input.Substring(1);
			}

			// Step 2: Normalize line endings to \n only
			input = input.Replace("\r\n", "\n").Replace("\r", "\n");

			// Step 3: Remove problematic control characters and Unicode
			var problematicChars = new char[]
			{
				'\u200B', // Zero Width Space
				'\u200C', // Zero Width Non-Joiner
				'\u200D', // Zero Width Joiner
				'\u2060', // Word Joiner
				'\uFEFF', // Zero Width No-Break Space (BOM)
				'\u00A0', // Non-Breaking Space
				'\v',     // Vertical Tab (0x0B) - THIS IS YOUR CULPRIT!
				'\f',     // Form Feed (0x0C)
				'\b',     // Backspace (0x08)
				'\a',     // Bell (0x07)
				'\0'      // Null character (0x00)
			};

			foreach (char c in problematicChars)
			{
				input = input.Replace(c.ToString(), "");
			}

			// Step 3b: Remove ANY other control characters except \n, \r, \t
			StringBuilder cleanedInput = new StringBuilder();
			foreach (char c in input)
			{
				if (char.IsControl(c))
				{
					// Only allow these control characters
					if (c == '\n' || c == '\r' || c == '\t')
					{
						cleanedInput.Append(c);
					}
					// Skip all other control characters (including 0x0B)
				}
				else
				{
					cleanedInput.Append(c);
				}
			}
			input = cleanedInput.ToString();

			// Step 4: PRESERVE tabs - do NOT convert to spaces
			// Python code editors need to preserve actual tab characters
			// input = input.Replace("\t", "    "); // REMOVED - keep original tabs

			// Step 5: Remove trailing whitespace from each line but preserve structure
			string[] lines = input.Split('\n');
			for (int i = 0; i < lines.Length; i++)
			{
				lines[i] = lines[i].TrimEnd();
			}

			// Step 6: Remove completely empty lines at start and end
			var lineList = new List<string>(lines);
			while (lineList.Count > 0 && string.IsNullOrWhiteSpace(lineList[0]))
			{
				lineList.RemoveAt(0);
			}
			while (lineList.Count > 0 && string.IsNullOrWhiteSpace(lineList[lineList.Count - 1]))
			{
				lineList.RemoveAt(lineList.Count - 1);
			}

			// Step 7: Rebuild the string
			string result = string.Join("\n", lineList.ToArray());

			// Debug logging for troubleshooting
			if (input != result)
			{
				Debug.Log($"Text sanitization applied. Original length: {input.Length}, Sanitized length: {result.Length}");
			}

			return result;
		}

		private IEnumerator ExecuteWithSceneReset(PythonInterpreter interpreter, List<Stmt> ast)
		{
			// First, reset the scene
			yield return ResetSceneState();

			// Set the batch size for this execution
			ExecutionTracker.SetBatchSize(loopBatchSize);

			// Then execute the script
			yield return CoroutineRunner.SafeExecute(
				interpreter.Execute(ast),
				stepDelay,
				ReportError,
				OnExecutionComplete
			);
		}

		// REPLACE the OnLineExecuted method:
		private void OnLineExecuted(ScriptRunner executingScript, int lineNumber)
		{
			// Only highlight if this is the script that's executing
			if (executingScript == this)
			{
				currentExecutingLine = lineNumber;
				UpdateLineNumberHighlighting();
			}
		}

		// ADDITIONAL PATCH for ScriptRunner.cs
		// Add this method to integrate scene reset functionality

		// ADD this method to ScriptRunner.cs (around line 150, before UpdateCodeLines method)

		/// <summary>
		/// Reset scene state before running script
		/// </summary>
		private IEnumerator ResetSceneState()
		{
			// Call scene reset if available
			yield return GameBuiltinMethods.ResetScene();
		}

		// MODIFY OnExecutionComplete method (around line 170):
		private void OnExecutionComplete()
		{
			isExecuting = false;
			currentExecutingLine = -1;
			UpdateLineNumberHighlighting(); // Reset highlighting

			Debug.Log("Script execution completed.");

			// ADD: Notify execution stopped
			ExecutionTracker.NotifyExecutionStopped();

			// ADD: Notify GlobalScriptManager of completion
			GlobalScriptManager.OnScriptComplete(this);
		}

		// MODIFY the ReportError method to ensure errors go to console (around line 180):
		private void ReportError(string msg)
		{
			string errorMessage = $"@{errorPrefix}: {msg}";
			ErrorLog += errorMessage + "\n";

			// Send error to console manager
			ConsoleManager.LogError(errorMessage);

			isExecuting = false;
			currentExecutingLine = -1;
			UpdateLineNumberHighlighting();

			// Notify execution stopped on error
			ExecutionTracker.NotifyExecutionStopped();

			// Notify GlobalScriptManager of error
			GlobalScriptManager.OnScriptError(this);
		}

		// MODIFY StopExecution method - remove ReportError from reset context:
		public void StopExecution()
		{
			if (isExecuting)
			{
				StopAllCoroutines();
				isExecuting = false;
				currentExecutingLine = -1;
				UpdateLineNumberHighlighting();

				// Notify execution stopped
				ExecutionTracker.NotifyExecutionStopped();

				// Only report "stopped by user" if called from StopAllRunners event
				// (not from reset button)
				if (GlobalScriptManager.GetCurrentRunningScript() == this)
				{
					// Log reset message immediately
					ConsoleManager.LogInfo("===stop===");

					// ReportError("Execution stopped by not by current script_window reset");
				}
			}
		}

		// MODIFY the ClearConsole method to NOT clear the console (around line 220):
		private void ClearConsole()
		{
			// DON'T clear the console anymore - let it accumulate messages
			// Keep this method for compatibility but make it do nothing
			// if (consoleOutput != null)
			//     consoleOutput.text = "";
			// ErrorLog = "";

			// Instead, just reset the ErrorLog for this script runner
			ErrorLog = "";
		}

		// ADD: State management method
		public void SetState(ScriptState newState)
		{
			currentState = newState;

			switch (newState)
			{
				case ScriptState.Stop:
					// Enable Run button, make input editable
					if (runButton != null)
						runButton.interactable = true;
					if (scriptInput != null)
						scriptInput.readOnly = false;

					// Reset line highlighting to gray
					currentExecutingLine = -1;
					UpdateLineNumberHighlighting();
					break;

				case ScriptState.Running:
					// Disable Run button, make input read-only
					if (runButton != null)
						runButton.interactable = false;
					if (scriptInput != null)
						scriptInput.readOnly = true;
					break;
			}
		}

		// ADD: Update code lines for line highlighting
		private void UpdateCodeLines()
		{
			codeLines.Clear();
			if (!string.IsNullOrEmpty(scriptInput.text))
			{
				codeLines.AddRange(scriptInput.text.Split('\n'));
			}
		}

		// ADD: Line number highlighting method (replaces LineHighlighter)
		private void UpdateLineNumberHighlighting()
		{
			if (lineNumbersText == null) return;

			string color_defaultLineNumber = "#3a3a3a";
			string color_executingLineNumber = "#fefefe";

			if (this.InputFieldLineNumbers_ref != null) // if there is a reference set
			{
				color_defaultLineNumber = $"#{ColorUtility.ToHtmlStringRGB(InputFieldLineNumbers_ref.defaultLineColor)}";
				color_executingLineNumber = $"#{ColorUtility.ToHtmlStringRGB(InputFieldLineNumbers_ref.executingLineColor)}";
			}
			else
			{
				Debug.Log("InputFieldLineNumbers_ref no referensed to access colors");
			}

			// $"<color=#{ColorUtility.ToHtmlStringRGB(executingLineColor)}>{lineText}</color>"

			// Parse existing line numbers text
			string[] lines = lineNumbersText.text.Split('\n');
			System.Text.StringBuilder newText = new System.Text.StringBuilder();

			for (int i = 0; i < lines.Length; i++)
			{
				if (i > 0) newText.AppendLine();

				// Extract line number from formatted text (remove any existing color tags)
				string lineText = lines[i];
				lineText = System.Text.RegularExpressions.Regex.Replace(lineText, @"<color[^>]*>|</color>", "");

				// Apply highlighting
				if (currentState == ScriptState.Running && currentExecutingLine == i + 1)
				{
					newText.Append($"<color={color_executingLineNumber}>{lineText}</color>");
				}
				else
				{
					newText.Append($"<color={color_defaultLineNumber}>{lineText}</color>");
				}
			}

			lineNumbersText.text = newText.ToString();
		}

		// ADD: Public getter for current state
		public ScriptState GetCurrentState()
		{
			return currentState;
		}

	}



	// REPLACE the ExecutionTracker class at the bottom of ScriptRunner.cs with this:
	//replace - Replace ExecutionTracker class with batching functionality
	public static class ExecutionTracker
	{
		// Event fired when a line is executed - now includes the ScriptRunner reference
		public static event Action<ScriptRunner, int> OnLineExecuted;

		// Event fired when execution starts - now includes the ScriptRunner reference
		public static event Action<ScriptRunner> OnExecutionStarted;

		// Event fired when execution stops/completes - now includes the ScriptRunner reference
		public static event Action<ScriptRunner> OnExecutionStopped;

		// Keep track of currently executing script
		private static ScriptRunner currentExecutingScript = null;

		// Iteration counter for batching step delays
		private static int iterationCounter = 0;
		private static int currentBatchSize = 100; // Default batch size

		/// <summary>
		/// Call this from PythonInterpreter when executing each statement
		/// </summary>
		public static void NotifyLineExecution(int lineNumber)
		{
			// Only notify if we have a current executing script
			if (currentExecutingScript != null)
			{
				OnLineExecuted?.Invoke(currentExecutingScript, lineNumber);
			}
		}

		/// <summary>
		/// Call this when script execution begins
		/// </summary>
		public static void NotifyExecutionStarted(ScriptRunner script)
		{
			currentExecutingScript = script;
			ResetIterationCounter(); // Reset counter at start
			OnExecutionStarted?.Invoke(script);
		}

		/// <summary>
		/// Call this when script execution stops or completes
		/// </summary>
		public static void NotifyExecutionStopped()
		{
			var script = currentExecutingScript;
			currentExecutingScript = null;
			if (script != null)
			{
				OnExecutionStopped?.Invoke(script);
			}
		}

		/// <summary>
		/// Get the currently executing script
		/// </summary>
		public static ScriptRunner GetCurrentExecutingScript()
		{
			return currentExecutingScript;
		}

		/// <summary>
		/// Set the batch size for current execution
		/// </summary>
		public static void SetBatchSize(int batchSize)
		{
			currentBatchSize = batchSize;
		}

		/// <summary>
		/// Increment iteration counter and check if we should yield
		/// </summary>
		public static bool ShouldYieldForBatch()
		{
			iterationCounter += 1;
			if ((iterationCounter % currentBatchSize) == 0)
				Debug.Log("gotta wait");
			return (iterationCounter % currentBatchSize) == 0;
		}

		/// <summary>
		/// Reset iteration counter when starting new execution or entering functions
		/// </summary>
		public static void ResetIterationCounter()
		{
			iterationCounter = 0;
		}

		/// <summary>
		/// Force immediate yield (for print, sleep, etc.) - does not increment counter
		/// </summary>
		public static void ForceYield()
		{
			// Don't increment counter for forced yields like print() and sleep()
		}
	}
}

/*
# required syntax

def func():
	n = getGoal() - getPos()
	for i in range(n.x):
		move("right")
	for i in range(n.y):
		move("up")
	submit()
func()

*/
