using System;

namespace GameCreator.Runtime.Common.Mathematics
{
	internal class Parser
	{
		public delegate float BinaryOperation(float a, float b);

		public delegate float UnaryOperation(float a);

		private readonly Tokenizer m_Tokenizer;

		private Parser(string expression)
		{
			m_Tokenizer = new Tokenizer(expression);
		}

		public static float Evaluate(string expression)
		{
			return new Parser(expression).ParseExpression()?.Evaluate() ?? 0f;
		}

		private ISymbol ParseExpression()
		{
			ISymbol result = ParseAddSubtract();
			if (m_Tokenizer.Type != Tokenizer.TokenType.EndOfExpression)
			{
				throw new Exception("Unexpected characters at end of expression");
			}
			return result;
		}

		private ISymbol ParseAddSubtract()
		{
			ISymbol symbol = ParseMultiplyDivide();
			while (true)
			{
				BinaryOperation binaryOperation = m_Tokenizer.Type switch
				{
					Tokenizer.TokenType.Add => (float a, float b) => a + b, 
					Tokenizer.TokenType.Subtract => (float a, float b) => a - b, 
					_ => null, 
				};
				if (binaryOperation == null)
				{
					break;
				}
				m_Tokenizer.NextToken();
				ISymbol rhs = ParseMultiplyDivide();
				symbol = new SymbolBinary(symbol, rhs, binaryOperation);
			}
			return symbol;
		}

		private ISymbol ParseMultiplyDivide()
		{
			ISymbol symbol = ParseUnary();
			while (true)
			{
				BinaryOperation binaryOperation = m_Tokenizer.Type switch
				{
					Tokenizer.TokenType.Multiply => (float a, float b) => a * b, 
					Tokenizer.TokenType.Divide => (float a, float b) => a / b, 
					_ => null, 
				};
				if (binaryOperation == null)
				{
					break;
				}
				m_Tokenizer.NextToken();
				ISymbol rhs = ParseUnary();
				symbol = new SymbolBinary(symbol, rhs, binaryOperation);
			}
			return symbol;
		}

		private ISymbol ParseUnary()
		{
			if (m_Tokenizer.Type == Tokenizer.TokenType.Add)
			{
				m_Tokenizer.NextToken();
				return ParseUnary();
			}
			if (m_Tokenizer.Type == Tokenizer.TokenType.Subtract)
			{
				m_Tokenizer.NextToken();
				return new SymbolUnary(ParseUnary(), (float a) => 0f - a);
			}
			return ParseLeaf();
		}

		private ISymbol ParseLeaf()
		{
			if (m_Tokenizer.Type == Tokenizer.TokenType.Number)
			{
				SymbolNumber result = new SymbolNumber(m_Tokenizer.Number);
				m_Tokenizer.NextToken();
				return result;
			}
			if (m_Tokenizer.Type == Tokenizer.TokenType.OpenParenthesis)
			{
				m_Tokenizer.NextToken();
				ISymbol result2 = ParseAddSubtract();
				if (m_Tokenizer.Type != Tokenizer.TokenType.CloseParenthesis)
				{
					throw new Exception("Missing closing parenthesis");
				}
				m_Tokenizer.NextToken();
				return result2;
			}
			throw new Exception($"Unexpected token: {m_Tokenizer.Type}");
		}
	}
}
