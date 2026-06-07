using System;
using SettingScripts;
using UnityEngine;

namespace SimulationScripts.BibiteScripts
{
	public class BibitePart : MonoBehaviour
	{
		[SerializeField]
		private BibiteBody mainBody;

		private bool isStarted;

		[NonSerialized]
		public Collider2D partCollider;

		private static readonly FloatSetting CollisionDamageConstant = ScenarioSettings.Instance.collisionDamageConstant;

		private static readonly FloatSetting CollisionDamageThreshold = ScenarioSettings.Instance.collisionDamageThreshold;

		private static float collisionDamageConstant = CollisionDamageConstant.SubscribeTo<FloatSetting, float>(UpdateCollisionDamageConstant);

		private static float collisionDamageThreshold = CollisionDamageThreshold.SubscribeTo<FloatSetting, float>(UpdateCollisionDamageThreshold);

		private static void UpdateCollisionDamageConstant(float val)
		{
			collisionDamageConstant = val;
		}

		private static void UpdateCollisionDamageThreshold(float val)
		{
			collisionDamageThreshold = val;
		}

		public void StartPart()
		{
			partCollider = GetComponent<Collider2D>();
			isStarted = true;
		}

		public BibiteBody GetMainBody()
		{
			return mainBody;
		}

		private void OnCollisionEnter2D(Collision2D other)
		{
			if (isStarted && !Mathf.Approximately(collisionDamageConstant, 0f) && !partCollider.isTrigger)
			{
				mainBody.onBodyCollided.Invoke(other.gameObject);
				float num = Vector2.Dot(other.GetContact(0).normal, other.relativeVelocity);
				float mass = other.otherRigidbody.mass;
				float num2 = 2f * mass * num / (mass + mainBody.mass);
				if (!(num2 < collisionDamageThreshold))
				{
					float dmg = (num2 - collisionDamageThreshold) * collisionDamageConstant;
					mainBody.Hurting(dmg);
				}
			}
		}
	}
}
