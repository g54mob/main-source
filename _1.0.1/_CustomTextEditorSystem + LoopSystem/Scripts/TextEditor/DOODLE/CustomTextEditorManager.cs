using System.Text;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using SPACE_UTIL;
using SPACE__SYNTAX_HIGHLIGHTER__SYSTEM;

namespace SPACE__CUSTOM_TEXT_EDITOR__SYSTEM
{
	public class CustomTextEditorManager : MonoBehaviour
	{
		#region Public API: get .text for external use 
		public string text
		{
			get
			{
				string STR = "";
				foreach (var line in lines)
					STR += $"{line.ToString()}\n";
				return STR;
			}
		}
		#endregion
		#region UnityLifeCycle
		private void Start()
		{
			if (lines.Count == 0)
				lines.Add(new StringBuilder());
			UpdateEntireDisplayVisual();

		}
		private void Update()
		{
			if (INPUT.UI.Hover) // do nothing when on top of any UI
				return;
			HandleMouseInput();
			HandleKeyBoardInput();
		} 
		#endregion

		[Header("STORAGE: just to log")]
		// STORE
		[SerializeField] List<StringBuilder> lines = new List<StringBuilder>();
		[SerializeField] v2 caret = (0, 0);
		// linear selection
		[SerializeField] public v2 selectionStartCaret = (0, 0);
		[SerializeField] public bool isSelecting = false;

		#region DISPLAY, VISUAL UPDATES Storage
		[Header("DISPLAY, VISUAL UPDATES Storage")]
		[SerializeField] Transform _caretTr;
		[SerializeField] Transform _selectionStartTr;
		[SerializeField] GameObject _selectionMeshContainer;
		[SerializeField] TextMeshPro _textField;
		[SerializeField] TextMeshPro _lineNumText;
		#endregion

		public static int tabSize = 4;
		[SerializeField] float _fontCharWidth = 1f; // haven't used this anywhere since the fontSize of 16f with bold consolas font shall lead to char size of 1.
		[SerializeField] float _fontLineHeight = 2.24f; // both textField/lineNum fontSize set to 16f with bold consolas font in TMPro.TextMeshPro Component Inspector.

		#region Undo/Redo System

		[System.Serializable]
		public class EditorState
		{
			public List<string> lines;           // Snapshot of all lines
			public v2 caret;                      // Caret position
			public v2 selectionStartCaret;        // Selection start
			public bool isSelecting;              // Selection state

			public EditorState(List<StringBuilder> sourceLines, v2 caret, v2 selStart, bool selecting)
			{
				// Deep copy lines (convert StringBuilder to string)
				lines = new List<string>(sourceLines.Count);
				foreach (var line in sourceLines)
					lines.Add(line.ToString());

				this.caret = caret;
				this.selectionStartCaret = selStart;
				this.isSelecting = selecting;
			}

			// Restore state back to editor
			public void RestoreTo(List<StringBuilder> targetLines, ref v2 targetCaret, ref v2 targetSelStart, ref bool targetSelecting)
			{
				targetLines.Clear();
				foreach (var line in lines)
					targetLines.Add(new StringBuilder(line));

				targetCaret = caret;
				targetSelStart = selectionStartCaret;
				targetSelecting = isSelecting;
			}
		}

		// Undo/Redo configuration
		[Header("Undo/Redo Settings")]
		[SerializeField] private int maxUndoSteps = 128;

		// Undo/Redo stacks
		private Stack<EditorState> undoStack = new Stack<EditorState>();
		private Stack<EditorState> redoStack = new Stack<EditorState>();

		// Track typing for smart grouping
		private enum UndoActionType { None, Typing, Deleting, Other }
		private UndoActionType lastActionType = UndoActionType.None;
		private char lastTypedChar = '\0';  // Track last character typed

		// Record state before modification
		private void RecordUndoState(UndoActionType actionType = UndoActionType.Other, char currentChar = '\0')
		{
			bool shouldRecord = true;

			// Smart grouping logic
			if (actionType == UndoActionType.Typing && lastActionType == UndoActionType.Typing)
			{
				// Break typing group on these conditions:
				// 1. Space after non-space (end of word)
				// 2. Non-space after space (start of new word)
				// 3. Punctuation or special characters
				// 4. Change in character type (letter -> number, etc.)

				bool lastWasSpace = char.IsWhiteSpace(lastTypedChar);
				bool currentIsSpace = char.IsWhiteSpace(currentChar);
				bool lastWasPunctuation = char.IsPunctuation(lastTypedChar) || char.IsSymbol(lastTypedChar);
				bool currentIsPunctuation = char.IsPunctuation(currentChar) || char.IsSymbol(currentChar);

				// Continue grouping (don't record) if:
				// - Both are letters/digits (typing a word)
				// - Both are spaces (typing multiple spaces)
				if ((char.IsLetterOrDigit(lastTypedChar) && char.IsLetterOrDigit(currentChar)) ||
					(lastWasSpace && currentIsSpace))
				{
					shouldRecord = false;
				}
				// Break on word boundary or punctuation
				else if (lastWasSpace != currentIsSpace || lastWasPunctuation || currentIsPunctuation)
				{
					shouldRecord = true;
				}
			}
			else if (actionType == UndoActionType.Deleting && lastActionType == UndoActionType.Deleting)
			{
				// Group consecutive deletions (backspace spam)
				shouldRecord = false;
			}
			else if (actionType == UndoActionType.Other)
			{
				// Always record for paste, newline, indent, etc.
				shouldRecord = true;
			}

			if (!shouldRecord)
			{
				lastTypedChar = currentChar;
				return;
			}

			// Create snapshot
			EditorState state = new EditorState(lines, caret, selectionStartCaret, isSelecting);

			// Add to undo stack
			undoStack.Push(state);

			// Enforce max limit
			if (undoStack.Count > maxUndoSteps)
			{
				// Remove oldest (bottom) item
				var tempList = undoStack.ToList();
				tempList.RemoveAt(tempList.Count - 1);
				undoStack = new Stack<EditorState>(tempList.AsEnumerable().Reverse());
			}

			// Clear redo stack on new action
			redoStack.Clear();

			// Update tracking
			lastActionType = actionType;
			lastTypedChar = currentChar;
		}

		public void Undo()
		{
			if (undoStack.Count == 0)
			{
				Debug.Log("Nothing to undo");
				return;
			}

			// Save current state to redo stack
			EditorState currentState = new EditorState(lines, caret, selectionStartCaret, isSelecting);
			redoStack.Push(currentState);

			// Restore previous state
			EditorState previousState = undoStack.Pop();
			previousState.RestoreTo(lines, ref caret, ref selectionStartCaret, ref isSelecting);

			// Reset action type
			lastActionType = UndoActionType.None;
			lastTypedChar = '\0';

			UpdateEntireDisplayVisual();
			Debug.Log($"Undo performed. Undo stack: {undoStack.Count}, Redo stack: {redoStack.Count}");
		}

