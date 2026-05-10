using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using SPACE_UTIL;
using SPACE_LOOP_SYSTEM;
using SPACE__CUSTOM_TEXT_EDITOR__SYSTEM;

namespace SPACE_GAME__CUSTOM_TEXT_EDITOR__SYSTEM___LOOP_SYSTEM
{
	public class DEBUG_Check: MonoBehaviour
	{
		[SerializeField] CoroutineRunner _runner;
		[SerializeField] TMP_InputField _inputField;
		[SerializeField] CustomTextEditorManager _debug_customTextEditor;
		[SerializeField] bool useCustomTextEditor = true;
		[SerializeField] Button _runBtn;
		[SerializeField] Button _stopBtn;
		// (Optional) UI for showing current line
		[Header("optional")]
		[SerializeField] TextMeshProUGUI _currentLineText;

		private void Start()
		{
			#region subscribe
			// Subscribe to line change events
			_runner.OnLineNumberChanged += HandleLineChanged;
			_runner.OnExecutionStarted += HandleExecutionStarted;
			_runner.OnExecutionCompleted += HandleExecutionCompleted; 
			#endregion
			// start script
			this._runBtn.onClick.AddListener(() =>
			{
				string script = (this.useCustomTextEditor) ? this._debug_customTextEditor.text : this._inputField.text;
				Debug.Log($"loaded script from inputField:\n {script}");
				_runner.Stop();
				_runner.Run(script);

				this._runBtn.interactable = false;
			});
			// stop script
			this._stopBtn.onClick.AddListener(() =>
			{
				Debug.Log($"stopped script in inputField:\n");
				_runner.Stop();
				this._runBtn.interactable = true;
			});
		}
		private void Update()
		{
			if(INPUT.K.HeldDown(KeyCode.LeftAlt) && INPUT.M.InstantDown(0))
			{
				StopAllCoroutines();
				StartCoroutine(STIMULATE());
			}
		}
		private void OnDestroy()
		{
			#region un-subscribe
			_runner.OnLineNumberChanged -= HandleLineChanged;
			_runner.OnExecutionStarted -= HandleExecutionStarted;
			_runner.OnExecutionCompleted -= HandleExecutionCompleted; 
			#endregion
		}
		//
		IEnumerator STIMULATE()
		{
			#region frameRate
			yield return null;
			#endregion

			// this.checkLOG();
			yield return this.checkInterpreter();
			yield return null;
		}
		//
		#region Event Handlers
		//  This is called ONLY when line number changes (not every frame)
		private void HandleLineChanged(int lineNumber)
		{
			Debug.Log($"<color=cyan>Executing line {lineNumber}</color>");

			// Update UI if you have one
			if (_currentLineText != null)
			{
				_currentLineText.text = $"Line: {lineNumber}";
			}

			// You can add custom behavior here:
			// - Highlight current line in a code editor
			// - Update a debugger UI
			// - Track execution statistics
			// - etc.
		}

		// Called when script starts
		private void HandleExecutionStarted()
		{
			Debug.Log("<color=green>Script execution started</color>");

			if (_currentLineText != null)
			{
				_currentLineText.text = "Running...";
			}
		}

		// Called when script completes (success or error)
		private void HandleExecutionCompleted()
		{
			Debug.Log("<color=yellow>Script execution completed</color>");
			this._runBtn.interactable = true;

			if (_currentLineText != null)
			{
				_currentLineText.text = "Idle";
			}
		}
		#endregion
		//
		IEnumerator checkInterpreter()
		{
			// Load the script
			string script = LOG.LoadGameData(GameDataType.sampleScript);

			// Debug what was actually loaded
			Debug.Log(script);

			// Just use the runner's built-in method!
			_runner.Run(script);

			// Wait for completion
			yield return new WaitForSeconds(0.1f);
		}
		IEnumerator checkInterpreter__prev()
		{
			#region string script
			string script = @"
# Test: Large loop (tests instruction budget / time slicing)
sum = 0
for i in range(10000):
	if (i % 1000) == 0:
		print(i)
		sleep(1.0)
    sum += 1
print(sum)  # Expected: 1000
";
			// script = LOG.LoadGameData(GameDataType.sampleScript);
			Debug.Log(script);
			#endregion
			this._runner.Run(script);
			yield return null;
		}
		//
		void checkLOG()
		{
			LOG.AddLog("somthng", "txt");
		}
	}
}