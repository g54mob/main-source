using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BottomPane : MonoBehaviour
{
	public Text cancelButtonSubtext;

	public Text unitStateText;

	public Text fireStateText;

	public Text ammoStateText;

	public Text ernStateText;

	public TextMeshProUGUI healthTitleText;

	public TextMeshProUGUI ammoTitleText;

	public TextMeshProUGUI healthText;

	public TextMeshProUGUI ammoText;

	public Image enableButtonImage;

	public GameObject enableButton;

	public GameObject armButton;

	public GameObject resupplyButton;

	public GameObject ernButton;

	public GameObject destroyButton;

	public Toggle avoidCreeperToggle;

	public GameObject buildHyperPathButton;

	public GameObject towerControls;

	public GameObject cannonControls;

	public GameObject sprayerControls;

	public GameObject deliveryPadControls;

	public GameObject podControls;

	public GameObject flyingUnitControls;

	public GameObject monolithControls;

	public GameObject payloadPadControls;

	public GameObject rocketPadControls;

	public GameObject reactorControls;

	public GameObject sniperControls;

	public GameObject commandBaseControls;

	public GameObject cmodUnitControls;

	public GameObject wallControls;

	public GameObject terpControls;

	public GameObject nullifierControls;

	public GameObject emitterDisplay;

	public GameObject createSquadButton;

	public GameObject selectSquadButton;

	public TextMeshProUGUI titleText;

	private float lastHealth;

	private float lastAmmo;

	private bool lastIsBuilding;

	private bool IsSquadMember()
	{
		return false;
	}

	public void LateUpdate()
	{
	}

	public void Refresh()
	{
	}

	public void OnHelpClicked()
	{
	}

	public void OnDestroyClicked()
	{
	}

	public void OnEnableClicked()
	{
	}

	public void OnArmClicked()
	{
	}

	public void OnResupplyClicked()
	{
	}

	public void OnERNClicked()
	{
	}

	public void OnAvoidCreeperChanged(bool val)
	{
	}
}
