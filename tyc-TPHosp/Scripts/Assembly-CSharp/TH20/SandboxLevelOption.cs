using FullInspector;

namespace TH20
{
	public class SandboxLevelOption : SandboxOption
	{
		public SharedInstance<LevelConfig> Level;

		public SharedInstance<SandboxThumbnail.Style> ThumbnailStyle;

		public SandboxThumbnail.Style GetThumbnailStyle(SandboxThumbnail.Style defaultStyle)
		{
			if (!ThumbnailStyle.IsNull())
			{
				return ThumbnailStyle.Instance;
			}
			return defaultStyle;
		}
	}
}
