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
			FilePathsData = new byte[37]
			{
				0, 0, 0, 1, 0, 0, 0, 29, 92, 65,
				115, 115, 101, 116, 115, 92, 67, 111, 108, 111,
				117, 114, 87, 105, 100, 103, 101, 116, 82, 97,
				100, 105, 97, 108, 46, 99, 115
			},
			TypesData = new byte[24]
			{
				0, 0, 0, 0, 19, 124, 67, 111, 108, 111,
				117, 114, 87, 105, 100, 103, 101, 116, 82, 97,
				100, 105, 97, 108
			},
			TotalFiles = 1,
			TotalTypes = 1,
			IsEditorOnly = false
		};
	}
}
