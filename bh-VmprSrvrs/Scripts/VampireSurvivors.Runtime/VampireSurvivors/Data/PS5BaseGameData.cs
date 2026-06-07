using System;
using UnityEngine;

namespace VampireSurvivors.Data
{
	[Serializable]
	public class PS5BaseGameData
	{
		[Tooltip("This should only ever be updated if we are submitting a new master version. This is for failed initial submissions, or remasters / disc releases.")]
		public string _MasterVersion;
	}
}
