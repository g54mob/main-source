using System;
using Cpp2ILInjected;

namespace Doozy.Engine.Utils;

public static class GuidUtils
{
	public unsafe static byte[] GuidToSerializedGuid(Guid guid)
	{
		if (guid._a == (nint)Guid.Empty)
		{
			object obj = (object)Guid.Empty >> 32;
			int num = guid._a >> 32;
			if (num == (nint)obj)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm3,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
				if (guid._a == (nint)Guid.Empty)
				{
					object obj2 = (object)Guid.Empty >> 32;
					int num2 = guid._a >> 32;
					if (num2 == (nint)obj2)
					{
						return null;
					}
				}
			}
		}
		return ((Guid*)guid)->ToByteArray();
	}

	public unsafe static Guid SerializedGuidToGuid(byte[] serializedGuid)
	{
		//IL_0048: Expected I4, but got O
		//IL_0043: Expected native int or pointer, but got O
		//IL_0030: Expected native int or pointer, but got O
		//IL_0077: Expected O, but got Ref
		//IL_0072: Expected native int or pointer, but got O
		Guid guid = default(Guid);
		if (serializedGuid != null && serializedGuid.Length == 16)
		{
			((Guid*)(nint)guid)->_a = 0;
			object obj = default(object);
			*(Guid*)(nint)guid = new Guid((ReadOnlySpan<byte>)(&obj));
			return guid;
		}
		((Guid*)(nint)guid)->_a = (int)Guid.Empty;
		return guid;
	}
}