		public void Redo()
		{
			if (redoStack.Count == 0)
			{
				Debug.Log("Nothing to redo");
				return;
			}

			// Save current state to undo stack
			EditorState currentState = new EditorState(lines, caret, selectionStartCaret, isSelecting);
			undoStack.Push(currentState);

			// Restore next state
			EditorState nextState = redoStack.Pop();
			nextState.RestoreTo(lines, ref caret, ref selectionStartCaret, ref isSelecting);

			// Reset action type
			lastActionType = UndoActionType.None;
			lastTypedChar = '\0';

			UpdateEntireDisplayVisual();
			Debug.Log($"Redo performed. Undo stack: {undoStack.Count}, Redo stack: {redoStack.Count}");
		}

		#endregion

		#region Selection System
		public bool hasTextInsideSelection => !(selectionStartCaret == caret);
		
		// Get normalized bounds (ensure start < end)
		(v2 start, v2 end) GetSelectionBounds()
		{
			v2 start = selectionStartCaret;
			v2 end = caret;

			// Normalize: start should come before end
			if (start.y > end.y || (start.y == end.y && start.x > end.x))
			{
				(start, end) = (end, start); // Swap
			}

			return (start, end);
		}

		// Extract selected text
		string GetSelectedText()
		{
			if (hasTextInsideSelection == false) return "";

			var (start, end) = GetSelectionBounds();
			var result = new StringBuilder();

			if (start.y == end.y)
			{
				// Single line
				result.Append(lines[start.y].ToString()
					.Substring(start.x, end.x - start.x));
			}
			else
			{
				// Multiple lines
				// First line: from start.x to end of line
				result.AppendLine(lines[start.y].ToString().Substring(start.x));

				// Middle lines: entire lines
				for (int row = start.y + 1; row < end.y; row++)
				{
					result.AppendLine(lines[row].ToString());
				}

				// Last line: from start to end.x
				result.Append(lines[end.y].ToString().Substring(0, end.x));
			}

			return result.ToString();
		}

		void SelectAll()
		{
			RecordUndoState(UndoActionType.Other);  // Undo/Redo
			isSelecting = true;
			selectionStartCaret = (0, 0);
			caret = (lines[lines.Count - 1].Length, lines.Count - 1);
			UpdateEntireDisplayVisual();
		}
		void CopySelection()
		{
			if (hasTextInsideSelection == false)
				return;

			string selectedText = GetSelectedText();
			LOG.AddLog(selectedText, "copySeleciton");
			GUIUtility.systemCopyBuffer = selectedText;
		}
		void CutSelection()
		{
			RecordUndoState(UndoActionType.Other);  // ← ADD THIS LINE AT THE START

			if (hasTextInsideSelection == false)
				return;
			string selectedText = GetSelectedText();

			LOG.AddLog(selectedText, "cutSelection");
			GUIUtility.systemCopyBuffer = selectedText;
			DeleteSelection();
		}
		void PasteText()
		{
			RecordUndoState(UndoActionType.Other);  // ← ADD THIS LINE AT THE START

			string clipBoardText = GUIUtility.systemCopyBuffer;
			InsertText(str: clipBoardText);
		}

		void DeSelectAllAndUpdateAllVisual()
		{
			isSelecting = false;
			selectionStartCaret = caret;
			UpdateEntireDisplayVisual();
		}
		#endregion

