using Febucci.TextAnimatorCore.Time;
using UnityEngine;

namespace Febucci.TextAnimatorForUnity
{
	public class UnityEngineProvider : IEngineProvider
	{
		public static readonly UnityEngineProvider Instance = new UnityEngineProvider();

		public float GetCurrentDeltaTime(TimeScale scale)
		{
			if (scale != TimeScale.Scaled)
			{
				return Time.unscaledDeltaTime;
			}
			return Time.deltaTime;
		}
	}
}
