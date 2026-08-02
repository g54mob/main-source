using UnityEngine;

namespace JUTPS.AI
{
	public class SetVehicleRandomDestinations : MonoBehaviour
	{
		private VehicleAI vehicleAI;

		[SerializeField]
		private float RefreshRate = 10f;

		[SerializeField]
		private float Range = 50f;

		private void Start()
		{
			vehicleAI = GetComponent<VehicleAI>();
			InvokeRepeating("Refresh", 0f, RefreshRate);
		}

		private void Refresh()
		{
			vehicleAI.SetVehicleDestination(new Vector3(Random.Range(0f - Range, Range), 0f, Random.Range(0f - Range, Range)));
			vehicleAI.RecalculatePath();
		}

		private void OnDrawGizmos()
		{
			Gizmos.DrawWireCube(Vector3.zero, new Vector3(Range * 2f, 0f, Range * 2f));
		}
	}
}
