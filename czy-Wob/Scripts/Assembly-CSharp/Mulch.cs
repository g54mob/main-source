using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Mulch_", menuName = "Mulch", order = 1)]
public class Mulch : ScriptableObject
{
	public Sprite icon;

	public string recipeName;

	public string recipeDescription;

	public List<RecipeItem> ingredients = new List<RecipeItem>();

	public List<MulchEffect> effects = new List<MulchEffect>();
}
