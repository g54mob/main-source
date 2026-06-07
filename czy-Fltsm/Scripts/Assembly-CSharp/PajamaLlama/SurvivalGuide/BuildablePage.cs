using System;
using System.Collections.Generic;
using System.Text;
using I2.Loc;
using UnityEngine;

namespace PajamaLlama.SurvivalGuide
{
	internal class BuildablePage : Page
	{
		private static readonly Dictionary<string, object> _stringParams = new Dictionary<string, object>(2);

		private static readonly string _durationMinutesParam = "DURATIONMINUTES";

		private static readonly string _durationSecondsParam = "DURATIONSECONDS";

		private static readonly StringBuilder _durationStringBuilder = new StringBuilder();

		public BuildableProperties Properties { get; private set; }

		private BuildablePage(BuildableProperties buildableProperties)
			: base(buildableProperties.SurvivalGuideIdentifier, buildableProperties.LocalizedNameTerm, buildableProperties.Icon)
		{
			Properties = buildableProperties;
		}

		internal static List<Page> Generate(BuildableProperties[] buildables, CategoryPage category)
		{
			List<Page> list = new List<Page>(buildables.Length);
			foreach (BuildableProperties buildableProperties in buildables)
			{
				if (buildableProperties.ShowInSurvivalGuide)
				{
					Page page = new BuildablePage(buildableProperties);
					category.AddEntry(page);
					list.Add(page);
				}
			}
			return list;
		}

		protected override List<WidgetContainer> GenerateWidgets(SurvivalGuideProperties survivalGuideProperties)
		{
			if (!survivalGuideProperties.TryReturnWidgetContainerStyle("vertical", out var style) || !survivalGuideProperties.TryReturnStyle("text-paragraph", out var widget))
			{
				Debug.LogException(new NotImplementedException());
				return new List<WidgetContainer>();
			}
			List<WidgetContainer> list = new List<WidgetContainer>
			{
				new WidgetContainer(style, new List<Tuple<BaseWidget, BaseWidget.BaseParameters>>
				{
					new Tuple<BaseWidget, BaseWidget.BaseParameters>(widget, new TextWidget.Parameters(Properties.Prefab.ReturnDescription()))
				})
			};
			list.AddRange(GetBuildableInformationElements(survivalGuideProperties));
			list.AddRange(GetResearchElements(survivalGuideProperties));
			list.AddRange(GetBuildingCostElements(survivalGuideProperties));
			if (Properties.TryReturnUpgradesFrom(out var buildable))
			{
				list.AddRange(GetUpgradeElements(survivalGuideProperties, survivalGuideProperties.UpgradesFromString, buildable));
			}
			if ((bool)Properties.Upgrade)
			{
				list.AddRange(GetUpgradeElements(survivalGuideProperties, survivalGuideProperties.UpgradesToString, Properties.Upgrade));
			}
			list.AddRange(GetCapacityElements(survivalGuideProperties));
			list.AddRange(GetProductionElements(survivalGuideProperties));
			list.AddRange(GetElectricityOutputElements(survivalGuideProperties));
			if (Properties.TutorialPageID != TutorialID.None)
			{
				list.AddRange(GetTutorialElements(survivalGuideProperties));
			}
			return list;
		}

