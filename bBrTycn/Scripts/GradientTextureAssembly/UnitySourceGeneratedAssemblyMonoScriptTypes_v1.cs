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
			FilePathsData = new byte[66]
			{
				0, 0, 0, 1, 0, 0, 0, 58, 92, 65,
				115, 115, 101, 116, 115, 92, 80, 108, 117, 103,
				105, 110, 115, 92, 71, 114, 97, 100, 105, 101,
				110, 116, 84, 101, 120, 116, 117, 114, 101, 92,
				82, 117, 110, 116, 105, 109, 101, 92, 71, 114,
				97, 100, 105, 101, 110, 116, 84, 101, 120, 116,
				117, 114, 101, 46, 99, 115
			},
			TypesData = new byte[62]
			{
				0, 0, 0, 0, 57, 80, 97, 99, 107, 97,
				103, 101, 115, 46, 71, 114, 97, 100, 105, 101,
				110, 116, 84, 101, 120, 116, 117, 114, 101, 71,
				101, 110, 101, 114, 97, 116, 111, 114, 46, 82,
				117, 110, 116, 105, 109, 101, 124, 71, 114, 97,
				100, 105, 101, 110, 116, 84, 101, 120, 116, 117,
				114, 101
			},
			TotalFiles = 1,
			TotalTypes = 1,
			IsEditorOnly = false
		};
	}
}
