namespace MalbersAnimations.Utilities
{
	public interface ILookAtActivation
	{
		void EnableByPriority(int layer);

		void DisableByPriority(int layer);

		void ResetByPriority(int layer);
	}
}
