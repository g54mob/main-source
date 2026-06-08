using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Login : Website
{
	[SerializeField]
	protected GameObject notificationPrefab;

	[SerializeField]
	protected Button login;

	[SerializeField]
	protected TMP_InputField username;

	[SerializeField]
	protected TMP_InputField password;

	protected override void Start()
	{
		base.Start();
		GetComponent<PlayerInput>().actions["Enter"].performed += delegate
		{
			if (CheckLogin())
			{
				LaunchNotificationPopup();
			}
		};
	}

	protected virtual bool CanLogin()
	{
		if (username.text.Length != 0)
		{
			return password.text.Length != 0;
		}
		return false;
	}

	protected virtual bool IsFocused()
	{
		if (!password.isFocused)
		{
			return username.isFocused;
		}
		return true;
	}

	public virtual void CheckEnableLogin()
	{
		login.interactable = CanLogin();
	}

	protected virtual bool CheckLogin()
	{
		if (CanLogin())
		{
			return IsFocused();
		}
		return false;
	}

	public virtual void LaunchNotificationPopup()
	{
	}
}
