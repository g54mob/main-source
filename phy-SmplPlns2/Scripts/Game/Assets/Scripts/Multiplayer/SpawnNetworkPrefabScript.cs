using Assets.Scripts.Flight;
using UnityEngine;

namespace Assets.Scripts.Multiplayer
{
	public class SpawnNetworkPrefabScript : MonoBehaviour
	{
		[SerializeField]
		private string _prefabPath;

		protected virtual void Start()
		{
			FlightSceneScript.Instance.FlightSceneNetwork.ClientStarted += OnFlightSceneNetworkClientStarted;
		}

		private void OnFlightSceneNetworkClientStarted()
		{
			FlightSceneScript.Instance.FlightSceneNetwork.ClientStarted -= OnFlightSceneNetworkClientStarted;
			if (FlightSceneScript.Instance.FlightSceneNetwork.IsServerStarted)
			{
				Vector3 absolutePosition = Utility.ConvertFloatingOriginToAbsolutePosition(base.transform.position);
				FlightSceneScript.Instance.FlightSceneNetwork.SpawnGameObject(_prefabPath, absolutePosition, base.transform.rotation.eulerAngles);
			}
		}
	}
}
