namespace TH20
{
	public interface IVisitorSpawned
	{
		void OnVisitorSpawned(Visitor visitor);

		void OnFailedToSpawn();

		bool IsValid();
	}
}
