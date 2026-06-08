using System.Collections.Generic;
using System.Linq;
using KitchenData;

namespace Kitchen
{
	public class TutorialAddMenuItem : TutorialAction
	{
		public int MenuItem;

		public List<int> Ingredients;

		public MenuPhase Phase;

		public TutorialAddMenuItem(int item, MenuPhase phase, params int[] ingredients)
		{
			MenuItem = item;
			Ingredients = ingredients.ToList();
			Phase = phase;
		}
	}
}
