using System;
using UMA.CharacterSystem;
using UnityEngine.Events;

namespace UMA
{
	[Serializable]
	public class UMACharacterEvent : UnityEvent<DynamicCharacterAvatar>
	{
		public UMACharacterEvent()
		{
		}

		public UMACharacterEvent(UMACharacterEvent source)
		{
		}

		public void AddAction(Action<DynamicCharacterAvatar> action)
		{
		}

		public void RemoveAction(Action<DynamicCharacterAvatar> action)
		{
		}
	}
}
