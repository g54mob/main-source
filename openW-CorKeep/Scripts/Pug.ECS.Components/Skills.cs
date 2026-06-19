using Unity.Collections.LowLevel.Unsafe;

public struct Skills
{
	public int mining;

	public int running;

	public int melee;

	public int vitality;

	public int crafting;

	public int range;

	public int gardening;

	public int fishing;

	public int cooking;

	public int magic;

	public int summoning;

	public static int Length => UnsafeUtility.SizeOf<Skills>() / UnsafeUtility.SizeOf<int>();

	public unsafe int Get(int index)
	{
		int* ptr = (int*)UnsafeUtility.AddressOf(ref mining);
		UnsafeUtility.CopyPtrToStructure<int>(ptr + index, out var output);
		return output;
	}

	public unsafe void Set(int index, int value)
	{
		int* ptr = (int*)UnsafeUtility.AddressOf(ref mining);
		UnsafeUtility.CopyStructureToPtr(ref value, ptr + index);
	}
}
