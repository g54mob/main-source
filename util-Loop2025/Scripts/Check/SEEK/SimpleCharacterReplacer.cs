//ADD - Create new file: Scripts/TextEditor/SimpleCharacterReplacer.cs
//Simpler approach without reflection complexity

using UnityEngine;
using TMPro;
using System.Text;

namespace GptDeepResearch
{
	/// <summary>
	/// Simple component that replaces problematic characters with spaces in TMP_InputField
	/// Handles Shift+Enter, paste operations, and any other problematic character input
	/// </summary>
	[RequireComponent(typeof(TMP_InputField))]
	public class SimpleCharacterReplacer : MonoBehaviour
	{
		[TextArea(3, 4)]
		[SerializeField] string README = @"Simple component that replaces problematic characters with spaces in TMP_InputField
Handles Shift+Enter, paste operations, and any other problematic character input";

		[Header("Replacement Settings")]
		[SerializeField] private bool replaceProblematicChars = true;
		[Tooltip("Replace problematic characters (0x0B, zero-width spaces, etc.) with regular spaces")]

		[SerializeField] private bool logReplacements = true;
		[Tooltip("Log when characters are replaced for debugging")]

		[SerializeField] private bool replaceInRealTime = true;
		[Tooltip("Replace characters immediately as they're typed/pasted")]

		private TMP_InputField inputField;
		private bool isProcessingText = false;

		void Start()
		{
			inputField = GetComponent<TMP_InputField>();

			if (inputField != null)
			{
				if (replaceInRealTime)
				{
					inputField.onValueChanged.AddListener(OnTextChanged);
				}

				// Clean any existing text
				CleanCurrentText();
			}
		}

		void OnDestroy()
		{
			if (inputField != null && replaceInRealTime)
			{
				inputField.onValueChanged.RemoveListener(OnTextChanged);
			}
		}

		private void OnTextChanged(string newText)
		{
			if (!replaceProblematicChars || isProcessingText)
				return;

			string cleanedText = ReplaceProblematicCharacters(newText);

			if (cleanedText != newText)
			{
				isProcessingText = true;

				// Store caret position
				int caretPos = inputField.caretPosition;

				// Update with cleaned text
				inputField.text = cleanedText;

				// Restore caret position (adjust if text length changed)
				int lengthDiff = newText.Length - cleanedText.Length;
				inputField.caretPosition = Mathf.Max(0, caretPos - lengthDiff);

				isProcessingText = false;
			}
		}

		/// <summary>
		/// Replace problematic characters with spaces
		/// </summary>
		private string ReplaceProblematicCharacters(string input)
		{
			if (string.IsNullOrEmpty(input))
				return input;

			StringBuilder result = new StringBuilder(input.Length);
			int replacementCount = 0;

			foreach (char c in input)
			{
				char outputChar = c;
				bool wasReplaced = false;
				string charType = "";

				// Replace vertical tab (0x0B) - main culprit from Shift+Enter
				if (c == '\v')
				{
					outputChar = ' ';
					wasReplaced = true;
					charType = "Vertical Tab (0x0B)";
				}
				// Replace form feed (0x0C)
				else if (c == '\f')
				{
					outputChar = ' ';
					wasReplaced = true;
					charType = "Form Feed (0x0C)";
				}
				// Replace BOM (often from copy-paste)
				else if (c == '\uFEFF')
				{
					outputChar = ' ';
					wasReplaced = true;
					charType = "BOM";
				}
				// Replace zero-width spaces (from web copy-paste)
				else if (c == '\u200B' || c == '\u200C' || c == '\u200D' || c == '\u2060')
				{
					outputChar = ' ';
					wasReplaced = true;
					charType = "Zero-Width Character";
				}
				// Replace non-breaking space (from documents)
				else if (c == '\u00A0')
				{
					outputChar = ' ';
					wasReplaced = true;
					charType = "Non-Breaking Space";
				}
				// Replace other problematic control characters
				else if (char.IsControl(c) && c != '\n' && c != '\r' && c != '\t' && c != '\b')
				{
					outputChar = ' ';
					wasReplaced = true;
					charType = $"Control Char (0x{((int)c):X2})";
				}

				if (wasReplaced)
				{
					replacementCount++;
					if (logReplacements)
					{
						Debug.Log($"SimpleCharacterReplacer: Replaced {charType} with space");
					}
				}

				result.Append(outputChar);
			}

			if (replacementCount > 0 && logReplacements)
			{
				Debug.Log($"SimpleCharacterReplacer: Replaced {replacementCount} problematic characters with spaces");
			}

			return result.ToString();
		}

		/// <summary>
		/// Manually clean the current input field text
		/// </summary>
		[ContextMenu("Clean Current Text")]
		public void CleanCurrentText()
		{
			if (inputField == null) return;

			string originalText = inputField.text;
			string cleanedText = ReplaceProblematicCharacters(originalText);

			if (cleanedText != originalText)
			{
				inputField.text = cleanedText;
				Debug.Log($"SimpleCharacterReplacer: Cleaned input field - replaced problematic characters with spaces");
			}
			else
			{
				Debug.Log("SimpleCharacterReplacer: Input field was already clean");
			}
		}

		/// <summary>
		/// Toggle real-time replacement
		/// </summary>
		public void SetRealTimeReplacement(bool enabled)
		{
			if (replaceInRealTime != enabled)
			{
				replaceInRealTime = enabled;

				if (inputField != null)
				{
					if (enabled)
					{
						inputField.onValueChanged.AddListener(OnTextChanged);
						Debug.Log("SimpleCharacterReplacer: Real-time replacement enabled");
					}
					else
					{
						inputField.onValueChanged.RemoveListener(OnTextChanged);
						Debug.Log("SimpleCharacterReplacer: Real-time replacement disabled");
					}
				}
			}
		}

		/// <summary>
		/// Analyze current input field text
		/// </summary>
		[ContextMenu("Analyze Current Text")]
		public void AnalyzeCurrentText()
		{
			if (inputField != null)
			{
				TextDebugUtility.AnalyzeInputText(inputField.text, $"SimpleCharacterReplacer ({gameObject.name})");
			}
		}
	}
}