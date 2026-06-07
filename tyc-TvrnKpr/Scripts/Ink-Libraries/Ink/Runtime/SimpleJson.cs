using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Ink.Runtime
{
	public static class SimpleJson
	{
		private class Reader
		{
			private string _text;

			private int _offset;

			private object _rootObject;

			public Reader(string text)
			{
			}

			public Dictionary<string, object> ToDictionary()
			{
				return null;
			}

			public List<object> ToArray()
			{
				return null;
			}

			private bool IsNumberChar(char c)
			{
				return false;
			}

			private bool IsFirstNumberChar(char c)
			{
				return false;
			}

			private object ReadObject()
			{
				return null;
			}

			private Dictionary<string, object> ReadDictionary()
			{
				return null;
			}

			private List<object> ReadArray()
			{
				return null;
			}

			private string ReadString()
			{
				return null;
			}

			private object ReadNumber()
			{
				return null;
			}

			private bool TryRead(string textToRead)
			{
				return false;
			}

			private void Expect(string expectedStr)
			{
			}

			private void Expect(bool condition, string message = null)
			{
			}

			private void SkipWhitespace()
			{
			}
		}

		public class Writer
		{
			private enum State
			{
				None = 0,
				Object = 1,
				Array = 2,
				Property = 3,
				PropertyName = 4,
				String = 5
			}

			private struct StateElement
			{
				public State type;

				public int childCount;
			}

			private Stack<StateElement> _stateStack;

			private TextWriter _writer;

			private State state => default(State);

			private int childCount => 0;

			public Writer()
			{
			}

			public Writer(Stream stream)
			{
			}

			public void WriteObject(Action<Writer> inner)
			{
			}

			public void WriteObjectStart()
			{
			}

			public void WriteObjectEnd()
			{
			}

			public void WriteProperty(string name, Action<Writer> inner)
			{
			}

			public void WriteProperty(int id, Action<Writer> inner)
			{
			}

			public void WriteProperty(string name, string content)
			{
			}

			public void WriteProperty(string name, int content)
			{
			}

			public void WriteProperty(string name, bool content)
			{
			}

			public void WritePropertyStart(string name)
			{
			}

			public void WritePropertyStart(int id)
			{
			}

			public void WritePropertyEnd()
			{
			}

			public void WritePropertyNameStart()
			{
			}

			public void WritePropertyNameEnd()
			{
			}

			public void WritePropertyNameInner(string str)
			{
			}

			private void WritePropertyStart<T>(T name)
			{
			}

			private void WriteProperty<T>(T name, Action<Writer> inner)
			{
			}

			public void WriteArrayStart()
			{
			}

			public void WriteArrayEnd()
			{
			}

			public void Write(int i)
			{
			}

			public void Write(float f)
			{
			}

			public void Write(string str, bool escape = true)
			{
			}

			public void Write(bool b)
			{
			}

			public void WriteNull()
			{
			}

			public void WriteStringStart()
			{
			}

			public void WriteStringEnd()
			{
			}

			public void WriteStringInner(string str, bool escape = true)
			{
			}

			private void WriteEscapedString(string str)
			{
			}

			private void StartNewObject(bool container)
			{
			}

			private void IncrementChildCount()
			{
			}

			[Conditional("DEBUG")]
			private void Assert(bool condition)
			{
			}

			public override string ToString()
			{
				return null;
			}
		}

		public static Dictionary<string, object> TextToDictionary(string text)
		{
			return null;
		}

		public static List<object> TextToArray(string text)
		{
			return null;
		}
	}
}
