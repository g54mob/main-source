using System;
using TMPro;
using UnityEngine;

[Serializable]
public class CafeStyleUpgrade
{
	public ButtonField button;

	public GameObject lockedScreen;

	public GameObject buyScreen;

	[SerializeField]
	private TMP_Text labelLocked;

	[SerializeField]
	private TMP_Text labelPrice;

	public bool locked;

	public bool bought;

	[Range(0f, 10f)]
	public int unlockLevel;

	[Range(0f, 2500f)]
	public int price;

	public void Lock()
	{
		locked = true;
		lockedScreen.SetActive(value: true);
		button.enabled = false;
		labelLocked.text = "LVL " + PopupMessageManager.GetHighlightBegin() + unlockLevel + PopupMessageManager.GetHighlightEnd();
		HideBuyScreen();
	}

	public void Unlock()
	{
		locked = false;
		lockedScreen.SetActive(value: false);
		button.enabled = true;
		labelLocked.text = "";
		ShowBuyScreen();
	}

	public void ShowBuyScreen()
	{
		bought = false;
		buyScreen.SetActive(value: true);
		button.enabled = true;
		labelPrice.text = price.ToString();
	}

	public void HideBuyScreen()
	{
		bought = true;
		buyScreen.SetActive(value: false);
		button.enabled = true;
		labelPrice.text = "";
	}
}
