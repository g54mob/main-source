using System;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class CombatEmoteStateAuthoring : MonoBehaviour
{
	[Serializable]
	public struct CombatEmoteAnimation
	{
		public string animation;

		public float duration;

		public float preCombatMinDuration;

		public float preCombatMaxDuration;
	}

	public float emoteInstantlyChance;

	public float minCooldown = 4f;

	public float maxCooldown = 6f;

	public List<CombatEmoteAnimation> emoteAnimations;
}
