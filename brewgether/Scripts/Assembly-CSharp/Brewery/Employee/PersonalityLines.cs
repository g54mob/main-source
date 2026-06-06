using System;
using UnityEngine;

namespace Brewery.Employee
{
	[Serializable]
	public struct PersonalityLines
	{
		public BreweryEmployeePersonality personality;

		[TextArea(1, 2)]
		public string[] lines;
	}
}