		private List<WidgetContainer> GetBuildableInformationElements(SurvivalGuideProperties survivalGuideProperties)
		{
			if (!survivalGuideProperties.TryReturnWidgetContainerStyle("vertical", out var style) || !survivalGuideProperties.TryReturnStyle("labelledimagevalue-paragraph", out var widget))
			{
				Debug.LogException(new NotImplementedException());
				return new List<WidgetContainer>();
			}
			List<Tuple<BaseWidget, BaseWidget.BaseParameters>> list = new List<Tuple<BaseWidget, BaseWidget.BaseParameters>>
			{
				new Tuple<BaseWidget, BaseWidget.BaseParameters>(widget, new LabelledImageValueWidget.Parameters(survivalGuideProperties.CategoryString, $"<color=#{ColorUtility.ToHtmlStringRGBA(Properties.Category.UIColor)}>{Properties.Category.Name}</color>", Properties.Category.IconSprite, 40f))
			};
			if (!Properties.UseCustomSize)
			{
				list.Add(new Tuple<BaseWidget, BaseWidget.BaseParameters>(widget, new LabelledImageValueWidget.Parameters(survivalGuideProperties.DimensionsString, $"{Properties.Width}x{Properties.Depth}", survivalGuideProperties.SizeSprite, 40f)));
			}
			list.Add(new Tuple<BaseWidget, BaseWidget.BaseParameters>(widget, new LabelledImageValueWidget.Parameters(survivalGuideProperties.WeightString, Properties.GetWeightModeWeight().ToString(), survivalGuideProperties.WeightSprite, 40f)));
			list.Add(new Tuple<BaseWidget, BaseWidget.BaseParameters>(widget, new LabelledImageValueWidget.Parameters(survivalGuideProperties.BeautyString, Properties.ReturnBuildableTooltipBeautyScore().ToString(), survivalGuideProperties.BeautySprite, 40f)));
			return new List<WidgetContainer>
			{
				new WidgetContainer(style, new List<Tuple<BaseWidget, BaseWidget.BaseParameters>>(list))
			};
		}

		private List<WidgetContainer> GetUpgradeElements(SurvivalGuideProperties survivalGuideProperties, LocalizedString title, BuildableProperties upgrade)
		{
			if (!survivalGuideProperties.TryReturnWidgetContainerStyle("vertical", out var style) || !survivalGuideProperties.TryReturnStyle("text-subtitle-underlined", out var widget) || !survivalGuideProperties.TryReturnStyle("labelledimage-paragraph", out var widget2))
			{
				Debug.LogException(new NotImplementedException());
				return new List<WidgetContainer>();
			}
			string text = "<style=\"SGLink\"><link=" + upgrade.SurvivalGuideIdentifier + ">" + upgrade.Name + "</link></style>";
			return new List<WidgetContainer>
			{
				new WidgetContainer(style, new List<Tuple<BaseWidget, BaseWidget.BaseParameters>>
				{
					new Tuple<BaseWidget, BaseWidget.BaseParameters>(widget, new TextWidget.Parameters(title)),
					new Tuple<BaseWidget, BaseWidget.BaseParameters>(widget2, new LabelledImageWidget.Parameters(text, upgrade.IconSprite, new Vector2(40f, 40f), upgrade.SurvivalGuideIdentifier))
				})
			};
		}

		private List<WidgetContainer> GetResearchElements(SurvivalGuideProperties survivalGuideProperties)
		{
			if (!survivalGuideProperties.TryReturnWidgetContainerStyle("vertical", out var style) || !survivalGuideProperties.TryReturnStyle("text-subtitle-underlined", out var widget) || !survivalGuideProperties.TryReturnStyle("labelledimagevalue-paragraph", out var widget2))
			{
				Debug.LogException(new NotImplementedException());
				return new List<WidgetContainer>();
			}
			if (Properties.IsDefaultBuildable || !GameSettings.Instance.TechTree.TryGetUnlockableNode(Properties, out var node) || node.Requirements.IsNullOrEmpty())
			{
				return new List<WidgetContainer>();
			}
			List<Tuple<BaseWidget, BaseWidget.BaseParameters>> list = new List<Tuple<BaseWidget, BaseWidget.BaseParameters>>
			{
				new Tuple<BaseWidget, BaseWidget.BaseParameters>(widget, new TextWidget.Parameters(survivalGuideProperties.ResearchCostString)),
				new Tuple<BaseWidget, BaseWidget.BaseParameters>(widget2, new LabelledImageValueWidget.Parameters(survivalGuideProperties.TechnologyString, node.Name, node.Icon, 40f))
			};
			if (node.ContainsRequirement(out KnowledgeRequirement requirement))
			{
				list.Add(new Tuple<BaseWidget, BaseWidget.BaseParameters>(widget2, new LabelledImageValueWidget.Parameters(survivalGuideProperties.ResearchKnowledgeRequirementString, requirement.Amount.ToString(), survivalGuideProperties.ResearchSprite, 40f)));
			}
			if (node.ContainsRequirement(out BackgroundRequirement requirement2))
			{
				list.Add(new Tuple<BaseWidget, BaseWidget.BaseParameters>(widget2, new LabelledImageValueWidget.Parameters(survivalGuideProperties.ResearchBackgroundRequirementString, requirement2.Background.Name, requirement2.GetIcon(), 40f, requirement2.Background.SurvivalGuideIdentifier)));
			}
			if (node.ContainsRequirement(out AssignmentRequirement requirement3))
			{
				list.Add(new Tuple<BaseWidget, BaseWidget.BaseParameters>(widget2, new LabelledImageValueWidget.Parameters(survivalGuideProperties.ResearchExpertiseRequirementString, $"{requirement3.GetLocalizedName()} {requirement3.RequiredPoints:F0}", requirement3.GetIcon(), 40f)));
			}
			return new List<WidgetContainer>
			{
				new WidgetContainer(style, list)
			};
		}

