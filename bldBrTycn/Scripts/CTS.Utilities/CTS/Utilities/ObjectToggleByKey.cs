using System;
using CTS.Core;
using UnityEngine;

namespace CTS.Utilities
{
	public class ObjectToggleByKey : CTSBehaviour
	{
		[Serializable]
		private struct Swapper
		{
			public GameObject[] Enable;

			public GameObject[] Disable;
		}

		[SerializeField]
		private SerializableDictionary<StringKey, Swapper> _swappers;

		[field: SerializeField]
		public StringKey DefaultMode { get; private set; }

		public StringKey LastDisplayedMode { get; private set; }

		protected override void OnAwake()
		{
			base.OnAwake();
			Swap(DefaultMode);
		}

		public void Swap(StringKey key)
		{
			if (!_swappers.TryGetValue(key, out var value))
			{
				return;
			}
			LastDisplayedMode = key;
			GameObject[] enable = value.Enable;
			foreach (GameObject gameObject in enable)
			{
				if ((bool)gameObject)
				{
					gameObject.SetActive(value: true);
				}
			}
			enable = value.Disable;
			foreach (GameObject gameObject2 in enable)
			{
				if ((bool)gameObject2)
				{
					gameObject2.SetActive(value: false);
				}
			}
		}
	}
}
