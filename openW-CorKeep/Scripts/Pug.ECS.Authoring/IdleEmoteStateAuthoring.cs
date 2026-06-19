using System;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class IdleEmoteStateAuthoring : MonoBehaviour
{
	[Serializable]
	public struct EmoteAnimation
	{
		public string animation;

		public float preIdleMinDuration;

		public float preIdleMaxDuration;

		public float duration;

		public bool mustBeOnWalkableGround;
	}

	public List<EmoteAnimation> emoteAnimations;

	public float minCooldown = 1f;

	public float maxCooldown = 3f;
}
