using System.Collections.Generic;
using CTS.BBT;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Drinks/Drink List")]
	public class DrinkList : ScriptableObject
	{
		[field: SerializeField]
		public List<DrinkSO> List { get; private set; } = new List<DrinkSO>();
	}
}
