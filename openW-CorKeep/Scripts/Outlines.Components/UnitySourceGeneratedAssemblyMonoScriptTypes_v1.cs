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
			FilePathsData = new byte[62]
			{
				0, 0, 0, 1, 0, 0, 0, 54, 92, 65,
				115, 115, 101, 116, 115, 92, 83, 99, 114, 105,
				112, 116, 115, 92, 79, 117, 116, 108, 105, 110,
				101, 115, 92, 67, 111, 109, 112, 111, 110, 101,
				110, 116, 115, 92, 86, 105, 115, 117, 97, 108,
				79, 117, 116, 108, 105, 110, 101, 67, 68, 46,
				99, 115
			},
			TypesData = new byte[40]
			{
				0, 0, 0, 0, 35, 79, 117, 116, 108, 105,
				110, 101, 115, 46, 67, 111, 109, 112, 111, 110,
				101, 110, 116, 115, 124, 86, 105, 115, 117, 97,
				108, 79, 117, 116, 108, 105, 110, 101, 67, 68
			},
			TotalFiles = 1,
			TotalTypes = 1,
			IsEditorOnly = false
		};
	}
}