		#region Text Input(@caret) & Deletion(@caret or selection) Core(without Undo/Redo System)
		void InsertChar(char c)
		{
			Debug.Log(C.method(this, "cyan", adMssg: $"{c} has been inserted"));
			RecordUndoState(UndoActionType.Typing, c);  // ← PASS THE CHARACTER HERE

			if (hasTextInsideSelection)
			{
				DeleteSelection(); // isSelecting, updateVisual is taken care inside.
			}
			lines[caret.y].Insert(caret.x, c);
			caret.x += 1;

			// deselect all before update visual
			DeSelectAllAndUpdateAllVisual();
		}
		void InsertNewLine(bool applyAutoIndent = true, bool shouldRecord_UR = true)
		{
			Debug.Log(C.method(this, "cyan"));
			if (shouldRecord_UR)
				RecordUndoState(UndoActionType.Other);  // ← ADD THIS LINE

			// Split current line at caret
			string remainingOfCaretLine = lines[caret.y].ToString().Substring(caret.x);
			lines[caret.y].Length = caret.x;

			// Create new line with remaining text
			caret.y += 1;
			lines.Insert(caret.y, new StringBuilder(remainingOfCaretLine));
			caret.x = 0;

			// AUTO-INDENTATION: Add here for Python-like languages
			// Example: DetectAndApplyAutoIndent();
			if (applyAutoIndent)
				DetectAndApplyAutoIndent();

			// deselect all before update visual
			DeSelectAllAndUpdateAllVisual();
		}
		void InsertTab(bool shouldRecord_UR = true)
		{
			Debug.Log(C.method(this, "cyan"));
			if (hasTextInsideSelection == true)
			{
				IndentLines();
				return;
			}
			if (shouldRecord_UR)
				RecordUndoState(UndoActionType.Other);  // ← ADD THIS LINE

			string spaces = new string(' ', tabSize); // insert tabSize * spaceChar instead(to make the grid functionality seemless)
			lines[caret.y].Insert(caret.x, spaces); caret.x += tabSize;
			// lines[caret.y].Insert(caret.x, '\t'); caret.x += 1;
			// deselect, if selection still turned on or even if there is selection all before update visual
			DeSelectAllAndUpdateAllVisual();
		}
		void DeleteChar()
		{
			Debug.Log(C.method(this, "cyan"));
			RecordUndoState(UndoActionType.Deleting);  // ← ADD THIS LINE

			if (hasTextInsideSelection == true)
			{
				Debug.Log(C.method(this, "orange", adMssg: "deleted text inside selection"));
				DeleteSelection(); // startSelectionCaret position is taken care there, as well as isSelecting turn off
				return;
			}

			if (caret.x > 0)
			{
				// Identify character type before caret
				string line = lines[caret.y].ToString();
				int deleteStart = caret.x;
				char lastChar = line[deleteStart - 1];
				if (char.IsWhiteSpace(lastChar)) // delete continuos space
				{
					// Delete ALL whitespace
					while (deleteStart > 0 && char.IsWhiteSpace(line[deleteStart - 1]))
						deleteStart--;
					int deleteCount = caret.x - deleteStart;
					lines[caret.y].Remove(deleteStart, deleteCount);
					caret.x = deleteStart;
				}
				else // default: delete a char
				{
					caret.x -= 1;
					lines[caret.y].Remove(caret.x, 1);
				}
			}
			else // @caret.x == 0
			{
				if (caret.y > 0)
				{
					caret.x = lines[caret.y - 1].Length;
					lines[caret.y - 1].Append(lines[caret.y].ToString());
					lines.RemoveAt(caret.y);
					caret.y -= 1;
				}
			}
			//
			DeSelectAllAndUpdateAllVisual();
		}
		void DeleteWord()
		{
			Debug.Log(C.method(this, "cyan"));
			RecordUndoState(UndoActionType.Deleting);  // ← ADD THIS LINE

			if (hasTextInsideSelection == true)
			{
				Debug.Log(C.method(this, "orange", adMssg: "deleted text inside selection"));
				DeleteSelection(); // startSelectionCaret position is taken care there, as well as isSelecting turn off
				return;
			}
			if (caret.x == 0)
			{
				DeleteChar();
				return;
			}

			string line = lines[caret.y].ToString();
			int deleteStart = caret.x;

			// Identify character type before caret
			char lastChar = line[deleteStart - 1];

			if (char.IsWhiteSpace(lastChar))
			{
				// Delete ALL whitespace
				while (deleteStart > 0 && char.IsWhiteSpace(line[deleteStart - 1]))
					deleteStart--;
			}
			else if (char.IsLetterOrDigit(lastChar) || lastChar == '_')
			{
				// Delete word characters
				while (deleteStart > 0 &&
					   (char.IsLetterOrDigit(line[deleteStart - 1]) ||
						line[deleteStart - 1] == '_'))
					deleteStart--;
			}
			else
			{
				// Delete ONE special character
				deleteStart--;
			}

			int deleteCount = caret.x - deleteStart;
			lines[caret.y].Remove(deleteStart, deleteCount);
			caret.x = deleteStart;
			//
			DeSelectAllAndUpdateAllVisual();
		}
		#region ad (Auto-Indentation)
		// implement these for Python-like auto-indentation:
		void DetectAndApplyAutoIndent()
		{
			// if (caretRow == 0) return;
			string previousLine = lines[caret.y - 1].ToString();

			int GetIndentLevel(string line)
			{
				int spaces = 0;
				for (int i = 0; i < line.Length; i += 1)
				{
					if (line[i] == ' ')
						spaces += 1;
					else if (line[i] == '\t')
						spaces += tabSize;
					else
						break;
				}
				return spaces;
			}
			int indentLevel = GetIndentLevel(previousLine);

			// Check if previous line ends with colon (Python)
			if (previousLine.TrimEnd().EndsWith(":") || previousLine.TrimEnd().EndsWith(","))
			{
				indentLevel += tabSize;
			}

			// Apply indentation
			if (indentLevel > 0)
			{
				string indent = new string(' ', indentLevel);
				lines[caret.y].Insert(0, indent);
				caret.x = indentLevel;
			}
		}

		#endregion
		void DeleteSelection()
		{
			if (hasTextInsideSelection == false) return;
			RecordUndoState(UndoActionType.Other);  // ← ADD THIS LINE AT THE START

			// RecordHistory();

			var (start, end) = GetSelectionBounds();

			if (start.y == end.y)
			{
				// Single line deletion
				lines[start.y].Remove(start.x, end.x - start.x);
			}
			else
			{
				// Multi-line deletion
				string beforeSel = lines[start.y].ToString().Substring(0, start.x);
				string afterSel = lines[end.y].ToString().Substring(end.x);

				// Merge start and end lines
				lines[start.y] = new StringBuilder(beforeSel + afterSel);

				// Remove intermediate lines
				for (int i = end.y; i > start.y; i--)
				{
					lines.RemoveAt(i);
				}
			}

			// Move caret to selection start
			caret = start;
			isSelecting = false;
			selectionStartCaret = caret;
			// ClearSelection();
			DeSelectAllAndUpdateAllVisual();
		}
		void InsertText(string str)
		{
			// well lets see how does that foes
			if (string.IsNullOrEmpty(str)) return;
			// RecordUndoState(UndoActionType.Other);  // ← ADD THIS LINE AT THE START, since Undo/Redo is taken care inside PasteText();

			if (hasTextInsideSelection)
				DeleteSelection();

			// Insert character by character to maintain consistency
			foreach (char c in str)
			{
				if (c == '\n')
				{
					InsertNewLine(applyAutoIndent: false, shouldRecord_UR: false); // Reuses existing method with no autoIndent(got non-desirable result with auto-indent turned on).
				}
				else if (c == '\t')
				{
					InsertTab(shouldRecord_UR: false); // Reuses existing method
				}
				else if (c >= ' ' && c != '\b' && c != '\r') // Printable characters only
				{
					lines[caret.y].Insert(caret.x, c);
					caret.x += 1;
				}
			}
			//
			DeSelectAllAndUpdateAllVisual();
		}
		#region Indent, Unindent
		void IndentLines()
		{

			// if (!hasTextInsideSelection) return; // (works even without selection via ctrl + ])
			Debug.Log(C.method(this, "cyan"));
			RecordUndoState(UndoActionType.Other);  // ← ADD THIS LINE AT THE START

			var (start, end) = GetSelectionBounds();

			for (int row = start.y; row <= end.y; row++)
			{
				lines[row].Insert(0, new string(' ', tabSize));
			}

			// Adjust caret/selection positions
			if (selectionStartCaret.y >= start.y && selectionStartCaret.y <= end.y)
				selectionStartCaret.x += tabSize;
			if (caret.y >= start.y && caret.y <= end.y)
				caret.x += tabSize;

			UpdateEntireDisplayVisual();
		}
		void UnIndentLines()
		{
			// if (!hasTextInsideSelection) return; //  // (works even without selection via ctrl + [)
			Debug.Log(C.method(this, "cyan"));
			RecordUndoState(UndoActionType.Other);  // ← ADD THIS LINE AT THE START

			var (start, end) = GetSelectionBounds();

			for (int row = start.y; row <= end.y; row++)
			{
				string line = lines[row].ToString();
				int spacesToRemove = 0;

				for (int i = 0; i < Mathf.Min(tabSize, line.Length); i++)
				{
					if (line[i] == ' ') spacesToRemove++;
					else break;
				}

				if (spacesToRemove > 0)
				{
					lines[row].Remove(0, spacesToRemove);

					// Adjust positions
					if (selectionStartCaret.y == row)
						selectionStartCaret.x = Mathf.Max(0, selectionStartCaret.x - spacesToRemove);
					if (caret.y == row)
						caret.x = Mathf.Max(0, caret.x - spacesToRemove);
				}
			}

			UpdateEntireDisplayVisual();
		}
		#endregion
		#region Comment Toggle (Python-style)

