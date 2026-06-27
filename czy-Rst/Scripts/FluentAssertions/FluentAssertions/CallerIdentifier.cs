using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using FluentAssertions.CallerIdentification;
using FluentAssertions.Common;

namespace FluentAssertions
{
	public static class CallerIdentifier
	{
		private sealed class StackFrameReference : IDisposable
		{
			private readonly StackFrameReference previousReference;

			public int SkipStackFrameCount { get; }

			public StackFrameReference()
			{
				StackFrame[] frames = GetFrames(new StackTrace());
				int i;
				for (i = 0; i < frames.Length && IsCurrentAssembly(frames[i]); i++)
				{
				}
				SkipStackFrameCount = frames.Length - i + 1;
				previousReference = StartStackSearchAfterStackFrame.Value;
				StartStackSearchAfterStackFrame.Value = this;
			}

			public void Dispose()
			{
				StartStackSearchAfterStackFrame.Value = previousReference;
			}
		}

		private static readonly AsyncLocal<StackFrameReference> StartStackSearchAfterStackFrame = new AsyncLocal<StackFrameReference>();

		public static Action<string> Logger { get; set; } = delegate
		{
		};

		public static string DetermineCallerIdentity()
		{
			return DetermineCallerIdentities().FirstOrDefault();
		}

		public static string[] DetermineCallerIdentities()
		{
			string[] result = Array.Empty<string>();
			try
			{
				StackFrame[] frames = GetFrames(new StackTrace(fNeedFileInfo: true));
				int num = frames.Length - 1;
				if (StartStackSearchAfterStackFrame.Value != null)
				{
					num = Array.FindLastIndex(frames, frames.Length - StartStackSearchAfterStackFrame.Value.SkipStackFrameCount, (StackFrame frame) => !IsCurrentAssembly(frame));
				}
				for (int num2 = Array.FindIndex(frames, 0, num + 1, (StackFrame frame) => !IsCurrentAssembly(frame) && !IsDynamic(frame) && !IsDotNet(frame)); num2 < frames.Length; num2++)
				{
					StackFrame stackFrame = frames[num2];
					Logger(stackFrame.ToString());
					if ((object)stackFrame.GetMethod() != null && !IsDynamic(stackFrame) && !IsDotNet(stackFrame) && !IsCustomAssertion(stackFrame) && !IsCurrentAssembly(stackFrame))
					{
						result = ExtractCallersFrom(stackFrame).ToArray();
						break;
					}
				}
			}
			catch (Exception ex)
			{
				Logger(ex.ToString());
			}
			return result;
		}

		internal static IDisposable OverrideStackSearchUsingCurrentScope()
		{
			return new StackFrameReference();
		}

		internal static bool OnlyOneFluentAssertionScopeOnCallStack()
		{
			StackFrame[] frames = GetFrames(new StackTrace());
			int num = Array.FindIndex(frames, (StackFrame frame) => !IsCurrentAssembly(frame));
			if (num < 0)
			{
				return true;
			}
			return Array.FindIndex(frames, num + 1, (StackFrame frame) => IsCurrentAssembly(frame)) < 0;
		}

		private static bool IsCustomAssertion(StackFrame frame)
		{
			MethodBase method = frame.GetMethod();
			if ((object)method != null)
			{
				if (!method.IsDecoratedWithOrInherit<CustomAssertionAttribute>())
				{
					return method.ReflectedType?.Assembly.IsDefined(typeof(CustomAssertionsAssemblyAttribute)) ?? false;
				}
				return true;
			}
			return false;
		}

		private static bool IsDynamic(StackFrame frame)
		{
			MethodBase method = frame.GetMethod();
			if ((object)method != null)
			{
				return (object)method.DeclaringType == null;
			}
			return false;
		}

		private static bool IsCurrentAssembly(StackFrame frame)
		{
			return frame.GetMethod()?.DeclaringType?.Assembly == typeof(CallerIdentifier).Assembly;
		}

		private static bool IsDotNet(StackFrame frame)
		{
			string text = frame.GetMethod()?.DeclaringType?.Namespace;
			if (text == null || !text.StartsWith("system.", StringComparison.OrdinalIgnoreCase))
			{
				return text?.Equals("system", StringComparison.OrdinalIgnoreCase) ?? false;
			}
			return true;
		}

		private static bool IsCompilerServices(StackFrame frame)
		{
			return frame.GetMethod()?.DeclaringType?.Namespace == "System.Runtime.CompilerServices";
		}

		private static IEnumerable<string> ExtractCallersFrom(StackFrame frame)
		{
			string[] callerIdentifiersFrom = GetCallerIdentifiersFrom(frame);
			string[] array = callerIdentifiersFrom;
			foreach (string text in array)
			{
				Logger(text);
				if (!IsBooleanLiteral(text) && !IsNumeric(text) && !IsStringLiteral(text) && !StartsWithNewKeyword(text))
				{
					yield return text;
				}
			}
		}

		private static string[] GetCallerIdentifiersFrom(StackFrame frame)
		{
			string fileName = frame.GetFileName();
			int fileLineNumber = frame.GetFileLineNumber();
			if (string.IsNullOrEmpty(fileName) || fileLineNumber == 0)
			{
				return null;
			}
			try
			{
				using StreamReader streamReader = new StreamReader(File.OpenRead(fileName));
				int num = 1;
				string text;
				while ((text = streamReader.ReadLine()) != null && num < fileLineNumber)
				{
					num++;
				}
				return (num == fileLineNumber && text != null) ? GetCallerIdentifiersFrom(frame, streamReader, text) : null;
			}
			catch
			{
				return Array.Empty<string>();
			}
		}

		private static string[] GetCallerIdentifiersFrom(StackFrame frame, StreamReader reader, string line)
		{
			int fileColumnNumber = frame.GetFileColumnNumber();
			if (fileColumnNumber > 0)
			{
				line = line.Substring(Math.Min(fileColumnNumber - 1, line.Length - 1));
			}
			StatementParser statementParser = new StatementParser();
			do
			{
				statementParser.Append(line);
			}
			while (!statementParser.IsDone() && (line = reader.ReadLine()) != null);
			return statementParser.Identifiers;
		}

		private static bool StartsWithNewKeyword(string candidate)
		{
			return Regex.IsMatch(candidate, "(?:^|s+)new(?:\\s?\\[|\\s?\\{|\\s\\w+)");
		}

		private static bool IsStringLiteral(string candidate)
		{
			return SystemExtensions.StartsWith(candidate, '"');
		}

		private static bool IsNumeric(string candidate)
		{
			double result;
			return double.TryParse(candidate, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out result);
		}

		private static bool IsBooleanLiteral(string candidate)
		{
			if (candidate == "true" || candidate == "false")
			{
				return true;
			}
			return false;
		}

		private static StackFrame[] GetFrames(StackTrace stack)
		{
			StackFrame[] frames = stack.GetFrames();
			if (frames == null)
			{
				return Array.Empty<StackFrame>();
			}
			return frames.Where((StackFrame frame) => !IsCompilerServices(frame)).ToArray();
		}
	}
}
