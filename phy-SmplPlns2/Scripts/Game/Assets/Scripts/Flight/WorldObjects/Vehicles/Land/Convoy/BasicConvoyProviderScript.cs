using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Vehicles.Land.Convoy
{
	public class BasicConvoyProviderScript : ConvoyProviderScript
	{
		[SerializeField]
		private GameObject[] _convoyPrefabs;

		public override GameObject[] GetConvoyPrefabs()
		{
			return _convoyPrefabs;
		}
	}
}
