using System;
using Gh.Tk.Story;

namespace Gh.Tk
{
	[Serializable]
	public class IngredientKeyLevel
	{
		public GameLevel Level;

		[DropDownChoice(typeof(StoryHelper), "GetAllGameItemTemplateIds")]
		public string IngredientId;
	}
}
