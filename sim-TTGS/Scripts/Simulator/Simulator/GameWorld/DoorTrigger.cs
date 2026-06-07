using System;
using System.Collections.Generic;
using Dhs5.Utility.Tags;
using UnityEngine;

namespace Simulator.GameWorld
{
	public class DoorTrigger : MonoBehaviour
	{
		[Header("References")]
		[SerializeField]
		private Door m_door;

		[Header("State")]
		[SerializeField]
		[ReadOnly(false, false)]
		private List<Character> m_insideCharacters = new List<Character>();

		public event Action CharacterListChanged;

		private void OnEnable()
		{
			EventManager.OnGameEvent += OnGameEvent;
		}

		private void OnDisable()
		{
			EventManager.OnGameEvent -= OnGameEvent;
		}

		public bool HasCharacterInside()
		{
			return m_insideCharacters.Count > 0;
		}

		public bool HasPlayerInside()
		{
			foreach (Character insideCharacter in m_insideCharacters)
			{
				if (insideCharacter.IsPlayer)
				{
					return true;
				}
			}
			return false;
		}

		private void OnTriggerEnter(Collider other)
		{
			if (IsColliderACharacterOfTags(other, m_door.RequiredTags, out var character) && !m_insideCharacters.Contains(character))
			{
				CharacterEnter(character);
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if (IsColliderACharacterOfTags(other, m_door.RequiredTags, out var character))
			{
				CharacterExit(character);
			}
		}

		private bool IsColliderACharacterOfTags(Collider collider, GameplayTagsList gameplayTagsList, out Character character)
		{
			Rigidbody attachedRigidbody = collider.attachedRigidbody;
			if (((attachedRigidbody != null) ? attachedRigidbody.gameObject : collider.gameObject).TryGetComponent<Character>(out character))
			{
				return character.ContainsAnyGameplayTags(gameplayTagsList);
			}
			return false;
		}

		private void CharacterEnter(Character character)
		{
			if (character.IsPlayer)
			{
				PlayerCharacterMovement.Teleported += OnPlayerCharacterTeleported;
			}
			m_insideCharacters.Add(character);
			OnCharacterListChange();
		}

		private void CharacterExit(Character character)
		{
			if (character.IsPlayer)
			{
				PlayerCharacterMovement.Teleported -= OnPlayerCharacterTeleported;
			}
			if (m_insideCharacters.Remove(character))
			{
				OnCharacterListChange();
			}
		}

		private void OnCharacterListChange()
		{
			this.CharacterListChanged?.Invoke();
		}

		private void ClearList()
		{
			foreach (Character insideCharacter in m_insideCharacters)
			{
				if (insideCharacter.IsPlayer)
				{
					PlayerCharacterMovement.Teleported -= OnPlayerCharacterTeleported;
				}
			}
			m_insideCharacters.Clear();
			OnCharacterListChange();
		}

		private void OnPlayerCharacterTeleported(Character character)
		{
			CharacterExit(character);
		}

		protected virtual void OnGameEvent(EGameEvent e)
		{
			if (e == EGameEvent.DAY_START)
			{
				ClearList();
			}
		}
	}
}
