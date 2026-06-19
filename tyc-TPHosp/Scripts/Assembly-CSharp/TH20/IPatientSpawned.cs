namespace TH20
{
	public interface IPatientSpawned
	{
		void OnPatientSpawned(Patient patient);

		void OnFailedToSpawn();

		bool IsValid();

		int GetArrivalPriority();
	}
}
