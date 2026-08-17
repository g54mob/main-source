using System;
using System.Threading;
using Cpp2ILInjected;

namespace Cysharp.Threading.Tasks.Internal;

internal sealed class ArrayPool<T>
{
	private const int DefaultMaxNumberOfArraysPerBucket = 50;

	private static readonly T[] EmptyArray;

	public static readonly ArrayPool<T> Shared;

	private readonly MinimumQueue<T[]>[] buckets;

	private readonly SpinLock[] locks;

	private ArrayPool()
	{
		//IL_004e: Expected O, but got I4
		//IL_0057: Expected O, but got I4
		//IL_00d1: Expected I, but got O
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Expected O, but got Unknown
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_array_new_specific\"");
		MinimumQueue<T[]>[] array = default(MinimumQueue<T[]>[]);
		buckets = array;
		SpinLock[] array2 = new SpinLock[18];
		locks = array2;
		MinimumQueue<T[]>[] array3 = buckets;
		object obj = 0;
		object obj2 = 0;
		object obj4 = default(object);
		while (true)
		{
			if ((nint)obj2 >= array3.Length)
			{
				return;
			}
			MinimumQueue<T[]>[] array4 = buckets;
			nint num2 = 0;
			object obj3 = null;
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183978360");
			if (obj3 != null)
			{
				nint num4 = (nint)array4;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				if (obj4 == null)
				{
					break;
				}
			}
			array4[obj] = (MinimumQueue<T[]>)obj3;
			SpinLock[] array5 = locks;
			object obj5 = obj + 1;
			_ = 2147483648L;
			array3 = buckets;
			obj = obj5;
			obj2 = obj5;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw ex;
	}

