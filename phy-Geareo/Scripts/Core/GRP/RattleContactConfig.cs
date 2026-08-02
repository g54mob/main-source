using Rhizomatic;
using UnityEngine;

namespace GRP
{
	[CreateAssetMenu(menuName = "GRP/Main/RattleContactConfig", fileName = "RattleContactConfig")]
	[AssetCreator(typeof(MainAssetCategory))]
	public class RattleContactConfig : ScriptableObject
	{
		public PhysicsMaterial[] colliderA;

		public PhysicsMaterial[] colliderB;

		public RattleEmitterConfig emitter;

		public float impactForce;

		public float impactDelta;

		public float rollForce;

		public int rollTime;

		public bool Check(PhysicsMaterial a, PhysicsMaterial b)
		{
			return false;
		}

		public bool _Check(PhysicsMaterial a, PhysicsMaterial b)
		{
			return false;
		}
	}
}
