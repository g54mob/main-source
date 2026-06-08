using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GRP
{
	public class HubReceiver : MonoBehaviour
	{
		public ChannelId channel;

		public HubSim hub { get; private set; }

		public List<Key> keys { get; }

		public Dictionary<Key, float> current { get; }

		public Dictionary<Key, float> next { get; }

		public void Setup(HubSim hub, ChannelId channel)
		{
		}

		public void Clear()
		{
		}

		public void RegisterKeys(params Key[] k)
		{
		}

		public void Shift()
		{
		}

		public void SetValue(Key key, float value)
		{
		}

		public void Set(Key key)
		{
		}

		public float GetValue(Key key)
		{
			return 0f;
		}

		public bool Get(Key key)
		{
			return false;
		}
	}
}
