using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Google.Protobuf.Reflection;

namespace Google.Protobuf
{
	public sealed class JsonFormatter
	{
		public sealed class Settings
		{
			public static Settings Default { get; }

			public bool FormatDefaultValues { get; }

			public TypeRegistry TypeRegistry { get; }

			public bool FormatEnumsAsIntegers { get; }

			public bool PreserveProtoFieldNames { get; }

			public string Indentation { get; }

			static Settings()
			{
			}

			public Settings(bool formatDefaultValues)
			{
			}

			public Settings(bool formatDefaultValues, TypeRegistry typeRegistry)
			{
			}

			private Settings(bool formatDefaultValues, TypeRegistry typeRegistry, bool formatEnumsAsIntegers, bool preserveProtoFieldNames, string indentation = null)
			{
			}

			public Settings WithFormatDefaultValues(bool formatDefaultValues)
			{
				return null;
			}

			public Settings WithTypeRegistry(TypeRegistry typeRegistry)
			{
				return null;
			}

			public Settings WithFormatEnumsAsIntegers(bool formatEnumsAsIntegers)
			{
				return null;
			}

			public Settings WithPreserveProtoFieldNames(bool preserveProtoFieldNames)
			{
				return null;
			}

			public Settings WithIndentation(string indentation = "  ")
			{
				return null;
			}
		}

		private static class OriginalEnumValueHelper
		{
			private static readonly ConcurrentDictionary<Type, Dictionary<object, string>> dictionaries;

			[UnconditionalSuppressMessage("Trimming", "IL2072", Justification = "The field for the value must still be present. It will be returned by reflection, will be in this collection, and its name can be resolved.")]
			internal static string GetOriginalName(object value)
			{
				return null;
			}

			private static Dictionary<object, string> GetNameMapping([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields)] Type enumType)
			{
				return null;
			}
		}

		internal const string AnyTypeUrlField = "@type";

		internal const string AnyDiagnosticValueField = "@value";

		internal const string AnyWellKnownTypeValueField = "value";

		private const string NameValueSeparator = ": ";

		private const string ValueSeparator = ", ";

		private const string MultilineValueSeparator = ",";

		private const char ObjectOpenBracket = '{';

		private const char ObjectCloseBracket = '}';

		private const char ListBracketOpen = '[';

		private const char ListBracketClose = ']';

		private static readonly JsonFormatter diagnosticFormatter;

		private static readonly string[] CommonRepresentations;

		private readonly Settings settings;

		private const string Hex = "0123456789abcdef";

		public static JsonFormatter Default { get; }

		private bool DiagnosticOnly => false;

		static JsonFormatter()
		{
		}

		public JsonFormatter(Settings settings)
		{
		}

		public string Format(IMessage message)
		{
			return null;
		}

		public string Format(IMessage message, int indentationLevel)
		{
			return null;
		}

		public void Format(IMessage message, TextWriter writer)
		{
		}

		public void Format(IMessage message, TextWriter writer, int indentationLevel)
		{
		}

		public static string ToDiagnosticString(IMessage message)
		{
			return null;
		}

		private void WriteMessage(TextWriter writer, IMessage message, int indentationLevel)
		{
		}

		private bool WriteMessageFields(TextWriter writer, IMessage message, bool assumeFirstFieldWritten, int indentationLevel)
		{
			return false;
		}

		private void MaybeWriteValueSeparator(TextWriter writer, bool first)
		{
		}

		private bool ShouldFormatFieldValue(IMessage message, FieldDescriptor field, object value)
		{
			return false;
		}

		internal static string ToJsonName(string name)
		{
			return null;
		}

		internal static string FromJsonName(string name)
		{
			return null;
		}

		private static void WriteNull(TextWriter writer)
		{
		}

		private static bool IsDefaultValue(FieldDescriptor descriptor, object value)
		{
			return false;
		}

		public void WriteValue(TextWriter writer, object value)
		{
		}

		public void WriteValue(TextWriter writer, object value, int indentationLevel)
		{
		}

		private void WriteWellKnownTypeValue(TextWriter writer, MessageDescriptor descriptor, object value, int indentationLevel)
		{
		}

		private void WriteTimestamp(TextWriter writer, IMessage value)
		{
		}

		private void WriteDuration(TextWriter writer, IMessage value)
		{
		}

		private void WriteFieldMask(TextWriter writer, IMessage value)
		{
		}

		private void WriteAny(TextWriter writer, IMessage value, int indentationLevel)
		{
		}

		private void WriteDiagnosticOnlyAny(TextWriter writer, IMessage value)
		{
		}

		private void WriteStruct(TextWriter writer, IMessage message, int indentationLevel)
		{
		}

		private void WriteStructFieldValue(TextWriter writer, IMessage message, int indentationLevel)
		{
		}

		internal void WriteList(TextWriter writer, IList list, int indentationLevel = 0)
		{
		}

		internal void WriteDictionary(TextWriter writer, IDictionary dictionary, int indentationLevel = 0)
		{
		}

		internal static void WriteString(TextWriter writer, string text)
		{
		}

		private static void HexEncodeUtf16CodeUnit(TextWriter writer, char c)
		{
		}

		private void WriteBracketOpen(TextWriter writer, char openChar)
		{
		}

		private void WriteBracketClose(TextWriter writer, char closeChar, bool hasFields, int indentationLevel)
		{
		}

		private void MaybeWriteValueWhitespace(TextWriter writer, int indentationLevel)
		{
		}

		private void WriteIndentation(TextWriter writer, int indentationLevel)
		{
		}
	}
}
