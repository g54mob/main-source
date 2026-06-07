namespace Gh.Tk.Story.Config
{
	public interface IPatronPawnModifyingConfig
	{
		bool deletePawns { get; }

		bool removeAllNonBasicNeeds { get; }

		bool disableImpromptuOptionalNeeds { get; }

		string[] removeNeeds { get; }

		string[] forceNeeds { get; }

		SecondaryNeedConfig[] secondaryNeeds { get; }

		bool removeReputationRequirements { get; }

		string[] traits { get; }

		string[] conversationThemes { get; }
	}
}
