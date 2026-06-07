using System.Collections.Generic;
using UnityEngine;

namespace Motorways
{
	[CreateAssetMenu(fileName = "New Map Library", menuName = "Motorways/Map Library", order = 2)]
	public class MapLibrary : ScriptableObject
	{
		[SerializeField]
		private MapDefinition[] _maps;

		public IEnumerable<MapDefinition> Maps => _maps;

		public int MapCount => _maps.Length;

		public MapDefinition GetMapByName(string cityName)
		{
			MapDefinition[] maps = _maps;
			foreach (MapDefinition mapDefinition in maps)
			{
				if (mapDefinition.cityName == cityName)
				{
					return mapDefinition;
				}
			}
			return null;
		}
	}
}
