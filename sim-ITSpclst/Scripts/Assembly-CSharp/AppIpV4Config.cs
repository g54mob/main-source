using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AppIpV4Config : MonoBehaviour
{
	[Header("Components")]
	public ComputerNetwork computerNetwork;

	[Header("Component Default")]
	public AppMovementFucus movementFucus;

	public WindowAppMinimalizeAnimation minimalizeAnimation;

	[Header("Component")]
	public AppBase AppBase;

	[Header("UI")]
	public Toggle IpDHCP;

	public Toggle IpStatic;

	public Image[] IpBackgroung;

	public TMP_InputField[] InputFieldIpAddress;

	public TMP_InputField[] InputFieldIpMask;

	public TMP_InputField[] InputFieldIpGateway;

	public CanvasGroup canvasGroupIpDHCP;

	[HideInInspector]
	public bool isOpen;

	private void Start()
	{
	}

	public void FillInputFields(ComputerNetwork computerNetwork)
	{
	}

	public void OpenApp()
	{
	}

	public void CloseApp()
	{
	}

	private void Update()
	{
	}

	private void SubscribeInputFields(TMP_InputField[] inputFields)
	{
	}

	private void NavigateToNextField()
	{
	}

	private void CheckFieldLengthAndValue(TMP_InputField inputField)
	{
	}

	private TMP_InputField[] CombineInputFields()
	{
		return null;
	}

	public void UpdateIpUI()
	{
	}

	public void Apply()
	{
	}

	public string GenerateSubnetMask(string ip)
	{
		return null;
	}

	public string GetIpFromOctetArray(TMP_InputField[] octet)
	{
		return null;
	}
}
