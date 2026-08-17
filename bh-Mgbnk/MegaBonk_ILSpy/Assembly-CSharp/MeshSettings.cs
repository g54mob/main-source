using System;
using Cpp2ILInjected;

public class MeshSettings : UpdatableData
{
	public const int numSupportedLODs = 5;

	public const int numSupportedChunkSizes = 9;

	public const int numSupportedFlatshadedChunkSizes = 3;

	public static readonly int[] supportedChunkSizes = new int[9] { 48, 72, 96, 120, 144, 168, 192, 216, 240 };

	public float meshScale = 2.5f;

	public bool useFlatShading;

	public int chunkSizeIndex;

	public int flatshadedChunkSizeIndex;

	public int numVertsPerLine
	{
		get
		{
			//IL_00a6: Expected O, but got I4
			//IL_0023: Expected O, but got I
			//IL_000e: Expected O, but got I4
			//IL_0089: Expected I4, but got O
			bool flag = useFlatShading;
			object obj = 52;
			if (!flag)
			{
				obj = 48;
			}
			int[] array = supportedChunkSizes;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rdx_v2+this @ rcx (MeshSettings)]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rdx_v2+this @ rcx (MeshSettings)]");
			if ((nint)0 < (nint)array.Length)
			{
				return array[obj2] + 5;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			return (int)ex;
		}
	}

	public float meshWorldSize
	{
		get
		{
			//IL_0085: Expected O, but got I4
			//IL_0023: Expected O, but got I
			//IL_000e: Expected O, but got I4
			//IL_003f: Expected O, but got I4
			bool flag = useFlatShading;
			object obj = 52;
			if (!flag)
			{
				obj = 48;
			}
			int[] array = supportedChunkSizes;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rdx_v2+this @ rcx (MeshSettings)]");
			object obj2 = 0;
			object obj3 = array[obj2] + 2;
			return (float)obj3 * meshScale;
		}
	}
}
