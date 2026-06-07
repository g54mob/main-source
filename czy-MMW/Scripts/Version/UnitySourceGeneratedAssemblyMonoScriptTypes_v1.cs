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
				115, 115, 101, 116, 115, 92, 82, 101, 115, 111,
				117, 114, 99, 101, 115, 92, 83, 99, 114, 105,
				112, 116, 115, 92, 86, 101, 114, 115, 105, 111,
				110, 46, 99, 115
			},
			TypesData = new byte[13]
			{
				0, 0, 0, 0, 8, 124, 86, 101, 114, 115,
				105, 111, 110
			},
			TotalFiles = 1,
			TotalTypes = 1,
			IsEditorOnly = false
		};
	}
}
