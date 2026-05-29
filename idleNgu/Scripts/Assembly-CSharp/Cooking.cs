using System;
using System.Collections.Generic;

[Serializable]
public class Cooking
{
	public bool unlocked;

	public float cookTimer;

	public List<Ingredient> ingredients;

	public List<int> pair1 = new List<int>();

	public List<int> pair2 = new List<int>();

	public List<int> pair3 = new List<int>();

	public List<int> pair4 = new List<int>();

	public int pair1Target;

	public int pair2Target;

	public int pair3Target;

	public int pair4Target;

	public float expBonus = 1f;

	public int curDishIndex;

	public Cooking()
	{
		ingredients = new List<Ingredient>();
		ingredients.Clear();
		ingredients.Add(new Ingredient());
		ingredients.Add(new Ingredient());
		ingredients.Add(new Ingredient());
		ingredients.Add(new Ingredient());
		ingredients.Add(new Ingredient());
		ingredients.Add(new Ingredient());
		ingredients.Add(new Ingredient());
		ingredients.Add(new Ingredient());
		ingredients[0].unlocked = true;
		ingredients[1].unlocked = true;
		ingredients[2].unlocked = true;
		ingredients[3].unlocked = true;
		ingredients[4].unlocked = true;
		ingredients[5].unlocked = true;
		ingredients[6].unlocked = false;
		ingredients[7].unlocked = false;
		pair1 = new List<int>();
		pair2 = new List<int>();
		pair3 = new List<int>();
		pair4 = new List<int>();
		expBonus = 1f;
		curDishIndex = 0;
		unlocked = false;
		pair1Target = 10;
		pair2Target = 10;
		pair3Target = 10;
		pair4Target = 10;
	}
}
