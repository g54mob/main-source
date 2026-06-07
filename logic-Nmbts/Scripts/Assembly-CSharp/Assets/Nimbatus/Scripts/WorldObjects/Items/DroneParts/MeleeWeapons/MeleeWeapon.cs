using System.Collections.Generic;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Behaviours.Health;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.MeleeWeapons
{
	public class MeleeWeapon : BindableDronePart
	{
		public float Damage;

		public virtual bool DealDamage(GameObject go, float damage)
		{
			if (go == null)
			{
				return false;
			}
			if (go.layer == RootDrone.RootDronePart.gameObject.layer)
			{
				return false;
			}
			go.SendMessage("TakeDamage", new DamageInformation(damage, EDamageReason.Player, this), SendMessageOptions.DontRequireReceiver);
			return true;
		}

		public override string GetDetailedTooltip()
		{
			string text = base.GetDetailedTooltip() + LabelHelper.NewLine;
			return text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/Damage") + ": " + LabelHelper.Orange + Damage;
		}

		public override List<KeyBinding> GetKeyBindings()
		{
			return new List<KeyBinding>();
		}
	}
}
