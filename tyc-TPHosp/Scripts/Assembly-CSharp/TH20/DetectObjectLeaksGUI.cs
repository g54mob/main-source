using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	public class DetectObjectLeaksGUI : MonoBehaviour
	{
		private void OnGUI()
		{
			Object[] array = Object.FindObjectsOfType(typeof(Object));
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			Object[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				string key = array2[i].GetType().ToString();
				if (dictionary.ContainsKey(key))
				{
					dictionary[key]++;
				}
				else
				{
					dictionary[key] = 1;
				}
			}
			List<KeyValuePair<string, int>> list = new List<KeyValuePair<string, int>>(dictionary);
			list.Sort((KeyValuePair<string, int> firstPair, KeyValuePair<string, int> nextPair) => nextPair.Value.CompareTo(firstPair.Value));
			GUI.Box(new Rect(0f, 0f, 400f, 600f), "");
			GUILayout.BeginArea(new Rect(0f, 0f, 400f, 600f));
			foreach (KeyValuePair<string, int> item in list)
			{
				GUILayout.Label(item.Key + ": " + item.Value);
			}
			GUILayout.EndArea();
		}
	}
}
