using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Kamgam.UGUIComponentsForSettings
{
	public class TabButtonUGUI : MonoBehaviour
	{
		public int GroupID;

		public int IndexID;

		public TabManagerUGUI tabManager;

		public Image ButtonImage;

		public TextMeshProUGUI ButtonText;

		public GameObject Content;

		public Color activeButtonColor;

		public Color deactiveButtonColor;

		public Color activeTextColor;

		public Color deactiveTextColor;

		public bool IsActive;

		public bool changeVisual = true;

		public bool hasEvents;

		public UnityEvent activeEvent;

		public string Text
		{
			get
			{
				return ButtonText.text;
			}
			set
			{
				if (!(value == Text))
				{
					ButtonText.text = value;
				}
			}
		}

		public void SetActive(bool active)
		{
			SetActive(active, includeInactiveSiblings: false);
			if (active)
			{
				tabManager.currentIndexID = IndexID;
				if (hasEvents)
				{
					activeEvent.Invoke();
				}
			}
		}

		public void SetActive(bool active, bool includeInactiveSiblings)
		{
			setActiveInternal(active);
			UpdateSiblings(includeInactiveSiblings);
			IsActive = active;
		}

		protected void setActiveInternal(bool active)
		{
			if (changeVisual)
			{
				if (active)
				{
					ButtonImage.color = activeButtonColor;
					ButtonText.color = activeTextColor;
				}
				else if (!active)
				{
					ButtonImage.color = deactiveButtonColor;
					ButtonText.color = deactiveTextColor;
				}
			}
			if (Content != null)
			{
				Content.gameObject.SetActive(active);
			}
		}

		public void UpdateSiblings(bool includeInactive = false)
		{
			foreach (TabButtonUGUI item in FindSiblings(includeInactive))
			{
				if (item != this)
				{
					item.setActiveInternal(active: false);
				}
			}
		}

		public List<TabButtonUGUI> FindSiblings(bool includeInactive = false)
		{
			List<TabButtonUGUI> list = new List<TabButtonUGUI>();
			Transform parent = base.transform.parent;
			if (parent == null)
			{
				GameObject[] rootGameObjects = base.transform.gameObject.scene.GetRootGameObjects();
				for (int i = 0; i < rootGameObjects.Length; i++)
				{
					TabButtonUGUI component = rootGameObjects[i].GetComponent<TabButtonUGUI>();
					if (component != null && component.GroupID == GroupID && (component.gameObject.activeSelf || includeInactive))
					{
						list.Add(component);
					}
				}
			}
			else
			{
				for (int j = 0; j < parent.childCount; j++)
				{
					TabButtonUGUI component2 = parent.GetChild(j).GetComponent<TabButtonUGUI>();
					if (component2 != null && component2.GroupID == GroupID && (component2.gameObject.activeSelf || includeInactive))
					{
						list.Add(component2);
					}
				}
			}
			return list;
		}
	}
}
