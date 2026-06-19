using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.RegularExpressions;
using Sentry.Extensibility;
using Sentry.Internal.Extensions;
using Sentry.Protocol;

namespace Sentry.Internal
{
	internal class DebugStackTrace : SentryStackTrace
	{
		private readonly SentryOptions _options;

		private readonly Dictionary<Guid, int> _debugImageIndexByModule = new Dictionary<Guid, int>();

		private const int DebugImageMissing = -1;

		private bool _debugImagesMerged;

		private static readonly Regex RegexAsyncFunctionName = new Regex("^(.*)\\+<(\\w*)>d__\\d*$", RegexOptions.Compiled | RegexOptions.CultureInvariant);

		private static readonly Regex RegexAnonymousFunction = new Regex("^<(\\w*)>b__\\w+$", RegexOptions.Compiled | RegexOptions.CultureInvariant);

		private static readonly Regex RegexAsyncReturn = new Regex("^(.+`[0-9]+)\\[\\[", RegexOptions.Compiled | RegexOptions.CultureInvariant);

		private static readonly Regex RegexNativeAOTInfo = new Regex("^(.+)\\.([^.]+\\(.*\\)) ?\\+ ?0x", RegexOptions.Compiled | RegexOptions.CultureInvariant);

		protected List<DebugImage> DebugImages { get; } = new List<DebugImage>();

		internal DebugStackTrace(SentryOptions options)
		{
			_options = options;
		}

		internal static DebugStackTrace Create(SentryOptions options, StackTrace stackTrace, bool isCurrentStackTrace, int skipFrames = 0)
		{
			return Create(options, stackTrace, isCurrentStackTrace, delegate(string? frameInfo)
			{
				if (frameInfo?.StartsWith("Sentry") ?? false)
				{
					options.LogDebug("Skipping initial stack frame '{0}'", frameInfo);
					return true;
				}
				return skipFrames-- > 0;
			});
		}

		internal static DebugStackTrace Create(SentryOptions options, StackTrace stackTrace, bool isCurrentStackTrace, Func<string?, bool> skipFrame)
		{
			DebugStackTrace debugStackTrace = new DebugStackTrace(options);
			foreach (SentryStackFrame item in debugStackTrace.CreateFrames(stackTrace, isCurrentStackTrace, skipFrame).Reverse())
			{
				debugStackTrace.Frames.Add(item);
			}
			return debugStackTrace;
		}

