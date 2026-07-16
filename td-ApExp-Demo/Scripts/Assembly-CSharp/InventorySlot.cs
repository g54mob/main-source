using System;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
	public Image IconImage;

	public Button Button;

	[NonSerialized]
	public Image rarityBorder;

	private void Awake()
	{
		Button = GetComponent<Button>();
		rarityBorder = GetComponent<Image>();
	}
}
