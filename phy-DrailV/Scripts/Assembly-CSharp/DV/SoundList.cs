using UnityEngine;

namespace DV
{
	[CreateAssetMenu(menuName = "DV/SoundList")]
	public class SoundList : ScriptableObject
	{
		public AudioClip[] clips;
	}
}
