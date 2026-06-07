using System;
using UnityEngine;
using UnityEngine.Events;

namespace UMA
{
	[Serializable]
	public class UMARandomAvatarEvent : UnityEvent<GameObject, GameObject>
	{
		public UMARandomAvatarEvent()
		{
		}

		public UMARandomAvatarEvent(UMARandomAvatarEvent source)
		{
		}
	}
}
