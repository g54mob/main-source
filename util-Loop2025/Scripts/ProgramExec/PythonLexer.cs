using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace GptDeepResearch
{
	// The lexer tokenizes the input Python-like code, handling indentation and line tracking
	public class PythonLexer
	{
		private string _code;
		private List<Token> _tokens = new List<Token>();
		private int _pos = 0;
		private int _line = 1;
		private int _column = 0;

		// Update Keywords hashset (around line 18):
		private static HashSet<string> Keywords = new HashSet<string>
		{
			"if", "else",
			"while","for", "in",
			"def", "return", "pass",
			"not", "and", "or",
			"global",
			"break", "continue",
			"class",  // ADD this line
		};

		public List<Token> Tokens => _tokens;

		public PythonLexer(string code)
		{
			_code = code.Replace("\r\n", "\n");
			Tokenize();
		}

		// In the Tokenize() method, after handling indentation but before tokenizing content
		// Add support for multi-line constructs by tracking brace depth
		private int _braceDepth = 0;
		private int _parenDepth = 0;
		private int _bracketDepth = 0;

		// REPLACE the entire Tokenize() method with this version:
		// Fix: Handle multi-line triple-quoted strings properly
		private void Tokenize()
		{
			Stack<int> indentStack = new Stack<int>();
			indentStack.Push(0);
			string[] lines = _code.Replace("\r\n", "\n").Split('\n');

			for (int i = 0; i < lines.Length; i++)
			{
				string line = lines[i];
				int indentLevel = 0;
				int indentPos = 0;

				// Count indentation (spaces or tabs at start)
				while (indentPos < line.Length && (line[indentPos] == ' ' || line[indentPos] == '\t'))
				{
					// treat tab as 4 spaces for simplicity
					indentLevel += (line[indentPos] == ' ') ? 1 : 4;
					indentPos++;
				}

				string trimmed = line.Trim();
				// Skip empty lines or comments
				if (trimmed.Length == 0 || trimmed.StartsWith("#"))
				{
					_line++;
					continue;
				}

				// Only handle indentation if we're not inside multi-line constructs
				if (_braceDepth == 0 && _parenDepth == 0 && _bracketDepth == 0)
				{
					// Indentation handling (emit INDENT/DEDENT tokens as needed)
					if (indentLevel > indentStack.Peek())
					{
						indentStack.Push(indentLevel);
						_tokens.Add(new Token(TokenType.INDENT, "", _line));
					}
					while (indentLevel < indentStack.Peek())
					{
						indentStack.Pop();
						_tokens.Add(new Token(TokenType.DEDENT, "", _line));
					}
					if (indentLevel != indentStack.Peek())
					{
						throw new Exception($"Indentation error at line {_line}");
					}
				}

				// Get the content part of the line (after indentation)
				string contentLine = line.Substring(indentPos);

				// Tokenize the content part of this line
				_pos = 0;
				_column = indentPos;
				while (_pos < contentLine.Length)
				{
					char c = contentLine[_pos];

					// Skip whitespace inside line content
					if (c == ' ' || c == '\t')
					{
						_pos++;
						_column++;
						continue;
					}

					// Comment - skip rest of line
					if (c == '#') break;

					// Number literal (integer or float)
					if (char.IsDigit(c))
					{
						int start = _pos;
						while (_pos < contentLine.Length && (char.IsDigit(contentLine[_pos]) || contentLine[_pos] == '.'))
						{
							_pos++;
						}
						string num = contentLine.Substring(start, _pos - start);
						_tokens.Add(new Token(TokenType.NUMBER, num, _line));
						continue;
					}

					// String literal (including triple-quoted strings) - FIXED VERSION
					if (c == '\"' || c == '\'')
					{
						char quote = c;
						int start = _pos;

						// Check for triple-quoted strings
						if (_pos + 2 < contentLine.Length &&
							contentLine[_pos + 1] == quote &&
							contentLine[_pos + 2] == quote)
						{
							// Triple-quoted string - collect content across multiple lines
							_pos += 3; // Skip opening triple quotes
							string tripleQuoteStr = "";
							bool foundEnd = false;

							// Get remaining content from current line
							string remainingLine = contentLine.Substring(_pos);

							// Check if closing quotes are on same line
							int sameLineEnd = remainingLine.IndexOf(new string(quote, 3));
							if (sameLineEnd >= 0)
							{
								// Same line closing
								tripleQuoteStr = remainingLine.Substring(0, sameLineEnd);
								_pos += sameLineEnd + 3;
								foundEnd = true;
							}
							else
							{
								// Multi-line - add remaining current line content
								tripleQuoteStr = remainingLine;

								// Search subsequent lines
								int searchIdx = i + 1;
								while (searchIdx < lines.Length && !foundEnd)
								{
									string searchLine = lines[searchIdx];
									int tripleEnd = searchLine.IndexOf(new string(quote, 3));

									if (tripleEnd >= 0)
									{
										// Found end - add content before closing quotes
										tripleQuoteStr += "\n" + searchLine.Substring(0, tripleEnd);
										foundEnd = true;

										// Update line counter and position for the closing line
										_line = searchIdx + 1;
										i = searchIdx; // Update outer loop counter

										// Force end of current line processing since we jumped to new line
										_pos = contentLine.Length;
									}
									else
									{
										// Add entire line and continue
										tripleQuoteStr += "\n" + searchLine;
										searchIdx++;
									}
								}

								// Update line counter for skipped lines
								if (foundEnd)
								{
									i = searchIdx; // Update outer loop counter
								}
								else
								{
									// Update to last line we processed
									_line += (searchIdx - i - 1);
									i = searchIdx - 1;
								}
							}

							if (foundEnd)
							{
								string strVal = new string(quote, 3) + tripleQuoteStr + new string(quote, 3);
								_tokens.Add(new Token(TokenType.STRING, strVal, _line));
								continue;
							}
							else
							{
								throw new Exception($"Unclosed triple-quoted string starting at line {_line}");
							}
						}
						else
						{
							// Regular single/double quoted string
							_pos++;
							while (_pos < contentLine.Length && contentLine[_pos] != quote)
							{
								if (contentLine[_pos] == '\\' && _pos + 1 < contentLine.Length)
								{
									_pos += 2;
								}
								else
								{
									_pos++;
								}
							}
							if (_pos >= contentLine.Length)
							{
								throw new Exception($"Unterminated string literal at line {_line}");
							}
							_pos++; // include closing quote
							string strVal = contentLine.Substring(start, _pos - start);
							_tokens.Add(new Token(TokenType.STRING, strVal, _line));
							continue;
						}
					}

					// Identifier or keyword
					if (char.IsLetter(c) || c == '_')
					{
						int start = _pos;
						while (_pos < contentLine.Length && (char.IsLetterOrDigit(contentLine[_pos]) || contentLine[_pos] == '_'))
						{
							_pos++;
						}
						string name = contentLine.Substring(start, _pos - start);
						TokenType type;
						if (name == "True" || name == "False")
							type = TokenType.BOOLEAN;
						else if (Keywords.Contains(name))
							type = GetKeywordType(name);
						else
							type = TokenType.NAME;

						_tokens.Add(new Token(type, name, _line));
						continue;
					}

					// Two-character operators
					if (_pos + 1 < contentLine.Length)
					{
						string two = contentLine.Substring(_pos, 2);
						if (two == "==" || two == "!=" || two == "<=" || two == ">=" ||
							two == "**" || two == "+=" || two == "-=" || two == "*=" || two == "/=" ||
							two == "<<" || two == ">>")
						{
							TokenType type;
							switch (two)
							{
								case "==": type = TokenType.EQ; break;
								case "!=": type = TokenType.NEQ; break;
								case "<=": type = TokenType.LTE; break;
								case ">=": type = TokenType.GTE; break;
								case "**": type = TokenType.POWER; break;
								case "+=": type = TokenType.PLUS_ASSIGN; break;
								case "-=": type = TokenType.MINUS_ASSIGN; break;
								case "*=": type = TokenType.STAR_ASSIGN; break;
								case "/=": type = TokenType.SLASH_ASSIGN; break;
								case "<<": type = TokenType.SHIFT_LEFT; break;
								case ">>": type = TokenType.SHIFT_RIGHT; break;
								default: type = TokenType.NAME; break;
							}
							_tokens.Add(new Token(type, two, _line));
							_pos += 2;
							continue;
						}
					}

					// Single-character tokens
					switch (c)
					{
						case '+':
							_tokens.Add(new Token(TokenType.PLUS, "+", _line));
							break;
						case '-':
							_tokens.Add(new Token(TokenType.MINUS, "-", _line));
							break;
						case '*':
							_tokens.Add(new Token(TokenType.STAR, "*", _line));
							break;
						case '/':
							_tokens.Add(new Token(TokenType.SLASH, "/", _line));
							break;
						case '%':
							_tokens.Add(new Token(TokenType.PERCENT, "%", _line));
							break;
						case '<':
							_tokens.Add(new Token(TokenType.LT, "<", _line));
							break;
						case '>':
							_tokens.Add(new Token(TokenType.GT, ">", _line));
							break;
						case '=':
							_tokens.Add(new Token(TokenType.ASSIGN, "=", _line));
							break;
						case ':':
							_tokens.Add(new Token(TokenType.COLON, ":", _line));
							break;
						case ',':
							_tokens.Add(new Token(TokenType.COMMA, ",", _line));
							break;
						case '.':
							_tokens.Add(new Token(TokenType.DOT, ".", _line));
							break;
						case '{':
							_tokens.Add(new Token(TokenType.LBRACE, "{", _line));
							_braceDepth++;
							break;
						case '}':
							_tokens.Add(new Token(TokenType.RBRACE, "}", _line));
							_braceDepth--;
							break;
						case '(':
							_tokens.Add(new Token(TokenType.LPAREN, "(", _line));
							_parenDepth++;
							break;
						case ')':
							_tokens.Add(new Token(TokenType.RPAREN, ")", _line));
							_parenDepth--;
							break;
						case '[':
							_tokens.Add(new Token(TokenType.LBRACKET, "[", _line));
							_bracketDepth++;
							break;
						case ']':
							_tokens.Add(new Token(TokenType.RBRACKET, "]", _line));
							_bracketDepth--;
							break;
						case '&':
							_tokens.Add(new Token(TokenType.BIT_AND, "&", _line));
							break;
						case '|':
							_tokens.Add(new Token(TokenType.BIT_OR, "|", _line));
							break;
						case '^':
							_tokens.Add(new Token(TokenType.BIT_XOR, "^", _line));
							break;
						case '~':
							_tokens.Add(new Token(TokenType.BIT_NOT, "~", _line));
							break;
						default:
							// Enhanced error reporting
							string charInfo = "";
							if (c == '\0')
							{
								charInfo = "null character (\\0) [0x00]";
							}
							else if (c == '\v')
							{
								charInfo = "vertical tab (\\v) [0x0B] - common TMP InputField issue!";
							}
							else if (c == '\f')
							{
								charInfo = "form feed (\\f) [0x0C]";
							}
							else if (c == '\b')
							{
								charInfo = "backspace (\\b) [0x08]";
							}
							else if (char.IsControl(c))
							{
								charInfo = $"control character [0x{((int)c):X2}] (Unicode: U+{((int)c):X4})";
							}
							else if (c > 127)
							{
								charInfo = $"non-ASCII character '{c}' [0x{((int)c):X2}] (Unicode: U+{((int)c):X4})";
							}
							else
							{
								charInfo = $"'{c}' [0x{((int)c):X2}] (ASCII: {(int)c})";
							}

							string context = "";
							int contextStart = Math.Max(0, _pos - 5);
							int contextLength = Math.Min(10, contentLine.Length - contextStart);
							if (contextLength > 0)
							{
								context = contentLine.Substring(contextStart, contextLength);
								context = context.Replace('\t', '→').Replace('\n', '↵').Replace('\r', '↵').Replace('\v', '∨');
							}

							throw new Exception($"Unknown token {charInfo} at line {_line}, pos {_pos + 1}. ctx: '{context}'");
					}
					_pos++;
					_column++;
				}

				// Only add NEWLINE tokens if we're not inside multi-line constructs
				if (_braceDepth == 0 && _parenDepth == 0 && _bracketDepth == 0)
				{
					_tokens.Add(new Token(TokenType.NEWLINE, "\\n", _line));
				}
				_line++;
			}

			// At EOF, unwind remaining indents
			while (indentStack.Count > 1)
			{
				indentStack.Pop();
				_tokens.Add(new Token(TokenType.DEDENT, "", _line));
			}
			_tokens.Add(new Token(TokenType.EOF, "", _line));
		}

		private TokenType GetKeywordType(string name)
		{
			switch (name)
			{
				case "if": return TokenType.IF;
				case "else": return TokenType.ELSE;
				case "while": return TokenType.WHILE;
				// 3. Add to PythonLexer.cs in GetKeywordType method:
				case "for": return TokenType.FOR;
				case "in": return TokenType.IN;

				case "def": return TokenType.DEF;
				case "return": return TokenType.RETURN;
				case "pass": return TokenType.PASS;
				case "not": return TokenType.NOT;
				case "and": return TokenType.AND;
				case "or": return TokenType.OR;
				case "break": return TokenType.BREAK;
				case "continue": return TokenType.CONTINUE;
				case "global": return TokenType.GLOBAL;
				// Add after case "global":
				case "class": return TokenType.CLASS;
			}
			return TokenType.NAME;
		}

	}
}
/* TEST CASES - Expected to work after fix:

Test 1 - Original failing case (multi-line docstring):
def func():
    '''
    with tab line
    with 4 space line
     with 5 space line
    '''
    # a normal comment
    for i in range(4):
        move(1, 0)
func()
Expected: Should parse successfully and execute

Test 2 - Single line docstring:
def test():
    """Single line docstring"""
    return 42
Expected: Should parse successfully

Test 3 - Assigned multi-line string:
def fn():
    a = """
this is a comment"""
    print("hello" + a)
fn()
Expected: Should parse successfully and execute print

Test 4 - Top-level docstring:
"""
This is a module docstring
    with mixed indentation
	and tabs
"""
print("hello")
Expected: Should parse successfully and execute print
*/
