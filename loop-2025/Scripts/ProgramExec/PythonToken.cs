using System;
using System.Collections.Generic;

namespace GptDeepResearch
{
	// Token types for the Python mini-language
	public enum TokenType
	{
		EOF,
		INDENT,
		DEDENT,
		NEWLINE,
		// Literals
		NUMBER,
		STRING,
		BOOLEAN,
		// Identifiers and Keywords
		NAME,
		// Operators
		PLUS,       // +
		MINUS,      // -
		STAR,       // *
		SLASH,      // /
		PERCENT,    // %
		EQ,         // ==
		NEQ,        // !=
		LT,         // <
		GT,         // >
		LTE,        // <=
		GTE,        // >=
		ASSIGN,     // =

		// ADD after ASSIGN:
		POWER,      // **
		PLUS_ASSIGN, // +=
		MINUS_ASSIGN, // -=
		STAR_ASSIGN, // *=
		SLASH_ASSIGN, // /=


		LPAREN,     // (
		RPAREN,     // )
		LBRACKET,   // [
		RBRACKET,   // ]
		COLON,      // :
		COMMA,      // ,
		DOT,        // .

		// Add these new token types after DOT (around line 45):
		LBRACE,     // {
		RBRACE,     // }

		// Keywords
		IF,
		ELSE,
		WHILE,
		FOR, // Add this line to the enum
		IN, // Add this to TokenType enum

		DEF,
		RETURN,
		PASS,
		NOT,
		AND,
		OR,

		// ADD these token types after GLOBAL (around line 60):
		BIT_AND,    // &
		BIT_OR,     // |
		BIT_XOR,    // ^
		BIT_NOT,    // ~
		SHIFT_LEFT, // <<
		SHIFT_RIGHT,// >>

		BREAK,      // Add this line
		CONTINUE,   // Add this line

		GLOBAL,     // Add this line
		// Add after GLOBAL (around line 80):
		CLASS,      // class token
	}

	public class Token
	{
		public TokenType Type;
		public string Text;
		public int Line;

		public Token(TokenType type, string text, int line)
		{
			Type = type;
			Text = text;
			Line = line;
		}

		public override string ToString() => $"{Type}({Text}) on line {Line}";
	}
}
