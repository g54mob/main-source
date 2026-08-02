using JUTPS.InventorySystem;
using JUTPS.JUInputSystem;
using JUTPSEditor.JUHeader;
using UnityEngine;
using UnityEngine.InputSystem;

namespace JUTPS.ItemSystem
{
	[AddComponentMenu("JU TPS/Item System/Item Switch Manager")]
	public class ItemSwitchManager : MonoBehaviour
	{
		[JUHeader("Settings")]
		public bool IsPlayer;

		public bool UseOldInputSystem;

		[SerializeField]
		private JUCharacterController JuTPSCharacter;

		public int ItemToEquipOnStart = -1;

		[JUHeader("Next-Previous Item Switch [Q-E]")]
		public bool EnableNextAndPreviousWeaponSwitch;

		[Tooltip("[OLD INPUT SYSTEM ONLY]")]
		public KeyCode CustomNextWeaponKeyCode;

		[Tooltip("[OLD INPUT SYSTEM ONLY]")]
		public KeyCode CustomPreviousWeaponKeycode;

		[JUHeader("Alpha Numeric Item Switch")]
		public bool EnableAlphaNumericWeaponSwitch;

		[JUHeader("Mouse Scroll Item Switch")]
		public bool EnableMouseScrollWeaponSwitch;

		public float ScrollThreshold = 0.1f;

		protected virtual void Start()
		{
			if (JuTPSCharacter == null)
			{
				JuTPSCharacter = GetComponent<JUCharacterController>();
				if (JuTPSCharacter != null)
				{
					Invoke("EquipStartItem", 0.2f);
				}
			}
			else
			{
				Invoke("EquipStartItem", 0.2f);
			}
			IsPlayer = base.gameObject.tag == "Player";
		}

		protected virtual void Update()
		{
			if (IsPlayer && !JuTPSCharacter.IsMeleeAttacking && !JuTPSCharacter.IsRagdolled && !JuTPSCharacter.IsDead && !JuTPSCharacter.IsRolling)
			{
				OldInput_ItemSwitchController();
				NewInput_ItemSwitchController();
			}
		}

		private void EquipStartItem()
		{
			JuTPSCharacter.SwitchToItem(ItemToEquipOnStart);
		}

		protected virtual void OldInput_ItemSwitchController()
		{
			if (!UseOldInputSystem)
			{
				return;
			}
			if (EnableNextAndPreviousWeaponSwitch)
			{
				if (CustomNextWeaponKeyCode != KeyCode.None)
				{
					if (Input.GetKeyDown(CustomNextWeaponKeyCode))
					{
						JuTPSCharacter.SwitchToNextItem();
					}
				}
				else if (JUInput.GetButtonDown(JUInput.Buttons.NextWeaponButton))
				{
					Debug.Log("Switch manager tentou trocar para o proximo item");
					JuTPSCharacter.SwitchToNextItem();
				}
				if (CustomPreviousWeaponKeycode != KeyCode.None)
				{
					if (Input.GetKeyDown(CustomPreviousWeaponKeycode))
					{
						JuTPSCharacter.SwitchToPreviousItem();
					}
				}
				else if (JUInput.GetButtonDown(JUInput.Buttons.PreviousWeaponButton))
				{
					JuTPSCharacter.SwitchToPreviousItem();
				}
			}
			if (EnableMouseScrollWeaponSwitch)
			{
				if (Input.GetAxis("Mouse ScrollWheel") >= ScrollThreshold)
				{
					JuTPSCharacter.SwitchToNextItem();
				}
				if (Input.GetAxis("Mouse ScrollWheel") <= 0f - ScrollThreshold)
				{
					JuTPSCharacter.SwitchToPreviousItem();
				}
			}
			if (!EnableAlphaNumericWeaponSwitch)
			{
				return;
			}
			for (int i = 48; i < 58; i++)
			{
				int key = i;
				int num = i - 49;
				if (Input.GetKeyDown((KeyCode)key) && num < JuTPSCharacter.Inventory.HoldableItensRightHand.Length)
				{
					JuTPSCharacter.SwitchToItem(num);
				}
			}
		}

