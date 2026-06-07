using Assets.Scripts.Menu.ListView;
using ModApi.CelestialData;

namespace Assets.Scripts.PlanetStudio.UI
{
	public class PlanetarySystemListViewModelDetails
	{
		private DetailsPropertyScript _author;

		private DetailsTextScript _description;

		private DetailsTextScript _filePath;

		private DetailsPropertyScript _lastModified;

		private DetailsPropertyScript _version;

		public PlanetarySystemListViewModelDetails(ListViewDetailsScript listViewDetails)
		{
			DetailsWidgetGroup widgets = listViewDetails.Widgets;
			_author = widgets.AddProperty("Author");
			_version = widgets.AddProperty("Version");
			_lastModified = widgets.AddProperty("LastModified");
			widgets.AddSpacer();
			_filePath = widgets.AddText("FilePath");
			widgets.AddSpacer();
			_description = widgets.AddText("Description");
			_author.LabelText = "Author";
			_version.LabelText = "Version";
			_lastModified.LabelText = "Modified Date";
		}

		public void UpdateDetails(CelestialFile file)
		{
			PlanetarySystemFileData planetarySystem = Game.Instance.CelestialDatabase.GetPlanetarySystem(file.Id);
			_author.ValueText = planetarySystem.Author;
			_version.ValueText = planetarySystem.Version?.ToString() ?? string.Empty;
			_lastModified.ValueText = file.LastModified.ToString("yyyy-MM-dd HH:mm:ss");
			_filePath.Text = file.Path.RelativePath;
			_description.Text = planetarySystem.Description;
		}
	}
}
