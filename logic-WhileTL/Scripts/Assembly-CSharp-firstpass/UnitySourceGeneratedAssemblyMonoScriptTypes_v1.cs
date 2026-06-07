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
			FilePathsData = new byte[44]
			{
				0, 0, 0, 1, 0, 0, 0, 36, 92, 65,
				115, 115, 101, 116, 115, 92, 80, 108, 117, 103,
				105, 110, 115, 92, 71, 79, 71, 71, 97, 108,
				97, 120, 121, 92, 72, 101, 108, 112, 101, 114,
				115, 46, 99, 115
			},
			TypesData = new byte[21]
			{
				0, 0, 0, 0, 16, 72, 101, 108, 112, 101,
				114, 115, 124, 76, 105, 115, 116, 101, 110, 101,
				114
			},
			TotalFiles = 1,
			TotalTypes = 1,
			IsEditorOnly = false
		};
	}
}
