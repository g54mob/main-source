using DV.Damage;
using DV.Localization;
using DV.UI.LocoHUD;
using DV.Utils;
using UnityEngine;

namespace DV.HUD
{
	public class DamageInterfacer : MonoBehaviour
	{
		private const float DISABLED_ALPHA = 0.25f;

		private const string DISABLED_STRING = "-";

		private HUDManager manager;

		private void Start()
		{
			manager = SingletonBehaviour<HUDManager>.Instance;
			SingletonBehaviour<HUDInterfacer>.Instance.HUDChanged += HUDChanged;
			manager.DamageMenu.cargo.SetTextValue("");
			manager.DamageMenu.cargo.SetTextUnit("");
		}

		private void HUDChanged(HUDInterfacer.HUDChangeEvent obj)
		{
			if ((bool)obj.oldBase)
			{
				DamageController component = obj.oldBase.car.GetComponent<DamageController>();
				if ((bool)component)
				{
					component.bodyDamage.CarEffectiveHealthStateUpdate -= BodyHealthUpdated;
					if (component.mechanicalPT != null)
					{
						component.mechanicalPT.HealthPercentageChanged -= MechanicalPowertrainHealthUpdated;
					}
					if (component.electricalPT != null)
					{
						component.electricalPT.HealthPercentageChanged -= ElectricPowertrainHealthUpdated;
					}
					if (component.wheels != null)
					{
						component.wheels.HealthPercentageChanged -= WheelsHealthUpdated;
					}
				}
			}
			if (!obj.newBase)
			{
				return;
			}
			DamageController component2 = obj.newBase.car.GetComponent<DamageController>();
			if ((bool)component2)
			{
				component2.bodyDamage.CarEffectiveHealthStateUpdate += BodyHealthUpdated;
				if (component2.mechanicalPT != null)
				{
					component2.mechanicalPT.HealthPercentageChanged += MechanicalPowertrainHealthUpdated;
					MechanicalPowertrainHealthUpdated(component2.mechanicalPT.HealthPercentage100Notation);
				}
				else
				{
					manager.DamageMenu.mechanicalPT.SetTextValue("-");
				}
				if (component2.electricalPT != null)
				{
					component2.electricalPT.HealthPercentageChanged += ElectricPowertrainHealthUpdated;
					ElectricPowertrainHealthUpdated(component2.electricalPT.HealthPercentage100Notation);
				}
				else
				{
					manager.DamageMenu.electricalPT.SetTextValue("-");
				}
				if (component2.wheels != null)
				{
					component2.wheels.HealthPercentageChanged += WheelsHealthUpdated;
					WheelsHealthUpdated(component2.wheels.HealthPercentage100Notation);
				}
				else
				{
					manager.DamageMenu.wheelsNBrakes.SetTextValue("-");
				}
				manager.DamageMenu.mechanicalPT.SetVisualLevel((component2.mechanicalPT != null) ? 1f : 0.25f);
				manager.DamageMenu.electricalPT.SetVisualLevel((component2.electricalPT != null) ? 1f : 0.25f);
				manager.DamageMenu.wheelsNBrakes.SetVisualLevel((component2.wheels != null) ? 1f : 0.25f);
				manager.DamageMenu.cargo.SetTextValue("-");
				manager.DamageMenu.cargo.SetVisualLevel(0.25f);
				BodyHealthUpdated(component2.bodyDamage.EffectiveHealthPercentage100Notation);
			}
		}

		private void BodyHealthUpdated(float value)
		{
			manager.DamageMenu.body.SetTextValue(value.ToString("N0", LocalizationAPI.CC) + "%");
		}

		private void MechanicalPowertrainHealthUpdated(float value)
		{
			manager.DamageMenu.mechanicalPT.SetTextValue(value.ToString("N0", LocalizationAPI.CC) + "%");
		}

		private void ElectricPowertrainHealthUpdated(float value)
		{
			manager.DamageMenu.electricalPT.SetTextValue(value.ToString("N0", LocalizationAPI.CC) + "%");
		}

		private void WheelsHealthUpdated(float value)
		{
			manager.DamageMenu.wheelsNBrakes.SetTextValue(value.ToString("N0", LocalizationAPI.CC) + "%");
		}
	}
}
