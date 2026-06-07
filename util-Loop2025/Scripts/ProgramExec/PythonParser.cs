using System;
using System.Collections.Generic;

namespace GptDeepResearch
{
	// Parser that builds AST from tokens
	public class PythonParser
	{
		private List<Token> _tokens;
		private int _pos = 0;

		public PythonParser(List<Token> tokens)
		{
			_tokens = tokens;
		}

		private Token Current => _pos < _tokens.Count ? _tokens[_pos] : null;
		private Token Next()
		{
			_pos += 1;
			return Current;
		}
		private bool Match(TokenType type)
		{
			if (Current != null && Current.Type == type)
			{
				Next();
				return true;
			}
			return false;
		}
		private Token Expect(TokenType type, string msg)
		{
			if (Current != null && Current.Type == type)
			{
				Token t = Current;
				Next();
				return t;
			}
			throw new Exception($"Expected {msg} at line {Current?.Line}");
		}

		public List<Stmt> Parse()
		{
			List<Stmt> statements = new List<Stmt>();
			while (Current != null && Current.Type != TokenType.EOF)
			{
				if (Current.Type == TokenType.NEWLINE)
				{
					Next();
					continue;
				}
				if (Current.Type == TokenType.DEDENT)
				{
					// Skip stray DEDENT
					Next();
					continue;
				}
				statements.Add(ParseStatement());
			}
			return statements;
		}

		#region parse Stmt

		#region ParseStatement UTIL
		// modify - update IsStandaloneDocstring and ParseStatement methods
		// Fix: Handle standalone docstrings that should be treated as comments
		private bool IsStandaloneDocstring()
		{
			// Check if current token is a STRING that starts with triple quotes
			if (Current != null && Current.Type == TokenType.STRING)
			{
				string text = Current.Text;
				bool isTripleQuoted = (text.StartsWith("\"\"\"") || text.StartsWith("'''"));
				return isTripleQuoted;
			}
			return false;
		}

		#endregion
		private Stmt ParseStatement()
		{
			Token token = Current;

			// Handle standalone docstrings (triple-quoted strings that are not assigned)
			if (IsStandaloneDocstring())
			{
				// Look ahead to see if this is followed by assignment
				if (_pos + 1 < _tokens.Count && _tokens[_pos + 1].Type != TokenType.ASSIGN)
				{
					// Consume the string token as a docstring/comment
					Next();
					if (Current != null && Current.Type == TokenType.NEWLINE)
					{
						Expect(TokenType.NEWLINE, "newline");
					}
					// Return a special pass statement to represent the docstring
					return new PassStmt(token.Line);
				}
			}

			switch (token.Type)
			{
				case TokenType.IF:
					return ParseIf();
				case TokenType.WHILE:
					return ParseWhile();
				case TokenType.FOR:
					return ParseFor();
				case TokenType.DEF:
					return ParseFunctionDef();
				case TokenType.RETURN:
					return ParseReturn();
				case TokenType.PASS:
					return ParsePass();
				case TokenType.GLOBAL:
					return ParseGlobal();
				case TokenType.CLASS:
					return ParseClass();
				case TokenType.BREAK:
					return ParseBreak();
				case TokenType.CONTINUE:
					return ParseContinue();
				default:
					// Could be assignment, in-place assignment, attribute assignment, index assignment, or expression
					if (token.Type == TokenType.NAME)
					{
						TokenType nextType = PeekNextType();
						if (nextType == TokenType.ASSIGN)
						{
							return ParseAssignment();
						}
						else if (nextType == TokenType.PLUS_ASSIGN || nextType == TokenType.MINUS_ASSIGN ||
								 nextType == TokenType.STAR_ASSIGN || nextType == TokenType.SLASH_ASSIGN)
						{
							return ParseInPlaceAssignment();
						}
						else
						{
							// Parse as expression first to determine assignment type
							Expr expr = ParseExpression();

							if (Current.Type == TokenType.ASSIGN)
							{
								Next(); // consume '='
								Expr value = ParseExpression();
								Expect(TokenType.NEWLINE, "newline");

								// Determine assignment type
								if (expr is AttributeExpr attrExpr)
								{
									return new AttributeAssignStmt(attrExpr.Target, attrExpr.Name, value, token.Line);
								}
								else if (expr is IndexExpr indexExpr)
								{
									return new IndexAssignStmt(indexExpr.Target, indexExpr.Index, value, token.Line);
								}
								else
								{
									throw new Exception($"Invalid assignment target at line {token.Line}");
								}
							}
							else
							{
								// Regular expression statement
								Expect(TokenType.NEWLINE, "newline");
								return new ExpressionStmt(expr, token.Line);
							}
						}
					}
					else
					{
						Expr expr = ParseExpression();
						Expect(TokenType.NEWLINE, "newline");
						return new ExpressionStmt(expr, token.Line);
					}
			}
		}