	public unsafe T[] Rent(int minimumLength)
	{
		//IL_02cd: Expected O, but got I
		//IL_02e2: Expected O, but got I
		//IL_002b: Expected O, but got I4
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00e9: Expected O, but got I4
		//IL_048d: Expected I, but got O
		//IL_0158: Expected O, but got I
		//IL_0168: Expected O, but got I
		//IL_01be: Expected I, but got O
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01da: Expected O, but got Unknown
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Expected O, but got Unknown
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fd: Expected O, but got Unknown
		//IL_0294: Expected I, but got O
		//IL_0266: Expected I, but got O
		bool flag = minimumLength < 0;
		bool flag2 = minimumLength == 0;
		if (!flag)
		{
			if (!flag2)
			{
				object obj = minimumLength - 1;
				object obj2 = obj >> 1;
				object obj3 = obj | obj2;
				object obj4 = obj3 >> 2;
				object obj5 = obj3 | obj4;
				object obj6 = obj5 >> 4;
				object obj7 = obj5 | obj6;
				object obj8 = obj7 >> 8;
				object obj9 = obj7 | obj8;
				object obj10 = obj9 >> 16;
				object obj11 = obj10 | obj9;
				object obj12 = obj11 + 1;
				if ((nint)obj12 < 8)
				{
					obj12 = 8;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18055F130");
				object obj13 = default(object);
				if ((nint)obj13 != -1)
				{
					string className = ((Exception)this)._className;
					bool flag3 = ((Exception)this)._className == null;
					ArgumentOutOfRangeException ex = (ArgumentOutOfRangeException)(object)this;
					if (flag3)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v348 @ rdx_v15 (System.String)+18]");
					nint num;
					if ((nint)obj13 >= 0)
					{
						num = (nint)this;
						throw new IndexOutOfRangeException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v348 @ rdx_v15 (System.String)+20+v166 @ rax_v57*8]");
					object obj14 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v344 @ stack_8_v9+18]");
					object obj15 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v344 @ stack_8_v9+18]");
					bool flag4 = (nint)0 == 0;
					ex = (ArgumentOutOfRangeException)(object)this;
					if (flag4)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v362 @ rsi_v10+18]");
					object obj16 = default(object);
					bool flag5 = (nint)obj16 >= 0;
					num = (nint)typeof(SpinLock);
					if (flag5)
					{
						throw new IndexOutOfRangeException();
					}
					object obj17 = obj16 + 8;
					object obj18 = obj17 * 4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v344 @ stack_8_v9+18]");
					SpinLock spinLock = (SpinLock)(0 + obj18);
					bool lockTaken = default(bool);
					((SpinLock*)spinLock)->Enter(ref lockTaken);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v348 @ rdx_v15 (System.String)+20+v166 @ rax_v57*8]");
					if ((nint)0 == 0)
					{
						ex = (ArgumentOutOfRangeException)spinLock;
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v389 @ rbx_v17+20]");
					if ((nint)0 != 0)
					{
						nint num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1835CEE50");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1835C42E0");
						num = unchecked((nint)null);
						T[] result = default(T[]);
						return result;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1835C42E0");
					num = unchecked((nint)null);
				}
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_array_new_specific\"");
				T[] result2 = default(T[]);
				return result2;
			}
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rcx_v20 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.ArrayPool`1>)+30]");
			object obj19 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rax_v40+B8]");
			return (T[])0;
		}
		ArgumentOutOfRangeException ex2 = new ArgumentOutOfRangeException("minimumLength");
		throw ex2;
	}

	public unsafe void Return(T[] array, bool clearArray = false)
	{
		//IL_00b8: Expected O, but got I
		//IL_00d7: Expected O, but got I
		//IL_0111: Expected I, but got O
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Expected O, but got Unknown
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Expected O, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Expected O, but got Unknown
		//IL_01e6: Expected O, but got I4
		//IL_01c9: Expected I, but got O
		if (array == null || array.Length == 0)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18055F130");
		IntPtr intPtr = default(IntPtr);
		if (intPtr != (IntPtr)(-1))
		{
			bool flag = !clearArray;
			IntPtr intPtr2 = intPtr;
			if (!flag)
			{
				Array.Clear(array, 0, array.Length);
				intPtr2 = intPtr;
			}
			MinimumQueue<T[]>[] array2 = buckets;
			MinimumQueue<T[]> minimumQueue = array2[(nint)intPtr2];
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ stack_8_v9+18]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ stack_8_v9+18]");
			bool flag2 = (nint)0 == 0;
			SpinLock spinLock = (SpinLock)(nint)intPtr2;
			if (flag2)
			{
				throw new NullReferenceException();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ rsi_v9+18]");
			object obj2 = default(object);
			bool flag3 = (nint)obj2 >= 0;
			nint num = (nint)typeof(SpinLock);
			if (flag3)
			{
				throw new IndexOutOfRangeException();
			}
			object obj3 = obj2 + 8;
			object obj4 = obj3 * 4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ stack_8_v9+18]");
			spinLock = (SpinLock)(0 + obj4);
			bool lockTaken = default(bool);
			((SpinLock*)spinLock)->Enter(ref lockTaken);
			if (array2[(nint)intPtr2] == null)
			{
				throw new NullReferenceException();
			}
			if (minimumQueue.size <= 50)
			{
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1835CEEE0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1835C42E0");
				num = unchecked((nint)null);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1835C42E0");
				spinLock = (SpinLock)0;
			}
		}
	}

	private static int CalculateSize(int size)
	{
		//IL_000e: Expected O, but got I4
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected I4, but got Unknown
		object obj = size - 1;
		object obj2 = obj >> 1;
		object obj3 = obj | obj2;
		object obj4 = obj3 >> 2;
		object obj5 = obj3 | obj4;
		object obj6 = obj5 >> 4;
		object obj7 = obj5 | obj6;
		object obj8 = obj7 >> 8;
		object obj9 = obj7 | obj8;
		object obj10 = obj9 >> 16;
		object obj11 = obj10 | obj9;
		int num = obj11 + 1;
		if (num < 8)
		{
			num = 8;
		}
		return num;
	}

	private static int GetQueueIndex(int size)
	{
		//IL_038f: Expected I4, but got I8
		//IL_034a: Expected I4, but got I8
		if (size > 2048)
		{
			switch (size)
			{
			case 262144:
				return 15;
			case 524288:
				return 16;
			case 1048576:
				return 17;
			case 65536:
				return 13;
			case 131072:
				return 14;
			case 16384:
				return 11;
			case 32768:
				return 12;
			case 4096:
				return 9;
			case 8192:
				return 10;
			}
		}
		else if (size > 64)
		{
			switch (size)
			{
			case 512:
				return 6;
			case 1024:
				return 7;
			case 2048:
				return 8;
			case 128:
				return 4;
			case 256:
				return 5;
			}
		}
		else
		{
			if (size <= 16)
			{
				if (size == 8)
				{
					return 0;
				}
				bool flag = size != 16;
				int result = -1;
				if (!flag)
				{
					result = 1;
				}
				return result;
			}
			switch (size)
			{
			case 32:
				return 2;
			case 64:
				return 3;
			}
		}
		return -1;
	}

	static ArrayPool()
	{
		//IL_0035: Expected O, but got I
		//IL_004a: Expected O, but got I
		//IL_00a6: Expected O, but got I
		//IL_00bb: Expected O, but got I
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_array_new_specific\"");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v9 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.ArrayPool`1>)+30]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rax_v11+B8]");
		object obj2 = 0;
		object obj3 = default(object);
		obj2 = obj3;
		nint num3 = 0;
		object obj4 = null;
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1835C3D30");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ rax_v30 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.ArrayPool`1>)+30]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ rax_v32+B8]");
		object obj6 = 0;
	}
}
