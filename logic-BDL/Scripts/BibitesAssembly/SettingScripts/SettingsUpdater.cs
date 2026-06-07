using ManagementScripts;
using SimulationScripts;
using SimulationScripts.BibiteScripts;
using UnityEngine;

namespace SettingScripts
{
	public class SettingsUpdater : MonoBehaviour
	{
		private static BoolSetting disableDragOnHeldPellet = ScenarioSettings.Instance.disableDragOnHeldPellet;

		private static BoolSetting pelletCollision = ScenarioSettings.Instance.pelletCollision;

		private static BoolSetting pelletRotation = ScenarioSettings.Instance.pelletRotation;

		private static FloatSetting dragCoefficient = ScenarioSettings.Instance.dragCoefficient;

		private static BoolSetting plantDecay;

		private static FloatSetting plantDecayRate;

		private static FloatSetting plantPerishableFactor;

		private static BoolSetting meatDecay;

		private static FloatSetting meatDecayRate;

		private static FloatSetting meatPerishableFactor;

		private static float freshValueDifference;

		public void Start()
		{
			disableDragOnHeldPellet.Subscribe(UpdatePelletHeldDrag);
			UpdatePelletHeldDrag(disableDragOnHeldPellet.val);
			pelletCollision.Subscribe(UpdatePelletCollision);
			pelletRotation.Subscribe(UpdatePelletRotation);
			dragCoefficient.Subscribe(UpdateDrag);
			plantDecay = MatterMaterialManager.PlantParameters.decay;
			plantDecayRate = MatterMaterialManager.PlantParameters.decayRate;
			plantPerishableFactor = MatterMaterialManager.PlantParameters.freshTime;
			meatDecay = MatterMaterialManager.MeatParameters.decay;
			meatDecayRate = MatterMaterialManager.MeatParameters.decayRate;
			meatPerishableFactor = MatterMaterialManager.MeatParameters.freshTime;
			MatterMaterialManager.PlantParameters.onPhysicalParametersChange.AddListener(UpdatePlantPhysicalProperties);
			plantDecay.Subscribe(UpdatePlantDecay);
			plantDecayRate.Subscribe(UpdatePlantDecayParameters);
			plantPerishableFactor.Subscribe(UpdateFreshValueDifference);
			plantPerishableFactor.Subscribe(UpdatePlantDecayParameters);
			MatterMaterialManager.MeatParameters.onPhysicalParametersChange.AddListener(UpdateMeatPhysicalProperties);
			meatDecay.Subscribe(UpdateMeatDecay);
			meatDecayRate.Subscribe(UpdateMeatDecayParameters);
			meatPerishableFactor.Subscribe(UpdateFreshValueDifference);
			meatPerishableFactor.Subscribe(UpdateMeatDecayParameters);
		}

		private void UpdatePlantPhysicalProperties()
		{
			UpdatePelletPhysicalProperties(MatterMaterialManager.Plant);
		}

		private void UpdateMeatPhysicalProperties()
		{
			UpdatePelletPhysicalProperties(MatterMaterialManager.Meat);
		}

		private void UpdatePlantDecay(bool val)
		{
			UpdateDecay(MatterMaterialManager.Plant, val);
		}

		private void UpdateMeatDecay(bool val)
		{
			UpdateDecay(MatterMaterialManager.Meat, val);
		}

		private void UpdatePlantDecayParameters()
		{
			UpdateDecayParameters(MatterMaterialManager.Plant);
		}

		private void UpdateMeatDecayParameters()
		{
			UpdateDecayParameters(MatterMaterialManager.Meat);
		}

		private void UpdateFreshValueDifference(float newVal, float oldVal)
		{
			freshValueDifference = newVal - oldVal;
		}

		private void UpdateDecay(MatterMaterial mat, bool val)
		{
			WorldObjectsSpawner.Instance.pelletsOfMaterial[mat].ForEach(delegate(MatterPellet p)
			{
				if (val)
				{
					MatterDecayProcessor.I.TryAddUnique(p);
				}
				else
				{
					MatterDecayProcessor.I.TryRemove(p);
				}
			});
		}

		private void UpdateDecayParameters(MatterMaterial mat)
		{
			MatterDecayProcessor.I.UpdateDecayParameters(mat, freshValueDifference);
		}

		private void UpdatePelletCollision(bool val)
		{
			WorldObjectsSpawner.Instance.allPellets.ForEach(delegate(MatterPellet p)
			{
				p.ToggleCollision(val);
			});
		}

		private void UpdatePelletRotation(bool val)
		{
			WorldObjectsSpawner.Instance.allPellets.ForEach(delegate(MatterPellet p)
			{
				Rigidbody2D component = p.GetComponent<Rigidbody2D>();
				if (!val)
				{
					component.rotation = 0f;
				}
				component.freezeRotation = !val;
			});
		}

		private void UpdateDrag(float val)
		{
			WorldObjectsSpawner.Instance.allPellets.ForEach(delegate(MatterPellet p)
			{
				p.UpdateDrag();
			});
			if (BibiteTracker.instance == null)
			{
				return;
			}
			foreach (BibiteBody bibite in BibiteTracker.instance.bibites)
			{
				bibite.UpdateDrag();
			}
			foreach (Transform item in WorldObjectsSpawner.Instance.bibiteHolder.transform)
			{
				if (item.gameObject.CompareTag("egg"))
				{
					item.GetComponent<EggHatching>().UpdateDrag();
				}
			}
		}

		private void UpdatePelletHeldDrag(bool val)
		{
			MatterPellet.disableDragOnHeldPellet = val;
			WorldObjectsSpawner.Instance.allPellets.ForEach(delegate(MatterPellet p)
			{
				p.UpdateDrag();
			});
		}

		private void UpdatePelletPhysicalProperties(MatterMaterial mat)
		{
			WorldObjectsSpawner.Instance.pelletsOfMaterial[mat].ForEach(delegate(MatterPellet p)
			{
				p.UpdatePhysicalProperties();
			});
		}

		public void OnDestroy()
		{
			disableDragOnHeldPellet.UnSubscribe(UpdatePelletHeldDrag);
			pelletCollision.UnSubscribeTo<BoolSetting, bool>(UpdatePelletCollision);
			pelletRotation.UnSubscribeTo<BoolSetting, bool>(UpdatePelletRotation);
			dragCoefficient.UnSubscribeTo<FloatSetting, float>(UpdateDrag);
			plantDecay.UnSubscribe(UpdatePlantDecay);
			plantDecayRate.UnSubscribe(UpdatePlantDecayParameters);
			plantPerishableFactor.UnSubscribe(UpdatePlantDecayParameters);
			plantPerishableFactor.UnSubscribe(UpdatePlantDecayParameters);
			meatDecay.UnSubscribe(UpdateMeatDecay);
			meatDecayRate.UnSubscribe(UpdateMeatDecayParameters);
			meatPerishableFactor.UnSubscribe(UpdateMeatDecayParameters);
			meatPerishableFactor.UnSubscribe(UpdatePlantDecayParameters);
		}
	}
}
