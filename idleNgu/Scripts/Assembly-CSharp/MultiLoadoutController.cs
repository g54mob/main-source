using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MultiLoadoutController : MonoBehaviour
{
	public LoadoutDisplayController[] loadouts;

	public Character character;

	public HoverTooltip tooltip;

	public ConfirmationBox box;

	public GameObject loadoutPanel;

	public GameObject invMenu;

	public int loadoutID;

	public bool panelShown;

	public InputField newLabel;

	public Text[] labels;

	public Text loadoutTitle;

	public Button[] loadoutPanelButtons;

	public Button[] invPanelButtons;

	public Button loadoutPanelInvButton;

	public GameObject anchor;

	private UnityAction yesAction;

	private UnityAction noAction;

	public void cancel()
	{
	}

	public void Start()
	{
		noAction = cancel;
		loadoutPanel.transform.position = invMenu.transform.position;
		loadoutPanel.transform.Translate(new Vector3(0f, -130f));
		loadoutPanel.transform.Translate(new Vector3(Screen.width * 2, Screen.height * 2));
	}

	public void setloadoutID(int newID)
	{
		if (newID >= character.inventoryController.loadoutSpaces())
		{
			tooltip.showOverrideTooltip("You haven't unlocked this Loadout Slot yet!");
			return;
		}
		if (newLabel.text != "")
		{
			if (newLabel.text.Length > 16)
			{
				newLabel.text = newLabel.text.Substring(0, 16);
			}
			character.inventory.loadouts[newID].loadoutName = newLabel.text;
			newLabel.text = "";
		}
		else
		{
			for (int i = 0; i < loadouts.Length; i++)
			{
				loadouts[i].loadoutID = newID;
				loadouts[i].updateItem();
			}
			loadoutID = newID;
		}
		refresh();
	}

	public void equipCurrentLoadout()
	{
		character.inventoryController.equipLoadout(loadoutID);
		refresh();
	}

	public void startAssign()
	{
		yesAction = assignCurrentEquipToLoadout;
		box.displayBox("Are you sure you want to assign your current equipment to the \"" + character.inventory.loadouts[loadoutID].loadoutName + "\" loadout?", yesAction, noAction);
	}

	public void assignCurrentEquipToLoadout()
	{
		character.inventoryController.assignCurrentEquipToLoadout(loadoutID);
		refresh();
	}

	public void refresh()
	{
		if (character.inventoryController.loadoutSpaces() > 0)
		{
			loadoutPanelInvButton.interactable = true;
		}
		else
		{
			loadoutPanelInvButton.interactable = false;
		}
		for (int i = 0; i < character.inventory.loadouts.Count; i++)
		{
			if (i >= character.inventoryController.loadoutSpaces())
			{
				loadoutPanelButtons[i].interactable = false;
				invPanelButtons[i].interactable = false;
			}
			else
			{
				loadoutPanelButtons[i].interactable = true;
				invPanelButtons[i].interactable = true;
			}
			if (i == loadoutID)
			{
				loadoutPanelButtons[i].image.color = new Color(1f, 0.827f, 0.235f);
			}
			else
			{
				loadoutPanelButtons[i].image.color = Color.white;
			}
			if (character.inventory.loadouts[i].loadoutName != "")
			{
				labels[i].text = character.inventory.loadouts[i].loadoutName;
			}
		}
		for (int j = 0; j < loadouts.Length; j++)
		{
			loadouts[j].updateItem();
		}
		loadoutTitle.text = character.inventory.loadouts[loadoutID].loadoutName;
	}

	public void showPanel()
	{
		if (!panelShown)
		{
			loadoutPanel.transform.position = anchor.transform.position;
			panelShown = true;
			character.inventoryController.daycaresController.hidePanel();
		}
		else
		{
			hidePanel();
		}
		refresh();
	}

	public void hidePanel()
	{
		if (panelShown)
		{
			loadoutPanel.transform.position = new Vector3(-5000f, -5000f);
			panelShown = false;
		}
		refresh();
	}

	public void showLoadoutNameOnTooltip(int id)
	{
		string message = "<b>" + character.inventory.loadouts[id].loadoutName + "</b>";
		tooltip.showOverrideTooltip(message);
	}

	public void hideTooltip()
	{
		tooltip.hideTooltip();
	}
}
