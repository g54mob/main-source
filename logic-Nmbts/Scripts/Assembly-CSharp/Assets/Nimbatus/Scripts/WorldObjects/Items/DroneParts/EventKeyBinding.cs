using System;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.SensorParts;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts
{
	[Serializable]
	public class EventKeyBinding : KeyBinding
	{
		public EventKeyBinding(string name, KeyCode key, bool required = false)
			: base(name, key, required)
		{
		}

		public void PressKey(bool press, EventKeyHub hub)
		{
			if (hub != null)
			{
				hub.PressKey(press, KeyCode);
				hub.PressKey(press, StringCode);
			}
		}
	}
}
