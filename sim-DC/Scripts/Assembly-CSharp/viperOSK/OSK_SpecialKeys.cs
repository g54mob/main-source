using System;
using UnityEngine;
using UnityEngine.Events;

namespace viperOSK
{
	[Serializable]
	public class OSK_SpecialKeys
	{
		public OSK_KeyCode keycode;

		public string name;

		public Color col;

		public float x_size;

		public int keySoundCode;

		public UnityEvent<OSK_KeyCode, OSK_Receiver> specialAction;

		public OSK_SpecialKeys(OSK_KeyCode k, string n, Color c, float s)
		{
		}
	}
}
