using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;

namespace Cysharp.Threading.Tasks.Internal;

internal class MinimumQueue<T>
{
	private const int MinimumGrow = 4;

	private const int GrowFactor = 200;

	private T[] array;

	private int head;

	private int tail;

	private int size;

	public int Count
	{
		[MethodImpl((MethodImplOptions)256)]
		get
		{
			return size;
		}
	}

	public MinimumQueue(int capacity)
	{
		if (capacity >= 0)
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_array_new_specific\"");
			T[] array = default(T[]);
			this.array = array;
			tail = 0;
			head = 0;
			return;
		}
		ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException("capacity");
		throw ex;
	}

	public T Peek()
	{
		if (size != 0)
		{
			T[] array = this.array;
			if (this.array != null)
			{
				int num = head;
				return array[num];
			}
			return (T)new NullReferenceException();
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002B70");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180563730");
		throw new IndexOutOfRangeException();
	}

	[MethodImpl((MethodImplOptions)256)]
	public void Enqueue(T item)
	{
		T[] array = this.array;
		if (size == array.Length)
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1839784B0");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		T[] array2 = this.array;
		int num2 = tail + 1;
		bool flag = num2 == array2.Length;
		int num3 = 0;
		if (!flag)
		{
			num3 = num2;
		}
		tail = num3;
		int num4 = size + 1;
		size = num4;
	}

	[MethodImpl((MethodImplOptions)256)]
	public T Dequeue()
	{
		if (size != 0)
		{
			int num = head;
			T[] array = this.array;
			if (this.array != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				T[] array2 = this.array;
				int num2 = head + 1;
				if (this.array != null)
				{
					bool flag = num2 == array2.Length;
					int num3 = 0;
					if (!flag)
					{
						num3 = num2;
					}
					head = num3;
					int num4 = size - 1;
					size = num4;
					return array[num];
				}
			}
			return (T)new NullReferenceException();
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002B70");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180563730");
		throw new IndexOutOfRangeException();
	}

	private void Grow()
	{
		//IL_002a: Expected O, but got I4
		//IL_003a: Expected O, but got I4
		//IL_0198: Expected O, but got I
		//IL_01a8: Expected O, but got I
		//IL_01b8: Expected O, but got I
		//IL_0069: Expected O, but got I4
		T[] array = this.array;
		T[] array2 = this.array;
		object obj = array.Length + array.Length;
		object obj2 = array2.Length + 4;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
		{
			obj = array2.Length + 4;
		}
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rcx_v2 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.MinimumQueue`1>)+38]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rax_v5+20]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rcx_v3+C0]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_array_new_specific\"");
		Array destinationArray = default(Array);
		if (size > 0)
		{
			int length = default(int);
			int destinationIndex;
			Array sourceArray;
			int sourceIndex;
			if (head >= tail)
			{
				Array.Copy(this.array, head, destinationArray, 0, length);
				T[] array3 = this.array;
				destinationIndex = array3.Length - head;
				sourceArray = this.array;
				sourceIndex = 0;
			}
			else
			{
				sourceIndex = head;
				destinationIndex = 0;
				sourceArray = this.array;
			}
			Array.Copy(sourceArray, sourceIndex, destinationArray, destinationIndex, length);
		}
		this.array = (T[])destinationArray;
		head = 0;
		bool flag = size == (nint)obj;
		int num2 = 0;
		if (!flag)
		{
			num2 = size;
		}
		tail = num2;
	}

	private void SetCapacity(int capacity)
	{
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_array_new_specific\"");
		Array destinationArray = default(Array);
		if (size > 0)
		{
			int length = default(int);
			int destinationIndex;
			Array sourceArray;
			int sourceIndex;
			if (head >= tail)
			{
				Array.Copy(this.array, head, destinationArray, 0, length);
				T[] array = this.array;
				destinationIndex = array.Length - head;
				sourceArray = this.array;
				sourceIndex = 0;
			}
			else
			{
				sourceIndex = head;
				destinationIndex = 0;
				sourceArray = this.array;
			}
			Array.Copy(sourceArray, sourceIndex, destinationArray, destinationIndex, length);
		}
		this.array = (T[])destinationArray;
		head = 0;
		bool flag = size == capacity;
		int num2 = 0;
		if (!flag)
		{
			num2 = size;
		}
		tail = num2;
	}

	[MethodImpl((MethodImplOptions)256)]
	private unsafe void MoveNext(ref int index)
	{
		//IL_001d: Expected O, but got I4
		//IL_003b: Expected O, but got I4
		T[] array = this.array;
		object obj = index + 1;
		bool flag = (nint)obj == array.Length;
		object obj2 = 0;
		if (!flag)
		{
			obj2 = obj;
		}
		ref int reference = ref *(int*)obj2;
	}

	private void ThrowForEmptyQueue()
	{
		object obj = new InvalidOperationException();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184E209C0");
		throw obj;
	}
}
