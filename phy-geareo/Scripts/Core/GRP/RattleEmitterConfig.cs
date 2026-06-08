using Rhizomatic;
using UnityEngine;

namespace GRP
{
	[CreateAssetMenu(menuName = "GRP/Main/RattleEmitterConfig", fileName = "RattleEmitterConfig")]
	[AssetCreator(typeof(MainAssetCategory))]
	public class RattleEmitterConfig : ScriptableObject
	{
		public float maxDistance;

		public AnimationCurve maxAngleOverDistance;

		public int lifeTime;

		public int maxCount;

		public int impactTimer;

		public float impactLargeForce;

		public float impactSweatForce;

		public float sweatVol;

		public AnimationCurve volumeMultiplierOverCount;

		[Header("Debug")]
		public bool noSlide;

		public bool noRoll;

		public bool noImpact;

		public bool noImpactLong;

		public bool noImpactSweat;

		[Header("Clips")]
		public AudioClip[] slideClips;

		public AudioClip[] rollClips;

		public AudioClip[] impactClips;

		public AudioClip[] largeImpactClips;

		public AudioClip[] sweatImpactClips;

		public RattleBankImpactVolume[] impacts;

		public AudioClip GetSlideClip()
		{
			return null;
		}

		public AudioClip GetRollClip()
		{
			return null;
		}

		public AudioClip GetImpactClip()
		{
			return null;
		}
	}
}
