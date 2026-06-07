using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator.Attributes;
using Assets.Nimbatus.Scripts.Behaviours.Health;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones;
using I2.Loc;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Components
{
	public class DroneComponent : DronePart
	{
		[EnumSetting("DronePartSettings/Coating", UndoManager.EStoreReason.DroneComponentCoating)]
		public ECoating SelectedCoating;

		private ECoating _coating;

		private string _initialSpriteName;

		public override void Update()
		{
			base.Update();
			if (RuntimeGlobals.RunningMode == ERunningMode.DroneCustomization)
			{
				UpdateCoating();
			}
		}

		protected override void Start()
		{
			base.Start();
			_initialSpriteName = base.Sprite.CurrentSprite.name;
			UpdateCoating();
		}

		private void UpdateCoating()
		{
			if (_coating != SelectedCoating)
			{
				_coating = SelectedCoating;
				HealthPool.HeatResistance = 0;
				HealthPool.ColdResistance = 0;
				float value = 1f;
				string text = _initialSpriteName;
				ApplyPhysicMaterial(SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.DronePhysicMaterial);
				switch (SelectedCoating)
				{
				case ECoating.HeatResistant:
					HealthPool.HeatResistance = 100;
					value = 0.5f;
					text += "HR";
					break;
				case ECoating.ColdResistant:
					HealthPool.ColdResistance = 100;
					value = 0.5f;
					text += "CR";
					break;
				case ECoating.Frictionless:
					ApplyPhysicMaterial(SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.FrictionLessMaterial);
					text += "FL";
					break;
				case ECoating.Superfriction:
					ApplyPhysicMaterial(SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.SuperFrictionMaterial);
					text += "FR";
					break;
				}
				HealthPool.SetHealthModifier(EHealthModifier.Plating, value);
				base.Sprite.SetSprite(text);
			}
		}

		public override string GetDetailedTooltip()
		{
			string text = base.GetDetailedTooltip() + LabelHelper.NewLine;
			return text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/Coating") + ": " + LabelHelper.Orange + SelectedCoating.ToLocalizationString();
		}

		public override NimbatusItemData CreateData()
		{
			return new DroneComponentData();
		}

		public override void FillUpData(ref NimbatusItemData data)
		{
			base.FillUpData(ref data);
			DroneComponentData droneComponentData;
			if ((droneComponentData = data as DroneComponentData) != null)
			{
				droneComponentData.Coating = SelectedCoating;
			}
		}

		public override void Load(NimbatusItemData data)
		{
			base.Load(data);
			DroneComponentData droneComponentData;
			if ((droneComponentData = data as DroneComponentData) != null)
			{
				SelectedCoating = droneComponentData.Coating;
			}
		}
	}
}
