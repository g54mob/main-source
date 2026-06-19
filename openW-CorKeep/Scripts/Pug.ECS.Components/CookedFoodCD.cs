using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public struct CookedFoodCD : IComponentData, IQueryTypeParameter
{
	private const int SEED = 87931;

	public ObjectID rareVersion;

	public ObjectID epicVersion;

	public Color ingredient1BrightestColor;

	public Color ingredient1BrightColor;

	public Color ingredient1DarkColor;

	public Color ingredient1DarkestColor;

	public Color ingredient2BrightestColor;

	public Color ingredient2BrightColor;

	public Color ingredient2DarkColor;

	public Color ingredient2DarkestColor;

	public const int INGREDIENT_ENCODING_SHIFT = 16;

	public static int GetFoodVariation(ObjectID ingredient1, ObjectID ingredient2)
	{
		return ((int)GetPrimaryIngredient(ingredient1, ingredient2) << 16) | (int)GetSecondaryIngredient(ingredient1, ingredient2);
	}

	private static ObjectID GetIngredient1FromFoodVariation(int variation)
	{
		return (ObjectID)((uint)variation >> 16);
	}

	private static ObjectID GetIngredient2FromFoodVariation(int variation)
	{
		return (ObjectID)(variation & 0xFFFF);
	}

	public static ObjectID GetPrimaryIngredientFromVariation(int variation)
	{
		return GetPrimaryIngredient(GetIngredient1FromFoodVariation(variation), GetIngredient2FromFoodVariation(variation));
	}

	public static ObjectID GetSecondaryIngredientFromVariation(int variation)
	{
		return GetSecondaryIngredient(GetIngredient1FromFoodVariation(variation), GetIngredient2FromFoodVariation(variation));
	}

	public static ObjectID GetPrimaryIngredient(ObjectID ingredient1, ObjectID ingredient2)
	{
		if (IngredientShouldBePrimary(ingredient1) && !IngredientShouldBePrimary(ingredient2))
		{
			return ingredient1;
		}
		if (!IngredientShouldBePrimary(ingredient1) && IngredientShouldBePrimary(ingredient2))
		{
			return ingredient2;
		}
		if (FirstIngredientIsPrimary(ingredient1, ingredient2))
		{
			return ingredient1;
		}
		return ingredient2;
	}

	public static ObjectID GetSecondaryIngredient(ObjectID ingredient1, ObjectID ingredient2)
	{
		if (IngredientShouldBePrimary(ingredient1) && !IngredientShouldBePrimary(ingredient2))
		{
			return ingredient2;
		}
		if (!IngredientShouldBePrimary(ingredient1) && IngredientShouldBePrimary(ingredient2))
		{
			return ingredient1;
		}
		if (FirstIngredientIsPrimary(ingredient1, ingredient2))
		{
			return ingredient2;
		}
		return ingredient1;
	}

	private static bool FirstIngredientIsPrimary(ObjectID ingredient1, ObjectID ingredient2)
	{
		Unity.Mathematics.Random random = Unity.Mathematics.Random.CreateFromIndex((uint)((int)ingredient1 * 2 + ingredient2 + 87931));
		Unity.Mathematics.Random random2 = Unity.Mathematics.Random.CreateFromIndex((uint)((int)ingredient2 * 2 + ingredient1 + 87931));
		return random.NextFloat() > random2.NextFloat();
	}

	public static bool IngredientShouldBePrimary(ObjectID ingredient)
	{
		if (!ingredient.IsGoldenPlant())
		{
			return ingredient == ObjectID.StarlightNautilus;
		}
		return true;
	}

	public static bool IsIngredientObsolete(ObjectID ingredient)
	{
		if (ingredient != ObjectID.GiantMushroom)
		{
			return ingredient == ObjectID.AmberLarva;
		}
		return true;
	}

	public static int ConvertOldVariationEncoding(int variation)
	{
		return GetFoodVariation((ObjectID)(variation / 10000), (ObjectID)(variation % 10000));
	}
}
