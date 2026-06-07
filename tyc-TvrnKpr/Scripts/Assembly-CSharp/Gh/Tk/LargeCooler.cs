using UnityEngine;

namespace Gh.Tk
{
	public class LargeCooler : Prop
	{
		[Header("Same as Well")]
		public IngredientKeyLevel[] ingredientKeyPerLevel;

		private IngredientTemplate _ingredientTemplate;

		public override void CreateMaintenanceJob()
		{
		}

		public override void Start()
		{
		}
	}
}
