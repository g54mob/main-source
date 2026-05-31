using System;
using System.Collections.Generic;
using UnityEngine;
using __Project__.Scripts.Computer;

public class PopUpManager : NoktaSingleton<PopUpManager>
{
	private Queue<IPopUp> m_PopUpQueue;

	private bool m_IsShowing;

	private bool m_MovementCache;

	private bool m_CameraCache;

	private CursorLockMode m_CursorLockCache;

	private Computer m_Computer;

	private ScaleInteraction m_ScaleInteraction;

	private bool m_CursorVisibleCache;

	private float m_CachedTimeScale;

	private bool m_PauseCache;

	private bool m_WillCache;

	public Action onPopUpOpened;

	public Action onPopUpClosed;

	public bool IsShowing => false;

	private void Start()
	{
	}

	public void AddPopUp(IPopUp currentPopUp, bool isWholeSale = false, bool willCacheTime = true, bool isWelcomeSent = false)
	{
	}

	public void OnPopUpClosed()
	{
	}

	public void OnInteractionFinished()
	{
	}

	private void ShowPopUp(bool isWholeSale = false, bool willCacheTime = true, bool isWelcomeSent = false)
	{
	}

	private void CacheInteractionData(bool willStopTime = true)
	{
	}

	private void ApplyInteractionData()
	{
	}

	public bool CanShowPopUp(bool isOutsideCheck = false, bool isWholeSale = false, bool isWelcomeSent = false)
	{
		return false;
	}
}
public static class PopupManager
{
	private static Dictionary<PopupType, Popup> m_PopupPrefabRegistry;

	private static Canvas m_PopupCanvas;

	private static List<Popup> m_Popups;

	public static Popup ActivePopup { get; private set; }

	[RuntimeInitializeOnLoadMethod]
	private static void Load()
	{
	}

	public static Popup CreatePopup(PopupType type)
	{
		return null;
	}

	public static void DestroyPopup(Popup popup)
	{
	}
}
