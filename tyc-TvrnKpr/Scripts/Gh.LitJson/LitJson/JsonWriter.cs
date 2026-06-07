using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace LitJson
{
	public class JsonWriter
	{
		private static readonly NumberFormatInfo numberFormat;

		private WriterContext context;

		private Stack<WriterContext> ctxStack;

		private bool hasReachedEnd;

		private char[] hexSeq;

		private int indentation;

		private int indentValue;

		private StringBuilder stringBuilder;

		public int IndentValue
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public bool PrettyPrint { get; set; }

		public bool Validate { get; set; }

		public bool TypeHinting { get; set; }

		public string HintTypeName { get; set; }

		public string HintValueName { get; set; }

		public TextWriter TextWriter { get; private set; }

		static JsonWriter()
		{
		}

		public JsonWriter()
		{
		}

		public JsonWriter(StringBuilder sb)
		{
		}

		public JsonWriter(TextWriter writer)
		{
		}

		private void DoValidation(Condition cond)
		{
		}

		private void Init()
		{
		}

		private static void IntToHex(int n, char[] hex)
		{
		}

		private void Indent()
		{
		}

		private void Put(string str)
		{
		}

		private void PutNewline(bool addComma = true)
		{
		}

		private void PutString(string str)
		{
		}

		private void Unindent()
		{
		}

		public override string ToString()
		{
			return null;
		}

		public void Reset()
		{
		}

		public void Write(bool boolean)
		{
		}

		public void Write(double number)
		{
		}

		public void Write(decimal number)
		{
		}

		public void Write(long number)
		{
		}

		public void Write(ulong number)
		{
		}

		public void Write(string str)
		{
		}

		public void WriteArrayEnd()
		{
		}

		public void WriteArrayStart()
		{
		}

		public void WriteObjectEnd()
		{
		}

		public void WriteObjectStart()
		{
		}

		public void WritePropertyName(string name)
		{
		}
	}
}
