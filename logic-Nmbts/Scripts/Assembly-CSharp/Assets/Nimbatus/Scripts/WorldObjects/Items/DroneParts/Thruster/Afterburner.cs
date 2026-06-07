using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Behaviours.Health;
using Assets.Nimbatus.Scripts.ResourceCollection;
using Assets.Nimbatus.Scripts.WorldObjects.DronePerks.Effects;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Thruster
{
	public class Afterburner : BindableDronePart, IFuelConsumer, IThruster
	{
		public float Force = 200f;

		public float FuelPerSecond = 16f;

		public float ActivationVelocity = 150f;

		public Renderer SpeedZone;

		public ParticleSystem[] Particles;

		public string ThusterSound;

		private KeyBinding _giveThrust;

		private float _thrustModifier;

		private bool _useEnergyAsFuel;

		private bool _improvedAfterburner;

		public override List<KeyBinding> GetKeyBindings()
		{
			_giveThrust = new KeyBinding("Activate", KeyCode.W);
			return new List<KeyBinding> { _giveThrust };
		}

		public override void InitDronePerkSettings(List<DroneEffect> effects)
		{
			base.InitDronePerkSettings(effects);
			_thrustModifier = 1f;
			if (effects != null)
			{
				ThrusterEffect thrusterEffect = effects.OfType<ThrusterEffect>().FirstOrDefault();
				if (thrusterEffect != null)
				{
					_thrustModifier = (float)(100 + thrusterEffect.ThrustIncrease) / 100f;
				}
				_useEnergyAsFuel = effects.OfType<SuperchargedBatteries>().Any();
				_improvedAfterburner = effects.OfType<ImprovedAfterburner>().Any();
			}
			else
			{
				_improvedAfterburner = false;
				_useEnergyAsFuel = false;
			}
		}

		protected override void Start()
		{
			base.Start();
			SpeedZone.material.color = Color.red;
		}

		public override void FixedUpdate()
		{
			if (Rigidbody == null)
			{
				Rigidbody = GetComponentInParent<Rigidbody>();
			}
			if (IsBroken || !CanControlDrone || HealthPool.CurrentState == EChemicalState.Frozen)
			{
				EnableParticles(false);
				return;
			}
			float magnitude = Rigidbody.velocity.magnitude;
			SpeedZone.material.SetFloat("_Cutoff", 1f / ActivationVelocity * magnitude);
			bool flag = magnitude >= ActivationVelocity;
			if (_improvedAfterburner)
			{
				flag = true;
				SpeedZone.material.SetFloat("_Cutoff", 1f);
			}
			if (flag)
			{
				SpeedZone.material.color = Color.green;
			}
			else
			{
				SpeedZone.material.color = Color.red;
			}
			bool enable = false;
			if (IsActive())
			{
				EResourceType mat = (_useEnergyAsFuel ? EResourceType.Energy : EResourceType.Fuel);
				if (_giveThrust.IsPressed(KeyEventHub) && flag)
				{
					float amount = FuelPerSecond * Time.fixedDeltaTime;
					if (base.CurrentResourceHub.HasResource(mat, amount))
					{
						if (Rigidbody != null)
						{
							Rigidbody.AddForceAtPosition(base.transform.right * Force * _thrustModifier * 20f, base.transform.position, ForceMode.Force);
						}
						base.CurrentResourceHub.UseResourceFromParts(mat, amount);
						enable = true;
					}
				}
			}
			EnableParticles(enable);
			base.FixedUpdate();
		}

		private void EnableParticles(bool enable)
		{
			ParticleSystem[] particles = Particles;
			for (int i = 0; i < particles.Length; i++)
			{
				ParticleSystem.EmissionModule emission = particles[i].emission;
				emission.enabled = enable;
			}
			if (enable)
			{
				StartSoundLoop(ThusterSound);
			}
			else
			{
				StopActiveSoundLoop();
			}
		}

		public override string GetDetailedTooltip()
		{
			string text = base.GetDetailedTooltip() + LabelHelper.NewLine;
			if (!_improvedAfterburner)
			{
				text = text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/RequiredSpeed") + ": " + LabelHelper.Orange + ActivationVelocity + LabelHelper.NewLine;
			}
			text = text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/ThrustForce") + ": " + LabelHelper.Orange + Force + LabelHelper.NewLine;
			if (_useEnergyAsFuel)
			{
				return text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/EnergyPerSecond") + ": " + LabelHelper.Orange + FuelPerSecond;
			}
			return text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/FuelPerSecond") + ": " + LabelHelper.Orange + FuelPerSecond;
		}

		public bool IsThrusterAlive()
		{
			if (!IsBroken && !HealthPool.IsDead)
			{
				return HealthPool.CurrentState != EChemicalState.Frozen;
			}
			return false;
		}

		public float GetCurrentThrust()
		{
			return Force;
		}

		public void SetCurrentThrust(float thrust)
		{
			Force = thrust;
		}
	}
}
