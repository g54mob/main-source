using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Behaviours.Health;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.MeleeWeapons
{
	public class Spike : MeleeWeapon
	{
		public float MaxDamage;

		public float MinDamageSpeed;

		public float MaxDamageSpeed;

		public ParticleSystem HitParticleSystem;

		public string HitSound;

		public override void OnCollisionEnter(Collision col)
		{
			float num = Mathf.Lerp(Damage, MaxDamage, (Rigidbody.velocity.magnitude - MinDamageSpeed) / (MaxDamageSpeed - MinDamageSpeed));
			if (num > 0f && DealDamage(col.contacts[0].otherCollider.gameObject, num))
			{
				if (HitParticleSystem != null)
				{
					HitParticleSystem.Play();
				}
				if (!string.IsNullOrEmpty(HitSound))
				{
					AudioController.Play(HitSound);
				}
			}
		}

		public void OnCollisionStay(Collision col)
		{
			if (HitParticleSystem != null)
			{
				HitParticleSystem.Stop();
			}
		}

		public void OnCollisionExit(Collision col)
		{
			if (HitParticleSystem != null)
			{
				HitParticleSystem.Stop();
			}
		}

		public override string GetDetailedTooltip()
		{
			string text = "";
			text = text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/HP") + ": " + LabelHelper.Orange + GetComponent<HealthPool>().ActiveMaxHealth + " ";
			text = text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/Mass") + ": " + LabelHelper.Orange + GetComponent<Rigidbody>().mass + LabelHelper.NewLine;
			return text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/Damage") + ": " + LabelHelper.Orange + Damage + " - " + MaxDamage;
		}
	}
}
