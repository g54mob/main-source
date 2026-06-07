namespace Assets.Scripts.Craft.Parts
{
	public interface IRoundRobinUpdate
	{
		bool IsDestroyed { get; }

		string RoundRobinGroupKey { get; }

		void OnRoundRobinUpdate(bool isActiveThisFrame);
	}
}
