using System.Collections.Generic;
using CTS.Core;
using UnityEngine;

namespace CTS.BBT.AI
{
	[CreateAssetMenu(fileName = "New Animation State Collection", menuName = "CTS/Animation State Collection")]
	public class AnimationStateCollection : ScriptableObject
	{
		[SerializeField]
		private SerializableDictionary<AnimKey, CTSLinearMixerTransition> _newMixers;

		[SerializeField]
		private SerializableDictionary<AnimKey, CTSClipTransition> _newPunctual;

		public bool TryGet(AnimKey key, out ICTSTransition transition)
		{
			if (_newPunctual.TryGetValue(key, out var value))
			{
				transition = value;
				return true;
			}
			if (_newMixers.TryGetValue(key, out var value2))
			{
				transition = value2;
				return true;
			}
			transition = null;
			return false;
		}

		public IEnumerable<CTSLinearMixerTransition> GetMixers()
		{
			foreach (CTSLinearMixerTransition value in _newMixers.Values)
			{
				yield return value;
			}
		}
	}
}
