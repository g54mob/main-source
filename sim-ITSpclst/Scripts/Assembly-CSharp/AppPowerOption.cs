using UnityEngine;
using UnityEngine.UI;

public class AppPowerOption : MonoBehaviour
{
	[Header("Component Default")]
	public AppMovementFucus movementFucus;

	public WindowAppMinimalizeAnimation minimalizeAnimation;

	public ComputerVariables computerVariables;

	[Header("Component")]
	public AppBase AppBase;

	[HideInInspector]
	public bool isOpen;

	[Header("Image")]
	public Image buttonBalanced;

	public Image buttonHighPerformance;

	[Header("GameObject")]
	public GameObject additionalView;

	public GameObject checkbox1;

	public GameObject checkbox2;

	public GameObject checkbox3;

	public GameObject checkbox4;

	private string grayColor;

	private string blueColor;

	private Color newGrayColor;

	private Color newBlueColor;

	[Header("Variables")]
	public bool sleepOptionChecked;

	public bool hibernationOptionCheckded;

	public bool lockOptionChecked;

	public string GrayColor
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public string BlueColor
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public void OpenApp()
	{
	}

	private void SetColorPallete()
	{
	}

	public void CloseApp()
	{
	}

	public void RefreshView()
	{
	}

	public void RefreshSecoundView()
	{
	}

	public void SetBalanced(bool setter)
	{
	}

	public void ExitSecoundView()
	{
	}

	public void EnterSecoundView()
	{
	}

	public void SetEnabledFastStartup()
	{
	}

	public void SetSleep()
	{
	}

	public void SetHibernation()
	{
	}

	public void SetLock()
	{
	}
}
