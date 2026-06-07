using System.Collections.Generic;
using UnityEngine;

public class ObjectMaterialControl : MonoBehaviour
{
	public enum eMaterialType
	{
		ORIGINAL = 0,
		PLACEMENT_MODE = 1,
		DISABLED = 2
	}

	[SerializeField]
	[Header("控制的Renderer清單")]
	private List<Renderer> list_Renderers;

	[Header("Renderer的原始材質")]
	[SerializeField]
	private List<Material> list_OriginalMaterials;

	[Header("建造模式時要顯示的材質")]
	[SerializeField]
	private Material material_PlacementMode;

	[SerializeField]
	[Header("不可使用時要顯示的材質")]
	private Material material_Disabled;

	private eMaterialType curMaterialType;

	private OutlineController.eOutlineType lastOutlineType;

	public void Initialize(Transform targetObject)
	{
	}

	private void OnDestroy()
	{
	}

	public void SwitchMaterial(eMaterialType type)
	{
	}
}
