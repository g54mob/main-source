using System;
using UnityEngine;

namespace Simulator
{
	[Serializable]
	public class BoxSaveState
	{
		public int uid;

		public bool grabbed;

		public bool open;

		public Vector3 position;

		public Quaternion rotation;

		public BoxSaveState(int uid, bool grabbed, bool open, Vector3 position, Quaternion rotation)
		{
			this.uid = uid;
			this.grabbed = grabbed;
			this.open = open;
			this.position = position;
			this.rotation = rotation;
		}
	}
}
