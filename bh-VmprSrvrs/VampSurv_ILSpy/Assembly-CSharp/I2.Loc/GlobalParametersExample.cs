using System;
using Cpp2ILInjected;
using UnityEngine;

namespace I2.Loc;

public class GlobalParametersExample : RegisterGlobalParameters
{
	public unsafe override string GetParameterValue(string ParamName)
	{
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Expected Ref, but got Unknown
		//IL_00bf: Expected I8, but got I4
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Expected Ref, but got Unknown
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Expected Ref, but got Unknown
		//IL_01a3: Expected I8, but got I4
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected Ref, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996CA2D]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		object obj = "WINNER";
		if ((object)ParamName != "WINNER")
		{
			if (ParamName != null && "WINNER" != null)
			{
				int stringLength = ParamName._stringLength;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rdx_v1+10]");
				if ((nint)stringLength == 0)
				{
					ref byte first = ref *(byte*)(ParamName + 20);
					ulong length = (ulong)(ParamName._stringLength + ParamName._stringLength);
					if (System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("WINNER" + 20), length))
					{
						goto IL_01e9;
					}
				}
			}
			object obj2 = "NUM PLAYERS";
			if ((object)ParamName != "NUM PLAYERS")
			{
				if (ParamName != null && "NUM PLAYERS" != null)
				{
					int stringLength2 = ParamName._stringLength;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rdx_v4+10]");
					if ((nint)stringLength2 == 0)
					{
						ref byte first2 = ref *(byte*)(ParamName + 20);
						ulong length2 = (ulong)(ParamName._stringLength + ParamName._stringLength);
						if (System.SpanHelpers.SequenceEqual(ref first2, ref *(byte*)("NUM PLAYERS" + 20), length2))
						{
							goto IL_01d7;
						}
					}
				}
				return null;
			}
			goto IL_01d7;
		}
		goto IL_01e9;
		IL_01e9:
		return "Javier";
		IL_01d7:
		int num = default(int);
		return num.ToString();
	}

	public GlobalParametersExample()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
