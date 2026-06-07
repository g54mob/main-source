using System;
using UnityEngine;

namespace Jundroo.ModTools.Events
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
