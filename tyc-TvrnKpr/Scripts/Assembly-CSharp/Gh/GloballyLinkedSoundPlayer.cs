using System.Collections.Generic;
using AK.Wwise;

namespace Gh
{
	public class GloballyLinkedSoundPlayer : BaseSoundPlayer
	{
		private static List<GloballyLinkedSoundPlayer> _linkedPlayers;

		private List<SimpleSoundPlayer> _ourSoundPlayers;

		public static GloballyLinkedSoundPlayer GetLinkedPlayer(SimpleSoundPlayer theirSoundPlayer, string eventId = null)
		{
			return null;
		}

		public static void PlayGlobalSound(SimpleSoundPlayer theirSoundPlayer, Event soundEvent = null)
		{
		}

		public static void StopGlobalSound(SimpleSoundPlayer theirSoundPlayer, Event soundEvent = null)
		{
		}

		protected override void Awake()
		{
		}

		protected void OnDestroy()
		{
		}

		protected override void LateUpdate()
		{
		}

		protected override void UpdateLargeMode()
		{
		}
	}
}
