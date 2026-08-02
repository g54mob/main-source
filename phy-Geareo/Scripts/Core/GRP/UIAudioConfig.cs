using Rhizomatic;
using UnityEngine;

namespace GRP
{
	[CreateAssetMenu(menuName = "GRP/Main/UIAudioConfig", fileName = "UIAudioConfig")]
	[AssetCreator(typeof(MainAssetCategory))]
	public class UIAudioConfig : ScriptableObject
	{
		public AudioClip[] enter;

		public AudioClip[] exit;

		public AudioClip[] down;

		public AudioClip[] up;
	}
}
