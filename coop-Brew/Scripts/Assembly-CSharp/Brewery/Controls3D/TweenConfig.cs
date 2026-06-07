using System;
using UnityEngine;

namespace Brewery.Controls3D
{
	[Serializable]
	public struct TweenConfig
	{
		[Min(0.01f)]
		public float duration;

		public LeanTweenType easeType;

		[Min(0f)]
		public float delay;

		public TweenConfig(float duration, LeanTweenType easeType, float delay = 0f)
		{
			this.duration = 0f;
			this.easeType = default(LeanTweenType);
			this.delay = 0f;
		}
	}
}