		// ADD new ParseInPlaceAssignment method after ParseAssignment (around line 95):
		private Stmt ParseInPlaceAssignment()
		{
			Token nameToken = Expect(TokenType.NAME, "identifier");
			string name = nameToken.Text;

			// Get the in-place operator
			Token opToken = Current;
			TokenType opType = opToken.Type;
			Next(); // consume the operator

			Expr value = ParseExpression();
			Expect(TokenType.NEWLINE, "newline");
			return new InPlaceAssignStmt(name, opType, value, nameToken.Line);
		}

		// Add ParseGlobal method:
		private Stmt ParseGlobal()
		{
			Token globalToken = Expect(TokenType.GLOBAL, "global");
			List<string> names = new List<string>();
			do
			{
				Token nameToken = Expect(TokenType.NAME, "variable name");
				names.Add(nameToken.Text);
			} while (Match(TokenType.COMMA));
			Expect(TokenType.NEWLINE, "newline");
			return new GlobalStmt(names, globalToken.Line);
		}

		// Add new parsing methods after ParseContinue method (around line 130):
		private Stmt ParseClass()
		{
			Token classToken = Expect(TokenType.CLASS, "class");
			Token nameToken = Expect(TokenType.NAME, "class name");
			string name = nameToken.Text;
			Expect(TokenType.COLON, "':'");
			Expect(TokenType.NEWLINE, "newline");
			Expect(TokenType.INDENT, "indent");

			List<Stmt> body = new List<Stmt>();
			while (Current.Type != TokenType.DEDENT && Current.Type != TokenType.EOF)
			{
				body.Add(ParseStatement());
			}
			Expect(TokenType.DEDENT, "dedent");

			// Check for docstring as first statement
			ClassDefStmt classStmt = new ClassDefStmt(name, body, classToken.Line);
			ExtractDocstring(classStmt, body);

			return classStmt;
		}
		#region ParseClass util
		/// <summary>
		/// Extract docstring from function or class body if present
		/// </summary>
		private void ExtractDocstring(object defStmt, List<Stmt> body)
		{
			if (body.Count > 0 && body[0] is ExpressionStmt exprStmt && exprStmt.Expression is StringExpr strExpr)
			{
				// First statement is a string literal - treat as docstring
				string docstring = strExpr.Value;

				// Remove triple quote markers if present
				if (docstring.StartsWith("\"\"\"") && docstring.EndsWith("\"\"\""))
				{
					docstring = docstring.Substring(3, docstring.Length - 6);
				}
				else if (docstring.StartsWith("'''") && docstring.EndsWith("'''"))
				{
					docstring = docstring.Substring(3, docstring.Length - 6);
				}

				// Set docstring on the definition
				if (defStmt is FunctionDefStmt funcDef)
				{
					funcDef.Docstring = docstring.Trim();
				}
				else if (defStmt is ClassDefStmt classDef)
				{
					classDef.Docstring = docstring.Trim();
				}

				// Remove the docstring statement from body
				body.RemoveAt(0);
			}
		}
		#endregion

		// Add ParseBreak method:
		private Stmt ParseBreak()
		{
			Token breakToken = Expect(TokenType.BREAK, "break");
			Expect(TokenType.NEWLINE, "newline");
			return new BreakStmt(breakToken.Line);
		}

		// Add ParseContinue method:
		private Stmt ParseContinue()
		{
			Token continueToken = Expect(TokenType.CONTINUE, "continue");
			Expect(TokenType.NEWLINE, "newline");
			return new ContinueStmt(continueToken.Line);
		}

		// LABELED DIFF FOR PythonParser.cs
		// Add parsing for ** operator and in-place assignments

		// MODIFY PeekNextType method to handle in-place operators (around line 75):
		private TokenType PeekNextType()
		{
			if (_pos + 1 < _tokens.Count)
				return _tokens[_pos + 1].Type;
			return TokenType.EOF;
		}

		private Stmt ParseAssignment()
		{
			Token nameToken = Expect(TokenType.NAME, "identifier");
			string name = nameToken.Text;
			Expect(TokenType.ASSIGN, "'='");
			Expr value = ParseExpression();
			Expect(TokenType.NEWLINE, "newline");
			return new AssignStmt(name, value, nameToken.Line);
		}

