namespace VoxelBusters.EssentialKit
{
	public class MediaContentSelectOptions
	{
		public string Title { get; private set; }

		public string AllowedMimeType { get; private set; }

		public int MaxAllowed { get; private set; }

		private bool ShowPrepermissionDialog { get; set; }

		public MediaContentSelectOptions(string title, string allowedMimeType, int maxAllowed)
		{
		}

		public static MediaContentSelectOptions CreateForImage(int maxAllowed = 1)
		{
			return null;
		}

		public static MediaContentSelectOptions CreateForVideo(int maxAllowed = 1)
		{
			return null;
		}

		public static MediaContentSelectOptions CreateForAudio(int maxAllowed = 1)
		{
			return null;
		}

		public static MediaContentSelectOptions CreateForAny(int maxAllowed = 1)
		{
			return null;
		}
	}
}
