namespace OffroadExplorer.Lobby
{
	public struct SceneTransitionOptions
	{
		public bool UseFade;

		public bool ShowIndicator;

		public string IndicatorText;

		public bool Networked;

		public static SceneTransitionOptions Default => default(SceneTransitionOptions);
	}
}
