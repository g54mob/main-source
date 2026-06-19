using UnityEngine;

namespace PugMod
{
	public interface IEffects
	{
		void PlayPuff(int puffId, Vector3 position, int particleCount = 10);

		void PlayTempSprite(int tempSpriteId, Vector3 position, float scale = 1f, float lifetime = 1f, float positionDev = 0f, bool looping = false);
	}
}
