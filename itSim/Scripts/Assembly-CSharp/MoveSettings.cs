using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoveSettings : MonoBehaviour
{
	[Header("Components")]
	public SimpleRCP simpleRCP;

	[Header("GameObject")]
	public GameObject Settigns;

	public GameObject EyeProtection;

	public GameObject cirle_off;

	public GameObject cirle_on;

	public GameObject[] _CategoriesView;

	[Header("Text")]
	public TextMeshProUGUI lightingDisplay;

	[Header("Network addressing")]
	public TMP_InputField[] InputFieldIpAddress;

	public TMP_InputField[] InputFieldIpMask;

	public TMP_InputField[] InputFieldIpGateway;

	[Header("Colors")]
	public Image bgEyeProtection;

	public string hexColorGray;

	public string hexColorBlue;

	private Color newColorGray;

	private Color newColorBlue;

	public void SetPaletteCollor()
	{
	}

	private void Start()
	{
	}

	public void ResetCategoriesView()
	{
	}

	public void ShowNetworkSettings()
	{
	}

	public void ShowRestartSettings()
	{
	}

	public void ShowModesSettings()
	{
	}

	public void ShowAvaiablity()
	{
	}

	public void ShowLockmode()
	{
	}

	public void ShowLocation()
	{
	}

	public void ShowUpdate()
	{
	}

	public void ShowAbout()
	{
	}

	public void IntoToSettings()
	{
	}

	public void RestartRCP()
	{
	}

	public void ApplyAddress()
	{
	}

	public void TcpIpViewUpdate()
	{
	}

	public void FillInputFields(SimpleRCP simpleRCP)
	{
	}

	private void SubscribeInputFields(TMP_InputField[] inputFields)
	{
	}

	private void CheckFieldLengthAndValue(TMP_InputField inputField)
	{
	}

	private TMP_InputField[] CombineInputFields()
	{
		return null;
	}

	public string GenerateSubnetMask(string ip)
	{
		return null;
	}

	public string GetIpFromOctetArray(TMP_InputField[] octet)
	{
		return null;
	}

	public void VerifyEyeProtection()
	{
	}

	public void SetProtection()
	{
	}

	public void SetLightingUp()
	{
	}

	public void SetLightingDown()
	{
	}
}
