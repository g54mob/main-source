using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using Sentry.Extensibility;
using Sentry.Internal;
using Sentry.Internal.Extensions;

namespace Sentry
{
	[DebuggerDisplay("{Function}")]
	public sealed class SentryStackFrame : ISentryJsonSerializable
	{
		private static readonly Lazy<PrefixOrPatternMatcher> LazyModuleMatcher = new Lazy<PrefixOrPatternMatcher>(() => new PrefixOrPatternMatcher());

		private static readonly Lazy<DelimitedPrefixOrPatternMatcher> LazyFunctionMatcher = new Lazy<DelimitedPrefixOrPatternMatcher>(() => new DelimitedPrefixOrPatternMatcher());

		internal List<string>? InternalPreContext { get; private set; }

		internal List<string>? InternalPostContext { get; private set; }

		internal Dictionary<string, string>? InternalVars { get; private set; }

		internal List<int>? InternalFramesOmitted { get; private set; }

		internal bool IsCodeLocation { get; set; }

		public string? FileName { get; set; }

		public string? Function { get; set; }

		public string? Module { get; set; }

		public int? LineNumber { get; set; }

		public int? ColumnNumber { get; set; }

		public string? AbsolutePath { get; set; }

		public string? ContextLine { get; set; }

		public IList<string> PreContext => InternalPreContext ?? (InternalPreContext = new List<string>());

		public IList<string> PostContext => InternalPostContext ?? (InternalPostContext = new List<string>());

		public bool? InApp { get; set; }

		public IDictionary<string, string> Vars => InternalVars ?? (InternalVars = new Dictionary<string, string>());

		public IList<int> FramesOmitted => InternalFramesOmitted ?? (InternalFramesOmitted = new List<int>());

		public string? Package { get; set; }

		public string? Platform { get; set; }

		public long? ImageAddress { get; set; }

		public long? SymbolAddress { get; set; }

		public long? InstructionAddress { get; set; }

		public string? AddressMode { get; set; }

		public long? FunctionId { get; set; }

		public void WriteTo(Utf8JsonWriter writer, IDiagnosticLogger? logger)
		{
			writer.WriteStartObject();
			if (IsCodeLocation)
			{
				writer.WriteString("type", "location");
			}
			writer.WriteStringArrayIfNotEmpty("pre_context", InternalPreContext);
			writer.WriteStringArrayIfNotEmpty("post_context", InternalPostContext);
			writer.WriteStringDictionaryIfNotEmpty("vars", InternalVars);
			writer.WriteArrayIfNotEmpty("frames_omitted", InternalFramesOmitted?.Cast<object>(), logger);
			writer.WriteStringIfNotWhiteSpace("filename", FileName);
			writer.WriteStringIfNotWhiteSpace("function", Function);
			writer.WriteStringIfNotWhiteSpace("module", Module);
			writer.WriteNumberIfNotNull("lineno", LineNumber);
			writer.WriteNumberIfNotNull("colno", ColumnNumber);
			writer.WriteStringIfNotWhiteSpace("abs_path", AbsolutePath);
			writer.WriteStringIfNotWhiteSpace("context_line", ContextLine);
			writer.WriteBooleanIfNotNull("in_app", InApp);
			writer.WriteStringIfNotWhiteSpace("package", Package);
			writer.WriteStringIfNotWhiteSpace("platform", Platform);
			writer.WriteStringIfNotWhiteSpace("image_addr", ImageAddress?.NullIfDefault()?.ToHexString());
			writer.WriteStringIfNotWhiteSpace("symbol_addr", SymbolAddress?.NullIfDefault()?.ToHexString());
			writer.WriteStringIfNotWhiteSpace("instruction_addr", InstructionAddress?.ToHexString());
			writer.WriteStringIfNotWhiteSpace("addr_mode", AddressMode);
			writer.WriteStringIfNotWhiteSpace("function_id", FunctionId?.ToHexString());
			writer.WriteEndObject();
		}

