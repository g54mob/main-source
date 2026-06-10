using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using Models.Production;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Goap;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Production;
using NSMedieval.Repository;
using NSMedieval.Serialization;
using NSMedieval.StatsSystem;
using NSMedieval.Types;
using NSMedieval.UI.Utils;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Views.Resources;
using UnityEngine;
using UnityEngine.Pool;

namespace NSMedieval.State
{
	[Serializable]
	[FVSerializableKey("ProductionStepSpawnProduct", "")]
	public class ProductionStepSpawnProduct : ProductionStepInstance
	{
		public ProductionStepSpawnProduct()
			: base(ProductionStepType.SpawnProduct)
		{
		}

		internal override void OnBecomeActive()
		{
			base.OnBecomeActive();
			NSMedieval.Model.Production production = base.OwnerProductionInstance.Blueprint;
			if (production.UseIngredientCombo)
			{
				SpawnProductsWithIngredients();
				SpawnProducts(production.Products);
				base.OwnerProductionInstance.Storage.ClearAll(isSilent: true);
				base.OwnerProductionInstance.SecondaryIngredientStorage.ClearAll(isSilent: true);
				Complete();
				return;
			}
			CustomProduct customProduct = production.GetCustomProduct(base.OwnerProductionInstance);
			if (customProduct != null)
			{
				SpawnProducts(customProduct.Products);
				base.OwnerProductionInstance.Storage.ClearAll(isSilent: true);
				base.OwnerProductionInstance.SecondaryIngredientStorage.ClearAll(isSilent: true);
				Complete();
			}
			else
			{
				SpawnProducts(production.Products);
				base.OwnerProductionInstance.Storage.ClearAll(isSilent: true);
				base.OwnerProductionInstance.SecondaryIngredientStorage.ClearAll(isSilent: true);
				Complete();
			}
		}

		private ResourceInstance GetIngredientWithMaxAmount(IEnumerable<ResourceInstance> resources, IngredientFlags flagsToSkip = IngredientFlags.None)
		{
			ResourceInstance resourceInstance = null;
			foreach (ResourceInstance resource in resources)
			{
				if (resource.Blueprint.IngredientFlag != IngredientFlags.None && (flagsToSkip == IngredientFlags.None || !resource.Blueprint.IngredientFlag.HasFlag(flagsToSkip)))
				{
					if (resourceInstance == null)
					{
						resourceInstance = resource;
					}
					else if (resourceInstance.Amount < resource.Amount)
					{
						resourceInstance = resource;
					}
				}
			}
			return resourceInstance;
		}

