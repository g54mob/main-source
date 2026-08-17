using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using Cpp2ILInjected;
using Microsoft.Win32.SafeHandles;
using UnityEngine;

namespace Coherence;

internal static class ProcessUtil
{
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public StringBuilder outputBuilder;

		public StringBuilder errorsBuilder;

		internal void _003CRunProcess_003Eb__0(object _, DataReceivedEventArgs args)
		{
			StringBuilder stringBuilder = outputBuilder.Append(args.data);
			string newLine = Environment.NewLine;
			StringBuilder stringBuilder2 = outputBuilder.Append(newLine);
		}

		internal void _003CRunProcess_003Eb__1(object _, DataReceivedEventArgs args)
		{
			StringBuilder stringBuilder = errorsBuilder.Append(args.data);
			string newLine = Environment.NewLine;
			StringBuilder stringBuilder2 = errorsBuilder.Append(newLine);
		}
	}

	public static Process RunOutsideTerminal(string executable, string arguments)
	{
		Process process = new Process();
		ProcessStartInfo processStartInfo = new ProcessStartInfo(executable, arguments);
		processStartInfo._002Ector(executable, arguments);
		if (processStartInfo != null)
		{
			processStartInfo.createNoWindow = true;
			processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			processStartInfo.redirectStandardOutput = true;
			processStartInfo.useShellExecute = false;
			if (process != null)
			{
				process.startInfo = processStartInfo;
				if (!process.watchForExit)
				{
					if (process.haveProcessId || process.haveProcessHandle)
					{
						SafeProcessHandle safeProcessHandle = process.OpenProcessHandle(2035711);
						process.EnsureWatchingForExit();
					}
					process.watchForExit = true;
				}
				if (process.Start())
				{
					process.BeginOutputReadLine();
				}
				return process;
			}
		}
		return (Process)(object)new NullReferenceException();
	}

	public static string CommandFromExecutableAndArguments(string executable, string arguments)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18997926F]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		return "\"" + executable + "\" " + arguments;
	}

	public static Process RunInTerminal(string command)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189979270]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB70C0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB70C0");
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002BB0");
		string dataPath = Application.dataPath;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002BB0");
		string directoryName = Path.GetDirectoryName(dataPath);
		string projectPath = "\\\"" + directoryName + "\\\"";
		return RunInTerminal(command, projectPath);
	}

	public static Process RunInTerminal(string command, string projectPath)
	{
		PlatformNotSupportedException ex = new PlatformNotSupportedException();
		throw ex;
	}

	public static int RunProcess(string application, string arguments, out string output, out string errors, int waitTimeMs = 5000)
	{
		// ILSpy could not decompile this. Please report the exception below,
		// along with the assembly it came from, at https://github.com/icsharpcode/ILSpy/issues/new
		// System.BadImageFormatException: Read out of bounds.
		//    at System.Reflection.Throw.OutOfBounds()
		//    at ICSharpCode.Decompiler.SRMExtensions.HasBody(MethodDefinition methodDefinition) in /_/ICSharpCode.Decompiler/SRMExtensions.cs:line 135
		//    at ICSharpCode.Decompiler.CSharp.CSharpDecompiler.DecompileBodyForAnalysis(IMethod method, IDecompilerTypeSystem typeSystem, CancellationToken cancellationToken) in /_/ICSharpCode.Decompiler/CSharp/CSharpDecompiler.cs:line 196
		//    at ICSharpCode.Decompiler.CSharp.AutoEventDecompiler.IsAutomaticAccessor(IDecompilerTypeSystem typeSystem, IMethod accessor, IField field, Boolean isAddAccessor, CancellationToken cancellationToken) in /_/ICSharpCode.Decompiler/CSharp/AutoEventDecompiler.cs:line 123
		//    at ICSharpCode.Decompiler.CSharp.AutoEventDecompiler.IsAutomaticEvent(IDecompilerTypeSystem typeSystem, IEvent ev, CancellationToken cancellationToken, IField& backingField) in /_/ICSharpCode.Decompiler/CSharp/AutoEventDecompiler.cs:line 70
		//    at ICSharpCode.Decompiler.CSharp.AutoEventDecompiler.IsAutomaticEvent(IDecompilerTypeSystem typeSystem, IEvent ev, DecompileRun decompileRun, CancellationToken cancellationToken, IField& backingField) in /_/ICSharpCode.Decompiler/CSharp/AutoEventDecompiler.cs:line 51
		//    at ICSharpCode.Decompiler.CSharp.ExpressionBuilder.ConvertField(IField field, ILInstruction targetInstruction) in /_/ICSharpCode.Decompiler/CSharp/ExpressionBuilder.cs:line 304
		//    at ICSharpCode.Decompiler.CSharp.ExpressionBuilder.VisitLdFlda(LdFlda inst, TranslationContext context) in /_/ICSharpCode.Decompiler/CSharp/ExpressionBuilder.cs:line 3154
		//    at ICSharpCode.Decompiler.CSharp.ExpressionBuilder.LdObj(ILInstruction address, IType loadType) in /_/ICSharpCode.Decompiler/CSharp/ExpressionBuilder.cs:line 2896
		//    at ICSharpCode.Decompiler.CSharp.ExpressionBuilder.VisitLdObj(LdObj inst, TranslationContext context) in /_/ICSharpCode.Decompiler/CSharp/ExpressionBuilder.cs:line 2888
		//    at ICSharpCode.Decompiler.CSharp.ExpressionBuilder.VisitStLoc(StLoc inst, TranslationContext context) in /_/ICSharpCode.Decompiler/CSharp/ExpressionBuilder.cs:line 811
		//    at ICSharpCode.Decompiler.CSharp.StatementBuilder.VisitStLoc(StLoc inst) in /_/ICSharpCode.Decompiler/CSharp/StatementBuilder.cs:line 118
		//    at ICSharpCode.Decompiler.CSharp.StatementBuilder.VisitBlock(Block block) in /_/ICSharpCode.Decompiler/CSharp/StatementBuilder.cs:line 1293
		//    at ICSharpCode.Decompiler.CSharp.StatementBuilder.VisitIfInstruction(IfInstruction inst) in /_/ICSharpCode.Decompiler/CSharp/StatementBuilder.cs:line 151
		//    at ICSharpCode.Decompiler.CSharp.StatementBuilder.VisitBlock(Block block) in /_/ICSharpCode.Decompiler/CSharp/StatementBuilder.cs:line 1293
		//    at ICSharpCode.Decompiler.CSharp.StatementBuilder.VisitIfInstruction(IfInstruction inst) in /_/ICSharpCode.Decompiler/CSharp/StatementBuilder.cs:line 151
		//    at ICSharpCode.Decompiler.CSharp.StatementBuilder.VisitBlock(Block block) in /_/ICSharpCode.Decompiler/CSharp/StatementBuilder.cs:line 1293
		//    at ICSharpCode.Decompiler.CSharp.StatementBuilder.VisitIfInstruction(IfInstruction inst) in /_/ICSharpCode.Decompiler/CSharp/StatementBuilder.cs:line 151
		//    at ICSharpCode.Decompiler.CSharp.StatementBuilder.ConvertBlockContainer(BlockStatement blockStatement, BlockContainer container, IEnumerable`1 blocks, Boolean isLoop) in /_/ICSharpCode.Decompiler/CSharp/StatementBuilder.cs:line 1547
		//    at ICSharpCode.Decompiler.CSharp.StatementBuilder.ConvertBlockContainer(BlockContainer container, Boolean isLoop) in /_/ICSharpCode.Decompiler/CSharp/StatementBuilder.cs:line 1434
		//    at ICSharpCode.Decompiler.CSharp.StatementBuilder.VisitBlockContainer(BlockContainer container) in /_/ICSharpCode.Decompiler/CSharp/StatementBuilder.cs:line 1320
		//    at ICSharpCode.Decompiler.CSharp.StatementBuilder.ConvertAsBlock(ILInstruction inst) in /_/ICSharpCode.Decompiler/CSharp/StatementBuilder.cs:line 87
		//    at ICSharpCode.Decompiler.CSharp.CSharpDecompiler.DecompileBody(IMethod method, EntityDeclaration entityDecl, DecompileRun decompileRun, ITypeResolveContext decompilationContext, ExtensionInfo extensionInfo) in /_/ICSharpCode.Decompiler/CSharp/CSharpDecompiler.cs:line 2325
	}

	public static void FixUnixPermissions(string path)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189979272]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string arguments = "755 " + path;
		ProcessStartInfo startInfo = new ProcessStartInfo("chmod", arguments);
		Process process = Process.Start(startInfo);
	}
}