		[Header("Comment Settings")]
		[SerializeField] private string commentPrefix = "# ";  // Python-style comment

		/// <summary>
		/// Toggle comments on selected lines (or current line if no selection)
		/// Follows Python-like rules:
		/// - If ANY line is uncommented, comment ALL
		/// - If ALL lines are commented, uncomment ALL
		/// - Comments placed at minimum indentation level
		/// </summary>
		void ToggleComment()
		{
			Debug.Log(C.method(this, "cyan"));
			RecordUndoState(UndoActionType.Other);

			var (start, end) = GetSelectionBounds();

			// Determine minimum indentation and check comment status
			int minIndent = int.MaxValue;
			bool allCommented = true;

			for (int row = start.y; row <= end.y; row++)
			{
				string line = lines[row].ToString();

				// Skip empty lines for indentation calculation
				if (string.IsNullOrWhiteSpace(line))
					continue;

				// Get indentation level
				int indent = GetLineIndentation(line);
				minIndent = Mathf.Min(minIndent, indent);

				// Check if line is commented (at any position)
				if (!IsLineCommented(line))
					allCommented = false;
			}

			// Handle edge case: all lines are empty/whitespace
			if (minIndent == int.MaxValue)
				minIndent = 0;

			// Perform comment/uncomment based on state
			if (allCommented)
			{
				UncommentLines(start.y, end.y, minIndent);
			}
			else
			{
				CommentLines(start.y, end.y, minIndent);
			}

			UpdateEntireDisplayVisual();
		}

		/// <summary>
		/// Get the indentation level (number of leading spaces) of a line
		/// </summary>
		int GetLineIndentation(string line)
		{
			int spaces = 0;
			for (int i = 0; i < line.Length; i++)
			{
				if (line[i] == ' ')
					spaces++;
				else if (line[i] == '\t')
					spaces += tabSize;
				else
					break;
			}
			return spaces;
		}

		/// <summary>
		/// Check if a line is commented (contains comment prefix after leading whitespace)
		/// </summary>
		bool IsLineCommented(string line)
		{
			string trimmed = line.TrimStart();
			return trimmed.StartsWith(commentPrefix.TrimEnd()); // Match "# " or "#"
		}

		/// <summary>
		/// Comment all lines in range at the specified indentation level
		/// </summary>
		void CommentLines(int startRow, int endRow, int indentLevel)
		{
			for (int row = startRow; row <= endRow; row++)
			{
				string line = lines[row].ToString();

				// Skip completely empty lines
				if (line.Length == 0)
					continue;

				// Find the position to insert comment
				int insertPos = Mathf.Min(indentLevel, line.Length);

				// For lines that are only whitespace, insert at end
				if (string.IsNullOrWhiteSpace(line))
					insertPos = line.Length;

				// Insert comment prefix
				lines[row].Insert(insertPos, commentPrefix);

				// Adjust caret/selection if on this row
				if (selectionStartCaret.y == row && selectionStartCaret.x >= insertPos)
					selectionStartCaret.x += commentPrefix.Length;

				if (caret.y == row && caret.x >= insertPos)
					caret.x += commentPrefix.Length;
			}
		}

		/// <summary>
		/// Uncomment all lines in range
		/// Removes comment prefix wherever it appears after leading whitespace
		/// Handles both "# " and "#" formats intelligently
		/// </summary>
		void UncommentLines(int startRow, int endRow, int indentLevel)
		{
			for (int row = startRow; row <= endRow; row++)
			{
				string line = lines[row].ToString();

				if (line.Length == 0)
					continue;

				// Find comment prefix position
				int commentPos = FindCommentPosition(line);

				if (commentPos == -1)
					continue; // Line not commented

				// Determine how many characters to remove
				int removeCount;
				string commentSymbol = commentPrefix.TrimEnd(); // Just "#"

				// Check what actually exists in the line
				if (commentPos + commentPrefix.Length <= line.Length)
				{
					// Check if full prefix "# " exists
					string fullPrefix = line.Substring(commentPos, commentPrefix.Length);
					if (fullPrefix == commentPrefix)
					{
						// Full "# " exists, remove both
						removeCount = commentPrefix.Length;
					}
					else
					{
						// Only "#" exists (no space after), remove just the symbol
						removeCount = commentSymbol.Length;
					}
				}
				else if (commentPos + commentSymbol.Length <= line.Length)
				{
					// Only "#" exists (line too short for "# "), remove just the symbol
					removeCount = commentSymbol.Length;
				}
				else
				{
					continue; // Shouldn't happen, but be safe
				}

				// Remove comment prefix
				lines[row].Remove(commentPos, removeCount);

				// Adjust caret/selection if on this row
				if (selectionStartCaret.y == row && selectionStartCaret.x > commentPos)
				{
					selectionStartCaret.x = Mathf.Max(commentPos,
						selectionStartCaret.x - removeCount);
				}

				if (caret.y == row && caret.x > commentPos)
				{
					caret.x = Mathf.Max(commentPos, caret.x - removeCount);
				}
			}
		}

		/// <summary>
		/// Find position of comment prefix in line (after leading whitespace)
		/// Returns -1 if not found
		/// </summary>
		int FindCommentPosition(string line)
		{
			// Skip leading whitespace
			int pos = 0;
			while (pos < line.Length && char.IsWhiteSpace(line[pos]))
				pos++;

			// Check if comment prefix exists at this position
			if (pos + commentPrefix.TrimEnd().Length <= line.Length)
			{
				string substring = line.Substring(pos, commentPrefix.TrimEnd().Length);
				if (substring == commentPrefix.TrimEnd())
					return pos;
			}

			return -1;
		}

		#endregion
		#endregion

