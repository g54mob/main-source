using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class IconRightClickController : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[SerializeField]
	private GameObject dropdown;

	[SerializeField]
	private GameObject button;

	[SerializeField]
	private PanelManager tableManager;

	private Canvas canvas;

	private ClickDrag clickDrag;

	private void Awake()
	{
		canvas = UIUtils.FindCanvasFromChild(base.transform);
		tableManager = canvas.GetComponent<PanelManager>();
		clickDrag = GetComponentInParent<ClickDrag>();
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button != PointerEventData.InputButton.Right)
		{
			return;
		}
		string tableName = base.transform.parent.Find("Table Name").GetComponent<TextMeshProUGUI>().text;
		if (tableManager.IsReadOnly(tableName))
		{
			return;
		}
		float num = 0f;
		Vector3 position = eventData.pressPosition;
		Vector3 position2 = Camera.main.ScreenToWorldPoint(position);
		position2.z = 100f;
		GameObject gameObject = Object.Instantiate(dropdown, position2, Quaternion.identity, canvas.transform);
		UIUtils.SetPenultimateLayer(gameObject);
		Dropdown dropdownScript = gameObject.GetComponent<Dropdown>();
		ICollection<Icon> selectedIcons = new List<Icon>(clickDrag.GetSelectedIcons());
		if (selectedIcons.Count == 1)
		{
			if (tableManager.IsRenamable(tableName))
			{
				GameObject renameFieldObject = base.transform.parent.Find("Rename Field").gameObject;
				TMP_InputField renameField = renameFieldObject.GetComponent<TMP_InputField>();
				Button button = CreateRightClickDropdownButton(gameObject.transform, default(Vector3), "Rename table");
				button.onClick.AddListener(delegate
				{
					SoundEffectUtils.GetNotificationPlayer().PlayRename();
					renameFieldObject.SetActive(value: true);
					renameField.Select();
					dropdownScript.DestroyDropdown();
				});
				num += ((RectTransform)button.transform).rect.height;
			}
			if (tableManager.IsDeletable(tableName))
			{
				CreateRightClickDropdownButton(gameObject.transform, -new Vector2(0f, num), "Delete table").onClick.AddListener(delegate
				{
					DeleteTable(base.transform, tableName, dropdownScript);
					SoundEffectUtils.GetOpenClosePanelPlayer().PlayDestroy();
				});
			}
		}
		else
		{
			if (selectedIcons.Count < 1 || !CanDeleteAllIcons(selectedIcons))
			{
				return;
			}
			CreateRightClickDropdownButton(gameObject.transform, default(Vector3), "Delete tables").onClick.AddListener(delegate
			{
				foreach (Icon item in selectedIcons)
				{
					DeleteTable(item.transform, Icon.GetName(item), dropdownScript);
				}
				SoundEffectUtils.GetOpenClosePanelPlayer().PlayExplosion();
			});
		}
	}

	private bool CanDeleteAllIcons(ICollection<Icon> selectedIcons)
	{
		foreach (Icon selectedIcon in selectedIcons)
		{
			if (!tableManager.IsDeletable(Icon.GetName(selectedIcon)))
			{
				return false;
			}
		}
		return true;
	}

	private void DeleteTable(Transform icon, string tableName, Dropdown dropdownScript)
	{
		ThomasGridLayoutGroup.RemoveIconPos(icon.parent.localPosition);
		Save.RemoveIconPosition(tableName);
		DatabaseUtils.DropTable(tableName);
		tableManager.DestroyPanel(tableName);
		clickDrag.RemoveIcon(icon.GetComponent<Icon>());
		icon.GetComponentInParent<IconGenerator>().inputField.HighlightKeywords();
		clickDrag.ClearSelectedIcons();
		Object.Destroy(icon.parent.gameObject);
		dropdownScript.DestroyDropdown();
	}

	private Button CreateRightClickDropdownButton(Transform parent, Vector2 position, string label)
	{
		GameObject obj = Object.Instantiate(button, parent);
		obj.transform.localPosition = position;
		obj.GetComponentInChildren<TextMeshProUGUI>().text = label;
		return obj.GetComponent<Button>();
	}
}
