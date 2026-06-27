using Helpers.Singletons;

namespace Mandragora.Audio
{
	public class SoundTrack : AudioTrack
	{
		protected override void Remove()
		{
			SingletonBehaviour<AudioManager>.Instance.RemoveSound(this);
		}
	}
}