		#region Caret Navigation
		#region CoordinateSystem
		public class CoordinateSystem
		{
			/// <summary>
			/// Convert logical column to visual display column
			/// Accounts for tab expansion
			/// </summary>
			public static int LogicalToVisualColumn(string line, int logicalCol)
			{
				int visualCol = 0;

				for (int i = 0; i < logicalCol && i < line.Length; i++)
				{
					if (line[i] == '\t')
					{
						// Tab expands to next multiple of tabSize
						visualCol += tabSize - (visualCol % tabSize);
					}
					else
					{
						visualCol++;
					}
				}

				return visualCol;
			}
			/// <summary>
			/// Convert visual display column to logical column
			/// CRITICAL for mouse clicks!
			/// </summary>
			public static int VisualToLogicalColumn(string line, int visualCol)
			{
				int currentVisual = 0;
				int logicalCol = 0;

				while (logicalCol < line.Length && currentVisual < visualCol)
				{
					if (line[logicalCol] == '\t')
					{
						int tabWidth = tabSize - (currentVisual % tabSize);
						currentVisual += tabWidth;
					}
					else
					{
						currentVisual++;
					}

					logicalCol++;
				}

				return logicalCol;
			}
			/// <summary>
			/// Calculate visual width of a tab at given position
			/// </summary>
			public static int GetTabWidth(int currentVisualCol)
			{
				return tabSize - (currentVisualCol % tabSize);
			}
			/// <summary>
			/// More precise version accounting for character spacing
			/// </summary>
			public static Vector2 LogicalToPixelPrecise(v2 logicalPos, List<StringBuilder> lines)
			{
				string line = lines[logicalPos.y].ToString();

				// Walk through line calculating exact pixel position
				float leftMargin = 0f;
				float topMargin = 0f;
				float charWidth = 1f;
				float charSpacing = 0f;
				float lineHeight = 2.56f;

				float x = leftMargin;
				int visualCol = 0;

				for (int i = 0; i < logicalPos.x && i < line.Length; i++)
				{
					if (line[i] == '\t')
					{
						int tabWidth = GetTabWidth(visualCol);
						x += tabWidth * (charWidth + charSpacing);
						visualCol += tabWidth;
					}
					else
					{
						x += charWidth + charSpacing;
						visualCol += 1;
					}
				}

				float y = topMargin + logicalPos.y * lineHeight;

				return new Vector2(x, y);
			}
			/// <summary>
			/// More precise version - considers click position within character
			/// </summary>
			public static v2 ScreenToLogicalPrecise(Vector2 localPos, List<StringBuilder> lines)
			{
				float leftMargin = 0f;
				float topMargin = 0f;
				float charWidth = 1f;
				float charSpacing = 0f;
				float lineHeight = 2.56f;

				int row = Mathf.FloorToInt((localPos.y - topMargin) / lineHeight);
				row = Mathf.Clamp(row, 0, lines.Count - 1);

				string line = lines[row].ToString();

				// Walk through line and find closest position
				float relativeX = localPos.x - leftMargin;
				float currentX = 0;
				int visualCol = 0;
				int logicalCol = 0;

				while (logicalCol < line.Length)
				{
					float charStartX = currentX;
					float charEndX;

					if (line[logicalCol] == '\t')
					{
						int tabWidth = GetTabWidth(visualCol);
						charEndX = currentX + tabWidth * (charWidth + charSpacing);
						visualCol += tabWidth;
					}
					else
					{
						charEndX = currentX + charWidth + charSpacing;
						visualCol++;
					}

					// Check if click is within this character
					if (relativeX >= charStartX && relativeX < charEndX)
					{
						float midpoint = (charStartX + charEndX) / 2f;

						if (relativeX < midpoint)
						{
							// Closer to start of character
							return (logicalCol, row);
						}
						else
						{
							// Closer to end of character
							return (logicalCol + 1, row);
						}
					}

					currentX = charEndX;
					logicalCol++;
				}

				// Clicked past end of line
				return (line.Length, row);
			}
		}
		#endregion

		#region basic movement
		void MoveCaret(v2 dir)
		{
			// ref coord dir: coord => X(left - to right +), Y(top - to down +)
			if (dir == (+1, 0)) // right
			{
				if (caret.x < lines[caret.y].Length)
					caret.x += 1;
				else
				{
					if (caret.y < lines.Count - 1)
					{
						// add new line
						caret.y += 1;
						caret.x = 0; // start of new line
					}
				}
			}
			else if (dir == (-1, 0)) // left
			{
				if (caret.x > 0)
					caret.x -= 1;
				else
				{
					// go to previous line
					if (caret.y >= 1)
					{
						caret.y -= 1;
						caret.x = lines[caret.y].Length;
					}
				}
			}
			else if (dir == (0, +1)) // down
			{
				if (caret.y < lines.Count - 1)
				{
					caret.y += 1;
					caret.x = Mathf.Min(caret.x, lines[caret.y].Length);
				}
			}
			else if (dir == (0, -1)) // up
			{
				if (caret.y > 0)
				{
					caret.y -= 1;
					caret.x = Mathf.Min(caret.x, lines[caret.y].Length);
				}
			}

			// deselect all and update visual
			DeSelectAllAndUpdateAllVisual();
		}
		void MoveCaretStartOrEndLine(int x = +1)
		{
			/*
			if (x == +1)
				caret.x = lines[caret.y].Length;
			if (x == -1)
				caret.x = 0;
			*/

			if (x == -1) // Home key
			{
				string line = lines[caret.y].ToString();
				int firstNonSpace = 0;

				// Find first non-whitespace
				while (firstNonSpace < line.Length &&
					   char.IsWhiteSpace(line[firstNonSpace]))
					firstNonSpace++;

				// Toggle: indent → column 0 → indent
				if (caret.x == firstNonSpace)
					caret.x = 0;
				else
					caret.x = firstNonSpace;
			}
			else // End key
			{
				caret.x = lines[caret.y].Length;
			}

			// deselect all and update visual
			DeSelectAllAndUpdateAllVisual();
		}
		#endregion

		#region word based movement
		// Ctrl+Left: Jump to previous word boundary
		void MoveCaretWord(v2 dir)
		{
			if (dir == (-1, 0))
			{
				if (caret.x == 0)
				{
					// MoveCaretLeft();
					MoveCaret((-1, 0));
					return;
				}

				string line = lines[caret.y].ToString();
				caret.x--;

				// Skip whitespace
				while (caret.x > 0 && char.IsWhiteSpace(line[caret.x]))
					caret.x--;

				// Skip word characters
				while (caret.x > 0 && !char.IsWhiteSpace(line[caret.x - 1]))
					caret.x--;
			}
			else if (dir == (+1, 0))
			{
				string line = lines[caret.y].ToString();
				if (caret.x >= line.Length)
				{
					// MoveCaretRight();
					MoveCaret((1, 0));
					return;
				}

				// Skip current word
				while (caret.x < line.Length && !char.IsWhiteSpace(line[caret.x]))
					caret.x++;

				// Skip whitespace
				while (caret.x < line.Length && char.IsWhiteSpace(line[caret.x]))
					caret.x++;
			}

			if (isSelecting == false)
			{
				selectionStartCaret = caret;
				UpdateSelectionStartCaretVisual();
			}
			// deselect all and update visual
			DeSelectAllAndUpdateAllVisual();
		}
		#endregion

