using UnityEngine;

namespace Assets.Scripts.Flight.Maps
{
	public class Map : MonoBehaviour
	{
		[SerializeField]
		[Tooltip("If checked, this map will be available for players to use in sandbox mode.")]
		private bool _allowSandbox = true;

		[SerializeField]
		[Tooltip("This should point to the game object that defines the start location for the map. This object should live somewhere in the map's game object hierarchy.")]
		private MapStartLocation _defaultStartLocation;

		[SerializeField]
		[Multiline(4)]
		[Tooltip("A brief description of the map.")]
		private string _description;

		[SerializeField]
		[Tooltip("The name of the map. This is the name users will see under the map icon for sandbox maps.")]
		private string _mapName = "Custom Map";

		public bool AllowSandbox => _allowSandbox;

		public MapStartLocation DefaultStartLocation => _defaultStartLocation;

		public string Description => _description;

		public string MapName => _mapName;
	}
}