		private Stmt ParseIf()
		{
			Token ifToken = Expect(TokenType.IF, "if");
			Expr condition = ParseExpression();
			Expect(TokenType.COLON, "':'");
			Expect(TokenType.NEWLINE, "newline");
			Expect(TokenType.INDENT, "indent");
			List<Stmt> thenBranch = new List<Stmt>();
			while (Current.Type != TokenType.DEDENT && Current.Type != TokenType.EOF)
			{
				thenBranch.Add(ParseStatement());
			}
			Expect(TokenType.DEDENT, "dedent");
			List<Stmt> elseBranch = null;
			if (Current.Type == TokenType.ELSE)
			{
				Expect(TokenType.ELSE, "else");
				Expect(TokenType.COLON, "':'");
				Expect(TokenType.NEWLINE, "newline");
				Expect(TokenType.INDENT, "indent");
				elseBranch = new List<Stmt>();
				while (Current.Type != TokenType.DEDENT && Current.Type != TokenType.EOF)
				{
					elseBranch.Add(ParseStatement());
				}
				Expect(TokenType.DEDENT, "dedent");
			}
			return new IfStmt(condition, thenBranch, elseBranch, ifToken.Line);
		}

		private Stmt ParseWhile()
		{
			Token whileToken = Expect(TokenType.WHILE, "while");
			Expr condition = ParseExpression();
			Expect(TokenType.COLON, "':'");
			Expect(TokenType.NEWLINE, "newline");
			Expect(TokenType.INDENT, "indent");
			List<Stmt> body = new List<Stmt>();
			while (Current.Type != TokenType.DEDENT && Current.Type != TokenType.EOF)
			{
				body.Add(ParseStatement());
			}
			Expect(TokenType.DEDENT, "dedent");
			return new WhileStmt(condition, body, whileToken.Line);
		}
		// 7. Add ParseFor method to PythonParser.cs:
		private Stmt ParseFor()
		{
			Token forToken = Expect(TokenType.FOR, "for");
			Token varToken = Expect(TokenType.NAME, "variable name");
			string variable = varToken.Text;
			Expect(TokenType.IN, "in");
			Expr iterable = ParseExpression();
			Expect(TokenType.COLON, "':'");
			Expect(TokenType.NEWLINE, "newline");
			Expect(TokenType.INDENT, "indent");

			List<Stmt> body = new List<Stmt>();
			while (Current.Type != TokenType.DEDENT && Current.Type != TokenType.EOF)
			{
				body.Add(ParseStatement());
			}
			Expect(TokenType.DEDENT, "dedent");

			return new ForStmt(variable, iterable, body, forToken.Line);
		}

		private Stmt ParseFunctionDef()
		{
			Token defToken = Expect(TokenType.DEF, "def");
			Token nameToken = Expect(TokenType.NAME, "function name");
			string name = nameToken.Text;
			Expect(TokenType.LPAREN, "'('");
			List<string> parameters = new List<string>();
			if (Current.Type != TokenType.RPAREN)
			{
				do
				{
					Token param = Expect(TokenType.NAME, "parameter name");
					parameters.Add(param.Text);
				} while (Match(TokenType.COMMA));
			}
			Expect(TokenType.RPAREN, "')'");
			Expect(TokenType.COLON, "':'");
			Expect(TokenType.NEWLINE, "newline");
			Expect(TokenType.INDENT, "indent");
			List<Stmt> body = new List<Stmt>();
			while (Current.Type != TokenType.DEDENT && Current.Type != TokenType.EOF)
			{
				body.Add(ParseStatement());
			}
			Expect(TokenType.DEDENT, "dedent");

			// Create function and extract docstring
			FunctionDefStmt funcStmt = new FunctionDefStmt(name, parameters, body, defToken.Line);
			ExtractDocstring(funcStmt, body);

			return funcStmt;
		}

		private Stmt ParseReturn()
		{
			Token retToken = Expect(TokenType.RETURN, "return");
			Expr value = null;
			if (Current.Type != TokenType.NEWLINE)
			{
				value = ParseExpression();
			}
			Expect(TokenType.NEWLINE, "newline");
			return new ReturnStmt(value, retToken.Line);
		}

		private Stmt ParsePass()
		{
			Token passToken = Expect(TokenType.PASS, "pass");
			Expect(TokenType.NEWLINE, "newline");
			return new PassStmt(passToken.Line);
		}
		#endregion

