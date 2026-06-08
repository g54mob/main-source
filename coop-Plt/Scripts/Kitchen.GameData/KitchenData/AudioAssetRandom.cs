using System.Collections.Generic;
using Sirenix.Serialization;
using UnityEngine;

namespace KitchenData
{
	public struct AudioAssetRandom : IAudioAsset
	{
		[OdinSerialize]
		private List<AudioClip> Clips;

		public AudioClip GetClip => Clips[Random.Range(0, Clips.Count)];
	}
}
