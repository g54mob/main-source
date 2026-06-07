using System;
using UnityEngine;

namespace Gh.Tk
{
	public class SpawnItemEventArgs : EventArgs
	{
		public GameObject ObjectToSpawn;

		public SpawnItemEventArgs(GameObject objectToSpawn)
		{
		}
	}
}
