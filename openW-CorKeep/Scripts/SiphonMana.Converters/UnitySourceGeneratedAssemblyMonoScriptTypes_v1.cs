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
			FilePathsData = new byte[68]
			{
				0, 0, 0, 1, 0, 0, 0, 60, 92, 65,
				115, 115, 101, 116, 115, 92, 83, 99, 114, 105,
				112, 116, 115, 92, 83, 105, 112, 104, 111, 110,
				77, 97, 110, 97, 92, 67, 111, 110, 118, 101,
				114, 116, 101, 114, 115, 92, 83, 105, 112, 104,
				111, 110, 77, 97, 110, 97, 67, 111, 110, 118,
				101, 114, 116, 101, 114, 46, 99, 115
			},
			TypesData = new byte[25]
			{
				0, 0, 0, 0, 20, 124, 83, 105, 112, 104,
				111, 110, 77, 97, 110, 97, 67, 111, 110, 118,
				101, 114, 116, 101, 114
			},
			TotalFiles = 1,
			TotalTypes = 1,
			IsEditorOnly = false
		};
	}
}
