using Sirenix.Serialization;
using UnityEngine;

namespace KitchenData
{
	public struct AudioAsset : IAudioAsset
	{
		[OdinSerialize]
		private AudioClip Clip;

		public AudioClip GetClip => Clip;
	}
}
