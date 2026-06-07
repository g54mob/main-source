using UnityEngine;

namespace GameCreator.Runtime.Common.Audio
{
	public interface IAudioConfig
	{
		float Volume { get; }

		float Pitch { get; }

		float TransitionIn { get; }

		float SpatialBlend { get; }

		TimeMode.UpdateMode UpdateMode { get; }

		GameObject GetTrackTarget(Args args);
	}
}