		public void ConfigureAppFrame(SentryOptions options)
		{
			if (InApp.HasValue)
			{
				return;
			}
			if (!string.IsNullOrEmpty(Module))
			{
				ConfigureAppFrame(options, Module, LazyModuleMatcher.Value);
				return;
			}
			if (!string.IsNullOrEmpty(Function))
			{
				ConfigureAppFrame(options, Function, LazyFunctionMatcher.Value);
				return;
			}
			long? imageAddress = ImageAddress;
			bool flag = ((!imageAddress.HasValue || imageAddress.GetValueOrDefault() == 0L) ? true : false);
			bool flag2 = flag;
			if (flag2)
			{
				long? instructionAddress = InstructionAddress;
				bool flag3 = ((!instructionAddress.HasValue || instructionAddress.GetValueOrDefault() == 0L) ? true : false);
				flag2 = flag3;
			}
			if (flag2)
			{
				InApp = true;
			}
		}

		private void ConfigureAppFrame(SentryOptions options, string parameter, IStringOrRegexMatcher matcher)
		{
			InApp = parameter.MatchesAny(options.InAppInclude, matcher) || !parameter.MatchesAny(options.InAppExclude, matcher);
		}

		public static SentryStackFrame FromJson(JsonElement json)
		{
			JsonElement? propertyOrNull = json.GetPropertyOrNull("pre_context");
			List<string> internalPreContext = (propertyOrNull.HasValue ? (from j in propertyOrNull.GetValueOrDefault().EnumerateArray()
				select j.GetString()).ToList() : null);
			propertyOrNull = json.GetPropertyOrNull("post_context");
			List<string> internalPostContext = (propertyOrNull.HasValue ? (from j in propertyOrNull.GetValueOrDefault().EnumerateArray()
				select j.GetString()).ToList() : null);
			Dictionary<string, string> dictionary = json.GetPropertyOrNull("vars")?.GetStringDictionaryOrNull();
			propertyOrNull = json.GetPropertyOrNull("frames_omitted");
			List<int> internalFramesOmitted = (propertyOrNull.HasValue ? (from j in propertyOrNull.GetValueOrDefault().EnumerateArray()
				select j.GetInt32()).ToList() : null);
			string fileName = json.GetPropertyOrNull("filename")?.GetString();
			string function = json.GetPropertyOrNull("function")?.GetString();
			string module = json.GetPropertyOrNull("module")?.GetString();
			int? lineNumber = json.GetPropertyOrNull("lineno")?.GetInt32();
			int? columnNumber = json.GetPropertyOrNull("colno")?.GetInt32();
			string absolutePath = json.GetPropertyOrNull("abs_path")?.GetString();
			string contextLine = json.GetPropertyOrNull("context_line")?.GetString();
			bool? inApp = json.GetPropertyOrNull("in_app")?.GetBoolean();
			string package = json.GetPropertyOrNull("package")?.GetString();
			string platform = json.GetPropertyOrNull("platform")?.GetString();
			long? imageAddress = json.GetPropertyOrNull("image_addr")?.GetHexAsLong();
			long? symbolAddress = json.GetPropertyOrNull("symbol_addr")?.GetHexAsLong();
			long? instructionAddress = json.GetPropertyOrNull("instruction_addr")?.GetHexAsLong();
			string addressMode = json.GetPropertyOrNull("addr_mode")?.GetString();
			long? functionId = json.GetPropertyOrNull("function_id")?.GetHexAsLong();
			return new SentryStackFrame
			{
				InternalPreContext = internalPreContext,
				InternalPostContext = internalPostContext,
				InternalVars = dictionary?.WhereNotNullValue().ToDict(),
				InternalFramesOmitted = internalFramesOmitted,
				FileName = fileName,
				Function = function,
				Module = module,
				LineNumber = lineNumber,
				ColumnNumber = columnNumber,
				AbsolutePath = absolutePath,
				ContextLine = contextLine,
				InApp = inApp,
				Package = package,
				Platform = platform,
				ImageAddress = imageAddress,
				SymbolAddress = symbolAddress,
				InstructionAddress = instructionAddress,
				AddressMode = addressMode,
				FunctionId = functionId
			};
		}
	}
}
