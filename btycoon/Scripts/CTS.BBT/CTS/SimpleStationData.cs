using CTS.Core;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS
{
	public abstract class SimpleStationData : ScriptableObject
	{
		[SerializeField]
		private SerializableDictionary<StringKey, ActionData[]> _actions = new SerializableDictionary<StringKey, ActionData[]>();

		[SerializeField]
		private SerializableDictionary<StringKey, AnimationClip[]> _stationAnimations = new SerializableDictionary<StringKey, AnimationClip[]>();

		public ReadOnlyDictionary<StringKey, ActionData[]> Actions => _actions;

		public ReadOnlyDictionary<StringKey, AnimationClip[]> StationAnimations => _stationAnimations;

		public AnimationClip GetAnimation(StringKey key)
		{
			if (_stationAnimations.TryGetValue(key, out var value))
			{
				return value.GetRandom();
			}
			return null;
		}
	}
}
