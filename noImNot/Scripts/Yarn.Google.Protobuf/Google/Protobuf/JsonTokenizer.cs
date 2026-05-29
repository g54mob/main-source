using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Google.Protobuf
{
	internal abstract class JsonTokenizer
	{
		private class JsonReplayTokenizer : JsonTokenizer
		{
			private readonly IList<JsonToken> tokens;

			private readonly JsonTokenizer nextTokenizer;

			private int nextTokenIndex;

			internal JsonReplayTokenizer(IList<JsonToken> tokens, JsonTokenizer nextTokenizer)
			{
			}

			protected override JsonToken NextImpl()
			{
				return null;
			}
		}

		private sealed class JsonTextTokenizer : JsonTokenizer
		{
			private enum ContainerType
			{
				Document = 0,
				Object = 1,
				Array = 2
			}

			[Flags]
			private enum State
			{
				StartOfDocument = 1,
				ExpectedEndOfDocument = 2,
				ReaderExhausted = 4,
				ObjectStart = 8,
				ObjectBeforeColon = 0x10,
				ObjectAfterColon = 0x20,
				ObjectAfterProperty = 0x40,
				ObjectAfterComma = 0x80,
				ArrayStart = 0x100,
				ArrayAfterValue = 0x200,
				ArrayAfterComma = 0x400
			}

			private class PushBackReader
			{
				private readonly TextReader reader;

				private char? nextChar;

				internal PushBackReader(TextReader reader)
				{
				}

				internal char? Read()
				{
					return null;
				}

				internal char ReadOrFail(string messageOnFailure)
				{
					return '\0';
				}

				internal void PushBack(char c)
				{
				}

				internal InvalidJsonException CreateException(string message)
				{
					return null;
				}
			}

			private static readonly State ValueStates;

			private readonly Stack<ContainerType> containerStack;

			private readonly PushBackReader reader;

			private State state;

			internal JsonTextTokenizer(TextReader reader)
			{
			}

			protected override JsonToken NextImpl()
			{
				return null;
			}

			private void ValidateState(State validStates, string errorPrefix)
			{
			}

			private string ReadString()
			{
				return null;
			}

			private char ReadEscapedCharacter()
			{
				return '\0';
			}

			private char ReadUnicodeEscape()
			{
				return '\0';
			}

			private void ConsumeLiteral(string text)
			{
			}

			private double ReadNumber(char initialCharacter)
			{
				return 0.0;
			}

			private char? ReadInt(StringBuilder builder)
			{
				return null;
			}

			private char? ReadFrac(StringBuilder builder)
			{
				return null;
			}

			private char? ReadExp(StringBuilder builder)
			{
				return null;
			}

			private char? ConsumeDigits(StringBuilder builder, out int count)
			{
				count = default(int);
				return null;
			}

			private void ValidateAndModifyStateForValue(string errorPrefix)
			{
			}

			private void PopContainer()
			{
			}
		}

		private JsonToken bufferedToken;

		internal int ObjectDepth { get; private set; }

		internal static JsonTokenizer FromTextReader(TextReader reader)
		{
			return null;
		}

		internal static JsonTokenizer FromReplayedTokens(IList<JsonToken> tokens, JsonTokenizer continuation)
		{
			return null;
		}

		internal void PushBack(JsonToken token)
		{
		}

		internal JsonToken Next()
		{
			return null;
		}

		protected abstract JsonToken NextImpl();

		internal void SkipValue()
		{
		}
	}
}
