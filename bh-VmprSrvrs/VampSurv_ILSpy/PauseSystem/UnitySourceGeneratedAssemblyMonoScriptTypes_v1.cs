using System.Runtime.CompilerServices;

internal class UnitySourceGeneratedAssemblyMonoScriptTypes_v1
{
	private struct MonoScriptData
	{
		public byte[] FilePathsData;

		public byte[] TypesData;

		public int TotalTypes;

		public int TotalFiles;

		public bool IsEditorOnly;
	}

	[MethodImpl((MethodImplOptions)256)]
	private unsafe static MonoScriptData Get()
	{
		//IL_006c: Expected native int or pointer, but got O
		//IL_007a: Expected native int or pointer, but got O
		//IL_00a3: Expected native int or pointer, but got O
		//IL_002e: Expected native int or pointer, but got O
		//IL_0041: Expected native int or pointer, but got O
		//IL_004f: Expected native int or pointer, but got O
		//IL_005d: Expected native int or pointer, but got O
		MonoScriptData monoScriptData = default(MonoScriptData);
		System.Runtime.CompilerServices.Unsafe.Write(&((MonoScriptData*)(nint)monoScriptData)->FilePathsData, null);
		((MonoScriptData*)(nint)monoScriptData)->TotalTypes = 0;
		System.Runtime.CompilerServices.Unsafe.Write(&((MonoScriptData*)(nint)monoScriptData)->FilePathsData, new byte[214]
		{
			0, 0, 0, 1, 0, 0, 0, 48, 92, 65,
			115, 115, 101, 116, 115, 92, 80, 108, 117, 103,
			105, 110, 115, 92, 80, 97, 117, 115, 101, 83,
			121, 115, 116, 101, 109, 92, 71, 97, 109, 101,
			77, 111, 110, 111, 66, 101, 104, 97, 118, 105,
			111, 117, 114, 46, 99, 115, 0, 0, 0, 1,
			0, 0, 0, 49, 92, 65, 115, 115, 101, 116,
			115, 92, 80, 108, 117, 103, 105, 110, 115, 92,
			80, 97, 117, 115, 101, 83, 121, 115, 116, 101,
			109, 92, 71, 97, 109, 101, 80, 101, 114, 102,
			70, 105, 120, 77, 97, 110, 97, 103, 101, 114,
			46, 99, 115, 0, 0, 0, 1, 0, 0, 0,
			43, 92, 65, 115, 115, 101, 116, 115, 92, 80,
			108, 117, 103, 105, 110, 115, 92, 80, 97, 117,
			115, 101, 83, 121, 115, 116, 101, 109, 92, 71,
			97, 109, 101, 84, 105, 99, 107, 97, 98, 108,
			101, 46, 99, 115, 0, 0, 0, 1, 0, 0,
			0, 42, 92, 65, 115, 115, 101, 116, 115, 92,
			80, 108, 117, 103, 105, 110, 115, 92, 80, 97,
			117, 115, 101, 83, 121, 115, 116, 101, 109, 92,
			80, 97, 117, 115, 101, 83, 121, 115, 116, 101,
			109, 46, 99, 115
		});
		System.Runtime.CompilerServices.Unsafe.Write(&((MonoScriptData*)(nint)monoScriptData)->TypesData, new byte[101]
		{
			0, 0, 0, 0, 18, 124, 71, 97, 109, 101,
			77, 111, 110, 111, 66, 101, 104, 97, 118, 105,
			111, 117, 114, 0, 0, 0, 0, 38, 80, 108,
			117, 103, 105, 110, 115, 46, 80, 97, 117, 115,
			101, 83, 121, 115, 116, 101, 109, 124, 71, 97,
			109, 101, 80, 101, 114, 102, 70, 105, 120, 77,
			97, 110, 97, 103, 101, 114, 0, 0, 0, 0,
			13, 124, 71, 97, 109, 101, 84, 105, 99, 107,
			97, 98, 108, 101, 0, 0, 0, 0, 12, 124,
			80, 97, 117, 115, 101, 83, 121, 115, 116, 101,
			109
		});
		((MonoScriptData*)(nint)monoScriptData)->TotalFiles = 4;
		((MonoScriptData*)(nint)monoScriptData)->TotalTypes = 4;
		((MonoScriptData*)(nint)monoScriptData)->IsEditorOnly = false;
		return monoScriptData;
	}
}
