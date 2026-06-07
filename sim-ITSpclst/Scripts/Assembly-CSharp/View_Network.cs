using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class View_Network : MonoBehaviour
{
	public SimplePrinter printer;

	[SerializeField]
	private GameObject View_TcpIp;

	[SerializeField]
	private GameObject View_Ethernet;

	[SerializeField]
	private GameObject View_IPsec;

	[SerializeField]
	private GameObject View_LDAP;

	[SerializeField]
	private GameObject View_Bonjour;

	[SerializeField]
	private GameObject View_IPP;

	[SerializeField]
	private GameObject OnOffIPsec_View;

	[SerializeField]
	private GameObject OnOffBonjour_View;

	[SerializeField]
	private GameObject OnOffIPP_View;

	[SerializeField]
	[TextArea(5, 17)]
	private string[] informationAboutFunction;

	public TMP_InputField[] InputFieldIpAddress;

	public TMP_InputField[] InputFieldIpMask;

	public TMP_InputField[] InputFieldIpGateway;

	[SerializeField]
	private TextMeshProUGUI conn_speed;

	[SerializeField]
	private TextMeshProUGUI work_mode;

	[SerializeField]
	private TextMeshProUGUI onoffbuttonText;

	[SerializeField]
	private TextMeshProUGUI encryption_method;

	[SerializeField]
	private TextMeshProUGUI operation_mode;

	[SerializeField]
	private TextMeshProUGUI key_management;

	[SerializeField]
	private TextMeshProUGUI onoffBonjourbuttonText;

	[SerializeField]
	private TextMeshProUGUI scopeOfSharingText;

	[SerializeField]
	private TextMeshProUGUI onoffIPPbuttonText;

	[SerializeField]
	private TextMeshProUGUI IppOverHttpsText;

	private int[] valueForConnectionSpeed;

	private int[] valueForWorkMode;

	private int[] valueForOnOffIPSec;

	private int[] valueForEncryptionMethod;

	private int[] valueForOperationMode;

	private int[] valueForKeyManagement;

	private int[] valueForOnOffBonjour;

	private int[] valueForScopeOfSharing;

	private int[] valueForOnOffIPP;

	private int[] valueForIppOverHttps;

	public Button conn_speed_button;

	public Button work_mode_button;

	public Button onoff_ipsec_button;

	public Button encryption_method_button;

	public Button operation_mode_button;

	public Button key_management_button;

	public Button onoff_bonjour_button;

	public Button scope_of_sharing_button;

	public Button onoff_ipp_button;

	public Button ipp_over_https_button;

	private void Start()
	{
	}

	public void ResetView()
	{
	}

	public void Show_View(GameObject view)
	{
	}

	public void Information(int information)
	{
	}

	public void EthernetViewUpdate()
	{
	}

	public void IPsecViewUpdate()
	{
	}

	public void BonjourViewUpdate()
	{
	}

	public void IppViewUpdate()
	{
	}

	public void TcpIpViewUpdate()
	{
	}

	public void FillInputFields(SimplePrinter simplePrinter)
	{
	}

	public void Set_DefaultValue()
	{
	}

	public void ApplyAddress()
	{
	}

	public void ChangeIntValue(Action action, Func<int> getter, Action<int> setter, int[] array)
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
}
