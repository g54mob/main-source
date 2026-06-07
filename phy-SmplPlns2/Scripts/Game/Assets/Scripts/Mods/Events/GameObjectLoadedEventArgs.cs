using System;
using UnityEngine;

namespace Assets.Scripts.Mods.Events
{
	public class GameObjectLoadedEventArgs : EventArgs
	{
		public GameObject GameObject { get; private set; }

		public GameObjectLoadedEventArgs(GameObject obj)
		{
			GameObject = obj;
		}
	}
}
