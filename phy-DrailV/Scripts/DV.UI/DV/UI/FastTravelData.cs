using System;

namespace DV.UI
{
	public struct FastTravelData
	{
		public string destinationName;

		public int fastTravelPrice;

		public int fastTravelWithLocoPrice;

		public bool hasMoneyForFastTravel;

		public bool hasMoneyForFastTravelWithLoco;

		public bool isDestinationLoco;

		public bool isDestinationWithinSameTrainset;

		public bool hasLicenseForDestinationLoco;

		public bool isInLocomotive;

		public bool hasLocoLicense;

		public bool isLocoOnTracks;

		public bool isTutorialInProgress;

		public bool isLocoFastTravelPrevented;

		public DateTime arrivalTime;

		public int fastTravelDuration;

		public bool CanTravelWithoutLoco
		{
			get
			{
				if (hasMoneyForFastTravel)
				{
					if (isDestinationLoco)
					{
						return hasLicenseForDestinationLoco;
					}
					return true;
				}
				return false;
			}
		}

		public bool CanTravelWithLoco
		{
			get
			{
				if (hasMoneyForFastTravelWithLoco && isInLocomotive && hasLocoLicense && isLocoOnTracks)
				{
					return !isLocoFastTravelPrevented;
				}
				return false;
			}
		}

		public FastTravelData(string destinationName, int fastTravelPrice, int fastTravelWithLocoPrice, bool hasMoneyForFastTravel, bool hasMoneyForFastTravelWithLoco, bool isDestinationLoco, bool isDestinationWithinSameTrainset, bool hasLicenseForDestinationLoco, bool isInLocomotive, bool hasLocoLicense, bool isLocoOnTracks, bool isLocoFastTravelPrevented, bool isTutorialInProgress, DateTime arrivalTime, int fastTravelDuration)
		{
			this.destinationName = destinationName;
			this.fastTravelPrice = fastTravelPrice;
			this.fastTravelWithLocoPrice = fastTravelWithLocoPrice;
			this.hasMoneyForFastTravel = hasMoneyForFastTravel;
			this.hasMoneyForFastTravelWithLoco = hasMoneyForFastTravelWithLoco;
			this.isDestinationLoco = isDestinationLoco;
			this.isDestinationWithinSameTrainset = isDestinationWithinSameTrainset;
			this.hasLicenseForDestinationLoco = hasLicenseForDestinationLoco;
			this.isInLocomotive = isInLocomotive;
			this.hasLocoLicense = hasLocoLicense;
			this.isLocoOnTracks = isLocoOnTracks;
			this.isLocoFastTravelPrevented = isLocoFastTravelPrevented;
			this.isTutorialInProgress = isTutorialInProgress;
			this.arrivalTime = arrivalTime;
			this.fastTravelDuration = fastTravelDuration;
		}
	}
}
