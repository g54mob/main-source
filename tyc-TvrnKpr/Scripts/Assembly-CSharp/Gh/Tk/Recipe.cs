using System.Collections.Generic;

namespace Gh.Tk
{
	public class Recipe : IPersistable
	{
		public int Amount;

		public string Id { get; private set; }

		public string ProcessVerb { get; set; }

		public List<RecipeInput> Inputs { get; set; }

		public StringBuilderPool.DisposableStringBuilder GetRecipeInfo()
		{
			return null;
		}
	}
}
