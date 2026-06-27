using UnityEngine;

namespace Restory.Data.GameWarnings
{
	[CreateAssetMenu(menuName = "Restory/GameWarnings/GameWarningDatabase", fileName = "GameWarningDatabase")]
	public class GameWarningDatabase : ScriptableObject
	{
		[SerializeField]
		private GameWarning notIdealDeviceWarning;

		[SerializeField]
		private GameWarning brokenElementWarning;

		[SerializeField]
		private GameWarning unableToEndDayWhenItHasNotStartedWarning;

		[SerializeField]
		private GameWarning insufficientMoneyToPayRegularPaymentWarning;

		[SerializeField]
		private GameWarning notBestPlaceForPapersWarning;

		[SerializeField]
		private GameWarning canNotPayRegularPaymentOutsideCashRegisterWarning;

		[SerializeField]
		private GameWarning cleanUpTheTableWarning;

		[SerializeField]
		private GameWarning orderWaitingUntilMorning;

		[SerializeField]
		private GameWarning recheckParts;

		[SerializeField]
		private GameWarning notScrewedParts;

		[SerializeField]
		private GameWarning removeExtraParts;

		[SerializeField]
		private GameWarning damagedPartInstalled;

		[SerializeField]
		private GameWarning dirtyPartInstalled;

		[SerializeField]
		private GameWarning notEnoughSpaceInStore;

		[SerializeField]
		private GameWarning partIsAlreadyClean;

		[SerializeField]
		private GameWarning needTurnOffBath;

		[SerializeField]
		private GameWarning noSpaceInBath;

		[SerializeField]
		private GameWarning bathCoverIsClosed;

		[SerializeField]
		private GameWarning partIsNotCompatibleWithDevice;

		[SerializeField]
		private GameWarning brokenPartRejectedByBath;

		[SerializeField]
		private GameWarning absentCompatiblePart;

		[SerializeField]
		private GameWarning solderingNeeded;

		[SerializeField]
		private GameWarning licenseRequired;

		[SerializeField]
		private GameWarning deviceQualityUnpaintableWarning;

		[SerializeField]
		private GameWarning noPaintableDevicePlacedWarning;

		[SerializeField]
		private GameWarning placedDeviceIsUnpaintableWarning;

		public GameWarning NotIdealDeviceWarning => notIdealDeviceWarning;

		public GameWarning BrokenElementWarning => brokenElementWarning;

		public GameWarning UnableToEndDayWhenItHasNotStartedWarning => unableToEndDayWhenItHasNotStartedWarning;

		public GameWarning InsufficientMoneyToPayRegularPaymentWarning => insufficientMoneyToPayRegularPaymentWarning;

		public GameWarning NotBestPlaceForPapersWarning => notBestPlaceForPapersWarning;

		public GameWarning CanNotPayRegularPaymentOutsideCashRegisterWarning => canNotPayRegularPaymentOutsideCashRegisterWarning;

		public GameWarning CleanUpTheTableWarning => cleanUpTheTableWarning;

		public GameWarning OrderWaitingUntilMorning => orderWaitingUntilMorning;

		public GameWarning RecheckParts => recheckParts;

		public GameWarning NotScrewedParts => notScrewedParts;

		public GameWarning RemoveExtraParts => removeExtraParts;

		public GameWarning DamagedPartInstalled => damagedPartInstalled;

		public GameWarning DirtyPartInstalled => dirtyPartInstalled;

		public GameWarning NotEnoughSpaceInStore => notEnoughSpaceInStore;

		public GameWarning PartIsAlreadyClean => partIsAlreadyClean;

		public GameWarning NeedTurnOffBath => needTurnOffBath;

		public GameWarning NoSpaceInBath => noSpaceInBath;

		public GameWarning BathCoverIsClosed => bathCoverIsClosed;

		public GameWarning PartIsNotCompatibleWithDevice => partIsNotCompatibleWithDevice;

		public GameWarning BrokenPartRejectedByBath => brokenPartRejectedByBath;

		public GameWarning AbsentCompatiblePart => absentCompatiblePart;

		public GameWarning SolderingNeeded => solderingNeeded;

		public GameWarning LicenseRequired => licenseRequired;

		public GameWarning DeviceQualityUnpaintableWarning => deviceQualityUnpaintableWarning;

		public GameWarning PlacedDeviceIsUnpaintableWarning => placedDeviceIsUnpaintableWarning;

		public GameWarning NoPaintableDevicePlacedWarning => noPaintableDevicePlacedWarning;
	}
}
