using System;
using System.Runtime.CompilerServices;

namespace Gh.Tk.UI.Dialogs.TavernMenu
{
	public class IngredientTavernMenuItem3DUIView : TavernMenuItem3DUIView
	{
		protected IngredientTemplate _ingredientTemplate;

		public event EventHandler<EventArgs<TavernMenuItem3DUIView>> Deleted
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		protected override void Start()
		{
		}

		private void DeleteButtonPressed()
		{
		}

		protected override void UpdateRatingInfo()
		{
		}

		public virtual void SetData(Ingredient ingredient)
		{
		}
	}
}
