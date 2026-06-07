using System;
using System.Collections.Generic;

namespace Gh.Tk
{
	public class ExNihiloProcess : CraftProcess, IEquatable<ExNihiloProcess>
	{
		public static HashSet<ExNihiloProcess> AllExNihiloProcesses;

		public IngredientKeyLevel[] ingredientKeyPerLevel;

		public override Ingredient Simulate(RecipeInput[] input)
		{
			return null;
		}

		protected override void CheckInput(RecipeInput[] input)
		{
		}

		public override void Start()
		{
		}

		private void OnBuildable_PostBuiltEvent(object sender, EventArgs e)
		{
		}

		public void AddRecipeIfNeeded()
		{
		}

		protected override void SimulateInternal(Ingredient target, RecipeInput[] input)
		{
		}

		public bool Equals(ExNihiloProcess other)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public static bool operator ==(ExNihiloProcess left, ExNihiloProcess right)
		{
			return false;
		}

		public static bool operator !=(ExNihiloProcess left, ExNihiloProcess right)
		{
			return false;
		}

		public override void OnDestroy()
		{
		}
	}
}
