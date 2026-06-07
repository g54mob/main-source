using System;
using System.Collections.Generic;
using System.Reflection;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Craft.Parts.Modifiers.LandingGear;
using Assets.Scripts.Craft.Parts.Modifiers.Propulsion;
using ModApi.Services.Purchasing;
using ModApi.State;
using ModApi.Ui;

namespace Assets.Scripts.Services.Purchasing
{
	public class InAppFeatures : IInAppPurchaseFeatures<InAppPurchaseFeature>
	{
		public IReadOnlyCollection<InAppPurchaseFeature> All { get; }

		public InAppPurchaseFeature CareerBundle { get; } = new InAppPurchaseFeature(InAppPurchaseProduct.CareerBundle);

		public InAppPurchaseFeature CareerCustomerPricklespac { get; } = new InAppPurchaseFeature(InAppPurchaseProduct.CareerBundle);

		public InAppPurchaseFeature CareerCustomerSchafer { get; } = new InAppPurchaseFeature(InAppPurchaseProduct.CareerBundle);

		public InAppPurchaseFeature CareerCustomerShotwell { get; } = new InAppPurchaseFeature(InAppPurchaseProduct.CareerBundle);

		public InAppPurchaseFeature CreateSubAssemblies { get; } = new InAppPurchaseFeature(InAppPurchaseProduct.EngineerBundle, InAppPurchaseProduct.CareerBundle);

		public InAppPurchaseFeature DesignerTinkerPanel { get; } = new InAppPurchaseFeature(InAppPurchaseProduct.SandboxBundle);

		public InAppPurchaseFeature DevConsole { get; } = new InAppPurchaseFeature(InAppPurchaseProduct.SandboxBundle);

		public InAppPurchaseFeature InFlightCheats { get; } = new InAppPurchaseFeature(InAppPurchaseProduct.SandboxBundle);

		public InAppPurchaseFeature LaunchLocationsAli { get; } = new InAppPurchaseFeature(InAppPurchaseProduct.SandboxBundle);

		public InAppPurchaseFeature LaunchLocationsCustom { get; } = new InAppPurchaseFeature(InAppPurchaseProduct.SandboxBundle);

		public InAppPurchaseFeature LaunchLocationsLuna { get; } = new InAppPurchaseFeature(InAppPurchaseProduct.SandboxBundle);

		public InAppPurchaseFeature PartPropertiesJetEngines { get; } = new InAppPurchaseFeature(InAppPurchaseProduct.EngineerBundle, InAppPurchaseProduct.CareerBundle);

		public InAppPurchaseFeature PartPropertiesLandingGear { get; } = new InAppPurchaseFeature(InAppPurchaseProduct.EngineerBundle, InAppPurchaseProduct.CareerBundle);

		public InAppPurchaseFeature PartPropertiesPropellerAssembly { get; } = new InAppPurchaseFeature(InAppPurchaseProduct.EngineerBundle, InAppPurchaseProduct.CareerBundle);

		public InAppPurchaseFeature PartPropertiesResizableWheels { get; } = new InAppPurchaseFeature(InAppPurchaseProduct.EngineerBundle, InAppPurchaseProduct.CareerBundle);

		public InAppPurchaseFeature PartPropertiesRocketEngines { get; } = new InAppPurchaseFeature(InAppPurchaseProduct.EngineerBundle, InAppPurchaseProduct.CareerBundle);

		public InAppPurchaseFeature PlanetarySystemsCustom { get; } = new InAppPurchaseFeature(InAppPurchaseProduct.SandboxBundle);

		public InAppPurchaseFeature PlanetarySystemsExpandedJuno { get; } = new InAppPurchaseFeature(InAppPurchaseProduct.SandboxBundle);

		public InAppPurchaseFeature RemoveAds { get; } = new InAppPurchaseFeature(InAppPurchaseProduct.RemoveAds);

		public InAppPurchaseFeature SandboxBundle { get; } = new InAppPurchaseFeature(InAppPurchaseProduct.SandboxBundle);

