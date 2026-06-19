using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Recipe_", menuName = "Project/Crafting/Recipe")]
public class Recipe : ScriptableObject
{
	[SerializeField]
	public float CraftDurationModifier;

	[field: SerializeField]
	public string ID { get; private set; }

	[field: SerializeField]
	public List<CostStack> Ingredients { get; private set; }

	[field: SerializeField]
	public ItemType Product { get; private set; }

	public bool DemoLocked => false;
}