		private void SpawnProductsWithIngredients()
		{
			IngredientFlags ingredientFlags = IngredientFlags.None;
			ResourceInstance ingredientWithMaxAmount = GetIngredientWithMaxAmount(base.OwnerProductionInstance.Storage.Resources);
			if (ingredientWithMaxAmount != null)
			{
				ingredientFlags = ingredientWithMaxAmount.Blueprint.IngredientFlag;
				ResourceInstance ingredientWithMaxAmount2 = GetIngredientWithMaxAmount(base.OwnerProductionInstance.SecondaryIngredientStorage.Resources, ingredientWithMaxAmount.Blueprint.IngredientFlag);
				if (ingredientWithMaxAmount2 != null)
				{
					ingredientFlags |= ingredientWithMaxAmount2.Blueprint.IngredientFlag;
				}
				else
				{
					ResourceInstance ingredientWithMaxAmount3 = GetIngredientWithMaxAmount(base.OwnerProductionInstance.Storage.Resources, ingredientWithMaxAmount.Blueprint.IngredientFlag);
					if (ingredientWithMaxAmount3 != null)
					{
						ingredientFlags |= ingredientWithMaxAmount3.Blueprint.IngredientFlag;
					}
				}
			}
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(29, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Production\\Steps\\ProductionStepSpawnProduct.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Production ingredient flags: ");
				messageBuilder.AppendFormatted(ingredientFlags);
			}
			Log.Info(messageBuilder);
			Resource byIngredientFlags = Repository<ResourceRepository, Resource>.Instance.GetByIngredientFlags(ingredientFlags);
			if (byIngredientFlags == null)
			{
				FVLogWarningInterpolationHandler messageBuilder2 = new FVLogWarningInterpolationHandler(45, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Production\\Steps\\ProductionStepSpawnProduct.cs");
				if (isEnabled)
				{
					messageBuilder2.AppendLiteral("Couldn't find resource based on ingredients: ");
					messageBuilder2.AppendFormatted(ingredientFlags.ToString());
				}
				Log.Warning(messageBuilder2);
				return;
			}
			NSMedieval.Model.Production production = base.OwnerProductionInstance.Blueprint;
			int amountToSpawn = GetAmountToSpawn(production);
			ResourceInstance logOwner = base.OwnerProductionInstance.Storage.Resources.FirstOrDefault((ResourceInstance res) => res.LifeEventLogs.Count > 0);
			ResourcePileView resourcePileView = MonoSingleton<ResourcePileManager>.Instance.SpawnPile(new ResourceInstance(byIngredientFlags, amountToSpawn, logOwner), base.OwnerProductionInstance.OwnerProductionComponentInstance.GetPosition());
			if (resourcePileView == null)
			{
				FVLogErrorInterpolationHandler messageBuilder3 = new FVLogErrorInterpolationHandler(54, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Production\\Steps\\ProductionStepSpawnProduct.cs");
				if (isEnabled)
				{
					messageBuilder3.AppendLiteral("Couldn't spawn the product ");
					messageBuilder3.AppendFormatted(production.GetID());
					messageBuilder3.AppendLiteral(". ResourcePileView is null!");
				}
				Log.Error(messageBuilder3);
				return;
			}
			resourcePileView.ResourcePileInstance.GetStoredResource().SetProducerUniqueId(GetProducerUniqueId());
			MonoSingleton<ResourcePileHaulingManager>.Instance.ForceProcessPileState(resourcePileView.ResourcePileInstance);
			HandleNameInherit(resourcePileView);
			HandleTrophyLog(byIngredientFlags, resourcePileView);
			using PooledList<ResourcePileInstance> spawnedPiles = NSMedieval.Utils.Pool.ListPool<ResourcePileInstance>.GetJanitor();
			spawnedPiles.Add(resourcePileView.ResourcePileInstance);
			CheckAchievements(spawnedPiles);
		}

		private void SpawnProducts(List<ProductModel> products)
		{
			bool isEnabled;
			if (products == null || products.Count == 0)
			{
				FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(41, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Production\\Steps\\ProductionStepSpawnProduct.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Production with no spawn resources... ");
					messageBuilder.AppendFormatted(base.OwnerProductionInstance.BlueprintId);
					messageBuilder.AppendLiteral("@(");
					messageBuilder.AppendFormatted(base.OwnerProductionInstance.OwnerProductionComponentInstance.GetGridPosition());
					messageBuilder.AppendLiteral(")");
				}
				Log.Warning(messageBuilder);
				return;
			}
			using PooledList<ResourcePileInstance> spawnedPiles = NSMedieval.Utils.Pool.ListPool<ResourcePileInstance>.GetJanitor();
			foreach (ProductModel product2 in products)
			{
				ProductQuality productQuality = GetProductQuality(product2);
				Resource product = product2.Product;
				if (product != null && productQuality == ProductQuality.None)
				{
					int amountToSpawn = GetAmountToSpawn(product2);
					ResourceInstance logOwner = base.OwnerProductionInstance.Storage.Resources.FirstOrDefault((ResourceInstance res) => res.LifeEventLogs.Count > 0);
					ResourcePileView resourcePileView = MonoSingleton<ResourcePileManager>.Instance.SpawnPile(new ResourceInstance(product, amountToSpawn, logOwner), base.OwnerProductionInstance.OwnerProductionComponentInstance.GetPosition());
					if (resourcePileView == null)
					{
						FVLogErrorInterpolationHandler messageBuilder2 = new FVLogErrorInterpolationHandler(54, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Production\\Steps\\ProductionStepSpawnProduct.cs");
						if (isEnabled)
						{
							messageBuilder2.AppendLiteral("Couldn't spawn the product ");
							messageBuilder2.AppendFormatted(product2.GetID());
							messageBuilder2.AppendLiteral(". ResourcePileView is null!");
						}
						Log.Error(messageBuilder2);
					}
					else
					{
						resourcePileView.ResourcePileInstance.GetStoredResource().SetProducerUniqueId(GetProducerUniqueId());
						MonoSingleton<ResourcePileHaulingManager>.Instance.ForceProcessPileState(resourcePileView.ResourcePileInstance);
						spawnedPiles.Add(resourcePileView.ResourcePileInstance);
						HandleNameInherit(resourcePileView);
						HandleTrophyLog(product, resourcePileView);
					}
					continue;
				}
				string text = productQuality.ToString().ToLower() + "_" + product2.GetID();
				Resource byID = Repository<ResourceRepository, Resource>.Instance.GetByID(text);
				if (byID == null)
				{
					FVLogErrorInterpolationHandler messageBuilder2 = new FVLogErrorInterpolationHandler(85, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\State\\Production\\Steps\\ProductionStepSpawnProduct.cs");
					if (isEnabled)
					{
						messageBuilder2.AppendLiteral("Could not spawn production quality item. Item blueprint '");
						messageBuilder2.AppendFormatted(text);
						messageBuilder2.AppendLiteral("' not found. Production: ");
						messageBuilder2.AppendFormatted(base.OwnerProductionInstance.BlueprintId);
						messageBuilder2.AppendLiteral("@(");
						messageBuilder2.AppendFormatted(base.OwnerProductionInstance.OwnerProductionComponentInstance.GetGridPosition());
						messageBuilder2.AppendLiteral(")");
					}
					Log.Error(messageBuilder2);
				}
				else
				{
					ResourceInstance resourceInstance = new ResourceInstance(byID, product2.Amount);
					resourceInstance.SetProducerUniqueId(GetProducerUniqueId());
					ResourcePileView resourcePileView2 = MonoSingleton<ResourcePileManager>.Instance.SpawnPile(resourceInstance, base.OwnerProductionInstance.OwnerProductionComponentInstance.GetPosition());
					if (!(resourcePileView2 == null))
					{
						spawnedPiles.Add(resourcePileView2.ResourcePileInstance);
						MonoSingleton<ResourcePileHaulingManager>.Instance.ForceProcessPileState(resourcePileView2.ResourcePileInstance);
						HandleNameInherit(resourcePileView2);
						HandleQualityProductionLog(resourceInstance, productQuality);
					}
				}
			}
			CheckAchievements(spawnedPiles);
		}

		private void HandleQualityProductionLog(ResourceInstance instance, ProductQuality quality)
		{
			if (LastAgent() is HumanoidInstance { WorkerBehaviour: not null } humanoidInstance)
			{
				humanoidInstance.WorkerBehaviour.WorkerProximity.OnProducedQualityItem(instance, quality);
			}
		}

		private void HandleTrophyLog(Resource product, ResourcePileView view1)
		{
			if (product.GroupIdentifier.Equals("trophy"))
			{
				ResourceInstance resourceInstance = view1.ResourcePileInstance?.GetStoredResource();
				if (resourceInstance != null && !string.IsNullOrEmpty(resourceInstance.LocalizedInheritedName))
				{
					string message = MonoSingleton<LocalizationController>.Instance.GetText("bbt_has_become_item").Replace("<agent_name>", resourceInstance.LocalizedInheritedName).Replace("<item>", ResourceUtils.GetLocalizedResourceName(product));
					resourceInstance.LogLifeEvent(LifeEventUtils.GetMiscLog(message));
				}
			}
		}

		private ProductQuality GetProductQuality(ProductModel product)
		{
			if (product.Product != null && !product.Product.HasQuality)
			{
				return ProductQuality.None;
			}
			SkillLevelPair skillLevelPair = base.OwnerProductionInstance.Blueprint.RequiredSkills[0];
			int skillValue = GetSkillLevel(skillLevelPair.Key);
			if (skillValue > 50)
			{
				skillValue = 50;
			}
			ProductQualityChance first = Repository<ProductQualityChanceRepository, ProductQualityChance>.Instance.GetFirst((ProductQualityChance x) => x.SkillLevel == skillValue);
			float attributeValue = GetAttributeValue(AttributeType.RareChance);
			float num = Mathf.Clamp(UnityEngine.Random.Range(0.2f, 100f) / attributeValue, 0.2f, 100f);
			List<float> list = first.ProductQualityFloatDictionary.Dictionary.Values.ToPooledList();
			list.Sort();
			for (int num2 = 0; num2 < list.Count; num2++)
			{
				float num3 = 0f;
				for (int num4 = 0; num4 <= num2; num4++)
				{
					num3 += list[num4];
				}
				if (num >= num3)
				{
					continue;
				}
				foreach (KeyValuePair<ProductQuality, float> item in first.ProductQualityFloatDictionary.Dictionary)
				{
					float a = (float)Math.Round(item.Value, 2);
					float b = (float)Math.Round(list[num2], 2);
					if (Mathf.Approximately(a, b))
					{
						CollectionPool<List<float>, float>.Release(list);
						return item.Key;
					}
				}
			}
			CollectionPool<List<float>, float>.Release(list);
			return ProductQuality.None;
		}

		private int GetAmountToSpawn(ProductModel product)
		{
			AttributeType modifyingAttribute = product.ModifyingAttribute;
			float attributeValue = GetAttributeValue(modifyingAttribute);
			float num = (float)product.Amount * attributeValue;
			if (!(num < 1f))
			{
				return Mathf.RoundToInt(num);
			}
			return 1;
		}

		private int GetAmountToSpawn(NSMedieval.Model.Production production)
		{
			AttributeType ingredientComboModifyingAttribute = production.IngredientComboModifyingAttribute;
			float attributeValue = GetAttributeValue(ingredientComboModifyingAttribute);
			float num = (float)production.IngredientComboSpawnAmount * attributeValue;
			if (!(num < 1f))
			{
				return Mathf.RoundToInt(num);
			}
			return 1;
		}

		private float GetAttributeValue(AttributeType attributeType)
		{
			if (attributeType == AttributeType.None)
			{
				return 1f;
			}
			IProductionAgent productionAgent = (base.OwnerProductionInstance.Steps.FirstOrDefault((ProductionStepInstance item) => item.Type == ProductionStepType.WorkerProduce && item.IsCompleted) as ProductionStepWorker)?.LastAgent;
			AttributeInstance attributeInstance = ((productionAgent != null && productionAgent.HasDisposed) ? null : productionAgent?.GetAttribute(attributeType));
			if (attributeInstance != null)
			{
				return attributeInstance.Value;
			}
			if (base.OwnerProductionInstance.Steps.FirstOrDefault((ProductionStepInstance item) => item.Type == ProductionStepType.PassiveProduce && item.IsCompleted) is ProductionStepPassive productionStepPassive && productionStepPassive.LastAgentAttributes.Dictionary.TryGetValue(attributeType, out var value))
			{
				return value.Value;
			}
			return 1f;
		}

		private int GetSkillLevel(SkillType skill)
		{
			return LastAgent()?.GetSkillLevel(skill) ?? 1;
		}

		private int GetProducerUniqueId()
		{
			return (LastAgent() as HumanoidInstance)?.UniqueId ?? 0;
		}

		private IProductionAgent LastAgent()
		{
			return (base.OwnerProductionInstance.Steps.FirstOrDefault((ProductionStepInstance item) => item.Type == ProductionStepType.WorkerProduce && item.IsCompleted) as ProductionStepWorker)?.LastAgent;
		}

		private void HandleNameInherit(ResourcePileView view)
		{
			if (!base.OwnerProductionInstance.Blueprint.ProductInheritsName)
			{
				return;
			}
			string text = string.Empty;
			foreach (ResourceInstance resource in base.OwnerProductionInstance.Storage.Resources)
			{
				if (!string.IsNullOrEmpty(resource.LocalizedInheritedName))
				{
					text = resource.LocalizedInheritedName;
					break;
				}
			}
			if (text == string.Empty)
			{
				text = MonoSingleton<LocalizationController>.Instance.GetText("unnamed");
			}
			view.ResourcePileInstance.GetStoredResource().SetLocalizedInheritedName(text);
		}

		private void CheckAchievements(PooledList<ResourcePileInstance> spawnedPiles)
		{
			int num = 0;
			int num2 = 0;
			bool flag = false;
			foreach (ResourcePileInstance item in spawnedPiles)
			{
				Resource resource = item.Blueprint;
				if (!(resource == null))
				{
					if (resource.GetID().Equals("enemy_skull_trophy") || resource.GetID().Equals("settler_skull_trophy"))
					{
						flag = true;
					}
					else if (resource.IsArt)
					{
						num2++;
					}
					else if (!(resource.EquipmentBlueprint == null) && resource.EquipmentBlueprint.ItemType == ItemType.Weapon)
					{
						num++;
					}
				}
			}
			MonoSingleton<AchievementManager>.Instance.IncreaseStat("PRODUCE_WEAPON_CNT", num);
			MonoSingleton<AchievementManager>.Instance.IncreaseStat("PRODUCE_ART_CNT", num2);
			if (flag)
			{
				MonoSingleton<AchievementManager>.Instance.UnlockAchievement("PRODUCE_HUMAN_TROPHY");
			}
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
		}

		public ProductionStepSpawnProduct(FVDeserializer deserializer)
			: base(deserializer)
		{
		}
	}
}
