using System;
using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors;

public class CommandLineHandler : MonoBehaviour
{
	private const string ARG_PREFIX = "-";

	private void Awake()
	{
	}

	private static bool ArgumentExists(string argument)
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected O, but got Unknown
		string[] commandLineArgs = Environment.GetCommandLineArgs();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999F239]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string text = "-" + argument;
		if (commandLineArgs != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180507B80");
			object obj2 = default(object);
			object obj = obj2 - -1;
			bool flag = obj == null;
			return !flag;
		}
		ArgumentNullException ex = new ArgumentNullException("array");
		throw ex;
	}

	private static string GetArgument(string argument)
	{
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Expected O, but got Unknown
		string[] commandLineArgs = Environment.GetCommandLineArgs();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999F239]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string text = "-" + argument;
		if (commandLineArgs != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180507B80");
			object obj = default(object);
			if ((nint)obj != -1)
			{
				string[] commandLineArgs2 = Environment.GetCommandLineArgs();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999F239]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				string text2 = "-" + argument;
				if (commandLineArgs2 == null)
				{
					ArgumentNullException ex = new ArgumentNullException("array");
					ex._002Ector("array");
					throw ex;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180507B80");
				object obj3 = default(object);
				object obj2 = obj3 + 1;
				if ((nint)obj2 < commandLineArgs2.Length)
				{
					object obj4 = obj3 + 1;
					if (!commandLineArgs2[obj4].StartsWith("-"))
					{
						return commandLineArgs2[obj4];
					}
				}
			}
			return "";
		}
		ArgumentNullException ex2 = new ArgumentNullException("array");
		throw ex2;
	}

	private static string ArgWithPrefix(string arg)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18999F239]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		return "-" + arg;
	}

	public CommandLineHandler()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
