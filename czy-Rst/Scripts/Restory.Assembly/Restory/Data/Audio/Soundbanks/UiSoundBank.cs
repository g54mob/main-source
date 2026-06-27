using FMODUnity;
using UnityEngine;

namespace Restory.Data.Audio.SoundBanks
{
	[CreateAssetMenu(menuName = "Restory/UI Sound Banks/General Sounds", fileName = "UI Sound Bank - Main")]
	public class UiSoundBank : ScriptableObject
	{
		[SerializeField]
		private EventReference clickSound;

		public EventReference ClickSound => clickSound;
	}
}
