namespace Coherence.Cloud
{
	public readonly struct LoginAsGuestOptions
	{
		public static readonly LoginAsGuestOptions Default;

		private readonly CloudUniqueId cloudUniqueId;

		private readonly string projectId;

		public CloudUniqueId CloudUniqueId => default(CloudUniqueId);

		internal string ProjectId => null;

		public LoginAsGuestOptions(CloudUniqueId cloudUniqueId)
		{
			this.cloudUniqueId = default(CloudUniqueId);
			projectId = null;
		}

		internal LoginAsGuestOptions(CloudUniqueId cloudUniqueId, string projectId)
		{
			this.cloudUniqueId = default(CloudUniqueId);
			this.projectId = null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
