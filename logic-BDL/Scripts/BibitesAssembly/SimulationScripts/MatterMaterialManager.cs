using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using ScriptHelpers;
using SettingScripts;
using UnityEngine;
using UnityEngine.Events;

namespace SimulationScripts
{
	public class MatterMaterialManager : MonoBehaviour, ISaveable
	{
		public static MatterMaterialManager Instance;

		[SerializeField]
		private MatterMaterial plant;

		[SerializeField]
		private MatterMaterial meat;

		[SerializeField]
		private MatterMaterial fat;

		[SerializeField]
		private MatterMaterial armor;

		[SerializeField]
		private MatterMaterial energy;

		[SerializeField]
		private MatterMaterial health;

		[SerializeField]
		private MatterMaterial none;

		public static MatterMaterialSettings PlantParameters;

		public static MatterMaterialSettings MeatParameters;

		public static MatterMaterialSettings FatParameters;

		public static MatterMaterialSettings ArmorParameters;

		public static MatterMaterial Plant;

		public static MatterMaterial Meat;

		public static MatterMaterial Energy;

		public static MatterMaterial Fat;

		public static MatterMaterial Armor;

		public static MatterMaterial Health;

		public static MatterMaterial None;

		public static List<MatterMaterial> DefaultMaterials = new List<MatterMaterial>();

		public static List<MatterMaterial> BaseMaterials = new List<MatterMaterial>();

		public static List<MatterMaterial> PhysicalMaterials = new List<MatterMaterial>();

		public static List<MatterMaterialSettings> MaterialSettings = new List<MatterMaterialSettings>();

		public static UnityEvent onMaterialListChange = new UnityEvent();

		public void Awake()
		{
			if (Instance == null)
			{
				Instance = this;
				DefaultMaterials = new List<MatterMaterial> { plant, meat, energy, fat, armor, health, none };
				PhysicalMaterials.Add(Plant = Object.Instantiate(plant));
				PhysicalMaterials.Add(Meat = Object.Instantiate(meat));
				Fat = Object.Instantiate(fat);
				Armor = Object.Instantiate(armor);
				Energy = Object.Instantiate(energy);
				Health = Object.Instantiate(health);
				None = Object.Instantiate(none);
				PhysicalMaterials.ForEach(delegate(MatterMaterial mat)
				{
					BaseMaterials.Add(mat);
				});
				BaseMaterials.Add(Fat);
				BaseMaterials.Add(Armor);
				MaterialSettings.Add(PlantParameters = new MatterMaterialSettings(Plant));
				MaterialSettings.Add(MeatParameters = new MatterMaterialSettings(Meat));
				MaterialSettings.Add(FatParameters = new MatterMaterialSettings(Fat));
				MaterialSettings.Add(ArmorParameters = new MatterMaterialSettings(Armor));
			}
		}

		public static MatterMaterial FindMaterial(string name)
		{
			return PhysicalMaterials.Find((MatterMaterial _m) => _m.Name == name) ?? null;
		}

		public static MatterMaterial FindDefaultMaterial(string name)
		{
			return DefaultMaterials.Find((MatterMaterial _m) => _m.Name == name);
		}

		public static MatterMaterialSettings SettingsOfMaterial(MatterMaterial mat)
		{
			return MaterialSettings.FirstOrDefault((MatterMaterialSettings m) => m.mat == mat);
		}

		public static void ResetAllMaterials(bool forceUpdate = true)
		{
			BaseMaterials.ForEach(ResetMaterialParameters);
			MaterialSettings.ForEach(delegate(MatterMaterialSettings s)
			{
				s.ResetSettingsFromMaterial(forceUpdate);
			});
		}

		public static void ResetMaterialParameters(MatterMaterial mat)
		{
			MatterMaterial matterMaterial = FindDefaultMaterial(mat.Name);
			if (!(matterMaterial == null))
			{
				mat.Cohesiveness = matterMaterial.Cohesiveness;
				mat.Reactivity = matterMaterial.Reactivity;
				mat.EnergyDensity = matterMaterial.EnergyDensity;
				mat.MassDensity = matterMaterial.MassDensity;
				mat.MaxConversionEfficiency = matterMaterial.MaxConversionEfficiency;
				mat.MinConversionEfficiency = matterMaterial.MinConversionEfficiency;
				mat.decay = matterMaterial.decay;
				mat.decayRate = matterMaterial.decayRate;
				mat.freshTime = matterMaterial.freshTime;
			}
		}

		private void OnApplicationQuit()
		{
			ResetAllMaterials(forceUpdate: false);
		}

		private void OnDestroy()
		{
			ResetAllMaterials(forceUpdate: false);
		}

		public JObject SaveState()
		{
			JObject jObject = new JObject();
			foreach (MatterMaterialSettings materialSetting in MaterialSettings)
			{
				jObject[materialSetting.Name] = SerializationHelper.SerializeObject(materialSetting);
			}
			return jObject;
		}

		public void LoadState(JObject state)
		{
			foreach (MatterMaterialSettings materialSetting in MaterialSettings)
			{
				ResetMaterialParameters(materialSetting.mat);
				materialSetting.ResetSettingsFromMaterial();
				if (state[materialSetting.Name] == null)
				{
					break;
				}
				SerializationHelper.DeserializeObject(materialSetting, state[materialSetting.Name]);
				materialSetting.UpdateMaterial();
			}
		}
	}
}
