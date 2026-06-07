using Ezereal;
using Pathfinding;
using UnityEngine;

namespace Brewery.Vehicle
{
	public class VehicleNavmeshCutController : MonoBehaviour
	{
		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private NavmeshCut navmeshCut;

		private IVehicleController vehicleController;

		private EzerealCarController carController;

		private bool lastHadDriver;

		private void Awake()
		{
		}

		private void Update()
		{
		}

		private bool GetHasDriver()
		{
			return false;
		}
	}
}
