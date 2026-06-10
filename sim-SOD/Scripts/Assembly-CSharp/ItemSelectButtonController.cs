using System;
using UnityEngine.UI;

public class ItemSelectButtonController : ButtonController
{
	[NonSerialized]
	public Interactable obj;

	public Image photo;

	public InfoWindow thisWindow;

	public void Setup(Interactable newInteractable, InfoWindow newThisWindow)
	{
	}

	public override void UpdateButtonText()
	{
	}

	public override void OnLeftClick()
	{
	}

	private void End()
	{
	}
}
