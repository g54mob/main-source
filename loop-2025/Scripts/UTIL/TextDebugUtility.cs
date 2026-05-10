using System;
using System.Linq;
using System.Text;

using UnityEngine;

namespace GptDeepResearch
{
	/// <summary>
	/// Utility class for debugging text input issues in the Python scripting system
	/// </summary>
	public static class TextDebugUtility
	{
		#region just to debug
		/// <summary>
		/// Analyze input text and log detailed information about potential issues
		/// </summary>
		public static void AnalyzeInputText(string text, string source = "Unknown")
		{
			Debug.Log($"=== TEXT ANALYSIS for {source} ===");

			if (text == null)
			{
				Debug.LogError("Text is NULL");
				return;
			}

			if (text.Length == 0)
			{
				Debug.LogWarning("Text is empty string");
				return;
			}

			Debug.Log($"Text length: {text.Length} characters");

			// Check for BOM
			if (text.Length > 0 && text[0] == '\uFEFF')
			{
				Debug.LogWarning("⚠️ Text starts with BOM (Byte Order Mark) - this will cause lexer errors!");
			}

			// Analyze problematic characters
			var problematicChars = new StringBuilder();
			var charCounts = new System.Collections.Generic.Dictionary<char, int>();

			for (int i = 0; i < text.Length; i++)
			{
				char c = text[i];

				if (!charCounts.ContainsKey(c))
					charCounts[c] = 0;
				charCounts[c]++;

				// Check for problematic characters
				if (c == '\uFEFF' || c == '\u200B' || c == '\u200C' || c == '\u200D' ||
					c == '\u2060' || c == '\u00A0' || c == '\0')
				{
					problematicChars.AppendLine($"Position {i}: {GetCharacterDescription(c)}");
				}
			}

			if (problematicChars.Length > 0)
			{
				Debug.LogError("🚨 PROBLEMATIC CHARACTERS FOUND:\n" + problematicChars.ToString());
			}

			// Show first 20 characters with detailed info
			Debug.Log("First 20 characters:");
			for (int i = 0; i < Math.Min(20, text.Length); i++)
			{
				Debug.Log($"[{i:D2}] {GetCharacterDescription(text[i])}");
			}

			// Line ending analysis
			int crCount = text.Count(c => c == '\r');
			int lfCount = text.Count(c => c == '\n');
			int crlfCount = text.Split(new string[] { "\r\n" }, StringSplitOptions.None).Length - 1;

			Debug.Log($"Line endings - CR: {crCount}, LF: {lfCount}, CRLF: {crlfCount}");

			if (crCount > 0 && lfCount > crlfCount)
			{
				Debug.LogWarning("⚠️ Mixed line endings detected - this can cause parsing issues!");
			}

			// Show lines structure
			string[] lines = text.Split('\n');
			Debug.Log($"Total lines: {lines.Length}");

			for (int i = 0; i < Math.Min(5, lines.Length); i++)
			{
				string line = lines[i];
				string display = line.Replace('\t', '→').Replace('\r', '↵');
				Debug.Log($"Line {i + 1}: '{display}' (length: {line.Length})");
			}
		}

		/// <summary>
		/// Get detailed description of a character
		/// </summary>
		public static string GetCharacterDescription(char c)
		{
			if (c == '\0') return "NULL (\\0) [0x00]";
			if (c == '\t') return "TAB (\\t) [0x09]";
			if (c == '\n') return "LF (\\n) [0x0A]";
			if (c == '\v') return "VERTICAL TAB (\\v) [0x0B] ⚠️ PROBLEMATIC!";
			if (c == '\f') return "FORM FEED (\\f) [0x0C]";
			if (c == '\r') return "CR (\\r) [0x0D]";
			if (c == ' ') return "SPACE [0x20]";
			if (c == '\uFEFF') return "BOM (\\uFEFF) ⚠️ PROBLEMATIC!";
			if (c == '\u200B') return "ZERO-WIDTH SPACE (\\u200B) ⚠️ PROBLEMATIC!";
			if (c == '\u200C') return "ZERO-WIDTH NON-JOINER (\\u200C) ⚠️ PROBLEMATIC!";
			if (c == '\u200D') return "ZERO-WIDTH JOINER (\\u200D) ⚠️ PROBLEMATIC!";
			if (c == '\u2060') return "WORD JOINER (\\u2060) ⚠️ PROBLEMATIC!";
			if (c == '\u00A0') return "NON-BREAKING SPACE (\\u00A0) ⚠️ PROBLEMATIC!";

			if (char.IsControl(c))
				return $"CONTROL-CHAR [0x{((int)c):X2}] (U+{((int)c):X4}) ⚠️ LIKELY PROBLEMATIC!";

			if (c > 127)
				return $"'{c}' (U+{((int)c):X4}) [0x{((int)c):X2}]";

			return $"'{c}' [0x{((int)c):X2}] (ASCII {(int)c})";
		}

		/// <summary>
		/// Test the sanitization function
		/// </summary>
		public static void TestSanitization(string input)
		{
			Debug.Log("=== SANITIZATION TEST ===");
			Debug.Log("BEFORE:");
			AnalyzeInputText(input, "Original");

			string sanitized = SanitizeText(input);

			Debug.Log("AFTER:");
			AnalyzeInputText(sanitized, "Sanitized");
		}

		#endregion

		/// <summary>
		/// Sanitize text (same logic as ScriptRunner but as static utility)
		/// </summary>
		public static string SanitizeText(string input)
		{
			if (string.IsNullOrEmpty(input))
				return "";

			// Step 1: Remove BOM if present
			if (input.Length > 0 && input[0] == '\uFEFF')
			{
				input = input.Substring(1);
			}

			// Step 2: Normalize line endings
			input = input.Replace("\r\n", "\n").Replace("\r", "\n");

			// Step 3: Remove problematic control characters
			var problematicChars = new char[]
			{
				'\u200B', '\u200C', '\u200D', '\u2060', '\uFEFF', '\u00A0',
				'\v', '\f', '\b', '\a', '\0'  // ADD control characters including 0x0B
            };

			foreach (char c in problematicChars)
			{
				input = input.Replace(c.ToString(), "");
			}

			// Step 3b: Remove ANY remaining control characters except \n, \r, \t
			var cleanedInput = new StringBuilder();
			foreach (char c in input)
			{
				if (char.IsControl(c))
				{
					// Only allow these control characters
					if (c == '\n' || c == '\r' || c == '\t')
					{
						cleanedInput.Append(c);
					}
					// Skip all other control characters
				}
				else
				{
					cleanedInput.Append(c);
				}
			}
			input = cleanedInput.ToString();

			// Step 4: PRESERVE tabs - do NOT convert to spaces
			// Python code needs actual tab characters preserved
			// input = input.Replace("\t", "    "); // REMOVED - keep tabs as tabs

			// Step 5: Clean up lines
			string[] lines = input.Split('\n');
			for (int i = 0; i < lines.Length; i++)
			{
				lines[i] = lines[i].TrimEnd();
			}

			var lineList = new System.Collections.Generic.List<string>(lines);
			while (lineList.Count > 0 && string.IsNullOrWhiteSpace(lineList[0]))
			{
				lineList.RemoveAt(0);
			}
			while (lineList.Count > 0 && string.IsNullOrWhiteSpace(lineList[lineList.Count - 1]))
			{
				lineList.RemoveAt(lineList.Count - 1);
			}

			return string.Join("\n", lineList.ToArray());
		}
	}
}