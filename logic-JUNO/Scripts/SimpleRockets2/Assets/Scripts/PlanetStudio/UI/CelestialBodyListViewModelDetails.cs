using Assets.Scripts.Menu.ListView;
using ModApi.CelestialData;

namespace Assets.Scripts.PlanetStudio.UI
{
	public class CelestialBodyListViewModelDetails
	{
		private DetailsPropertyScript _author;

		private bool _create;

		private DetailsTextScript _description;

		private DetailsTextScript _filePath;

		private DetailsPropertyScript _lastModified;

		private DetailsPropertyScript _version;

		public CelestialBodyListViewModelDetails(ListViewDetailsScript listViewDetails, bool create)
		{
			_create = create;
			DetailsWidgetGroup widgets = listViewDetails.Widgets;
			if (!_create)
			{
				widgets.AddSpacer();
				_author = widgets.AddProperty("Author");
				_version = widgets.AddProperty("Version");
				_lastModified = widgets.AddProperty("LastModified");
				widgets.AddSpacer();
				_filePath = widgets.AddText("FilePath");
				_author.LabelText = "Author";
				_version.LabelText = "Version";
				_lastModified.LabelText = "Modified Date";
				widgets.AddSpacer();
			}
			_description = widgets.AddText("Description");
		}

		public void UpdateDetails(CelestialFile file)
		{
			CelestialBodyFileData celestialBody = Game.Instance.CelestialDatabase.GetCelestialBody(file.Id);
			_description.Text = celestialBody.Description;
			if (!_create)
			{
				_author.ValueText = celestialBody.Author;
				_version.ValueText = celestialBody.Version?.ToString() ?? string.Empty;
				_lastModified.ValueText = file.LastModified.ToString("yyyy-MM-dd HH:mm:ss");
				_filePath.Text = file.Path.RelativePath;
			}
		}
	}
}
