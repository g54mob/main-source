using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AppUserAccount : PTSMonoBehaviour
{
	[Header("Component Default")]
	public AppMovementFucus movementFucus;

	public WindowAppMinimalizeAnimation minimalizeAnimation;

	public ComputerVariables computerVariables;

	public NotifiSystemManager notifiSystemManager;

	public WarningDatabase warningDatabase;

	public AdminAcceptData adminAcceptData;

	[Header("Component")]
	public AppBase AppBase;

	[HideInInspector]
	public bool isOpen;

	[Header("Additional View")]
	public GameObject secoundView;

	public GameObject thirdView;

	public GameObject fourView;

	[Header("First View Data")]
	public TextMeshProUGUI FV_nameAccount;

	public TextMeshProUGUI FV_mail;

	public GameObject FV_isAdminText;

	public Image FV_avatarAccount;

	[Header("Secound View Data")]
	public TextMeshProUGUI SV_nameAccount;

	public TextMeshProUGUI SV_mail;

	public TextMeshProUGUI SV_isAdminText;

	public Image SV_avatarAccount;

	[Header("Third View Data")]
	public TextMeshProUGUI TV_nameAccount;

	public TextMeshProUGUI TV_mail;

	public TextMeshProUGUI TV_isAdminText;

	public Image TV_avatarAccount;

	[Header("Four View Data")]
	public TextMeshProUGUI FourV_nameAccount;

	public TextMeshProUGUI FourV_mail;

	public TextMeshProUGUI FourV_isAdminText;

	public Image FourV_avatarAccount;

	public void OpenApp()
	{
	}

	public void CloseApp()
	{
	}

	public void RefreshFirstView()
	{
	}

	public void OpenSecoundView()
	{
	}

	public void OpenAfterAcceptAdmin()
	{
	}

	public void CloseSecoundView()
	{
	}

	public void SetAcccountType()
	{
	}

	public void OpenThirdView()
	{
	}

	public void OpenAfterAcceptAdminThirdView()
	{
	}

	public void CloseThirdView()
	{
	}

	public void OpenFourView()
	{
	}

	public void OpenFourChangeType()
	{
	}

	public void OpenFourManagerAccount()
	{
	}
}
