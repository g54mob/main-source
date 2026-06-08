namespace TwitchLib.Api.Helix.Models.Helpers
{
	public class ExtensionAnalytics
	{
		public string Date { get; protected set; }

		public string ExtensionName { get; protected set; }

		public string ExtensionClientId { get; protected set; }

		public int Installs { get; protected set; }

		public int Uninstalls { get; protected set; }

		public int Activations { get; protected set; }

		public int UniqueActiveChannels { get; protected set; }

		public int Renders { get; protected set; }

		public int UniqueRenders { get; protected set; }

		public int Views { get; protected set; }

		public int UniqueViewers { get; protected set; }

		public int UniqueInteractors { get; protected set; }

		public int Clicks { get; protected set; }

		public double ClicksPerInteractor { get; protected set; }

		public double InteractionRate { get; protected set; }

		public ExtensionAnalytics(string row)
		{
			string[] array = row.Split(',');
			Date = array[0];
			ExtensionName = array[1];
			ExtensionClientId = array[2];
			Installs = int.Parse(array[3]);
			Uninstalls = int.Parse(array[4]);
			Activations = int.Parse(array[5]);
			UniqueActiveChannels = int.Parse(array[6]);
			Renders = int.Parse(array[7]);
			UniqueRenders = int.Parse(array[8]);
			Views = int.Parse(array[9]);
			UniqueViewers = int.Parse(array[10]);
			UniqueInteractors = int.Parse(array[11]);
			Clicks = int.Parse(array[12]);
			ClicksPerInteractor = double.Parse(array[13]);
			InteractionRate = double.Parse(array[14]);
		}
	}
}
