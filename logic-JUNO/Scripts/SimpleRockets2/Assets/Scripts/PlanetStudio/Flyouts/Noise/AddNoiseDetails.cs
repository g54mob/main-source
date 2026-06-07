using Assets.Scripts.Menu.ListView;

namespace Assets.Scripts.PlanetStudio.Flyouts.Noise
{
	public class AddNoiseDetails
	{
		private DetailsTextScript _description;

		public AddNoiseDetails(ListViewDetailsScript listViewDetails)
		{
			_description = listViewDetails.Widgets.AddText("Description");
		}

		public void UpdateDetails(AddNoiseViewModel.PlanetModifierElement itemModel)
		{
			_description.Text = itemModel.Description;
		}
	}
}
