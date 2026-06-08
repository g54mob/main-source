using UnityEngine;
using UnityEngine.UI;

public class UIShipHold : MonoBehaviour
{
	public enum ShipPropertyEnum
	{
		Scrap = 0,
		FleetDrone = 1,
		ReserveDrone = 2,
		DroneUpgrades = 3,
		ShipUpgrades = 4,
		PFuelReserve = 5
	}

	public Text scrapMaxLabel;

	public Text activeDroneMaxLabel;

	public Text reserveDroneMaxLabel;

	public Text droneUpgradesMaxLabel;

	public Text shipUpgradesMaxLabel;

	public Text pfuelReserveMaxLabel;

	public Text scrapCurLabel;

	public Text activeDroneCurLabel;

	public Text reserveDroneCurLabel;

	public Text droneUpgradesCurLabel;

	public Text shipUpgradesCurLabel;

	public Text pfuelReserveCurLabel;

	private void Start()
	{
	}

	public void SetValue(ShipPropertyEnum propertyType, int max, int cur, int maxOrig)
	{
		switch (propertyType)
		{
		case ShipPropertyEnum.DroneUpgrades:
			SetValue(droneUpgradesMaxLabel, droneUpgradesCurLabel, max, cur, (maxOrig >= 0) ? true : false, maxOrig);
			break;
		case ShipPropertyEnum.FleetDrone:
			SetValue(activeDroneMaxLabel, activeDroneCurLabel, max, cur, (maxOrig >= 0) ? true : false, maxOrig);
			break;
		case ShipPropertyEnum.ReserveDrone:
			SetValue(reserveDroneMaxLabel, reserveDroneCurLabel, max, cur, (maxOrig >= 0) ? true : false, maxOrig);
			break;
		case ShipPropertyEnum.Scrap:
			SetValue(scrapMaxLabel, scrapCurLabel, max, cur, (maxOrig >= 0) ? true : false, maxOrig);
			break;
		case ShipPropertyEnum.ShipUpgrades:
			SetValue(shipUpgradesMaxLabel, shipUpgradesCurLabel, max, cur, (maxOrig >= 0) ? true : false, maxOrig);
			break;
		case ShipPropertyEnum.PFuelReserve:
			SetValue(pfuelReserveMaxLabel, pfuelReserveCurLabel, max, cur, (maxOrig >= 0) ? true : false, maxOrig);
			break;
		}
	}

	private void SetValue(Text labelMax, Text labelCur, int max, int cur, bool setColors, int maxOrig)
	{
		if (labelMax != null)
		{
			labelMax.text = max.ToString();
		}
		if (labelCur != null)
		{
			labelCur.text = cur.ToString();
		}
		if (setColors && labelMax != null)
		{
			if (maxOrig < max)
			{
				labelMax.color = CommandeerUI.Instance.changePositiveColor;
			}
			else if (maxOrig == max)
			{
				labelMax.color = CommandeerUI.Instance.changeNeutralColor;
			}
			else if (maxOrig > max)
			{
				labelMax.color = CommandeerUI.Instance.changeNegativeColor;
			}
		}
	}
}