		public InAppPurchaseFeature UnlimitedCraftInFlight { get; } = new InAppPurchaseFeature(InAppPurchaseProduct.SandboxBundle);

		public InAppPurchaseFeature Vizzy { get; } = new InAppPurchaseFeature(InAppPurchaseProduct.EngineerBundle, InAppPurchaseProduct.CareerBundle);

		public InAppPurchaseFeature WingCurves { get; } = new InAppPurchaseFeature(InAppPurchaseProduct.SandboxBundle);

		public InAppFeatures()
		{
			List<InAppPurchaseFeature> list = new List<InAppPurchaseFeature>();
			PropertyInfo[] properties = GetType().GetProperties();
			foreach (PropertyInfo propertyInfo in properties)
			{
				if (propertyInfo.PropertyType == typeof(InAppPurchaseFeature))
				{
					list.Add((InAppPurchaseFeature)propertyInfo.GetValue(this));
				}
			}
			All = list.AsReadOnly();
		}

		public bool IsFeatureUnlocked(IInAppPurchaseFeature feature, string message, IInAppPurchaseFeature comboFeature = null)
		{
			IInAppPurchaseFeature missingFeature = feature;
			if (feature.Unlocked)
			{
				if (comboFeature == null || comboFeature.Unlocked)
				{
					return true;
				}
				missingFeature = comboFeature;
			}
			MessageDialogScript messageDialogScript = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.OkayCancel);
			messageDialogScript.MessageText = ((comboFeature == null) ? ("Upgrade to the " + feature.ProductName + " to " + message) : ("Upgrade to both the " + feature.ProductName + " and " + comboFeature.ProductName + " to " + message));
			messageDialogScript.OkayButtonText = "UPGRADE";
			messageDialogScript.OkayClicked += delegate(MessageDialogScript d)
			{
				d.Close();
				Game.Instance.InAppPurchases.CreatePurchaseDialog(missingFeature.ProductId);
			};
			return false;
		}

		public InAppPurchaseFeature CareerCustomer(string name)
		{
			if (Compare(name, "pricklespac"))
			{
				return CareerCustomerPricklespac;
			}
			if (Compare(name, "schafer"))
			{
				return CareerCustomerSchafer;
			}
			if (Compare(name, "shotwell"))
			{
				return CareerCustomerShotwell;
			}
			return InAppPurchaseFeature.DefaultUnlocked;
			static bool Compare(string a, string b)
			{
				return string.Equals(a, b, StringComparison.OrdinalIgnoreCase);
			}
		}

		public InAppPurchaseFeature PartProperties(Type type, GameStateMode? gameMode = null)
		{
			if ((gameMode ?? (Game.Instance.GameState ?? throw new InvalidOperationException("Unable to determine current game mode")).Mode) == GameStateMode.Sandbox)
			{
				if (type == typeof(RocketEngineData))
				{
					return PartPropertiesRocketEngines;
				}
				if (type == typeof(JetEngineData))
				{
					return PartPropertiesJetEngines;
				}
				if (type == typeof(ResizableWheelData))
				{
					return PartPropertiesResizableWheels;
				}
				if (type == typeof(LandingGearData))
				{
					return PartPropertiesLandingGear;
				}
				if (type == typeof(PropellerAssemblyData))
				{
					return PartPropertiesPropellerAssembly;
				}
			}
			return InAppPurchaseFeature.DefaultUnlocked;
		}

		public InAppPurchaseFeature Planet(string planetName, GameStateMode? gameMode = null)
		{
			if ((gameMode ?? (Game.Instance.GameState ?? throw new InvalidOperationException("Unable to determine current game mode")).Mode) == GameStateMode.Sandbox)
			{
				switch (planetName)
				{
				case "Juno":
				case "Droo":
				case "Brigo":
				case "Luna":
				case "T.T.":
					return InAppPurchaseFeature.DefaultUnlocked;
				default:
					return PlanetarySystemsExpandedJuno;
				}
			}
			return InAppPurchaseFeature.DefaultUnlocked;
		}
	}
}
