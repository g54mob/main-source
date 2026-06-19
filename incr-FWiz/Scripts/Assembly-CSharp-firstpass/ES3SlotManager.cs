using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ES3SlotManager : MonoBehaviour
{
	[Tooltip("Shows a confirmation if this slot already exists when we select it.")]
	public bool showConfirmationIfExists;

	[Tooltip("Whether the Create new slot button should be visible.")]
	public bool showCreateSlotButton;

	[Tooltip("Whether we should automatically create an empty save file when the user creates a new save slot. This will be created using the default settings, so you should set this to false if you are using ES3Settings objects.")]
	public bool autoCreateSaveFile;

	[Tooltip("Whether a save slot should be selected after a user creates it.")]
	public bool selectSlotAfterCreation;

	[Space(16f)]
	[Tooltip("The name of a scene to load after the user chooses a slot.")]
	public string loadSceneAfterSelectSlot;

	[Space(16f)]
	[Tooltip("An event called after a slot is selected, but before the scene specified by loadSceneAfterSelectSlot is loaded.")]
	public UnityEvent onAfterSelectSlot;

	[Tooltip("An event called after a slot is created by a user, but hasn't been selected.")]
	public UnityEvent onAfterCreateSlot;

	[Space(16f)]
	[Tooltip("The subfolder we want to store our save files in. If this is a relative path, it will be relative to Application.persistentDataPath.")]
	public string slotDirectory;

	[Tooltip("The extension we want to use for our save files.")]
	public string slotExtension;

	[Space(16f)]
	[Tooltip("The template we'll instantiate to create our slots.")]
	public GameObject slotTemplate;

	[Tooltip("The dialog box for creating a new slot.")]
	public GameObject createDialog;

	[Tooltip("The dialog box for displaying an error to the user.")]
	public GameObject errorDialog;

	public static string selectedSlotPath;

	public List<GameObject> slots;

	private static DateTime falseDateTime;

	protected virtual void OnEnable()
	{
	}

	protected virtual void InstantiateSlots()
	{
	}

	public virtual ES3Slot InstantiateSlot(string slotName, DateTime timestamp)
	{
		return null;
	}

	public virtual ES3Slot CreateNewSlot(string slotName)
	{
		return null;
	}

	public virtual void ShowErrorDialog(string errorMessage)
	{
	}

	protected virtual void DestroySlots()
	{
	}

	public virtual string GetSlotPath(string slotName)
	{
		return null;
	}

	public void ScrollToTop()
	{
	}
}
