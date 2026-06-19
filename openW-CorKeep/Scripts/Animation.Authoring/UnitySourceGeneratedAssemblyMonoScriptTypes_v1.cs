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
			FilePathsData = new byte[65]
			{
				0, 0, 0, 1, 0, 0, 0, 57, 92, 65,
				115, 115, 101, 116, 115, 92, 83, 99, 114, 105,
				112, 116, 115, 92, 65, 110, 105, 109, 97, 116,
				105, 111, 110, 92, 65, 117, 116, 104, 111, 114,
				105, 110, 103, 92, 65, 110, 105, 109, 97, 116,
				105, 111, 110, 65, 117, 116, 104, 111, 114, 105,
				110, 103, 46, 99, 115
			},
			TypesData = new byte[24]
			{
				0, 0, 0, 0, 19, 124, 65, 110, 105, 109,
				97, 116, 105, 111, 110, 65, 117, 116, 104, 111,
				114, 105, 110, 103
			},
			TotalFiles = 1,
			TotalTypes = 1,
			IsEditorOnly = false
		};
	}
}
