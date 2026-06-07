using UnityEngine;

namespace viperOSK
{
	public class OSK_LongPressPacket
	{
		public string character;

		public OSK_KeyCode keyCode;

		public GameObject keyObj;

		public string keyPressType;

		public OSK_LongPressPacket(string c, OSK_KeyCode code, GameObject obj, string pressType)
		{
		}
	}
}
