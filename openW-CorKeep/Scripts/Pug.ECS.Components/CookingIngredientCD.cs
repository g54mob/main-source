using Unity.Entities;
using UnityEngine;

public struct CookingIngredientCD : IComponentData, IQueryTypeParameter
{
	public Color brightestColor;

	public Color brightColor;

	public Color darkColor;

	public Color darkestColor;

	public ObjectID turnsIntoFood;

	public IngredientType ingredientType;
}
