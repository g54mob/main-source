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
			FilePathsData = new byte[48]
			{
				0, 0, 0, 1, 0, 0, 0, 40, 92, 65,
				115, 115, 101, 116, 115, 92, 84, 104, 105, 114,
				100, 80, 97, 114, 116, 121, 92, 87, 101, 98,
				67, 111, 114, 101, 92, 85, 110, 105, 116, 66,
				101, 122, 105, 101, 114, 46, 99, 115
			},
			TypesData = new byte[16]
			{
				0, 0, 0, 0, 11, 124, 85, 110, 105, 116,
				66, 101, 122, 105, 101, 114
			},
			TotalFiles = 1,
			TotalTypes = 1,
			IsEditorOnly = false
		};
	}
}