		private List<WidgetContainer> GetBuildingCostElements(SurvivalGuideProperties survivalGuideProperties)
		{
			if (!survivalGuideProperties.TryReturnWidgetContainerStyle("vertical", out var style) || !survivalGuideProperties.TryReturnStyle("text-subtitle-underlined", out var widget) || !survivalGuideProperties.TryReturnStyle("labelledimagevalue-paragraph", out var widget2))
			{
				Debug.LogException(new NotImplementedException());
				return new List<WidgetContainer>();
			}
			if (Properties.RequiredResources.Length == 0)
			{
				return new List<WidgetContainer>();
			}
			List<Tuple<BaseWidget, BaseWidget.BaseParameters>> list = new List<Tuple<BaseWidget, BaseWidget.BaseParameters>>
			{
				new Tuple<BaseWidget, BaseWidget.BaseParameters>(widget, new TextWidget.Parameters(survivalGuideProperties.BuildingCostString))
			};
			CountedItemProperty[] requiredResources = Properties.RequiredResources;
			foreach (CountedItemProperty countedItemProperty in requiredResources)
			{
				list.Add(new Tuple<BaseWidget, BaseWidget.BaseParameters>(widget2, new LabelledImageValueWidget.Parameters(countedItemProperty.ItemProperties.LocalizedName, countedItemProperty.Amount.ToString(), countedItemProperty.ItemProperties.InventorySprite, 40f, countedItemProperty.ItemProperties.SurvivalGuideIdentifier, survivalGuideProperties.ResourceBackgroundSprite, survivalGuideProperties.ResourceBackgroundSpriteColor)));
			}
			string durationString = GetDurationString(Properties.GetConstructionTime(), survivalGuideProperties);
			list.Add(new Tuple<BaseWidget, BaseWidget.BaseParameters>(widget2, new LabelledImageValueWidget.Parameters(survivalGuideProperties.ConstructionTimeString, durationString, survivalGuideProperties.TimeSprite, 40f)));
			return new List<WidgetContainer>
			{
				new WidgetContainer(style, list)
			};
		}

