using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Michsky.DreamOS
{
	[AddComponentMenu("DreamOS/UI Elements/Context Menu Content")]
	public class ContextMenuContent : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
	{
		[Serializable]
		public class MenuItem
		{
			public string itemText;

			public string localizationKey;

			public Sprite itemIcon;

			public ContextItemType contextItemType;

			public UnityEvent onClick = new UnityEvent();
		}

		public enum ContextItemType
		{
			Button = 0,
			Separator = 1
		}

		[Header("Resources")]
		public ContextMenuManager contextManager;

		public Transform itemParent;

		[Header("Items")]
		public List<MenuItem> menuItems = new List<MenuItem>();

		private GameObject selectedItem;

		private void Awake()
		{
			if (base.gameObject.GetComponent<Image>() == null)
			{
				Image image = base.gameObject.AddComponent<Image>();
				image.color = new Color(0f, 0f, 0f, 0f);
				image.raycastTarget = true;
			}
		}

		private void Start()
		{
			if (contextManager == null)
			{
				try
				{
					contextManager = UnityEngine.Object.FindObjectsByType<ContextMenuManager>(FindObjectsSortMode.None)[0];
				}
				catch
				{
					Debug.Log("<b>[Context Menu]</b> Context Manager is missing.", this);
					return;
				}
			}
			itemParent = contextManager.contentRect.transform.Find("Item List").transform;
			foreach (Transform item in itemParent)
			{
				UnityEngine.Object.Destroy(item.gameObject);
			}
		}

		public void ProcessContent()
		{
			foreach (Transform item in itemParent)
			{
				UnityEngine.Object.Destroy(item.gameObject);
			}
			for (int i = 0; i < menuItems.Count; i++)
			{
				bool flag = false;
				if (menuItems[i].contextItemType == ContextItemType.Button && contextManager.buttonPreset != null)
				{
					selectedItem = contextManager.buttonPreset;
				}
				else if (menuItems[i].contextItemType == ContextItemType.Separator && contextManager.separatorPreset != null)
				{
					selectedItem = contextManager.separatorPreset;
				}
				else
				{
					Debug.LogError("<b>[Context Menu]</b> At least one of the item preset is missing.", this);
					flag = true;
				}
				if (flag)
				{
					continue;
				}
				GameObject gameObject = UnityEngine.Object.Instantiate(selectedItem, new Vector3(0f, 0f, 0f), Quaternion.identity);
				gameObject.transform.SetParent(itemParent, worldPositionStays: false);
				if (menuItems[i].contextItemType == ContextItemType.Button)
				{
					ButtonManager component = gameObject.GetComponent<ButtonManager>();
					LocalizedObject component2 = component.gameObject.GetComponent<LocalizedObject>();
					if (string.IsNullOrEmpty(menuItems[i].localizationKey) || component2 == null || !component2.CheckLocalizationStatus())
					{
						component.SetText(menuItems[i].itemText);
					}
					else if (component2 != null)
					{
						component.SetText(component2.GetKeyOutput(menuItems[i].localizationKey));
					}
					if (menuItems[i].itemIcon == null)
					{
						component.SetIcon(null);
					}
					else
					{
						component.SetIcon(menuItems[i].itemIcon);
					}
					ButtonManager component3 = gameObject.GetComponent<ButtonManager>();
					component3.onClick.AddListener(menuItems[i].onClick.Invoke);
					component3.onClick.AddListener(contextManager.Close);
				}
				StopCoroutine("ExecuteAfterTime");
				StartCoroutine("ExecuteAfterTime", 0.01f);
			}
			contextManager.SetContextMenuPosition();
			contextManager.Open();
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			if (contextManager.isOn)
			{
				contextManager.Close();
			}
			else if (eventData.button == PointerEventData.InputButton.Right && !contextManager.isOn)
			{
				ProcessContent();
			}
		}

		private IEnumerator ExecuteAfterTime(float time)
		{
			yield return new WaitForSeconds(time);
			itemParent.gameObject.SetActive(value: false);
			itemParent.gameObject.SetActive(value: true);
		}

		public void CreateNewButton(string title, Sprite icon)
		{
			MenuItem menuItem = new MenuItem();
			menuItem.itemText = title;
			menuItem.itemIcon = icon;
			menuItems.Add(menuItem);
		}
	}
}