		protected virtual void NewInput_ItemSwitchController()
		{
			if (UseOldInputSystem || JUInput.Instance() == null || JUInput.Instance().InputActions == null)
			{
				return;
			}
			if (EnableNextAndPreviousWeaponSwitch)
			{
				if (JUInput.GetButtonDown(JUInput.Buttons.NextWeaponButton))
				{
					JuTPSCharacter.SwitchToNextItem();
				}
				if (JUInput.GetButtonDown(JUInput.Buttons.PreviousWeaponButton))
				{
					JuTPSCharacter.SwitchToPreviousItem();
				}
			}
			if (EnableMouseScrollWeaponSwitch)
			{
				if (Mouse.current.scroll.ReadValue().y / 360f >= ScrollThreshold)
				{
					JuTPSCharacter.SwitchToNextItem();
				}
				if (Mouse.current.scroll.ReadValue().y / 360f <= 0f - ScrollThreshold)
				{
					JuTPSCharacter.SwitchToPreviousItem();
				}
			}
			if (EnableAlphaNumericWeaponSwitch)
			{
				if (JUInput.Instance().InputActions.Player.Slot1.triggered)
				{
					SwitchToItemInSequentialSlot(JUInventory.SequentialSlotsEnum.first);
				}
				if (JUInput.Instance().InputActions.Player.Slot2.triggered)
				{
					SwitchToItemInSequentialSlot(JUInventory.SequentialSlotsEnum.second);
				}
				if (JUInput.Instance().InputActions.Player.Slot3.triggered)
				{
					SwitchToItemInSequentialSlot(JUInventory.SequentialSlotsEnum.third);
				}
				if (JUInput.Instance().InputActions.Player.Slot4.triggered)
				{
					SwitchToItemInSequentialSlot(JUInventory.SequentialSlotsEnum.fourth);
				}
				if (JUInput.Instance().InputActions.Player.Slot5.triggered)
				{
					SwitchToItemInSequentialSlot(JUInventory.SequentialSlotsEnum.fifth);
				}
				if (JUInput.Instance().InputActions.Player.Slot6.triggered)
				{
					SwitchToItemInSequentialSlot(JUInventory.SequentialSlotsEnum.sixth);
				}
				if (JUInput.Instance().InputActions.Player.Slot7.triggered)
				{
					SwitchToItemInSequentialSlot(JUInventory.SequentialSlotsEnum.seventh);
				}
				if (JUInput.Instance().InputActions.Player.Slot8.triggered)
				{
					SwitchToItemInSequentialSlot(JUInventory.SequentialSlotsEnum.eighth);
				}
				if (JUInput.Instance().InputActions.Player.Slot9.triggered)
				{
					SwitchToItemInSequentialSlot(JUInventory.SequentialSlotsEnum.ninth);
				}
				if (JUInput.Instance().InputActions.Player.Slot10.triggered)
				{
					SwitchToItemInSequentialSlot(JUInventory.SequentialSlotsEnum.tenth);
				}
			}
		}

		public virtual void NextItem()
		{
			JuTPSCharacter.SwitchToNextItem();
		}

		public virtual void PreviousItem()
		{
			JuTPSCharacter.SwitchToPreviousItem();
		}

		public virtual void SwitchToItem(int SwitchID)
		{
			if (SwitchID < JuTPSCharacter.Inventory.HoldableItensRightHand.Length)
			{
				if (!JuTPSCharacter.IsItemEquiped)
				{
					JuTPSCharacter.SwitchToItem(SwitchID);
				}
				else if (JuTPSCharacter.HoldableItemInUseRightHand.ItemSwitchID != SwitchID)
				{
					JuTPSCharacter.SwitchToItem(SwitchID);
				}
			}
			else
			{
				Debug.LogWarning("Unable to switch to this item, this ID is out of bounds for the list");
			}
		}

		public virtual void SwitchToItemInSequentialSlot(JUInventory.SequentialSlotsEnum Slot)
		{
			Item sequentialSlotItem = JuTPSCharacter.Inventory.GetSequentialSlotItem(Slot);
			if (!(sequentialSlotItem == null))
			{
				JUInventory.GetGlobalItemSwitchID(sequentialSlotItem, JuTPSCharacter.Inventory);
			}
			if (sequentialSlotItem == null)
			{
				SwitchToItem(-1);
			}
			else
			{
				SwitchToItem(sequentialSlotItem.ItemSwitchID);
			}
		}

		public static void SwitchCharacterItem(JUCharacterController character, int SwitchID)
		{
			if (SwitchID < character.Inventory.HoldableItensRightHand.Length)
			{
				character.SwitchToItem(SwitchID);
			}
			else
			{
				Debug.LogWarning("Unable to switch to item with ID " + SwitchID + " , this ID is out of bounds for the list");
			}
		}

		public static void SwitchPlayerItem(int SwitchID)
		{
			if (GameObject.FindGameObjectWithTag("Player") == null)
			{
				Debug.LogError("Could not find a gameobject tagged 'Player'");
				return;
			}
			JUCharacterController component = GameObject.FindGameObjectWithTag("Player").GetComponent<JUCharacterController>();
			if (SwitchID < component.Inventory.HoldableItensRightHand.Length)
			{
				component.SwitchToItem(SwitchID);
			}
			else
			{
				Debug.LogWarning("Unable to switch to item with ID " + SwitchID + " , this ID is out of bounds for the list");
			}
		}

		public static void NextPlayerItem()
		{
			if (GameObject.FindGameObjectWithTag("Player") == null)
			{
				Debug.LogError("Could not find a gameobject tagged 'Player'");
			}
			else
			{
				GameObject.FindGameObjectWithTag("Player").GetComponent<JUCharacterController>().SwitchToNextItem();
			}
		}

		public static void PreviousPlayerItem()
		{
			if (GameObject.FindGameObjectWithTag("Player") == null)
			{
				Debug.LogError("Could not find a gameobject tagged 'Player'");
			}
			else
			{
				GameObject.FindGameObjectWithTag("Player").GetComponent<JUCharacterController>().SwitchToPreviousItem();
			}
		}
	}
}
