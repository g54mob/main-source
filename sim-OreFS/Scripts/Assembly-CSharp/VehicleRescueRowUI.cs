using I2.Loc;
using TMPro;
using UnityEngine;

public class VehicleRescueRowUI : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI vehicleNameText;

	[SerializeField]
	private TextMeshProUGUI statusText;

	private SCC_Network vehicle;

	private int vehicleType;

	private int index;

	public void Initialize(SCC_Network vehicle, int vehicleType, int index, int vehicleNumber)
	{
		this.vehicle = vehicle;
		this.vehicleType = vehicleType;
		this.index = index;
		if (vehicleNameText != null && vehicle != null && vehicle.vehicleItem != null)
		{
			string translation = LocalizationManager.GetTranslation(vehicle.vehicleItem.Name);
			vehicleNameText.text = $"{translation} #{vehicleNumber}";
		}
		RefreshStatus();
	}

	public void RefreshStatus()
	{
		if (!(statusText == null))
		{
			bool flag = vehicle != null && vehicle.HasDriverAll;
			statusText.text = (flag ? LocalizationManager.GetTranslation("Vehicle_Full") : LocalizationManager.GetTranslation("Vehicle_Empty"));
		}
	}

	public void OnRescueClicked()
	{
		if (VehicleRescueManager.Instance != null)
		{
			VehicleRescueManager.Instance.CmdRequestRescue(vehicleType, index);
		}
	}
}
