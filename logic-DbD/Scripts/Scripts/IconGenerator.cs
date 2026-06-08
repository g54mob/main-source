using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IconGenerator : MonoBehaviour
{
	[SerializeField]
	private GameObject iconPrefab;

	[SerializeField]
	private CreatePanels panelConstructor;

	[SerializeField]
	private NotificationHandler errorHandler;

	[SerializeField]
	private PanelManager tableManager;

	[SerializeField]
	public QueryInputUtils inputField;

	private static GameObject notification;

	private static ClickDrag clickDrag;

	private void Start()
	{
		if (!CreateTables.DEV_MODE)
		{
			IconMoveIn();
		}
		clickDrag = GetComponent<ClickDrag>();
		clickDrag.PopulateIconPositions();
		GenerateIcons();
	}

	public void IconMoveIn()
	{
		GetComponent<Animator>().Play("Move In Icons");
	}

	public void IconMoveOut()
	{
		GetComponent<Animator>().Play("Move Out Icons");
	}

	public void GenerateIcons()
	{
		foreach (string item in (IEnumerable<string>)(from tableName in DatabaseUtils.GetAllTableNames(DatabaseUtils.GetConnection())
			orderby !ReadOnlyTables.CoreTableNames().Contains(tableName)
			select tableName).ToList())
		{
			try
			{
				if (ReadOnlyTables.PostponedTableNames().Contains(item) || ReadOnlyTables.IsGeneratedTable(item))
				{
					panelConstructor.CreateDeletablePanel(item).SetActive(value: false);
				}
				else if (ReadOnlyTables.IsReadOnlyTable(item))
				{
					panelConstructor.CreateGivenPanel(item).SetActive(value: false);
				}
				else
				{
					panelConstructor.CreateUserPanel(item, save: true).SetActive(value: false);
				}
				GameObject gameObject = CreateIcon(item);
				if (ReadOnlyTables.CoreTableNames().Contains(item))
				{
					AddLocksToIcon(gameObject);
				}
				ThomasGridLayoutGroup.AddIcon(gameObject.transform);
			}
			catch (IllegalQueryException)
			{
				DatabaseUtils.DropTable(item);
			}
		}
	}

	public void ClearIcons()
	{
		foreach (Transform item in base.transform)
		{
			Icon componentInChildren = item.GetComponentInChildren<Icon>();
			if (componentInChildren.IsTable())
			{
				ThomasGridLayoutGroup.RemoveIconPos(item.localPosition);
				Save.RemoveIconPosition(componentInChildren.GetIconName());
				clickDrag.RemoveIcon(componentInChildren);
				UnityEngine.Object.Destroy(item.gameObject);
			}
		}
		clickDrag.ClearSelectedIcons();
	}

	public GameObject CreateIcon(string tableName)
	{
		GameObject gameObject = GenerateIcon(tableName);
		Icon icon = gameObject.GetComponentInChildren<Icon>();
		GameObject renameFieldObject = gameObject.transform.Find("Rename Field").gameObject;
		TextMeshProUGUI iconText = gameObject.transform.Find("Table Name").GetComponent<TextMeshProUGUI>();
		TMP_InputField renameField = renameFieldObject.GetComponent<TMP_InputField>();
		TMP_InputField tMP_InputField = renameField;
		tMP_InputField.onValidateInput = (TMP_InputField.OnValidateInput)Delegate.Combine(tMP_InputField.onValidateInput, (TMP_InputField.OnValidateInput)((string input, int charIndex, char addedChar) => ValidateTableName(addedChar)));
		renameField.onEndEdit.AddListener(delegate
		{
			string text = iconText.text;
			string text2 = renameField.text;
			renameField.text = "";
			renameFieldObject.SetActive(value: false);
			if (IsTableNameValid(errorHandler, text2))
			{
				DatabaseUtils.RenameTable(text, text2);
				iconText.text = text2;
				tableManager.RenamePanel(text, text2);
				inputField.HighlightKeywords();
				SoundEffectUtils.GetNotificationPlayer().PlayRenameSuccess();
			}
			icon.SetName(iconText.text);
		});
		icon.SetName(iconText.text);
		clickDrag.AddIcon(gameObject);
		return gameObject;
	}

	public void GenerateReadonlyIcon(string tableName)
	{
		if (ReadOnlyTables.IsReadOnlyTable(tableName))
		{
			GameObject gameObject = CreateIcon(tableName);
			ThomasGridLayoutGroup.AddIcon(gameObject.transform);
			AddLocksToIcon(gameObject);
			panelConstructor.CreateGivenPanel(tableName).SetActive(value: false);
		}
	}

	public void GenerateDeleteonlyIcon(string tableName)
	{
		Debug.Log("Generating icon for: " + tableName);
		ThomasGridLayoutGroup.AddIcon(CreateIcon(tableName).transform);
		panelConstructor.CreateDeletablePanel(tableName).SetActive(value: false);
	}

	private void AddLocksToIcon(GameObject icon)
	{
		Sprite image = ResourcesManager.GetImage("UI/document lock taskbar");
		Sprite image2 = ResourcesManager.GetImage("UI/document lock 1 52");
		Sprite image3 = ResourcesManager.GetImage("UI/document lock 2 52");
		icon.GetComponentInChildren<Button>().gameObject.GetComponent<Image>().sprite = image2;
		TableIcon componentInChildren = icon.GetComponentInChildren<TableIcon>();
		componentInChildren.SetTaskbarIcon(image);
		if (true)
		{
			componentInChildren.PlayAnimation();
		}
		else
		{
			componentInChildren.StopAnimation();
		}
		componentInChildren.hasNotifications = true;
		componentInChildren.SetSprites(image2, image3);
	}

	private GameObject GenerateIcon(string tableName)
	{
		GameObject obj = UnityEngine.Object.Instantiate(iconPrefab, base.transform);
		obj.transform.Find("Table Name").GetComponent<TextMeshProUGUI>().text = tableName;
		return obj;
	}

	public static char ValidateTableName(char charToValidate)
	{
		if (char.IsLetter(charToValidate) || char.IsNumber(charToValidate) || charToValidate == '_')
		{
			return UIUtils.RemoveDiacritics(charToValidate);
		}
		return '\0';
	}

	public static bool IsTableNameValid(NotificationHandler errorHandler, string name)
	{
		if (name.Equals("table", StringComparison.OrdinalIgnoreCase) || QueryParser.IsKeyword(name) || QueryParser.ILLEGAL_MATERIALS.Contains(name) || ReadOnlyTables.IsPostponedTableName(name) || ReadOnlyTables.IsGeneratedTable(name))
		{
			ClearNotification();
			notification = errorHandler.CreateNotificationPanel("<b>" + name + "</b> cannot be used as a table name. Please choose another.");
			PanelManager.OpenWindow(notification);
			return false;
		}
		if (name == string.Empty)
		{
			return false;
		}
		bool flag = DatabaseUtils.GetAllTableNames().Any((string s) => s.Equals(name, StringComparison.OrdinalIgnoreCase));
		if (flag || char.IsNumber(name[0]))
		{
			ClearNotification();
			notification = errorHandler.CreateNotificationPanel();
			if (flag)
			{
				errorHandler.SetNotificationMessage(notification, "Table name already used. Please choose another.");
			}
			else if (char.IsNumber(name[0]))
			{
				errorHandler.SetNotificationMessage(notification, "Table names cannot start with a number.");
			}
			PanelManager.OpenWindow(notification);
			return false;
		}
		return true;
	}

	private static void ClearNotification()
	{
		if (notification != null)
		{
			UnityEngine.Object.Destroy(notification);
		}
	}
}
