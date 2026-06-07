namespace Gh.Tk.UI.InfoPanels
{
	public interface IGoxInfoElement
	{
		GameObjectX Gox { get; }

		void SetGox(GameObjectX gox);

		void Refresh();
	}
}
