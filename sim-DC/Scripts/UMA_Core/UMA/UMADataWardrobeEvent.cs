using System;
using UMA.CharacterSystem;
using UnityEngine.Events;

namespace UMA
{
	[Serializable]
	public class UMADataWardrobeEvent : UnityEvent<UMAData, UMAWardrobeRecipe>
	{
		public UMADataWardrobeEvent()
		{
		}

		public UMADataWardrobeEvent(UMADataWardrobeEvent source)
		{
		}
	}
}
