using Rhizomatic;
using UnityEngine;

namespace GRP
{
	[CreateAssetMenu(menuName = "GRP/Main/AudioClipConfig", fileName = "AudioClipConfig")]
	[AssetCreator(typeof(MainAssetCategory))]
	public class AudioClipConfig : ScriptableObject
	{
		public AudioClip[] clips;

		public AudioClip clip => null;
	}
}
