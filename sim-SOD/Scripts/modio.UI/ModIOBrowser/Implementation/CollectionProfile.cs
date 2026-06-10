using ModIO;

namespace ModIOBrowser.Implementation
{
	public struct CollectionProfile
	{
		public ModProfile modProfile;

		public bool subscribed;

		public bool enabled;

		public int subscribers;

		public string installationStatus;

		public ModId id => default(ModId);

		public string name => null;

		public CollectionProfile(ModProfile profile, bool subscribed, bool enabled, int subscribers, string installationStatus)
		{
			modProfile = default(ModProfile);
			this.subscribed = false;
			this.enabled = false;
			this.subscribers = 0;
			this.installationStatus = null;
		}
	}
}
