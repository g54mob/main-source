using PolyAndCode.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AssetManagementDeviceLine : MonoBehaviour, ICell
{
	[SerializeField]
	private AssetManagement assetManagement;

	[SerializeField]
	private TextMeshProUGUI deviceType;

	[SerializeField]
	private TextMeshProUGUI deviceSubtype;

	[SerializeField]
	private TextMeshProUGUI deviceNameText;

	[SerializeField]
	private TextMeshProUGUI deviceEOL;

	[SerializeField]
	private TextMeshProUGUI deviceState;

	private NetworkSwitch networkSwitch;

	private Server server;

	[SerializeField]
	private ButtonExtended buttonClearWarning;

	[SerializeField]
	private ButtonExtended buttonSendTechnician;

	private int _cellIndex;

	public void SetupLine(AssetManagementDeviceLineData data, int index)
	{
	}

	public void ButtonClearWarningSign()
	{
	}

	public void ButtonSendTechnician()
	{
	}
}
