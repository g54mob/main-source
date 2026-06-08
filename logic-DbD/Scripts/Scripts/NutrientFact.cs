public class NutrientFact
{
	public string food_name;

	public string nutrient;

	public int nutrient_quantity;

	public NutrientFact(string food_name, string nutrient, int nutrient_quantity)
	{
		this.food_name = food_name;
		this.nutrient = nutrient;
		this.nutrient_quantity = nutrient_quantity;
	}

	public override string ToString()
	{
		return $"'{food_name}', '{nutrient}', {nutrient_quantity}";
	}
}
