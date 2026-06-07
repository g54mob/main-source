using System.Collections;
using System.Collections.Generic;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator.Attributes;
using Assets.Nimbatus.Scripts.ResourceCollection;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.DefensiveParts
{
	public class TemperatureRegulator : BindableDronePart, IEnergyConsumer
	{
		private KeyBinding _activate;

		public string SoundEffect;

		private const float MinRadius = 2f;

		private const float MaxRadius = 14f;

		[FloatSetting("DronePartSettings/Radius", 2f, 14f, 13, UndoManager.EStoreReason.TemperatureRegulatorRadius)]
		public float Radius;

		private const int MaxStrength = 100;

		private const int MinStrength = 0;

		[IntSetting("DronePartSettings/Strength", 0, 100, 100, UndoManager.EStoreReason.TemperatureRegulatorStrength)]
		public int Strength;

		public float TemperatureChange;

		public int EnergyPerSecond;

		public tk2dSprite Led;

		public Color ActiveColor;

		public Color InactiveColor;

		private bool _isActive;

		private bool _stopCoroutine;

		private int _energy;

		public override List<KeyBinding> GetKeyBindings()
		{
			_activate = new KeyBinding("Activate", KeyCode.None);
			return new List<KeyBinding> { _activate };
		}

		protected override void Validate()
		{
			base.Validate();
			Radius = Mathf.Clamp(Radius, 2f, 14f);
			Strength = Mathf.Clamp(Strength, 0, 100);
		}

		protected override void Start()
		{
			base.Start();
			Led.color = InactiveColor;
			_stopCoroutine = false;
			StartCoroutine(ChangeTemperature());
			_energy = EnergyPerSecond;
		}

		private IEnumerator ChangeTemperature()
		{
			while (!_stopCoroutine)
			{
				if (_isActive)
				{
					HashSet<GameObject> hashSet = new HashSet<GameObject>();
					Collider[] array = Physics.OverlapSphere(base.transform.position, Radius);
					for (int i = 0; i < array.Length; i++)
					{
						GameObject gameObject = array[i].gameObject;
						if (!hashSet.Contains(gameObject))
						{
							gameObject.SendMessage("ChangeTemperatureBy", TemperatureChange * ((float)Strength / 100f), SendMessageOptions.DontRequireReceiver);
							hashSet.Add(gameObject);
						}
					}
				}
				yield return new WaitForSeconds(0.1f);
			}
		}

		public override void OnDisable()
		{
			_stopCoroutine = true;
		}

		public override void FixedUpdate()
		{
			EnergyPerSecond = (int)((float)(_energy * Strength) / 100f);
			if (IsActive())
			{
				if (_activate.IsPressed(KeyEventHub))
				{
					float amount = (float)EnergyPerSecond * Time.fixedDeltaTime;
					if (base.CurrentResourceHub.HasResource(EResourceType.Energy, EnergyPerSecond))
					{
						_isActive = true;
						base.CurrentResourceHub.UseResourceFromParts(EResourceType.Energy, amount);
					}
					else
					{
						_isActive = false;
					}
				}
				else
				{
					_isActive = false;
				}
			}
			else
			{
				_isActive = false;
			}
			Led.color = (_isActive ? ActiveColor : InactiveColor);
			if (_isActive)
			{
				StartSoundLoop(SoundEffect);
			}
			else
			{
				StopActiveSoundLoop();
			}
			ShowRadius = true;
			DisplayRadius = Radius;
			base.FixedUpdate();
		}

		public override string GetDetailedTooltip()
		{
			string text = base.GetDetailedTooltip() + LabelHelper.NewLine;
			text = text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/Radius") + ": " + LabelHelper.Orange + Radius + LabelHelper.NewLine;
			text = text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/Strength") + ": " + LabelHelper.Orange + Strength + LabelHelper.NewLine;
			return text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/EnergyPerSecond") + ": " + LabelHelper.Orange + EnergyPerSecond;
		}

		public override NimbatusItemData CreateData()
		{
			return new TemperatureRegulatorData();
		}

		public override void FillUpData(ref NimbatusItemData data)
		{
			base.FillUpData(ref data);
			TemperatureRegulatorData temperatureRegulatorData = data as TemperatureRegulatorData;
			if (temperatureRegulatorData != null)
			{
				temperatureRegulatorData.Strength = Strength;
				temperatureRegulatorData.Radius = Radius;
			}
		}

		public override void Load(NimbatusItemData data)
		{
			base.Load(data);
			TemperatureRegulatorData temperatureRegulatorData = data as TemperatureRegulatorData;
			if (temperatureRegulatorData != null)
			{
				Strength = temperatureRegulatorData.Strength;
				Radius = temperatureRegulatorData.Radius;
			}
		}
	}
}
