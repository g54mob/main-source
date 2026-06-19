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
			FilePathsData = new byte[60]
			{
				0, 0, 0, 1, 0, 0, 0, 52, 92, 65,
				115, 115, 101, 116, 115, 92, 83, 99, 114, 105,
				112, 116, 115, 92, 79, 116, 104, 101, 114, 92,
				90, 105, 112, 83, 97, 118, 101, 70, 111, 108,
				100, 101, 114, 92, 90, 105, 112, 83, 97, 118,
				101, 70, 111, 108, 100, 101, 114, 46, 99, 115
			},
			TypesData = new byte[19]
			{
				0, 0, 0, 0, 14, 124, 90, 105, 112, 83,
				97, 118, 101, 70, 111, 108, 100, 101, 114
			},
			TotalFiles = 1,
			TotalTypes = 1,
			IsEditorOnly = false
		};
	}
}
