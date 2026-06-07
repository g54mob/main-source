using Motorways.Models;
using UnityEngine;

namespace Motorways.Views
{
	public class DraftDestinationCarparkMeshes : MonoBehaviour
	{
		[SerializeField]
		private GameObject _singleHorizontalDrivewayWest;

		[SerializeField]
		private GameObject _singleHorizontalDrivewayEast;

		[SerializeField]
		private GameObject _singleVerticalDrivewayNorth;

		[SerializeField]
		private GameObject _singleVerticalDrivewaySouth;

		[SerializeField]
		private GameObject _doubleHorizontalFirstDestination;

		[SerializeField]
		private GameObject _doubleHorizontalSecondDestination;

		[SerializeField]
		private GameObject _doubleVerticalFirstDestination;

		[SerializeField]
		private GameObject _doubleVerticalSecondDestination;

		[SerializeField]
		private GameObject _trainStationHorizontalFlippedFirstDestination;

		[SerializeField]
		private GameObject _trainStationHorizontalFlippedSecondDestination;

		[SerializeField]
		private GameObject _trainStationVerticalFlippedFirstDestination;

		[SerializeField]
		private GameObject _trainStationVerticalFlippedSecondDestination;

		[SerializeField]
		private GameObject _boatTerminalFirstDestination;

		[SerializeField]
		private GameObject _boatTerminalSecondDestination;

		public void SetVisibleCarparkMesh(bool isDouble, DrivewayDirection drivewayDirection, TileDirection carparkSide, bool supportsBoats, bool focusOnSecondDestination = false)
		{
			_singleHorizontalDrivewayWest.SetActive(value: false);
			_singleHorizontalDrivewayEast.SetActive(value: false);
			_singleVerticalDrivewayNorth.SetActive(value: false);
			_singleVerticalDrivewaySouth.SetActive(value: false);
			_doubleHorizontalFirstDestination.SetActive(value: false);
			_doubleHorizontalSecondDestination.SetActive(value: false);
			_doubleVerticalFirstDestination.SetActive(value: false);
			_doubleVerticalSecondDestination.SetActive(value: false);
			_trainStationHorizontalFlippedFirstDestination.SetActive(value: false);
			_trainStationHorizontalFlippedSecondDestination.SetActive(value: false);
			_trainStationVerticalFlippedFirstDestination.SetActive(value: false);
			_trainStationVerticalFlippedSecondDestination.SetActive(value: false);
			_boatTerminalFirstDestination.SetActive(value: false);
			_boatTerminalSecondDestination.SetActive(value: false);
			if (supportsBoats)
			{
				if (focusOnSecondDestination)
				{
					_boatTerminalSecondDestination.SetActive(value: true);
				}
				else
				{
					_boatTerminalFirstDestination.SetActive(value: true);
				}
			}
			else if (isDouble)
			{
				switch (carparkSide)
				{
				case TileDirection.South:
					if (focusOnSecondDestination)
					{
						_doubleHorizontalSecondDestination.SetActive(value: true);
					}
					else
					{
						_doubleHorizontalFirstDestination.SetActive(value: true);
					}
					break;
				case TileDirection.West:
					if (focusOnSecondDestination)
					{
						_doubleVerticalSecondDestination.SetActive(value: true);
					}
					else
					{
						_doubleVerticalFirstDestination.SetActive(value: true);
					}
					break;
				case TileDirection.North:
					Diagnostics.Log.Info("DraftDestinationCarparkMeshes", "Enabling horizontal flipped train carpark!");
					if (focusOnSecondDestination)
					{
						_trainStationHorizontalFlippedSecondDestination.SetActive(value: true);
					}
					else
					{
						_trainStationHorizontalFlippedFirstDestination.SetActive(value: true);
					}
					break;
				default:
					Diagnostics.Log.Info("DraftDestinationCarparkMeshes", "Enabling vertical flipped train carpark!");
					if (focusOnSecondDestination)
					{
						_trainStationVerticalFlippedSecondDestination.SetActive(value: true);
					}
					else
					{
						_trainStationVerticalFlippedFirstDestination.SetActive(value: true);
					}
					break;
				}
			}
			else
			{
				switch (drivewayDirection)
				{
				case DrivewayDirection.West:
					_singleHorizontalDrivewayWest.SetActive(value: true);
					break;
				case DrivewayDirection.East:
					_singleHorizontalDrivewayEast.SetActive(value: true);
					break;
				case DrivewayDirection.North:
					_singleVerticalDrivewayNorth.SetActive(value: true);
					break;
				default:
					_singleVerticalDrivewaySouth.SetActive(value: true);
					break;
				}
			}
		}
	}
}
