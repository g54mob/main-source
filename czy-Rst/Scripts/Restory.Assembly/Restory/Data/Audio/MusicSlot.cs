using Restory.Data.Base;
using UnityEngine;

namespace Restory.Data.Audio
{
	[CreateAssetMenu(fileName = "MusicSlot", menuName = "Restory/Audio/Music Slot", order = 6)]
	public class MusicSlot : RestoryEntityInfoBase
	{
		[SerializeField]
		private MusicTrack defaultMusicTrack;

		public MusicTrack DefaultMusicTrack => defaultMusicTrack;
	}
}
