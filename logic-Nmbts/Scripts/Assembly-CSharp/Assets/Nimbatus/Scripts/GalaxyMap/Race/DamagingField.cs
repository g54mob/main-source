using Assets.Nimbatus.Scripts.Behaviours.Health;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Race
{
	public class DamagingField : RaceTrigger
	{
		public float Damage;

		public string DamageSound;

		protected override void Update()
		{
			base.Update();
			if (Colliders.Count > 0)
			{
				StartSoundLoop(DamageSound);
			}
			else
			{
				StopSoundLoop();
			}
		}

		public void OnTriggerStay(Collider other)
		{
			if (other.gameObject.layer == 9 || other.gameObject.layer == 27)
			{
				other.gameObject.SendMessage("TakeDamage", new DamageInformation(Damage * Time.deltaTime, EDamageReason.Environment), SendMessageOptions.DontRequireReceiver);
			}
		}
	}
}
