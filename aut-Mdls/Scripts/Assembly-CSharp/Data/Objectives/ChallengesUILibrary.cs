using System.Collections.Generic;
using UnityEngine;

namespace Data.Objectives
{
	[CreateAssetMenu(menuName = "Objectives/ChallengesUISO")]
	public class ChallengesUILibrary : ScriptableObject
	{
		public List<ChallengeUI> ChallengeUIs;

		public List<string> TierLocaKeys;
	}
}
