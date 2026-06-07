using UnityEngine;

namespace GameCreator.Runtime.Common
{
	public interface IMaterialSound
	{
		float Volume { get; }

		AudioClip Audio { get; }

		PoolField Impact { get; }
	}
}
