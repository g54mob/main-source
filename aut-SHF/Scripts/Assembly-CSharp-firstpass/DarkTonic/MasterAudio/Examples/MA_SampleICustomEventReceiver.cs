using System.Collections.Generic;
using UnityEngine;

namespace DarkTonic.MasterAudio.Examples
{
	public class MA_SampleICustomEventReceiver : MonoBehaviour, ICustomEventReceiver
	{
		private readonly List<string> _eventsSubscribedTo;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		public void CheckForIllegalCustomEvents()
		{
		}

		public void ReceiveEvent(string customEventName, Vector3 originPoint)
		{
		}

		public bool SubscribesToEvent(string customEventName)
		{
			return false;
		}

		public void RegisterReceiver()
		{
		}

		public void UnregisterReceiver()
		{
		}

		public IList<AudioEventGroup> GetAllEvents()
		{
			return null;
		}
	}
}
