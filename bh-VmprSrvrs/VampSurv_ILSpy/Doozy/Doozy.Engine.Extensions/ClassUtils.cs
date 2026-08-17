using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Cpp2ILInjected;

namespace Doozy.Engine.Extensions;

public static class ClassUtils
{
	public static T Clone<T>(T source)
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected O, but got Unknown
		//IL_011f: Expected I8, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ rdx (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		object obj4 = default(object);
		object obj3 = obj4;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v275 @ rdx_v10+268] (should have been resolved before IL gen)");
		object obj5 = default(object);
		if (obj5 != null)
		{
			if (source != null)
			{
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				MemoryStream memoryStream = new MemoryStream();
				if (binaryFormatter != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804F1390");
					if (memoryStream != null)
					{
						long num = memoryStream.Seek(0L, SeekOrigin.Begin);
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804F12C0");
						MemoryStream memoryStream2 = default(MemoryStream);
						bool flag = memoryStream2 == null;
						T result = (T)null;
						if (!flag)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
							T val = default(T);
							bool flag2 = val == null;
							result = val;
							if (flag2)
							{
								throw new InvalidCastException();
							}
						}
						object obj6 = default(object);
						if (obj6 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
						}
						return result;
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			return (T)null;
		}
		ArgumentException ex = new ArgumentException("The type must be serializable.", "source");
		ex._002Ector("The type must be serializable.", "source");
		throw ex;
	}
}
