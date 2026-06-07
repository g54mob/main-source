using System.Collections.Generic;
using UnityEngine;

public class SkinWrapper : MonoBehaviour
{
	[Header("Player Reference")]
	public GamePlayer gamePlayer;

	[Header("Customization References")]
	public List<SkinnedMeshRenderer> headRef;

	public List<SkinnedMeshRenderer> topRef;

	public List<SkinnedMeshRenderer> bottomRef;

	public List<SkinnedMeshRenderer> helmetRef;

	public List<SkinnedMeshRenderer> beltRef;

	public List<SkinnedMeshRenderer> bootsRef;

	public List<SkinnedMeshRenderer> highBootsRef;

	public List<SkinnedMeshRenderer> openGlovesRef;

	public List<SkinnedMeshRenderer> closeGlovesRef;

	[Header("Clothing Materials")]
	[Tooltip("Her top index'i için kullanılabilir materyaller")]
	public List<ClothingMaterialEntry> topMaterials;

	[Tooltip("Her bottom/highBoots index'i için kullanılabilir materyaller (ortak matID)")]
	public List<ClothingMaterialEntry> bottomMaterials;

	[Tooltip("Her gloves index'i için kullanılabilir materyaller (open/close ortak)")]
	public List<ClothingMaterialEntry> glovesMaterials;

	[Tooltip("Her helmet index'i için kullanılabilir materyaller")]
	public List<ClothingMaterialEntry> helmetMaterials;

	[Tooltip("Her boots index'i için kullanılabilir materyaller")]
	public List<ClothingMaterialEntry> bootsMaterials;

	[Header("Skin Color")]
	public Material skin1;

	public Material skin2;

	public List<SkinnedMeshRenderer> skinColorRenderers;

	private void OnEnable()
	{
		if (!(gamePlayer == null))
		{
			ApplyCustomization(gamePlayer.headID, gamePlayer.topID, gamePlayer.bottomID, gamePlayer.helmetID, gamePlayer.glovesID, gamePlayer.bootsID, gamePlayer.beltID, gamePlayer.topMatID, gamePlayer.bottomMatID, gamePlayer.glovesMatID, gamePlayer.helmetMatID, gamePlayer.bootsMatID);
		}
	}

	public void ApplyCustomization(int head, int top, int bottom, int helmet, int gloves, int boots, int belt, int topMat = 0, int bottomMat = 0, int glovesMat = 0, int helmetMat = 0, int bootsMat = 0)
	{
		EnableOnlyIndex(headRef, head);
		bool num = top >= 2;
		EnableOnlyIndex(topRef, top);
		ApplyClothingMaterial(topRef, top, topMaterials, topMat);
		if (boots == 3)
		{
			DisableAll(bottomRef);
			DisableAll(bootsRef);
			EnableOnlyIndex(highBootsRef, bottom);
			int materialSlot = ((bottom == 0) ? 1 : 0);
			ApplyClothingMaterial(highBootsRef, bottom, bottomMaterials, bottomMat, materialSlot);
		}
		else
		{
			DisableAll(highBootsRef);
			EnableOnlyIndex(bottomRef, bottom);
			ApplyClothingMaterial(bottomRef, bottom, bottomMaterials, bottomMat);
			EnableOnlyIndex(bootsRef, boots);
			ApplyClothingMaterial(bootsRef, boots, bootsMaterials, bootsMat);
		}
		EnableOnlyIndex(helmetRef, helmet);
		ApplyClothingMaterial(helmetRef, helmet, helmetMaterials, helmetMat);
		EnableOnlyIndex(beltRef, belt);
		if (num)
		{
			DisableAll(closeGlovesRef);
			EnableOnlyIndex(openGlovesRef, gloves);
			if (gloves != 1)
			{
				ApplyClothingMaterial(openGlovesRef, gloves, glovesMaterials, glovesMat, 1);
			}
		}
		else
		{
			DisableAll(openGlovesRef);
			EnableOnlyIndex(closeGlovesRef, gloves);
			ApplyClothingMaterial(closeGlovesRef, gloves, glovesMaterials, glovesMat);
		}
		Material material = ((head == 0) ? skin2 : skin1);
		ApplySkinColor(material);
		if (!num || gloves != 1 || openGlovesRef == null || gloves >= openGlovesRef.Count)
		{
			return;
		}
		SkinnedMeshRenderer skinnedMeshRenderer = openGlovesRef[1];
		if (!(skinnedMeshRenderer != null))
		{
			return;
		}
		Material[] materials = skinnedMeshRenderer.materials;
		if (materials.Length < 2)
		{
			return;
		}
		materials[1] = material;
		if (glovesMaterials != null && 1 < glovesMaterials.Count)
		{
			ClothingMaterialEntry clothingMaterialEntry = glovesMaterials[1];
			if (clothingMaterialEntry?.materials != null && clothingMaterialEntry.materials.Count > 0)
			{
				int index = Mathf.Clamp(glovesMat, 0, clothingMaterialEntry.materials.Count - 1);
				if (clothingMaterialEntry.materials[index] != null)
				{
					materials[0] = clothingMaterialEntry.materials[index];
				}
			}
		}
		skinnedMeshRenderer.materials = materials;
	}

