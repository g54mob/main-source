using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Simulator.GameWorld
{
	public class ReserveShelf : GroundFurniture
	{
		[Header("Stands")]
		[SerializeField]
		private ReserveShelfStand m_standLeft;

		[SerializeField]
		private ReserveShelfStand m_standRight;

		private bool m_characterContextRegistered;

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
			}
			if (newContext != EPlayerCharacterContext.GRABBING)
			{
				return;
			}
			RegisterToCharacterHandContentChanged(register: true, playerCharacter);
			if (playerCharacter.HasGrabbable(out var grabbable))
			{
				if (grabbable is StackableBox)
				{
					HighlightCompatibleShelves(playerCharacter, active: true);
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

		private void HighlightCompatibleShelves(Character character, bool active)
		{
			List<ReserveShelfInteractable> list = ((!active) ? GetAllShelfInteractables().ToList() : GetAllUsableShelfInteractablesForCharacter(character).ToList());
			foreach (ReserveShelfInteractable item in list)
			{
				item.Highlight(active);
			}
		}

		public IEnumerable<ReserveShelfInteractable> GetAllShelfInteractables()
		{
			if ((bool)m_standLeft)
			{
				foreach (ReserveShelfInteractable allShelfInteractable in m_standLeft.GetAllShelfInteractables())
				{
					yield return allShelfInteractable;
				}
			}
			if (!m_standRight)
			{
				yield break;
			}
			foreach (ReserveShelfInteractable allShelfInteractable2 in m_standRight.GetAllShelfInteractables())
			{
				yield return allShelfInteractable2;
			}
		}

		public IEnumerable<ReserveShelfInteractable> GetAllUsableShelfInteractablesForCharacter(Character character)
		{
			if ((bool)m_standLeft)
			{
				foreach (ReserveShelfInteractable item in m_standLeft.GetUsableShelfInteractablesForCharacter(character))
				{
					yield return item;
				}
			}
			if (!m_standRight)
			{
				yield break;
			}
			foreach (ReserveShelfInteractable item2 in m_standRight.GetUsableShelfInteractablesForCharacter(character))
			{
				yield return item2;
			}
		}

		public override void Load(int phase, SaveClass_Furnitures.FurnitureState state)
		{
			base.Load(phase, state);
			if (phase != 1 || !(state is SaveClass_Furnitures.ReserveShelfState reserveShelfState))
			{
				return;
			}
			int num = 0;
			foreach (ReserveShelfInteractable allShelfInteractable in GetAllShelfInteractables())
			{
				if (reserveShelfState.shelfInteractables.IsIndexValid(num))
				{
					allShelfInteractable.Load(phase, reserveShelfState.shelfInteractables[num]);
				}
				num++;
			}
		}

		public override SaveClass_Furnitures.FurnitureState Save()
		{
			return new SaveClass_Furnitures.ReserveShelfState(this);
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
