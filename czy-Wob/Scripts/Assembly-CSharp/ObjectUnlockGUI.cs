using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjectUnlockGUI : MonoBehaviour
{
	public delegate void GUIClosedCallback();

	private GUIClosedCallback closedCallback;

	public TextMeshProUGUI unlockText;

	public TextMeshProUGUI itemNameText;

	public Image itemSprite;

	public InchwormBounce iconBouncer;

	public TextScaleInOnLoad titleTextScaleEffect;

	public TextScaleInOnLoad objectNameScaleEffect;

	private float standardSoundDelay = 0.75f;

	private string windowOpenSound = "newUnlock_open";

	private GUIManagerPens guiRef;

	private void Update()
	{
		if (GameControls.actions.CloseMenu.WasPressed)
		{
			OnOkButtonClicked();
		}
	}

	public void SetUnlockedObject(Researchable researchableRef, GUIClosedCallback newCallback = null, float soundDelay = -1f)
	{
		if (researchableRef.inventoryItemUnlock != null)
		{
			SetUnlockViaInventoryItem(researchableRef.inventoryItemUnlock, newCallback);
		}
		else if (researchableRef.roomCustomizationObjectUnlock != null)
		{
			SetUnlockViaRoomCustomizationObject(researchableRef.roomCustomizationObjectUnlock, newCallback);
		}
		else
		{
			Debug.LogError("No unlock found!");
		}
		InitializeGUI(soundDelay);
	}

	public void SetUnlockViaInventoryItem(InventoryItem itemRef, GUIClosedCallback newCallback = null)
	{
		closedCallback = newCallback;
		unlockText.text = ScriptLocalization.GUI.GUI_GOALS_ITEMREC;
		itemSprite.sprite = itemRef.icon;
		itemNameText.text = itemRef.itemNameLocalized;
	}

	public void SetUnlockViaRoomCustomizationObject(RoomCustomizationObject objectRef, GUIClosedCallback newCallback = null)
	{
		closedCallback = newCallback;
		unlockText.text = ScriptLocalization.GUI.GUI_GOALS_OBJUNLOCKED;
		itemSprite.sprite = objectRef.icon;
		itemNameText.text = objectRef.GetName();
	}

	private void InitializeGUI(float soundDelay = -1f)
	{
		iconBouncer.RequestBounce();
		titleTextScaleEffect.RequestScaleIn();
		objectNameScaleEffect.RequestScaleIn();
		if (soundDelay < 0f)
		{
			soundDelay = standardSoundDelay;
		}
		AudioController.Play(windowOpenSound, 1f, soundDelay);
	}

	public void OnOkButtonClicked()
	{
		if (guiRef == null)
		{
			guiRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI);
		}
		guiRef.HideObjectUnlockGUI();
		if (closedCallback != null)
		{
			closedCallback();
			closedCallback = null;
		}
	}
}
