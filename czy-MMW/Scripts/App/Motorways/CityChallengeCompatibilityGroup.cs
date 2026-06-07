using System.Linq;
using NaughtyAttributes;
using UnityEngine;

namespace Motorways
{
	[CreateAssetMenu(fileName = "New Challenge", menuName = "Motorways/Challenges/CityGroup", order = 3)]
	public class CityChallengeCompatibilityGroup : ScriptableObject
	{
		[TextArea]
		public string description;

		[InfoBox("If a map is in this list, is it compatible or incompatible with the group?", InfoBoxType.Normal, null)]
		public bool isWhiteList;

		public MapDefinition.CityNames[] cities = new MapDefinition.CityNames[0];

		public bool IsMapCompatible(MapDefinition.CityNames cityName)
		{
			bool flag = cities.Contains(cityName);
			return isWhiteList == flag;
		}
	}
}
