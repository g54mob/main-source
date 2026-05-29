using System;
using UnityEngine;

namespace FuryStudios.FurySDK.Settings
{
	[Serializable]
	public class Playstation4AgeRestriction
	{
		[SerializeField]
		private string country;

		[SerializeField]
		private int ageRestriction;

		public string Country => null;

		public int AgeRestriction => 0;

		public Playstation4AgeRestriction(string country, int ageRestriction)
		{
		}
	}
}