		#region mouse certain coord movement
		void moveCaretToCertainCoord(v2 coord)
		{
			caret = coord;
			if (isSelecting == false)
				selectionStartCaret = caret;
			UpdateSelectionStartCaretVisual();
			UpdateCaretVisual();
		}
		v2 GetMouseToCaretCoord()
		{
			// caret, its visual
			INPUT.M.up = Vector3.forward;
			Vector2 pos2D = INPUT.M.getPos3D;
			v2 coord = new v2(pos2D.x.ceil(), (pos2D.y / this._fontLineHeight).round());
			coord.y = coord.y.clamp(-(lines.Count - 1), 0);

			coord.y *= -1; // To Txt Coord
			coord.x = coord.x.clamp(0, lines[coord.y].Length); // use coord.y to clamping

			return coord;
		}
		#endregion
		#endregion

		#region INPUT
		#region keyBoard Repeat Keys Behaviour

		// NEW: Add to class fields
		[Header("Key Repeat Settings")]
		[SerializeField] private float keyRepeatInitialDelay = 0.5f; // 500ms
		[SerializeField] private float keyRepeatInterval = 0.05f; // 50ms

		private Dictionary<KeyCode, float> keyHeldTimes = new Dictionary<KeyCode, float>();
		private Dictionary<KeyCode, float> keyLastRepeatTimes = new Dictionary<KeyCode, float>();

		// NEW: Helper method
		bool ShouldRepeatKey(KeyCode key)
		{
			if (!INPUT.K.HeldDown(key))
			{
				keyHeldTimes.Remove(key);
				keyLastRepeatTimes.Remove(key);
				return false;
			}

			if (!keyHeldTimes.ContainsKey(key))
			{
				keyHeldTimes[key] = Time.time;
				return false; // First press handled by InstantDown
			}

			float heldDuration = Time.time - keyHeldTimes[key];

			if (heldDuration < keyRepeatInitialDelay)
				return false;

			if (!keyLastRepeatTimes.ContainsKey(key))
			{
				keyLastRepeatTimes[key] = Time.time;
				return true;
			}

			if (Time.time - keyLastRepeatTimes[key] >= keyRepeatInterval)
			{
				keyLastRepeatTimes[key] = Time.time;
				return true;
			}

			return false;
		}
		#endregion

		#region multiple click within 300ms threshold
		// Click tracking for multi-click detection
		private float lastClickTime = 0f;
		private int clickCount = 0;
		private v2 lastClickPosition = (-1, -1);
		private const float DOUBLE_CLICK_TIME = 0.3f; // 300ms window

		// Select word under caret
		void SelectWordAtCaret()
		{
			StringBuilder line = lines[caret.y];
			if (line.Length == 0) return;

			int col = Mathf.Clamp(caret.x, 0, line.Length - 1);

			// Find word boundaries
			int startCol = col;
			int endCol = col;

			// Expand left to word start
			while (startCol > 0 && IsWordChar(line[startCol - 1]))
				startCol--;

			// Expand right to word end
			while (endCol < line.Length && IsWordChar(line[endCol]))
				endCol++;

			// Set selection
			selectionStartCaret = new v2(startCol, caret.y);
			caret = new v2(endCol, caret.y);
			isSelecting = true;
		}

		// Select entire line at caret
		void SelectLineAtCaret()
		{
			selectionStartCaret = new v2(0, caret.y);
			caret = new v2(lines[caret.y].Length, caret.y);
			isSelecting = true;
		}

