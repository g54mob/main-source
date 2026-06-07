using UnityEngine.Events;

namespace MalbersAnimations
{
	public interface IAITargeterTarget : IAITarget
	{
		float TargeterStopDistance { get; }

		int Targeters { get; }

		int TargetsLimits { get; }

		bool FullTargeters { get; }

		float WaitTargeterDistance { get; }

		UnityEvent TargetersRefresh { get; set; }

		float GetTargeterStoppingDistance(int index);

		bool TargeterIsWaiting(int index);

		void AddTargeter(IAIControl ai);

		void RemoveTargeter(IAIControl ai);
	}
}
