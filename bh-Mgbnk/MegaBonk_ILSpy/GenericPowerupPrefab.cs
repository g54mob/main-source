using Assets.Scripts.Inventory__Items__Pickups.Pickups;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

public class GenericPowerupPrefab : MonoBehaviour
{
	public Pickup pickup;

	public ParticleSystem ps;

	public MeshRenderer minimapRenderer;

	public MeshRenderer iconRenderer;

	public Material hpMaterial;

	public Material nukeMaterial;

	public Material timeFreezeMaterial;

	public Material shieldMaterial;

	public Material rageMaterial;

	public Material hasteMaterial;

	public Material stonksMaterial;

	public Material magnetMaterial;

	private MaterialPropertyBlock propertyBlock;

	private void TryInit()
	{
		if (propertyBlock == null)
		{
			MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
			propertyBlock = materialPropertyBlock;
			((Renderer)iconRenderer).Internal_GetPropertyBlock(propertyBlock);
		}
	}

	public unsafe void Set(EPickup ePickup)
	{
		//IL_007b: Expected O, but got Ref
		//IL_0089: Expected O, but got I4
		//IL_00b4: Expected O, but got I4
		//IL_00c1: Expected O, but got I8
		//IL_00db: Expected O, but got I8
		if (propertyBlock == null)
		{
			MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
			propertyBlock = materialPropertyBlock;
			((Renderer)iconRenderer).Internal_GetPropertyBlock(propertyBlock);
		}
		Pickup pickup = this.pickup;
		pickup.ePickup = ePickup;
		Color color = MyColorUtility.PickupToColor(ePickup);
		object obj = default(object);
		ps.startColor = (Color)(&obj);
		object obj2 = ePickup - 2;
		if ((nint)obj2 <= 7)
		{
			object obj3 = ePickup - 2;
			object obj4 = 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ rdx_v10+4C4DB8+v272 @ rax_v16*4]");
			object obj5 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v240 @ rax_v18 (should have been resolved before IL gen)");
		}
		((Renderer)minimapRenderer).SetMaterial((Material)null);
		Material material = ((Renderer)minimapRenderer).GetMaterial();
		Texture mainTexture = material.mainTexture;
		propertyBlock.SetTexture("_MainTex", mainTexture);
		((Renderer)iconRenderer).Internal_SetPropertyBlock(propertyBlock);
	}

	private Material GetMinimapMaterial(EPickup ePickup)
	{
		//IL_000e: Expected O, but got I4
		//IL_0039: Expected O, but got I4
		//IL_0046: Expected O, but got I8
		//IL_0060: Expected O, but got I8
		object obj = ePickup - 2;
		if ((nint)obj <= 7)
		{
			object obj2 = ePickup - 2;
			object obj3 = 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ r8_v1+4C4BC0+v15 @ rax_v3*4]");
			object obj4 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v19 @ rax_v5 (should have been resolved before IL gen)");
		}
		return null;
	}
}