		/*
		// New precedence chain (highest to lowest):
		ParseExpression() → ParseOr() → ParseAnd() → ParseBitOr() → ParseBitXor() → 
		ParseBitAnd() → ParseShift() → ParseNot() → ParseCompare() → ParseAddSubtract() → 
		ParseTerm() → ParsePower() → ParseFactor()
		*/
		// CHANGES TO PythonParser.cs - Expression parsing methods
		// Replace the existing expression parsing methods with these updated versions


		// CHANGES TO PythonParser.cs - Expression parsing methods
		// Replace the existing expression parsing methods with these updated versions

		#region parse Expr - UPDATED FOR PROPER PRECEDENCE
		private Expr ParseExpression()
		{
			return ParseOr();
		}

		private Expr ParseOr()
		{
			Expr expr = ParseAnd();
			while (Current.Type == TokenType.OR)
			{
				Token op = Current; Next();
				Expr right = ParseAnd();
				expr = new BinaryExpr(expr, TokenType.OR, right, op.Line);
			}
			return expr;
		}

		private Expr ParseAnd()
		{
			Expr expr = ParseBitOr();
			while (Current.Type == TokenType.AND)
			{
				Token op = Current; Next();
				Expr right = ParseBitOr();
				expr = new BinaryExpr(expr, TokenType.AND, right, op.Line);
			}
			return expr;
		}

		private Expr ParseBitOr()
		{
			Expr expr = ParseBitXor();
			while (Current.Type == TokenType.BIT_OR)
			{
				Token op = Current; Next();
				Expr right = ParseBitXor();
				expr = new BinaryExpr(expr, op.Type, right, op.Line);
			}
			return expr;
		}

		private Expr ParseBitXor()
		{
			Expr expr = ParseBitAnd();
			while (Current.Type == TokenType.BIT_XOR)
			{
				Token op = Current; Next();
				Expr right = ParseBitAnd();
				expr = new BinaryExpr(expr, op.Type, right, op.Line);
			}
			return expr;
		}

		private Expr ParseBitAnd()
		{
			Expr expr = ParseShift();
			while (Current.Type == TokenType.BIT_AND)
			{
				Token op = Current; Next();
				Expr right = ParseShift();
				expr = new BinaryExpr(expr, op.Type, right, op.Line);
			}
			return expr;
		}

		private Expr ParseShift()
		{
			Expr expr = ParseCompare(); // FIXED: Call ParseCompare to maintain correct precedence chain
			while (Current.Type == TokenType.SHIFT_LEFT || Current.Type == TokenType.SHIFT_RIGHT)
			{
				Token op = Current; Next();
				Expr right = ParseCompare(); // FIXED: Call ParseCompare to maintain correct precedence chain
				expr = new BinaryExpr(expr, op.Type, right, op.Line);
			}
			return expr;
		}

		// UPDATED METHOD: Handle unary NOT and bitwise NOT at correct precedence
		private Expr ParseNot()
		{
			if (Current.Type == TokenType.NOT)
			{
				Token op = Current; Next();
				Expr operand = ParseNot(); // Recursive for multiple nots like "not not x"
				return new UnaryExpr(TokenType.NOT, operand, op.Line);
			}
			if (Current.Type == TokenType.BIT_NOT) // Add support for ~ operator  
			{
				Token op = Current; Next();
				Expr operand = ParseNot(); // Recursive for combinations like "~not x"
				return new UnaryExpr(TokenType.BIT_NOT, operand, op.Line);
			}
			return ParseAddSubtract(); // FIXED: Should call ParseAddSubtract, not ParseCompare
		}

		private Expr ParseCompare()
		{
			Expr expr = ParseNot(); // FIXED: Call ParseNot instead of ParseAddSubtract
			if (Current.Type == TokenType.EQ || Current.Type == TokenType.NEQ ||
				Current.Type == TokenType.LT || Current.Type == TokenType.GT ||
				Current.Type == TokenType.LTE || Current.Type == TokenType.GTE)
			{
				Token op = Current; Next();
				Expr right = ParseNot(); // FIXED: Call ParseNot instead of ParseAddSubtract
				expr = new BinaryExpr(expr, op.Type, right, op.Line);
			}
			return expr;
		}

		private Expr ParseAddSubtract()
		{
			Expr expr = ParseTerm();
			while (Current.Type == TokenType.PLUS || Current.Type == TokenType.MINUS)
			{
				Token op = Current; Next();
				Expr right = ParseTerm();
				expr = new BinaryExpr(expr, op.Type, right, op.Line);
			}
			return expr;
		}

		private Expr ParseTerm()
		{
			Expr expr = ParsePower();
			while (Current.Type == TokenType.STAR || Current.Type == TokenType.SLASH || Current.Type == TokenType.PERCENT)
			{
				Token op = Current; Next();
				Expr right = ParsePower();
				expr = new BinaryExpr(expr, op.Type, right, op.Line);
			}
			return expr;
		}

