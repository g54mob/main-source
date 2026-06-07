using System;
using ModApi.State;

namespace ModApi.Services.Purchasing
{
	public interface IInAppPurchaseFeatures<out T> where T : IInAppPurchaseFeature
	{
		T CareerBundle { get; }

		T CareerCustomerPricklespac { get; }

		T CareerCustomerSchafer { get; }

		T CareerCustomerShotwell { get; }

		T CreateSubAssemblies { get; }

		T DesignerTinkerPanel { get; }

		T DevConsole { get; }

		T InFlightCheats { get; }

		T LaunchLocationsAli { get; }

		T LaunchLocationsCustom { get; }

		T LaunchLocationsLuna { get; }

		T PartPropertiesJetEngines { get; }

		T PartPropertiesLandingGear { get; }

		T PartPropertiesPropellerAssembly { get; }

		T PartPropertiesResizableWheels { get; }

		T PartPropertiesRocketEngines { get; }

		T PlanetarySystemsCustom { get; }

		T PlanetarySystemsExpandedJuno { get; }

		T RemoveAds { get; }

		T SandboxBundle { get; }

		T UnlimitedCraftInFlight { get; }

		T Vizzy { get; }

		T WingCurves { get; }

		bool IsFeatureUnlocked(IInAppPurchaseFeature feature, string message, IInAppPurchaseFeature comboFeature = null);

		T CareerCustomer(string name);

		T PartProperties(Type modifierType, GameStateMode? gameMode = null);

		T Planet(string planetName, GameStateMode? gameMode = null);
	}
}
