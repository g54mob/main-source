using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator.Attributes;
using Assets.Nimbatus.Scripts.Behaviours.Health;
using Assets.Nimbatus.Scripts.ResourceCollection;
using Assets.Nimbatus.Scripts.WorldObjects.DronePerks.Effects;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Thruster
{
	public class DynamicThruster : BindableDronePart, IFuelConsumer, IThruster
	{
		[FloatSetting("DronePartSettings/StartForce", 0f, 30f, 31, UndoManager.EStoreReason.DynamicThrusterStartForce)]
		public float StartForce = 30f;

		private const float MinForce = 0f;

		private const float MaxForce = 30f;

		private const float MinForceIncrease = 0f;

		private const float MaxForceIncrease = 30f;

		[FloatSetting("DronePartSettings/ForceChange", 0f, 30f, 31, UndoManager.EStoreReason.DynamicThrusterForceChange)]
		public float ForceIncrease = 5f;

		public float FuelPerSecond = 1f;

		public ParticleSystem Particles;

		public Renderer ForceRenderer;

		public string ThusterSound;

		private KeyBinding _increaseThrust;

		private KeyBinding _decreaseThrust;

		private float _currentThrust;

		private KeyBinding _toggle;

		private float _thrustModifier;

		private bool _useEnergyAsFuel;

		protected override void Validate()
		{
			base.Validate();
			StartForce = Mathf.Clamp(StartForce, 0f, 30f);
			ForceIncrease = Mathf.Clamp(ForceIncrease, 0f, 30f);
		}

		public override List<KeyBinding> GetKeyBindings()
		{
			_toggle = new KeyBinding("Activate", KeyCode.None);
			_increaseThrust = new KeyBinding("Increase Thrust", KeyCode.None, false);
			_decreaseThrust = new KeyBinding("Decrease Thrust", KeyCode.None, false);
			return new List<KeyBinding> { _toggle, _increaseThrust, _decreaseThrust };
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

		protected override void Start()
		{
			base.Start();
			_currentThrust = StartForce;
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
			EResourceType mat = EResourceType.Fuel;
			if (_useEnergyAsFuel)
			{
				mat = EResourceType.Energy;
			}
			if (IsActive())
			{
				if (_increaseThrust.IsPressed(KeyEventHub))
				{
					_currentThrust = Mathf.Min(30f, _currentThrust + ForceIncrease * Time.fixedDeltaTime);
				}
				if (_decreaseThrust.IsPressed(KeyEventHub))
				{
					_currentThrust = Mathf.Max(0f, _currentThrust - ForceIncrease * 2f * Time.fixedDeltaTime);
				}
				if (_currentThrust > 0f && _toggle.IsPressed(KeyEventHub))
				{
					float amount = FuelPerSecond * Time.fixedDeltaTime * 1f / 30f * _currentThrust;
					if (base.CurrentResourceHub.HasResource(mat, amount))
					{
						if (Rigidbody != null)
						{
							Rigidbody.AddForceAtPosition(base.transform.right * _currentThrust * 20f * _thrustModifier, base.transform.position, ForceMode.Force);
						}
						base.CurrentResourceHub.UseResourceFromParts(mat, amount);
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
			}
			else
			{
				EnableParticles(false);
			}
			if (ForceRenderer != null)
			{
				ForceRenderer.material.SetFloat("_Fuel", 1f / 30f * _currentThrust);
			}
			base.FixedUpdate();
		}

		private void EnableParticles(bool enable, bool chargeUp = false)
		{
			ParticleSystem.EmissionModule emission = Particles.emission;
			ParticleSystem.MainModule main = Particles.main;
			main.startLifetimeMultiplier = 1f / 30f * _currentThrust;
			emission.enabled = enable;
			if (enable || chargeUp)
			{
				StartSoundLoop(ThusterSound, 1f / 30f * _currentThrust);
			}
			else
			{
				StopActiveSoundLoop();
			}
		}

		public override string GetDetailedTooltip()
		{
			string text = base.GetDetailedTooltip() + LabelHelper.NewLine;
			text = text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/StartForce") + ": " + LabelHelper.Orange + StartForce + LabelHelper.NewLine;
			text = text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/MaxForce") + ": " + LabelHelper.Orange + 30f + LabelHelper.NewLine;
			text = text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/ForceChange") + ": " + LabelHelper.Orange + ForceIncrease + LabelHelper.NewLine;
			if (_useEnergyAsFuel)
			{
				return text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/EnergyPerSecond") + ": " + LabelHelper.Orange + FuelPerSecond;
			}
			return text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/FuelPerSecond") + ": " + LabelHelper.Orange + FuelPerSecond;
		}

		public override NimbatusItemData CreateData()
		{
			return new DynamicThrusterData();
		}

		public override void FillUpData(ref NimbatusItemData data)
		{
			base.FillUpData(ref data);
			DynamicThrusterData dynamicThrusterData = data as DynamicThrusterData;
			if (dynamicThrusterData != null)
			{
				dynamicThrusterData.StartForce = StartForce;
				dynamicThrusterData.ForceChange = ForceIncrease;
			}
		}

		public override void Load(NimbatusItemData data)
		{
			base.Load(data);
			DynamicThrusterData dynamicThrusterData = data as DynamicThrusterData;
			if (dynamicThrusterData != null)
			{
				StartForce = dynamicThrusterData.StartForce;
				ForceIncrease = dynamicThrusterData.ForceChange;
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
			return _currentThrust;
		}

		public void SetCurrentThrust(float thrust)
		{
			_currentThrust = thrust;
		}
	}
}
