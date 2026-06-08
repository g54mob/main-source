using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.XPath;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public static class XPathCompiler
	{
		private enum Token
		{
			Name = 0,
			SelfReference = 1,
			StepSeparator = 2,
			NameSeparator = 3,
			AttributeStart = 4,
			VariableStart = 5,
			EqualsOperator = 6,
			PredicateStart = 7,
			PredicateEnd = 8,
			StringLiteral = 9,
			EndOfInput = 10,
			Error = 11
		}

		private class Tokenizer
		{
			private enum State
			{
				Initial = 0,
				Name = 1,
				SingleQuoteString = 2,
				DoubleQuoteString = 3,
				Failed = 4
			}

			private readonly string input;

			private State state;

			private Token token;

			private int index;

			private int start;

			private int prior;

			public Token Token => token;

			public string Text => input.Substring(start, index - start + 1);

			public int Index => start;

			public Tokenizer(string input)
			{
				this.input = input;
				state = State.Initial;
				index = -1;
				Consume();
			}

			public string GetConsumedText(int start)
			{
				return input.Substring(start, prior - start + 1);
			}

			public void Consume()
			{
				prior = index;
				while (true)
				{
					char c = ReadChar();
					switch (state)
					{
					case State.Initial:
						start = index;
						switch (c)
						{
						case '.':
							token = Token.SelfReference;
							return;
						case '/':
							token = Token.StepSeparator;
							return;
						case ':':
							token = Token.NameSeparator;
							return;
						case '@':
							token = Token.AttributeStart;
							return;
						case '$':
							token = Token.VariableStart;
							return;
						case '=':
							token = Token.EqualsOperator;
							return;
						case '[':
							token = Token.PredicateStart;
							return;
						case ']':
							token = Token.PredicateEnd;
							return;
						case '\0':
							token = Token.EndOfInput;
							return;
						case '\'':
							state = State.SingleQuoteString;
							break;
						case '"':
							state = State.DoubleQuoteString;
							break;
						default:
							if (IsNameStartChar(c))
							{
								state = State.Name;
							}
							else if (!IsWhitespace(c))
							{
								state = State.Failed;
							}
							break;
						}
						break;
					case State.Name:
						if (!IsNameChar(c))
						{
							RewindChar();
							token = Token.Name;
							state = State.Initial;
							return;
						}
						break;
					case State.SingleQuoteString:
						if (c == '\'')
						{
							token = Token.StringLiteral;
							state = State.Initial;
							return;
						}
						break;
					case State.DoubleQuoteString:
						if (c == '"')
						{
							token = Token.StringLiteral;
							state = State.Initial;
							return;
						}
						break;
					case State.Failed:
						token = Token.Error;
						return;
					}
				}
			}

			private char ReadChar()
			{
				if (++index >= input.Length)
				{
					return '\0';
				}
				return input[index];
			}

			private void RewindChar()
			{
				index--;
			}

			private static bool IsWhitespace(char c)
			{
				return XmlConvert.IsWhitespaceChar(c);
			}

			private static bool IsNameStartChar(char c)
			{
				return XmlConvert.IsStartNCNameChar(c);
			}

			private static bool IsNameChar(char c)
			{
				return XmlConvert.IsNCNameChar(c);
			}
		}

		private static readonly Func<CompiledXPathNode> NodeFactory = () => new CompiledXPathNode();

		private static readonly Func<CompiledXPathStep> StepFactory = () => new CompiledXPathStep();

		public static CompiledXPath Compile(string path)
		{
			if (path == null)
			{
				throw Error.ArgumentNull("path");
			}
			CompiledXPath compiledXPath = new CompiledXPath();
			compiledXPath.Path = XPathExpression.Compile(path);
			if (!ParsePath(new Tokenizer(path), compiledXPath))
			{
				compiledXPath.MakeNotCreatable();
			}
			compiledXPath.Prepare();
			return compiledXPath;
		}

		private static bool ParsePath(Tokenizer source, CompiledXPath path)
		{
			CompiledXPathStep step = null;
			do
			{
				if (!ParseStep(source, path, ref step))
				{
					return false;
				}
				if (source.Token == Token.EndOfInput)
				{
					return true;
				}
				if (!Consume(source, Token.StepSeparator))
				{
					return false;
				}
			}
			while (!step.IsAttribute);
			return false;
		}

		private static bool ParseStep(Tokenizer source, CompiledXPath path, ref CompiledXPathStep step)
		{
			CompiledXPathStep compiledXPathStep = step;
			int index = source.Index;
			if (!ParseNodeCore(source, StepFactory, ref step))
			{
				return false;
			}
			if (step != compiledXPathStep)
			{
				string consumedText = source.GetConsumedText(index);
				step.Path = XPathExpression.Compile(consumedText);
				if (compiledXPathStep == null)
				{
					path.FirstStep = step;
				}
				else
				{
					LinkNodes(compiledXPathStep, step);
				}
				path.Depth++;
			}
			return true;
		}

		private static bool ParseNodeCore<TNode>(Tokenizer source, Func<TNode> factory, ref TNode node) where TNode : CompiledXPathNode
		{
			if (!Consume(source, Token.SelfReference))
			{
				node = factory();
				if (Consume(source, Token.AttributeStart))
				{
					node.IsAttribute = true;
				}
				if (!ParseQualifiedName(source, node))
				{
					return false;
				}
			}
			if (node != null)
			{
				return ParsePredicateList(source, node);
			}
			return source.Token != Token.PredicateStart;
		}

		private static bool ParsePredicateList(Tokenizer source, CompiledXPathNode parent)
		{
			while (Consume(source, Token.PredicateStart))
			{
				if (!ParsePredicate(source, parent))
				{
					return false;
				}
			}
			return true;
		}

		private static bool ParsePredicate(Tokenizer source, CompiledXPathNode parent)
		{
			if (!ParseAndExpression(source, parent))
			{
				return false;
			}
			if (!Consume(source, Token.PredicateEnd))
			{
				return false;
			}
			return true;
		}

		private static bool ParseAndExpression(Tokenizer source, CompiledXPathNode parent)
		{
			while (true)
			{
				if (!ParseExpression(source, parent))
				{
					return false;
				}
				if (source.Token != Token.Name || source.Text != "and")
				{
					break;
				}
				source.Consume();
			}
			return true;
		}

		private static bool ParseExpression(Tokenizer source, CompiledXPathNode parent)
		{
			if (source.Token != Token.Name && source.Token != Token.AttributeStart && source.Token != Token.SelfReference)
			{
				return ParseRightToLeftExpression(source, parent);
			}
			return ParseLeftToRightExpression(source, parent);
		}

		private static bool ParseLeftToRightExpression(Tokenizer source, CompiledXPathNode parent)
		{
			if (!ParseNestedPath(source, parent, out var node))
			{
				return false;
			}
			if (!Consume(source, Token.EqualsOperator))
			{
				return true;
			}
			if (!ParseValue(source, out var value))
			{
				return false;
			}
			node.Value = value;
			return true;
		}

		private static bool ParseRightToLeftExpression(Tokenizer source, CompiledXPathNode parent)
		{
			if (!ParseValue(source, out var value))
			{
				return false;
			}
			if (!Consume(source, Token.EqualsOperator))
			{
				return false;
			}
			if (!ParseNestedPath(source, parent, out var node))
			{
				return false;
			}
			node.Value = value;
			return true;
		}

		private static bool ParseNestedPath(Tokenizer source, CompiledXPathNode parent, out CompiledXPathNode node)
		{
			node = null;
			while (true)
			{
				if (!ParseNode(source, parent, ref node))
				{
					return false;
				}
				if (!Consume(source, Token.StepSeparator))
				{
					break;
				}
				if (node.IsAttribute)
				{
					return false;
				}
			}
			if (node == null)
			{
				IList<CompiledXPathNode> dependencies = parent.Dependencies;
				if (dependencies.Count != 0)
				{
					return false;
				}
				dependencies.Add(node = NodeFactory());
			}
			return true;
		}

		private static bool ParseNode(Tokenizer source, CompiledXPathNode parent, ref CompiledXPathNode node)
		{
			CompiledXPathNode compiledXPathNode = node;
			if (!ParseNodeCore(source, NodeFactory, ref node))
			{
				return false;
			}
			if (node != compiledXPathNode)
			{
				if (compiledXPathNode == null)
				{
					parent.Dependencies.Add(node);
				}
				else
				{
					LinkNodes(compiledXPathNode, node);
				}
			}
			return true;
		}

		private static bool ParseValue(Tokenizer source, out XPathExpression value)
		{
			int index = source.Index;
			if (!Consume(source, Token.StringLiteral) && (!Consume(source, Token.VariableStart) || !ParseQualifiedName(source, null)))
			{
				return Try.Failure<XPathExpression>(out value);
			}
			string consumedText = source.GetConsumedText(index);
			value = XPathExpression.Compile(consumedText);
			return true;
		}

		private static bool ParseQualifiedName(Tokenizer source, CompiledXPathNode node)
		{
			if (!ParseName(source, out var name))
			{
				return false;
			}
			if (!Consume(source, Token.NameSeparator))
			{
				if (node != null)
				{
					node.LocalName = name;
				}
				return true;
			}
			if (!ParseName(source, out var name2))
			{
				return false;
			}
			if (node != null)
			{
				node.Prefix = name;
				node.LocalName = name2;
			}
			return true;
		}

		private static bool ParseName(Tokenizer source, out string name)
		{
			if (source.Token != Token.Name)
			{
				return Try.Failure<string>(out name);
			}
			name = source.Text;
			source.Consume();
			return true;
		}

		private static bool Consume(Tokenizer source, Token token)
		{
			if (source.Token != token)
			{
				return false;
			}
			source.Consume();
			return true;
		}

		private static void LinkNodes(CompiledXPathNode previous, CompiledXPathNode next)
		{
			previous.NextNode = next;
			next.PreviousNode = previous;
		}
	}
}