		// Helper: Check if character is part of a word
		bool IsWordChar(char c)
		{
			return char.IsLetterOrDigit(c) || c == '_';
		}
		#endregion
		void HandleMouseInput()
		{
			// set caret via mouse pos(3D Plane with vec3.fwd as up) @instant down
			if (INPUT.M.InstantDown(0))
			{
				#region by default when instant down
				/*
				// clear selection
				// deselect all and update visual
				DeSelectAllAndUpdateAllVisual();
				moveCaretToCertainCoord(GetMouseToCaretCoord());
				*/ 
				#endregion

				#region multiple click within 300ms threshold
				v2 clickedCaretCoord = GetMouseToCaretCoord();
				float currentTime = Time.time;

				// Multi-click detection
				if (clickedCaretCoord == lastClickPosition && (currentTime - lastClickTime) < DOUBLE_CLICK_TIME)
				{
					clickCount++;
				}
				else
				{
					clickCount = 1;
				}

				lastClickTime = currentTime;
				lastClickPosition = clickedCaretCoord; 
				#endregion

				// Handle based on click count
				if (clickCount == 1)
				{
					// default behaviour
					// 0. clear selection
					// 1. deselect all and update visual
					DeSelectAllAndUpdateAllVisual();
					moveCaretToCertainCoord(GetMouseToCaretCoord());
				}
				#region multiple click within 300ms threshold
				else if (clickCount == 2)
				{
					// Double click - select word
					SelectWordAtCaret();
					UpdateLinearSelectionVisual();
				}
				else if (clickCount == 3)
				{
					// Triple click - select line
					SelectLineAtCaret();
					UpdateLinearSelectionVisual();
				}
				else if (clickCount >= 4)
				{
					SelectAll();
					clickCount = 0; // Reset after quadruple
					UpdateLinearSelectionVisual();
				} 
				#endregion
			}
			if (INPUT.M.HeldDown(0) && clickCount == 1) // selecting occur when click count instant down within that 300ms doesnt exceed count of 1
			{
				// set caret via mouse pos(3D Plane with vec3.fwd as up) @instant down
				isSelecting = true;
				moveCaretToCertainCoord(GetMouseToCaretCoord()); // update of carets are done inside move_()
				UpdateLinearSelectionVisual();
			}
			if (INPUT.M.InstantUp(0))
			{
				if (hasTextInsideSelection)
				{
					// do nothing
				}
				else
				{
					selectionStartCaret = caret;
					isSelecting = false;
				}
			}
		}
		void HandleKeyBoardInput()
		{
			if (INPUT.K.HeldDown(KeyCode.LeftControl)) // no input string allowed while leftCtrl is held down
			{
				if (INPUT.K.InstantDown(KeyCode.LeftArrow) || ShouldRepeatKey(KeyCode.LeftArrow)) MoveCaretWord(new v2(-1, 0));
				else if (INPUT.K.InstantDown(KeyCode.RightArrow) || ShouldRepeatKey(KeyCode.RightArrow)) MoveCaretWord(new v2(+1, 0));
				else if (INPUT.K.InstantDown(KeyCode.Backspace) || ShouldRepeatKey(KeyCode.Backspace)) DeleteWord();
				else if (INPUT.K.InstantDown(KeyCode.A)) SelectAll();
				else if (INPUT.K.InstantDown(KeyCode.C)) CopySelection();
				else if (INPUT.K.InstantDown(KeyCode.X)) CutSelection();
				else if (INPUT.K.InstantDown(KeyCode.V)) PasteText();
				else if (INPUT.K.InstantDown(KeyCode.LeftBracket) || ShouldRepeatKey(KeyCode.LeftBracket)) UnIndentLines();
				else if (INPUT.K.InstantDown(KeyCode.RightBracket) || ShouldRepeatKey(KeyCode.RightBracket)) IndentLines();
				else if (INPUT.K.InstantDown(KeyCode.Slash)) ToggleComment();

				#region Undo/Redo
				// NEW: Undo/Redo shortcuts
				if (INPUT.K.InstantDown(KeyCode.Z) || ShouldRepeatKey(KeyCode.Z))
				{
					if (INPUT.K.HeldDown(KeyCode.LeftShift))
						Redo(); // Ctrl+Shift+Z
					else
						Undo(); // Ctrl+Z
					return; // Don't process other inputs
				}

				// Alternative redo shortcut
				if (INPUT.K.InstantDown(KeyCode.Y) || ShouldRepeatKey(KeyCode.Y))
				{
					Redo(); // Ctrl+Y
					return;
				}
				#endregion
			}
			else
			{
				if (INPUT.K.InstantDown(KeyCode.LeftArrow)		 || ShouldRepeatKey(KeyCode.LeftArrow))		MoveCaret((-1, 0));
				else if (INPUT.K.InstantDown(KeyCode.RightArrow) || ShouldRepeatKey(KeyCode.RightArrow))	MoveCaret((+1, 0));
				else if (INPUT.K.InstantDown(KeyCode.DownArrow)  || ShouldRepeatKey(KeyCode.DownArrow))		MoveCaret((0, +1));
				else if (INPUT.K.InstantDown(KeyCode.UpArrow)	 || ShouldRepeatKey(KeyCode.UpArrow))		MoveCaret((0, -1));
				else if (INPUT.K.InstantDown(KeyCode.Home)) MoveCaretStartOrEndLine(x: -1);
				else if (INPUT.K.InstantDown(KeyCode.End)) MoveCaretStartOrEndLine(x: +1);

				// else if (INPUT.K.InstantDown(KeyCode.Backspace) ) DeleteChar();
				else if (INPUT.K.InstantDown(KeyCode.Backspace) || ShouldRepeatKey(KeyCode.Backspace)) DeleteChar();
				else if (INPUT.K.InstantDown(KeyCode.Tab)) InsertTab();
				else if (
					(INPUT.K.InstantDown(KeyCode.Return) || ShouldRepeatKey(KeyCode.Return)) || 
					(INPUT.K.InstantDown(KeyCode.KeypadEnter) || ShouldRepeatKey(KeyCode.KeypadEnter))) InsertNewLine();
				else if (INPUT.K.InstantDown(KeyCode.Delete)) DeleteWord(); // ctrl + backspace isnt providing desirable result probably somthng have to do with unity config.
																			
				// ===== TEXT INPUT ===== >>
				if (!string.IsNullOrEmpty(Input.inputString))
				{
					char c = Input.inputString[0];
					if (c >= ' ' && c != '\t' && c != '\b' && c != '\n' && c != '\r')
						InsertChar(c);
				}
				// << ===== TEXT INPUT ===== 
			}

			#region todo: shift arrow select
			// Selection >>
			if (INPUT.K.HeldDown(KeyCode.LeftShift))
			{
			}
			if (INPUT.K.InstantUp(KeyCode.LeftShift))
			{
			}
			// << Selection 
			#endregion

		}
		#endregion

		#region DISPLAY, VISUAL UPDATES
		// syntax highlighter
		[SerializeField] SyntaxHighlighterBase syntaxHighlighterBase;
		void UpdateEntireDisplayVisual()
		{
			StringBuilder fullText = new StringBuilder();
			for (int i = 0; i < lines.Count; i++)
			{
				fullText.Append(lines[i]);
				if (i < lines.Count - 1)
					fullText.Append('\n');
			}
			this._textField.text = fullText.ToString();

			UpdateLineNumbersVisual();
			UpdateCaretVisual();

			UpdateSelectionStartCaretVisual();
			UpdateLinearSelectionVisual();

			// if (hasSelection) { DrawSelection(); }
			if (this.syntaxHighlighterBase != null)
			{
				if (this.syntaxHighlighterBase.gameObject.activeSelf == true)
					this.syntaxHighlighterBase.UpdateSyntaxVisual();
			}
		}
		void UpdateLineNumbersVisual()
		{
			StringBuilder lineNums = new StringBuilder();
			for (int i0 = 0; i0 < lines.Count; i0 += 1)
			{
				lineNums.Append(i0);
				if (i0 < lines.Count)
					lineNums.Append('\n');
			}
			_lineNumText.text = lineNums.ToString();
		}

		// depends on v2 caret;
		void UpdateCaretVisual()
		{
			// vec3 visualCoord = GridToLocal(caretRow, caretCol)
			this._caretTr.position = new Vector3()
			{
				x = CoordinateSystem.LogicalToVisualColumn(lines[caret.y].ToString(), caret.x),
				// x = CoordinateSystem.LogicalToPixelPrecise(caret, lines).x,
				y = -caret.y * this._fontLineHeight,
				z = 10,
			};
		}
		// depends on v2 selectionStartCaret;
		void UpdateSelectionStartCaretVisual()
		{
			v2 coord = selectionStartCaret;
			this._selectionStartTr.position = new Vector3()
			{
				x = CoordinateSystem.LogicalToVisualColumn(lines[coord.y].ToString(), coord.x),
				// x = CoordinateSystem.LogicalToPixelPrecise(caret, lines).x,
				y = -coord.y * this._fontLineHeight,
				z = 10,
			};
		}
		void UpdateLinearSelectionVisual()
		{
			UpdateCaretVisual();
			UpdateSelectionStartCaretVisual();

			(v2 minStart, v2 maxEnd) = GetSelectionBounds();
			var mf = this._selectionMeshContainer.gc<MeshFilter>();
			var mr = this._selectionMeshContainer.gc<MeshRenderer>();
			mf.sharedMesh = MESH.GetSelectionMesh(lines, minStart, maxEnd, charWidth: _fontCharWidth, lineHeight: _fontLineHeight);
		}
		#endregion
	}

