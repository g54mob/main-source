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
			FilePathsData = new byte[80]
			{
				0, 0, 0, 1, 0, 0, 0, 72, 92, 65,
				115, 115, 101, 116, 115, 92, 83, 99, 114, 105,
				112, 116, 115, 92, 67, 111, 109, 109, 97, 110,
				100, 77, 105, 110, 105, 111, 110, 92, 67, 111,
				110, 118, 101, 114, 116, 101, 114, 115, 92, 67,
				111, 109, 109, 97, 110, 100, 77, 105, 110, 105,
				111, 110, 87, 101, 97, 112, 111, 110, 67, 111,
				110, 118, 101, 114, 116, 101, 114, 46, 99, 115
			},
			TypesData = new byte[47]
			{
				0, 0, 0, 0, 42, 67, 111, 109, 109, 97,
				110, 100, 77, 105, 110, 105, 111, 110, 124, 67,
				111, 109, 109, 97, 110, 100, 77, 105, 110, 105,
				111, 110, 87, 101, 97, 112, 111, 110, 67, 111,
				110, 118, 101, 114, 116, 101, 114
			},
			TotalFiles = 1,
			TotalTypes = 1,
			IsEditorOnly = false
		};
	}
}
