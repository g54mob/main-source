using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

namespace SPACE__SYNTAX_HIGHLIGHTER__SYSTEM
{
	/// <summary>
	/// Python-like syntax highlighting with Claude Dark Theme colors
	/// Uses placeholder protection system to prevent recursive highlighting bugs
	/// </summary>
	public class PythonSyntaxHighlighter : SyntaxHighlighterBase
	{
		/* previous color scheme
		[Header("Python Color Scheme (Claude Dark)")]
		[SerializeField] private Color commentColor = new Color(0.42f, 0.45f, 0.50f, 1f);      // #6B7280 Gray   	 // #6B7280 Gray, new: #2A2D33
		[SerializeField] private Color keywordColor = new Color(0.75f, 0.52f, 0.99f, 1f);      // #C084FC Purple	 // #C084FC Purple, new: #BC4DA9
		[SerializeField] private Color stringColor = new Color(0.20f, 0.83f, 0.60f, 1f);       // #34D399 Green		 // #34D399 Green, new: #BC8649
		[SerializeField] private Color numberColor = new Color(0.38f, 0.65f, 0.98f, 1f);       // #60A5FA Blue		 // #60A5FA Blue, new: #EC672B
		[SerializeField] private Color operatorColor = new Color(0.96f, 0.45f, 0.71f, 1f);     // #F472B6 Pink		 // #F472B6 Pink, new: #3CA2C3
		[SerializeField] private Color builtinColor = new Color(0.98f, 0.75f, 0.14f, 1f);      // #FBBF24 Amber		 // #FBBF24 Amber, new: #666CE9
		[SerializeField] private Color customBuiltinColor = new Color(0.98f, 0.57f, 0.24f, 1f); // #FB923C Orange	  // #FB923C Orange, new: #CC4033
		*/
		// new color scheme
		[Header("Python Color Scheme (Claude Dark)")]
		[SerializeField] private Color commentColor = new Color(0.16f, 0.18f, 0.20f, 1f);      // #2A2D33
		[SerializeField] private Color keywordColor = new Color(0.74f, 0.30f, 0.66f, 1f);      // #BC4DA9
		[SerializeField] private Color stringColor = new Color(0.74f, 0.53f, 0.29f, 1f);       // #BC8649
		[SerializeField] private Color numberColor = new Color(0.93f, 0.40f, 0.17f, 1f);       // #EC672B
		[SerializeField] private Color operatorColor = new Color(0.24f, 0.64f, 0.76f, 1f);     // #3CA2C3
		[SerializeField] private Color builtinColor = new Color(0.25f, 0.46f, 0.73f, 1f);      // 
		[SerializeField] private Color customBuiltinColor = new Color(0.80f, 0.25f, 0.20f, 1f); // #CC4033

		[Header("Python Syntax Configuration")]
		[SerializeField]
		private string[] keywords = new string[]
		{
			"def", "class", "if", "elif", "else", "while", "for", "in", "return",
			"import", "from", "as", "try", "except", "finally", "with", "lambda",
			"yield", "pass", "break", "continue", "True", "False", "None", "and",
			"or", "not", "is", "global", "nonlocal", "assert", "del", "raise"
		};

		[SerializeField]
		private string[] builtins = new string[]
		{
			"print", "len", "range", "str", "int", "float", "bool", "list", "dict",
			"tuple", "set", "abs", "sum", "min", "max", "sorted", "reversed",
			"enumerate", "zip", "map", "filter", "open", "input", "type", "isinstance"
		};

		[SerializeField]
		private string[] customBuiltins = new string[]
		{
            // User can add custom function/class names here via Inspector
        };

		// CRITICAL: Placeholder protection system to prevent recursive highlighting
		private Dictionary<string, string> protectedContent = new Dictionary<string, string>();
		private int placeholderCounter = 0;

		// Cache compiled regex patterns for performance
		private static Regex commentPattern;
		private static Regex tripleDoubleStringPattern;
		private static Regex tripleSingleStringPattern;
		private static Regex doubleStringPattern;
		private static Regex singleStringPattern;
		private static Regex numberPattern;

