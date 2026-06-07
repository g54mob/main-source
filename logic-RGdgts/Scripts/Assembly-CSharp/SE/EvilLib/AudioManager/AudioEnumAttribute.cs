using UnityEngine;

namespace SE.EvilLib.AudioManager
{
	public class AudioEnumAttribute : PropertyAttribute
	{
		public AudioCategory audioCategory;

		public AudioEnumAttribute(AudioCategory category)
		{
		}
	}
}
