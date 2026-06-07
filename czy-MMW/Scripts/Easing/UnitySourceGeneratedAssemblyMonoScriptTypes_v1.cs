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
			FilePathsData = new byte[43]
			{
				0, 0, 0, 1, 0, 0, 0, 35, 92, 65,
				115, 115, 101, 116, 115, 92, 84, 104, 105, 114,
				100, 80, 97, 114, 116, 121, 92, 69, 97, 115,
				105, 110, 103, 92, 69, 97, 115, 105, 110, 103,
				46, 99, 115
			},
			TypesData = new byte[19]
			{
				0, 0, 0, 0, 14, 69, 97, 115, 105, 110,
				103, 124, 69, 97, 115, 105, 110, 103, 115
			},
			TotalFiles = 1,
			TotalTypes = 1,
			IsEditorOnly = false
		};
	}
}
