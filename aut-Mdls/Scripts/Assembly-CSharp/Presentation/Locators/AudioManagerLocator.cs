using Logic.Audio;
using UnityEngine;

namespace Presentation.Locators
{
	[CreateAssetMenu(menuName = "Locators/AudioManager", fileName = "AudioManagerLocator", order = 0)]
	public class AudioManagerLocator : ScriptableObject
	{
		public AudioManager AudioManager;
	}
}
