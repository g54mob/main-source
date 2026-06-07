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
			FilePathsData = new byte[39]
			{
				0, 0, 0, 1, 0, 0, 0, 31, 92, 65,
				115, 115, 101, 116, 115, 92, 83, 111, 107, 112,
				111, 112, 73, 110, 116, 114, 111, 92, 83, 111,
				107, 73, 110, 116, 114, 111, 46, 99, 115
			},
			TypesData = new byte[20]
			{
				0, 0, 0, 0, 15, 83, 111, 107, 112, 111,
				112, 124, 83, 111, 107, 73, 110, 116, 114, 111
			},
			TotalFiles = 1,
			TotalTypes = 1,
			IsEditorOnly = false
		};
	}
}
