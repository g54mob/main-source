using Assets.Scripts.MapGeneration;
using Cpp2ILInjected;
using UnityEngine;

public class MinimapMesh : MonoBehaviour
{
	public MeshRenderer meshRenderer;

	public MeshFilter meshFilter;

	public void Set(Mesh mesh, Color fogColor)
	{
		//IL_0049: Expected I, but got O
		//IL_0078: Expected F4, but got I
		//IL_0086: Expected I, but got O
		//IL_00b0: Expected F4, but got I
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: true);
		meshFilter.sharedMesh = mesh;
		Material sharedMaterial = ((Renderer)meshRenderer).GetSharedMaterial();
		nint num = (nint)typeof(MapInfo);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rcx_v8 (Il2CppClass<Assets.Scripts.MapGeneration.MapInfo>)+B8]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rcx_v9 (Il2CppStaticFields<Assets.Scripts.MapGeneration.MapInfo>)+4]");
		sharedMaterial.SetFloat("_MinDistance", 0f);
		nint num3 = (nint)typeof(MapInfo);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rax_v10 (Il2CppClass<Assets.Scripts.MapGeneration.MapInfo>)+B8]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rcx_v11 (Il2CppStaticFields<Assets.Scripts.MapGeneration.MapInfo>)+10]");
		sharedMaterial.SetFloat("_MaxDistance", 0f);
	}

	private unsafe Color GetSaturatedColor(Color color)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Expected Ref, but got Unknown
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected Ref, but got Unknown
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected Ref, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		//IL_009b: Expected native int or pointer, but got O
		_ = 0;
		object obj = default(object);
		ref float v = ref *(float*)(obj + 24);
		_ = 0;
		ref float s = ref *(float*)(obj + 8);
		_ = color.r;
		ref float h = ref *(float*)(obj - 40);
		_ = 0;
		Color rgbColor = (Color)(obj - 24);
		_ = 0;
		Color.RGBToHSV(rgbColor, out h, out s, out v);
		Color color2 = default(Color);
		float h2 = default(float);
		float v2 = default(float);
		bool hdr = default(bool);
		((Color*)(nint)color2)->r = Color.HSVToRGB(h2, 1f, v2, hdr).r;
		return color2;
	}
}
