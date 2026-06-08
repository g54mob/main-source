using UnityEngine;

namespace GRP
{
	public class RattleEmitter
	{
		public Vector3 position;

		public Vector3 targetPosition;

		public AudioSource slideSource;

		public AudioSource rollSource;

		public float slideTarget;

		public float rollTarget;

		public float impactTarget;

		public RattleScene scene;

		public RattleEmitterConfig config;

		public int count;

		public int lifeTime;

		public int impactTimer;

		public bool hasImpact;

		public RattleEmitter(RattleScene scene, RattleContact contact)
		{
		}

		public void Reset()
		{
		}

		public bool CanAddContact(RattleContact contact)
		{
			return false;
		}

		public void AddContact(RattleContact contact)
		{
		}

		public void Update(float dt)
		{
		}

		public AudioSource NewSource()
		{
			return null;
		}

		public void Destroy()
		{
		}

		public void OnDrawGizmos()
		{
		}
	}
}
