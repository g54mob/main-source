using System.Collections.Generic;
using MG_BlocksEngine2.Block;
using UnityEngine.Events;

namespace MG_BlocksEngine2.Core
{
	public class BE2_EventsManager
	{
		private Dictionary<BE2EventTypes, UnityEvent> _eventDictionary;

		private Dictionary<BE2EventTypesBlock, BE2_Event> _eventDictionaryBlock;

		public BE2_EventsManager()
		{
			if (_eventDictionary == null)
			{
				_eventDictionary = new Dictionary<BE2EventTypes, UnityEvent>();
			}
			if (_eventDictionaryBlock == null)
			{
				_eventDictionaryBlock = new Dictionary<BE2EventTypesBlock, BE2_Event>();
			}
		}

		public void StartListening(BE2EventTypes eventName, UnityAction listener)
		{
			UnityEvent value = null;
			if (_eventDictionary.TryGetValue(eventName, out value))
			{
				value.AddListener(listener);
				return;
			}
			value = new UnityEvent();
			value.AddListener(listener);
			_eventDictionary.Add(eventName, value);
		}

		public void StartListening(BE2EventTypesBlock eventName, UnityAction<I_BE2_Block> listener)
		{
			BE2_Event value = null;
			if (_eventDictionaryBlock.TryGetValue(eventName, out value))
			{
				value.AddListener(listener);
				return;
			}
			value = new BE2_Event();
			value.AddListener(listener);
			_eventDictionaryBlock.Add(eventName, value);
		}

		public void StopListening(BE2EventTypes eventName, UnityAction listener)
		{
			UnityEvent value = null;
			if (_eventDictionary.TryGetValue(eventName, out value))
			{
				value.RemoveListener(listener);
			}
		}

		public void StopListening(BE2EventTypesBlock eventName, UnityAction<I_BE2_Block> listener)
		{
			BE2_Event value = null;
			if (_eventDictionaryBlock.TryGetValue(eventName, out value))
			{
				value.RemoveListener(listener);
			}
		}

		public void TriggerEvent(BE2EventTypes eventName)
		{
			UnityEvent value = null;
			if (_eventDictionary.TryGetValue(eventName, out value))
			{
				value.Invoke();
			}
		}

		public void TriggerEvent(BE2EventTypesBlock eventName, I_BE2_Block block)
		{
			BE2_Event value = null;
			if (_eventDictionaryBlock.TryGetValue(eventName, out value))
			{
				value.Invoke(block);
			}
		}
	}
}
