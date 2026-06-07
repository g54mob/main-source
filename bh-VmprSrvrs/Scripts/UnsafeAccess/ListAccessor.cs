using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;

public ref struct ListAccessor<T>
{
	public List<T> list;

	public T[] array;

	public int Count
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Il2CppSetOption(/*Could not decode attribute arguments.*/)]
		get
		{
			return 0;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Il2CppSetOption(/*Could not decode attribute arguments.*/)]
		set
		{
		}
	}

	public ListAccessor(List<T> list)
	{
		this.list = null;
		array = null;
	}
}
