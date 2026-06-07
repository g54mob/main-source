using UnityEngine;

namespace ModApi.Audio
{
	public interface ISingleSound
	{
		float MaxVolume { get; set; }

		void AddPosition(Vector3 position, float volume);

		void NewFrame();
	}
}
