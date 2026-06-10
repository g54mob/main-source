using System;
using NSMedieval.State;

namespace NSMedieval.UI
{
	public class SelectionExtraAnimal : SelectionExtraWindowView
	{
		[NonSerialized]
		private AnimalInstance animal;

		public AnimalInstance Animal => animal;

		public void ShowPanel(AnimalInstance animal)
		{
			if (this.animal != animal)
			{
				this.animal = animal;
			}
			ShowPanel();
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			animal = null;
		}
	}
}
