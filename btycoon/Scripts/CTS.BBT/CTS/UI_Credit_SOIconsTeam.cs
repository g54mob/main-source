using System;
using System.Collections.Generic;
using UnityEngine;

namespace CTS
{
	[Serializable]
	[CreateAssetMenu(fileName = "CreditIconTeam", menuName = "Sheet/IconTeam")]
	public class UI_Credit_SOIconsTeam : ScriptableObject
	{
		[field: SerializeField]
		public List<Sprite> IconTeams { get; private set; }
	}
}