		private List<WidgetContainer> GetProductionElements(SurvivalGuideProperties survivalGuideProperties)
		{
			if (!survivalGuideProperties.TryReturnWidgetContainerStyle("vertical", out var style) || !survivalGuideProperties.TryReturnStyle("text-subtitle-underlined", out var widget) || !survivalGuideProperties.TryReturnStyle("labelledimagevalue-paragraph", out var widget2) || !survivalGuideProperties.TryReturnStyle("custom-productionrecipewidget", out var widget3))
			{
				Debug.LogException(new NotImplementedException());
				return new List<WidgetContainer>();
			}
			if (!Properties.Prefab.TryGetComponent<Producer>(out var component))
			{
				return new List<WidgetContainer>();
			}
			List<Tuple<BaseWidget, BaseWidget.BaseParameters>> list = new List<Tuple<BaseWidget, BaseWidget.BaseParameters>>
			{
				new Tuple<BaseWidget, BaseWidget.BaseParameters>(widget, new TextWidget.Parameters(survivalGuideProperties.ProductionString))
			};
			if (!component.ProductionProperties.Recipes.IsNullOrEmpty())
			{
				ProductionRecipeProperties productionRecipeProperties = component.ProductionProperties.Recipes[0];
				if (productionRecipeProperties.Attribute != DrifterAttributes.AttributeType.None && component.ProductionProperties.ProductionProject != null)
				{
					DrifterAttributes.Attribute attribute = survivalGuideProperties.DrifterAttributes.ReturnAttribute(productionRecipeProperties.Attribute);
					AssignmentSetting assignmentSetting = GameSettings.Instance.ProjectSettings.ReturnAssignmentSetting(component.ProductionProperties.ProductionProject.AssignmentType);
					list.Add(new Tuple<BaseWidget, BaseWidget.BaseParameters>(widget2, new LabelledImageValueWidget.Parameters(survivalGuideProperties.DrifterProducerAttributeString, attribute.Name, assignmentSetting.Sprite, 40f, attribute.SurvivalGuideLink)));
				}
			}
			if (component.ProductionProperties.EnergyCost > 0f)
			{
				list.Add(new Tuple<BaseWidget, BaseWidget.BaseParameters>(widget2, new LabelledImageValueWidget.Parameters(survivalGuideProperties.EnergyPerSecondString, $"-{component.ProductionProperties.EnergyCost:F0}", survivalGuideProperties.EnergyConsumptionSprite, 40f)));
			}
			foreach (ProductionRecipeProperties recipe in component.ProductionProperties.Recipes)
			{
				string durationString = GetDurationString(recipe.ProductionTime, survivalGuideProperties);
				list.Add(new Tuple<BaseWidget, BaseWidget.BaseParameters>(widget3, new ProductionRecipeWidget.Parameters(recipe, durationString)));
			}
			return new List<WidgetContainer>
			{
				new WidgetContainer(style, list)
			};
		}

