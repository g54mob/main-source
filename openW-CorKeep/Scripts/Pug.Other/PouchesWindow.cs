using System.Collections.Generic;
using UnityEngine;

public class PouchesWindow : UIelement, ISlotHoverProxy
{
	public GameObject root;

	public List<SlotUIBase> proxiedSlots = new List<SlotUIBase>();

	public ButtonUIElement openButton;

	public override bool isShowing => root.activeSelf;

	public void Awake()
	{
		HidePouches();
	}

	public void TogglePouchWindow()
	{
		if (isShowing)
		{
			HidePouches();
		}
		else
		{
			ShowPouches();
		}
		AudioManager.Sfx(SfxTableID.inventorySFXInfoTab, Manager.main.player.transform.position);
	}

	private void ShowPouches()
	{
		root.SetActive(value: true);
	}

	public void HidePouches()
	{
		root.SetActive(value: false);
	}

	public IEnumerable<SlotUIBase> GetProxySlots()
	{
		return proxiedSlots;
	}

	public void SetHighliged(bool anySlotShouldBeProxied)
	{
		openButton.optionalSelectedMarker.gameObject.SetActive(anySlotShouldBeProxied);
	}
}
