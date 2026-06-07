using CTS.Core;
using UnityEngine;

namespace CTS.Utilities
{
	public class ObjectToggleGroupByKey : CTSBehaviour
	{
		[SerializeField]
		private SerializableDictionary<StringKey, GameObject[]> _objectGroups;

		[field: SerializeField]
		public StringKey DefaultMode { get; private set; }

		public StringKey LastDisplayedMode { get; private set; }

		protected override void OnAwake()
		{
			base.OnAwake();
			Swap(DefaultMode);
		}

		public void Swap(ScriptableStringKey key)
		{
			Swap(key.Key);
		}

		public void Swap(StringKey key)
		{
			if (!_objectGroups.TryGetValue(key, out var value))
			{
				return;
			}
			GameObject[] array;
			if (LastDisplayedMode.IsValid() && _objectGroups.TryGetValue(LastDisplayedMode, out var value2))
			{
				array = value2;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].SetActive(value: false);
				}
			}
			LastDisplayedMode = key;
			array = value;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetActive(value: true);
			}
		}
	}
}