		private List<WidgetContainer> GetElectricityOutputElements(SurvivalGuideProperties survivalGuideProperties)
		{
			if (!survivalGuideProperties.TryReturnWidgetContainerStyle("vertical", out var style) || !survivalGuideProperties.TryReturnStyle("text-subtitle-underlined", out var widget) || !survivalGuideProperties.TryReturnStyle("labelledimagevalue-paragraph", out var widget2))
			{
				Debug.LogException(new NotImplementedException());
				return new List<WidgetContainer>();
			}
			List<Tuple<BaseWidget, BaseWidget.BaseParameters>> list = null;
			EnergyManualProducer component2;
			EnergyPassiveGenerator component3;
			if (Properties.Prefab.TryGetComponent<EnergyItemProducer>(out var component))
			{
				string durationString = GetDurationString(component.MaxBurnTime, survivalGuideProperties);
				ItemProperties energyItemProperties = component.EnergyItemProperties;
				list = new List<Tuple<BaseWidget, BaseWidget.BaseParameters>>
				{
					new Tuple<BaseWidget, BaseWidget.BaseParameters>(widget2, new LabelledImageValueWidget.Parameters(survivalGuideProperties.EnergyPerSecondString, $"+{component.PowerRate:F0}", survivalGuideProperties.EnergyProductionSprite, 40f)),
					new Tuple<BaseWidget, BaseWidget.BaseParameters>(widget2, new LabelledImageValueWidget.Parameters(survivalGuideProperties.ProductionCostString, energyItemProperties.LocalizedName + " 1", energyItemProperties.InventorySprite, 40f, energyItemProperties.SurvivalGuideIdentifier, survivalGuideProperties.ResourceBackgroundSprite, energyItemProperties.ItemType.Color)),
					new Tuple<BaseWidget, BaseWidget.BaseParameters>(widget2, new LabelledImageValueWidget.Parameters(survivalGuideProperties.ResourceBurnTimeString, durationString, survivalGuideProperties.TimeSprite, 40f))
				};
			}
			else if (Properties.Prefab.TryGetComponent<EnergyManualProducer>(out component2))
			{
				list = new List<Tuple<BaseWidget, BaseWidget.BaseParameters>>
				{
					new Tuple<BaseWidget, BaseWidget.BaseParameters>(widget2, new LabelledImageValueWidget.Parameters(survivalGuideProperties.EnergyPerSecondString, $"+{component2.RechargeSpeed:F0}", survivalGuideProperties.EnergyProductionSprite, 40f))
				};
			}
			else if (Properties.Prefab.TryGetComponent<EnergyPassiveGenerator>(out component3))
			{
				list = new List<Tuple<BaseWidget, BaseWidget.BaseParameters>>
				{
					new Tuple<BaseWidget, BaseWidget.BaseParameters>(widget2, new LabelledImageValueWidget.Parameters(survivalGuideProperties.EnergyPerSecondString, $"+{component3.EnergyRate:F0}", survivalGuideProperties.EnergyProductionSprite, 40f))
				};
			}
			if (list == null)
			{
				return new List<WidgetContainer>();
			}
			return new List<WidgetContainer>
			{
				new WidgetContainer(style, new List<Tuple<BaseWidget, BaseWidget.BaseParameters>>
				{
					new Tuple<BaseWidget, BaseWidget.BaseParameters>(widget, new TextWidget.Parameters(survivalGuideProperties.EnergyOutputString))
				}),
				new WidgetContainer(style, list)
			};
		}

		private List<WidgetContainer> GetCapacityElements(SurvivalGuideProperties survivalGuideProperties)
		{
			if (!survivalGuideProperties.TryReturnWidgetContainerStyle("vertical", out var style) || !survivalGuideProperties.TryReturnStyle("text-subtitle-underlined", out var widget) || !survivalGuideProperties.TryReturnStyle("labelledimagevalue-paragraph", out var widget2) || !survivalGuideProperties.TryReturnStyle("padding", out var widget3))
			{
				Debug.LogException(new NotImplementedException());
				return new List<WidgetContainer>();
			}
			Storage component = Properties.Prefab.GetComponent<Storage>();
			BirdHouse component2 = Properties.Prefab.GetComponent<BirdHouse>();
			House component3 = Properties.Prefab.GetComponent<House>();
			EnergyStorage component4 = Properties.Prefab.GetComponent<EnergyStorage>();
			if (component == null && component2 == null && component3 == null && component4 == null)
			{
				return new List<WidgetContainer>();
			}
			List<Tuple<BaseWidget, BaseWidget.BaseParameters>> list = new List<Tuple<BaseWidget, BaseWidget.BaseParameters>>
			{
				new Tuple<BaseWidget, BaseWidget.BaseParameters>(widget, new TextWidget.Parameters(survivalGuideProperties.CapacityString))
			};
			if (component3 != null)
			{
				list.Add(new Tuple<BaseWidget, BaseWidget.BaseParameters>(widget2, new LabelledImageValueWidget.Parameters(survivalGuideProperties.DrifterString, component3.Properties.Capacity.ToString(), survivalGuideProperties.HouseSprite, 40f)));
			}
			if (component2 != null)
			{
				list.Add(new Tuple<BaseWidget, BaseWidget.BaseParameters>(widget2, new LabelledImageValueWidget.Parameters(survivalGuideProperties.BirdString, component2.BirdCapacity.ToString(), survivalGuideProperties.BirdhouseSprite, 40f)));
			}
			if (component != null)
			{
				Inventory component5 = component.GetComponent<Inventory>();
				int storageCapacity = component5.StorageCapacity;
				if (storageCapacity > 0)
				{
					if ((component._filter & (component._filter - 1)) != Item.Tags.None || component5.InventoryType == InventoryType.Producer)
					{
						list.Add(new Tuple<BaseWidget, BaseWidget.BaseParameters>(widget2, new LabelledImageValueWidget.Parameters(survivalGuideProperties.StorageString, $"{storageCapacity} {survivalGuideProperties.MixedStorageString}", survivalGuideProperties.StorageSprite, 40f)));
					}
					else
					{
						ItemType itemType = GameManager.Settings.ItemSettings.ReturnItemPropertiesWithTag(component._filter)[0].ItemType;
						list.Add(new Tuple<BaseWidget, BaseWidget.BaseParameters>(widget2, new LabelledImageValueWidget.Parameters(survivalGuideProperties.StorageString, $"{storageCapacity} {itemType.Name}", itemType.Icon, 40f)));
					}
				}
				int liquidCapacity = component5.LiquidCapacity;
				if (liquidCapacity > 0)
				{
					list.Add(new Tuple<BaseWidget, BaseWidget.BaseParameters>(widget2, new LabelledImageValueWidget.Parameters(survivalGuideProperties.StorageString, $"{liquidCapacity} {survivalGuideProperties.LiquidStorageString}", survivalGuideProperties.LiquidStorageSprite, 40f)));
				}
			}
			if (component4 != null)
			{
				list.Add(new Tuple<BaseWidget, BaseWidget.BaseParameters>(widget2, new LabelledImageValueWidget.Parameters(survivalGuideProperties.StorageString, $"{component4.EnergyCapacity:F0} {survivalGuideProperties.EnergyStorageString}", survivalGuideProperties.EnergyStorageSprite, 40f)));
			}
			list.Add(new Tuple<BaseWidget, BaseWidget.BaseParameters>(widget3, new PaddingWidget.Parameters(20f)));
			return new List<WidgetContainer>
			{
				new WidgetContainer(style, list)
			};
		}