	private void ApplyClothingMaterial(List<SkinnedMeshRenderer> renderers, int meshIndex, List<ClothingMaterialEntry> entries, int matIndex, int materialSlot = 0)
	{
		if (renderers == null || entries == null || meshIndex < 0 || meshIndex >= entries.Count)
		{
			return;
		}
		ClothingMaterialEntry clothingMaterialEntry = entries[meshIndex];
		if (clothingMaterialEntry.materials == null || clothingMaterialEntry.materials.Count == 0)
		{
			return;
		}
		int index = Mathf.Clamp(matIndex, 0, clothingMaterialEntry.materials.Count - 1);
		Material material = clothingMaterialEntry.materials[index];
		if (!(material == null) && meshIndex < renderers.Count && !(renderers[meshIndex] == null))
		{
			SkinnedMeshRenderer skinnedMeshRenderer = renderers[meshIndex];
			Material[] materials = skinnedMeshRenderer.materials;
			if (materialSlot >= 0 && materialSlot < materials.Length)
			{
				materials[materialSlot] = material;
				skinnedMeshRenderer.materials = materials;
			}
		}
	}

	private void ApplySkinColor(Material skinMat)
	{
		if (skinMat == null || skinColorRenderers == null)
		{
			return;
		}
		for (int i = 0; i < skinColorRenderers.Count; i++)
		{
			SkinnedMeshRenderer skinnedMeshRenderer = skinColorRenderers[i];
			if (!(skinnedMeshRenderer == null))
			{
				skinnedMeshRenderer.material = skinMat;
			}
		}
	}

	private void EnableOnlyIndex(List<SkinnedMeshRenderer> list, int index)
	{
		if (list == null)
		{
			return;
		}
		if (index < 0)
		{
			index = 0;
		}
		for (int i = 0; i < list.Count; i++)
		{
			SkinnedMeshRenderer skinnedMeshRenderer = list[i];
			if (!(skinnedMeshRenderer == null))
			{
				bool flag = i == index;
				SafeSetRenderer(skinnedMeshRenderer, flag);
			}
		}
	}

	private void DisableAll(List<SkinnedMeshRenderer> list)
	{
		if (list == null)
		{
			return;
		}
		for (int i = 0; i < list.Count; i++)
		{
			SkinnedMeshRenderer skinnedMeshRenderer = list[i];
			if (!(skinnedMeshRenderer == null))
			{
				SafeSetRenderer(skinnedMeshRenderer, enabled: false);
			}
		}
	}

	private void SafeSetRenderer(SkinnedMeshRenderer r, bool enabled)
	{
		if (!(r == null))
		{
			r.gameObject.SetActive(enabled);
		}
	}
}
