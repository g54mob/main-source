namespace ModApi.PlanetStudio
{
	public interface IEquirectangularMapView
	{
		bool Enabled { get; set; }

		float Scale { get; set; }

		void Refresh();
	}
}
