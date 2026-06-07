using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Behaviours.Health;
using Assets.Nimbatus.Scripts.Controls.Keybinds;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.ResourceCollection;
using Assets.Nimbatus.Scripts.Tutorial;
using Assets.Nimbatus.Scripts.WorldObjects.DronePerks.Effects;
using I2.Loc;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Thruster
{
	public class Thruster : BindableDronePart, IFuelConsumer, IThruster
	{
		public float Force = 100f;

		public float FuelPerSecond = 1f;

		public ParticleSystem[] Particles;

		public bool ChargeUp;

		[ShowIf("ChargeUp", true)]
		public Renderer ChargeRenderer;

		[ShowIf("ChargeUp", true)]
		public string ReleaseSound;

		private float _chargeAmount;

		private const float MaxChargeAmount = 100f;

		public string ThusterSound;

		private KeyBinding _giveThrust;

		private AudioObject _releaseSound;

		private float _thrustModifier;

		private bool _useEnergyAsFuel;

		public override List<KeyBinding> GetKeyBindings()
		{
			_giveThrust = new KeyBinding("Activate", BaseSingleton<KeybindManager>.Instance.GetKeyCode(EKeybinding.DefaultThrusterForward));
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
			}
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
			if (IsActive())
			{
				EResourceType mat = (_useEnergyAsFuel ? EResourceType.Energy : EResourceType.Fuel);
				if (_giveThrust.IsPressed(KeyEventHub))
				{
					float amount = FuelPerSecond * Time.fixedDeltaTime;
					if (base.CurrentResourceHub.HasResource(mat, amount))
					{
						if (ChargeUp)
						{
							_chargeAmount = Mathf.Min(100f, _chargeAmount + Time.fixedDeltaTime * 50f);
							if (_chargeAmount < 100f)
							{
								base.CurrentResourceHub.UseResourceFromParts(mat, amount);
							}
							EnableParticles(false, true);
						}
						else
						{
							if (Rigidbody != null)
							{
								Rigidbody.AddForceAtPosition(base.transform.right * Force * _thrustModifier * 20f, base.transform.position, ForceMode.Force);
							}
							base.CurrentResourceHub.UseResourceFromParts(mat, amount);
							EnableParticles(true);
						}
					}
					else
					{
						EnableParticles(false);
					}
				}
				else if (ChargeUp && _chargeAmount > 0f)
				{
					if (Rigidbody != null)
					{
						Rigidbody.AddForceAtPosition(base.transform.right * Force * _thrustModifier * 150f, base.transform.position, ForceMode.Force);
					}
					_chargeAmount -= 10f;
					if (_releaseSound == null || !_releaseSound.IsPlaying())
					{
						_releaseSound = AudioController.Play(ReleaseSound, base.transform, 0.01f * _chargeAmount);
					}
					EnableParticles(true);
				}
				else
				{
					EnableParticles(false);
				}
			}
			else
			{
				EnableParticles(false);
			}
			if (ChargeUp && ChargeRenderer != null)
			{
				ChargeRenderer.material.SetFloat("_Fuel", 0.01f * _chargeAmount);
			}
			base.FixedUpdate();
		}

		public override void IsDragged(bool isDragged)
		{
			base.IsDragged(isDragged);
			if (isDragged || _giveThrust.HasBeenAssigned || !(GlobalSerializableMonobehaviour<TutorialManager, TutorialSaveData>.Instance.ActiveTutorial == null))
			{
				return;
			}
			Vector3 position = RootDrone.transform.position;
			Vector3 vector = position + RootDrone.transform.up * 10f;
			Vector3 vector2 = position - RootDrone.transform.up * 10f;
			Vector3 vector3 = position - RootDrone.transform.right * 10f;
			Vector3 vector4 = position + RootDrone.transform.right * 10f;
			float num = Vector2.Distance(base.transform.position, vector);
			float num2 = Vector2.Distance(base.transform.position, vector2);
			float num3 = Vector2.Distance(base.transform.position, vector3);
			float num4 = Vector2.Distance(base.transform.position, vector4);
			if ((num < num3 && num < num4) || (num2 < num3 && num2 < num4))
			{
				if (num < num2)
				{
					_giveThrust.SetKey(BaseSingleton<KeybindManager>.Instance.GetKeyCode(EKeybinding.DefaultThrusterRight));
				}
				else
				{
					_giveThrust.SetKey(BaseSingleton<KeybindManager>.Instance.GetKeyCode(EKeybinding.DefaultThrusterLeft));
				}
			}
			else
			{
				_giveThrust.SetKey(BaseSingleton<KeybindManager>.Instance.GetKeyCode(EKeybinding.DefaultThrusterForward));
			}
		}

		private void EnableParticles(bool enable, bool chargeUp = false)
		{
			ParticleSystem[] particles = Particles;
			for (int i = 0; i < particles.Length; i++)
			{
				ParticleSystem.EmissionModule emission = particles[i].emission;
				emission.enabled = enable;
			}
			if (enable || chargeUp)
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
			text = text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/ThrustForce") + ": " + LabelHelper.Orange + Force + LabelHelper.NewLine;
			text = ((!_useEnergyAsFuel) ? (text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/FuelPerSecond") + ": " + LabelHelper.Orange + FuelPerSecond) : (text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/EnergyPerSecond") + ": " + LabelHelper.Orange + FuelPerSecond));
			if (ChargeUp)
			{
				text = text + LabelHelper.NewLine + LabelHelper.Orange + LocalizationManager.GetTermTranslation("DronePartSettings/ChargedThruster");
			}
			return text;
		}
	}
}