	// UTIL //
	#region MESH
	public static class MESH
	{
		public static Mesh GetSelectionMesh(List<StringBuilder> lines,
			v2 minStart, v2 maxEnd,
			float charWidth = 1f, float lineHeight = 2.21f, int layer = -10)
		{
			v2 start = minStart;
			v2 end = maxEnd;
			if (start == end)
				return new Mesh(); // empty mesh with no VERT, TRI

			List<Vector3> VERT = new List<Vector3>();
			List<int> TRI = new List<int>();
			Vector3 vertOffset = new Vector3(-charWidth, -lineHeight) / 2f;

			#region doodle: straight line start to end
			/*
			VERT = new List<Vector3>()
			{
				new Vector3(start.x * charWidth, -start.y * lineHeight, -layer ) + vertOffset,
				new Vector3(start.x * charWidth, -start.y * lineHeight, -layer ) + Vector3.up * lineHeight+ vertOffset,
				new Vector3(end.x * charWidth, -end.y * lineHeight, -layer ) + Vector3.up * lineHeight+ vertOffset,
				new Vector3(end.x * charWidth, -end.y * lineHeight, -layer ) + vertOffset,
			};
			TRI = new List<int>()
			{
				0, 1, 2,
				0, 2, 3,
			}; 
			*/
			#endregion

			// 0. draw start selection line row.
			if (start.y == end.y)
			{
				v2 from = start, to = end;
				var NewVERT = new List<Vector3>()
				{
					new Vector3(from.x * charWidth, -from.y * lineHeight, -layer ) + vertOffset,
					new Vector3(from.x * charWidth, -from.y * lineHeight, -layer ) + Vector3.up * lineHeight + vertOffset,
					new Vector3(to.x * charWidth, -to.y * lineHeight, -layer ) + Vector3.up * lineHeight + vertOffset,
					new Vector3(to.x * charWidth, -to.y * lineHeight, -layer ) + vertOffset,
				};
				var NewTRI = new List<int>()
				{
					0, 1, 2,
					0, 2, 3,
				};
				// increment the starting point for each tri index.
				int triIndexStartFrom = VERT.Count; for (int i0 = 0; i0 < NewTRI.Count; i0 += 1) NewTRI[i0] += triIndexStartFrom;

				VERT.AddRange(NewVERT);
				TRI.AddRange(NewTRI);
			}
			else
			{
				v2 from = start, to = new v2(lines[start.y].Length, start.y);
				var NewVERT = new List<Vector3>()
				{
					new Vector3(from.x * charWidth, -from.y * lineHeight, -layer ) + vertOffset,
					new Vector3(from.x * charWidth, -from.y * lineHeight, -layer ) + Vector3.up * lineHeight + vertOffset,
					new Vector3(to.x * charWidth, -to.y * lineHeight, -layer ) + Vector3.up * lineHeight + vertOffset,
					new Vector3(to.x * charWidth, -to.y * lineHeight, -layer ) + vertOffset,
				};
				var NewTRI = new List<int>()
				{
					0, 1, 2,
					0, 2, 3,
				};
				// increment the starting point for each tri index.
				int triIndexStartFrom = VERT.Count; for (int i0 = 0; i0 < NewTRI.Count; i0 += 1) NewTRI[i0] += triIndexStartFrom;

				VERT.AddRange(NewVERT);
				TRI.AddRange(NewTRI);
			}

			// 1. draw all middle selection line rows via loop.
			if ((end.y - start.y) <= 1)
			{
				// do nothing
			}
			else
			{
				for (int i0 = start.y + 1; i0 <= end.y - 1; i0 += 1)
				{
					v2 from = new v2(0, i0), to = new v2(lines[i0].Length, i0);
					var NewVERT = new List<Vector3>()
					{
						new Vector3(from.x * charWidth, -from.y * lineHeight, -layer ) + vertOffset,
						new Vector3(from.x * charWidth, -from.y * lineHeight, -layer ) + Vector3.up * lineHeight + vertOffset,
						new Vector3(to.x * charWidth, -to.y * lineHeight, -layer ) + Vector3.up * lineHeight + vertOffset,
						new Vector3(to.x * charWidth, -to.y * lineHeight, -layer ) + vertOffset,
					};
					var NewTRI = new List<int>()
					{
						0, 1, 2,
						0, 2, 3,
					};
					// increment the starting point for each tri index.
					int triIndexStartFrom = VERT.Count; for (int triI = 0; triI < NewTRI.Count; triI += 1) NewTRI[triI] += triIndexStartFrom;

					VERT.AddRange(NewVERT);
					TRI.AddRange(NewTRI);
				}
			}

			// 2. draw end selection line row.
			if (start.y == end.y)
			{
				// do nothing, since starting row = ending row already drawn
			}
			else
			{
				v2 from = new v2(0, end.y), to = end;
				var NewVERT = new List<Vector3>()
				{
					new Vector3(from.x * charWidth, -from.y * lineHeight, -layer ) + vertOffset,
					new Vector3(from.x * charWidth, -from.y * lineHeight, -layer ) + Vector3.up * lineHeight + vertOffset,
					new Vector3(to.x * charWidth, -to.y * lineHeight, -layer ) + Vector3.up * lineHeight + vertOffset,
					new Vector3(to.x * charWidth, -to.y * lineHeight, -layer ) + vertOffset,
				};
				var NewTRI = new List<int>()
				{
					0, 1, 2,
					0, 2, 3,
				};
				// increment the starting point for each tri index.
				int triIndexStartFrom = VERT.Count; for (int i0 = 0; i0 < NewTRI.Count; i0 += 1) NewTRI[i0] += triIndexStartFrom;

				VERT.AddRange(NewVERT);
				TRI.AddRange(NewTRI);
			}

			#region return mesh
			Mesh mesh = new Mesh()
			{
				vertices = VERT.ToArray(),
				triangles = TRI.ToArray(),
			};
			mesh.RecalculateNormals();
			return mesh;
			#endregion
		}
	}
	#endregion
	// UTIL //
}

/*
	caret pos, visual updated when:
		moveCaret(byChar/byWord is made)
		caret positioned via mouse(instantDown/heldDown)

	caret start pos, visual updated when:
		expet situation when selection is in [rpgress, other than that its updated every time.
		moveCaret(byChar/byWord is made)
		caret positioned via mouse(instantDown/heldDown)

*/

