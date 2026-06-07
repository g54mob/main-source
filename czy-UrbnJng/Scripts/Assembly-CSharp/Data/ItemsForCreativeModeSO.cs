using System;
using UnityEngine;

namespace Data
{
	[CreateAssetMenu]
	public class ItemsForCreativeModeSO : ScriptableObject
	{
		public int Level;

		public string guid;

		public GameObject prefab;

		public Sprite sprite;

		private void OnValidate()
		{
			if (string.IsNullOrEmpty(guid))
			{
				guid = Guid.NewGuid().ToString();
			}
		}
	}
}
