using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ES3SlotManager : MonoBehaviour
{
	[Tooltip("Shows a confirmation if this slot already exists when we select it.")]
	public bool showConfirmationIfExists = true;

	[Tooltip("Whether the Create new slot button should be visible.")]
	public bool showCreateSlotButton = true;

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
	public string slotDirectory = "slots/";

	[Tooltip("The extension we want to use for our save files.")]
	public string slotExtension = ".es3";

	[Space(16f)]
	[Tooltip("The template we'll instantiate to create our slots.")]
	public GameObject slotTemplate;

	[Tooltip("The dialog box for creating a new slot.")]
	public GameObject createDialog;

	[Tooltip("The dialog box for displaying an error to the user.")]
	public GameObject errorDialog;

	public static string selectedSlotPath = null;

	public List<GameObject> slots = new List<GameObject>();

	private static DateTime falseDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

	protected virtual void OnEnable()
	{
		slotTemplate.SetActive(value: false);
		DestroySlots();
		InstantiateSlots();
	}

	protected virtual void InstantiateSlots()
	{
		List<(string, DateTime)> list = new List<(string, DateTime)>();
		if (!ES3.DirectoryExists(slotDirectory))
		{
			return;
		}
		string[] files = ES3.GetFiles(slotDirectory);
		for (int i = 0; i < files.Length; i++)
		{
			string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(files[i]);
			DateTime item = ES3.GetTimestamp(GetSlotPath(fileNameWithoutExtension)).ToLocalTime();
			list.Add((fileNameWithoutExtension, item));
		}
		list = list.OrderByDescending<(string, DateTime), DateTime>(((string Name, DateTime Timestamp) x) => x.Timestamp).ToList();
		foreach (var item2 in list)
		{
			InstantiateSlot(item2.Item1, item2.Item2);
		}
	}

	public virtual ES3Slot InstantiateSlot(string slotName, DateTime timestamp)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(slotTemplate, slotTemplate.transform.parent);
		slots.Add(gameObject);
		gameObject.SetActive(value: true);
		ES3Slot component = gameObject.GetComponent<ES3Slot>();
		component.nameLabel.text = slotName.Replace('_', ' ');
		if (timestamp == falseDateTime)
		{
			component.timestampLabel.text = "";
		}
		else
		{
			component.timestampLabel.text = timestamp.ToString("yyyy-MM-dd") + "\n" + timestamp.ToString("HH:mm:ss");
		}
		return component;
	}

	public virtual ES3Slot CreateNewSlot(string slotName)
	{
		DateTime now = DateTime.Now;
		ES3Slot eS3Slot = InstantiateSlot(slotName, now);
		eS3Slot.MoveToTop();
		if (autoCreateSaveFile)
		{
			ES3.SaveRaw("{}", GetSlotPath(slotName));
		}
		if (selectSlotAfterCreation)
		{
			eS3Slot.SelectSlot();
		}
		ScrollToTop();
		return eS3Slot;
	}

	public virtual void ShowErrorDialog(string errorMessage)
	{
		errorDialog.transform.Find("Dialog Box/Message").GetComponent<TMP_Text>().text = errorMessage;
		errorDialog.SetActive(value: true);
	}

	protected virtual void DestroySlots()
	{
		foreach (GameObject slot in slots)
		{
			UnityEngine.Object.Destroy(slot);
		}
		slots.Clear();
	}

	public virtual string GetSlotPath(string slotName)
	{
		return slotDirectory + Regex.Replace(slotName, "\\s+", "_") + slotExtension;
	}

	public void ScrollToTop()
	{
		base.transform.Find("Scroll View").GetComponent<ScrollRect>().verticalNormalizedPosition = 1f;
	}
}
