using Assets.Scripts;
using Assets.Scripts.Flight;
using Assets.Scripts.Multiplayer;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Todo
{
	public class SpawnNetworkFlightObjectScript : MonoBehaviour
	{
		[SerializeField]
		private string _prefab;

		protected virtual void Start()
		{
			int stableHashCode = StringUtility.GetStableHashCode(Utilities.GetFullObjectHierarchy(base.transform));
			FlightSceneNetworkScript flightSceneNetwork = FlightSceneScript.Instance.FlightSceneNetwork;
			if (flightSceneNetwork.FlightObjectsManager.GetFlightObjectByID(stableHashCode) == null)
			{
				flightSceneNetwork.SpawnFlightObject(_prefab, Utility.ConvertFloatingOriginToAbsolutePosition(base.transform.position), base.transform.rotation.eulerAngles, null, stableHashCode);
			}
		}
	}
}
