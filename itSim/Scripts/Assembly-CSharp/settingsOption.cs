using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class settingsOption : MonoBehaviour
{
	[Header("Component Default")]
	public AppMovementFucus movementFucus;

	public WindowAppMinimalizeAnimation minimalizeAnimation;

	[Header("Component")]
	public ComputerStation computerStation;

	public systemOptionSettings SystemOptionSettings;

	public SystemOScypek SystemOScypek;

	public networkOption networkOption;

	public ComputerVariables computerVariables;

	public settingsOptionsOscypekUpdate oscypekUpdate;

	public PersonalizationSettings personalizationSettings;

	[Header("User Data")]
	public Image avatar;

	public TextMeshProUGUI nameUser;

	public TextMeshProUGUI mailUser;

	[SerializeField]
	[Header("Only Button Category")]
	private TextMeshProUGUI category_name;

	public Image but_system;

	public Image but_network;

	public Image but_personalization;

	public Image but_privacy;

	public Image but_update;

	public Image but_account;

	public GameObject pasek_system;

	public GameObject pasek_network;

	public GameObject pasek_personalization;

	public GameObject pasek_privacy;

	public GameObject pasek_update;

	public GameObject pasek_account;

	public GameObject cat_system;

	public GameObject cat_network;

	public GameObject cat_personalization;

	public GameObject cat_privacy;

	public GameObject cat_update;

	public GameObject cat_account;

	[Header("Color Background Button Category")]
	private Color newColor;

	[Header("View")]
	public GameObject settings;

	[Header("Coroutines")]
	public Coroutine checkingNetwork;

	private bool isOpen;

	public void OpenApp()
	{
	}

	public void CloseApp()
	{
	}

	public void Update()
	{
	}

	private void Start()
	{
	}

	public void ResetPaskow()
	{
	}

	public void ResetCategory()
	{
	}

	public void ResetColorBG()
	{
	}

	public void Chanage_category(Image bg, GameObject category, GameObject pasek, string name)
	{
	}

	public void OpenSystemSettings()
	{
	}

	public void OpenNetworkSettings()
	{
	}

	public void OpenPersonalizationSettings()
	{
	}

	public void OpenPrivacySettings()
	{
	}

	public void OpenUpdateSettings()
	{
	}

	public void OpenAccountSettings()
	{
	}
}
