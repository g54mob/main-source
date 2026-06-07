using System;
using UnityEngine;

namespace Brewery.Employee
{
	[Serializable]
	public struct PerkDisplayData
	{
		public string displayName;

		[Tooltip("Use {0} placeholder for the numeric value")]
		public string description;
	}
}
