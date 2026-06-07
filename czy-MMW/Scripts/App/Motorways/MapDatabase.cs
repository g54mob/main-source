using UnityEngine;

namespace Motorways
{
	[CreateAssetMenu(fileName = "New Map Database", menuName = "Motorways/Map Database", order = 2)]
	public class MapDatabase : ScriptableObject
	{
		[SerializeField]
		private MapLibrary _mapLibrary;

		public MapLibrary MapLibrary => _mapLibrary;
	}
}
