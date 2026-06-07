using System;
using UnityEngine;

namespace viperOSK
{
	[Serializable]
	public class OSK_KeyTypeMeta
	{
		public OSK_KEY_TYPES keyType;

		public Color col;

		public int keySoundCode;

		public static OSK_KEY_TYPES KeyType(OSK_KeyCode key)
		{
			return default(OSK_KEY_TYPES);
		}

		public OSK_KeyTypeMeta()
		{
		}

		public OSK_KeyTypeMeta(OSK_KEY_TYPES kt, Color c)
		{
		}
	}
}
