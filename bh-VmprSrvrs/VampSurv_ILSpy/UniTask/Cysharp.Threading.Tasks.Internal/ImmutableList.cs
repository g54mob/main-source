using System;
using Cpp2ILInjected;

namespace Cysharp.Threading.Tasks.Internal;

internal class ImmutableList<T>
{
	public static readonly ImmutableList<T> Empty;

	private T[] data;

	public T[] Data => data;

	private ImmutableList()
	{
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_array_new_specific\"");
		T[] array = default(T[]);
		data = array;
	}

	public ImmutableList(T[] data)
	{
		this.data = data;
	}

	public ImmutableList<T> Add(T value)
	{
		//IL_001f: Expected O, but got I4
		//IL_0068: Expected I, but got O
		//IL_00d6: Expected O, but got I
		//IL_01c3: Expected I, but got O
		//IL_0131: Expected O, but got I
		T[] array = data;
		object obj = array.Length + 1;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_array_new_specific\"");
		T[] array2 = data;
		Array array3 = default(Array);
		if (array3 != null)
		{
			nint num2 = (nint)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rcx_v15 (Il2CppClass<T[]>)+132]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rax_v20 (T[])+10]");
				int sourceIndex;
				if ((nint)0 == 0)
				{
					sourceIndex = 0;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rax_v20 (T[])+10]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ rax_v40+8]");
					sourceIndex = 0;
				}
				nint num3 = (nint)array3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ rax_v22 (Il2CppClass<System.Array>)+132]");
				if ((nint)0 > (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v19 (System.Array)+10]");
					int destinationIndex;
					if ((nint)0 == 0)
					{
						destinationIndex = 0;
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v19 (System.Array)+10]");
						object obj3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ rax_v39+8]");
						destinationIndex = 0;
					}
					int length = default(int);
					Array.Copy(array2, sourceIndex, array3, destinationIndex, length);
					T[] array4 = data;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					nint num4 = 0;
					ImmutableList<T> immutableList = null;
					immutableList.data = (T[])array3;
					return immutableList;
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
			IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
			throw ex2;
		}
		ArgumentNullException ex3 = new ArgumentNullException("destinationArray");
		ex3._002Ector("destinationArray");
		throw ex3;
	}

	public ImmutableList<T> Remove(T value)
	{
		//IL_01bf: Expected O, but got I4
		//IL_00e2: Expected I, but got O
		//IL_0258: Expected O, but got I
		//IL_026d: Expected O, but got I
		T[] array = data;
		int num = 0;
		int num2 = 0;
		object obj = default(object);
		nint num4 = default(nint);
		Array destinationArray = default(Array);
		int length = default(int);
		ImmutableList<T> result;
		while (true)
		{
			nint num3;
			if (num < array.Length)
			{
				T[] array2 = data;
				if (num2 >= array2.Length)
				{
					return (ImmutableList<T>)(object)new IndexOutOfRangeException();
				}
				T val = array2[num2];
				if ((object)array2[num2] != (object)value)
				{
					bool flag = array2[num2] == null;
					num3 = num4;
					if (flag)
					{
						goto IL_012c;
					}
					bool flag2 = value == null;
					num3 = num4;
					if (flag2)
					{
						goto IL_012c;
					}
					nint num5 = (nint)val;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v330 @ r8_v8 (Il2CppClass<T>)+140]");
					num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v330 @ r8_v8 (Il2CppClass<T>)+138] (should have been resolved before IL gen)");
					bool flag3 = obj != null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v330 @ r8_v8 (Il2CppClass<T>)+140]");
					num4 = 0;
					if (!flag3)
					{
						goto IL_012c;
					}
				}
				if (num2 >= 0)
				{
					T[] array3 = data;
					nint num6 = 0;
					if (array3.Length != 1)
					{
						object obj2 = array3.Length - 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_array_new_specific\"");
						Array.Copy(data, 0, destinationArray, 0, length);
						int sourceIndex = num2 + 1;
						Array.Copy(data, sourceIndex, destinationArray, num2, length);
						nint num7 = 0;
						result = null;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804D0380");
					}
					else
					{
						nint num8 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ rcx_v9 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.ImmutableList`1>)+30]");
						object obj3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v404 @ rax_v15+B8]");
						object obj4 = 0;
						result = (ImmutableList<T>)obj4;
					}
					break;
				}
			}
			result = this;
			break;
			IL_012c:
			array = data;
			num2++;
			num4 = num3;
			num = num2;
		}
		return result;
	}

	public int IndexOf(T value)
	{
		//IL_0156: Expected I4, but got I8
		//IL_0164: Expected I4, but got O
		//IL_00f3: Expected I, but got O
		T[] array = data;
		int num = 0;
		int num2 = 0;
		object obj = default(object);
		while (true)
		{
			if (num < array.Length)
			{
				T[] array2 = data;
				if (num2 >= array2.Length)
				{
					break;
				}
				T val = array2[num2];
				if ((object)array2[num2] != (object)value)
				{
					if (array2[num2] == null || value == null)
					{
						goto IL_011d;
					}
					nint num3 = (nint)val;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v226 @ r8_v6 (Il2CppClass<T>)+138] (should have been resolved before IL gen)");
					if (obj == null)
					{
						goto IL_011d;
					}
				}
				return num2;
			}
			return -1;
			IL_011d:
			array = data;
			num2++;
			num = num2;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		return (int)ex;
	}

	static ImmutableList()
	{
		//IL_0030: Expected O, but got I
		//IL_0040: Expected O, but got I
		//IL_0050: Expected O, but got I
		//IL_0084: Expected O, but got I
		//IL_0099: Expected O, but got I
		nint num = 0;
		object obj = null;
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rax_v9 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.ImmutableList`1>)+38]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rcx_v5+20]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v10+C0]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_array_new_specific\"");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rax_v17 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.ImmutableList`1>)+30]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rax_v19+B8]");
		object obj6 = 0;
		obj6 = obj;
	}
}
