using System;
using UnityEngine;

namespace CTS
{
	[Serializable]
	public struct Level
	{
		[field: SerializeField]
		public int CharacteristicsMaximum { get; private set; }

		[field: SerializeField]
		public float RequiredExperience { get; private set; }
	}
}
