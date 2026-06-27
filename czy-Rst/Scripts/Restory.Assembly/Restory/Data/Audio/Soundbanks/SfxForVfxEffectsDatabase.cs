using FMODUnity;
using UnityEngine;

namespace Restory.Data.Audio.Soundbanks
{
	[CreateAssetMenu(menuName = "Restory/SoundBanks/SfxForVfxEffectsDatabase", fileName = "SfxForVfxEffectsDatabase")]
	public class SfxForVfxEffectsDatabase : ScriptableObject
	{
		[SerializeField]
		private EventReference perfectDeviceCheckSound;

		public EventReference PerfectDeviceCheckSound => perfectDeviceCheckSound;
	}
}