		private List<WidgetContainer> GetTutorialElements(SurvivalGuideProperties survivalGuideProperties)
		{
			if (!survivalGuideProperties.TryReturnWidgetContainerStyle("vertical", out var style) || !survivalGuideProperties.TryReturnStyle("text-subtitle-underlined", out var widget) || !survivalGuideProperties.TryReturnStyle("tutorial-button-widget", out var widget2))
			{
				Debug.LogException(new NotImplementedException());
				return new List<WidgetContainer>();
			}
			return new List<WidgetContainer>
			{
				new WidgetContainer(style, new List<Tuple<BaseWidget, BaseWidget.BaseParameters>>
				{
					new Tuple<BaseWidget, BaseWidget.BaseParameters>(widget, new TextWidget.Parameters(survivalGuideProperties.TutorialString)),
					new Tuple<BaseWidget, BaseWidget.BaseParameters>(widget2, new TutorialButtonWidget.Parameters(Properties.TutorialPageID))
				})
			};
		}

		private static string GetDurationString(float duration, SurvivalGuideProperties survivalGuideProperties)
		{
			int num = Mathf.FloorToInt(duration / 60f);
			int num2 = Mathf.FloorToInt(duration % 60f);
			_stringParams[_durationMinutesParam] = num.ToString();
			_stringParams[_durationSecondsParam] = num2.ToString();
			_durationStringBuilder.Clear();
			if (num > 0)
			{
				string translation = survivalGuideProperties.MinutesString;
				LocalizationManager.ApplyLocalizationParams(ref translation, _stringParams);
				_durationStringBuilder.Append(translation);
				if (num2 > 0)
				{
					_durationStringBuilder.Append(" ");
				}
			}
			if (num2 > 0)
			{
				string translation2 = survivalGuideProperties.SecondsString;
				LocalizationManager.ApplyLocalizationParams(ref translation2, _stringParams);
				_durationStringBuilder.Append(translation2);
			}
			return _durationStringBuilder.ToString();
		}
	}
}
