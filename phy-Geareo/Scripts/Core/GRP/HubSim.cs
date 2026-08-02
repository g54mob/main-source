using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GRP
{
	public class HubSim : MonoBehaviour
	{
		public Hub hub;

		public List<Key> keyboardKeys;

		public Dictionary<Key, bool> keyboardValues;

		public Dictionary<int, bool> currentKeyboardValues;

		public Dictionary<int, bool> lastKeyboardValues;

		public Dictionary<ChannelId, List<HubReceiver>> receivers;

		public void Init(Hub hub)
		{
		}

		public void ReadKeyboard()
		{
		}

		public void SetupKeyboard()
		{
		}

		public void ReadGlobal()
		{
		}

		public void ShiftReceivers()
		{
		}

		public void AddReceiver(ChannelId channel, HubReceiver receiver)
		{
		}

		public bool GetKey(Key key)
		{
			return false;
		}
	}
}
