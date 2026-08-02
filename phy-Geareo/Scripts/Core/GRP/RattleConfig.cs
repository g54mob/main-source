using System.Collections.Generic;
using Rhizomatic;
using UnityEngine;

namespace GRP
{
	[CreateAssetMenu(menuName = "GRP/Main/RattleConfig", fileName = "RattleConfig")]
	[AssetCreator(typeof(MainAssetCategory))]
	public class RattleConfig : ScriptableObject
	{
		public AnimationCurve pitchOverVelocity;

		public AnimationCurve volumeOverVelocity;

		public AnimationCurve volumeOverImpact;

		public AnimationCurve rollPitchOverVelocity;

		public AnimationCurve rollVolumeOverVelocity;

		public float minIntensity;

		public int contactLifeTime;

		public List<RattleContactConfig> contacts;

		public RattleContactConfig GetContactConfig(PhysicsMaterial a, PhysicsMaterial b)
		{
			return null;
		}
	}
}
