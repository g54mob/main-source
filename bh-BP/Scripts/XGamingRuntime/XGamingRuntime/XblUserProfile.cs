using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblUserProfile
	{
		public ulong XboxUserId { get; private set; }

		public string AppDisplayName { get; private set; }

		public string AppDisplayPictureResizeUri { get; private set; }

		public string GameDisplayName { get; private set; }

		public string GameDisplayPictureResizeUri { get; private set; }

		public string Gamerscore { get; private set; }

		public string Gamertag { get; private set; }

		public string ModernGamertag { get; private set; }

		public string ModernGamertagSuffix { get; private set; }

		public string UniqueModernGamertag { get; private set; }

		internal XblUserProfile(XGamingRuntime.Interop.XblUserProfile interopStruct)
		{
		}
	}
}
