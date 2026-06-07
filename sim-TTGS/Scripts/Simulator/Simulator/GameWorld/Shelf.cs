using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Simulator.GameWorld
{
	public class Shelf : GroundFurniture
	{
		[Header("Stands")]
		[SerializeField]
		private ShelfStand m_standLeft;

		[SerializeField]
		private ShelfStand m_standRight;

		private bool m_characterContextRegistered;

		private bool m_stackChangeRegistered;

		private bool m_boxOpeningRegistered;

		private StackableBox m_boxToWatchOpening;

		protected override void OnEnable()
		{
			base.OnEnable();
			EventManager.OnWorldEvent += OnWorldEvent;
			RegisterToCharacterContextChanged(register: true);
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			EventManager.OnWorldEvent -= OnWorldEvent;
			RegisterToCharacterContextChanged(register: false);
			RegisterToBoxOpening(register: false);
			RegisterToStackChanged(register: false);
		}

		protected virtual void OnWorldEvent(EWorldEvent e)
		{
			if (e == EWorldEvent.PREPARE_QUIT)
			{
				RegisterToCharacterContextChanged(register: false);
			}
		}

		private void RegisterToCharacterContextChanged(bool register)
		{
			if (m_characterContextRegistered != register && !(World.PlayerCharacter == null))
			{
				m_characterContextRegistered = register;
				if (register)
				{
					World.PlayerCharacter.CharacterContextChanged += OnCharacterContextChanged;
				}
				else
				{
					World.PlayerCharacter.CharacterContextChanged -= OnCharacterContextChanged;
				}
			}
		}

		private void RegisterToStackChanged(bool register)
		{
			if (m_stackChangeRegistered == register)
			{
				return;
			}
			m_stackChangeRegistered = register;
			List<ShelfInteractable> list = GetAllShelfInteractables().ToList();
			for (int i = 0; i < list.Count; i++)
			{
				if (register)
				{
					list[i].Stack.Stacked += OnStackChanged;
					list[i].Stack.Poped += OnStackChanged;
				}
				else
				{
					list[i].Stack.Stacked -= OnStackChanged;
					list[i].Stack.Poped -= OnStackChanged;
				}
			}
		}

		private void RegisterToBoxOpening(bool register)
		{
			if (m_boxOpeningRegistered != register && !(m_boxToWatchOpening == null))
			{
				m_boxOpeningRegistered = register;
				if (register)
				{
					m_boxToWatchOpening.OnOpened += OnBoxOpened;
					return;
				}
				m_boxToWatchOpening.OnOpened -= OnBoxOpened;
				m_boxToWatchOpening = null;
			}
		}

		private void RegisterToCharacterHandContentChanged(bool register, PlayerCharacter character)
		{
			if (register)
			{
				character.HandContentChanged += OnCharacterHandContentChanged;
			}
			else
			{
				character.HandContentChanged -= OnCharacterHandContentChanged;
			}
		}

		private void OnCharacterContextChanged(EPlayerCharacterContext oldContext, EPlayerCharacterContext newContext)
		{
			PlayerCharacter playerCharacter = World.PlayerCharacter;
			if (oldContext == EPlayerCharacterContext.GRABBING)
			{
				HighlightCompatibleShelves(playerCharacter, active: false);
				RegisterToCharacterHandContentChanged(register: false, playerCharacter);
				RegisterToStackChanged(register: false);
				RegisterToBoxOpening(register: false);
			}
			if (newContext != EPlayerCharacterContext.GRABBING)
			{
				return;
			}
			RegisterToCharacterHandContentChanged(register: true, playerCharacter);
			RegisterToStackChanged(register: true);
			if (playerCharacter.HasGrabbable(out var grabbable))
			{
				if (grabbable is StackableBox stackableBox)
				{
					if (stackableBox.IsOpen)
					{
						HighlightCompatibleShelves(playerCharacter, active: true);
						return;
					}
					m_boxToWatchOpening = stackableBox;
					RegisterToBoxOpening(register: true);
				}
			}
			else
			{
				HighlightCompatibleShelves(playerCharacter, active: true);
			}
		}

		private void OnStackChanged()
		{
			PlayerCharacter playerCharacter = World.PlayerCharacter;
			HighlightCompatibleShelves(playerCharacter, active: false);
			HighlightCompatibleShelves(playerCharacter, active: true);
		}

		private void OnCharacterHandContentChanged()
		{
			PlayerCharacter playerCharacter = World.PlayerCharacter;
			HighlightCompatibleShelves(playerCharacter, active: false);
			HighlightCompatibleShelves(playerCharacter, active: true);
		}

		private void OnBoxOpened()
		{
			RegisterToBoxOpening(register: false);
			HighlightCompatibleShelves(World.PlayerCharacter, active: true);
		}

		private void HighlightCompatibleShelves(Character character, bool active)
		{
			List<ShelfInteractable> list = ((!active) ? GetAllShelfInteractables().ToList() : GetAllUsableShelfInteractablesForCharacter(character).ToList());
			foreach (ShelfInteractable item in list)
			{
				item.Highlight(active);
			}
		}

		public virtual IEnumerable<ShelfInteractable> GetAllShelfInteractables()
		{
			if ((bool)m_standLeft)
			{
				foreach (ShelfInteractable allShelfInteractable in m_standLeft.GetAllShelfInteractables())
				{
					yield return allShelfInteractable;
				}
			}
			if (!m_standRight)
			{
				yield break;
			}
			foreach (ShelfInteractable allShelfInteractable2 in m_standRight.GetAllShelfInteractables())
			{
				yield return allShelfInteractable2;
			}
		}

		public virtual IEnumerable<ShelfInteractable> GetAllUsableShelfInteractablesForCharacter(Character character)
		{
			if ((bool)m_standLeft)
			{
				foreach (ShelfInteractable item in m_standLeft.GetUsableShelfInteractablesForCharacter(character))
				{
					yield return item;
				}
			}
			if (!m_standRight)
			{
				yield break;
			}
			foreach (ShelfInteractable item2 in m_standRight.GetUsableShelfInteractablesForCharacter(character))
			{
				yield return item2;
			}
		}

		public override void Load(int phase, SaveClass_Furnitures.FurnitureState state)
		{
			base.Load(phase, state);
			if (phase != 1 || !(state is SaveClass_Furnitures.ShelfState shelfState))
			{
				return;
			}
			int num = 0;
			foreach (ShelfInteractable allShelfInteractable in GetAllShelfInteractables())
			{
				if (shelfState.shelfStacks.IsIndexValid(num))
				{
					if (shelfState.shelfStacks[num].quantity > 0 && ProductDatabase.TryGet(shelfState.shelfStacks[num].productUID, out var productData))
					{
						allShelfInteractable.Stack.Fill(productData, shelfState.shelfStacks[num].quantity);
					}
					allShelfInteractable.Label.SetProductState(shelfState.shelfStacks[num].labelState);
				}
				num++;
			}
		}

		public override SaveClass_Furnitures.FurnitureState Save()
		{
			return new SaveClass_Furnitures.ShelfState(this);
		}

		public override void OnStartMoveBy(FurnitureMover mover)
		{
			base.OnStartMoveBy(mover);
			if ((bool)m_standLeft)
			{
				m_standLeft.SetActive(active: false);
			}
			if ((bool)m_standRight)
			{
				m_standRight.SetActive(active: false);
			}
		}

		protected override void OnStopMove()
		{
			base.OnStopMove();
			if ((bool)m_standLeft)
			{
				m_standLeft.SetActive(active: true);
			}
			if ((bool)m_standRight)
			{
				m_standRight.SetActive(active: true);
			}
		}
	}
}
