namespace Gh.Tk
{
	public class CinematicCinemaBars3DUIView : SimpleCinemaBars3DUIView
	{
		public const string PREFAB_KEY = "CinemaBarsOverlay";

		public const string IS_CINEMA_BARS_ACTIVE_STORYKEY = "IsCinemaBarsActive";

		public static bool IsStoryFlagActive => false;

		public static bool CanCinematicPlay()
		{
			return false;
		}

		protected override void Awake()
		{
		}

		public void Show(bool skipTransition = false)
		{
		}

		public void Hide(bool skipTransition = false)
		{
		}

		public void UpdateVisual(bool skipTransition)
		{
		}
	}
}
