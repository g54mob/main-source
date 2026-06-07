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
			FilePathsData = new byte[81]
			{
				0, 0, 0, 1, 0, 0, 0, 73, 92, 65,
				115, 115, 101, 116, 115, 92, 82, 101, 119, 105,
				114, 101, 100, 92, 73, 110, 116, 101, 114, 110,
				97, 108, 92, 83, 99, 114, 105, 112, 116, 115,
				92, 80, 108, 97, 116, 102, 111, 114, 109, 115,
				92, 87, 105, 110, 100, 111, 119, 115, 92, 70,
				117, 110, 99, 116, 105, 111, 110, 115, 92, 70,
				117, 110, 99, 116, 105, 111, 110, 115, 46, 99,
				115
			},
			TypesData = new byte[39]
			{
				0, 0, 0, 0, 34, 82, 101, 119, 105, 114,
				101, 100, 46, 73, 110, 116, 101, 114, 110, 97,
				108, 46, 87, 105, 110, 100, 111, 119, 115, 124,
				70, 117, 110, 99, 116, 105, 111, 110, 115
			},
			TotalFiles = 1,
			TotalTypes = 1,
			IsEditorOnly = false
		};
	}
}