		private void Awake()
		{
			// Initialize static regex patterns (only once)
			if (commentPattern == null)
			{
				commentPattern = new Regex(@"(#.*)(?=\n|$)", RegexOptions.Compiled);
				tripleDoubleStringPattern = new Regex(@"(""""""[\s\S]*?"""""")", RegexOptions.Compiled);
				tripleSingleStringPattern = new Regex(@"('''[\s\S]*?''')", RegexOptions.Compiled);
				doubleStringPattern = new Regex(@"(""(?:[^""\\]|\\.)*"")", RegexOptions.Compiled);
				singleStringPattern = new Regex(@"('(?:[^'\\]|\\.)*')", RegexOptions.Compiled);
				numberPattern = new Regex(@"\b(0x[0-9A-Fa-f]+|0b[01]+|0o[0-7]+|\d+\.?\d*(?:[eE][+-]?\d+)?)\b", RegexOptions.Compiled);
			}
		}

		protected override string ApplySyntaxHighlighting(string plainText)
		{
			if (string.IsNullOrEmpty(plainText))
				return plainText;

			protectedContent.Clear();
			placeholderCounter = 0;

			string result = plainText;

			// Apply highlighting with protection (ORDER MATTERS!)
			// 1. Comments (highest precedence - can contain anything)
			result = ApplyAndProtect(result, HighlightComments);

			// 2. Strings (can contain operators, keywords, etc.)
			result = ApplyAndProtect(result, HighlightStrings);

			// 3. Numbers
			result = ApplyAndProtect(result, HighlightNumbers);

			// 4. Keywords
			result = ApplyAndProtect(result, HighlightKeywords);

			// 5. Built-ins
			result = ApplyAndProtect(result, HighlightBuiltins);

			// 6. Custom Built-ins
			result = ApplyAndProtect(result, HighlightCustomBuiltins);

			// 7. Operators (CRITICAL: Special handling to prevent recursion)
			result = HighlightOperatorsWithProtection(result);

			// 8. Restore all placeholders
			result = RestoreProtectedContent(result);

			return result;
		}

		#region Highlighting Methods

		private string HighlightComments(string text)
		{
			return commentPattern.Replace(text, match => ColorWrap(match.Value, commentColor));
		}

		private string HighlightStrings(string text)
		{
			// Order matters: triple quotes must be processed first!
			text = tripleDoubleStringPattern.Replace(text, match => ColorWrap(match.Value, stringColor));
			text = tripleSingleStringPattern.Replace(text, match => ColorWrap(match.Value, stringColor));
			text = doubleStringPattern.Replace(text, match => ColorWrap(match.Value, stringColor));
			text = singleStringPattern.Replace(text, match => ColorWrap(match.Value, stringColor));
			return text;
		}

		private string HighlightNumbers(string text)
		{
			return numberPattern.Replace(text, match => ColorWrap(match.Value, numberColor));
		}

		private string HighlightKeywords(string text)
		{
			foreach (string keyword in keywords)
			{
				string pattern = @"\b" + Regex.Escape(keyword) + @"\b";
				text = Regex.Replace(text, pattern, match => ColorWrap(match.Value, keywordColor));
			}
			return text;
		}

		private string HighlightBuiltins(string text)
		{
			foreach (string builtin in builtins)
			{
				// Only highlight if followed by '(' (function call)
				string pattern = @"\b" + Regex.Escape(builtin) + @"(?=\s*\()";
				text = Regex.Replace(text, pattern, match => ColorWrap(match.Value, builtinColor));
			}
			return text;
		}

		private string HighlightCustomBuiltins(string text)
		{
			if (customBuiltins == null || customBuiltins.Length == 0)
				return text;

			foreach (string customBuiltin in customBuiltins)
			{
				if (string.IsNullOrEmpty(customBuiltin))
					continue;

				// Only highlight if followed by '(' (function call)
				string pattern = @"\b" + Regex.Escape(customBuiltin) + @"(?=\s*\()";
				text = Regex.Replace(text, pattern, match => ColorWrap(match.Value, customBuiltinColor));
			}
			return text;
		}

		private string HighlightOperatorsWithProtection(string text)
		{
			// CRITICAL: Longest operators first to prevent partial matches
			string[] operators = new string[]
			{
				@"\*\*", @"//", @"<<", @">>",           // Two-character operators
                @"==", @"!=", @"<=", @">=",
				@"\+=", @"-=", @"\*=", @"/=", @"%=",
				@"\+", @"-", @"\*", @"/", @"%",         // Single-character operators
                @"<", @">", @"=",
				@"&", @"\|", @"\^", @"~", @"@"
			};

			// CRITICAL: Protect after EACH operator to prevent recursive highlighting!
			foreach (string op in operators)
			{
				text = Regex.Replace(text, op, match => ColorWrap(match.Value, operatorColor));
				text = ProtectColorTags(text); // ← Immediate protection!
			}

			return text;
		}

		#endregion

		#region Placeholder Protection System

		/// <summary>
		/// Apply highlighting function and immediately protect resulting color tags
		/// </summary>
		private string ApplyAndProtect(string text, Func<string, string> highlightFunc)
		{
			text = highlightFunc(text);
			text = ProtectColorTags(text);
			return text;
		}

		/// <summary>
		/// Replace color tags with unique placeholders using control characters
		/// Control characters (\x02, \x03) never appear in normal code
		/// </summary>
		private string ProtectColorTags(string text)
		{
			return Regex.Replace(text, @"<color=#[0-9A-Fa-f]{6}>.*?</color>", match =>
			{
				string placeholder = $"\x02PLACEHOLDER_{placeholderCounter}\x03";
				protectedContent[placeholder] = match.Value;
				placeholderCounter++;
				return placeholder;
			}, RegexOptions.Singleline);
		}

		/// <summary>
		/// Restore all protected content at the end
		/// </summary>
		private string RestoreProtectedContent(string text)
		{
			foreach (var kvp in protectedContent)
			{
				text = text.Replace(kvp.Key, kvp.Value);
			}
			return text;
		}

		#endregion

		#region Debug Tools

		[ContextMenu("Test Simple Case")]
		private void TestSimpleCase()
		{
			if (sourceText == null || syntaxOverlayText == null)
			{
				Debug.LogError("TextMeshPro references not assigned!");
				return;
			}

			string testCode = @"# This is a comment
a = 5 + 3
print('Hello World')
if a == 8:
    result = True";

			sourceText.text = testCode;
			UpdateSyntaxVisual();

			// Validate output
			string output = syntaxOverlayText.text;
			if (output.Contains("<color<color"))
			{
				Debug.LogError("❌ NESTED TAGS DETECTED! Recursive highlighting bug!");
			}
			else
			{
				Debug.Log("✓ Highlighting appears correct!");
				Debug.Log($"Output preview:\n{output.Substring(0, Mathf.Min(200, output.Length))}...");
			}
		}

		[ContextMenu("Test Edge Cases")]
		private void TestEdgeCases()
		{
			if (sourceText == null || syntaxOverlayText == null)
			{
				Debug.LogError("TextMeshPro references not assigned!");
				return;
			}

			string testCode = @"# Test operators in strings
text = 'a = b + c'
x = 1 + 2 * 3 / 4 - 5 ** 6 // 7

# Test strings
s1 = 'single'
s2 = ""double""
s3 = '''triple
multi-line'''

# Test numbers
hex_num = 0xFF
bin_num = 0b1010
float_num = 3.14e-10";

			sourceText.text = testCode;
			UpdateSyntaxVisual();

			string output = syntaxOverlayText.text;
			if (output.Contains("<color<color"))
			{
				Debug.LogError("❌ NESTED TAGS DETECTED!");
			}
			else
			{
				Debug.Log("✓ Edge cases handled correctly!");
			}
		}

		#endregion
	}
}