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
		System.Runtime.CompilerServices.Unsafe.Write(&((MonoScriptData*)(nint)monoScriptData)->FilePathsData, new byte[83]
		{
			0, 0, 0, 1, 0, 0, 0, 75, 92, 65,
			115, 115, 101, 116, 115, 92, 65, 112, 112, 92,
			83, 99, 114, 105, 112, 116, 115, 92, 85, 73,
			92, 66, 101, 97, 114, 100, 121, 71, 114, 105,
			100, 76, 97, 121, 111, 117, 116, 71, 114, 111,
			117, 112, 92, 115, 114, 99, 92, 82, 117, 110,
			116, 105, 109, 101, 92, 71, 114, 105, 100, 76,
			97, 121, 111, 117, 116, 71, 114, 111, 117, 112,
			46, 99, 115
		});
		System.Runtime.CompilerServices.Unsafe.Write(&((MonoScriptData*)(nint)monoScriptData)->TypesData, new byte[27]
		{
			0, 0, 0, 0, 22, 66, 101, 97, 114, 100,
			121, 124, 71, 114, 105, 100, 76, 97, 121, 111,
			117, 116, 71, 114, 111, 117, 112
		});
		((MonoScriptData*)(nint)monoScriptData)->TotalFiles = 1;
		((MonoScriptData*)(nint)monoScriptData)->TotalTypes = 1;
		((MonoScriptData*)(nint)monoScriptData)->IsEditorOnly = false;
		return monoScriptData;
	}
}
