using UnityEngine;

namespace TH20
{
	public interface IArrivedCallback
	{
		Character OnArrived(Vector3 position);

		void OnFailed();

		bool HasPatientSpawnedCallback(IPatientSpawned patientSpawned);

		bool IsValid();

		int GetArrivalPriority();
	}
}
