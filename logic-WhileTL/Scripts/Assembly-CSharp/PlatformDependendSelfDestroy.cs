using UnityEngine;

public class PlatformDependendSelfDestroy : ActiveComponent
{
	public bool destroyIfDisableSteamworks;

	public bool destroyIfMobile;

	public bool destroyIfTablet;

	public bool destroyIfMac;

	public bool destroyIfStandalone;

	public bool destroyIfApple;

	public bool destroyIfNotAppstore;

	public bool destroyIfNotApple;

	public bool destroyIfStandaloneNotAppstore;

	public bool destroyIfMacAppStore;

	public bool destroyIfNS;

	public bool destroyIFNotNS;

	public bool destroyIfJoyCon;

	public bool destroyIfNotJoyCon;

	public bool destroyIfBigNodesMode;

	public bool destroyIfNotBigNodesMode;

	public bool destroyIfPS;

	public bool destroyIfNotPS;

	public bool destroyIfAndroid;

	public bool destroyIfNotAndroid;

	public bool destroyIfNotGooglePlay;

	public bool destroyIfNotGoG;

	public bool destroyIfGoG;

	public bool destroyIfEpic;

	public bool destroyIfNotEpic;

	public bool destroyIfNotDevelopment;

	public bool preserveForSteamDeck;

	public bool destroyIfNotSteamDeck;

	public bool destroyIfSteamDeck;

	public bool destroyIfSeamlessJoyCon;

	public bool destoryIfNotSeamlessJoyCon;

	private RewiredDependentHideShow curHide;

	private RewiredImageChange curImg;

	private RewiredTextChange curText;

	public void Check()
	{
		if (destroyIfSeamlessJoyCon)
		{
			if (!preserveForSteamDeck || !Logic.IsSteamDeckRunning())
			{
				Object.Destroy(base.gameObject);
			}
			return;
		}
		if (Logic.IsSteamDeckRunning() && destroyIfSteamDeck)
		{
			Object.Destroy(base.gameObject);
			return;
		}
		if (!Logic.IsSteamDeckRunning() && destroyIfNotSteamDeck)
		{
			Object.Destroy(base.gameObject);
			return;
		}
		bool flag = true;
		if (destroyIfBigNodesMode && flag)
		{
			Object.Destroy(base.gameObject);
		}
		else if (destroyIfNotBigNodesMode && !flag)
		{
			Object.Destroy(base.gameObject);
		}
		else if (destroyIfStandalone && !(destroyIfNotBigNodesMode && flag))
		{
			if (!preserveForSteamDeck || !Logic.IsSteamDeckRunning())
			{
				Object.Destroy(base.gameObject);
			}
		}
		else if (destroyIfNotApple)
		{
			Object.Destroy(base.gameObject);
		}
		else if (destroyIfNotAppstore)
		{
			Object.Destroy(base.gameObject);
		}
		else if (destroyIfStandaloneNotAppstore)
		{
			Object.Destroy(base.gameObject);
		}
		else if (destroyIFNotNS)
		{
			Object.Destroy(base.gameObject);
		}
		else if (destroyIfJoyCon)
		{
			Object.Destroy(base.gameObject);
		}
		else if (destroyIfNotPS)
		{
			Object.Destroy(base.gameObject);
		}
		else if (destroyIfNotAndroid)
		{
			Object.Destroy(base.gameObject);
		}
		else if (destroyIfNotGooglePlay)
		{
			Object.Destroy(base.gameObject);
		}
		else if (destroyIfNotGoG)
		{
			Object.Destroy(base.gameObject);
		}
		else if (destroyIfNotEpic)
		{
			Object.Destroy(base.gameObject);
		}
		else if (destroyIfNotDevelopment)
		{
			Object.Destroy(base.gameObject);
		}
		else
		{
			Object.Destroy(this);
		}
	}

	private void Awake()
	{
		curHide = base.gameObject.GetComponent<RewiredDependentHideShow>();
		curImg = base.gameObject.GetComponent<RewiredImageChange>();
		curText = base.gameObject.GetComponent<RewiredTextChange>();
	}

	private void Update()
	{
		if (ActiveComponent._staticData != null && !(curHide != null) && !(curImg != null) && !(curText != null))
		{
			Check();
		}
	}

	private void LateUpdate()
	{
		if (ActiveComponent._staticData != null && !(curHide != null) && !(curImg != null) && !(curText != null))
		{
			Check();
		}
	}
}