		internal void MergeDebugImagesInto(SentryEvent @event)
		{
			if (_debugImagesMerged)
			{
				_options.LogWarning("Cannot call MergeDebugImagesInto multiple times. Event: {0}", @event.EventId);
				return;
			}
			_debugImagesMerged = true;
			_options.LogDebug("Merging {0} debug images from stacktrace.", DebugImages.Count);
			if (DebugImages.Count == 0)
			{
				return;
			}
			if (@event.DebugImages == null)
			{
				List<DebugImage> list = (@event.DebugImages = new List<DebugImage>());
			}
			if (@event.DebugImages.Count == 0)
			{
				@event.DebugImages.AddRange(DebugImages);
				return;
			}
			int count = @event.DebugImages.Count;
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			for (int i = 0; i < DebugImages.Count; i++)
			{
				if (DebugImages[i].ModuleVersionId.HasValue)
				{
					bool flag = false;
					for (int j = 0; j < count; j++)
					{
						if (DebugImages[i].ModuleVersionId == @event.DebugImages[j].ModuleVersionId)
						{
							if (i != j)
							{
								dictionary.Add(GetRelativeAddressMode(i), GetRelativeAddressMode(j));
							}
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						dictionary.Add(GetRelativeAddressMode(i), GetRelativeAddressMode(@event.DebugImages.Count));
						@event.DebugImages.Add(DebugImages[i]);
					}
				}
				else if (DebugImages[i].ImageAddress.HasValue)
				{
					bool flag2 = false;
					for (int k = 0; k < count; k++)
					{
						if (DebugImages[i].ImageAddress == @event.DebugImages[k].ImageAddress)
						{
							flag2 = true;
							break;
						}
					}
					if (!flag2)
					{
						@event.DebugImages.Add(DebugImages[i]);
					}
				}
				else
				{
					_options.LogWarning("Unexpected debug image: neither ModuleVersionId nor ImageAddress is defined");
				}
			}
			foreach (SentryStackFrame frame in base.Frames)
			{
				if (frame.AddressMode != null && dictionary.TryGetValue(frame.AddressMode, out var value))
				{
					frame.AddressMode = value;
				}
			}
		}

		[UnconditionalSuppressMessage("Trimming", "IL2026:Members annotated with 'RequiresUnreferencedCodeAttribute' require dynamic access otherwise can break functionality when trimming application code", Justification = "Non-trimmable code is avoided at runtime")]
		private IEnumerable<SentryStackFrame> CreateFrames(StackTrace stackTrace, bool isCurrentStackTrace, Func<string?, bool> skipFrame)
		{
			IEnumerable<RealStackFrame> enumerable = ((_options.StackTraceMode == StackTraceMode.Enhanced) ? (from p in EnhancedStackTrace.GetFrames(stackTrace)
				select new RealStackFrame(p)) : (from p in stackTrace.GetFrames()
				select new RealStackFrame(p)));
			if (enumerable.IsNull())
			{
				_options.LogDebug("No stack frames found. AttachStacktrace: '{0}', isCurrentStackTrace: '{1}'", _options.AttachStacktrace, isCurrentStackTrace);
				yield break;
			}
			bool firstFrame = true;
			foreach (RealStackFrame item in enumerable)
			{
				if (item == null)
				{
					continue;
				}
				if (firstFrame && isCurrentStackTrace)
				{
					string text = null;
					MethodBase method = item.GetMethod();
					if ((object)method != null)
					{
						text = method.DeclaringType?.AssemblyQualifiedName;
					}
					if (text == null && item.HasNativeImage())
					{
						text = item.ToString();
					}
					if (skipFrame(text))
					{
						continue;
					}
				}
				firstFrame = false;
				SentryStackFrame sentryStackFrame = CreateFrame(item);
				if (sentryStackFrame != null)
				{
					yield return sentryStackFrame;
				}
				else
				{
					_options.LogDebug("Could not resolve stack frame '{0}'", item.ToString());
				}
			}
		}

		[UnconditionalSuppressMessage("Trimming", "IL2026:Members annotated with 'RequiresUnreferencedCodeAttribute' require dynamic access otherwise can break functionality when trimming application code", Justification = "Non-trimmable code is avoided at runtime")]
		private SentryStackFrame? TryCreateManagedFrame(IStackFrame stackFrame)
		{
			MethodBase method = stackFrame.GetMethod();
			if ((object)method == null)
			{
				return null;
			}
			SentryStackFrame sentryStackFrame = new SentryStackFrame
			{
				Module = (method.DeclaringType?.FullName ?? "(unknown)"),
				Package = method.DeclaringType?.Assembly.FullName
			};
			sentryStackFrame.Function = method.Name;
			if (stackFrame.Frame is EnhancedStackFrame enhancedStackFrame)
			{
				StringBuilder stringBuilder = new StringBuilder();
				sentryStackFrame.Function = enhancedStackFrame.MethodInfo.Append(stringBuilder, fullName: false).ToString();
				Type declaringType = enhancedStackFrame.MethodInfo.DeclaringType;
				if ((object)declaringType != null)
				{
					stringBuilder.Clear();
					stringBuilder.AppendTypeDisplayName(declaringType);
					string text = stringBuilder.ToString();
					string text2 = declaringType.Namespace;
					sentryStackFrame.Module = ((text2 != null && !text.StartsWith(text2)) ? (text2 + "." + text) : text);
				}
			}
			if (_options.StackTraceMode != StackTraceMode.Original && method.Module.Assembly.IsDynamic)
			{
				sentryStackFrame.InApp = false;
			}
			int? num = AddManagedModuleDebugImage(method.Module);
			if (num.HasValue)
			{
				int valueOrDefault = num.GetValueOrDefault();
				if (valueOrDefault != -1)
				{
					sentryStackFrame.AddressMode = GetRelativeAddressMode(valueOrDefault);
					try
					{
						int metadataToken = method.MetadataToken;
						if ((metadataToken & 0xFF000000u) == 100663296)
						{
							sentryStackFrame.FunctionId = metadataToken & 0xFFFFFF;
						}
					}
					catch (InvalidOperationException)
					{
						_options.LogDebug("Could not get MetadataToken for stack frame {0} from {1}", sentryStackFrame.Function, method.Module.GetNameOrScopeName());
					}
				}
			}
			string text3 = stackFrame.GetFileName();
			if (text3 != null)
			{
				string text4 = AttributeReader.TryGetProjectDirectory(method.Module.Assembly);
				if (text4 != null && text3.StartsWith(text4, StringComparison.OrdinalIgnoreCase))
				{
					sentryStackFrame.AbsolutePath = text3;
					string text5 = text3;
					int length = text4.Length;
					text3 = text5.Substring(length, text5.Length - length);
				}
				sentryStackFrame.FileName = text3;
			}
			return sentryStackFrame;
		}

		internal SentryStackFrame? CreateFrame(IStackFrame stackFrame)
		{
			SentryStackFrame sentryStackFrame = TryCreateManagedFrame(stackFrame);
			if (sentryStackFrame == null)
			{
				return null;
			}
			sentryStackFrame.ConfigureAppFrame(_options);
			int iLOffset = stackFrame.GetILOffset();
			if (iLOffset != -1)
			{
				sentryStackFrame.InstructionAddress = iLOffset;
			}
			int fileLineNumber = stackFrame.GetFileLineNumber();
			if (fileLineNumber > 0)
			{
				sentryStackFrame.LineNumber = fileLineNumber;
			}
			int fileColumnNumber = stackFrame.GetFileColumnNumber();
			if (fileColumnNumber > 0)
			{
				sentryStackFrame.ColumnNumber = fileColumnNumber;
			}
			if (!(stackFrame.Frame is EnhancedStackFrame))
			{
				DemangleAsyncFunctionName(sentryStackFrame);
				DemangleAnonymousFunction(sentryStackFrame);
				DemangleLambdaReturnType(sentryStackFrame);
			}
			else
			{
				sentryStackFrame.Module = null;
			}
			return sentryStackFrame;
		}

		private static string GetRelativeAddressMode(int moduleIndex)
		{
			return $"rel:{moduleIndex}";
		}

		private static void DemangleAsyncFunctionName(SentryStackFrame frame)
		{
			if (frame.Module == null || frame.Function != "MoveNext")
			{
				return;
			}
			Match match = RegexAsyncFunctionName.Match(frame.Module);
			if (match != null && match.Success)
			{
				GroupCollection groups = match.Groups;
				if (groups != null && groups.Count == 3)
				{
					frame.Module = match.Groups[1].Value;
					frame.Function = match.Groups[2].Value;
				}
			}
		}

		internal static void DemangleAnonymousFunction(SentryStackFrame frame)
		{
			if (frame.Function == null)
			{
				return;
			}
			Match match = RegexAnonymousFunction.Match(frame.Function);
			if (match != null && match.Success)
			{
				GroupCollection groups = match.Groups;
				if (groups != null && groups.Count == 2)
				{
					frame.Function = match.Groups[1].Value + " { <lambda> }";
				}
			}
		}

		private static void DemangleLambdaReturnType(SentryStackFrame frame)
		{
			if (frame.Module == null)
			{
				return;
			}
			Match match = RegexAsyncReturn.Match(frame.Module);
			if (match != null && match.Success)
			{
				GroupCollection groups = match.Groups;
				if (groups != null && groups.Count == 2)
				{
					frame.Module = match.Groups[1].Value;
				}
			}
		}

		[UnconditionalSuppressMessage("SingleFile", "IL3002:Avoid calling members marked with 'RequiresAssemblyFilesAttribute' when publishing as a single-file", Justification = "Code is avoided at runtime.")]
		private static PEReader? TryReadAssemblyFromDisk(Module module, SentryOptions options, out string? assemblyName)
		{
			try
			{
				assemblyName = module.FullyQualifiedName;
				string text = assemblyName;
				if ((text == null || text == "<Unknown>") ? true : false)
				{
					assemblyName = null;
					return null;
				}
				Func<string, PEReader> assemblyReader = options.AssemblyReader;
				if (assemblyReader != null)
				{
					return assemblyReader(assemblyName);
				}
				return new PEReader(options.FileSystem.OpenFileForReading(assemblyName));
			}
			catch (Exception)
			{
				assemblyName = null;
				return null;
			}
		}

		private int? AddManagedModuleDebugImage(Module module)
		{
			Guid moduleVersionId = module.ModuleVersionId;
			if (_debugImageIndexByModule.TryGetValue(moduleVersionId, out var value))
			{
				return value;
			}
			DebugImage managedModuleDebugImage = GetManagedModuleDebugImage(module, _options);
			if (managedModuleDebugImage == null)
			{
				_debugImageIndexByModule.Add(moduleVersionId, -1);
				return null;
			}
			value = DebugImages.Count;
			DebugImages.Add(managedModuleDebugImage);
			_debugImageIndexByModule.Add(moduleVersionId, value);
			return value;
		}

		internal static DebugImage? GetManagedModuleDebugImage(Module module, SentryOptions options)
		{
			string nameOrScopeName = module.GetNameOrScopeName();
			string assemblyName;
			using PEReader pEReader = TryReadAssemblyFromDisk(module, options, out assemblyName);
			if (pEReader != null)
			{
				DebugImage debugImage = pEReader.TryGetPEDebugImageData().ToDebugImage(assemblyName, module.ModuleVersionId);
				if (debugImage == null)
				{
					options.LogInfo("Skipping debug image for module '{0}' because the Debug ID couldn't be determined", nameOrScopeName);
					return null;
				}
				options.LogDebug("Got debug image for '{0}' having Debug ID: {1}", nameOrScopeName, debugImage.DebugId);
				return debugImage;
			}
			options.LogDebug("Skipping debug image for module '{0}' because assembly wasn't found: '{1}'", nameOrScopeName, assemblyName);
			return null;
		}
	}
}
