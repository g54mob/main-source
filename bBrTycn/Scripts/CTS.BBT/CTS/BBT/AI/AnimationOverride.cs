using System;
using UnityEngine;

namespace CTS.BBT.AI
{
	[Serializable]
	public class AnimationOverride
	{
		[field: SerializeField]
		public int Priority { get; private set; }

		[field: SerializeField]
		public AnimationStateCollection AnimationCollection { get; private set; }
	}
}
