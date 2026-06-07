namespace Gh.Tk.Story.Structure
{
	public interface IStaffFilterNode
	{
		string race { get; }

		int minTier { get; }

		Gender gender { get; }

		bool excludeStoryStaff { get; }

		string sickState { get; }

		string sleepState { get; }

		string workState { get; }

		string[] mustHaveTraits { get; }

		string[] cannotHaveTraits { get; }

		int minHappiness { get; }

		int maxHappiness { get; }
	}
}
