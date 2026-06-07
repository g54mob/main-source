using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace viperOSK
{
	public class OSK_Settings : MonoBehaviour
	{
		[NonSerialized]
		public bool hasAccentedConsole;

		public float longPressDelay;

		public UnityEvent<OSK_LongPressPacket> longPressAction;

		[TextArea(1, 8)]
		public string physicalKeyboardLayout;

		public Dictionary<KeyCode, OSK_KeyCode> physicalKeyboardMap;

		public bool remapPhysicalKeyboard;

		public static OSK_Settings instance { get; private set; }

		public void SetLongPressAction(UnityAction<OSK_LongPressPacket> action)
		{
		}

		private void Awake()
		{
		}
	}
}
