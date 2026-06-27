using FMODUnity;
using UnityEngine;

namespace Restory.Data.Audio.SoundBanks
{
	[CreateAssetMenu(menuName = "Restory/SoundBanks/RecycleServiceSfxSoundsDatabase", fileName = "RecycleServiceSfxSoundsDatabase")]
	public class RecycleServiceSfxSoundsDatabase : ScriptableObject
	{
		[SerializeField]
		private EventReference objectRecycledSound;

		public EventReference ObjectRecycledSound => objectRecycledSound;
	}
}
