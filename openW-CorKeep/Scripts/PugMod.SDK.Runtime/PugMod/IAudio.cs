using UnityEngine;

namespace PugMod
{
	public interface IAudio
	{
		void PlaySfx(int sfxTableID, Vector3 position, Transform transformToFollow = null, float volumeMultiplier = 1f, float pitchMultiplier = 1f, int sfxType = 2);
	}
}
