using System;
using System.Collections.Generic;
using System.Linq;
using Aggro.Core;
using Unity.Mathematics;
using UnityEngine;

public class ModifierArtManager : EntityBehaviourBase, IModifierAdded
{
	[Serializable]
	public struct ModifierArtStyleSet
	{
		public ModifierArtStyle style;

		public ModifierPropVariant[] propVariants;
	}

	[Serializable]
	public struct ModifierPropVariant
	{
		public Material material;

		public GameObject[] gameObjects;

		public int cardCount;
	}

	private int _seed;

	public ModifierArtStyleSet[] modifierArtStyleSets;

	private MeshRenderer _meshRenderer;

	public List<Material> originalMaterials;

	private ModifierArtStyle _currentStyle;

	public int sideMatIndex = -1;

	protected override void OnEntityCreated()
	{
		_meshRenderer = GetComponent<MeshRenderer>();
		if (_meshRenderer != null)
		{
			originalMaterials = _meshRenderer.sharedMaterials.ToList();
		}
		_seed = Hash.Calculate(GameUtil.seed, Hash.Calculate(GetType()), math.asint(base.transform.position.x), math.asint(base.transform.position.y));
		ResetArtStyle();
		SetArtStyle(modifierArtStyleSets[0].style);
	}

	private void ResetArtStyle()
	{
		_currentStyle = ModifierArtStyle.None;
		if (_meshRenderer != null)
		{
			_meshRenderer.SetSharedMaterials(originalMaterials);
		}
		ModifierArtStyleSet[] array = modifierArtStyleSets;
		for (int i = 0; i < array.Length; i++)
		{
			ModifierPropVariant[] propVariants = array[i].propVariants;
			for (int j = 0; j < propVariants.Length; j++)
			{
				GameObject[] gameObjects = propVariants[j].gameObjects;
				foreach (GameObject gameObject in gameObjects)
				{
					if (gameObject == null)
					{
						Debug.LogError("ModiferArtManager's prop variant is missing objects: ", this);
						return;
					}
					gameObject.SetActive(value: false);
				}
			}
		}
	}

	private void SetArtStyle(ModifierArtStyle style)
	{
		_currentStyle = style;
		ModifierArtStyleSet setFromStyle = GetSetFromStyle(style);
		if (_meshRenderer != null)
		{
			if (setFromStyle.style == ModifierArtStyle.None)
			{
				_meshRenderer.SetSharedMaterials(originalMaterials);
			}
			else
			{
				List<Material> list = new List<Material>();
				for (int i = 0; i < _meshRenderer.materials.Length; i++)
				{
					if (i == sideMatIndex)
					{
						list.Add(originalMaterials[sideMatIndex]);
					}
					list.Add(setFromStyle.propVariants[0].material);
				}
				_meshRenderer.SetSharedMaterials(list);
			}
		}
		Deck<ModifierPropVariant> deck = new Deck<ModifierPropVariant>(_seed);
		ModifierPropVariant[] propVariants = setFromStyle.propVariants;
		for (int j = 0; j < propVariants.Length; j++)
		{
			ModifierPropVariant card = propVariants[j];
			for (int k = 0; k < card.cardCount; k++)
			{
				deck.AddCard(card);
			}
		}
		deck.Shuffle();
		GameObject[] gameObjects = deck.DrawCard().gameObjects;
		for (int j = 0; j < gameObjects.Length; j++)
		{
			gameObjects[j].SetActive(value: true);
		}
		deck.Clear();
	}

	private ModifierArtStyleSet GetSetFromStyle(ModifierArtStyle style)
	{
		ModifierArtStyleSet[] array = modifierArtStyleSets;
		for (int i = 0; i < array.Length; i++)
		{
			ModifierArtStyleSet result = array[i];
			if (result.style == style)
			{
				return result;
			}
		}
		return modifierArtStyleSets[0];
	}

	public void OnModifierAdded(ModifierBase modifier)
	{
		ResetArtStyle();
		SetArtStyle(modifier.modifierArtStyle);
	}
}
