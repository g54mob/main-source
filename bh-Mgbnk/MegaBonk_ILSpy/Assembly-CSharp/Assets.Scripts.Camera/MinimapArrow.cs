using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.Camera;

public class MinimapArrow : MonoBehaviour
{
	public Transform target;

	public MeshRenderer arrowRenderer;

	private Material material;

	public unsafe void Set(Transform target, Color color)
	{
		//IL_0065: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172B43]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		this.target = target;
		Material material = ((Renderer)arrowRenderer).GetMaterial();
		this.material = material;
		object obj = default(object);
		this.material.SetColor("_Color", (Color)(&obj));
	}

	private void OnDestroy()
	{
		if (material != null)
		{
			Object.Destroy(material);
		}
	}
}
