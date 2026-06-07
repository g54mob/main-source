using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Vehicles.Land.Convoy
{
	public abstract class ConvoyProviderScript : MonoBehaviour
	{
		public abstract GameObject[] GetConvoyPrefabs();
	}
}
