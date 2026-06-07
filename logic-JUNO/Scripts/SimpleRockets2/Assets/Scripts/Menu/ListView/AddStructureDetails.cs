namespace Assets.Scripts.Menu.ListView
{
	public class AddStructureDetails
	{
		private DetailsTextScript _description;

		public AddStructureDetails(ListViewDetailsScript listViewDetails)
		{
			_description = listViewDetails.Widgets.AddText("Description");
		}

		public void UpdateDetails(AddStructureViewModel.StructureItem structure)
		{
			_description.Text = structure.Description;
		}
	}
}
