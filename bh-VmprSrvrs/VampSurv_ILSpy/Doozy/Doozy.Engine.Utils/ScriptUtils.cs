using System;
using System.Text;
using Cpp2ILInjected;

namespace Doozy.Engine.Utils;

public static class ScriptUtils
{
	public const char STRING_SEPARATOR = '|';

	private const string BASE64_IDENTIFIER = "B64|";

	private static readonly bool debug;

	public unsafe static string DecodeString(string data)
	{
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected I, but got Unknown
		//IL_00be: Expected I, but got O
		//IL_00ce: Expected O, but got I
		//IL_00de: Expected O, but got I
		if (data.StartsWith("B64|"))
		{
			object obj = "B64|";
			int stringLength = data._stringLength;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rdx_v6+10]");
			int length = (int)((nint)stringLength - (nint)0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rdx_v6+10]");
			string text = data.Substring(0, length);
			if (text == null)
			{
				ArgumentNullException ex = new ArgumentNullException("s");
				ex._002Ector("s");
				throw ex;
			}
			char* inputPtr = (char*)(nint)(text + 20);
			byte[] array = Convert.FromBase64CharPtr(inputPtr, text._stringLength);
			Encoding uTF = Encoding.UTF8;
			nint num = (nint)uTF;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v236 @ r8_v8 (Il2CppClass<System.Text.Encoding>)+368]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v236 @ r8_v8 (Il2CppClass<System.Text.Encoding>)+370]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v157 @ r9_v4 (should have been resolved before IL gen)");
		}
		return data;
	}

	public unsafe static string EncodeString(string data)
	{
		//IL_005a: Expected O, but got Ref
		if (!debug)
		{
			Encoding uTF = Encoding.UTF8;
			if (uTF != null)
			{
				byte[] bytes = uTF.GetBytes(data);
				if (bytes != null)
				{
					object obj = default(object);
					string text = Convert.ToBase64String((ReadOnlySpan<byte>)(&obj));
					return "B64|" + text;
				}
				ArgumentNullException ex = new ArgumentNullException("inArray");
				throw ex;
			}
			return (string)(object)new NullReferenceException();
		}
		return data;
	}
}