		private Expr ParsePower()
		{
			Expr expr = ParseFactor();
			while (Current.Type == TokenType.POWER)
			{
				Token op = Current; Next();
				Expr right = ParseFactor(); // Right associative
				expr = new BinaryExpr(expr, op.Type, right, op.Line);
			}
			return expr;
		}

		private Expr ParseFactor()
		{
			Token token = Current;
			if (token.Type == TokenType.MINUS)
			{
				Next();
				Expr operand = ParseFactor();
				return new UnaryExpr(TokenType.MINUS, operand, token.Line);
			}
			if (token.Type == TokenType.NUMBER)
			{
				Next();
				double val;
				if (!double.TryParse(token.Text, out val))
				{
					throw new Exception($"Invalid number '{token.Text}' at line {token.Line}");
				}
				return new NumberExpr(val, token.Line);
			}
			if (token.Type == TokenType.STRING)
			{
				Next();
				string s = token.Text;
				if ((s.StartsWith("\"") && s.EndsWith("\"")) || (s.StartsWith("'") && s.EndsWith("'")))
				{
					s = s.Substring(1, s.Length - 2);
				}
				return new StringExpr(s, token.Line);
			}
			if (token.Type == TokenType.BOOLEAN)
			{
				Next();
				bool val = token.Text == "True";
				return new BooleanExpr(val, token.Line);
			}
			if (token.Type == TokenType.NAME)
			{
				Next();
				Expr node = new NameExpr(token.Text, token.Line);
				return ParseCallIndexAttribute(node);
			}
			if (token.Type == TokenType.LPAREN)
			{
				Next();
				Expr expr = ParseExpression();
				Expect(TokenType.RPAREN, "')'");
				return ParseCallIndexAttribute(expr);
			}
			if (token.Type == TokenType.LBRACKET)
			{
				// list literal
				Next();
				List<Expr> elements = new List<Expr>();
				if (Current.Type != TokenType.RBRACKET)
				{
					do
					{
						Expr e = ParseExpression();
						elements.Add(e);
					} while (Match(TokenType.COMMA));
				}
				Expect(TokenType.RBRACKET, "']'");
				return new ListExpr(elements, token.Line);
			}
			// Add case after TokenType.LBRACKET:
			if (token.Type == TokenType.LBRACE)
			{
				// Dictionary literal
				Next();
				List<(Expr Key, Expr Value)> pairs = new List<(Expr Key, Expr Value)>();
				if (Current.Type != TokenType.RBRACE)
				{
					do
					{
						Expr key = ParseExpression();
						Expect(TokenType.COLON, "':'");
						Expr value = ParseExpression();
						pairs.Add((key, value));
					} while (Match(TokenType.COMMA));
				}
				Expect(TokenType.RBRACE, "'}'");
				return new DictExpr(pairs, token.Line);
			}
			throw new Exception($"Unexpected token '{token.Text}' at line {token.Line}");
		}
		#endregion

		private Expr ParseCallIndexAttribute(Expr node)
		{
			while (true)
			{
				if (Current.Type == TokenType.LPAREN)
				{
					// function or method call
					Next(); // consume '('
					List<Expr> args = new List<Expr>();
					if (Current.Type != TokenType.RPAREN)
					{
						do
						{
							args.Add(ParseExpression());
						} while (Match(TokenType.COMMA));
					}
					Expect(TokenType.RPAREN, "')'");
					node = new CallExpr(node, args, node.Line);
				}
				else if (Current.Type == TokenType.DOT)
				{
					Next(); // consume '.'
					Token nameToken = Expect(TokenType.NAME, "attribute name");
					node = new AttributeExpr(node, nameToken.Text, node.Line);
				}
				else if (Current.Type == TokenType.LBRACKET)
				{
					// indexing or slicing
					Next(); // consume '['
					Expr start = null;
					Expr end = null;
					if (Current.Type != TokenType.COLON)
					{
						start = ParseExpression();
					}
					if (Current.Type == TokenType.COLON)
					{
						Next(); // consume ':'
						if (Current.Type != TokenType.RBRACKET)
						{
							end = ParseExpression();
						}
						Expect(TokenType.RBRACKET, "']'");
						node = new SliceExpr(node, start, end, node.Line);
					}
					else
					{
						Expect(TokenType.RBRACKET, "']'");
						node = new IndexExpr(node, start, node.Line);
					}
				}
				else
				{
					break;
				}
			}
			return node;
		} 
	}
}
