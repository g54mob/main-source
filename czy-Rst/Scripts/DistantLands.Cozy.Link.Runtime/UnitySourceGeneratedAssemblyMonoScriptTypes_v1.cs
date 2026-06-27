using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Runtime.CompilerServices;

[EditorBrowsable(EditorBrowsableState.Never)]
[GeneratedCode("Unity.MonoScriptGenerator.MonoScriptInfoGenerator", null)]
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

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static MonoScriptData Get()
	{
		return new MonoScriptData
		{
			FilePathsData = new byte[66]
			{
				0, 0, 0, 1, 0, 0, 0, 58, 92, 80,
				97, 99, 107, 97, 103, 101, 115, 92, 99, 111,
				109, 46, 100, 105, 115, 116, 97, 110, 116, 108,
				97, 110, 100, 115, 46, 99, 111, 122, 121, 46,
				108, 105, 110, 107, 92, 82, 117, 110, 116, 105,
				109, 101, 92, 76, 105, 110, 107, 77, 111, 100,
				117, 108, 101, 46, 99, 115
			},
			TypesData = new byte[33]
			{
				0, 0, 0, 0, 28, 68, 105, 115, 116, 97,
				110, 116, 76, 97, 110, 100, 115, 46, 67, 111,
				122, 121, 124, 76, 105, 110, 107, 77, 111, 100,
				117, 108, 101
			},
			TotalFiles = 1,
			TotalTypes = 1,
			IsEditorOnly = false
		};
	}
}
