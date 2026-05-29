namespace Funly.SkyStudio
{
	public struct ProfileBlendingState
	{
		public SkyProfile blendedProfile;

		public SkyProfile fromProfile;

		public SkyProfile toProfile;

		public float progress;

		public float outProgress;

		public float inProgress;

		public float timeOfDay;

		public ProfileBlendingState(SkyProfile blendedProfile, SkyProfile fromProfile, SkyProfile toProfile, float progress, float outProgress, float inProgress, float timeOfDay)
		{
			this.blendedProfile = null;
			this.fromProfile = null;
			this.toProfile = null;
			this.progress = 0f;
			this.outProgress = 0f;
			this.inProgress = 0f;
			this.timeOfDay = 0f;
		}
	}
}
