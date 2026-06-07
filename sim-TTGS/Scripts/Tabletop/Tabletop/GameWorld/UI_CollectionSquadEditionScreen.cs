using System;
using System.Collections.Generic;
using Dhs5.Utility.Updates;
using Simulator;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Tabletop.GameWorld
{
	public class UI_CollectionSquadEditionScreen : MonoBehaviour, IActivable
	{
		[Header("UI Components")]
		[SerializeField]
		private NavBox m_navBox;

		[SerializeField]
		private UI_CollectionSquadMiniatureSlot[] m_slots;

		[SerializeField]
		private UI_CollectionSquadEditionItemContainer m_itemsContainerNavBox;

		[SerializeField]
		private NavInputField m_squadNameInputField;

		[SerializeField]
		private Image m_licenseImage;

		[SerializeField]
		private Image m_army1Image;

		[SerializeField]
		private Image m_army2Image;

		[SerializeField]
		private TextMeshProUGUI m_lifePointsText;

		[SerializeField]
		private NavButton m_statisticsButton;

		[SerializeField]
		private NavButton m_validateButton;

		[SerializeField]
		private NavButton m_closeButton;

		[Header("Prefabs")]
		[SerializeField]
		private GameObject m_itemPrefab;

		private List<UI_CollectionSquadItem> m_items = new List<UI_CollectionSquadItem>();

		private CollectionWargameSquad m_squad;

		public static int CurrentlyEditedSlot { get; set; }

		public static CollectionWargameSquad CurrentlyEditedSquad { get; private set; }

		public bool IsActive => base.gameObject.activeSelf;

		public event Action Closed;

		public static event Action<CollectionWargameSquad> SquadModified;

		protected void OnEnable()
		{
			RegisterUICallbacks(register: true);
		}

		protected void OnDisable()
		{
			RegisterUICallbacks(register: false);
		}

		public bool TryAddMiniatureToSquad(int miniatureUID)
		{
			if (m_items.Count < WargameSettings.SquadSize)
			{
				MiniatureData miniatureData = MiniatureDatabase.Get(miniatureUID);
				if (miniatureData == null)
				{
					return false;
				}
				if (m_squad.Armies.IsValid() && m_squad.Armies.Count == WargameSettings.MaxArmyBySquad && !m_squad.Armies.Contains(miniatureData.Army))
				{
					return false;
				}
				int slotIndex = -1;
				for (int i = 0; i < m_slots.Length; i++)
				{
					if (m_slots[i].Item == null)
					{
						slotIndex = i;
						break;
					}
				}
				if (CreateItem(miniatureData, slotIndex))
				{
					UpdateCollectionSquadContent();
					return true;
				}
			}
			return false;
		}

		public void RefreshMiniatureImages()
		{
			foreach (UI_CollectionSquadItem item in m_items)
			{
				item.RefreshMiniatureImage();
			}
		}

		public void SelectCloseButton()
		{
			m_closeButton.Select();
		}

		private void RefreshContent()
		{
			m_squad = Collection.GetSquadAtIndex(CurrentlyEditedSlot);
			bool hasLicense = true;
			if (!m_squad.Exists)
			{
				m_squad = CollectionWargameSquad.CreateNew();
				hasLicense = false;
			}
			m_itemsContainerNavBox.ClearAllElements();
			InitItems(m_squad);
			SetItemsNeighbours();
			m_navBox.SetCurrentElement(m_itemsContainerNavBox);
			UpdateVisualContent(hasLicense);
			Updater.CallInXFrames(1, NotifySquadModified, out var _);
		}

		private void UpdateCollectionSquadContent()
		{
			int[] array = new int[WargameSettings.SquadSize];
			bool hasLicense = false;
			ELicense license = ELicense.FWB;
			List<EMiniatureArmy> list = new List<EMiniatureArmy>();
			for (int i = 0; i < array.Length; i++)
			{
				if (m_slots[i].Item != null)
				{
					array[i] = m_slots[i].Item.Data.UID;
					hasLicense = true;
					license = m_slots[i].Item.Data.License;
					if (!list.Contains(m_slots[i].Item.Data.Army))
					{
						list.Add(m_slots[i].Item.Data.Army);
					}
				}
				else
				{
					array[i] = 0;
				}
			}
			m_squad = new CollectionWargameSquad(m_squad, license, list, array);
			SetItemsNeighbours();
			if (m_squad.Armies.Count > 0)
			{
				m_navBox.SetCurrentElement(m_itemsContainerNavBox);
			}
			UpdateVisualContent(hasLicense);
			NotifySquadModified();
		}

		private void UpdateVisualContent(bool hasLicense)
		{
			m_squadNameInputField.InputField.text = m_squad.Name;
			m_licenseImage.enabled = hasLicense;
			m_licenseImage.sprite = MiniatureSettings.GetLicenseSprite(m_squad.License);
			if (m_squad.Armies.IsValid())
			{
				m_army1Image.sprite = MiniatureSettings.GetArmySprite(m_squad.Armies[0]);
				m_army1Image.enabled = true;
				m_army2Image.sprite = ((m_squad.Armies.Count > 1) ? MiniatureSettings.GetArmySprite(m_squad.Armies[1]) : null);
				m_army2Image.enabled = m_squad.Armies.Count > 1;
			}
			else
			{
				m_army1Image.enabled = false;
				m_army2Image.enabled = false;
			}
			int num = 0;
			for (int i = 0; i < m_slots.Length; i++)
			{
				if (m_slots[i].Item != null)
				{
					num += m_slots[i].Item.Data.Skill.LifePoints;
				}
			}
			if (m_lifePointsText != null)
			{
				m_lifePointsText.text = num.ToString();
			}
		}

		private void NotifySquadModified()
		{
			CurrentlyEditedSquad = m_squad;
			UI_CollectionSquadEditionScreen.SquadModified?.Invoke(m_squad);
		}

		public void SetActive(bool active)
		{
			if (IsActive != active)
			{
				base.gameObject.SetActive(active);
				if (active)
				{
					OnSetActive();
					m_navBox.SetActive();
				}
				else
				{
					m_navBox.SetInactive();
					OnSetInactive();
				}
			}
		}

		private void OnSetActive()
		{
			RefreshContent();
		}

		private void OnSetInactive()
		{
			ClearItemsAndSlots();
		}

		private void RegisterUICallbacks(bool register)
		{
			if (register)
			{
				for (int i = 0; i < m_slots.Length; i++)
				{
					m_slots[i].WelcomedItem += OnSlotWelcomeItem;
				}
				m_squadNameInputField.InputField.onSubmit.AddListener(OnSquadNameValueChanged);
				m_squadNameInputField.InputField.onEndEdit.AddListener(OnSquadNameValueChanged);
				m_squadNameInputField.InputField.onSelect.AddListener(OnInputField_Selected);
				m_squadNameInputField.InputField.onDeselect.AddListener(OnInputField_Deselected);
				m_statisticsButton.Button.onClick.AddListener(OnButton_Statistics);
				m_validateButton.Button.onClick.AddListener(OnButton_Validate);
				m_closeButton.Button.onClick.AddListener(OnButton_Close);
			}
			else
			{
				for (int j = 0; j < m_slots.Length; j++)
				{
					m_slots[j].WelcomedItem -= OnSlotWelcomeItem;
				}
				m_squadNameInputField.InputField.onSubmit.RemoveListener(OnSquadNameValueChanged);
				m_squadNameInputField.InputField.onEndEdit.RemoveListener(OnSquadNameValueChanged);
				m_squadNameInputField.InputField.onSelect.RemoveListener(OnInputField_Selected);
				m_squadNameInputField.InputField.onDeselect.RemoveListener(OnInputField_Deselected);
				m_statisticsButton.Button.onClick.RemoveListener(OnButton_Statistics);
				m_validateButton.Button.onClick.RemoveListener(OnButton_Validate);
				m_closeButton.Button.onClick.RemoveListener(OnButton_Close);
			}
		}

		private void ClearItemsAndSlots()
		{
			for (int i = 0; i < m_items.Count; i++)
			{
				UnityEngine.Object.Destroy(m_items[i].gameObject);
			}
			m_items.Clear();
			for (int j = 0; j < m_slots.Length; j++)
			{
				m_slots[j].Clear();
			}
		}

		private void InitItems(CollectionWargameSquad squad)
		{
			m_items = new List<UI_CollectionSquadItem>();
			for (int i = 0; i < WargameSettings.SquadSize; i++)
			{
				CreateItem(MiniatureDatabase.Get(squad.GetMiniatureUID(i)), i);
			}
		}

		private bool CreateItem(MiniatureData miniatureData, int slotIndex)
		{
			if (miniatureData == null || slotIndex < 0 || slotIndex >= m_slots.Length)
			{
				return false;
			}
			UI_CollectionSquadItem component = UnityEngine.Object.Instantiate(m_itemPrefab, m_itemsContainerNavBox.transform).GetComponent<UI_CollectionSquadItem>();
			m_itemsContainerNavBox.AddItem(component);
			m_slots[slotIndex].WelcomeItem(component, callback: false);
			component.Init(miniatureData);
			component.DeletedItem += OnDeleteItem;
			m_items.Add(component);
			return true;
		}

		public UI_CollectionSquadItem GetRightSquadItem(int startIndex)
		{
			for (int i = startIndex + 1; i < m_slots.Length; i++)
			{
				if (m_slots[i].Item != null)
				{
					return m_slots[i].Item;
				}
			}
			return null;
		}

		public UI_CollectionSquadItem GetLeftSquadItem(int startIndex)
		{
			for (int num = startIndex - 1; num >= 0; num--)
			{
				if (m_slots[num].Item != null)
				{
					return m_slots[num].Item;
				}
			}
			return null;
		}

		public UI_CollectionSquadMiniatureSlot GetRightSlot(int startIndex)
		{
			if (startIndex + 1 >= m_slots.Length)
			{
				return null;
			}
			return m_slots[startIndex + 1];
		}

		public UI_CollectionSquadMiniatureSlot GetLeftSlot(int startIndex)
		{
			if (startIndex - 1 < 0)
			{
				return null;
			}
			return m_slots[startIndex - 1];
		}

		private void SetItemsNeighbours()
		{
			for (int i = 0; i < m_slots.Length; i++)
			{
				if (!(m_slots[i].Item == null))
				{
					UI_CollectionSquadItem rightSquadItem = GetRightSquadItem(i);
					UI_CollectionSquadItem leftSquadItem = GetLeftSquadItem(i);
					m_slots[i].Item.SetNeighbours(new SimpleNavElementNeighbours
					{
						RightNeighbour = rightSquadItem,
						LeftNeighbour = leftSquadItem
					});
				}
			}
		}

		private void OnSlotWelcomeItem()
		{
			UpdateCollectionSquadContent();
		}

		private void OnDeleteItem(int slotIndex)
		{
			UI_CollectionSquadItem item = m_slots[slotIndex].Item;
			if (item != null)
			{
				m_items.Remove(item);
				m_itemsContainerNavBox.RemoveItem(item);
				UnityEngine.Object.Destroy(item.gameObject);
				m_slots[slotIndex].Clear();
				if (TransientManager<InputManager>.Instance.CurrentDevice == EInputDeviceType.GAMEPAD)
				{
					m_navBox.NavigateTo(m_navBox.GetNeighbour(MoveDirection.Down), searchForFirstElement: true, MoveDirection.Right);
				}
				UpdateCollectionSquadContent();
			}
		}

		private void OnSquadNameValueChanged(string name)
		{
			if (TransientManager<InputManager>.Instance.CurrentDevice == EInputDeviceType.KEYBOARD)
			{
				if (ProfanityManager.ProfanityFilter.ContainsProfanity(name))
				{
					m_squadNameInputField.InputField.text = m_squad.Name;
					return;
				}
				m_squad.Name = name;
				m_squadNameInputField.Select();
			}
		}

		private void OnInputField_Selected(string str)
		{
			InputManager.InputFieldFocused = true;
		}

		private void OnInputField_Deselected(string str)
		{
			InputManager.InputFieldFocused = false;
		}

		private void OnButton_Statistics()
		{
		}

		private void OnButton_Validate()
		{
			Collection.SetSquadAtIndex(CurrentlyEditedSlot, m_squad);
			this.Closed?.Invoke();
		}

		private void OnButton_Close()
		{
			this.Closed?.Invoke();
		}
	}
}
