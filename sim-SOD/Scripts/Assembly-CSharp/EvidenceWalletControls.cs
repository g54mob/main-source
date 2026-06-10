using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EvidenceWalletControls : MonoBehaviour
{
	public InfoWindow parentWindow;

	public Sprite moneySprite;

	public Sprite cardSprite;

	public Sprite keySprite;

	public static List<EvidenceWalletControls> allItems;

	[Header("Wallet")]
	public ButtonController button;

	public TextMeshProUGUI buttonText;

	[NonSerialized]
	public Human.WalletItem itemRef;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void CheckEnabled()
	{
	}

	public void VisualUpdate(int walletIndex)
	{
	}

	public void OnButtonPress()
	{
	}
}
