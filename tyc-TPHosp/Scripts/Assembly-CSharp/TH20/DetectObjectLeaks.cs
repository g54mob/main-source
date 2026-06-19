#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TH20
{
	public class DetectObjectLeaks
	{
		private List<UnityEngine.Object> _objectSnapshot;

		public void Record()
		{
			_objectSnapshot = Resources.FindObjectsOfTypeAll(typeof(UnityEngine.Object)).ToList();
		}

		public void Report()
		{
			System.GC.Collect();
			List<UnityEngine.Object> list = Resources.FindObjectsOfTypeAll(typeof(UnityEngine.Object)).ToList();
			foreach (UnityEngine.Object item in _objectSnapshot)
			{
				list.Remove(item);
			}
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			foreach (UnityEngine.Object item2 in list)
			{
				string key = item2.GetType().ToString();
				if (dictionary.ContainsKey(key))
				{
					dictionary[key]++;
				}
				else
				{
					dictionary[key] = 1;
				}
			}
			if (dictionary.Count == 0)
			{
				return;
			}
			Logging.Warning(LogChannels.Unity, "Detected {0} object leak types", dictionary.Count);
			List<KeyValuePair<string, int>> list2 = new List<KeyValuePair<string, int>>(dictionary);
			list2.Sort((KeyValuePair<string, int> firstPair, KeyValuePair<string, int> nextPair) => nextPair.Value.CompareTo(firstPair.Value));
			foreach (KeyValuePair<string, int> item3 in list2)
			{
				Logging.Warning(LogChannels.Unity, "     {0}: {1}", item3.Key, item3.Value);
			}
		}
	}
}
