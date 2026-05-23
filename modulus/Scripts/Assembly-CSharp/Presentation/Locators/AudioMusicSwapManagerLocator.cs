using Logic.Audio;
using UnityEngine;

namespace Presentation.Locators
{
	[CreateAssetMenu(menuName = "Locators/AudioMusicSwapManagerLocator", fileName = "AudioMusicSwapManagerLocator", order = 0)]
	public class AudioMusicSwapManagerLocator : ScriptableObject
	{
		public AudioMusicSwapManager MusicSwapManager;
	}
}
