using System;
using System.Collections.Generic;
using UnityEngine;

namespace Data.Save
{
	[Serializable]
	public struct BoxSaveData
	{
		public bool IsOpen;

		public List<string> ContentGUIDs;

		public Vector3 Position;
	}
}
