using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.MapGeneration;

public static class MapInfo
{
	public static Vector3 mapBoundsLower;

	public static Vector3 mapBoundsUpper;

	public static Vector3 mapCenter;

	public static Vector3 mapSize;

	public static float DespawnEnemyHeight()
	{
		//IL_0013: Expected I, but got O
		nint num = (nint)typeof(MapInfo);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ rax_v3 (Il2CppClass<Assets.Scripts.MapGeneration.MapInfo>)+B8]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v4 (Il2CppStaticFields<Assets.Scripts.MapGeneration.MapInfo>)+4]");
		return 0f - 10f;
	}

	static MapInfo()
	{
		//IL_0018: Expected I, but got O
		//IL_0036: Expected I, but got O
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ rax_v3 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		nint num3 = (nint)typeof(MapInfo);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v4 (Il2CppClass<Assets.Scripts.MapGeneration.MapInfo>)+B8]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rcx_v3 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
		float num5 = 0f * -100f;
		Vector3 vector = default(Vector3);
		mapBoundsLower = vector;
	}
}
