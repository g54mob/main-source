using UnityEngine;

namespace Motorways.Audio
{
	public interface IAudioView
	{
		Vector2 Pan { get; }

		float Attenuation { get; }

		Transform transform { get; }

		float GetAttenuation(bool zoom, float falloffFactor = 5f);
	}
}
