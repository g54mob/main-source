using System;
using Aggro.Core;
using UnityEngine;

public class ModifierMaterialManager : EntityBehaviourBase, IModifierAdded
{
	[Serializable]
	public struct ModifierMaterialStyle
	{
		public ModifierArtStyle artStyle;

		public Material material;
	}

	private Material _originalMaterial;

	public ModifierMaterialStyle[] modifierMaterialStyles;

	public MeshRenderer[] meshRenderers;

	public void OnModifierAdded(ModifierBase modifier)
	{
		MeshRenderer[] array;
		if (modifier.modifierArtStyle == ModifierArtStyle.None)
		{
			array = meshRenderers;
			foreach (MeshRenderer meshRenderer in array)
			{
				for (int j = 0; j < meshRenderer.sharedMaterials.Length; j++)
				{
					meshRenderer.sharedMaterials[j] = _originalMaterial;
				}
			}
			return;
		}
		array = meshRenderers;
		foreach (MeshRenderer meshRenderer2 in array)
		{
			for (int k = 0; k < meshRenderer2.sharedMaterials.Length; k++)
			{
				meshRenderer2.sharedMaterials[k] = GetMaterialStyleFromStyle(modifier.modifierArtStyle).material;
			}
		}
		ModifierMaterialStyle GetMaterialStyleFromStyle(ModifierArtStyle style)
		{
			ModifierMaterialStyle[] array2 = modifierMaterialStyles;
			for (int l = 0; l < array2.Length; l++)
			{
				ModifierMaterialStyle result = array2[l];
				if (result.artStyle == style)
				{
					return result;
				}
			}
			return modifierMaterialStyles[0];
		}
	}
}
