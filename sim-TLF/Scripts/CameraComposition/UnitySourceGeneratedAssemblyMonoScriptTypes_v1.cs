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
			FilePathsData = new byte[64]
			{
				0, 0, 0, 1, 0, 0, 0, 56, 92, 65,
				115, 115, 101, 116, 115, 92, 67, 97, 109, 101,
				114, 97, 32, 67, 111, 109, 112, 111, 115, 105,
				116, 105, 111, 110, 92, 83, 99, 114, 105, 112,
				116, 115, 92, 67, 111, 109, 112, 111, 115, 105,
				116, 105, 111, 110, 79, 118, 101, 114, 108, 97,
				121, 46, 99, 115
			},
			TypesData = new byte[37]
			{
				0, 0, 0, 0, 32, 74, 111, 114, 100, 97,
				110, 67, 97, 115, 115, 97, 100, 121, 124, 67,
				111, 109, 112, 111, 115, 105, 116, 105, 111, 110,
				79, 118, 101, 114, 108, 97, 121
			},
			TotalFiles = 1,
			TotalTypes = 1,
			IsEditorOnly = false
		};
	}
}
